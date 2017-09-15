using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Data;

namespace ConsultaAmbulatoria.Alertas
{
    public partial class DatosAlertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPaciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
                if (idPaciente > 0)
                {
                    DataTable d = SPs.AprAlertaCtrolPerinatal(idPaciente).GetDataSet().Tables[0];
                    if (d.Rows.Count > 0)
                    {
                        gvSIP.DataSource = d;
                        gvSIP.DataBind();
                    }
                }
            }
        }
    }
}
