using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Drawing;

namespace UserControls
{
    public partial class Efector : System.Web.UI.UserControl
    {
        public bool Requerido { get; set; }
        public string ValidationGroup { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            boolRequerido.Value = Requerido.ToString().ToLower();
            cvValidar.ValidationGroup = ValidationGroup;
            cvValidar.Enabled = (Requerido != true ? false : true);
        }

        public int getEfector()
        {
            int idE;
            if (Int32.TryParse(idEfector.Value, out idE))
            {
                ActivarRequerido(false);
                return idE;
            }
            else
            {
                if (Requerido) ActivarRequerido(true);
                return -1;
            }
        }

        private void ActivarRequerido(bool Activa)
        {
            lblMensajeError.Style.Add("visibility", (Activa == true ? "visible" : "collapse"));
        }

        public void setEfector(int idE)
        {
            SysEfector oEfec = new SysEfector(idE);
            if (!oEfec.IsNew)
            {
                idEfector.Value = oEfec.IdEfector.ToString();
                lblNombre.Text = oEfec.Nombre;

                if (idE < 0 && Requerido) ActivarRequerido(true);
            }
            else
            {
                lblNombre.Text = "El Efector seteado es incorrecto";
            }
        }
    }
}