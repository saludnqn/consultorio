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
    public partial class ReporteDiagnosticos : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                txtDesde.Text = DateTime.Now.AddDays(-30).ToString().Substring(0, 10);
                txtHasta.Text = DateTime.Now.ToString().Substring(0, 10);

                SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
                if (efector.IdTipoEfector >= 4)
                { ///Panel para zona zanitaria y para subsecretaria

                    pnlEfector.Visible = true;
                    pnlFiltroProfesional.Visible = false; //Se ocultan filtros para efectores

                }
                else
                {
                    pnlEfector.Visible = false;
                    pnlFiltroProfesional.Visible = true; //Se ocultan filtros para efectores
                }

                llenarCombos();
                CargarGrilla();


            }
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

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector >= 4)
            { ///Panel para zona zanitaria y para subsecretaria
                ///
                if (ddlTipoTurno.SelectedValue == "Prestaciones") //tipo de prestacion            
                {
                    SysEspecialidadCollection cte = new SubSonic.Select()
                    .From(Schemas.SysEspecialidad)

                    .Where(SysEspecialidad.Columns.Codigo).IsEqualTo(0)
                    .OrderAsc(SysEspecialidad.Columns.Nombre)
                    .ExecuteAsCollection<SysEspecialidadCollection>();
                    ddlEspecialidad.DataSource = cte;
                }

                if (ddlTipoTurno.SelectedValue == "Especialidad") //especialidades
                {
                    SysEspecialidadCollection cte = new SubSonic.Select()
                    .From(Schemas.SysEspecialidad)
                    .Where(SysEspecialidad.Columns.Codigo).IsNotEqualTo(0)
                    .OrderAsc(SysEspecialidad.Columns.Nombre)
                    .ExecuteAsCollection<SysEspecialidadCollection>();
                    ddlEspecialidad.DataSource = cte;
                }

                if (ddlTipoTurno.SelectedValue == "0") //especialidades
                {
                    SysEspecialidadCollection cte = new SubSonic.Select()
                        .From(Schemas.SysEspecialidad)
                        .OrderAsc(SysEspecialidad.Columns.Nombre)
                        .ExecuteAsCollection<SysEspecialidadCollection>();
                    ddlEspecialidad.DataSource = cte;
                }

                ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
                ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("Todas", "0"));
            }
            else
            {
                ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, i_tipo).GetDataSet();

                ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
                ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, "--Todas--");
            }
        }

        private void llenarCombos()
        {
            ///Carolina: Modifico para que se muestren los servicios del efector   
            ///
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector < 4)
            {
                if (efector.IdTipoEfector <= 2) //Centro de salud
                {
                    ListItem ItemSeleccion = new ListItem();
                    ItemSeleccion.Value = "148";
                    ItemSeleccion.Text = "Centro de salud";
                    ddlServicios.Items.Add(ItemSeleccion);
                    pnlServicio.Visible = false;
                }
                else
                {
                    ddlServicios.DataSource = SPs.SysGetServicioByEfector(SSOHelper.CurrentIdentity.IdEfector).GetDataSet();
                    ddlServicios.DataTextField = SysServicio.Columns.Nombre;
                    ddlServicios.DataValueField = SysServicio.Columns.IdServicio;
                    ddlServicios.DataBind();
                    ddlServicios.Items.Insert(0, new ListItem("Todos", "0"));
                }
            }
            else
            {
                pnlServicio.Visible = false;
            }
            ///---------------------------------------

            ///Carolina: Modifico para que se muestren los servicios del efector   
            ///

            if (efector.IdTipoEfector < 4)
                ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, -1).GetDataSet();
            else
                ddlEspecialidad.DataSource = new SubSonic.Select()
                    .From(Schemas.SysEspecialidad)
             .OrderAsc(SysEspecialidad.Columns.Nombre)
             .ExecuteAsCollection<SysEspecialidadCollection>();

            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Todas--");

            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();

            ddlProfesional.Items.Insert(0, new ListItem("Todos", "0"));

            SysZonaCollection ct1 = new SubSonic.Select()
               .From(Schemas.SysZona)
               .OrderAsc(SysZona.Columns.IdZona)
               .ExecuteAsCollection<SysZonaCollection>();
            ddlZona.DataSource = ct1;
            ddlZona.DataValueField = SysZona.Columns.IdZona;
            ddlZona.DataTextField = SysZona.Columns.Nombre;
            ddlZona.DataBind();
            ddlZona.Items.Insert(0, new ListItem("Todos", "0"));


            SysEfectorCollection ct = new SubSonic.Select()
                .From(Schemas.SysEfector)
                .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                .OrderAsc(SysEfector.Columns.Nombre)
                .ExecuteAsCollection<SysEfectorCollection>();
            ddlEfector.DataSource = ct;
            ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
            ddlEfector.DataTextField = SysEfector.Columns.Nombre;
            ddlEfector.DataBind();
            ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            gvLista.DataSource = buscarAgendas();
            gvLista.DataBind();

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector >= 4)
                pnlReporteDetallado.Visible = false;
            else
                pnlReporteDetallado.Visible = true;
        }

        private DataTable buscarAgendas()
        {
            int idZona = 0;
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            //int idTipoConsultorio = 0;
            int idTipoReporte = 4;
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;

            if (ddlZona.SelectedIndex > 0) { idZona = Convert.ToInt32(ddlZona.SelectedValue); }

            if (ddlServicios.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicios.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }

            if (ddlTipoTurno.SelectedValue == "Prestaciones") tipoAgenda = 0;

            if (ddlTipoTurno.SelectedValue == "Especialidad") tipoAgenda = 1;

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector); int idEfector = SSOHelper.CurrentIdentity.IdEfector;
            if (efector.IdTipoEfector >= 4)
            ///Consulta para nivel central
            {
                idProfesional = 0;
                idEfector = int.Parse(ddlEfector.SelectedValue);
            }

            int tipoDiagnostico = -1;
            if (ddlTipoDiagnostico.SelectedIndex > 0) tipoDiagnostico = Convert.ToInt32(ddlTipoDiagnostico.SelectedValue);

            return SPs.ConEstadisticaDiagnosticos(idZona, idEfector, idServicio, idEspecialidad, idProfesional, fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), "", tipoDiagnostico, tipoAgenda, 1).GetDataSet().Tables[0];
        }

        private DataTable buscarPacientesDiagnosticos()
        {
            int idZona = 0;
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            int idEfector = 0;
            //int idTipoConsultorio = 0;
            int idTipoReporte = 5;
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;

            if (ddlZona.SelectedIndex > 0) { idZona = Convert.ToInt32(ddlZona.SelectedValue); }

            if (ddlServicios.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicios.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }
            int tipoDiagnostico = -1;
            if (ddlTipoDiagnostico.SelectedIndex > 0) tipoDiagnostico = Convert.ToInt32(ddlTipoDiagnostico.SelectedValue);
            if (ddlTipoTurno.SelectedValue == "Prestaciones") tipoAgenda = 0;

            if (ddlTipoTurno.SelectedValue == "Especialidad") tipoAgenda = 1;

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector >= 4)
            ///Consulta para nivel central
            {
                idProfesional = 0;
                idEfector = int.Parse(ddlEfector.SelectedValue);
            }
            else
                idEfector = SSOHelper.CurrentIdentity.IdEfector;

            return SPs.ConEstadisticaDiagnosticos(idZona, idEfector, idServicio, idEspecialidad, idProfesional, fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), "", tipoDiagnostico, tipoAgenda, 2).GetDataSet().Tables[0];

            //return SPs.ConEstadisticaConsultas(us.IdEfector, idServicio, idEspecialidad, idProfesional,
            //                       fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), tipoAgenda, idTipoReporte).GetDataSet().Tables[0];
        }

        private void ImprimirPlanillaDetallada(string tipo)
        {

            string tipoReporte = "";
            string nombreReporte = "EstadisticaDiagnosticoDetallada.rpt";

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            string nombreEfector = efector.Nombre;

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = tipoReporte;

            ParameterDiscreteValue encabezado2 = new ParameterDiscreteValue();
            encabezado2.Value = "Periodo: " + txtDesde.Text + " - " + txtHasta.Text;

            ParameterDiscreteValue encabezado3 = new ParameterDiscreteValue();
            encabezado3.Value = nombreEfector;

            DataTable dt = buscarPacientesDiagnosticos();
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

        private void ImprimirPlanilla(string tipo)
        {

            string tipoReporte = "DIAGNOSTICO";
            string nombreReporte = "EstadisticaDiagnostico.rpt";

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            string nombreEfector = efector.Nombre;
            if (efector.IdTipoEfector >= 4) ///Consulta para nivel central
                nombreEfector = ddlEfector.SelectedItem.Text;

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

        protected void lnkPdf_Click(object sender, EventArgs e)
        {
            ImprimirPlanilla("PDF");
        }

        protected void lnkExcel_Click(object sender, EventArgs e)
        {
            ImprimirPlanilla("EXCEL");
        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i = 2;

            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
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

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            if (efector.IdTipoEfector >= 4)//nivel central
                Response.Redirect("../Principal.aspx", false);
            else
                Response.Redirect("PrincipalEfector.aspx", false);
        }

        protected void imgDetalladoPdf_Click(object sender, ImageClickEventArgs e)
        {
            ImprimirPlanillaDetallada("PDF");
        }

        protected void imgDetalladoExcel_Click(object sender, ImageClickEventArgs e)
        {
            ImprimirPlanillaDetallada("EXCEL");
        }

        protected void lnkPdf0_Click(object sender, EventArgs e)
        {
            ImprimirPlanillaDetallada("PDF");
        }

        protected void lnkExcel0_Click(object sender, EventArgs e)
        {
            ImprimirPlanillaDetallada("EXCEL");
        }

        protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                .OrderAsc(SysEfector.Columns.Nombre)
                .ExecuteAsCollection<SysEfectorCollection>();
                ddlEfector.DataSource = ct;
                ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
                ddlEfector.DataTextField = SysEfector.Columns.Nombre;
                ddlEfector.DataBind();
                ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));
            }
        }
    }
}
