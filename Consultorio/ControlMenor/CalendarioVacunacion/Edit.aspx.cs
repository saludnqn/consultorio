using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using SIPS.Utilidades;
using Salud.Security.SSO;

namespace SIPS.ControlMenor.CalendarioVacunacion
{
    public partial class Edit : System.Web.UI.Page
    {
        private int idAplicacionVacuna
        {
            get { return ViewState["idAplicacionVacuna"] == null ? 0 : Convert.ToInt32(ViewState["idAplicacionVacuna"]); }
            set { ViewState["idAplicacionVacuna"] = value; }
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
            txtFechaAplicacion.Text = DateTime.Today.ToShortDateString();
            int idPacienteTemp, idAplicacionVacunaTemp;
            CargarDosis();
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPacienteTemp))
            {
                idPaciente = idPacienteTemp;
                setPermitirGuardar(idPacienteTemp);

            }
            if (Int32.TryParse(Request.QueryString["id"], out idAplicacionVacunaTemp))
            {
                idAplicacionVacuna = idAplicacionVacunaTemp;
                LoadAplicacionVacuna(idAplicacionVacunaTemp);
            }
        }

        private void CargarDosis()
        {
            SubSonic.Select d = new SubSonic.Select();
            d.From(AprNumeroDosi.Schema);
            ddlDosis.DataSource = d.ExecuteTypedList<AprNumeroDosi>();
            ddlDosis.DataBind();
            ddlDosis.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
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

        private void LoadAplicacionVacuna(int id)
        {
            AprAplicacionVacuna oAplicacionVacuna = new AprAplicacionVacuna(id);
            if (oAplicacionVacuna.IsNew) { Master.Message("No se encuentra el objeto a editar.", MessageStatus.alert); return; }

            txtFechaAplicacion.Text = oAplicacionVacuna.FechaAplicacion.ToShortDateString();
            Medicamento1.setMedicamento(oAplicacionVacuna.IdVacuna);
            txtObservacion.Text = oAplicacionVacuna.Observacion;
            ddlDosis.SelectedValue = oAplicacionVacuna.IdNumeroDosis.ToString();

            if (oAplicacionVacuna.Baja.HasValue)
            {
                ckbBaja.Checked = oAplicacionVacuna.Baja.Value;
            }

            setPermitirGuardar(oAplicacionVacuna.IdPaciente);
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
            DateTime fechaAplicacion;
            int idVacuna;
            if (DateTime.TryParse(txtFechaAplicacion.Text, out fechaAplicacion) &&
                Int32.TryParse(Medicamento1.getMedicamento(), out idVacuna))
            {
                AprAplicacionVacuna oAplicacionVacuna = new AprAplicacionVacuna(idAplicacionVacuna);

                oAplicacionVacuna.IdPaciente = idPaciente;
                oAplicacionVacuna.Observacion = txtObservacion.Text;
                oAplicacionVacuna.FechaAplicacion = fechaAplicacion;
                oAplicacionVacuna.IdVacuna = idVacuna;
                oAplicacionVacuna.IdNumeroDosis = Convert.ToInt32(ddlDosis.SelectedValue);
                oAplicacionVacuna.Baja = ckbBaja.Checked;

                try
                {                   
                    oAplicacionVacuna.Save(SSOHelper.CurrentIdentity.Username);
                    Response.Redirect(string.Format("Default.aspx?idPaciente={0}", oAplicacionVacuna.IdPaciente));
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