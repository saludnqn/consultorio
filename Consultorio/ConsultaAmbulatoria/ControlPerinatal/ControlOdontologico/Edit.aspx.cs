using System;
using DalSic;
using Salud.Security.SSO;
using System.Data;


namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.ControlOdontologico
{
    public partial class Edit : System.Web.UI.Page
    {
        private int idControlOdontologico
        {
            get { return ViewState["idControlOdontologico"] == null ? 0 : Convert.ToInt32(ViewState["idControlOdontologico"]); }
            set { ViewState["idControlOdontologico"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            txtFecha.Text = DateTime.Today.ToShortDateString();
            int idHistoriaClinicaPerinatalTemp, idInterconsultaTemp;
            getProfesionales(SSOHelper.CurrentIdentity.IdEfector);
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHistoriaClinicaPerinatalTemp))
            {
                idHistoriaClinicaPerinatal = idHistoriaClinicaPerinatalTemp;
            }
            if (Int32.TryParse(Request.QueryString["id"], out idInterconsultaTemp))
            {
                idControlOdontologico = idInterconsultaTemp;
                LoadControlOdontologico(idInterconsultaTemp);
            }
        }

        private void getProfesionales(int idEfector)
        {
            //Obtengo los medicos de acuerdo al Efector del usuario logueado
            DataTable dt = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet().Tables[0];
            ddlProfesional.DataSource = dt;
            ddlProfesional.DataBind();
        }

        private void LoadControlOdontologico(int id)
        {
            AprControlOdontologico oControlOdontologico = new AprControlOdontologico(id);
            if (oControlOdontologico.IsNew) { Master.Message("No se encuentra el objeto a editar.", MessageStatus.alert); return; }

            txtFecha.Text = oControlOdontologico.Fecha.HasValue ? oControlOdontologico.Fecha.Value.ToShortDateString() : "";
            txtMotivo.Text = oControlOdontologico.Motivo;
            ddlProfesional.SelectedValue = oControlOdontologico.IdProfesional.ToString();
            txtDescripcion.Text = oControlOdontologico.Descripcion;
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Default.aspx?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            int idProfesional;
            if (DateTime.TryParse(txtFecha.Text, out fecha) && Int32.TryParse(ddlProfesional.SelectedValue, out idProfesional) &&
                txtMotivo.Text.Length > 0)
            {
                AprControlOdontologico oControlOdontologico = new AprControlOdontologico(idControlOdontologico);

                oControlOdontologico.IdHistoriaClinicaPerinatal = idHistoriaClinicaPerinatal;
                oControlOdontologico.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                oControlOdontologico.Motivo = txtMotivo.Text;
                oControlOdontologico.Descripcion = txtDescripcion.Text;
                oControlOdontologico.Fecha = fecha;
                oControlOdontologico.IdProfesional = idProfesional;

                try
                {
                    oControlOdontologico.Save(SSOHelper.CurrentIdentity.Username);
                    Response.Redirect(string.Format("Default.aspx?idHistoriaClinicaPerinatal={0}", oControlOdontologico.IdHistoriaClinicaPerinatal));
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