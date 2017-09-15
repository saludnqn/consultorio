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

namespace SIC.ControlMenor.Visitas.UserControls
{
    public partial class Enfermeria : System.Web.UI.UserControl
    {
        // Identificador del control
        private int idControl
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idControl"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AprControlNiñoSanoEnfermerium oControl = new Select()
                .From(AprControlNiñoSanoEnfermerium.Schema)
                .Where(AprControlNiñoSanoEnfermerium.IdControlNiñoSanoColumn).IsEqualTo(idControl)
                .ExecuteSingle<AprControlNiñoSanoEnfermerium>();

            if (oControl != null)
            {
                ltPerimetroCefalico.Text = oControl.PerimetroCefalico.ToString() + " centímetros";
                ltPeso.Text = oControl.Peso.ToString() + " Kilogramos";
                ltTalla.Text = oControl.Talla.ToString() + " centímetros";

                ltEstadoNutricional.Text = oControl.AprEstadoNutricional != null ? oControl.AprEstadoNutricional.Nombre : "[SIN DATOS]";
                ltTallaEdad.Text = oControl.AprTallaEdad != null ? oControl.AprTallaEdad.Nombre : "[SIN DATOS]";

                ltFecha.Text = oControl.FechaControl.ToString();
                if (oControl.Ta != null) ltTa.Text = oControl.Ta.ToString() + " mmHg";
                else ltFecha.Text = "";
                ltObservaciones.Text = oControl.Observaciones;
                ltProfesional.Text = oControl.SysProfesional.ApellidoyNombre != null ? ltProfesional.Text : "[SIN DATOS]"; 
                //ltProfesional.Text = oControl.SysProfesional.ApellidoyNombre;
            }
        }
    }
}