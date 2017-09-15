using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using SubSonic;

namespace UserControls
{
    public partial class AlertasControlMenor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        public void SetAlertas(int idCalendarioVisitas)
        {
            AprAlertaControlMenorCollection oAlertas = new Select()
            .From(Schemas.AprAlertaControlMenor)
            .Where(AprAlertaControlMenor.Columns.IdCalendarioVisitas)
            .IsEqualTo(idCalendarioVisitas)
            .ExecuteAsCollection<AprAlertaControlMenorCollection>();

            rptAlertas.DataSource = oAlertas;
            rptAlertas.DataBind();
        }
    }
}