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
using SubSonic;
using DalSic;

namespace SIPS.ControlMenor.Visitas.UserControls
{
    public partial class AreasDesarrollo : System.Web.UI.UserControl
    {
        // Identificador del control
        private int idControl
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idControl"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            rptAreasDesarrollo.DataSource = new Select(AprAreaDesarrollo.NombreColumn.ColumnName + " as AreaDesarrollo", "Adecuado", "Item")
                .From(AprRelControlNiñoSanoAreaDesarrollo.Schema)
                .InnerJoin(AprAreaDesarrollo.IdAreaDesarrolloColumn, AprRelControlNiñoSanoAreaDesarrollo.IdAreaDesarrolloColumn)
                .InnerJoin(AprControlNiñoSanoConsultorio.IdControlNiñoSanoConsultorioColumn, AprRelControlNiñoSanoAreaDesarrollo.IdControlNiñoSanoConsultorioColumn)
                .Where(AprControlNiñoSanoConsultorio.IdControlNiñoSanoColumn).IsEqualTo(idControl)
                .ExecuteDataSet();
            rptAreasDesarrollo.DataBind();
        }
    }
}