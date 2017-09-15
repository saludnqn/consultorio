using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace SIPS.ControlMenor.PanelControl
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ddlEfector.DataSource = new SysEfectorCollection().Load();
            ddlEfector.DataTextField = SysEfector.Columns.Nombre;
            ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
            ddlEfector.DataBind();

            ddlEfector.Items.Insert(0, Utilidades.Utils.getEmptyListItem());

            txtFInicio.Text = "01/01/2011";
            txtFFin.Text = DateTime.Now.ToShortDateString();

            setearEfector();
        }

        protected void setearEfector()
        {
            int idEfector;
            DateTime? finicio = null;
            DateTime? ffin = null;
            DateTime inicio;
            DateTime fin;
            if (DateTime.TryParse(txtFInicio.Text, out inicio))
                finicio = inicio;
            if (DateTime.TryParse(txtFFin.Text, out fin))
                ffin = fin;
            if (Int32.TryParse(ddlEfector.SelectedValue, out idEfector))
            {
                foreach (Control oControl in tabs.Controls)
                {
                    InformacionPorEdad otemp = oControl as InformacionPorEdad;
                    if (otemp != null)
                    {
                        otemp.idEfector = idEfector;
                    }
                }
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            setearEfector();
        }
    }
}
