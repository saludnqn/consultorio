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
    public partial class FactoresProtectores : System.Web.UI.UserControl
    {
        // Identificador del control
        private int idControl
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idControl"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            rptFactoresProtectores.DataSource = new Select(AprFactorProtector.NombreColumn.ColumnName + " as FactorProtector")
                .From(AprRelControNiñoSanoFactorProtector.Schema)
                .InnerJoin(AprControlNiñoSanoConsultorio.IdControlNiñoSanoConsultorioColumn, AprRelControNiñoSanoFactorProtector.IdControlNiñoSanoConsultorioColumn)
                .InnerJoin(AprFactorProtector.IdFactorProtectorColumn, AprRelControNiñoSanoFactorProtector.IdFactorProtectorColumn)
                .Where(AprControlNiñoSanoConsultorio.IdControlNiñoSanoColumn).IsEqualTo(idControl)
                .ExecuteDataSet();
            rptFactoresProtectores.DataBind();
        }
    }
}