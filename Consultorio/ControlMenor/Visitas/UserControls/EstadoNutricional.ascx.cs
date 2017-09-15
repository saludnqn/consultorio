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
using DalSic;
using SubSonic;

namespace SIC.ControlMenor.Visitas.UserControls
{
    public partial class EstadoNutricional : System.Web.UI.UserControl
    {
        // Identificador del control
        private int idControl
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idControl"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AprControlNiñoSanoConsultorio oControl = new Select()
                .From(AprControlNiñoSanoConsultorio.Schema)
                .Where(AprControlNiñoSanoConsultorio.IdControlNiñoSanoColumn).IsEqualTo(idControl)
                .ExecuteSingle<AprControlNiñoSanoConsultorio>();

            if (oControl != null)
            {
                if (oControl.IdTipoLactancia != null)
                {
                    ltTipoLactancia.Text = oControl.AprTipoLactancium.Nombre;
                }
                if (oControl.IdIntervencion != null)
                {
                    ltIntervencion.Text = oControl.AprIntervencion.Nombre;
                }
            }
        }
    }
}