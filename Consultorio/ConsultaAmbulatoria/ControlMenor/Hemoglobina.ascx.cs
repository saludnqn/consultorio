using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public class ResultadoHemoglobina
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public decimal resultado = -1;
    }

    public partial class Hemoglobina : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void comprobarAnalisis(int idPaciente)
        {
            //reviso si el paciente no se hizo ya el analisis, para mostrar el resultado
            SubSonic.Select s = new SubSonic.Select();
            s.From(Schemas.AprControlNiñoSanoHemoglobina);
            s.Where(AprControlNiñoSanoHemoglobina.Columns.IdPaciente).IsEqualTo(idPaciente);
            List<AprControlNiñoSanoHemoglobina> controles = s.ExecuteTypedList<AprControlNiñoSanoHemoglobina>();

            if (controles.Count>0)
            {
                txtResultado.Text = controles[0].Valor.ToString();
            }
        }

        public ResultadoHemoglobina getDatos()
        {
            ResultadoHemoglobina oResultado = new ResultadoHemoglobina();

            decimal resultado;
            if (!String.IsNullOrEmpty(txtResultado.Text))
            {
                if (Decimal.TryParse(txtResultado.Text, out resultado))
                {
                    oResultado.resultado = resultado;
                }
                else
                {
                    oResultado.Estado = MessageStatus.alert;
                    oResultado.mensaje.Add("El resultado debe ser un valor decimal.");
                }
            }

            return oResultado;
        }
    }
}