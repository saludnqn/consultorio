using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Data;

namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.Estado
{
    public partial class Default : System.Web.UI.Page
    {
        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            lblMensaje.Text = "";
            int idHistoriaClinicaPerinatalTemp;

            if (Int32.TryParse(Request.QueryString["id"], out idHistoriaClinicaPerinatalTemp))
            {
                idHistoriaClinicaPerinatal = idHistoriaClinicaPerinatalTemp;
                LoadEstado(idHistoriaClinicaPerinatalTemp);
            }
        }

        private void LoadEstado(int idHistoriaClinicaPerinatalTemp)
        {
            AprHistoriaClinicaPerinatal oHistoria = new AprHistoriaClinicaPerinatal(idHistoriaClinicaPerinatalTemp);

            if (oHistoria.Activa == true) rblEstado.SelectedValue = "1";
            else rblEstado.SelectedValue = "0";
            txtObservaciones.Text = oHistoria.Observaciones;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SysUsuario us = new SysUsuario(Session["idUsuario"]);
            if (!us.IsNew)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                AprHistoriaClinicaPerinatal oHistoria = new AprHistoriaClinicaPerinatal();
                if (id > 0) {
                    // edito una HCP existente
                    oHistoria = new AprHistoriaClinicaPerinatal(id);
                }
                if (rblEstado.SelectedValue == "0") oHistoria.Activa = false;
                else oHistoria.Activa = true;
                oHistoria.Observaciones = txtObservaciones.Text;

                oHistoria.Save(us.Username);
                lblMensaje.Text = "Los datos se guardaron correctamente.";
            }
        }
    }
}
