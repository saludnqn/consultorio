using System;
using System.Data;
using DalSic;
using Salud.Security.SSO;

namespace ConsultaAmbulatoria.Alertas
{
    public partial class ControlPerinatal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //aca llamo al store de muestra los alertas si los hubiese
            DataTable d = SPs.AprGetAlertaCP(SSOHelper.CurrentIdentity.IdEfector).GetDataSet().Tables[0];
            if (d.Rows.Count > 0)
            {
                gvPacientes.DataSource = d;
                gvPacientes.DataBind();
            }
        }
    }
}
