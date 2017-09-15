using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalSic;
using System.Text;

namespace UserControls
{
    public partial class AlertaCM : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            LoadAlertas();
        }

        private void LoadAlertas()
        {
            DataTable d = SPs.AprGetAlertaCM().GetDataSet().Tables[0];
            if (d.Rows.Count > 0)
            {
                rptAlertas.DataSource = d;
                rptAlertas.DataBind();
                //gvMenores.DataSource = d;
                //gvMenores.DataBind();
            }
        }
    }
}