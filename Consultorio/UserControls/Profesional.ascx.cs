using System;
using DalSic;

namespace UserControls
{
    public partial class Profesional : System.Web.UI.UserControl
    {
        public bool Requerido { get; set; }
        public string ValidationGroup { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            boolRequerido.Value = Requerido.ToString().ToLower();
            cvValidar.ValidationGroup = ValidationGroup;
            cvValidar.Enabled = (Requerido != true ? false : true);
        }

        public int getProfesional()
        {
            int idP;
            if (Int32.TryParse(idProf.Value, out idP))
            {
                ActivarRequerido(false);
                return idP;
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

        public void setProfesional(int idP)
        {
            SysProfesional oProf = new SysProfesional(idP);
            if (!oProf.IsNew)
            {
                idProf.Value = oProf.IdProfesional.ToString();
                lblNombreCompleto.Text = oProf.NombreCompleto;

                if (idP < 0 && Requerido) ActivarRequerido(true);
            }
            else
            {
                lblNombreCompleto.Text = "El Profesional seteado es incorrecto";
            }
        }
    }
}