using System;
using DalSic;
using SubSonic;
using System.Data;
using Salud.Security.SSO;


namespace Consultorio.ConsultorioMedico
{
    public partial class DatosControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //traigo los datos del control del Paciente               
                int efector = SSOHelper.CurrentIdentity.IdEfector;
                if (Request["idPaciente"] != null)
                {
                    int paciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
                    if (paciente > 0) mostrarDatos(paciente, efector);
                }
            }
        }

        private void mostrarDatos(int paciente, int efector)
        {
            DataTable dt = SPs.ConGetHistorialDatosControl(paciente, efector).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                gvDatos.DataSource = dt;
            }
            gvDatos.DataBind();
        }
    }
}