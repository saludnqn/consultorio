using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using DalSic;
using SubSonic;
using Salud.Security.SSO;

namespace Consultorio.Abm {
    public partial class AbmConsultorios : System.Web.UI.Page {

        private DataTable dtGrilla {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {
           
                if (!IsPostBack) {
                    llenarCombos();
                }
           
        }

        private void llenarCombos() {
            ConConsultorioTipoCollection tc = new Select().From(Schemas.ConConsultorioTipo)
                            .Where(ConConsultorioTipo.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
                            .OrderAsc(ConConsultorioTipo.Columns.Nombre)
                            .ExecuteAsCollection<ConConsultorioTipoCollection>();
            ddlTipoConsultorio.DataSource = tc;
            ddlTipoConsultorio.DataTextField = ConConsultorioTipo.Columns.Nombre;
            ddlTipoConsultorio.DataValueField = ConConsultorioTipo.Columns.IdTipoConsultorio;
            ddlTipoConsultorio.DataBind();

            if (ddlTipoConsultorio.SelectedIndex > -1) {
                int idTipoConsultorio = Convert.ToInt32(ddlTipoConsultorio.SelectedValue);
                actualizarConsultorios(idTipoConsultorio);
            }
        }

        protected void ddlTipoConsultorio_SelectedIndexChanged(object sender, EventArgs e) {
            int idTipoConsultorio = Convert.ToInt32(ddlTipoConsultorio.SelectedValue);
            actualizarConsultorios(idTipoConsultorio);
        }

        private void actualizarConsultorios(int idTipoConsultorio) {
            gvConsultorios.DataSource = new Select().From(Schemas.ConConsultorio)
                                        .Where(ConConsultorioTipo.Columns.IdTipoConsultorio)
                                        .IsEqualTo(idTipoConsultorio)
                                        .OrderAsc(ConConsultorio.Columns.Nombre)
                                        .ExecuteDataSet().Tables[0];
            gvConsultorios.DataBind();
            cmdEliminar.Enabled = (gvConsultorios.Rows.Count > 0) ? false : true;
            cmdEliminar.ToolTip = (cmdEliminar.Enabled) ? "Eliminar tipo de consultorios" : "Imposible eliminar. Mueva antes los consultorios a otro tipo";
        }

        protected void cmdNuevoTipo_Click(object sender, EventArgs e) {  
            mPopupMsg.Show();
            UpdatePanel1.Update();
        }
    }
}

