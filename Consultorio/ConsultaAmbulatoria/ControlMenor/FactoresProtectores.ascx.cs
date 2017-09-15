using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public class ResultadoFactorProtector
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public AprRelControNiñoSanoFactorProtectorCollection factoresprotectores = new AprRelControNiñoSanoFactorProtectorCollection();
    }
    public partial class FactoresProtectores : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LoadFactoresProtectores();
        }

        private void LoadFactoresProtectores()
        {
            rptFactoresProtectores.DataSource = new AprFactorProtectorCollection().Load();
            rptFactoresProtectores.DataBind();
        }

        public ResultadoFactorProtector getDatos()
        {
            ResultadoFactorProtector oResultado = new ResultadoFactorProtector();

            foreach (RepeaterItem oRow in rptFactoresProtectores.Items)
            {
                CheckBox cbFactorProtector = oRow.FindControl("cbFactorProtector") as CheckBox;
                HiddenField hfFactorProtectorId = oRow.FindControl("hfFactorProtectorId") as HiddenField;
                int idFactorProtector;
                if (hfFactorProtectorId != null && Int32.TryParse(hfFactorProtectorId.Value, out idFactorProtector)
                    && cbFactorProtector != null)
                {
                    if (cbFactorProtector.Checked)
                    {
                        AprRelControNiñoSanoFactorProtector oFactorProtector = new AprRelControNiñoSanoFactorProtector();
                        oFactorProtector.IdFactorProtector = idFactorProtector;

                        oResultado.factoresprotectores.Add(oFactorProtector);
                    }
                }

            }

            return oResultado;
        }
    }
}