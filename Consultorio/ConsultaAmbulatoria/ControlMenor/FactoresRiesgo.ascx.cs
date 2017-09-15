using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public class ResultadoFactorRiesgo
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public AprRelControlNiñoSanoFactorRiesgoCollection factoresriesgo = new AprRelControlNiñoSanoFactorRiesgoCollection();
    }
    public partial class FactoresRiesgo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LoadFactoresRiesgo();
        }

        private void LoadFactoresRiesgo()
        {
            rptFactoresRiesgo.DataSource = new AprFactorRiesgoCollection().Load();
            rptFactoresRiesgo.DataBind();
        }

        public ResultadoFactorRiesgo getDatos()
        {
            ResultadoFactorRiesgo oResultado = new ResultadoFactorRiesgo();

            foreach (RepeaterItem fila in rptFactoresRiesgo.Items)
            {
                CheckBox cbFactor = fila.FindControl("cbFactor") as CheckBox;
                HiddenField hfFactorRiesgoId = fila.FindControl("hfFactorRiesgoId") as HiddenField;
                int idFactor;
                if (cbFactor != null && hfFactorRiesgoId != null
                    && cbFactor.Checked && Int32.TryParse(hfFactorRiesgoId.Value, out idFactor))
                {
                    AprRelControlNiñoSanoFactorRiesgo oFactor = new AprRelControlNiñoSanoFactorRiesgo();
                    oFactor.IdFactorRiesgo = idFactor;
                    oResultado.factoresriesgo.Add(oFactor);
                }
            }

            return oResultado;
        }
    }
}