using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using DalSic;
using System.Data;
using Salud.Security.SSO;
using SubSonic;
using TurnosProtegidos;
using System.Configuration;
using System.Xml;

namespace Consultorio.Turnos.TurnosProtegidos
{
    public partial class verificarAsignacionAgenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // ---------------------------------------------------------------------------------------------------------------------------

            if (!IsPostBack)
            {
                if (Session["TurnosProtegidos_EfectorHabilitadoId"].ToString().Trim() != "221") // Distinto de H. Heller
                {
                    string s_urlWFC = ConfigurationManager.AppSettings["TUP_WebService"].ToString();
                    string s_url = s_urlWFC + "/verificaPacienteAgenda?idEfector=" + Session["TurnosProtegidos_EfectorHabilitadoId"].ToString().Trim() +
                                                                     "&idAgenda=" + Request["idAgenda"].ToString().Trim() +
                                                                     "&numerodocumento=" + Session["TurnosProtegidos_DNIPaciente"].ToString().Trim();

                    WebRequest request = WebRequest.Create(s_url);
                    WebResponse ws = request.GetResponse();
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    Stream st = ws.GetResponseStream();
                    StreamReader sr = new StreamReader(st);
                    string s = sr.ReadToEnd();
                    int inicios = s.IndexOf("[");
                    int fins = s.IndexOf("]") + 1;
                    string auxs = s.Substring(inicios, fins - inicios);
                    List<existePacienteEnAgenda> lstExistePacienteEnAgendas = jsonSerializer.Deserialize<List<existePacienteEnAgenda>>(auxs);

                    if (lstExistePacienteEnAgendas[0].existe.ToString().Trim() == "0") // Todo ok, el paciente NO tiene un turno aaignado en esta agenda.
                    {
                        Response.Redirect("turnosDisponibles.aspx?idAgenda=" + Request["idAgenda"].ToString().Trim() +
                                                                "&idEspecialidad=" + Request["idEspecialidad"].ToString().Trim() +
                                                                "&idInterconsulta=" + Request["idInterconsulta"].ToString().Trim() +
                                                                "&consultorio=" + Request["consultorio"].ToString().Trim(), false);
                    }
                }
            }

        }

        // ---------------------------------------------------------------------------------------------------------------------------

    }
}