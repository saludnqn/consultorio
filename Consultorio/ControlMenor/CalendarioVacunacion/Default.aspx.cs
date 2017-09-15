using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DalSic;
using SIPS.Utilidades;

namespace SIPS.ControlMenor.CalendarioVacunacion
{
    public partial class Default : System.Web.UI.Page
    {
        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            int idTemp;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp))
            {
                idPaciente = idTemp;
                
                //rptVacunaciones.DataSource = new AprAplicacionVacunaCollection().Where(AprAplicacionVacuna.Columns.IdPaciente, idTemp).
                //OrderByDesc(AprAplicacionVacuna.Columns.FechaAplicacion).Load();
                
                //calcular la edad en la fecha de vacunacion y el estado (que dira si fue puesta a tiempo o no)
                rptVacunaciones.DataSource = SPs.AprGetVacunas(idTemp).GetDataSet();
                rptVacunaciones.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("Edit.aspx?idPaciente={0}", idPaciente));
        }
    }
}