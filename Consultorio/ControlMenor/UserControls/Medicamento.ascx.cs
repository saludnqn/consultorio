using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace SIPS.ControlMenor.UserControls
{
    public partial class Medicamento : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getMedicamento()
        {
            return idMedicamento.Value;
        }

        public void setMedicamento(int idMed)
        {
            SysMedicamento oMed = new SysMedicamento(idMed);
            if (!oMed.IsNew)
            {
                idMedicamento.Value = idMed.ToString();
                lblDescripcion.Text = oMed.Nombre;
                txtAutomed.Text = oMed.Nombre;
                lblRubro.Text = oMed.SysMedicamentoRubro != null ? oMed.SysMedicamentoRubro.Nombre : "-";
            }
            else
            {
                lblDescripcion.Text = "El medicamento seteado es incorrecto";
            }
        }
    }
}