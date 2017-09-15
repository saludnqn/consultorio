using System;
using DalSic;
using Salud.Security.SSO;
using System.Data;


namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.Actividades
{
    public partial class Edit : System.Web.UI.Page
    {

        private int idActividadControlPerinatal
        {
            get { return ViewState["idActividadControlPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idActividadControlPerinatal"]); }
            set { ViewState["idActividadControlPerinatal"] = value; }
        }
        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            txtFecha.Text = DateTime.Today.ToShortDateString();
            int idHCPTemp, idInterconsultaTemp;

            getProfesionales(SSOHelper.CurrentIdentity.IdEfector);
            getTiposActividades();
            getActividades();
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHCPTemp))
            {
                idHistoriaClinicaPerinatal = idHCPTemp;
            }
            if (Int32.TryParse(Request.QueryString["id"], out idInterconsultaTemp))
            {
                idActividadControlPerinatal = idInterconsultaTemp;
                LoadActividadControlPerinatal(idInterconsultaTemp);
            }
        }

        private void getTiposActividades()
        {
            ddlTipoActividad.DataSource = new AprTipoActividadEmbarazoCollection().OrderByAsc(AprTipoActividadEmbarazo.Columns.Nombre).Load();
            ddlTipoActividad.DataTextField = AprTipoActividadEmbarazo.Columns.Nombre;
            ddlTipoActividad.DataValueField = AprTipoActividadEmbarazo.Columns.IdTipoActividadEmbarazo;
            ddlTipoActividad.DataBind();
        }

        private void getActividades()
        {
            ddlActividad.DataSource = new AprActividadEmbarazoCollection().
                Where(AprActividadEmbarazo.Columns.IdTipoActividadEmbarazo, ddlTipoActividad.SelectedValue).OrderByAsc(AprTipoActividadEmbarazo.Columns.Nombre).Load();
            ddlActividad.DataTextField = AprActividadEmbarazo.Columns.Nombre;
            ddlActividad.DataValueField = AprActividadEmbarazo.Columns.IdActividadEmbarazo;
            ddlActividad.DataBind();
        }

        private void getProfesionales(int idEfector)
        {
            //Obtengo los medicos de acuerdo al Efector del usuario logueado
            DataTable dt = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet().Tables[0];
            ddlProfesional.DataSource = dt;
            ddlProfesional.DataBind();
        }

        private void LoadActividadControlPerinatal(int id)
        {
            AprActividadControlPerinatal oActividad = new AprActividadControlPerinatal(id);
            if (oActividad.IsNew) { Master.Message("No se encuentra el objeto a editar.", MessageStatus.alert); return; }

            txtFecha.Text = oActividad.Fecha.HasValue ? oActividad.Fecha.Value.ToShortDateString() : "";
            ddlTipoActividad.SelectedValue = oActividad.AprActividadEmbarazo.IdTipoActividadEmbarazo.ToString();
            getActividades();
            ddlActividad.SelectedValue = oActividad.IdActividadEmbarazo.ToString();
            txtMotivo.Text = oActividad.Motivo;
            ddlProfesional.SelectedValue = oActividad.IdProfesional.ToString();
            txtDescripcion.Text = oActividad.Descripcion;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Default.aspx?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            int idProfesional, idActividadEmbarazo;
            if (DateTime.TryParse(txtFecha.Text, out fecha) && Int32.TryParse(ddlProfesional.SelectedValue, out idProfesional) &&
                Int32.TryParse(ddlActividad.SelectedValue, out idActividadEmbarazo) &&
                txtMotivo.Text.Length > 0)
            {
               
                
                AprActividadControlPerinatal oActividadControlPerinatal = new AprActividadControlPerinatal(idActividadControlPerinatal);

                oActividadControlPerinatal.IdHistoriaClinicaPerinatal = idHistoriaClinicaPerinatal;
                oActividadControlPerinatal.IdActividadEmbarazo = idActividadEmbarazo;
                oActividadControlPerinatal.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                oActividadControlPerinatal.Motivo = txtMotivo.Text;
                oActividadControlPerinatal.Descripcion = txtDescripcion.Text;
                oActividadControlPerinatal.Fecha = fecha;
                oActividadControlPerinatal.IdProfesional = idProfesional;

                try
                {
                    oActividadControlPerinatal.Save(SSOHelper.CurrentIdentity.Username);
                    Response.Redirect(string.Format("Default.aspx?IdHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal));
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

        protected void ddlTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            getActividades();
        }
    }
}