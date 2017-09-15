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
using System.Transactions;
using System.Collections.Generic;
using Consultorio.Utilidades;

namespace Consultorio.ConsultaAmbulatoria
{

    /// <summary>
    ///  Comentario para subir de nuevo
    /// </summary>
    public partial class DiagnosticoEdit : System.Web.UI.Page
    {
        private DataTable dtGrilla
        {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        private int idConsulta
        {
            get { return ViewState["idConsulta"] == null ? 0 : Convert.ToInt32(ViewState["idConsulta"]); }
            set { ViewState["idConsulta"] = value; }
        }

        protected void Page_PreInit(object sender, EventArgs e)
{
    if (Request["Tipo"] != null)
        Page.MasterPageFile = "~/mConsultorio.master";
    else
        Page.MasterPageFile = "~/Turno.master";
}


        protected void Page_Load(object sender, EventArgs e)
        {
            SysUsuario us = new SysUsuario(Session["idUsuario"]);   //  LinkButton1.Visible = false;
            if (!us.IsNew)
            {
                if (!IsPostBack)
                {
                    int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                    ConAgenda ag = new ConAgenda(idAgenda);
                    SysProfesional p = new SysProfesional(ag.IdProfesional);
                    string especialidad = "";


                    if (ag.IdEspecialidad > 0)
                    {
                        SysEspecialidad oEspecialidad = new SysEspecialidad(ag.IdEspecialidad);
                        especialidad = oEspecialidad.Nombre;
                    }

                    lblTituloAgenda.Text = p.ApellidoyNombre + " - " + especialidad;
                    lblFechaAgenda.Text = Rutinas.getNombreDia (ag.Fecha).ToUpper() + " " + ag.Fecha.ToShortDateString();
                    lblHoraAgenda.Text = " (" + ag.HoraInicio + " - " + ag.HoraFin + ")";
                    actualizarTurnos(idAgenda);
                    pnlHola.Visible = true;
                    pnlDiagnostico.Visible = false;

                    if (Request["idTurno"] != null)
                    {
                        int idTurno = Convert.ToInt32(Request.QueryString["idTurno"]);
                        if (idTurno > 0)                            mostrarTurno(idTurno);
                    }

                }
            }
            else Response.Redirect("~/FinSesion.aspx", false);

        }

        private void actualizarTurnos(int idAgenda)
        {
            //Carga los turnos de la agenda
            ConAgenda oAgenda = new ConAgenda(idAgenda);

            SysProfesional oProfesional = new SysProfesional(oAgenda.IdProfesional);


            dtGrilla = construirTurnos(idAgenda);
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.DataBind();
            gvTurnos.Visible = true;
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
            //  int reserva = ag.Reservados;
            int maxSbts = ag.MaximoSobreturnos;
            string hIni = ag.HoraInicio;
            string hFin = ag.HoraFin;
            string hora = hIni;

            //DateTime hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            //DateTime horafin1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hFin);


            //do
            //{
            //    if (!existeHoraEnDataTable(dt, hora))
            //    {
            //        insertarDataRow(dt, fecha, hora, idAgenda);
            //    }
            //    hora = incrementarHora(hora, duracion);
            //    hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            //} while (!(hora1 >= horafin1));

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
            newRow["Estado"] = "Activo";
            newRow["DNI"] = "0";
            newRow["HC"] = "0";
            newRow["Paciente"] = "";
            newRow["TipoTurno"] = "";
            newRow["Asistencia"] = "0";

            ConTurnoBloqueo r = new Select().From(Schemas.ConTurnoBloqueo)
                       .Where(ConTurnoBloqueo.Columns.IdAgenda).IsEqualTo(idAgenda)
                       .And(ConTurnoBloqueo.Columns.FechaTurno).IsEqualTo(ag.Fecha)
                       .And(ConTurnoBloqueo.Columns.HoraTurno).IsEqualTo(hora)
                       .ExecuteSingle<ConTurnoBloqueo>();

            if (r != null)
                newRow["Estado"] = "Bloqueado";
            else
                newRow["Estado"] = "Activo";

            dt.Rows.Add(newRow);

        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
             SysUsuario us = new SysUsuario(Session["idUsuario"]);
             if (!us.IsNew)
             {
                 //int idAgenda = ;
               
                 int i = gvTurnos.SelectedRow.RowIndex;
                if (Request["Tipo"]!=null)
                
                 Response.Redirect("DiagnosticoEdit.aspx?idAgenda="+Convert.ToInt32(Request.QueryString["idAgenda"])+ "&Tipo=Atencion&idTurno="+ Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]),false);
                else

                    Response.Redirect("DiagnosticoEdit.aspx?idAgenda=" + Convert.ToInt32(Request.QueryString["idAgenda"]) + "&idTurno=" + Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]), false);
             }
        }

        private void mostrarTurno(int idTurno)
        {

        //    if (Request["Tipo"] != null)
        //    {                //pnlAtencion.Visible = true;
        //        pnlModulos.Visible = true;
        //    }
        //    else
        //    {                //pnlAtencion.Visible = false;
        //        pnlModulos.Visible = false;
        //    }


            pnlHola.Visible = false;
            pnlDiagnostico.Visible = true;
            ConTurno t = new ConTurno(idTurno);
            lblPaciente.Text = t.SysPaciente.NumeroDocumento.ToString()+ " " + t.SysPaciente.Apellido + " " + t.SysPaciente.Nombre;
            lblFechaNacimiento.Text ="Fecha de Nacimiento: " + t.SysPaciente.FechaNacimiento.ToShortDateString();                

            DateDifference oEdad = new DateDifference(t.SysPaciente.FechaNacimiento, t.Fecha);
            if (oEdad.Years > 0)
                lblFechaNacimiento.Text += " - Edad: " + oEdad.Years.ToString() + " años";
            else
            {
                if (oEdad.Months > 0)
                    lblFechaNacimiento.Text += " - Edad: " + oEdad.Months.ToString() + " meses";
                else
                    if (oEdad.Days > 0)
                        lblFechaNacimiento.Text += " - Edad: " + oEdad.Days.ToString() + " días";
            }
            lblIdTurno.Text = idTurno.ToString();

            gvHistorial.DataSource = SPs.ConGetTurnosPacientes(t.Fecha.ToString("yyyyMMdd"), t.SysPaciente.IdPaciente, 1).GetDataSet();
            gvHistorial.DataBind();

            MostrarConsulta(idTurno);
        }

        private void MostrarConsulta(int idTurno)
        {
            ConTurno t = new ConTurno(int.Parse(lblIdTurno.Text));
            ConConsultum oConsulta = new SubSonic.Select()
              .From(Schemas.ConConsultum)
                        .Where(ConConsultum.Columns.IdTurno).IsEqualTo(idTurno)
                          .ExecuteSingle<ConConsultum>();

               //.ExecuteAsCollection<ConConsultum>();
            if (oConsulta != null)
            {
                lblIdConsulta.Text = oConsulta.IdConsulta.ToString();
                txtInformeConsulta.Text = oConsulta.InformeConsulta;

                ConConsultaDiagnosticoCollection tempDiagSec = new ConConsultaDiagnosticoCollection();
                foreach (ConConsultaDiagnostico oDiagnostico in oConsulta.ConConsultaDiagnosticoRecords)
                {
                    if (oDiagnostico.Principal.GetValueOrDefault(false))
                    {
                        DiagnosticoPrincipal1.setDiagnosticoPrincipal(oDiagnostico.CODCIE10.GetValueOrDefault(0));
                        ddlPrimerConsulta.SelectedValue = oDiagnostico.PrimerConsulta.ToString();
                    }
                    else
                    {
                        tempDiagSec.Add(oDiagnostico);
                    }
                }
                DiagnosticoSecundario1.setDiagnosticos(tempDiagSec);
           
             //   pnlInterConsulta.Enabled = true;
                
            }

            else
            {
                lblIdConsulta.Text = "0";
              //  DiagnosticoPrincipal1.Controls.Clear();
                ddlPrimerConsulta.SelectedValue = "-1";
           
               // pnlInterConsulta.Enabled = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                GuardarDiagnosticos();
                if (Request["Tipo"] != null)
                    Response.Redirect("DiagnosticoEdit.aspx?idAgenda=" + idAgenda + "&Tipo=Atencion", false);
                else
                    Response.Redirect("DiagnosticoEdit.aspx?idAgenda=" + idAgenda, false);
            }
        }

        private void GuardarDiagnosticos()
        {
            ConTurno t= new ConTurno(int.Parse(lblIdTurno.Text));                   
            ConConsultum   oConsulta = new ConConsultum( int.Parse(lblIdConsulta.Text));            
                           

            oConsulta.Fecha =t.Fecha;
            oConsulta.Hora = t.Hora;
            oConsulta.IdTurno = int.Parse(lblIdTurno.Text);
            oConsulta.IdPaciente= t.IdPaciente;

              
            oConsulta.IdProfesional =t.ConAgenda.IdProfesional;
            oConsulta.IdEspecialidad =t.ConAgenda.IdEspecialidad;
            oConsulta.IdTipoPrestacion =t.ConAgenda.IdTipoPrestacion;

            oConsulta.MotivoConsulta ="";
            oConsulta.InformeConsulta = txtInformeConsulta.Text;
    
            // Buscamos el usuario.
            SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
            // Guardamos las cositas que faltaban.
            oConsulta.IdUsuarioRegistro = oUsuario.IdUsuario;
            oConsulta.IdEfector = oUsuario.IdEfector;

            SysPaciente oPaciente = new SysPaciente(t.IdPaciente);
            if (oPaciente != null)            oConsulta.IdObraSocial = oPaciente.IdObraSocial;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                    {
                        try
                        {
                            oConsulta.Save();

                            BorrarDiagnosticos(oConsulta);

                            ConConsultaDiagnostico oDiagnostico = new ConConsultaDiagnostico();
                            oDiagnostico.IdConsulta = oConsulta.IdConsulta;
                            oDiagnostico.IdEfector = oConsulta.IdEfector.Value;
                            oDiagnostico.CODCIE10 = DiagnosticoPrincipal1.getDiagnostico();
                            oDiagnostico.Principal = true;
                            oDiagnostico.PrimerConsulta =int.Parse( ddlPrimerConsulta.SelectedValue);

                            oDiagnostico.Save();
                            //oConsulta.ConConsultaDiagnosticoRecords.SaveAll();
                            //oConsulta.ConConsultaMedicamentoRecords.SaveAll();


                            string[] oDiagnosticos = DiagnosticoSecundario1.getDiagnosticos().Split(',');
                            foreach (string sDiagnosticoSecundario in oDiagnosticos)
                            {
                                if (sDiagnosticoSecundario.Length > 0)
                                {
                                    int idDiagnostico;
                                    if (Int32.TryParse(sDiagnosticoSecundario, out idDiagnostico))
                                    {
                                        ConConsultaDiagnostico oDiagnosticoSecundario = new ConConsultaDiagnostico();
                                        oDiagnosticoSecundario.IdConsulta = oConsulta.IdConsulta;
                                        oDiagnosticoSecundario.Principal = false;
                                        oDiagnosticoSecundario.CODCIE10 = idDiagnostico;
                                        oDiagnosticoSecundario.IdEfector = oConsulta.IdEfector.Value;
                                        oDiagnosticoSecundario.Save();
                                    }
                                    //else
                                    //{

                                    //    oResultado.Estado = MessageStatus.error;
                                    //    oResultado.mensaje.Add("Unos de los codigo de diagnostico secundario no se reconoce.");
                                    //}
                                }
                            }

                            ts.Complete();
                           // Master.Message("La consulta se guardo con exito.", MessageStatus.ok);
                        }
                        catch (Exception ex)
                        {
                            ts.Dispose();
                            List<string> m = new List<string>();
                            while (ex != null)
                            {
                                m.Add(ex.Message);
                                ex = ex.InnerException;
                            }
                         //   Master.Message(MessageStatus.error, "Error al guardar", m);
                        }
                    }
                }
            
          
        }

        private void BorrarDiagnosticos(ConConsultum oConsulta)
        {
            Query i = new Query(Schemas.ConConsultaDiagnostico);
            i.QueryType = QueryType.Delete;
            i.WHERE(ConConsultaDiagnostico.Columns.IdConsulta, oConsulta.IdConsulta);
            i.Execute(); 
        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                                
                ImageButton cmdSelTurno = (ImageButton)e.Row.FindControl("cmdSelTurno");
                Image imgTurno = (Image)e.Row.FindControl("imgTurno");
                Image imgConsulta = (Image)e.Row.FindControl("imgConsulta");         
                string Estado = dtGrilla.Rows[e.Row.RowIndex]["Estado"].ToString();
                string Consulta = dtGrilla.Rows[e.Row.RowIndex]["Consulta"].ToString();
                string Asistencia = dtGrilla.Rows[e.Row.RowIndex]["Asistencia"].ToString();                
                
                switch (Consulta)
                {
                    case "Si":
                        {
                            for (int i = 0; i < gvTurnos.Columns.Count; i++)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Gainsboro;                               
                            }                                                            
                        } break;
                    case "No":
                        {
                            for (int i = 0; i < gvTurnos.Columns.Count; i++)
                            {
                                e.Row.Cells[i].BackColor = System.Drawing.Color.White;
                            }
                        } break;
                        }


                switch (Estado)
                {
                    case "Activo":
                        {
                            string tipoTurno = dtGrilla.Rows[e.Row.RowIndex]["TipoTurno"].ToString();
                            switch (tipoTurno)
                            {
                                case "":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnoactivo.png";
                                    imgTurno.ToolTip = "Turno activo";
                                    break;
                                case "Turno":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/check_verde16.png";
                                    imgTurno.ToolTip = "Turno del día";
                                    break;
                                case "Programado":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta1.png";
                                    imgTurno.ToolTip = "Turno Anticipado";
                                    break;
                                case "SobreTurno":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta.png";
                                    imgTurno.ToolTip = "Sobre Turno";
                                    break;
                            }
                        } break;
                    case "Bloqueado":
                        {
                            imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnobloqueado.png";
                            imgTurno.ToolTip = "Turno bloqueado";
                        } break;
                }

                if (Asistencia=="0")
                    cmdSelTurno.Visible = false;
            }
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            if (Request["Tipo"] != null)
                Response.Redirect( "../Consultorio/AtencionConsultorio/AgendaList.aspx",false);
            else                
            Response.Redirect("../Consultorio/Agenda/AgendaList.aspx", false);
        }

        protected void cvDiagnostico_ServerValidate(object source, ServerValidateEventArgs args)
        {////verificar que DiagnosticoPrincipal1.getDiagnostico()<>"-1"
            if (DiagnosticoPrincipal1.getDiagnostico()==-1)
            args.IsValid = false;
            else
                args.IsValid = true;
            return;

        }
    }
}
