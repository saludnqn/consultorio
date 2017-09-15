using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace ConsultaAmbulatoria.UserControls
{
    public partial class DiagnosticoSecundario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getDiagnosticos()
        {
            //return idDiagnosticosSecundarios.Value;
            return idDiagnosticosSecundariosConNotificacion.Value;
        }

        public string GetNotificacion(object primerconsulta)
        { 
            string  textonotificacion = "No Informado";
        if (int.Parse(primerconsulta.ToString()) == 0) textonotificacion = "No Informado";
        if (int.Parse(primerconsulta.ToString()) == 1) textonotificacion = "Primera Vez";
        if (int.Parse(primerconsulta.ToString()) == 2) textonotificacion = "Ulterior";
        return textonotificacion;
        }
        public void setDiagnosticos(ConConsultaDiagnosticoCollection oDiagnosticos)
        {
            rptDiagnosticos.DataSource = oDiagnosticos;
            rptDiagnosticos.DataBind();

            foreach (ConConsultaDiagnostico oDiagnostico in oDiagnosticos)
            {
                if (idDiagnosticosSecundariosConNotificacion.Value.Length == 0)
                {
                    //idDiagnosticosSecundarios.Value += oDiagnostico.CODCIE10;
                    idDiagnosticosSecundariosConNotificacion.Value += oDiagnostico.CODCIE10 + ";" + oDiagnostico.PrimerConsulta.ToString(); 
                }
                else
                {
                    //idDiagnosticosSecundarios.Value += "," + oDiagnostico.CODCIE10;
                    idDiagnosticosSecundariosConNotificacion.Value += "," + oDiagnostico.CODCIE10.ToString() + ";" + oDiagnostico.PrimerConsulta.ToString(); ;
                }
            }
        }

        public void setDiagnosticosEnfermedad(AprRelRecienNacidoEnfermedadCollection oDiagnosticos)
        {
            rptDiagnosticos.DataSource = oDiagnosticos;
            rptDiagnosticos.DataBind();

            foreach (AprRelRecienNacidoEnfermedad oDiagnostico in oDiagnosticos)
            {
                if (idDiagnosticosSecundarios.Value.Length == 0)
                {
                    idDiagnosticosSecundarios.Value += oDiagnostico.CODCIE10;
                }
                else
                {
                    idDiagnosticosSecundarios.Value += "," + oDiagnostico.CODCIE10;
                }
            }
        }

    }
}