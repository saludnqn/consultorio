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
    public partial class DiagnosticoPrincipal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int getDiagnostico()
        {
            int idDiag;
            if (Int32.TryParse(idCie10.Value, out idDiag))
            {
                return idDiag;
            }
            else
            {
                return -1;
            }
        }

        public void setDiagnosticoPrincipal(int idCIE10)
        {
            ///Muestra el diagnostico principal
            SysCIE10 oCie10 = new SysCIE10(idCIE10);
            if (!oCie10.IsNew)
            {
                idCie10.Value = idCIE10.ToString();
                lblCodigo.Text = "("+oCie10.Codigo + " - " + oCie10.Nombre+")";
                lblNombre.Text = oCie10.Sinonimo;
                lblCapitulo.Text = oCie10.DescripCap;
            }
            else
            {
                lblNombre.Text = "El diagnostico seteado es incorrecto";
            }
        }
    }
}