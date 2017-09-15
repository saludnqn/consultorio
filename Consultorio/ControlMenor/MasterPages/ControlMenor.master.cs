using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
public enum MessageStatus
{
    ok = 0,
    alert,
    error
}
namespace Consultorio.ControlMenor.MasterPages
{
    public partial class ControlMenor : System.Web.UI.MasterPage
    {
        //public SysUsuario Usuario { get { return Master.Usuario; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        public void Message(string Mensaje, MessageStatus estado)
        {
            Message(Mensaje, estado, "");
        }

        public void Message(string Mensaje, MessageStatus estado, String BackUrl)
        {
            string TituloMensaje;
            string clase;
            string imagen;
            switch (estado)
            {
                case MessageStatus.ok:
                    TituloMensaje = "Mensaje";
                    clase = "ui-corner-all ui-state-default";
                    imagen = "ok";
                    break;
                case MessageStatus.alert:
                    TituloMensaje = "Alerta";
                    clase = "ui-corner-all ui-state-highlight";
                    imagen = "alert";
                    break;
                case MessageStatus.error:
                    TituloMensaje = "Error";
                    clase = "ui-corner-all ui-state-error";
                    imagen = "error";
                    break;
                default:
                    TituloMensaje = "Mensaje";
                    clase = "ui-corner-all ui-state-default";
                    imagen = "ok";
                    break;
            }
            pnlMensaje.CssClass = clase;
            lTitulo.Text = TituloMensaje;
            lMensaje.Text = Mensaje;
            imgMensaje.ImageUrl = String.Format("~/Images/{0}.png", imagen);
            pnlMensaje.Visible = true;
        }
    }
}
