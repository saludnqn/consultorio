using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DalSic;
using Salud.Security.SSO;


namespace Consultorio.ConsultaAmbulatoria.MasterPages
{

    public partial class Consultorio : System.Web.UI.MasterPage
    {
        //public SysUsuario Usuario { get { return Master.Usuario; } }
       

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMensaje.Controls.Clear();
            if (IsPostBack) return;

            


        }

        public void Message(string Mensaje, MessageStatus estado)
        {
            Message(Mensaje, estado, "");
        }
        public void Message(string Mensaje, MessageStatus estado, String BackUrl)
        {
            List<string> temp = new List<string>();
            temp.Add(Mensaje);
            Message(estado, "", temp, "");
        }

        public void Message(MessageStatus estado, string Titulo, List<string> Mensaje)
        {
            Message(estado, Titulo, Mensaje, "");
        }
        public void Message(MessageStatus estado, string Titulo, List<string> Mensaje, String BackUrl)
        {
            string TituloMensaje;
            string clase;
            string imagen;
            switch (estado)
            {
                case MessageStatus.ok:
                    TituloMensaje = "Mensaje: ";
                    clase = "ui-corner-all ui-state-highlight";
                    imagen = "ok";
                    break;
                case MessageStatus.alert:
                    TituloMensaje = "Alerta: ";
                    clase = "ui-corner-all ui-state-highlight";
                    imagen = "alert";
                    break;
                case MessageStatus.error:
                    TituloMensaje = "Error: ";
                    clase = "ui-corner-all ui-state-error";
                    imagen = "error";
                    break;
                default:
                    TituloMensaje = "Mensaje: ";
                    clase = "ui-corner-all ui-state-highlight";
                    imagen = "ok";
                    break;
            }
            string divError = @"<div class='{0}' style='padding:3px'>
            <img src='{1}' />
            <span><strong>{2}</strong>
            {3}</span></div>";
            string limensaje = "<li>{0}</li>";
            string ulmensaje = "<ul>{0}</ul>";
            string temp = "";
            foreach (string m in Mensaje)
            {
                temp += string.Format(limensaje, m);
            }

            Literal lt = new Literal();
            lt.Text = String.Format(divError, clase,
                ResolveClientUrl(String.Format("~/Images/{0}.png", imagen)),
                TituloMensaje + Titulo, temp.Length == 0 ? "" :
                String.Format(ulmensaje, temp));

            pnlMensaje.Controls.Add(lt);
            pnlMensaje.Visible = true;
        }

        public int getSemanas()
        {
            return RP.getSemanas();
        }

        public int getAños()
        {
            return RP.edadPaciente().Years;
        }
    }
}