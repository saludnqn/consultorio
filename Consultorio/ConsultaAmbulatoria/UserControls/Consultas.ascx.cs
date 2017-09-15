using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Data;
using Consultorio.Utilidades;
using SubSonic;
using ConsultaAmbulatoria.UserControls;

namespace ConsultaAmbulatoria.UserControls {
    public partial class Consultas : System.Web.UI.UserControl {
        public int idPaciente {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        public int idConsulta {
            get { return ViewState["idConsulta"] == null ? 0 : Convert.ToInt32(ViewState["idConsulta"]); }
            set { ViewState["idConsulta"] = value; }
        }

        public string returnUrl {
            get { return ViewState["returnUrl"] == null ? "" : (string)ViewState["returnUrl"]; }
            set { ViewState["returnUrl"] = value; }
        }

        //private bool error = false;

       protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) return;

            // En caso que no sea un postback, guardamos la url de retorno
            returnUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();

            // En caso que no haya una Url de retorno, no habilitamos el botón cancelar
            //btnCancelar.Enabled = !String.IsNullOrEmpty(returnUrl);

            txtFechaI.Text = "01/01/2011";
            txtFechaF.Text = DateTime.Now.ToShortDateString();
            getEspecialidades();
            getTipoProfesional();
        }

        private void getTipoProfesional() {
            //Obtengo los tipo de profesionales para listar todos los diponibles
            ddlTipoProfesional.DataSource = new SysTipoProfesionalCollection().Load();
            ddlTipoProfesional.DataTextField = SysTipoProfesional.Columns.Nombre;
            ddlTipoProfesional.DataValueField = SysTipoProfesional.Columns.IdTipoProfesional;
            ddlTipoProfesional.DataBind();
            ddlTipoProfesional.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        private void getEspecialidades() {
            //Obtengo las especialidades
            ddlEspecialidad.DataSource = new SysEspecialidadCollection().Load();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        protected void ddlTipoProfesional_SelectedIndexChanged(object sender, EventArgs e) {
            DateTime? fechainicio = null;
            DateTime? fechafin = null;

            DateTime inicio;
            DateTime fin;
            if (DateTime.TryParse(txtFechaI.Text, out inicio))
                fechainicio = inicio;
            if (DateTime.TryParse(txtFechaF.Text, out fin))
                fechafin = fin;

            int especialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            int tipoprof = Convert.ToInt32(ddlTipoProfesional.SelectedValue);

            SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
            if (oUsuario.IsNew) return;
            int efector = oUsuario.IdEfector;

            DataSet c = SPs.ConGetConsultasByEfector(efector, fechainicio, fechafin, especialidad, tipoprof).GetDataSet();
            gvConsultas.DataSource = c;
            gvConsultas.DataBind();
        }

    }
}
