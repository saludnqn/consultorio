using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DalSic;
using SubSonic;
using Salud.Security.SSO;
using System.Collections.Generic;

namespace Consultorio.Turnos
{
    public partial class AsistenciaEdit : System.Web.UI.Page
    {

        private DataTable dtGrilla
        {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }  
        
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {

                if (Request.QueryString["idAgenda"] != string.Empty)
                {
                    int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                    
                    if (idAgenda > 0)
                    {
                            actualizarTurnos(idAgenda);                           
                    }
                }
                    
            }
            
        }               

        protected void btnGuardarAsistencia_Click(object sender, EventArgs e)
        {
            GuardarAsistencia(); Response.Redirect("../Agenda/AgendaList.aspx", false);
        }

        private void GuardarAsistencia()
        {            
            foreach (GridViewRow row in gvTurnos.Rows)
            {

                int idturno = int.Parse(gvTurnos.DataKeys[row.RowIndex].Value.ToString());
                CheckBox a = ((CheckBox)(row.Cells[0].FindControl("CheckBox1")));
                if (a.Checked == true)
                {

                    ConTurnoAsistencium asist = new ConTurnoAsistencium();
                    asist.IdTurno = idturno;
                    asist.FechaAsistencia = DateTime.Now;
                    asist.IdUsuario = SSOHelper.CurrentIdentity.Id; ;
                    asist.Save();
                }
                else
                {///Si ya tiene un registro de asitencia lo borra
                    Query asist = new Query(Schemas.ConTurnoAsistencium);
                    asist.QueryType = QueryType.Delete;
                    asist.WHERE(ConTurnoAsistencium.Columns.IdTurno, idturno);
                    asist.Execute();
                }
            }

            ///Cierra la agenda
            int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
            ConAgenda ag = new ConAgenda(idAgenda);
            ag.IdAgendaEstado = 4;
            ag.Save();
            grabarAuditoria(ag);
        }


        private void grabarAuditoria(ConAgenda ag)
        {
            string h = Convert.ToString(DateTime.Now.Hour);
            string m = Convert.ToString(DateTime.Now.Minute);
            if (h.Length < 2) { h = "0" + h; }
            if (m.Length < 2) { m = "0" + m; }
            string Hora = h + ":" + m;

            ConAgendaAuditorium aud = new ConAgendaAuditorium();
            aud.IdAgenda = ag.IdAgenda;
            aud.IdUsuario = SSOHelper.CurrentIdentity.Id;
            aud.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
            aud.IdAgendaEstado = ag.IdAgendaEstado;
            aud.IdServicio = ag.IdServicio;
            aud.IdProfesional = ag.IdProfesional;
            aud.IdEspecialidad = ag.IdEspecialidad;
            aud.IdConsultorio = ag.IdConsultorio;
            aud.Fecha = ag.Fecha;
            aud.HoraInicio = ag.HoraInicio;
            aud.HoraFin = ag.HoraFin;
            aud.Duracion = ag.Duracion;
            //    aud.Reservados = ag.Reservados;
            aud.MaxSobreturnos = ag.MaximoSobreturnos;
            aud.CitarPorBloques = 1; // ag.CitarPorBloques;
            aud.FechaModificacion = DateTime.Now;
            aud.HoraModificacion = Hora;
            aud.Save();
        }
        private void actualizarAgendas()
        {
            limpiarGrillaTurnos();         
        }        

        private void limpiarGrillaTurnos()
        {
            gvTurnos.SelectedIndex = -1;
            if (dtGrilla != null)
            {
                for (int i = dtGrilla.Rows.Count - 1; i >= 0; i--)
                {
                    dtGrilla.Rows.Remove(dtGrilla.Rows[i]);
                    dtGrilla.AcceptChanges();
                }
                gvTurnos.DataSource = dtGrilla;
                gvTurnos.DataBind();
            }
        }     

        private DataTable getTurnos(SysPaciente paciente)
        {
            return new Select("idTurno, idTurnoEstado, Fecha, Hora, numeroDocumento as DNI, historiaClinica as HC, (apellido + ' ' + nombre) as Paciente, 'Activo' as Estado, case idTipoTurno when 0 then 'Turno' when 1 then 'Programado' when 2 then 'Interconsulta' end as TipoTurno  ")
                            .From(Schemas.ConTurno).InnerJoin(Schemas.SysPaciente)
                            .Where(ConTurno.Columns.IdPaciente).IsEqualTo(paciente.IdPaciente)
                            .And(ConTurno.Columns.IdTurnoEstado).IsNotEqualTo(4)
                            .ExecuteDataSet().Tables[0];
        }

       
        private DataTable getTurnosPorAgenda(int idAgenda)
        {
            DataTable dt = SPs.ConTurnosPorAgenda(idAgenda).GetDataSet().Tables[0];

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                int idTurno = Convert.ToInt32(dt.Rows[i]["idTurno"]);
                int idTurnoEstado = Convert.ToInt32(dt.Rows[i]["idTurnoEstado"]);

                /// si el estado es reservado chequeo caducidad de reserva
                if (idTurno > 0 & idTurnoEstado == 2)
                {
                    ConTurno t = new ConTurno(idTurno);
                    ConTurnoReserva res = t.ConTurnoReservaRecords.Last<ConTurnoReserva>();

                    DateTime fcaducidad = res.ReservaHasta;
                    if (fcaducidad <= DateTime.Now)
                    {
                        /// venció reserva
                        res.CofirmoTurno = false;
                        res.Save();

                        /// en forma lógica omito leer el paciente que reservaba el turno (luego se pisan los datos del paciente)
                        dt.Rows[i]["idPaciente"] = 0;
                        dt.Rows[i]["idTurnoEstado"] = 1;
                        dt.Rows[i]["Estado"] = "Activo";
                        dt.Rows[i]["DNI"] = "0";
                        dt.Rows[i]["HC"] = "0";
                        dt.Rows[i]["Paciente"] = "";
                        dt.Rows[i]["TipoTurno"] = "";
                        dt.AcceptChanges();
                    }
                }
            }
            return dt;
        }
        private DataTable construirTurnos(int idAgenda)
        {
            ConAgenda ag = new ConAgenda(idAgenda);
            DataTable dt = getTurnosPorAgenda(idAgenda);

            DateTime fecha = ag.Fecha;
            int duracion = ag.Duracion;          
            int maxSbts = ag.MaximoSobreturnos;
            string hIni = ag.HoraInicio;
            string hFin = ag.HoraFin;
            string hora = hIni;

            DateTime hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            DateTime horafin1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hFin);

            do
            {
                if (!existeHoraEnDataTable(dt, hora))
                {
                 //   insertarDataRow(dt, fecha, hora, idAgenda);
                }
                hora = incrementarHora(hora, duracion);
                hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            } while (!(hora1 >= horafin1));
            dt = Rutinas.getDataTableOrdenado(dt, "Fecha, Hora");

            return dt;
        }
        private bool existeHoraEnDataTable(DataTable dt, string hora)
        {
            bool existe = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string horaDt = Convert.ToString(dt.Rows[i]["Hora"]);
                if (hora == horaDt) { existe = true; break; }
            }
            return existe;
        }
        private void insertarDataRow(DataTable dt, DateTime f, string hora, int idAgenda)
        {
            /// inserto en dataset un fila en blanco para la fecha generada
            ConAgenda ag = new ConAgenda(idAgenda);

            DataRow newRow;
            newRow = dt.NewRow();
            newRow["idTurno"] = 0;
            newRow["Sobreturno"] = false;
            newRow["Fecha"] = ag.Fecha.ToString().Substring(0, 10);
            newRow["Hora"] = hora;
            newRow["idPaciente"] = 0;
            newRow["idTurnoEstado"] = 1;

            newRow["DNI"] = "0";
            newRow["HC"] = "0";
            newRow["Paciente"] = "";
            newRow["TipoTurno"] = "";           

            string estadoTurno = "Activo";
            ConTurnoBloqueoCollection srv = new SubSonic.Select()
               .From(Schemas.ConTurnoBloqueo)
                         .Where(ConTurnoBloqueo.Columns.IdAgenda).IsEqualTo(idAgenda)
                         .And(ConTurnoBloqueo.Columns.FechaTurno).IsEqualTo(ag.Fecha)
                         .And(ConTurnoBloqueo.Columns.HoraTurno).IsEqualTo(hora)
                         .OrderDesc(ConTurnoBloqueo.Columns.IdTurnoBloqueo)
                .ExecuteAsCollection<ConTurnoBloqueoCollection>();

            foreach (ConTurnoBloqueo oBloqueo in srv)
            {
                if (oBloqueo.IdUsuarioDesBloqueo == 0)
                    estadoTurno = "Bloqueado";
                else
                    estadoTurno = "Activo";
                break;

            }
            
            newRow["Estado"] = estadoTurno;

            dt.Rows.Add(newRow);
        }

        private string incrementarHora(string Hora, int duracion)
        {
            string h = Hora.Substring(0, 2);
            string m = Hora.Substring(3, 2);
            int horas = Convert.ToInt32(h);
            int minutos = Convert.ToInt32(m);

            minutos += duracion;
            while (minutos >= 60)
            {
                horas += 1;
                minutos -= 60;
            }
            m = minutos.ToString();
            h = horas.ToString();
            if (m.Length < 2) { m = "0" + m; }
            if (h.Length < 2) { h = "0" + h; }

            return h + ":" + m;
        }

        private void actualizarTurnos(int idAgenda)
        {
            ConAgenda ag = new ConAgenda(idAgenda);
            SysProfesional p = new SysProfesional(ag.IdProfesional);
            string especialidad = "";

            if (ag.IdAgendaEstado == 4) lblCerrada.Visible = true;
            else lblCerrada.Visible = false;

            if (ag.IdEspecialidad > 0)
            {
                SysEspecialidad oEspecialidad = new SysEspecialidad(ag.IdEspecialidad);
                especialidad = oEspecialidad.Nombre;
            }
            if (ag.IdTipoPrestacion > 0)
            {
                ConTipoPrestacion oPrestacion = new ConTipoPrestacion(ag.IdTipoPrestacion);
                especialidad = oPrestacion.Nombre;
            }

       //     lblTituloAgenda.Text = p.ApellidoyNombre + " - " + especialidad;

            ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                      .From(Schemas.ConAgendaProfesional).InnerJoin(Schemas.SysProfesional)
                      .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                      .ExecuteAsCollection<ConAgendaProfesionalCollection>();

            List<string> listaProfesionales = new List<string>();

            foreach (ConAgendaProfesional data in listaAgendaProfesional)
            {
                lblTituloAgenda.Text += data.SysProfesional.NombreCompleto + " - " + data.SysEspecialidad.Nombre + "<br/>";

            

            }
            lblFechaAgenda.Text = ag.Fecha.ToShortDateString();
            lblHoraAgenda.Text = " (" + ag.HoraInicio + " - " + ag.HoraFin + ")";
       
            dtGrilla = construirTurnos(idAgenda);
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.DataBind();

            if (dtGrilla.Rows.Count == 0)
                btnGuardarAsistencia.Enabled = false;
            else
            {
                if (p.IdProfesional < 0)
                    btnGuardarAsistencia.Enabled = false;
                else
                    btnGuardarAsistencia.Enabled = true;
            }            
        }


        private DataTable getTurnos(ConAgenda agenda)
        {
            return SPs.ConTurnosPorAgenda(agenda.IdAgenda).GetDataSet().Tables[0];
        }

        private DataTable getPlanillaTurnos(ConAgenda agenda)
        {
            return SPs.ConPlanillaPorAgenda(agenda.IdAgenda).GetDataSet().Tables[0];
        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Text = Rutinas.Capitalizar(e.Row.Cells[5].Text);


                Image imgTurno = (Image)e.Row.FindControl("imgTurno");                
                
                int dni = Convert.ToInt32(dtGrilla.Rows[e.Row.RowIndex]["DNI"]);

                string Asistencia = dtGrilla.Rows[e.Row.RowIndex]["Asistencia"].ToString();
                string ConConsulta = dtGrilla.Rows[e.Row.RowIndex]["Consulta"].ToString();

                int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                ConAgenda ag = new ConAgenda(idAgenda);

                if (ag.IdAgendaEstado != 4) //Cerrada                
                {// se puede seleccionar la asistencia
                    CheckBox a = ((CheckBox)(e.Row.Cells[0].FindControl("CheckBox1")));
                    a.Visible = true;
                }
                //else
                //{// no se puede seleccionar la asistencia

                if (Asistencia == "1")
                {
                    if (ag.IdAgendaEstado == 4) //Cerrada     
                        e.Row.Cells[7].Text = "SI";
                    else
                    {
                        CheckBox a = ((CheckBox)(e.Row.Cells[0].FindControl("CheckBox1")));
                        a.Checked = true;
                        a.Visible = true;
                        if (ConConsulta.ToUpper() == "SI") a.Enabled = false;
                        else a.Enabled = true;
                    }

                  //  e.Row.Cells[7].Text = "SI";
                    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.LightYellow;                        
                    }
                }
                else
                {

                    if (ag.IdAgendaEstado == 4) //Cerrada     
                        e.Row.Cells[7].Text = "NO";
                    else
                    {
                        CheckBox a = ((CheckBox)(e.Row.Cells[0].FindControl("CheckBox1")));
                        a.Checked = false;
                        a.Visible = true;
                     
                    }

                }
            //    }


                string Estado = dtGrilla.Rows[e.Row.RowIndex]["Estado"].ToString();


                switch (Estado)
                {
                    case "Activo":
                        {

                            string tipoTurno = dtGrilla.Rows[e.Row.RowIndex]["TipoTurno"].ToString();
                            switch (tipoTurno)
                            {

                                case "":
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/turnoactivo.png";
                                    imgTurno.ToolTip = "Turno activo";
                                    break;

                                case "Turno":
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/check_verde16.png";
                                    imgTurno.ToolTip = "Turno del día";


                                    break;
                                case "Programado":
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/alerta1.png";
                                    imgTurno.ToolTip = "Turno Anticipado";

                                    break;
                                case "SobreTurno":
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/alerta.png";
                                    imgTurno.ToolTip = "Sobre Turno";


                                    break;
                            }


                        } break;
                    case "Bloqueado":
                        {
                            imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/turnobloqueado.png";
                            imgTurno.ToolTip = "Turno bloqueado";
                        } break;
                }            
            }
        }

        private string getDatosReserva(int idTurno)
        {
            ConTurnoReserva r = new Select().From(Schemas.ConTurnoReserva)
                            .Where(ConTurnoReserva.Columns.IdTurno).IsEqualTo(idTurno)
                            .ExecuteSingle<ConTurnoReserva>();
            return "(caduca " + r.ReservaHasta.ToString() + ")";
        }  

        private string getImageUrl(int sexo)
        {
            string url = string.Empty;
            switch (sexo)
            {
                case 1: url = "../../App_Themes/consultorio/Agenda/ayuda32.png"; break;
                case 2: url = "../../App_Themes/consultorio/Agenda/mujer32.png"; break;
                case 3: url = "../../App_Themes/consultorio/Agenda/hombre32.png"; break;
            }
            return url;
        }       

        protected void cmdCancelarAsistencia_Click(object sender, EventArgs e)
        {
          //  leerAsistencia();
        }

        protected bool validarFecha()
        {
            bool valido = true;           
            return valido;
        }        

        private void grabarAsistencia(DateTime fechaNueva)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurnoAsistencium asist = new Select().From(Schemas.ConTurnoAsistencium)
                                                    .Where(ConTurnoAsistencium.Columns.IdTurno)
                                                    .IsEqualTo(idTurno)
                                                    .ExecuteSingle<ConTurnoAsistencium>();
            asist.FechaAsistencia = fechaNueva;
            asist.IdUsuario = SSOHelper.CurrentIdentity.Id;
            asist.Save();
        }

        private void grabarAsistencia()
        {
            ConTurnoAsistencium asist = new ConTurnoAsistencium();
            asist.IdTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            asist.FechaAsistencia = DateTime.Now;
            asist.IdUsuario = SSOHelper.CurrentIdentity.Id;
            asist.Save();
        }

      
        private void borrarAsistencia()
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);

            Query asist = new Query(Schemas.ConTurnoAsistencium);
            asist.QueryType = QueryType.Delete;
            asist.WHERE(ConTurnoAsistencium.Columns.IdTurno, idTurno);
            asist.Execute();
        }

      

        private bool tieneAsistencia(ConTurno t)
        {
            int r = new Select().From(Schemas.ConTurnoAsistencium)
                                .Where(ConTurnoAsistencium.Columns.IdTurno)
                                .IsEqualTo(t.IdTurno).GetRecordCount();
            return (r > 0) ? true : false;
        }       

        private void establecerEstado(ConTurno t, int idTurnoEstado)
        {
            int idAgenda = t.IdAgenda;

            t.IdTurnoEstado = idTurnoEstado;
            t.Save();

            grabarAuditoriaTurno(t);

            actualizarTurnos(idAgenda);         
        }

        private void grabarAuditoriaTurno(ConTurno turno)
        {
            string h = Convert.ToString(DateTime.Now.Hour);
            string m = Convert.ToString(DateTime.Now.Minute);
            if (h.Length < 2) { h = "0" + h; }
            if (m.Length < 2) { m = "0" + m; }
            string hora = h + ":" + m;

            ConTurnoAuditorium aud = new ConTurnoAuditorium();
            aud.IdTurno = turno.IdTurno;
            aud.IdTurnoEstado = turno.IdTurnoEstado;
            aud.IdUsuario = SSOHelper.CurrentIdentity.Id;
            aud.IdServicio = turno.ConAgenda.IdServicio;
            aud.IdProfesional = turno.ConAgenda.IdProfesional;
            aud.IdEspecialidad = turno.ConAgenda.IdEspecialidad;
            aud.IdConsultorio = turno.ConAgenda.IdConsultorio;
            aud.Fecha = turno.Fecha;
            aud.Hora = turno.Hora;
            aud.FechaModificacion = System.DateTime.Now;
            aud.HoraModificacion = hora;
            aud.Save();
        }      

        protected void lnkMarcar_Click(object sender, EventArgs e)
        {
            MarcarSeleccionados(true);
        }

        protected void lnkDesMarcar_Click(object sender, EventArgs e)
        {
            MarcarSeleccionados(false);
        }


        private void MarcarSeleccionados(bool p)
        {
            foreach (GridViewRow row in gvTurnos.Rows)
            {
                CheckBox a = ((CheckBox)(row.Cells[0].FindControl("CheckBox1")));
                if (a.Checked == !p)
                    ((CheckBox)(row.Cells[0].FindControl("CheckBox1"))).Checked = p;
            }

        }

     
    }
}
