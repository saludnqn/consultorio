using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;


namespace Consultorio.ConsultaAmbulatoria.MasterPages
{
    public partial class ConsultorioPerinatal : System.Web.UI.MasterPage
    {
        private int idPaciente
        {
            get {   int idTemp; 
                    return (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp)) ? idTemp : 0; }
        }

        private int idHistoriaClinicaPerinatal
        {
            get { int idHCPTemp; return (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHCPTemp)) ? idHCPTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMensaje.Controls.Clear();
            if (IsPostBack) return;

            if (idHistoriaClinicaPerinatal != 0)
            {
                string activo = "ui-state-default ui-corner-top ui-tabs-selected ui-state-active";
                hlControl.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Control/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Control/")) tabControl.Attributes["class"] = activo;
                hlActividades.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Actividades/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Actividades/")) tabActividades.Attributes["class"] = activo;
                hlControlOdontologico.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/ControlOdontologico/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/ControlOdontologico/")) tabControlOdontologico.Attributes["class"] = activo;
                hlInterconsultas.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Interconsultas/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Interconsultas/")) tabInterconsultas.Attributes["class"] = activo;
                hlGraficos.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Graficos/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Graficos/")) tabGraficos.Attributes["class"] = activo;
                //hlScore.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Score/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                //if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Score/")) tabScore.Attributes["class"] = activo;
                //hlEvaluacion.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Evaluacion/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                //if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Evaluacion/")) tabEval.Attributes["class"] = activo;
                hlAlerta.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Alerta/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Alerta/")) tabAlerta.Attributes["class"] = activo;
                hlAUterina.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/AlturaUterina/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/AlturaUterina/")) tabAUterina.Attributes["class"] = activo;
                hlParto.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Parto/?idHistoriaClinicaPerinatal={0}", idHistoriaClinicaPerinatal);
                if (Request.FilePath.StartsWith("/ConsultaAmbulatoria/ControlPerinatal/Parto/")) tabParto.Attributes["class"] = activo;
            }
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
            string divError = @"<div class='{0}' style='padding:15px'>
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