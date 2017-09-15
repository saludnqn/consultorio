using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SIPS.ControlMenor.Visitas
{
    public partial class View : System.Web.UI.Page
    {
        public int idControl
        {
            get {int idTemp; return (Int32.TryParse(Request.QueryString["idControl"], out idTemp))? idTemp : 0;}
        }
        
        private int idPaciente
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ControlMenor/Visitas/?idPaciente=" + idPaciente.ToString());
        }
    }
}
