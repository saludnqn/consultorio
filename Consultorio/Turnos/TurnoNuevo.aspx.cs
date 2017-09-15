using System;
using System.Collections;
using System.Collections.Generic;
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
using Consultorio.Utilidades;
using Salud.Security.SSO;
using System.Text;


namespace Consultorio.Turnos
{
    public partial class TurnoNuevo : System.Web.UI.Page
    {

        private DataTable dtGrilla
        {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }


        private int Inasistencia
        {
            get { return ViewState["Inasistencia"] == null ? 0 : (int)(ViewState["Inasistencia"]); }
            set { ViewState["Inasistencia"] = value; }
        }
        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : (int)(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        private int mostrarDiv
        {
            get { return ViewState["mostrarDiv"] == null ? 0 : (int)(ViewState["mostrarDiv"]); }
            set { ViewState["mostrarDiv"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreventingDoubleSubmit(btnDemandaRechazada);
                PreventingDoubleSubmit(btnGrabar);

                SysEfector oEfectorInterConsulta = new SysEfector(SSOHelper.CurrentIdentity.Id);
                SysEfector oEfectorSuperior = new SysEfector(oEfectorInterConsulta.IdEfectorSuperior);

                if (Request["Interconsulta"] != null)
                {
                    lblTitulo.Text = "ASIGNACION DE TURNOS PARA INTERCONSULTA: " + oEfectorSuperior.Nombre;
                }
                else
                    lblTitulo.Text = "ASIGNACION DE TURNOS: " + oEfectorInterConsulta.Nombre;

                if (Request.QueryString["idPaciente"] == null) Response.Redirect("TurnoNuevoDefault.aspx", false);
                Inasistencia = 0;
                setearVisibilidad(false);
                llenarCombos();

                actualizarVista();
                int accion = 0;
                if (Request.QueryString["accion"] != string.Empty)
                {
                    accion = Convert.ToInt32(Request.QueryString["accion"]);
                    switch (accion)
                    {
                        case 1: setearRecita(); break;
                        case 2: mostrarTurnosPaciente(); break;
                    }
                }
                mostrarTurnosPaciente();
                txtFechaDesde.Text = DateTime.Now.ToString().Substring(0, 10);
            }
        }

        private void PreventingDoubleSubmit(Button button)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("if (typeof(Page_ClientValidate) == ' ') { ");
            sb.Append("var oldPage_IsValid = Page_IsValid; var oldPage_BlockSubmit = Page_BlockSubmit;");
            sb.Append("if (Page_ClientValidate('" + button.ValidationGroup + "') == false) {");
            sb.Append(" Page_IsValid = oldPage_IsValid; Page_BlockSubmit = oldPage_BlockSubmit; return false; }} ");
            sb.Append("this.value = 'Procesando...';");
            sb.Append("this.disabled = true;");
            sb.Append(ClientScript.GetPostBackEventReference(button, null) + ";");
            sb.Append("return true;");

            string submit_Button_onclick_js = sb.ToString();
            button.Attributes.Add("onclick", submit_Button_onclick_js);
        }

        private void setearRecita()
        {
            int idTurno = Convert.ToInt32(Request["idTurno"].ToString());
            ConTurno t = new ConTurno(idTurno);

            idPaciente = t.IdPaciente;
            SysPaciente pac = new SysPaciente(idPaciente);

            //establecerEstado(t);
            //seleccionaPaciente(SSOHelper.CurrentIdentity.Id, idPaciente, idTurno);

            actualizarVista();
        }

        private void establecerEstado(ConTurno t)
        {
            int idAgenda = t.IdAgenda;

            t.IdTurnoEstado = 4;
            t.Save();

            grabarAuditoriaTurno(t);

            actualizarTurnos(idAgenda);
        }

        private void mostrarTurnosPaciente()
        {
            int idPaciente = 0;
            if (Request.QueryString["idPaciente"] == null)
            {
                int idTurno = Convert.ToInt32(Request.QueryString["idTurno"]);
                ConTurno t = new ConTurno(idTurno);
                idPaciente = t.IdPaciente;
            }
            else
                idPaciente = int.Parse(Request.QueryString["idPaciente"]);

            SysRelHistoriaClinicaEfector hc = new Select()
                                    .From(SysRelHistoriaClinicaEfector.Schema)
                                  .Where(SysRelHistoriaClinicaEfector.Columns.IdPaciente).IsEqualTo(idPaciente)
                                  .And(SysRelHistoriaClinicaEfector.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
                                 .ExecuteSingle<SysRelHistoriaClinicaEfector>();

            if (hc != null) txtHistoriaClinica.Text = hc.HistoriaClinica.ToString();
            else txtHistoriaClinica.Text = "";

            SysPaciente paciente = new SysPaciente(idPaciente);
            lblPaciente.Text = paciente.Apellido + " " + paciente.Nombre;

            lblDni.Text = paciente.NumeroDocumento.ToString();
            OSociales.setOS(paciente.IdObraSocial);

            /// Turnos dados en el futuro: hoy en adelante. La funcion es mostrar los turnos que se van dando al paciente en un momento dado.
            gvTurnosPaciente.DataSource = SPs.ConGetTurnosPacientes(DateTime.Now.ToString("yyyyMMdd"), paciente.IdPaciente, 0).GetDataSet();
            gvTurnosPaciente.DataBind();

            ///Turnos dados en el pasado: historial de turnos dados con indicación de asistencia
            gvHistorial.DataSource = SPs.ConGetTurnosPacientes(DateTime.Now.ToString("yyyyMMdd"), paciente.IdPaciente, 1).GetDataSet();
            gvHistorial.DataBind();

            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = DateTime.Now;

            int idEspecialidad = 0;

            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }

            ///Demanda Rechazada: muestra el historial de demanda rechazadas que tuvo el paciente
            gvDemandaRechazada.DataSource = SPs.ConGetDemandaRechazada(SSOHelper.CurrentIdentity.IdEfector, idEspecialidad, fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), paciente.IdPaciente).GetDataSet(); //SPs.ConGetTurnosPacientes(DateTime.Now.ToString("yyyyMMdd"), paciente.IdPaciente, 2).GetDataSet();
            gvDemandaRechazada.DataBind();

            if (Inasistencia > 0)
            {
                imgAsistencia.Visible = true;
                lblInasistencia.Text = "Atención: El paciente tiene " + Inasistencia.ToString() + " inasistencia en los turnos solicitados. Ver el Historial.";
            }
            else
            { imgAsistencia.Visible = false; lblInasistencia.Text = ""; }

            UpdatePanel3.Update();
        }

        private void llenarCombos()
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            ///demanda rechazada
            //divConfirma.Visible = true;
            //divError.Visible = false;
            int efectorTurno = SSOHelper.CurrentIdentity.IdEfector;
            if (Request["Interconsulta"] != null)
                efectorTurno = efector.IdEfectorSuperior;

            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(efectorTurno, -1).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Todas--");


            ///Carolina: Modifico para que se muestren los profesiones del efector                        
            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(efectorTurno, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();
            ddlProfesional.Items.Insert(0, "--Todos--");

            if (efector.IdTipoEfector <= 2) //Centro de salud
            {
                ListItem ItemSeleccion = new ListItem();
                ItemSeleccion.Value = "148";
                ItemSeleccion.Text = "medicina general";
                ddlServicio.Items.Add(ItemSeleccion);
                chkFiltro.Checked = false; //por defecto todas las agendas
                pnlServicio.Visible = false;

            }
            else
            {
                ///Carolina: Modifico para que se muestren los servicios del efector   
                ddlServicio.DataSource = SPs.SysGetServicioByEfector(efectorTurno).GetDataSet();
                ddlServicio.DataTextField = SysServicio.Columns.Nombre;
                ddlServicio.DataValueField = SysServicio.Columns.IdServicio;
                ddlServicio.DataBind();
                ddlServicio.Items.Insert(0, "--Seleccione--");
                pnlServicio.Visible = true;

                chkFiltro.Checked = true;  /// por defecto solo las agendas con turnos libres.
                ///
            }

            ///Carolina: Combospara demanda rechazada  

            ddlEspecialidadDR.DataSource = SPs.SysGetEspecialidadByEfector(efectorTurno, -1).GetDataSet();
            ddlEspecialidadDR.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidadDR.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidadDR.DataBind();
            ddlEspecialidadDR.Items.Insert(0, "--Seleccione--");



            ConMotivosRechazoCollection mrc = new SubSonic.Select()
        .From(Schemas.ConMotivosRechazo)
        .ExecuteAsCollection<ConMotivosRechazoCollection>();
            ddlMotivoRechazo.DataSource = mrc;
            ddlMotivoRechazo.DataValueField = ConMotivosRechazo.Columns.IdMotivoRechazo;
            ddlMotivoRechazo.DataTextField = ConMotivosRechazo.Columns.Nombre;
            ddlMotivoRechazo.DataBind();
            ddlMotivoRechazo.Items.Insert(0, new ListItem("--Seleccione--", "0"));


            //    SysObraSocialCollection osc = new SubSonic.Select()
            //.From(Schemas.SysObraSocial)
            //.ExecuteAsCollection<SysObraSocialCollection>();
            //    ddlObraSocial.DataSource = osc;
            //    ddlObraSocial.DataValueField = SysObraSocial.Columns.IdObraSocial;
            //    ddlObraSocial.DataTextField = SysObraSocial.Columns.Nombre;
            //    ddlObraSocial.DataBind();
            //ddlObraSocial.Items.Insert(0, new ListItem("--Seleccione--", "0"));



        }

        private void setearVisibilidad(bool Visible)
        {
            //  divErr.Visible = Visible;
            //                updpacientes.Visible = Visible;
            //              divpaciente.Visible = Visible;
            divgrilla.Visible = Visible;
            //            divdemandarechazada.Visible = Visible;
            divgrabado.Visible = Visible;
            // divreserva.Visible = Visible;
        }

        protected void ScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            if (e.Exception.Data["ExtraInfo"] != null)
            {
                ToolkitScriptManager1.AsyncPostBackErrorMessage =
                       e.Exception.Message + e.Exception.Data["ExtraInfo"].ToString();
            }
            else
            {
                ToolkitScriptManager1.AsyncPostBackErrorMessage = "An unspecified error occurred.";
            }
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //buscarPaciente();
            //gvPacientes.PageIndex = e.NewPageIndex;
            //gvPacientes.DataBind();
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    ImageButton cmdSel = (ImageButton)e.Row.Cells[0].FindControl("cmdSel");
            //    cmdSel.CommandArgument = this.gvPacientes.DataKeys[e.Row.RowIndex].Value.ToString();
            //    cmdSel.CommandName = "cmdSel";
            //    cmdSel.ToolTip = "Registrar demanda de turno";
            //}
        }


        //private string getImagenPaciente(int idSexo)
        //{
        //    string hombre = "../../App_Themes/consultorio/Agenda/hombre48.png";
        //    string mujer = "../../App_Themes/consultorio/Agenda/mujer48.png";
        //    string indefinido = "../../App_Themes/consultorio/Agenda/ayuda48.png";
        //    return (idSexo == 1) ? indefinido : (idSexo == 2) ? mujer : hombre;
        //}

        protected void dtRechazo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void btnRechazoDemanda_Click(object sender, EventArgs e)
        {
            //divbusquedapacientes.Visible = false;
            //divpaciente.Visible = false;
            //divdemandarechazada.Visible = true;

        }

        protected void btnCancelarRechazo_Click(object sender, EventArgs e)
        {
            //divbusquedapacientes.Visible = false;
            //divpaciente.Visible = true;
            //divdemandarechazada.Visible = false;
        }

        //protected void btnGrabarRechazo_Click(object sender, EventArgs e)
        //{
        //    if (ddlServicio.SelectedIndex != 0)
        //    {
        //        divConfirma.Visible = true;
        //        divError.Visible = false;
        //    }
        //    else
        //    {
        //        divError.Visible = true;
        //        divConfirma.Visible = false;
        //    }
        //    updturnos.Update();
        //}

        //protected void cmdNo_Click(object sender, EventArgs e)
        //{
        //    inpConfirma.Value = "";
        //    divConfirma.Visible = false;
        //    divError.Visible = false;
        //}
        //protected void cmdSi_Click(object sender, EventArgs e)
        //{
        //    SysUsuario us = new SysUsuario(Session["idUsuario"]);

        //    if (!us.IsNew)
        //    {
        //        grabarRechazoDemanda();

        //        Response.Redirect("TurnoNuevoDefault.aspx?idPaciente=" + Request.QueryString["idPaciente"], false);
        //        //divConfirma.Visible = false;
        //        //divError.Visible = false;
        //      //  pnlInfo.Visible = false;
        //    }
        //    else Response.Redirect("~/FinSesion.aspx", false);
        //}


        private void grabarRechazoDemanda()
        {
            //SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            ConDemandaRechazada r = new ConDemandaRechazada();
            r.IdEspecialidad = int.Parse(ddlEspecialidadDR.SelectedValue);


            int efectorTurno = SSOHelper.CurrentIdentity.IdEfector;
            if (Request["Interconsulta"] != null)
                efectorTurno = efector.IdEfectorSuperior;

            r.IdEfector = efectorTurno;
            r.IdPaciente = int.Parse(Request.QueryString["idPaciente"]);
            r.IdMotivoRechazo = int.Parse(ddlMotivoRechazo.SelectedValue);
            r.Observaciones = txtObservacionesDR.Text;

            r.IdUsuario = SSOHelper.CurrentIdentity.Id;
            r.FechaRegistro = DateTime.Now;
            r.Save();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (mascaraCorrecta(txtFechaHasta.Text))
            {
                actualizarVista();
            }
            else
            {
                lblFechasErr.Text = "Formato de fecha distinto al esperado (dd/mm/aaaa)";
                //  divinfoagenda.Visible = false;
                divgrabado.Visible = false;
                //divreserva.Visible = false;
                divcomprobante.Visible = false;
                divfechaserr.Visible = true;
                divinfo.Visible = false;
                divgrilla.Visible = true;
                divfechas.Visible = true;
                divturnoseleccionado.Visible = false;
                btnGrabar.Enabled = false;
                // btnReservar.Enabled = false;
                updturnos.Update();
            }
        }

        private bool mascaraCorrecta(string st)
        {
            bool correcta = true;
            if (st.Length > 0)
            {
                try
                {
                    DateTime fecha = Convert.ToDateTime(st);
                    correcta = true;
                }
                catch { correcta = false; }
            }
            return correcta;
        }

        private void actualizarVista()
        {
            DateTime finicio = DateTime.Now.Date;
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            string disponibles = "1";
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            int idTipoCons = 0;
            int tipoAgenda = 0;

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            if (ddlServicio.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicio.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }

            if (!(txtFechaDesde.Text == string.Empty)) { finicio = Convert.ToDateTime(txtFechaDesde.Text); }
            if (!(txtFechaHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtFechaHasta.Text); }
            if (!chkFiltro.Checked) { disponibles = "0"; }

            int efectorTurno = SSOHelper.CurrentIdentity.IdEfector;
            if (Request["Interconsulta"] != null)
                efectorTurno = efector.IdEfectorSuperior;

            ddlFechas.DataSource = SPs.ConGetAgendasFechas(efectorTurno, idServicio, idEspecialidad, idProfesional, idTipoCons,
                                  finicio.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), disponibles, tipoAgenda).GetDataSet();
            ddlFechas.DataValueField = "Fecha";
            ddlFechas.DataTextField = "DiaFecha";
            ddlFechas.DataTextFormatString = "{0:dd/MM/yyyy}";
            ddlFechas.DataBind();

            divinfo.Visible = false;
            divgrilla.Visible = true;
            divfechas.Visible = true;
            divturnoseleccionado.Visible = false;
            btnGrabar.Enabled = false;

            if (ddlFechas.Items.Count > 0)
            {
                divfechasok.Visible = true;
                divgrillaok.Visible = true;
                divfechaserr.Visible = false;
                divgrillaerr.Visible = false;
                ddlFechas.SelectedIndex = 0;
                gvTurnos.Visible = false;
                gvFechas.Visible = true;
                actualizarAgendas(DateTime.Parse(ddlFechas.SelectedItem.Value));
            }
            else
            {
                lblFechasErr.Text = "No se encontraron agendas según filtro especificado";
                lblGrillaErr.Text = "No se encontraron turnos según filtro especificado";
                divgrabado.Visible = false;
                divcomprobante.Visible = false;
                divfechasok.Visible = false;
                divgrillaok.Visible = false;
                divfechaserr.Visible = true;
                divgrillaerr.Visible = true;
                gvTurnos.Visible = false;
                gvFechas.Visible = false;
            }
        }

        protected void ddlFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(ddlFechas.SelectedItem.Value);
            actualizarAgendas(fecha);
        }

        private void actualizarAgendas(DateTime fecha)
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            string disponibles = "1";
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            int idTipoCons = 0;
            int tipoAgenda = 0;

            if (ddlServicio.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicio.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (!chkFiltro.Checked) { disponibles = "0"; }

            int efectorTurno = SSOHelper.CurrentIdentity.IdEfector;
            if (Request["Interconsulta"] != null)
                efectorTurno = efector.IdEfectorSuperior;

            gvFechas.DataSource = SPs.ConGetAgendasTurnos(efectorTurno, idServicio, idEspecialidad, idProfesional, idTipoCons,
                                                 fecha.ToString("yyyyMMdd"), disponibles, tipoAgenda).GetDataSet().Tables[0];
            gvFechas.DataBind();
            gvFechas.SelectedIndex = 0;
            if (gvFechas.Rows.Count > 0)
            {
                int idAgenda = Convert.ToInt32(gvFechas.DataKeys[0].Value);
                actualizarTurnos(idAgenda);
                //  llenarCuadroInformacion(idAgenda);
            }
        }

        protected void gvFechas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ConAgenda agenda = new ConAgenda(int.Parse(gvFechas.DataKeys[e.Row.RowIndex].Value.ToString()));

                ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                    .From(Schemas.ConAgendaProfesional).Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(agenda.IdAgenda)
                    .ExecuteAsCollection<ConAgendaProfesionalCollection>();

                ListView lblProfesional = (ListView)e.Row.FindControl("lsvProfesional");
                ListView lblEspecialidad = (ListView)e.Row.FindControl("lsvEspecialidad");
                List<string> lista = new List<string>();
                List<string> listae = new List<string>();

                if (agenda.Multiprofesional == true)
                {
                    for (int x = 0; x < listaAgendaProfesional.Count; x++)
                    {
                        lista.Add(listaAgendaProfesional.ElementAt(x).SysProfesional.NombreCompleto);
                        listae.Add(listaAgendaProfesional.ElementAt(x).SysEspecialidad.Nombre);
                    }

                    lblProfesional.DataSource = lista;
                    lblProfesional.DataBind();

                    lblEspecialidad.DataSource = listae;
                    lblEspecialidad.DataBind();
                }
                else
                {
                    lista.Add(agenda.SysProfesional.NombreCompleto);
                    listae.Add(agenda.SysEspecialidad.Nombre);
                    lblProfesional.DataSource = lista;
                    lblProfesional.DataBind();
                    lblEspecialidad.DataSource = listae;
                    lblEspecialidad.DataBind();
                }

                //ImageButton cmdSelAgenda = (ImageButton)e.Row.Cells[0].FindControl("Select");
                LinkButton cmdSelAgenda = (LinkButton)e.Row.Cells[0].FindControl("Select");
                cmdSelAgenda.CommandArgument = e.Row.Cells[0].Text;
                cmdSelAgenda.CommandName = "Select";
                cmdSelAgenda.ToolTip = "Seleccionar agenda";
            }
        }

        protected void gvFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkButton cmd = (LinkButton)gvFechas.Rows[gvFechas.SelectedIndex].FindControl("Select");
            int idAgenda = int.Parse(gvFechas.SelectedDataKey.Value.ToString()); // Convert.ToInt32(cmd.CommandArgument);

            actualizarTurnos(idAgenda);
            //  llenarCuadroInformacion(idAgenda);         
        }

        private void llenarCuadroInformacion(int idAgenda)
        {
            ConAgenda ag = new ConAgenda(idAgenda);

            lblTotalTurnosEspecialidad.Text = "";
            lblTurnosDiaEspecialidad.Text = "";
            lblTurnosAnticipadosEspecialidad.Text = "";

            lblTurnosDiaEspecialidad1.Text = "";
            lblTurnosAnticipadosEspecialidad1.Text = "";


            
            ConAgendaProfesionalCollection cons = new Select().From(Schemas.ConAgendaProfesional)
                .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(idAgenda)

                .ExecuteAsCollection<ConAgendaProfesionalCollection>();

            int i_especialidad=-1;
            foreach (ConAgendaProfesional data in cons)
            {
                i_especialidad =data.SysEspecialidad.IdEspecialidad;
                    break;
            }

            if (i_especialidad > -1)
            {
                ConCantidadTurnosEspecialidad t = new Select()
                                    .From(ConCantidadTurnosEspecialidad.Schema)
                                  .Where(ConCantidadTurnosEspecialidad.Columns.IdAgenda).IsEqualTo(idAgenda)

                                 .ExecuteSingle<ConCantidadTurnosEspecialidad>();



                int totalturnos = int.Parse(t.CantidadTurnos.ToString());

                double destinadoTurnoDia = (int.Parse(t.CantidadTurnos.ToString()) * int.Parse(t.PorcentajeTurnosDia.ToString())) / 100;
                double destinadoTurnoAnticipado = (int.Parse(t.CantidadTurnos.ToString()) * int.Parse(t.PorcentajeTurnosAnticipado.ToString())) / 100;
                ///carolina: para las agendas multidisciplinarias, todos los turnos son anticipados
                if (ag.Multiprofesional)
                {
                  destinadoTurnoDia =0;
                    destinadoTurnoAnticipado = 100;
                }

                if ((destinadoTurnoDia + destinadoTurnoAnticipado) != totalturnos)
                    destinadoTurnoAnticipado = destinadoTurnoAnticipado + (totalturnos - (destinadoTurnoDia + destinadoTurnoAnticipado));

                lblTotalTurnosEspecialidad.Text = totalturnos.ToString();

                ConCantidadTipoTurnosEspecialidad r = new Select(ConCantidadTipoTurnosEspecialidad.Columns.Cantidad)
                                   .From(ConCantidadTipoTurnosEspecialidad.Schema)
                                 .Where(ConCantidadTipoTurnosEspecialidad.Columns.IdAgenda).IsEqualTo(idAgenda)
                                 .And(ConCantidadTipoTurnosEspecialidad.Columns.IdTipoTurno).IsEqualTo(0)
                           .ExecuteSingle<ConCantidadTipoTurnosEspecialidad>();
                if (r != null)
                    lblTurnosDiaEspecialidad.Text = r.Cantidad.ToString();
                else
                    lblTurnosDiaEspecialidad.Text = "0";

                ConCantidadTipoTurnosEspecialidad Anticipado = new Select(ConCantidadTipoTurnosEspecialidad.Columns.Cantidad)
                                   .From(ConCantidadTipoTurnosEspecialidad.Schema)
                                 .Where(ConCantidadTipoTurnosEspecialidad.Columns.IdAgenda).IsEqualTo(idAgenda)
                                 .And(ConCantidadTipoTurnosEspecialidad.Columns.IdTipoTurno).IsEqualTo(1)
                           .ExecuteSingle<ConCantidadTipoTurnosEspecialidad>();

                if (Anticipado != null) lblTurnosAnticipadosEspecialidad.Text = Anticipado.Cantidad.ToString();
                else lblTurnosAnticipadosEspecialidad.Text = "0";

                lblTurnosDiaEspecialidad1.Text = destinadoTurnoDia.ToString();
                lblTurnosAnticipadosEspecialidad1.Text = destinadoTurnoAnticipado.ToString();
            }


            int disponibles = getTurnosDisponibles();
            int ocupados = getTurnosOcupados();
            int sobreturnos = getSobreturnos();
            int reservados = getReservados();
            int maxsobreturnos = ag.MaximoSobreturnos;
            int bloqueados = getBloqueados();
            //int bloques = 1; // ag.CitarPorBloques;
            int total = disponibles + ocupados - bloqueados;

            if (!PacienteExisteEnAgenda(ag))
            {
                if ((disponibles - bloqueados) == 0)
                {
                    if (ag.Fecha <= DateTime.Now)
                    {
                        //      btnReservar.Visible = false;
                        //  btnReservar.Enabled = false;
                        lblHora.Text = "SOBRETURNO";
                        btnGrabar.Enabled = true;
                        btnGrabar.Text = "Sobreturno";
                        btnGrabar.Visible = ((maxsobreturnos > 0) && (maxsobreturnos > sobreturnos)) ? true : false;
                        rdbTipoTurno.SelectedValue = "0";
                        rdbTipoTurno.Enabled = false;
                        divturnoseleccionado.Visible = ((maxsobreturnos > 0) && (maxsobreturnos > sobreturnos)) ? true : false;
                        divgrabado.Visible = ((maxsobreturnos > 0) && (maxsobreturnos > sobreturnos)) ? true : false;
                    }
                }
                else
                {
                    //btnReservar.Visible = true;
                    //btnReservar.Enabled = false;

                    divgrabado.Visible = false;
                    rdbTipoTurno.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnGrabar.Visible = true;
                    btnGrabar.Text = "Grabar turno";
                }

            }
            else
            {
                lblHora.Text = "El paciente ya tiene turnos en la agenda seleccionada";
                rdbTipoTurno.Visible = false;

                btnGrabar.Visible = false;

                divgrabado.Visible = true;
                divturnoseleccionado.Visible = true;
                updturnos.Update();
            }
            //lblAgenda.Text = "N° Agenda " + ag.IdAgenda.ToString();
            //lblAgenda.Visible = false;

            //lblAgendaDisponibles.Text = disponibles.ToString() + " (" + Rutinas.porcentaje(disponibles, total).ToString() + "%)";
            //lblAgendaOcupados.Text = ocupados.ToString() + " (" + Rutinas.porcentaje(ocupados, total).ToString() + "%)";
            //lblAgendaSobreturnos.Text = sobreturnos.ToString() + " (máximo p/agenda: " + maxsobreturnos + ")";
            //lblAgendaReservados.Text = reservados.ToString() + " (máximo p/agenda: " + maxreservados + ")";
            //imgAgenda.ImageUrl = (ag.IdAgendaEstado == 1) ? "../../App_Themes/consultorio/Agenda/agenda32.png" : "../../App_Themes/consultorio/Agenda/candado32.png";
            //lnkEditarAgenda.PostBackUrl = "~/Consultorio/Agenda/AgendaEdit.aspx?idAgenda=" + idAgenda.ToString();
            //lnkEditarTurnos.PostBackUrl = "TurnosAdmin.aspx?idAgenda=" + idAgenda.ToString();
            //divinfoagenda.Visible = true;
        }

        private int getTurnosDisponibles()
        {
            int disponibles = 0;
            for (int i = 0; i < gvTurnos.Rows.Count; i++)
            {
                if (gvTurnos.Rows[i].Cells[2].Text == "0") { disponibles += 1; }
            }
            return (disponibles);
        }

        private int getTurnosOcupados()
        {
            int ocupados = 0;
            for (int i = 0; i < gvTurnos.Rows.Count; i++)
            {
                if (!(gvTurnos.Rows[i].Cells[2].Text == "0")) { ocupados += 1; }
            }
            return ocupados;
        }

        private int getSobreturnos()
        {
            int sobreturnos = 0;
            for (int i = 0; i < gvTurnos.Rows.Count; i++)
            {
                if ((bool)dtGrilla.Rows[i]["Sobreturno"]) { sobreturnos += 1; }
            }
            return sobreturnos;
        }

        private int getBloqueados()
        {
            int sobreturnos = 0;
            for (int i = 0; i < gvTurnos.Rows.Count; i++)
            {
                if (dtGrilla.Rows[i]["Estado"].ToString() == "Bloqueado") { sobreturnos += 1; }
            }
            return sobreturnos;
        }

        private int getReservados()
        {
            int reservados = 0;
            for (int i = 0; i < gvTurnos.Rows.Count; i++)
            {
                int idTurnoEstado = Convert.ToInt32(dtGrilla.Rows[i]["idTurnoEstado"]);
                if (idTurnoEstado == 2) { reservados += 1; }
            }
            return reservados;
        }

        protected void gvFechas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            if (cmd == "cmdSelAgenda")
            {
                int idAgenda = Convert.ToInt32(e.CommandArgument);
                llenarCuadroInformacion(idAgenda);
            }
        }

        private void actualizarTurnos(int idAgenda)
        {
            ConAgenda oAgenda = new ConAgenda(idAgenda);

            SysProfesional oProfesional = new SysProfesional(oAgenda.IdProfesional);

            string s_especialidad = "";
            if (oAgenda.IdEspecialidad > 0)
            {
                SysEspecialidad oEspecialidad = new SysEspecialidad(oAgenda.IdEspecialidad);
                s_especialidad = oEspecialidad.Nombre;
            }
            if (oAgenda.IdTipoPrestacion > 0)
            {
                ConTipoPrestacion oPrestacion = new ConTipoPrestacion(oAgenda.IdTipoPrestacion);
                s_especialidad = oPrestacion.Nombre;
            }

            DateTime fecha = Convert.ToDateTime(ddlFechas.SelectedValue);
            lblGrillaOk.Text = Rutinas.getNombreDia(fecha).ToUpper() + " " + fecha.ToString().Substring(0, 10) + " " + oAgenda.HoraInicio + " - " + oAgenda.HoraFin;

            if (oAgenda.Multiprofesional == true)
            {
                ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                        .From(Schemas.ConAgendaProfesional).InnerJoin(Schemas.SysProfesional)
                        .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(oAgenda.IdAgenda)
                        .ExecuteAsCollection<ConAgendaProfesionalCollection>();

                List<string> listaProfesionales = new List<string>();

                foreach (ConAgendaProfesional data in listaAgendaProfesional)
                {
                    listaProfesionales.Add(data.SysProfesional.NombreCompleto + " - "  + data.SysEspecialidad.Nombre +  "<br/>");

                }
                lblGrillaOk1.Text = "";
              //  lblGrillaOk1.Text = s_especialidad + "<br>";

                lstProfesionales.DataSource = listaProfesionales.ToList();
                lstProfesionales.DataBind();
            }
            else
            {
                lstProfesionales.DataSource = null;
                lstProfesionales.DataBind();
                lstProfesionales.Items.Clear();
                lblGrillaOk1.Text = oProfesional.Apellido + " " + oProfesional.Nombre + " - " + s_especialidad;
            }

            dtGrilla = construirTurnos(idAgenda);
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.DataBind();
            gvTurnos.Visible = true;

            llenarCuadroInformacion(idAgenda);

            divcomprobante.Visible = false;
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
                        dt.Rows[i]["usuario"] = "";
                        dt.AcceptChanges();
                    }
                }
            }
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

            newRow["DNI"] = "0";
            newRow["HC"] = "0";

            string motivoB = "";

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

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgTurno = (Image)e.Row.FindControl("imgTurno");
                Image imgTipoTurno = (Image)e.Row.FindControl("imgTipoTurno");

                LinkButton cmdSelTurno = (LinkButton)e.Row.FindControl("cmdSelTurno");
                cmdSelTurno.CommandName = "Select";
                cmdSelTurno.ToolTip = "Seleccionar turno";
                cmdSelTurno.CommandArgument = dtGrilla.Rows[e.Row.RowIndex]["Hora"].ToString();

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
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/turnoactivo.png";
                                    imgTurno.ToolTip = "Turno activo";
                                    cmdSelTurno.Visible = true;
                                    break;

                                case "Turno":
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/check_verde16.png";
                                    imgTurno.ToolTip = "Turno del día";

                                    cmdSelTurno.Visible = false;
                                    break;
                                case "Programado":
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/alerta1.png";
                                    imgTurno.ToolTip = "Turno Anticipado";
                                    cmdSelTurno.Visible = false;
                                    break;
                                case "SobreTurno":
                                    imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/alerta.png";
                                    imgTurno.ToolTip = "Sobre Turno";
                                    cmdSelTurno.Visible = false;

                                    break;
                            }
                        } break;
                    case "Bloqueado":
                        {
                            imgTurno.ImageUrl = "../../App_Themes/consultorio/Agenda/turnobloqueado.png";
                            imgTurno.ToolTip = "Turno bloqueado";
                            cmdSelTurno.Visible = false;
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
            int i = gvTurnos.SelectedRow.RowIndex;
            int idTurno = Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]);
            int idTurnoEstado = Convert.ToInt32(dtGrilla.Rows[i]["idTurnoEstado"]);

            int idAgenda = Convert.ToInt32(gvFechas.SelectedDataKey.Value.ToString());
            ConAgenda ag = new ConAgenda(idAgenda);
            if (!PacienteExisteEnAgenda(ag))
            {
                if (HayLugarAnticipados(ag.Fecha))
                {

                    lblHora.Text = "Selección: " + gvTurnos.Rows[i].Cells[1].Text + " hs.";
                    hdnHora.Value = gvTurnos.Rows[i].Cells[1].Text;

                    //Se fija la fecha para determinar si es anticipado o no                     
                    if (ag.Fecha > DateTime.Now)
                    {
                        rdbTipoTurno.SelectedValue = "1"; ///turno anticipado
                        rdbTipoTurno.Enabled = false;
                    }
                    else
                    {
                        rdbTipoTurno.SelectedValue = "0"; // turno del dia
                        rdbTipoTurno.Enabled = true;
                    }
                    rdbTipoTurno.Visible = true;
                    divturnoseleccionado.Visible = true;
                    divgrabado.Visible = true;
                    btnGrabar.Text = "Grabar turno";
                    btnGrabar.Enabled = true;
                    btnGrabar.Visible = true;
                }
                else
                {
                    lblHora.Text = "Ha completado el limite de turnos anticipados.";
                    rdbTipoTurno.Visible = false;

                    btnGrabar.Visible = false;

                    divgrabado.Visible = true;
                    divturnoseleccionado.Visible = true;
                }
            }
            else
            {
                if (Request["accion"] == "1")
                {
                    divturnoseleccionado.Visible = true;
                    divgrabado.Visible = true;
                    btnGrabar.Visible = true;
                    btnGrabar.Enabled = true;
                    lblHora.Visible = true;
                    lblHora.Text = "Selección: " + gvTurnos.Rows[i].Cells[1].Text + " hs.";
                    hdnHora.Value = gvTurnos.Rows[i].Cells[1].Text;
                    rdbTipoTurno.Visible = true;
                    rdbTipoTurno.SelectedValue = "0";
                }
                else
                {
                    lblHora.Text = "El paciente ya tiene turnos en la agenda seleccionada";
                    rdbTipoTurno.Visible = false;

                    btnGrabar.Visible = false;

                    divgrabado.Visible = true;
                    divturnoseleccionado.Visible = true;
                }
            }
            updturnos.Update();
        }

        private bool HayLugarAnticipados(DateTime fechaAgenda)
        {
            bool hayLugar = true;
            if ((lblTurnosAnticipadosEspecialidad.Text != "") && (lblTurnosAnticipadosEspecialidad1.Text != ""))
            {
                if (fechaAgenda > DateTime.Now)
                {
                    if (int.Parse(lblTurnosAnticipadosEspecialidad.Text) == int.Parse(lblTurnosAnticipadosEspecialidad1.Text))
                        hayLugar = false;
                }
            }

            return hayLugar;
        }

        private bool PacienteExisteEnAgenda(ConAgenda ag)
        {
            bool existe = false;
            int idPaciente = int.Parse(Request.QueryString["idPaciente"]);

            ConTurno r = new Select().From(Schemas.ConTurno)
                       .Where(ConTurno.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                       .And(ConTurno.Columns.IdPaciente).IsEqualTo(idPaciente)
                       .And(ConTurno.Columns.IdTurnoEstado).IsEqualTo(1)
                       .ExecuteSingle<ConTurno>();

            if (r != null) //Ya existe
                existe = true;
            else
                existe = false;
            return existe;
        }



        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            // Valido la selección de Obra Social
            if (Page.IsValid)
            {
                if (Request["accion"] == "1")
                {
                    int idTurno = Convert.ToInt32(Request["idTurno"].ToString());
                    ConTurno t = new ConTurno(idTurno);
                    establecerEstado(t);
                }

                bool sobreturno = (btnGrabar.Text == "Sobreturno") ? true : false;

                grabar(false, sobreturno);
            }
        }

        private void grabar(bool reserva, bool sobreturno)
        {
            int idTurno = (sobreturno) ? 0 : Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            string hora = string.Empty;

            if (Request.QueryString["accion"] == "1")
                hora = hdnHora.Value;
            else
                hora = (sobreturno) ? getHoraSobreturno() : gvTurnos.SelectedRow.Cells[1].Text;


            if (!recienDado2(hora))
            {
                idTurno = grabarTurno(idTurno, hora, sobreturno, reserva);

                if (Request.QueryString["idDemandaRechazada"] != null)
                {
                    ConDemandaRechazada DemandaRechazada = new ConDemandaRechazada(int.Parse(Request.QueryString["idDemandaRechazada"]));
                    DemandaRechazada.IdTurnoResolucion = idTurno;
                    DemandaRechazada.Save();
                }

                if (Request.QueryString["accion"] != string.Empty)
                {
                    //acción si está recitando pacientes
                    int accion = Convert.ToInt32(Request.QueryString["accion"]);
                    int idTurnoAnterior = Convert.ToInt32(Request.QueryString["idTurno"]);
                    if (accion == 1) { recitarTurno(idTurnoAnterior, idTurno, SSOHelper.CurrentIdentity.Id); }
                }

                Response.Redirect("TurnoComprobante.aspx?idTurno=" + idTurno, false);
            }
            else
            {
                lblGrillaErr.Text = "El turno fué tomado en otro puesto de trabajo. Actualice vista de turnos";
                divgrilla.Visible = true;
                updturnos.Update();
            }
        }

        private void recitarTurno(int idTurnoAnterior, int idTurno, int idUsuario)
        {
            ConTurnoRecitum r = new ConTurnoRecitum();
            ConTurno t = new ConTurno(idTurnoAnterior);

            r.IdTurnoAnterior = idTurnoAnterior;
            r.IdPaciente = t.IdPaciente;
            r.FechaAnterior = t.Fecha;
            r.HoraAnterior = t.Hora;
            r.IdAgendaAnterior = t.ConAgenda.IdAgenda;
            r.IdTurnoActual = idTurno;
            r.IdUsuario = SSOHelper.CurrentIdentity.Id;
            r.FechaRecita = DateTime.Now;
            r.Save();

            t.IdTurnoEstado = 4;
            t.Save();
        }

        private void setVistaComprobante(int idTurno)
        {
            ConTurno t = new ConTurno(idTurno);

            actualizarTurnos(t.IdAgenda);

            nroTurno.Value = idTurno.ToString();
            lblComprobante.Text = "Comprobante n° " + idTurno.ToString();
            lblComprobanteFecha.Text = "Fecha: " + t.Fecha.ToString().Substring(0, 10) + " " + t.Hora; ;
            lblComprobanteConsultorio.Text = "Consultorio: " + t.ConAgenda.ConConsultorio.Nombre;
            lblComprobanteProfesional.Text = "Profesional: " + t.ConAgenda.SysProfesional.Apellido + " " + t.ConAgenda.SysProfesional.Nombre;
            lblComprobanteBloque.Text = "Concurrir a las " + getHoraPorBloque(t) + " hs.";
            divgrabado.Visible = false;
            divcomprobante.Visible = true;
            gvTurnos.SelectedIndex = -1;
        }

        private string getHoraPorBloque(ConTurno t)
        {
            bool bloques = t.ConAgenda.CitarPorBloques;

            string hora = string.Empty;

            if (!bloques)
                hora = t.Hora;
            else
                hora = t.Hora.Substring(0, 2) + ":00";

            return hora;
        }

        private bool recienDado(int idTurno)
        {
            /// chequeo que no se haya dado el turno en otro puesto de trabajo (no funciona)
            bool dado = false;
            if (idTurno > 0)
            {
                ConTurno t = new ConTurno(idTurno);

                /// no tengo en cuenta turnos reservados
                /// si llega a esta instancia la reserva está vencida
                if (t.IdPaciente > 0 & t.IdTurnoEstado != 2) { dado = true; }
            }
            return dado;
        }

        private bool recienDado2(string hora)
        {
            ///Rehago la verificación de si el turno ya fue dado.
            ///

            int idAgenda = Convert.ToInt32(gvFechas.SelectedDataKey.Value.ToString());
            /// chequeo que no se haya dado el turno en otro puesto de trabajo
            bool dado = false;

            DataTable p = new Select().From(Schemas.ConTurno)
                            .Where(ConTurno.Columns.Hora).IsEqualTo(hora)
                            .And(ConTurno.Columns.IdAgenda).IsEqualTo(idAgenda)
                            .And(ConTurno.Columns.IdTurnoEstado).IsEqualTo(1)
                            .ExecuteDataSet().Tables[0];
            if (p.Rows.Count > 0) dado = true;


            return dado;
        }

        private string getHoraSobreturno()
        {
            string ultimahora = gvTurnos.Rows[gvTurnos.Rows.Count - 1].Cells[1].Text;
            string horas = ultimahora.Substring(0, 2);
            string minutos = ultimahora.Substring(3, 2);
            int h = Convert.ToInt32(horas);
            int m = Convert.ToInt32(minutos);

            m = m + 1;
            while (m > 60)
            {
                h += 1;
                m -= 60;
            }
            minutos = m.ToString();
            horas = h.ToString();
            if (minutos.Length < 2) { minutos = "0" + minutos; }
            if (horas.Length < 2) { horas = "0" + horas; }

            return horas + ":" + minutos;
        }

        private int grabarTurno(int idTurno, string hora, bool sobreturno, bool Reserva)
        {
            int idAgenda = Convert.ToInt32(gvFechas.SelectedDataKey.Value.ToString());

            int idPaciente = 0;
            if (Request.QueryString["idPaciente"] == null)
            {
                int idTurnoAnterior = Convert.ToInt32(Request.QueryString["idTurno"]);
                ConTurno t = new ConTurno(idTurnoAnterior);
                idPaciente = t.IdPaciente;
            }
            else
                idPaciente = int.Parse(Request.QueryString["idPaciente"]);

            SysPaciente pac = new SysPaciente(idPaciente);
            ConTurno turno = new ConTurno(idTurno);

            /// grabado del turno           
            turno.IdAgenda = idAgenda;
            turno.IdObraSocial = OSociales.getObraSocial();

            turno.IdTurnoEstado = (Reserva) ? 2 : 1;
            turno.IdPaciente = pac.IdPaciente;
            turno.IdUsuario = SSOHelper.CurrentIdentity.Id;
            turno.Fecha = Convert.ToDateTime(ddlFechas.SelectedValue);
            turno.Hora = hora;
            turno.Sobreturno = sobreturno;
            turno.IdTipoTurno = int.Parse(rdbTipoTurno.SelectedValue);

            //Se cambia el método Save() por el Storeed Procedure para ver si se soluciona el problema de las agendas duplicadas.
            GuardarTurno guardarTurno = new GuardarTurno();
            guardarTurno.guardarTurno(turno, out idTurno);

            turno.IdTurno = idTurno;

            grabarAuditoriaTurno(turno);

            if (getTurnosDisponibles() - 1 == 0)
            {
                /// si estoy grabando ultimo turno, marco la agenda como sin turnos disponibles
                ConAgenda ag = new ConAgenda(idAgenda);
                ag.TurnosDisponibles = false;
                ag.Save();
            }

            return turno.IdTurno;
        }

        private void confirmarReserva(int idTurno, bool confirma)
        {
            ConTurno turno = new ConTurno(idTurno);
            turno.IdTurnoEstado = (confirma) ? 1 : 4;
            turno.Save();

            ConTurnoReserva r = turno.ConTurnoReservaRecords.Last<ConTurnoReserva>();
            r.CofirmoTurno = confirma;
            r.Save();

            int idAgenda = Convert.ToInt32(gvFechas.SelectedRow.Cells[0].Text);
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
            aud.IdPaciente = turno.IdPaciente;
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



        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("TurnoNuevo.aspx?idPaciente=" + Request.QueryString["idPaciente"], false);
        }

        protected void btnTerminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("TurnoNuevoDefault.aspx", false);
        }

        private void limpiarControles()
        {
            divgrillaerr.Visible = false;
            divgrabado.Visible = false;
            divcomprobante.Visible = false;

            ImageButton cmd = (ImageButton)gvFechas.Rows[gvFechas.SelectedIndex].FindControl("Select");
            int idAgenda = Convert.ToInt32(cmd.CommandArgument);
            actualizarTurnos(idAgenda);
        }

        protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
        {
            int idTurno = Convert.ToInt32(nroTurno.Value);
        }

        protected void btnReservaConfirma_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            confirmarReserva(idTurno, true);
        }

        protected void btnReservaEliminar_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            confirmarReserva(idTurno, false);
        }

        private void buscarTurnos(string Documento)
        {
            int dni = 0;

            try
            {
                dni = Convert.ToInt32(Documento);
            }
            catch { Response.Redirect("~/Paciente/PacienteEdit.aspx"); return; }

            int idPaciente = getIdPaciente(dni);
            if (idPaciente > 0)
            {
                Response.Redirect("TurnosAdmin.aspx?idPaciente=" + idPaciente.ToString());
            }
            else
            {
                Response.Redirect("~/Paciente/PacienteEdit.aspx");
            }
        }

        private int getIdPaciente(int dni)
        {
            DataTable p = new Select().From(Schemas.SysPaciente)
                            .Where(SysPaciente.Columns.NumeroDocumento)
                            .IsEqualTo(dni).ExecuteDataSet().Tables[0];
            return (p.Rows.Count > 0) ? Convert.ToInt32(p.Rows[0]["idPaciente"]) : 0;
        }

        protected void gvHistorial_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label olblAsistencia = (Label)e.Item.FindControl("lblAsistencia");
            if (olblAsistencia != null)
            {
                switch (olblAsistencia.Text)
                {
                    case "Si":
                        {
                            Image oImgSexo = (Image)e.Item.FindControl("imgAsistencia");

                            if (oImgSexo != null)
                            {
                                oImgSexo.ImageUrl = "~/App_Themes/consultorio/agenda/tilde_verde.gif";
                                oImgSexo.ToolTip = "Asistió";
                            }
                        }
                        break;
                    case "No":
                        {
                            Inasistencia += 1;
                            Image oImgSexo = (Image)e.Item.FindControl("imgAsistencia");

                            if (oImgSexo != null)
                            {
                                oImgSexo.ImageUrl = "~/App_Themes/consultorio/agenda/suprime-la-ventana-icono-4582-16.png";
                                oImgSexo.ToolTip = "No asistió";
                            }
                        } break;
                }
            }
        }

        protected void btnDemandaRechazada_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                grabarRechazoDemanda();

                Response.Redirect("TurnoNuevoDefault.aspx?idPaciente=" + Request.QueryString["idPaciente"], false);
            }
        }

        protected void btnGuardarHC_Click(object sender, EventArgs e)
        {
            GuardarHistoriaClinica();
        }

        private void GuardarHistoriaClinica()
        {
            if (DatoValido())
            {
                int idPaciente = int.Parse(Request.QueryString["idPaciente"]);
                SysRelHistoriaClinicaEfector hc = new Select()
                                  .From(SysRelHistoriaClinicaEfector.Schema)
                                .Where(SysRelHistoriaClinicaEfector.Columns.IdPaciente).IsEqualTo(idPaciente)
                                .And(SysRelHistoriaClinicaEfector.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
                               .ExecuteSingle<SysRelHistoriaClinicaEfector>();

                if (hc != null)
                    hc.HistoriaClinica = Convert.ToInt32(txtHistoriaClinica.Text);
                else
                {
                    SysRelHistoriaClinicaEfector rhc = new SysRelHistoriaClinicaEfector();

                    rhc.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                    rhc.HistoriaClinica = Convert.ToInt32(txtHistoriaClinica.Text);
                    rhc.IdPaciente = int.Parse(Request.QueryString["idPaciente"]);
                    rhc.IdUsuarioRegistro = SSOHelper.CurrentIdentity.Username;
                    rhc.FechaRegistro = DateTime.Now;
                    rhc.Save();

                    lblMensajeOK.Text = "La Historia Clínica se guardó correctamente.";
                }
            }
        }

        private bool DatoValido()
        {
            int idPac = int.Parse(Request.QueryString["idPaciente"]);

            if (!string.IsNullOrEmpty(txtHistoriaClinica.Text))
            {
                int nro = Convert.ToInt32(txtHistoriaClinica.Text);

                SubSonic.Select p = new SubSonic.Select();
                p.From(SysRelHistoriaClinicaEfector.Schema);
                p.Where(SysRelHistoriaClinicaEfector.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector);
                p.And(SysRelHistoriaClinicaEfector.Columns.HistoriaClinica).IsEqualTo(nro);

                DataTable dt = p.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblMensaje.Text = "El Número de Historia Clínica ya existe en el Efector. <br/>";
                }
                if (lblMensaje.Text == string.Empty)
                {
                    return true;
                }
            }
            else
                lblMensaje.Text = "Debe ingresar un número válido de Historia Clínica.";

            return false;
        }
    }
}

