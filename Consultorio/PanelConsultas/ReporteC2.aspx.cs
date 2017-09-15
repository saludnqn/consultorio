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
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.IO;
using Salud.Security.SSO;
using System.Text.RegularExpressions;

namespace Consultorio.PanelConsultas
{
    public partial class ReporteC2 : System.Web.UI.Page
    {
        public CrystalReportSource oCr = new CrystalReportSource();

        int suma1 = 0; int suma2 = 0; int suma3 = 0; int suma4 = 0; int suma5 = 0; int suma6 = 0; int suma7 = 0; int suma8 = 0; int suma9 = 0;
        int suma10 = 0; int suma11 = 0; int suma12 = 0; int suma13 = 0;


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
                txtDesde.Text = DateTime.Now.AddDays(-7).ToString().Substring(0, 10);
                txtHasta.Text = DateTime.Now.ToString().Substring(0, 10);

                llenarCombos();
                gvLista.DataSource = buscarAgendas();
                gvLista.DataBind();
            }
            //}
            //else Response.Redirect("~/FinSesion.aspx", false);
        }

        private void llenarCombos()
        {
            SysZonaCollection ct1 = new SubSonic.Select()
               .From(Schemas.SysZona)
               .Where(SysZona.Columns.IdZona).IsGreaterThan(1)
               .OrderAsc(SysZona.Columns.IdZona)
               .ExecuteAsCollection<SysZonaCollection>();
            ddlZona.DataSource = ct1;
            ddlZona.DataValueField = SysZona.Columns.IdZona;
            ddlZona.DataTextField = SysZona.Columns.Nombre;
            ddlZona.DataBind();
            ddlZona.Items.Insert(0, new ListItem("Todos", "0"));

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector == 1)///Centro de salud
            {
                pnlEfector.Visible = false;
                SysEfectorCollection ct = new SubSonic.Select()
                   .From(Schemas.SysEfector)
                   .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                   .And(SysEfector.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
                   .OrderAsc(SysEfector.Columns.Nombre)
                   .ExecuteAsCollection<SysEfectorCollection>();
                ddlEfector.DataSource = ct;
                ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
                ddlEfector.DataTextField = SysEfector.Columns.Nombre;
                ddlEfector.DataBind();
            }
            else
            {
                ddlZona.Enabled = false;
                pnlEfector.Visible = true;
                SysEfectorCollection ct = new SubSonic.Select()
                    .From(Schemas.SysEfector)
                    .Where(SysEfector.Columns.IdEfector).IsEqualTo(efector.IdEfector)
                    //.And(SysEfector.Columns.IdEfector).IsEqualTo(us.IdEfector)
                    .OrderAsc(SysEfector.Columns.Nombre)
                    .ExecuteAsCollection<SysEfectorCollection>();
                ddlEfector.DataSource = ct;
                ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
                ddlEfector.DataTextField = SysEfector.Columns.Nombre;
                ddlEfector.DataBind();
                //ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));
            }

        }

        private DataTable buscarAgendas()
        {
            int idZona = 0;
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            //int idTipoConsultorio = 0;
            int idTipoReporte = int.Parse(ddlTipoDeInforme.SelectedValue);
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;


            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }



            // SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"])); int idEfector = us.IdEfector;
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector >= 4)
            ///Consulta para nivel central
            {
                idProfesional = 0;
                //idEfector = int.Parse(ddlEfector.SelectedValue);
                efector.IdEfector = int.Parse(ddlEfector.SelectedValue);
                //  idTipoReporte = 3;
            }

            int tipoDiagnostico = -1;


            string filtro = "";
            //  if (ddlCategoria.SelectedIndex > 0) filtro = ddlCategoria.SelectedValue;

            return SPs.ConEstadisticaDiagnosticos(idZona, efector.IdEfector, idServicio, idEspecialidad, idProfesional, fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), filtro, tipoDiagnostico, tipoAgenda, int.Parse(ddlTipoDeInforme.SelectedValue)).GetDataSet().Tables[0];
        }


        protected void gvLista_RowDataBound(object sender, EventArgs e)
        {

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) gvLista.DataSource = buscarAgendas();
            gvLista.DataBind();
        }

        protected void ddlZona_SelectedIndexChanged()
        {

        }
        protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            ddlEfector.Items.Clear();
            if (ddlZona.SelectedValue != "0")
            {

                SysEfectorCollection ct = new SubSonic.Select()
                      .From(Schemas.SysEfector)
                      .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                      .And(SysEfector.Columns.IdZona).IsEqualTo(int.Parse(ddlZona.SelectedValue))
                      .OrderAsc(SysEfector.Columns.Nombre)
                      .ExecuteAsCollection<SysEfectorCollection>();
                ddlEfector.DataSource = ct;
                ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
                ddlEfector.DataTextField = SysEfector.Columns.Nombre;
                ddlEfector.DataBind();
                ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));
            }
            else
            {
                SysEfectorCollection ct = new SubSonic.Select()
                .From(Schemas.SysEfector)
                 .Where(SysEfector.Columns.IdEfector).IsEqualTo(efector.IdEfector)
             //   .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                    //    .And(SysEfector.Columns.IdZona).IsEqualTo(us.SysEfector.IdZona)
                .OrderAsc(SysEfector.Columns.Nombre)
                .ExecuteAsCollection<SysEfectorCollection>();
                ddlEfector.DataSource = ct;
                ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
                ddlEfector.DataTextField = SysEfector.Columns.Nombre;
                ddlEfector.DataBind();
                ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));
            }
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

        protected void gvLista_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            int i = 1;

            if ((e.Row.RowType == DataControlRowType.DataRow))
            {



                LinkButton cmdEditar = (LinkButton)e.Row.FindControl("Ver");
                cmdEditar.CommandArgument = e.Row.Cells[1].Text;
                cmdEditar.CommandName = "Ver";
                cmdEditar.ToolTip = "Ver";


                if (e.Row.Cells[1 + i].Text == "0") e.Row.Cells[1 + i].Text = "&nbsp;";
                if (e.Row.Cells[1 + i].Text != "&nbsp;")
                    suma1 += int.Parse(e.Row.Cells[1 + i].Text);

                if (e.Row.Cells[2 + i].Text == "0") e.Row.Cells[2 + i].Text = "&nbsp;";
                if (e.Row.Cells[2 + i].Text != "&nbsp;")
                    suma2 += int.Parse(e.Row.Cells[2 + i].Text);

                if (e.Row.Cells[3 + i].Text == "0") e.Row.Cells[3 + i].Text = "&nbsp;";
                if (e.Row.Cells[3 + i].Text != "&nbsp;")
                    suma3 += int.Parse(e.Row.Cells[3 + i].Text);

                if (e.Row.Cells[4 + i].Text == "0") e.Row.Cells[4 + i].Text = "&nbsp;";
                if (e.Row.Cells[4 + i].Text != "&nbsp;")
                    suma4 += int.Parse(e.Row.Cells[4 + i].Text);

                if (e.Row.Cells[5 + i].Text == "0") e.Row.Cells[5 + i].Text = "&nbsp;";
                if (e.Row.Cells[5 + i].Text != "&nbsp;")
                    suma5 += int.Parse(e.Row.Cells[5 + i].Text);

                if (e.Row.Cells[6 + i].Text == "0") e.Row.Cells[6 + i].Text = "&nbsp;";
                if (e.Row.Cells[6 + i].Text != "&nbsp;")
                    suma6 += int.Parse(e.Row.Cells[6 + i].Text);

                if (e.Row.Cells[7 + i].Text == "0") e.Row.Cells[7 + i].Text = "&nbsp;";
                if (e.Row.Cells[7 + i].Text != "&nbsp;")
                    suma7 += int.Parse(e.Row.Cells[7 + i].Text);

                if (e.Row.Cells[8 + i].Text == "0") e.Row.Cells[8 + i].Text = "&nbsp;";
                if (e.Row.Cells[8 + i].Text != "&nbsp;")
                    suma8 += int.Parse(e.Row.Cells[8 + i].Text);

                if (e.Row.Cells[9 + i].Text == "0") e.Row.Cells[9 + i].Text = "&nbsp;";
                if (e.Row.Cells[9 + i].Text != "&nbsp;")
                    suma9 += int.Parse(e.Row.Cells[9 + i].Text);

                if (e.Row.Cells[10 + i].Text == "0") e.Row.Cells[10 + i].Text = "&nbsp;";
                if (e.Row.Cells[10 + i].Text != "&nbsp;")
                    suma10 += int.Parse(e.Row.Cells[10 + i].Text);

                if (e.Row.Cells[11 + i].Text == "0") e.Row.Cells[11 + i].Text = "&nbsp;";
                if (e.Row.Cells[11 + i].Text != "&nbsp;")
                    suma11 += int.Parse(e.Row.Cells[11 + i].Text);


                if (e.Row.Cells[12 + i].Text == "0") e.Row.Cells[12 + i].Text = "&nbsp;";
                if (e.Row.Cells[12 + i].Text != "&nbsp;")
                    suma12 += int.Parse(e.Row.Cells[12 + i].Text);

                if (e.Row.Cells[13 + i].Text == "0") e.Row.Cells[13 + i].Text = "&nbsp;";
                if (e.Row.Cells[13 + i].Text != "&nbsp;")
                    suma13 += int.Parse(e.Row.Cells[13 + i].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0 + i].Text = "TOTAL DE CONSULTAS";
                e.Row.Cells[1 + i].Text = suma1.ToString();
                e.Row.Cells[2 + i].Text = suma2.ToString();
                e.Row.Cells[3 + i].Text = suma3.ToString();
                e.Row.Cells[4 + i].Text = suma4.ToString();
                e.Row.Cells[5 + i].Text = suma5.ToString();
                e.Row.Cells[6 + i].Text = suma6.ToString();
                e.Row.Cells[7 + i].Text = suma7.ToString();
                e.Row.Cells[8 + i].Text = suma8.ToString();
                e.Row.Cells[9 + i].Text = suma9.ToString();
                e.Row.Cells[10 + i].Text = suma10.ToString();
                e.Row.Cells[11 + i].Text = suma11.ToString();
                e.Row.Cells[12 + i].Text = suma12.ToString();
                e.Row.Cells[13 + i].Text = suma13.ToString();
            }

        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
                ImprimirPlanillaDetallada("PDF", e.CommandArgument.ToString());
        }

        private DataTable buscarPacientesDiagnosticos(string diagnostico)
        {
            int idZona = 0;
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            //int idTipoConsultorio = 0;
            int idTipoReporte = 5;
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;


            //if (ddlServicios.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicios.SelectedValue); }
            //if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            //if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }
            int tipoDiagnostico = -1;
            //if (ddlTipoDiagnostico.SelectedIndex > 0) tipoDiagnostico = Convert.ToInt32(ddlTipoDiagnostico.SelectedValue);
            //if (ddlTipoTurno.SelectedValue == "Prestaciones") tipoAgenda = 0;

            //if (ddlTipoTurno.SelectedValue == "Especialidad") tipoAgenda = 1;

            //if (ddlTipoReporte.SelectedIndex > 0) { 
            //idTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
            //}

            // SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector >= 4)
            ///Consulta para nivel central
            {
                idProfesional = 0;
                // idTipoReporte = 3;
            }
            //if (Request["tipo"] != null)
            //{
            //    if (Request["tipo"] == "Diagnosticos") idTipoReporte = 5;
            //}

            int? tipoDeInforme; 

            switch(ddlTipoDeInforme.SelectedValue) {
                case "5":
                     tipoDeInforme = 6;
                     break;
                default:
                     tipoDeInforme = 4;
                     break;
            }

            return SPs.ConEstadisticaDiagnosticos(idZona, efector.IdEfector, idServicio, idEspecialidad, idProfesional, fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), diagnostico, tipoDiagnostico, tipoAgenda, tipoDeInforme).GetDataSet().Tables[0];

            //return SPs.ConEstadisticaConsultas(us.IdEfector, idServicio, idEspecialidad, idProfesional,
            //                       fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), tipoAgenda, idTipoReporte).GetDataSet().Tables[0];



        }
        private void ImprimirPlanillaDetallada(string tipo, string diagnostico)
        {

            string tipoReporte = "Reporte C2";
            string nombreReporte = "EstadisticaDiagnosticoDetallada.rpt";

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            string nombreEfector = efector.Nombre;
            //if (us.SysEfector.IdTipoEfector >= 4) ///Consulta para nivel central
            //    tipoReporte = "EFECTOR";
            //else
            //{

            //    switch (Convert.ToInt32(ddlTipoReporte.SelectedValue))
            //    {
            //        case 0: tipoReporte = "SERVICIO"; break;
            //        case 1: tipoReporte = "ESPECIALIDAD"; break;
            //        case 2: tipoReporte = "PROFESIONAL"; break;
            //    }

            //    if (Request["tipo"] != null)
            //    {
            //        if (Request["tipo"] == "Diagnosticos")
            //        {
            //            tipoReporte = "DIAGNOSTICO";
            //            nombreReporte = "EstadisticaDiagnostico.rpt";
            //        }
            //    }
            //}


            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = tipoReporte;

            ParameterDiscreteValue encabezado2 = new ParameterDiscreteValue();
            encabezado2.Value = "Periodo: " + txtDesde.Text + " - " + txtHasta.Text;

            ParameterDiscreteValue encabezado3 = new ParameterDiscreteValue();
            encabezado3.Value = nombreEfector;

            DataTable dt = buscarPacientesDiagnosticos(diagnostico);
            oCr.Report.FileName = nombreReporte;
            oCr.ReportDocument.SetDataSource(dt);


            oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);
            oCr.ReportDocument.ParameterFields[1].CurrentValues.Add(encabezado2);
            oCr.ReportDocument.ParameterFields[2].CurrentValues.Add(encabezado3);

            oCr.DataBind();

            MemoryStream oStream; // using System.IO
            if (tipo == "PDF")
            {
                oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=EstadisticasDetallada.pdf");
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
            }
            if (tipo == "EXCEL")
            {
                oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=EstadisticasDetallada.xls");
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
            }


        }

        protected void lnkPdf_Click(object sender, EventArgs e)
        {
            ImprimirPlanilla("PDF");
        }


        private void ImprimirPlanilla(string tipo)
        {

            string tipoReporte = "DIAGNOSTICO";
            string nombreReporte = "EstadisticaDiagnosticoC2.rpt";

            //SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            string nombreEfector = efector.Nombre;
            if (efector.IdTipoEfector >= 4) ///Consulta para nivel central
                nombreEfector = ddlEfector.SelectedItem.Text;
            //else
            //{

            //    switch (Convert.ToInt32(ddlTipoReporte.SelectedValue))
            //    {
            //        case 0: tipoReporte = "SERVICIO"; break;
            //        case 1: tipoReporte = "ESPECIALIDAD"; break;
            //        case 2: tipoReporte = "PROFESIONAL"; break;
            //    }

            //    if (Request["tipo"] != null)
            //    {
            //        if (Request["tipo"] == "Diagnosticos")
            //        {
            //            tipoReporte = "DIAGNOSTICO";
            //            nombreReporte = "EstadisticaDiagnostico.rpt";
            //        }
            //    }
            //}


            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = tipoReporte;

            ParameterDiscreteValue encabezado2 = new ParameterDiscreteValue();
            encabezado2.Value = "Periodo: " + txtDesde.Text + " - " + txtHasta.Text;

            ParameterDiscreteValue encabezado3 = new ParameterDiscreteValue();
            encabezado3.Value = nombreEfector;

            DataTable dt = buscarAgendas();
            oCr.Report.FileName = nombreReporte;
            oCr.ReportDocument.SetDataSource(dt);


            oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);
            oCr.ReportDocument.ParameterFields[1].CurrentValues.Add(encabezado2);
            oCr.ReportDocument.ParameterFields[2].CurrentValues.Add(encabezado3);

            oCr.DataBind();

            MemoryStream oStream; // using System.IO
            if (tipo == "PDF")
            {
                oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=Estadisticas.pdf");
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
            }
            if (tipo == "EXCEL")
            {
                oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=Estadisticas.xls");
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
            }


        }

        protected void lnkExcel_Click(object sender, EventArgs e)
        {
            ImprimirPlanilla("EXCEL");
        }
    }
}
