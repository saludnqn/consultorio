using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalSic;
using SubSonic;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Salud.Security.SSO;
using System.Text;

namespace Consultorio.Agenda
{
    public partial class AgendaList : System.Web.UI.Page
    {
        public CrystalReportSource oCr = new CrystalReportSource();
        public CrystalReportSource oCrProf = new CrystalReportSource();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int us = SSOHelper.CurrentIdentity.Id;

            if (!IsPostBack)
            {
                if (Request["llamada"] != null)///es consultorio
                {
                    btnNuevaAgenda.Visible = false;
                    //ddlProfesional.SelectedValue = us.ToString();
                }

                llenarCombos();
                txtAgenda.Focus();
                IniciarValores();
                int idServicio = int.MinValue;
                int idEspecialidad = int.MinValue;
                int idProfesional = int.MinValue;

                try
                {
                    idServicio = Convert.ToInt32(Request.QueryString["idServicio"]);
                    idEspecialidad = Convert.ToInt32(Request.QueryString["idEspecialidad"]);
                    idProfesional = Convert.ToInt32(Request.QueryString["idProfesional"]);

                    if (idServicio > 0) { ddlServicios.SelectedValue = idServicio.ToString(); }
                    if (idEspecialidad > 0) { ddlEspecialidad.SelectedValue = idEspecialidad.ToString(); }
                    if (idProfesional > 0) { ddlProfesional.SelectedValue = idProfesional.ToString(); }

                    buscarAgendas();
                }
                catch { }
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
        }

        private void llenarCombos()
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector < 2) //Centro de salud
            {
                ListItem ItemSeleccion = new ListItem();
                ItemSeleccion.Value = "148";
                ItemSeleccion.Text = "Centro de salud";
                ddlServicios.Items.Add(ItemSeleccion);
                pnlServicio.Visible = false;
            }
            else
            {
                ///Carolina: Modifico para que se muestren los servicios del efector   
                ddlServicios.DataSource = SPs.SysGetServicioByEfector(efector.IdEfector).GetDataSet();
                ddlServicios.DataTextField = SysServicio.Columns.Nombre;
                ddlServicios.DataValueField = SysServicio.Columns.IdServicio;
                ddlServicios.DataBind();
                ddlServicios.Items.Insert(0, new ListItem("Todos", "0"));
                pnlServicio.Visible = true;

                ///
            }

            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(efector.IdEfector, -1).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Todas--");

            ConConsultorioTipoCollection ct = new SubSonic.Select()
                .From(Schemas.ConConsultorioTipo)
                .Where(ConConsultorioTipo.Columns.IdEfector).IsEqualTo(efector.IdEfector)
                .OrderAsc(ConConsultorioTipo.Columns.Nombre)
                .ExecuteAsCollection<ConConsultorioTipoCollection>();
            ddlTipoCons.DataSource = ct;
            ddlTipoCons.DataValueField = ConConsultorioTipo.Columns.IdTipoConsultorio;
            ddlTipoCons.DataTextField = ConConsultorioTipo.Columns.Nombre;
            ddlTipoCons.DataBind();
            ddlTipoCons.Items.Insert(0, new ListItem("Todos", "0"));

            ConAgendaEstadoCollection estado = new SubSonic.Select()
               .From(Schemas.ConAgendaEstado)
               .ExecuteAsCollection<ConAgendaEstadoCollection>();
            ddlEstado.DataSource = estado;
            ddlEstado.DataValueField = ConAgendaEstado.Columns.IdAgendaEstado;
            ddlEstado.DataTextField = ConAgendaEstado.Columns.Nombre;
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("Todas", "0"));

            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(efector.IdEfector, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();

            if (Request["llamada"] != null)
            {
                string username = SSOHelper.CurrentIdentity.Username;

                /// agrego relacion con la sys_relprofesionalefector.
                SysProfesional r = new Select().From(Schemas.SysProfesional)                   
                                       .Where(SysProfesional.Columns.NumeroDocumento).IsEqualTo(username)                                            
                                       .ExecuteSingle<SysProfesional>();               

                if (r != null)
                {
                    ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(efector.IdEfector,int.Parse( username)).GetDataSet();
                    ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
                    ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
                    ddlProfesional.DataBind();

                    ddlProfesional.Items.Clear();
                    ddlProfesional.Items.Insert(0, new ListItem(r.ApellidoyNombre, r.IdProfesional.ToString()));
                    ddlProfesional.Enabled = false;
                    txtHasta.Text = DateTime.Now.ToString().Substring(0, 10);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Debe ser Médico para poder ver esta opción!!!');window.location='../Principal.aspx'; ", true);
            }

            else
                ddlProfesional.Items.Insert(0, new ListItem("Todos", "0"));

            txtDesde.Text = DateTime.Now.ToString().Substring(0, 10);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            buscarAgendas();
        }

        private void buscarAgendas()
        { 
            AlmacenarSesion();
            int idZona = 0;
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            int idTipoConsultorio = 0;
            int idAgendaEstado = 0;
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;

            if (ddlServicios.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicios.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            if ((ddlProfesional.SelectedValue != "0") && (ddlProfesional.SelectedValue != "")) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (ddlTipoCons.SelectedIndex > 0) { idTipoConsultorio = Convert.ToInt32(ddlTipoCons.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }

            if (ddlTipoTurno.SelectedValue == "Prestaciones") tipoAgenda = 0;

            if (ddlTipoTurno.SelectedValue == "Especialidad") tipoAgenda = 1;

            if (ddlEstado.SelectedIndex > 0) { idAgendaEstado = Convert.ToInt32(ddlEstado.SelectedValue); }

            gvAgendas.DataSource = SPs.ConGetAgendas(idZona, SSOHelper.CurrentIdentity.IdEfector, idServicio, idEspecialidad, idProfesional, idTipoConsultorio,
                                   fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), tipoAgenda, idAgendaEstado).GetDataSet().Tables[0];

            gvAgendas.DataBind();

            PintarReferencias();
            btnNuevaAgenda.Enabled = true;

            lblAgendaSinProfesionales.Visible = false;

            
          
           

        }

        private void AlmacenarSesion()
        {
            if (chkRecordarFiltro.Checked)
            {
                
                string s_valores = "ddlEspecialidad:" + ddlEspecialidad.SelectedValue;
                s_valores += ";ddlProfesional:" + ddlProfesional.SelectedValue;
                s_valores += ";ddlTipoCons:" + ddlTipoCons.SelectedValue;
                s_valores += ";txtDesde:" + txtDesde.Text;
                s_valores += ";txtHasta:" + txtHasta.Text;
                s_valores += ";ddlEstado:" + ddlEstado.SelectedValue;

                Session["FiltroProtocolo"] = s_valores;
            }
           
        }

        private void IniciarValores()
        {
            if (Session["FiltroProtocolo"] != null)
            {
                string[] arr = Session["FiltroProtocolo"].ToString().Split((";").ToCharArray());
                foreach (string item in arr)
                {
                    string[] s_control = item.Split((":").ToCharArray());
                    switch (s_control[0].ToString())
                    {
                        case "txtDesde": txtDesde.Text = s_control[1].ToString(); break;
                        case "txtHasta": txtHasta.Text = s_control[1].ToString(); break;
                        case "ddlEspecialidad": ddlEspecialidad.SelectedValue = s_control[1].ToString(); break;


                    

                        case "ddlProfesional": ddlProfesional.SelectedValue = s_control[1].ToString(); break;

                        case "ddlTipoCons": ddlTipoCons.SelectedValue = s_control[1].ToString(); break;
                        case "ddlEstado": ddlEstado.SelectedValue = s_control[1].ToString(); break;
                       


                    }
                }
            }

        }
        private void PintarReferencias()
        {
            foreach (GridViewRow row in gvAgendas.Rows)
            {
                switch (row.Cells[0].Text)
                {
                    case "Inactiva": ///Abierto
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Red;
                        }
                        break;
                    case "Bloqueada": //en proceso
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Red;
                        }
                        break;
                    case "Activa": //terminado
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Black;

                        }
                        break;

                    case "Cerrada": //terminado
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Blue;
                        }
                        break;
                }
            }
        }

        protected void gvAgendas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private DataTable getPlanillaTurnos(ConAgenda agenda)
        {
            return SPs.ConPlanillaPorAgenda(agenda.IdAgenda).GetDataSet().Tables[0];
        }

        protected void gvAgendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ConAgenda agenda = new ConAgenda(int.Parse(gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString()));

                    ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                        .From(Schemas.ConAgendaProfesional).Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(agenda.IdAgenda)
                        .ExecuteAsCollection<ConAgendaProfesionalCollection>();

                

                    ListView lblProfesional = (ListView)e.Row.FindControl("lsvProfesional");
                    ListView lblEspecialidad = (ListView)e.Row.FindControl("lsvEspecialidad");

                    List<string> lista = new List<string>();
                    List<string> lista_e = new List<string>();

                    //if (agenda.Multiprofesional == true)
                    //{
                        for (int x = 0; x < listaAgendaProfesional.Count; x++)
                        {
                            lista.Add(listaAgendaProfesional.ElementAt(x).SysProfesional.NombreCompleto);
                            lista_e.Add(listaAgendaProfesional.ElementAt(x).SysEspecialidad.Nombre);
                        }

                        lblProfesional.DataSource = lista;
                        lblProfesional.DataBind();

                        lblEspecialidad.DataSource = lista_e;
                        lblEspecialidad.DataBind();
                    //}
                    //else
                    //{
                    //    lista.Add(agenda.SysProfesional.NombreCompleto);

                    //    lblProfesional.DataSource = lista;
                    //    lblProfesional.DataBind();
                    //}

                    LinkButton cmdEditar = (LinkButton)e.Row.FindControl("Editar");
                    cmdEditar.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                    cmdEditar.CommandName = "Editar";
                    cmdEditar.ToolTip = "Editar";

                    LinkButton cmdPlanilla = (LinkButton)e.Row.FindControl("Planilla");
                    cmdPlanilla.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                    cmdPlanilla.CommandName = "Imprimir";
                    cmdPlanilla.ToolTip = "Imprimir Planilla";


                    LinkButton cmdCierre = (LinkButton)e.Row.FindControl("Cierre");
                    cmdCierre.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                    cmdCierre.CommandName = "Cierre";
                    cmdCierre.ToolTip = "Cerrar Agenda";


                    LinkButton cmdCodificar = (LinkButton)e.Row.FindControl("Codificar");
                    cmdCodificar.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                    cmdCodificar.CommandName = "Codificar";
                    cmdCodificar.ToolTip = "Codificar Agenda";

                    //Nuevo consultroio medicos
                    LinkButton cmdConMedico = (LinkButton)e.Row.FindControl("ConMedico");
                    cmdConMedico.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                    cmdConMedico.CommandName = "ConMedico";
                    cmdConMedico.ToolTip = "Consultorio Medico";
                    ConAgenda Agenda = new ConAgenda(int.Parse(gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString()));
                    if (Agenda.SysEfector.IdTipoEfector <= 1) //Centro de salud
                        e.Row.Cells[2].Text = "-";

                    if (int.Parse(e.Row.Cells[10].Text) < 0) e.Row.Cells[10].Text = "0";

                    switch (Agenda.IdAgendaEstado)
                    {
                        case 1: //Está Activa                           
                            {
                                cmdCierre.Visible = true;
                                cmdCodificar.Visible = true;
                                cmdConMedico.Visible = true;
                            }

                            if (Agenda.Fecha > DateTime.Now)
                            { cmdCierre.Visible = false; cmdCodificar.Visible = false; cmdConMedico.Visible = false; }
                            break;
                        case 2: ///Está Bloqueada
                            {
                                cmdPlanilla.Visible = false;
                                cmdCierre.Visible = false;
                                cmdCodificar.Visible = false;
                                cmdConMedico.Visible = false;
                            } break;

                        case 3: ///Está Inactiva
                            {
                                cmdPlanilla.Visible = false;
                                cmdCierre.Visible = false;
                                cmdCodificar.Visible = false;
                                cmdConMedico.Visible = false;
                            } break;

                        case 4:  //Está cerrada
                            {
                                cmdEditar.Visible = false;
                                //  cmdPlanilla.Visible = false;
                                cmdCodificar.Visible = true;
                                cmdConMedico.Visible = true;
                            } break;
                    }

                    if ((Agenda.SysProfesional.IdProfesional == -1) && (Agenda.Multiprofesional == false))
                    {
                        if (DateTime.Parse(e.Row.Cells[1].Text).ToShortDateString() == DateTime.Now.ToShortDateString())
                        {
                            cmdPlanilla.Enabled = false;
                            cmdCierre.Enabled = false;
                            lblAgendaSinProfesionales.Visible = true;
                        }

                        cmdCodificar.Enabled = false;
                        cmdConMedico.Enabled = false;
                    }

                    if (Request["llamada"] != null)
                    {
                        e.Row.Cells[16].Visible = true;
                        cmdConMedico.Visible = true;
                        e.Row.Cells[15].Visible = false;
                        cmdCodificar.Visible = false;
                        e.Row.Cells[14].Visible = false;
                        cmdCierre.Visible = false;
                        e.Row.Cells[12].Visible = false;
                        cmdEditar.Visible = false;
                        e.Row.Cells[13].Visible = true;
                        cmdPlanilla.Visible = true;
                    }
                    else
                    {
                        e.Row.Cells[16].Visible = false;
                        cmdConMedico.Visible = false;
                        e.Row.Cells[15].Visible = true;
                        cmdCodificar.Visible = true;
                        e.Row.Cells[14].Visible = true;
                        cmdCierre.Visible = true;
                        e.Row.Cells[12].Visible = true;
                        cmdEditar.Visible = true;
                        e.Row.Cells[13].Visible = true;
                        cmdPlanilla.Visible = true;
                    }

                }

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Request["llamada"] != null)///es cionsultorio
                    {
                        e.Row.Cells[16].Visible = true;
                        e.Row.Cells[15].Visible = false;
                        e.Row.Cells[14].Visible = false;
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = true;
                    }
                    else
                    {
                        e.Row.Cells[16].Visible = false;
                        e.Row.Cells[15].Visible = true;
                        e.Row.Cells[14].Visible = true;
                        e.Row.Cells[13].Visible = true;
                        e.Row.Cells[12].Visible = true;
                    }
                }
            }
        }

        protected void gvAgendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
                Response.Redirect("AgendaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            if (e.CommandName == "Imprimir")
                ImprimirPlanilla(int.Parse(e.CommandArgument.ToString()));

            if (e.CommandName == "Cierre")
                Response.Redirect("../Turnos/AsistenciaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            if (e.CommandName == "Codificar")
            {     //verificar si la agenda es de odonto que lleve a diagnosticoeditodontologia
                ConAgenda agenda = new ConAgenda(int.Parse(e.CommandArgument.ToString()));

                if (agenda.IdEspecialidad == 34)///Odontologia
                {
                    Response.Redirect("../Turnos/DiagnosticoEditOdontologia.aspx?idAgenda=" + e.CommandArgument.ToString() + "&Desde=Codificar", false);                
                }
                else
                { 
                    Session["idTurnoSeleccionado"] = ""; // Utilizo esta variable en "DiagnosticoEdit.aspx".
                    Response.Redirect("../Turnos/DiagnosticoEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);
                }
            }

            //Diagnosticar Consultorio Medicos
            if (e.CommandName == "ConMedico")
            {     //verificar si la agenda es de odonto que lleve a diagnosticoeditodontologia
                ConAgenda agenda = new ConAgenda(int.Parse(e.CommandArgument.ToString()));

                if (agenda.IdEspecialidad == 34)///Odontologia
                {
                    Response.Redirect("../Turnos/DiagnosticoEditOdontologia.aspx?idAgenda=" + e.CommandArgument.ToString() + "&Desde=Consultorio", false);                
                }
                else
                {
                    Session["idTurnoSeleccionado"] = ""; // Utilizo esta variable en "DiagnosticoEditConsultorio.aspx".
                    Response.Redirect("../Turnos/DiagnosticoEditConsultorio.aspx?idAgenda=" + e.CommandArgument.ToString(), false);                
                }
            }
        }

        protected void gvAgendas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAgendas.PageIndex = e.NewPageIndex;
            buscarAgendas();
        }

        private bool AgendasSinProfesional()
        {
            bool valido = false;

            ConAgendaCollection listaAgenda = new SubSonic.Select().From(Schemas.ConAgenda)
            .Where(ConAgenda.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
            .And(ConAgenda.Columns.Fecha).IsEqualTo(DateTime.Today)
            .And(ConAgenda.Columns.IdAgendaEstado).IsEqualTo(1)
            .ExecuteAsCollection<ConAgendaCollection>();

            foreach (ConAgenda data in listaAgenda)
            {
                if ((data.IdProfesional == -1) && (data.Multiprofesional == false))
                    valido = true;
            }

            return valido;
        }

        private void ImprimirPlanilla(int idAgenda)
        {
            //Aca se deberá consultar los parametros para mostrar una hoja de trabajo u otra           
            string informe = "../Informes/Planilla.rpt";
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            ConAgenda agenda = new ConAgenda(idAgenda);

            DataTable dtProf = new DataTable();
            string profesionales = string.Empty;

            if (efector.IdTipoEfector < 2) //Centro de salud
                informe = "../Informes/Planilla.rpt";
            else
                informe = "../Informes/Planilla_Oficio.rpt";

            if ((agenda.IdEspecialidad == 50) || (agenda.IdEspecialidad == 52) || (agenda.IdEspecialidad == 25))///Salud Mental
            {
                if (efector.IdTipoEfector < 2)
                { //Centro de salud                    
                    informe = "../Informes/PlanillaSaludMental.rpt";

                    ConAgendaProfesionalCollection agendaProf = new SubSonic.Select().From(Schemas.ConAgendaProfesional)
            .InnerJoin(Schemas.SysProfesional).Where(ConAgendaProfesional.Columns.IdAgenda)
            .IsEqualTo(idAgenda).ExecuteAsCollection<ConAgendaProfesionalCollection>();

                    foreach (ConAgendaProfesional data in agendaProf)
                    {
                        profesionales = profesionales + data.SysProfesional.NombreCompleto + " - ";
                    }

                    dtProf.Columns.Add("NombreCompleto");

                    if (profesionales != "")
                        dtProf.Rows.Add(profesionales.ToString());
                    else
                        dtProf.Rows.Add("");
                }
                else
                    informe = "../Informes/PlanillaSaludMental_Oficio.rpt";
            }

            if ((agenda.IdEspecialidad == 34) || (agenda.IdEspecialidad == 186))///Odontologia
                informe = "../Informes/PlanillaOdontologia2.rpt";

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = agenda.SysEfector.Nombre;

            DataTable dt = getPlanillaTurnos(agenda);
            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);

            if (profesionales != "")
                oCr.ReportDocument.Subreports["Profesionales.rpt"].SetDataSource(dtProf);

            oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);

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

        protected void BtnOtrasActividades_Click(object sender, EventArgs e)
        {
            string url = "../../../ActividadGrupal/Default.aspx";
            Response.Redirect(url, false);
        }
    }
}
