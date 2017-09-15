using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsultaAmbulatoria.UserControls
{
    public partial class Medicamento : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getMedicamentos()
        {
            return idMedicamentos.Value;
        }
    }
}