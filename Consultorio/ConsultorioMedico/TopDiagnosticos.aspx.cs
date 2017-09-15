using System;
using DalSic;
using SubSonic;
using System.Data;
using Salud.Security.SSO;


namespace Consultorio.ConsultorioMedico
{
    public partial class TopDiagnosticos : System.Web.UI.Page
    {

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //traigo los datos del control del Paciente               
                int efector = SSOHelper.CurrentIdentity.IdEfector;
                if (Request["idPaciente"] != null)
                {
                    int paciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
                    if (paciente > 0) mostrarDiagnosticos(paciente, efector);
                }
            }
        }

        private void mostrarDiagnosticos(int paciente, int efector)
        {
            DataTable dt = SPs.ConGetHistorialDatosControl(paciente, efector).GetDataSet().Tables[1];
            if (dt.Rows.Count > 0)
            {
                gvDiagnosticos.DataSource = dt;
            }
            gvDiagnosticos.DataBind();
        }
    }
}