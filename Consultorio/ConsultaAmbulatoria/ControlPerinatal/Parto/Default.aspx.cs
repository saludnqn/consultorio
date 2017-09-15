using System;
using DalSic;

namespace ConsultaAmbulatoria.ControlPerinatal.Parto
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
            int idHistoriaClinicaPerinatalTemp;
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHistoriaClinicaPerinatalTemp))
            {
                idHistoriaClinicaPerinatal = idHistoriaClinicaPerinatalTemp;

                AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal(idHistoriaClinicaPerinatal);
                if (!oHCP.Activa)
                {
                    btnNuevo.Enabled = false;
                }

                rptPartos.DataSource = new AprPartoProvisorioCollection().Where(AprPartoProvisorio.Columns.IdHistoriaClinicaPerinatal, idHistoriaClinicaPerinatalTemp).
                    OrderByDesc(AprPartoProvisorio.Columns.FechaNacimiento).Load();
                rptPartos.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("Edit.aspx?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal));
        }
    }
}