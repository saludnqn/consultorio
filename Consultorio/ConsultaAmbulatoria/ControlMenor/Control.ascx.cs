using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public class ResultadoControl
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public DateTime? fechaproximocontrol = null;
        public string observacion = "";
    }

    public partial class Control : System.Web.UI.UserControl
    {
        public DateTime fechaProximaVisita
        {
            set
            {
                txtFechaProximoControl.Text = value.ToShortDateString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;            
        }

        public ResultadoControl getDatos()
        {
            ResultadoControl oResultado = new ResultadoControl();
            
            if (txtFechaProximoControl.Text.Length > 0)
            {
                DateTime fechaControl;
                if (DateTime.TryParse(txtFechaProximoControl.Text, out fechaControl))
                {
                    oResultado.fechaproximocontrol = fechaControl;
                }
                else
                {
                    oResultado.Estado = MessageStatus.error;
                    oResultado.mensaje.Add("La fecha tiene un formato incorrecto.");
                }
            }
            if (txtObservacion.Text.Length > 0)
            {
                oResultado.observacion = txtObservacion.Text;
            }

            return oResultado;
        }
    }
}