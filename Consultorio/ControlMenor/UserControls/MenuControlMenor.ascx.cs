using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SIPS.ControlMenor.UserControls
{
    public partial class MenuControlMenor : System.Web.UI.UserControl
    {
        private int idPaciente
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (idPaciente != 0)
            {
                string activo = "ui-state-default ui-corner-top ui-tabs-selected ui-state-active";

                hlDatosMadre.NavigateUrl = String.Format("~/ControlMenor/DatosMadre/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/DatosMadre/")) tabDatosMadre.Attributes["class"] = activo;

                hlCondicionesVivienda.NavigateUrl = String.Format("~/ControlMenor/CondVivienda/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/ConVivienda/")) tabCondicionesVivienda.Attributes["class"] = activo;

                hlDatosPerinatales.NavigateUrl = String.Format("~/ControlMenor/DatosPerinatales/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/DatosPerinatales/")) tabDatosPerinatales.Attributes["class"] = activo;

                hlControles.NavigateUrl = String.Format("~/ControlMenor/Visitas/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/Visitas/")) tabControles.Attributes["class"] = activo;

                hlCalendarioVacunacion.NavigateUrl = String.Format("~/ControlMenor/CalendarioVacunacion/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/CalendarioVacunacion/")) tabCalendarioVacunacion.Attributes["class"] = activo;

                hlResumenProblemas.NavigateUrl = String.Format("~/ControlMenor/ResProblemas/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/ResProblemas/")) tabResumenProblemas.Attributes["class"] = activo;

                hlVisitasDomiliarias.NavigateUrl = String.Format("~/ControlMenor/VisitasDomiciliarias/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/VisitasDomiciliarias/")) tabVisitasDomiciliarias.Attributes["class"] = activo;

                hlIntervenciones.NavigateUrl = String.Format("~/ControlMenor/Intervenciones/?idPaciente={0}", idPaciente);
                if (Request.FilePath.StartsWith("/ControlMenor/Intervenciones/")) tabIntervenciones.Attributes["class"] = activo;
            }
        }
    }
}