using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using SubSonic;
using DalSic;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.IO;
using Salud.Security.SSO;

namespace Consultorio.Turnos
{
    public partial class PacientesConTurnos : System.Web.UI.Page
    {
        public CrystalReportSource oCr = new CrystalReportSource();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;
        }

        protected void Page_Load(object sender, EventArgs e){          

            if (!IsPostBack)
            {
                    llenarCombos();                  
                    txtFecha.Text = DateTime.Now.ToString().Substring(0, 10);
                    Buscar();                                                     
            }            
        }

        private void llenarCombos()
        {
            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector,-1).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Todas--");

        
            ///Carolina: Modifico para que se muestren los profesiones del efector                        
            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();
            ddlProfesional.Items.Insert(0, "--Todos--");
        }

        protected void ddlTipoTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i_tipo = -1;

            if (ddlTipoTurno.SelectedValue == "Prestaciones") //tipo de prestacion
            {
                i_tipo = 0;

            }
            if (ddlTipoTurno.SelectedValue == "Médica") //tipo de prestacion
            {
                i_tipo = 1;
            }
          
            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, i_tipo).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Todas--");

            Buscar();

        }
        protected void cmdFecha_Click(object sender, ImageClickEventArgs e)
        {
            txtFecha.Focus();
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            gvPacientes.DataSource = MostrarPacientes();
            gvPacientes.DataBind();
            
        }

        private DataSet MostrarPacientesHCEfector()
        {                
            int idtipoAgenda = -1;
            int idEspecialidad = 0;
            int idProfesional = 0;
            if (ddlTipoTurno.SelectedValue == "Médica") idtipoAgenda = 1;
            if (ddlTipoTurno.SelectedValue == "Prestaciones") idtipoAgenda = 0;
            if (ddlEspecialidad.SelectedIndex != 0) idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            if (ddlProfesional.SelectedIndex != 0) idProfesional = int.Parse(ddlProfesional.SelectedValue);

//            DateTime fecha = DateTime.Parse(txtFecha.Text);
            DataSet ds = SPs.ConGetTurnosPorDia("", SSOHelper.CurrentIdentity.IdEfector, idtipoAgenda, idEspecialidad, idProfesional, -1).GetDataSet();
            return ds;
            //llamar al store [CONGetTurnosPacientes]
        }


        private DataSet MostrarPacientes()
        {
            int idtipoAgenda = -1;
            int idEspecialidad = 0;
            int idProfesional = 0;
            if (ddlTipoTurno.SelectedValue == "Médica") idtipoAgenda = 1;
            if (ddlTipoTurno.SelectedValue == "Prestaciones") idtipoAgenda = 0;
            if (ddlEspecialidad.SelectedIndex != 0) idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            if (ddlProfesional.SelectedIndex != 0) idProfesional = int.Parse(ddlProfesional.SelectedValue);

                        DateTime fecha = DateTime.Parse(txtFecha.Text);

                        DataSet ds = SPs.ConGetTurnosPorDia(fecha.ToString("yyyyMMdd"), SSOHelper.CurrentIdentity.IdEfector, idtipoAgenda, idEspecialidad, idProfesional,-1).GetDataSet();
            return ds;
            //llamar al store [CONGetTurnosPacientes]
        }

        protected void lnkExportarPdf_Click(object sender, EventArgs e)
        {
            Exportar();
        }


        private void Exportar()
        {
            //Aca se deberá consultar los parametros para mostrar una hoja de trabajo u otra
            //this.CrystalReportSource1.Report.FileName = "HTrabajo2.rpt";
            string informe = "../Informes/PacientesTurno.rpt";
            
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = efector.Nombre;


            ParameterDiscreteValue fecha1= new ParameterDiscreteValue();
            fecha1.Value = txtFecha.Text.ToString();

            DataTable dt = MostrarPacientes().Tables[0];

            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);
            oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);
            oCr.ReportDocument.ParameterFields[1].CurrentValues.Add(fecha1);

            oCr.DataBind();

            MemoryStream oStream; // using System.IO
            oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=PacientesTurno.pdf");

            Response.BinaryWrite(oStream.ToArray());
            Response.End();

        }

        private void ExportarHistorias(string tipo)
        {
            //Aca se deberá consultar los parametros para mostrar una hoja de trabajo u otra
            //this.CrystalReportSource1.Report.FileName = "HTrabajo2.rpt";
            string informe = "../Informes/HistoriasClinicas.rpt";
            
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = efector.Nombre;


            ParameterDiscreteValue fecha1 = new ParameterDiscreteValue();
            fecha1.Value = txtFecha.Text.ToString();

            DataTable dt = MostrarPacientesHCEfector().Tables[0];

            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);
            oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);
     //       oCr.ReportDocument.ParameterFields[1].CurrentValues.Add(fecha1);

            oCr.DataBind();
            MemoryStream oStream;
            if (tipo == "PDF")
            {
                oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=HistoriasClinicas.pdf");
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
            }
            if (tipo == "EXCEL")
            {
                oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=HistoriasClinicas.xls");
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
            }

        }
        protected void lnkDescargarArchivoHC_Click(object sender, EventArgs e)
        {
            ExportarHistorias("PDF");

        }

        protected void lnlDescargarArchivoHCExcel_Click(object sender, EventArgs e)
        {
            ExportarHistorias("EXCEL");
        }
    }
}
