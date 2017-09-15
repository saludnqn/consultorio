using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using SIPS.Utilidades;
using Salud.Security.SSO;

namespace SIPS.ControlMenor.ResProblemas
{
    public partial class Edit : System.Web.UI.Page
    {
        private int idProblemaMenor
        {
            get { return ViewState["idProblemaMenor"] == null ? 0 : Convert.ToInt32(ViewState["idProblemaMenor"]); }
            set { ViewState["idProblemaMenor"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        private bool PermitirGuardar
        {
            get { return ViewState["permitirGuardar"] == null ? false : Convert.ToBoolean(ViewState["permitirGuardar"]); }
            set { ViewState["permitirGuardar"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            txtFecha.Text = DateTime.Today.ToShortDateString();
            int idPacienteTemp, idProblemaTemp;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPacienteTemp))
            {
                idPaciente = idPacienteTemp;
                setPermitirGuardar(idPacienteTemp);
            }
            if (Int32.TryParse(Request.QueryString["id"], out idProblemaTemp))
            {
                idProblemaMenor = idProblemaTemp;
                LoadProblema(idProblemaTemp);
            }
        }

        private void setPermitirGuardar(int idPaciente)
        {
            SysPaciente oPaciente = new SysPaciente(idPaciente);
            if (oPaciente != null)
            {
                DateDifference oDateDifference = new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                PermitirGuardar = oDateDifference.Years <= 6;
            }
        }

        private void LoadProblema(int id)
        {
            AprProblemasMenor oProblema = new AprProblemasMenor(id);
            if (oProblema.IsNew) { Master.Message("No se encuentra el objeto a editar.", MessageStatus.alert); return; }

            txtFecha.Text = oProblema.Fecha.HasValue ? oProblema.Fecha.Value.ToShortDateString() : "S/D";
            txtDescripcion.Text = oProblema.Descripcion;
            DiagnosticoPrincipal1.setDiagnosticoPrincipal(oProblema.CODCIE10.HasValue ? oProblema.CODCIE10.Value : 0);
            txtIntervencion.Text = oProblema.Intervencion;

            setPermitirGuardar(oProblema.IdPaciente);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Default.aspx?idPaciente={0}", idPaciente));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!PermitirGuardar)
            {
                Master.Message("No se pueden Modificar los datos del paciente, el mismo es mayor de 6 años.", MessageStatus.alert);
                return;
            }

            DateTime fecha;
            if (DateTime.TryParse(txtFecha.Text, out fecha))
            {
                AprProblemasMenor oProblema = new AprProblemasMenor(idProblemaMenor);

                oProblema.IdPaciente = idPaciente;
                oProblema.Fecha = fecha;
                oProblema.Descripcion = txtDescripcion.Text;
                oProblema.Intervencion = txtIntervencion.Text;
                if (DiagnosticoPrincipal1.getDiagnostico() > 0)
                    oProblema.CODCIE10 = DiagnosticoPrincipal1.getDiagnostico();

                try
                {                    
                    oProblema.Save(SSOHelper.CurrentIdentity.Username);
                    Response.Redirect(string.Format("Default.aspx?idPaciente={0}", oProblema.IdPaciente));
                }
                catch (Exception Ex)
                {
                    string exception = "";
                    while (Ex != null)
                    {
                        exception = Ex.Message + "<br>";
                        Ex = Ex.InnerException;
                    }
                    Master.Message(exception, MessageStatus.error);
                }
            }
            else
            {
                Master.Message("Los datos en el formulario son incorrectos", MessageStatus.error);
            }
        }
    }
}
