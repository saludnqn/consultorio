using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Drawing;

namespace ConsultaAmbulatoria.UserControls
{
    public partial class PrestacionOdontologia : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int getPrestacion()
        {
            int idPrest;
            if (Int32.TryParse(idNomenclador.Value, out idPrest))
            {
                return idPrest;
            }
            else
            {
                return -1;
            }
        }

        public void setPrestacion(int idPrest)
        {
            ///Muestra el diagnostico principal
            OdoNomenclador oCie10 = new OdoNomenclador(idPrest);
            if (!oCie10.IsNew)
            {
                idNomenclador.Value = idNomenclador.ToString();
                lblCodigo.Text = "("+oCie10.Codigo + " - " + oCie10.Descripcion+")";
                lblNombre.Text = oCie10.Descripcion;
                lblClasificacion.Text = oCie10.Clasificacion;
            }
            else
            {
                lblNombre.Text = "La prestación es incorrecta.";
            }
        }
        public void Limpiar()
        { 

           
            txtAutoOdonto.Text="";
            idNomenclador.Value="";
            lblNombre.Text="Ingrese nombre o codigo.";
            lblCodigo.Text="";
              lblClasificacion.Text = "";

           
        }
    }
}