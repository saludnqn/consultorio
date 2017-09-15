using System;
using DalSic;

namespace ConsultaAmbulatoria.ControlPerinatal.Interconsultas
{
    public partial class Default : System.Web.UI.Page
    {
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
            int idTemp;
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idTemp))
            {
                idHistoriaClinicaPerinatal = idTemp;

                AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal(idHistoriaClinicaPerinatal);
                if (!oHCP.Activa)
                {
                    btnNuevo.Enabled = false;
                }

                rptInterconsultas.DataSource = new AprInterconsultumCollection().Where(AprInterconsultum.Columns.IdHistoriaClinicaPerinatal, idTemp).
                    OrderByDesc(AprInterconsultum.Columns.Fecha).Load();
                rptInterconsultas.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("Edit.aspx?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal));
        }
    }
}