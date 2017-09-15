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
using CrystalDecisions.Web;
using DalSic;
using CrystalDecisions.Shared;
using System.IO;
using Salud.Security.SSO;

namespace Consultorio.PanelConsultas
{
    public partial class TurnosxEfector : System.Web.UI.Page
    {
         
        public CrystalReportSource oCr = new CrystalReportSource();


        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));

            //if (!us.IsNew)
            //{
                if (!IsPostBack)
                {
                    txtDesde.Text = DateTime.Now.AddDays(-30).ToString().Substring(0, 10);
                    txtHasta.Text = DateTime.Now.ToString().Substring(0, 10);
                    llenarCombos();              
                    actualizarVista();
                   
                }
            //}
            //else Response.Redirect("~/FinSesion.aspx", false);
        }

        protected void ddlTipoTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cValidator_gr2.IsValid = true;
            //divErr.Visible = false;
            //filaValidacion.Visible = false;
            //filaActivacion.Visible = (Convert.ToInt32(ddlEstado.SelectedValue) == 1) ? false : true;

            if (ddlTipoTurno.SelectedValue == "Prestaciones") //tipo de prestacion
            {
                ConTipoPrestacionCollection e1 = new SubSonic.Select()
                .From(Schemas.ConTipoPrestacion)
                .Where(ConTipoPrestacion.Columns.IdTipoPrestacion).IsNotEqualTo(0)
                .OrderAsc(ConAgendaEstado.Columns.Nombre)
                .ExecuteAsCollection<ConTipoPrestacionCollection>();
                ddlEspecialidad.DataSource = e1;
                ddlEspecialidad.DataValueField = ConTipoPrestacion.Columns.IdTipoPrestacion;
                ddlEspecialidad.DataTextField = ConTipoPrestacion.Columns.Nombre;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, "--Todas--");

            }
            if (ddlTipoTurno.SelectedValue == "Médica") //tipo de prestacion
            {
                SysEspecialidadCollection especialidades = new SubSonic.Select()
                .From(Schemas.SysEspecialidad)
                //.Where(SysServicio.Columns.IdEfector).IsEqualTo(us.IdEfector)
                .OrderAsc(SysEspecialidad.Columns.Nombre)
                .ExecuteAsCollection<SysEspecialidadCollection>();
                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
                ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("Todas", "0"));
            }

        }

        private void llenarCombos()
        {
            SysServicioCollection servicios = new SubSonic.Select()
            .From(Schemas.SysServicio)
            //.Where(SysServicio.Columns.IdEfector).IsEqualTo(us.IdEfector)
            .OrderAsc(SysServicio.Columns.Nombre)
            .ExecuteAsCollection<SysServicioCollection>();
            ddlServicios.DataSource = servicios;
            ddlServicios.DataValueField = SysServicio.Columns.IdServicio;
            ddlServicios.DataTextField = SysServicio.Columns.Nombre;
            ddlServicios.DataBind();
            ddlServicios.Items.Insert(0, new ListItem("Todos", "0"));
            

            SysEspecialidadCollection especialidades= new SubSonic.Select()
            .From(Schemas.SysEspecialidad)
            //.Where(SysServicio.Columns.IdEfector).IsEqualTo(us.IdEfector)
            .OrderAsc(SysEspecialidad.Columns.Nombre)
            .ExecuteAsCollection<SysEspecialidadCollection>();
            ddlEspecialidad.DataSource = especialidades;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Todas", "0"));                             
           
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarVista();
        }

        private void actualizarVista()
        {


            int idServicio = 0;
            int idEspecialidad = 0;
           
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = 0;


            if (ddlServicios.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicios.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            //if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }
            if (ddlTipoTurno.SelectedValue == "Prestaciones") tipoAgenda = 1;
            if (ddlTipoTurno.SelectedValue == "Médico") tipoAgenda = 0;
            //if (ddlTipoReporte.SelectedIndex > 0) { idTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue); }

            //SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));
            //if (us.SysEfector.IdTipoEfector >= 4)
            /////Consulta para nivel central
            //{
            //    idProfesional = 0;
            //    idTipoReporte = 3;
            //}
            //if (Request["tipo"] != null)
            //{
            //    if (Request["tipo"] == "Diagnosticos") idTipoReporte = 4;
            //}

          



            //gvLista.DataSource = SPs.ConTurnosEspecialidad(idServicio, tipoAgenda, idEspecialidad, fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd")).GetDataSet().Tables[0];
         
            //gvLista.DataBind();
   
        }


        //private void PintarReferencias()
        //{



        //    foreach (GridViewRow row in gvLista.Rows)
        //    {
        //        switch (row.Cells[0].Text)
        //        {
        //            case "Inactiva": ///Abierto
        //                {
        //                    row.Cells[0].ForeColor = System.Drawing.Color.Red;
        //                    //Image hlnk = new Image();
        //                    //hlnk.ImageUrl = "~/App_Themes/consultorio/Agenda/turnobloqueado.png";
        //                    //row.Cells[0].Controls.Add(hlnk);
        //                }
        //                break;
        //            case "Bloqueada": //en proceso
        //                {
        //                    row.Cells[0].ForeColor = System.Drawing.Color.Red;
        //                    //Image hlnk = new Image();
        //                    //hlnk.ImageUrl = "~/App_Themes/consultorio/images/amarillo.gif";
        //                    //row.Cells[0].Controls.Add(hlnk);
        //                }
        //                break;
        //            case "Activa": //terminado
        //                {
        //                    row.Cells[0].ForeColor = System.Drawing.Color.Black;
        //                    //Image hlnk = new Image();
        //                    //hlnk.ImageUrl = "~/App_Themes/consultorio/images/verde.gif";
        //                    //row.Cells[0].Controls.Add(hlnk);
        //                }
        //                break;

        //            case "Cerrada": //terminado
        //                {
        //                    row.Cells[0].ForeColor = System.Drawing.Color.Blue;
        //                    //Image hlnk = new Image();
        //                    //hlnk.ImageUrl = "~/App_Themes/consultorio/images/verde.gif";
        //                    //row.Cells[0].Controls.Add(hlnk);
        //                }
        //                break;
        //        }

        //        //switch (row.Cells[1].Text)
        //        //{
        //        //    case "True":
        //        //        {
        //        //            Image hlnk = new Image();
        //        //            hlnk.ImageUrl = "~/App_Themes/default/images/impreso.jpg";
        //        //            hlnk.ToolTip = "Protocolo Impreso";
        //        //            row.Cells[1].Controls.Add(hlnk);
        //        //        }
        //        //        break;
        //        //    case "False":
        //        //        {
        //        //            Image hlnk = new Image();
        //        //            hlnk.ImageUrl = "~/App_Themes/default/images/transparente.jpg";
        //        //            row.Cells[1].Controls.Add(hlnk);
        //        //        }
        //        //        break;

        //        //}

        //    }

        //}




        protected void gvAgendas_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void ImprimirPlanilla(int idAgenda)
        {
            //Aca se deberá consultar los parametros para mostrar una hoja de trabajo u otra
            //this.CrystalReportSource1.Report.FileName = "HTrabajo2.rpt";
            string informe = "../Informes/Planilla.rpt";

            ConAgenda agenda = new ConAgenda(idAgenda);

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = agenda.SysEfector.Nombre;

            DataTable dt = getPlanillaTurnos(agenda);
            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);
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

        private DataTable getPlanillaTurnos(ConAgenda agenda)
        {
            return SPs.ConPlanillaPorAgenda(agenda.IdAgenda).GetDataSet().Tables[0];
        }

        protected void gvAgendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void gvAgendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Editar")
            //    Response.Redirect("AgendaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            //if (e.CommandName == "Imprimir")
            //    ImprimirPlanilla(int.Parse(e.CommandArgument.ToString()));

            //if (e.CommandName == "Cierre")
            //    Response.Redirect("../Turnos/AsistenciaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            //if (e.CommandName == "Codificar")
            //    Response.Redirect("~/ConsultaAmbulatoria/DiagnosticoEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

        }

        protected void gvAgendas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;
            actualizarVista();
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            //SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));


            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector >= 4)//nivel central
                Response.Redirect("../Principal.aspx", false);
            else
                Response.Redirect("PrincipalEfector.aspx", false);
        }


    }
}
