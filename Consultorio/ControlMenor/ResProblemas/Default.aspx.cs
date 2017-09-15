using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace SIPS.ControlMenor.ResProblemas
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

                rptProblemas.DataSource = new AprProblemasMenorCollection().Where(AprProblemasMenor.Columns.IdPaciente, idTemp).
                    OrderByDesc(AprProblemasMenor.Columns.Fecha).Load();
                rptProblemas.DataBind();
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("Edit.aspx?idPaciente={0}", idPaciente));
        }
    }
}
