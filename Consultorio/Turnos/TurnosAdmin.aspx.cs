using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using DalSic;
using Salud.Security.SSO;
using SubSonic;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace Consultorio.Turnos
{

    public partial class TurnosAdmin : System.Web.UI.Page
    {
        private DataTable dtGrilla
        {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        public CrystalReportSource oCr = new CrystalReportSource();


        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarCombos();
                if (Request.QueryString["idAgenda"] != string.Empty)
                {
                    int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                    if (idAgenda > 0)
                    {
                        leerAgenda(idAgenda);
                        Buscar();
                    }
                }

                if (Request["idAgenda"] == null)
                    Buscar();
            }
        }

        private void leerAgenda(int idAgenda)
        {
            actualizarTurnos(idAgenda);
        }

        private void llenarCombos()
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            if (efector.IdTipoEfector <= 2) //Centro de salud
            {
                ListItem ItemSeleccion = new ListItem();
                ItemSeleccion.Value = "148";
                ItemSeleccion.Text = "Centro de salud";
                ddlServicio.Items.Add(ItemSeleccion);
                pnlServicio.Visible = false;
            }
            else
            {
                ///Carolina: Modifico para que se muestren los servicios del efector   
                ddlServicio.DataSource = SPs.SysGetServicioByEfector(SSOHelper.CurrentIdentity.IdEfector).GetDataSet();
                ddlServicio.DataTextField = SysServicio.Columns.Nombre;
                ddlServicio.DataValueField = SysServicio.Columns.IdServicio;
                ddlServicio.DataBind();
                ddlServicio.Items.Insert(0, new ListItem("Todos", "0"));
                pnlServicio.Visible = true;
            }

            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, -1).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Todas--");

            ConConsultorioTipoCollection ct = new SubSonic.Select()
                .From(Schemas.ConConsultorioTipo)
                .Where(ConConsultorioTipo.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
                .OrderAsc(ConConsultorioTipo.Columns.Nombre)
                .ExecuteAsCollection<ConConsultorioTipoCollection>();
            ddlTipoConsultorio.DataSource = ct;
            ddlTipoConsultorio.DataValueField = ConConsultorioTipo.Columns.IdTipoConsultorio;
            ddlTipoConsultorio.DataTextField = ConConsultorioTipo.Columns.Nombre;
            ddlTipoConsultorio.DataBind();
            ddlTipoConsultorio.Items.Insert(0, new ListItem("--Todos--", "0"));



            ///Carolina: Modifico para que se muestren los profesiones del efector                        
            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();
            ddlProfesional.Items.Insert(0, "--Todos--");
            ///

            ddlMotivoDeBloqueo.DataSource = SPs.ConMotivoDeBloqueo().GetReader();
            ddlMotivoDeBloqueo.DataTextField = "descripcion";
            ddlMotivoDeBloqueo.DataValueField = "idMotivoBloqueo";
            ddlMotivoDeBloqueo.DataBind();
            //ddlMotivoDeBloqueo.Items.Insert(0, "--Todos--");
            ddlMotivoDeBloqueo.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            txtDesde.Text = DateTime.Now.ToString().Substring(0, 10);
            txtHasta.Text = DateTime.Now.ToString().Substring(0, 10);
        }

        protected void btnBuscarTurno_Click(object sender, EventArgs e)
        {

        }

        private void buscarComprobante(int idTurno)
        {
            dtGrilla = new Select("idTurno, idTurnoEstado, Fecha, Hora, numeroDocumento as DNI, historiaClinica as HC, (Apellido + ', ' + Nombre) as Paciente")
                .From(Schemas.ConTurno)
                .InnerJoin(Schemas.SysPaciente)
                .Where(ConTurno.Columns.IdTurno).IsEqualTo(idTurno)
                .ExecuteDataSet().Tables[0];
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.EmptyDataText = "No se encontró el n° de comprobante especificado";
            gvTurnos.DataBind();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            string st = formatoValido();
            string estilo = string.Empty;

            if (st == string.Empty)
            {
                estilo = "background-color:#F1E2BB;background-image: url('../../App_Themes/consultorio/Agenda/check_verde.png');background-repeat:no-repeat;";
                lblMsg.Text = "";
                actualizarAgendas();
            }
            else
            {
                estilo = "background-color:#F1E2BB;background-image: url('../../App_Themes/consultorio/Agenda/check_rojopng.png');background-repeat:no-repeat;";
                lblMsg.Text = st;
            }
            divMsg.Style.Value = estilo;
        }

        private void actualizarAgendas()
        {
            limpiarGrillaTurnos();
            limpiarInfoTurno();
            buscarAgendas();
        }

        private void limpiarInfoTurno()
        {
            lblInfoPaciente.Text = "";
            lblInfoDni.Text = "";
            lblInfoOS.Text = "";
            pnlInfo.Visible = false;
            pnlResultados.Update();
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

        private void buscarAgendas(int idAgenda)
        {
            gvAgendas.DataSource = SPs.ConGetAgendasById(idAgenda).GetDataSet().Tables[0];
            gvAgendas.DataBind();
        }

        private void buscarAgendas()
        {
            int idZona = 0;
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            int idTipoConsultorio = 0;
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;

            if (ddlTipoTurno.SelectedValue == "Prestaciones") tipoAgenda = 0;

            if (ddlTipoTurno.SelectedValue == "Especialidad") tipoAgenda = 1;


            if (ddlServicio.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicio.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (ddlTipoConsultorio.SelectedIndex > 0) { idTipoConsultorio = Convert.ToInt32(ddlTipoConsultorio.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }

            ///solo muestra las agendas activas            

            gvAgendas.DataSource = SPs.ConGetAgendas(idZona, SSOHelper.CurrentIdentity.IdEfector, idServicio, idEspecialidad, idProfesional, idTipoConsultorio,
                                   fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), tipoAgenda, 1).GetDataSet().Tables[0];
            gvAgendas.DataBind();

            lblTituloAgenda.Text = "Seleccione la agenda para la cual desea administrar turnos";
            lblFechaAgenda.Text = "";
            lblHoraAgenda.Text = "";
        }

        protected void ddlTipoTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i_tipo = -1;

            if (ddlTipoTurno.SelectedValue == "Prestaciones") //tipo de prestacion
            {
                i_tipo = 0;

            }
            if (ddlTipoTurno.SelectedValue == "Especialidad") //tipo de prestacion
            {
                i_tipo = 1;
            }

            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, i_tipo).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Todas--");

            updfiltro.Update();
        }

        private DataTable getTurnos(SysPaciente paciente)
        {
            return new Select("idTurno, idTurnoEstado, Fecha, Hora, numeroDocumento as DNI, historiaClinica as HC, (apellido + ' ' + nombre) as Paciente, 'Activo' as Estado, case idTipoTurno when 0 then 'Turno' when 1 then 'Programado' when 2 then 'Interconsulta' end as TipoTurno  ")
                            .From(Schemas.ConTurno).InnerJoin(Schemas.SysPaciente)
                            .Where(ConTurno.Columns.IdPaciente).IsEqualTo(paciente.IdPaciente)
                            .And(ConTurno.Columns.IdTurnoEstado).IsNotEqualTo(4)
                            .ExecuteDataSet().Tables[0];
        }

        protected void gvAgendas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAgendas.SelectedIndex = -1;
            actualizarAgendas();
            gvAgendas.PageIndex = e.NewPageIndex;
            gvAgendas.DataBind();
            pnlResultados.Update();
        }

        protected void gvAgendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ConAgenda agenda = new ConAgenda(int.Parse(gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString()));

                ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                    .From(Schemas.ConAgendaProfesional).Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(agenda.IdAgenda)
                    .ExecuteAsCollection<ConAgendaProfesionalCollection>();

                ListView lblProfesional = (ListView)e.Row.FindControl("lsvProfesional");

                List<string> lista = new List<string>();

               // if (agenda.Multiprofesional == true)
                //{
                    for (int x = 0; x < listaAgendaProfesional.Count; x++)
                    {
                        lista.Add(listaAgendaProfesional.ElementAt(x).SysProfesional.NombreCompleto);
                    }

                    lblProfesional.DataSource = lista;
                    lblProfesional.DataBind();
               // }
                //else
                //{
                //    lista.Add(agenda.SysProfesional.NombreCompleto);

                //    lblProfesional.DataSource = lista;
                //    lblProfesional.DataBind();
                //}

                e.Row.Cells[2].Text = Rutinas.Capitalizar(e.Row.Cells[2].Text);

                //ImageButton cmdSel = (ImageButton)e.Row.Cells[0].FindControl("cmdSel");
                LinkButton cmdSel = (LinkButton)e.Row.FindControl("cmdSel");
                cmdSel.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdSel.CommandName = "Select";
                cmdSel.ToolTip = "Mostrar turnos de Agenda n°" + cmdSel.CommandArgument;
            }
        }

        protected void gvAgendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;

            int idAgenda = Convert.ToInt32(gvAgendas.DataKeys[gvAgendas.SelectedIndex].Value);

            actualizarTurnos(idAgenda);
            pnlResultados.Update();
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
                    insertarDataRow(dt, fecha, hora, idAgenda);
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

            string estadoTurno = "Activo";
            string motivoB = "";
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
                {
                    ConMotivosDeBloqueo motivito = new ConMotivosDeBloqueo(oBloqueo.IdMotivoBloqueo);
                    if (motivito != null) motivoB = motivito.Descripcion.ToUpper();
                    estadoTurno = "Bloqueado";
                }
                else
                    estadoTurno = "Activo";
                break;

            }

            if (estadoTurno == "Bloqueado")
                newRow["Paciente"] = motivoB;
            else
                newRow["Paciente"] = "";

            newRow["TipoTurno"] = "";
            newRow["Asistencia"] = "0";

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
            lblTituloAgenda.Text = "";
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



            ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                  .From(Schemas.ConAgendaProfesional).Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                  .ExecuteAsCollection<ConAgendaProfesionalCollection>();      

            List<string> lista = new List<string>();

            if (ag.Multiprofesional == true)
            {
                lblTituloAgenda.Text = "";
                for (int x = 0; x < listaAgendaProfesional.Count; x++)
                {
                    lblTituloAgenda.Text += listaAgendaProfesional.ElementAt(x).SysProfesional.NombreCompleto +" - ";
                    lista.Add(listaAgendaProfesional.ElementAt(x).SysProfesional.NombreCompleto);
                }

            }
            else
            {
                lblTituloAgenda.Text = p.Apellido + " " + (p.Nombre != "" ? p.Nombre.Substring(0, 1) : "") + " - " + especialidad;
            }


            
            lblDiaAgenda.Text = Rutinas.getNombreDia(ag.Fecha);
            lblFechaAgenda.Text = ag.Fecha.ToShortDateString();
            lblHoraAgenda.Text = " (" + ag.HoraInicio + " - " + ag.HoraFin + ")";

            dtGrilla = construirTurnos(idAgenda);
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.DataBind();
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
                //ImageButton cmdSelTurno = (ImageButton)e.Row.FindControl("cmdSelTurno");
                LinkButton cmdSelTurno = (LinkButton)e.Row.FindControl("cmdSelTurno");
                cmdSelTurno.CommandArgument = gvTurnos.DataKeys[0].Value.ToString();
                cmdSelTurno.CommandName = "Select";
                cmdSelTurno.ToolTip = "Seleccionar turno";
                cmdSelTurno.CommandArgument = dtGrilla.Rows[e.Row.RowIndex]["Hora"].ToString();
                int dni = Convert.ToInt32(dtGrilla.Rows[e.Row.RowIndex]["DNI"]);


                string Asistencia = dtGrilla.Rows[e.Row.RowIndex]["Asistencia"].ToString();

                if (Asistencia == "1")
                {
                    for (int i = 1; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.LightYellow;
                    }
                }

                string Estado = dtGrilla.Rows[e.Row.RowIndex]["Estado"].ToString();

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
                                    imgTurno.ToolTip = "SobreTurno";
                                    break;
                            }

                        } break;
                    case "Bloqueado":
                        {
                            imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnobloqueado.png";
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

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(gvTurnos.DataKeys[gvTurnos.SelectedIndex].Value);

            if (idTurno != 0) ///Si es un turno muestra datos del mismo
            {
                ConTurno turno = new ConTurno(idTurno);

                llenarInfoTurno(turno);
                leerAsistencia();
                Calendario.DataBind();
                pnlResultados.Update();

                divInfoPaciente.Visible = true;
                motivoDeBloqueo.Visible = false;

                if (DateTime.Parse(lblFechaAgenda.Text) > DateTime.Now)
                    lnkAsistenciaNo.Visible = false;
                else
                    lnkAsistenciaNo.Visible = true;


                /// solo es es salud mental
                if ((turno.ConAgenda.IdEspecialidad == 50) || (turno.ConAgenda.IdEspecialidad == 52) || (turno.ConAgenda.IdEspecialidad == 25))
                {   /////control de codigo para mostrar o no los acompañantes terapeuticos
                    cmdNuevoAcompanianteTerapeutico.Visible = true;
                    int i = getCantidadAcompaniantes(idTurno);
                    if (i > 0)
                    {
                        lblCantidadAcompaniantes.Visible = true;
                        lblCantidadAcompaniantes.Text = "Tiene " + i.ToString() + " A.T (para ver clic aqui)";
                        /// agrego atributo para abrir en popup los acompaniantes registrados
                        lblCantidadAcompaniantes.Attributes.Add("onClick", "javascript: PacienteCompania (" + idTurno.ToString() + "); return false");
                    }
                    else
                        lblCantidadAcompaniantes.Visible = false;
                }
                else
                {
                    cmdNuevoAcompanianteTerapeutico.Visible = false;
                    lblCantidadAcompaniantes.Visible = false;
                }
                //////////////fin de control
            }
            else //No es un turno: se puede bloquear.
            {
                MostrarTurnoDisponible(dtGrilla.Rows[gvTurnos.SelectedIndex]["Fecha"].ToString(), dtGrilla.Rows[gvTurnos.SelectedIndex]["Hora"].ToString());
                Calendario.DataBind();

                divAsistenciaEdit.Visible = false;
                divAsistenciaNo.Visible = false;
                divAsistenciaSi.Visible = false;

                pnlResultados.Update();
                divInfoPaciente.Visible = false;
                cmdNuevoAcompanianteTerapeutico.Visible = false;
                lblCantidadAcompaniantes.Visible = false;
            }
        }

        private int getCantidadAcompaniantes(int idTurno)
        {
            DataTable p = new Select().From(Schemas.ConTurno)
                            .Where(ConTurno.Columns.IdTurnoAcompaniante).IsEqualTo(idTurno)
                            .And(ConTurno.Columns.IdTurnoEstado).IsNotEqualTo(4)
                            .ExecuteDataSet().Tables[0];
            return p.Rows.Count; //> 0) ? Convert.ToInt32(p.Rows[0]["idPaciente"]) : 0;
        }

        private void MostrarTurnoDisponible(string fecha, string hora)
        {
            imgInfoPaciente.Visible = false;

            lblInfoPaciente.Text = "TURNO " + hora;

            divConfirma.Visible = false;
            divError.Visible = false;
            pnlInfo.Visible = true;

            lblNoAsistencia.Visible = false;
            cmdRecitar.Visible = false;
            cmdNuevoTurno.Visible = false;
            cmdLiberar.Visible = false;
            cmdSuspender.Visible = false;
            lnkAsistenciaNo.Visible = false;

            int idAgenda = 0;

            idAgenda = Convert.ToInt32(gvAgendas.DataKeys[gvAgendas.SelectedIndex].Value);

            cmdBloquear.Visible = true;

            if (dtGrilla.Rows[gvTurnos.SelectedIndex]["Estado"].ToString() == "Activo")
            {
                lblMotivoBloqueo.Visible = false;
                cmdBloquear.Text = "Bloquear";
                motivoDeBloqueo.Visible = true;
            }
            else
            {
                lblMotivoBloqueo.Visible = true;
                cmdBloquear.Text = "DesBloquear";
                motivoDeBloqueo.Visible = false;
                lblMotivoBloqueo.Text = verMotivoDeBloqueo();
            }
        }

        public string verMotivoDeBloqueo()
        {

            int idAgenda = Convert.ToInt32(gvAgendas.DataKeys[gvAgendas.SelectedIndex].Value);

            ConTurnoBloqueo turnoBloqueo = new Select().From(Schemas.ConTurnoBloqueo).Where(ConTurnoBloqueo.IdAgendaColumn).IsEqualTo(idAgenda)
                .ExecuteSingle<ConTurnoBloqueo>();

            string query = " Select descripcion from Con_MotivosDeBloqueo MB Inner Join Con_TurnoBloqueo CB On (CB.IdMotivoBloqueo = MB.IdMotivoBloqueo) "
                            + " Inner Join Con_Agenda A On (a.IdAgenda = CB.IdAgenda) Where A.idAgenda = " + idAgenda
                            + " And CB.HoraTurno = '" + turnoBloqueo.HoraTurno
                            + "' Order bY CB.IdTurnoBloqueo Desc";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SicConnectionString"].ToString());
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            string descripcion = (string)comm.ExecuteScalar();

            conn.Close();

            string bloqueo = "Motivo: " + descripcion;

            return bloqueo;
        }

        private void llenarInfoTurno(ConTurno turno)
        {
            imgInfoPaciente.ImageUrl = getImageUrl(turno.SysPaciente.IdSexo);
            lnkPaciente.NavigateUrl = "~/Paciente/PacienteView.aspx?id=" + turno.IdPaciente.ToString();
            lnkPaciente.ToolTip = "click para ver datos del paciente";
            lblInfoDni.Text = " Dni " + turno.SysPaciente.NumeroDocumento.ToString();

            if (turno.IdObraSocial > -1)
            {
                SysObraSocial unaObraSocial = new SysObraSocial(turno.IdObraSocial);
                lblInfoOS.Text = " Obra Social: " + unaObraSocial.Nombre;
            }
            else
                lblInfoOS.Text = "";


            lblInfoPaciente.Text = Rutinas.Capitalizar(turno.SysPaciente.Apellido) + ", "
                             + Rutinas.Capitalizar(turno.SysPaciente.Nombre);

            divConfirma.Visible = false;
            divError.Visible = false;
            pnlInfo.Visible = true;

            lblNoAsistencia.Visible = true;
            cmdRecitar.Visible = true;
            cmdNuevoTurno.Visible = true;
            cmdLiberar.Visible = true;
            cmdSuspender.Visible = true;
            lnkAsistenciaNo.Visible = true;
            cmdBloquear.Visible = false;
            lblMotivoBloqueo.Visible = false;
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

        protected void lnkAsistenciaNo_Click(object sender, EventArgs e)
        {
            divAsistenciaNo.Visible = true;
            divAsistenciaSi.Visible = false;
            divAsistenciaEdit.Visible = false;
            divConfirma.Visible = false;
            divError.Visible = false;

            grabarAsistencia();
            leerAsistencia();

        }

        protected void cmdBorrarAsistencia_Click(object sender, EventArgs e)
        {
            borrarAsistencia();
            divAsistenciaNo.Visible = true;
            divAsistenciaSi.Visible = false;
            divAsistenciaEdit.Visible = false;
            divConfirma.Visible = false;
            divError.Visible = false;
        }

        protected void cmdEditarAsistencia_Click(object sender, EventArgs e)
        {
            divAsistenciaNo.Visible = false;
            divAsistenciaSi.Visible = false;
            divAsistenciaEdit.Visible = true;
            divConfirma.Visible = false;
            divError.Visible = false;
        }

        protected void cmdCancelarAsistencia_Click(object sender, EventArgs e)
        {
            leerAsistencia();
        }

        protected bool validarFecha()
        {
            bool valido = true;
            try
            {
                DateTime f = Convert.ToDateTime(txtFechaAsistencia.Text + " " + txtHoraAsistencia.Value + ":00");
                DateTime fechaTurno = Convert.ToDateTime(gvTurnos.SelectedRow.Cells[1].Text + " " + gvTurnos.SelectedRow.Cells[2].Text + ":00");
                valido = (fechaTurno > f) ? false : true;
            }
            catch { valido = false; }
            return valido;
        }

        protected void cmdGrabarAsistencia_Click(object sender, EventArgs e)
        {
            if (rqfvHoraAsistencia.IsValid)
            {
                DateTime fechaNueva = Convert.ToDateTime(txtFechaAsistencia.Text + " " + txtHoraAsistencia.Value + ":00");
                grabarAsistencia(fechaNueva);
                leerAsistencia();
                divAsistenciaNo.Visible = false;
                divAsistenciaSi.Visible = true;
                divAsistenciaEdit.Visible = false;
            }
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

        private void leerAsistencia()
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);

            try
            {
                divAsistenciaNo.Visible = true;
                divAsistenciaSi.Visible = false;
                divAsistenciaEdit.Visible = false;

                ConTurnoAsistencium asist = new Select()
                                            .From(Schemas.ConTurnoAsistencium)
                                            .Where(ConTurnoAsistencium.Columns.IdTurno)
                                            .IsEqualTo(idTurno)
                                            .ExecuteSingle<ConTurnoAsistencium>();

                if (asist != null)
                {
                    lblAsistencia.Text = asist.FechaAsistencia.ToString().Substring(0, 16);
                    txtFechaAsistencia.Text = asist.FechaAsistencia.ToString().Substring(0, 10);
                    txtHoraAsistencia.Value = asist.FechaAsistencia.Hour.ToString() + ":" + asist.FechaAsistencia.Minute.ToString(); // Substring(11, 5);

                    /// si tiene una consulta asociada no puede revertir la asistencia
                    ConConsultum ocon = new Select()
                                           .From(Schemas.ConConsultum)
                                           .Where(ConConsultum.Columns.IdTurno)
                                           .IsEqualTo(idTurno)
                                           .ExecuteSingle<ConConsultum>();
                    if (ocon != null)
                    {
                        divAsistenciaNo.Visible = false;
                        divAsistenciaSi.Visible = false;
                        divAsistenciaEdit.Visible = false;
                    }
                    else
                    {

                        divAsistenciaNo.Visible = false;
                        divAsistenciaSi.Visible = true;
                        divAsistenciaEdit.Visible = false;
                    }
                    CalendarExtender3.SelectedDate = Convert.ToDateTime(txtFechaAsistencia.Text);
                }
            }
            catch { }
        }

        private void borrarAsistencia()
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);

            Query asist = new Query(Schemas.ConTurnoAsistencium);
            asist.QueryType = QueryType.Delete;
            asist.WHERE(ConTurnoAsistencium.Columns.IdTurno, idTurno);
            asist.Execute();
        }

        protected void cmdRecitar_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            if (!tieneAsistencia(t))
            {
                Response.Redirect("TurnoNuevo.aspx?accion=1&idTurno=" + idTurno.ToString() + "&idPaciente=" + t.IdPaciente.ToString());
            }
            else
            {
                divError.Visible = true;
                divConfirma.Visible = false;
            }
        }

        protected void cmdNuevoTurno_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            Response.Redirect("TurnoNuevo.aspx?accion=2&idPaciente=" + t.IdPaciente.ToString() + "&idTurno=" + idTurno);

        }

        protected void cmdLiberar_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            if (!tieneAsistencia(t))
            {
                inpConfirma.Value = "4";
                divError.Visible = false;
                divConfirma.Visible = true;
                lblConfirma.Text = "No podrá revertir esta acción ¿Confirma liberar el turno?";
            }
            else
            {
                divError.Visible = true;
                divConfirma.Visible = false;
            }
        }

        protected void cmdSuspender_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            if (!tieneAsistencia(t))
            {
                inpConfirma.Value = "5";
                divError.Visible = false;
                divConfirma.Visible = true;
                lblConfirma.Text = "No podrá revertir esta acción ¿Confirma eliminar el turno?";
            }
            else
            {
                divError.Visible = true;
                divConfirma.Visible = false;
            }
        }

        public void RegisterDOMReadyScript(string key, string script)
        {
            string enclosed = EncloseOnDOMReadyEvent(script);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, enclosed, true);
        }

        private string EncloseOnDOMReadyEvent(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("function r(f){/in/.test(document.readyState)?setTimeout('r('+f+')',9):f()} r(function(){")
                .Append(str)
                .Append("});");
            return sb.ToString();
        }

        protected void cmdBloquear_Click(object sender, EventArgs e)
        {
            if (ddlMotivoDeBloqueo.SelectedValue == "0" && cmdBloquear.Text == "Bloquear")
            {
                RegisterDOMReadyScript("Alerta!!!", "alert('Debe seleccionar un Motivo de Bloqueo');");
            }
            else
            {
                int idAgenda = 0;
                idAgenda = Convert.ToInt32(gvAgendas.DataKeys[gvAgendas.SelectedIndex].Value);

                if (cmdBloquear.Text == "Bloquear")
                {
                    ConTurnoBloqueo bloq = new ConTurnoBloqueo();
                    bloq.IdAgenda = idAgenda;
                    bloq.FechaTurno = DateTime.Parse(dtGrilla.Rows[gvTurnos.SelectedIndex]["Fecha"].ToString());
                    bloq.HoraTurno = dtGrilla.Rows[gvTurnos.SelectedIndex]["Hora"].ToString();
                    bloq.IdUsuarioBloqueo = SSOHelper.CurrentIdentity.Id;
                    bloq.FechaBloqueo = DateTime.Now;
                    bloq.IdMotivoBloqueo = int.Parse(ddlMotivoDeBloqueo.SelectedValue);
                    bloq.Save();
                }
                else
                {
                    ConTurnoBloqueo r = new Select().From(Schemas.ConTurnoBloqueo)
                        .Where(ConTurnoBloqueo.Columns.IdAgenda).IsEqualTo(idAgenda)
                        .And(ConTurnoBloqueo.Columns.FechaTurno).IsEqualTo(DateTime.Parse(dtGrilla.Rows[gvTurnos.SelectedIndex]["Fecha"].ToString()))
                        .And(ConTurnoBloqueo.Columns.HoraTurno).IsEqualTo(dtGrilla.Rows[gvTurnos.SelectedIndex]["Hora"].ToString())
                        .And(ConTurnoBloqueo.Columns.IdUsuarioDesBloqueo).IsEqualTo(0)

                        .ExecuteSingle<ConTurnoBloqueo>();

                    r.IdUsuarioDesBloqueo = SSOHelper.CurrentIdentity.Id;
                    r.FechaDesBloqueo = DateTime.Now;
                    r.Save();

                    cmdBloquear.Visible = true;
                    ddlMotivoDeBloqueo.Visible = true;
                }
                actualizarTurnos(idAgenda);
                MostrarTurnoDisponible(dtGrilla.Rows[gvTurnos.SelectedIndex]["Fecha"].ToString(), dtGrilla.Rows[gvTurnos.SelectedIndex]["Hora"].ToString());
            }
        }

        private bool tieneAsistencia(ConTurno t)
        {
            int r = new Select().From(Schemas.ConTurnoAsistencium)
                                .Where(ConTurnoAsistencium.Columns.IdTurno)
                                .IsEqualTo(t.IdTurno).GetRecordCount();
            return (r > 0) ? true : false;
        }

        protected void cmdNo_Click(object sender, EventArgs e)
        {
            inpConfirma.Value = "";
            divConfirma.Visible = false;
            divError.Visible = false;
        }

        protected void cmdSi_Click(object sender, EventArgs e)
        {
            int idTurnoEstado = Convert.ToInt32(inpConfirma.Value);
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            establecerEstado(t, idTurnoEstado);

            ConAgenda A = new ConAgenda(t.IdAgenda);
            A.TurnosDisponibles = true;
            A.Save();

            divConfirma.Visible = false;
            divError.Visible = false;
            pnlInfo.Visible = false;

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

        private string formatoValido()
        {
            string strsalida = string.Empty;
            string desde = txtDesde.Text;
            string hasta = txtHasta.Text;

            if ((desde.Length > 0) & (desde.Length < 10))
            {
                strsalida = "El valor de fecha de inicio no es una fecha válida ";
            }
            else
            {
                if (desde != string.Empty)
                {
                    try { DateTime f = Convert.ToDateTime(desde); }
                    catch { strsalida = "El valor de fecha de inicio no es una fecha válida "; }
                }
            }
            if ((hasta.Length > 0) & (hasta.Length < 10))
            {
                strsalida = "El valor de fecha de fin no es una fecha válida ";
            }
            else
            {
                if (hasta != string.Empty)
                {
                    try { DateTime f = Convert.ToDateTime(hasta); }
                    catch
                    {
                        if (strsalida != string.Empty) { strsalida += Environment.NewLine; }
                        strsalida += "El valor de fecha de fin no es una fecha válida ";
                    }
                }

                if (strsalida != string.Empty)
                {
                    strsalida += Environment.NewLine;
                    strsalida += "(Formato esperado dd/mm/aaaa)";
                }
            }

            divMsg.Visible = (strsalida != string.Empty);
            return strsalida;
        }

        protected void cmdAuditoria_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            Response.Redirect("TurnosAuditoria.aspx?idTurno=" + idTurno.ToString());
        }

        protected void lnkImprimir_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
        }

        private void ImprimirPlanilla()
        {
            //Aca se deberá consultar los parametros para mostrar una hoja de trabajo u otra
            //this.CrystalReportSource1.Report.FileName = "HTrabajo2.rpt";
            string informe = "../Informes/Planilla.rpt";

            if (gvAgendas.Rows.Count > 0 && gvAgendas.Visible == true)
            {
                if (gvAgendas.DataKeys[gvAgendas.SelectedIndex].Value.ToString() != "")
                {
                    ConAgenda agenda = new ConAgenda(int.Parse(gvAgendas.DataKeys[gvAgendas.SelectedIndex].Value.ToString()));

                    ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
                    encabezado1.Value = agenda.IdEfector;

                    DataTable dt = getPlanillaTurnos(agenda);

                    oCr.Report.FileName = informe;
                    oCr.ReportDocument.SetDataSource(dt);

                    oCr.DataBind();

                    MemoryStream oStream; // using System.IO
                    oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=PlanillaConsultorio.pdf");

                    Response.BinaryWrite(oStream.ToArray());
                    Response.End();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ImprimirPlanilla();
        }

        protected void cmdNuevoAcompanianteTerapeutico_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);

            Response.Redirect("TurnoNuevoDefault.aspx?Desde=TurnosAdmin.aspx&idTurnoAcompaniante=" + idTurno.ToString(), false);
        }
    }
}
