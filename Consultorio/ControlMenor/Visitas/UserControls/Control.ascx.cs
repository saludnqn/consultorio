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
using DalSic;
using SubSonic;

namespace SIPS.ControlMenor.Visitas.UserControls
{
    public partial class Control : System.Web.UI.UserControl
    {
        // Identificador del control
        private int idControl
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idControl"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            AprControlNiñoSanoConsultorio oControl = new Select()
                .From(AprControlNiñoSanoConsultorio.Schema)
                .Where(AprControlNiñoSanoConsultorio.IdControlNiñoSanoColumn).IsEqualTo(idControl)
                .ExecuteSingle<AprControlNiñoSanoConsultorio>();

            if (oControl != null)
            {
                SetDatos(oControl);

                dtpFecha.Text = oControl.FechaProximoControl.HasValue ? oControl.FechaProximoControl.Value.ToShortDateString() : "";
                txtObservaciones.Text = oControl.Observacion;
            }
        }

        protected void SetDatos(AprControlNiñoSanoConsultorio oControl)
        {
            ltFechaProximoControl.Text = oControl.FechaProximoControl.HasValue ? oControl.FechaProximoControl.Value.ToShortDateString() : "";
            ltObservaciones.Text = oControl.Observacion;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //SIPS.ControlMenor.MasterPages.ControlMenor oMaster = Page.Master as SIPS.ControlMenor.MasterPages.ControlMenor;
            //string usuario = "tempUser";
            //if (oMaster != null)
            //{
            //    usuario = oMaster.Usuario.Username;
            //}

            AprControlNiñoSanoConsultorio oControl = new Select()
                .From(AprControlNiñoSanoConsultorio.Schema)
                .Where(AprControlNiñoSanoConsultorio.IdControlNiñoSanoConsultorioColumn).IsEqualTo(idControl)
                .ExecuteSingle<AprControlNiñoSanoConsultorio>();

            if (oControl != null)
            {
                oControl.FechaProximoControl = Convert.ToDateTime(dtpFecha.Text);
                oControl.Observacion = txtObservaciones.Text;
                oControl.Save(0);

                SetDatos(oControl);
            }
        }
    }
}