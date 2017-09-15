using System;
using DalSic;


namespace ConsultaAmbulatoria.ControlPerinatal.Alerta
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
            }
            if (idHistoriaClinicaPerinatal > 0) GetAlerta(idHistoriaClinicaPerinatal);
            else return;
        }

        private void GetAlerta(int idHistoriaClinicaPerinatal)
        {
            //aca llamo al store de muestra los alertas del registro del SIP si los hubiese
            gvAlertas.DataSource = SPs.AprAlertaCtrolPerinatal(idHistoriaClinicaPerinatal).GetDataSet();
            gvAlertas.DataBind();
        }
    }
}
