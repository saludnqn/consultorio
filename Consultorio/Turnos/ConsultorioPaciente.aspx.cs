using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using Consultorio.Utilidades;
using SubSonic;
using Salud.Security.SSO;
using System.Text;
using CrystalDecisions.Web;
using System.IO;

namespace Consultorio.Turnos
{

  
    public partial class ConsultorioPaciente : System.Web.UI.Page
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
            if (!IsPostBack)
            {                                     

                if (Request["idPaciente"] != null)
                {
                    int idPaciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
                    if (idPaciente > 0) mostrarHistorial(idPaciente);
                }
            }
        }            

      
        private void mostrarHistorial(int idPaciente)
        {      
        
            pnlDiagnostico.Visible = true;
            SysPaciente t = new SysPaciente(idPaciente);
            lblPaciente.Text = t.NumeroDocumento.ToString() + " " + t.Apellido + " " + t.Nombre;
            lblFechaNacimiento.Text = "Fecha de Nacimiento: " + t.FechaNacimiento.ToShortDateString();

            DateDifference oEdad = new DateDifference(t.FechaNacimiento, DateTime.Now);
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
            lblIdPaciente.Text =idPaciente.ToString();

            gvHistorial.DataSource = SPs.ConGetTurnosPacientes(DateTime.Now.ToString("yyyyMMdd"), t.IdPaciente, 1).GetDataSet();
            gvHistorial.DataBind();          
        }               
      

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
          
        }

        protected void cvDiagnostico_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ////verificar que DiagnosticoPrincipal1.getDiagnostico()<>"-1"
            //if (DiagnosticoPrincipal1.getDiagnostico() == -1)
            //    args.IsValid = false;
            //else
            //    args.IsValid = true;
            //return;

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirHistorial();

        }

        private void ImprimirHistorial()
        {        
            string informe = "../Informes/ConsultorioPaciente.rpt";
            string nombreArchivo = lblPaciente.Text.Trim();

            DataTable dt =  SPs.ConGetTurnosPacientes(DateTime.Now.ToString("yyyyMMdd"), int.Parse(lblIdPaciente.Text) , 1).GetDataSet().Tables[0];
            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);         
            oCr.DataBind();

            MemoryStream oStream; 
            oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename="+nombreArchivo+".pdf");

            Response.BinaryWrite(oStream.ToArray());
            Response.End();
        }
    }
}
