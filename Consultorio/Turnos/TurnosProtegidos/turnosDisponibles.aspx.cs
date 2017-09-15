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
    public partial class turnosDisponibles : System.Web.UI.Page
    {

        // ---------------------------------------------------------------------------------------------------------------------------
        // Declaraciones globales
        // ---------------------------------------------------------------------------------------------------------------------------

        string hayError = "NO";

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDatosPaciente.Text = Session["TurnosProtegidos_DatosPaciente"].ToString();
                lblOtrosDatos.Text = Session["TurnosProtegidos_OtrosDatos"].ToString();

                if (Session["TurnosProtegidos_EfectorHabilitadoId"].ToString().Trim() == "221") // H. Heller
                {
                    // Oculto/muestro las tablas que corresponde
                    gvListaTurnosDisponiblesHeller.Visible = true;
                    gvListaTurnosDisponiblesDistintoHeller.Visible = false;

                    string url = "http://10.1.104.37/sss/getTurnosReservados.php?idagenda=" + Request["idAgenda"] + "&idesp=" + Request["idEspecialidad"];

                    WebRequest request = WebRequest.Create(url);
                    WebResponse ws = request.GetResponse();
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    Stream st = ws.GetResponseStream();
                    StreamReader sr = new StreamReader(st);
                    string s = sr.ReadToEnd();
                    //var turnos = jsonSerializer.Deserialize<List<turnoHeller>>(s).Where(t => t.idagenda == turno.idagenda);
                    if (s != "0")
                    {
                        var turnos = jsonSerializer.Deserialize<List<turnosProtegidos>>(s);

                        // ----------------------------------------------------------------------------------------------------------------------------------------
                        // Cargo los datos en un DataTable para poder obtener los valores de los campos que no son "DataKeyNames="idTurno", i.e.: "hora" y "fecha".
                        // ----------------------------------------------------------------------------------------------------------------------------------------

                        DataTable dtTurnosDisponibles;
                        dtTurnosDisponibles = new DataTable();

                        dtTurnosDisponibles.Columns.Add("idTurno", typeof(int));
                        dtTurnosDisponibles.Columns.Add("hora", typeof(string));
                        dtTurnosDisponibles.Columns.Add("fecha", typeof(string));

                        int longitud = obtenerLongitudHeller(s);

                        for (int i = 0; i < longitud; i++)
                        {
                            // Creo una fila
                            dtTurnosDisponibles.Rows.Add();
                            // Agrego datos
                            dtTurnosDisponibles.Rows[i]["idTurno"] = int.Parse(turnos[i].idTurno.ToString());
                            dtTurnosDisponibles.Rows[i]["hora"] = turnos[i].hora;
                            // Formateo la fecha a "dd/mm/aaaa"
                            string fechaSinFormato = turnos[i].fecha;
                            dtTurnosDisponibles.Rows[i]["fecha"] = fechaSinFormato.Substring(6, 2) + "/" + fechaSinFormato.Substring(4, 2) + "/" + fechaSinFormato.Substring(0, 4);
                        }

                        // Cargo un viewstate para poder trabajar desde otros métodos con el DataTable
                        ViewState["viewState_dtTurnosDisponibles"] = dtTurnosDisponibles;

                        gvListaTurnosDisponiblesHeller.DataSource = dtTurnosDisponibles;
                        gvListaTurnosDisponiblesHeller.DataBind();

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('No hay turnos disponibles');</script>");
                    }
                }
                else // Distinto de H. Heller
                {
                    // Oculto/muestro las tablas que corresponde
                    gvListaTurnosDisponiblesHeller.Visible = false;
                    gvListaTurnosDisponiblesDistintoHeller.Visible = true;

                    // ,nota: "TUP_WebService" es una clave en el Web.config de la forma:
                    //        <add key="TUP_WebService" value="http://10.1.232.15/WsTurnos/Turnos.asmx" />

                    string s_urlWFC = ConfigurationManager.AppSettings["TUP_WebService"].ToString();
                    string s_url = s_urlWFC + "/getTurnosProtegidos?idEfector=" + Session["TurnosProtegidos_EfectorHabilitadoId"].ToString().Trim() + 
                                                                  "&idAgenda=" + Request["idAgenda"].ToString().Trim();

                    WebRequest request = WebRequest.Create(s_url);
                    WebResponse ws = request.GetResponse();
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    Stream st = ws.GetResponseStream();
                    StreamReader sr = new StreamReader(st);
                    string s = sr.ReadToEnd();
                    int inicios = s.IndexOf("[");
                    int fins = s.IndexOf("]") + 1;
                    string auxs = s.Substring(inicios, fins - inicios);
                    List<turnosProtegidos> lstTurnosProtegidos = jsonSerializer.Deserialize<List<turnosProtegidos>>(auxs);

                    // ----------------------------------------------------------------------------------------------------------------------------------------
                    // Cargo los datos en un DataTable para poder obtener los valores de los campos que no son "DataKeyNames="idTabla", i.e.: "fecha" y "hora".
                    // ----------------------------------------------------------------------------------------------------------------------------------------

                    DataTable dtTurnosDisponibles;
                    dtTurnosDisponibles = new DataTable();

                    dtTurnosDisponibles.Columns.Add("idTabla", typeof(int));                    
                    dtTurnosDisponibles.Columns.Add("fecha", typeof(string));
                    dtTurnosDisponibles.Columns.Add("hora", typeof(string));

                    int longitud = obtenerLongitudDistintoHeller(auxs);

                    int indiceTabla = 0;

                    for (int i = 0; i < longitud; i++)
                    {
                        // Creo una fila
                        dtTurnosDisponibles.Rows.Add();
                        // Agrego datos
                        dtTurnosDisponibles.Rows[i]["idTabla"] = indiceTabla;
                        dtTurnosDisponibles.Rows[i]["hora"] = lstTurnosProtegidos[i].hora;
                        // Formateo la fecha a "dd/mm/aaaa"
                        string fechaSinFormato = lstTurnosProtegidos[i].fecha;
                        fechaSinFormato = fechaSinFormato.Substring(0, 10);
                        dtTurnosDisponibles.Rows[i]["fecha"] = fechaSinFormato.Substring(0, 2) + "/" + fechaSinFormato.Substring(3, 2) + "/" + fechaSinFormato.Substring(6, 4);

                        indiceTabla++;
                    }

                    // Cargo un viewstate para poder trabajar desde otros métodos con el DataTable
                    ViewState["viewState_dtTurnosDisponiblesSIPS"] = dtTurnosDisponibles;

                    gvListaTurnosDisponiblesDistintoHeller.DataSource = dtTurnosDisponibles;
                    gvListaTurnosDisponiblesDistintoHeller.DataBind();
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        public int obtenerLongitudHeller(string cadena)
        {
            // Calculo la longitud de un string de la forma (ej.: [{"hora":" 9:45","fecha":"20130904  ","idturno":2291943},{"hora":" 9:30","fecha":"20130904  ","idturno":2291942},{"hora":" 9:15","fecha":"20130904  ","idturno":2291941}])
            // ,nota: Busco la subcadena: "idturno" (es el delimitador que utilizo para poder contar).

            int ocurrencias = 0;
            ocurrencias = cadena.Split(new String[] { "idturno" }, StringSplitOptions.None).Length;
            
            return ocurrencias;
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        public int obtenerLongitudDistintoHeller(string cadena)
        {
            // Calculo la longitud de un string de la forma (ej.: [{"hora":" 9:45","fecha":"20130904},{"hora":" 9:30","fecha":"20130904  "},{"hora":" 9:15","fecha":"20130904  "])
            // ,nota: Busco la subcadena: "idTabla" (es el delimitador que utilizo para poder contar).

            int ocurrencias = 0;
            ocurrencias = cadena.Split(new String[] { "hora" }, StringSplitOptions.None).Length - 1;

            return ocurrencias;
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        public void obtenerFechaYHoraParaHeller(int idTurnoSeleccionado)
        {
            int idTurnoObtenido;
            int i = 0;

            DataTable dtTurnosDisponibles_aux;

            dtTurnosDisponibles_aux = (DataTable)ViewState["viewState_dtTurnosDisponibles"];

            foreach (DataRow drTurnoDisponible in dtTurnosDisponibles_aux.Rows)
            {
                idTurnoObtenido = int.Parse(dtTurnosDisponibles_aux.Rows[i]["idTurno"].ToString());

                if (idTurnoObtenido == idTurnoSeleccionado) // Encontré el registro
                {
                    Session["TurnosProtegidos_fechaTurnoDisponible"] = dtTurnosDisponibles_aux.Rows[i]["fecha"].ToString();
                    Session["TurnosProtegidos_horaTurnoDisponible"] = dtTurnosDisponibles_aux.Rows[i]["hora"].ToString();
                }

                i += 1;
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        public void obtenerFechaYHoraParaDistintoHeller(int idTablaSeleccionado)
        {
            int idTablaObtenido;
            int i = 0;

            DataTable dtTurnosDisponibles_aux;

            dtTurnosDisponibles_aux = (DataTable)ViewState["viewState_dtTurnosDisponiblesSIPS"];

            foreach (DataRow drTurnoDisponible in dtTurnosDisponibles_aux.Rows)
            {
                idTablaObtenido = int.Parse(dtTurnosDisponibles_aux.Rows[i]["idTabla"].ToString());

                if (idTablaObtenido == idTablaSeleccionado) // Encontré el registro
                {
                    Session["TurnosProtegidos_fechaTurnoDisponible"] = dtTurnosDisponibles_aux.Rows[i]["fecha"].ToString();
                    Session["TurnosProtegidos_horaTurnoDisponible"] = dtTurnosDisponibles_aux.Rows[i]["hora"].ToString();
                }

                i += 1;
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        public void guardarTurnoEnTablaTUP_TurnosProtegidos(int idTurno)
        {
            // Grabo el registro del turno en la tabla "TUP_TurnosProtegidos"

            TupTurnosProtegido oTurnoProtegido = new TupTurnosProtegido();
            oTurnoProtegido.IdInterconsulta = int.Parse(Session["turnosProtegidos_interconsultaId"].ToString());

            oTurnoProtegido.IdTurnoEfector = idTurno;

            oTurnoProtegido.IdEfector = int.Parse(Session["TurnosProtegidos_EfectorHabilitadoId"].ToString());
            oTurnoProtegido.IdExternoEspecialidad = int.Parse(Session["TurnosProtegidos_idExternoEspecialidad"].ToString());
            oTurnoProtegido.NombreEspecialidad = Session["TurnosProtegidos_nombreEspecialidad"].ToString();
            oTurnoProtegido.IdExternoProfesional = int.Parse(Session["TurnosProtegidos_idExternoProfesional"].ToString());
            oTurnoProtegido.NombreProfesional = Session["TurnosProtegidos_nombreProfesional"].ToString();

            oTurnoProtegido.FechaTurno = DateTime.Parse(Session["TurnosProtegidos_fechaTurnoDisponible"].ToString().Trim());
            oTurnoProtegido.HoraTurno = DateTime.Parse(Session["TurnosProtegidos_horaTurnoDisponible"].ToString().Trim());

            oTurnoProtegido.FechaTurno = DateTime.Parse(Session["TurnosProtegidos_fechaTurnoDisponible"].ToString());

            DateTime horaTurno = DateTime.Parse(Session["TurnosProtegidos_horaTurnoDisponible"].ToString());
            oTurnoProtegido.HoraTurno = DateTime.Parse(horaTurno.ToShortTimeString().ToString());

            oTurnoProtegido.IdUsuarioCarga = int.Parse(SSOHelper.CurrentIdentity.Id.ToString().Trim());

            oTurnoProtegido.Save();

            Session["TurnosProtegidos_valor_idTurnoSubsecretaria"] = oTurnoProtegido.IdTurnoSubsecretaria.ToString().Trim(); // lo utilizo en "gvListaTurnosDisponiblesHeller_RowCommand(....)"

            // Cargo algunas variables de sesión...
            Session["TurnosProtegidos_Turno_OtrosDatos"] = "Efector: " + Session["TurnosProtegidos_EfectorHabilitadoNombre"] + " </br>" +
                                                           "Fecha: " + Session["TurnosProtegidos_fechaTurnoDisponible"].ToString().Trim() + "</br>" +
                                                           "Hora: " + Session["TurnosProtegidos_horaTurnoDisponible"].ToString().Trim() + "</br>" +
                                                           "Profesional: " + oTurnoProtegido.NombreProfesional + "</br>" +
                                                           "Especialidad: " + oTurnoProtegido.NombreEspecialidad + "</br>" +
                                                           "Consultorio: " + Request["consultorio"];
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void gvListaTurnosDisponiblesHeller_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Seleccionar":

                        int idTurno = int.Parse(e.CommandArgument.ToString().Trim());

                        guardarTurnoEnTablaTUP_TurnosProtegidos(idTurno);

                        // LLamo al ws grabarTurnosReservados con el dni del pac, idTurnoHeller, idTurnoSubse 
                        string url = "http://10.1.104.37/sss/grabarTurnosReservados.php?dni=" + Session["TurnosProtegidos_DNIPaciente"].ToString().Trim() + "&idturno=" + idTurno + "&idturnosss=" + Session["TurnosProtegidos_valor_idTurnoSubsecretaria"].ToString().Trim();

                        WebRequest request = WebRequest.Create(url);
                        WebResponse ws = request.GetResponse();
                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        Stream st = ws.GetResponseStream();
                        StreamReader sr = new StreamReader(st);
                        string s = sr.ReadToEnd();

                        if (s != "0")
                        {
                            // Muestro el turno en pantalla ...
                            Response.Redirect("mostrarTurnoPaciente.aspx", false);
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('Hubo un error al intertar guardar el turno protegido en la base del H. Heller');</script>");
                        }
                    break;
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void gvListaTurnosDisponiblesHeller_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton CmdSeleccionar = (ImageButton)e.Row.Cells[0].Controls[1];
                CmdSeleccionar.CommandArgument = this.gvListaTurnosDisponiblesHeller.DataKeys[e.Row.RowIndex].Value.ToString();
                CmdSeleccionar.CommandName = "Seleccionar";
                CmdSeleccionar.ToolTip = "Seleccionar turno";
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void gvListaTurnosDisponiblesDistintoHeller_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Seleccionar":
                        int idTabla = int.Parse(e.CommandArgument.ToString().Trim());
                        obtenerFechaYHoraParaDistintoHeller(idTabla);

                        string fechaDeNacimientoCompleta = Session["TurnosProtegidos_fechaNacimiento"].ToString().Trim();
                        string fechaDeNacimientoFormateada = fechaDeNacimientoCompleta.Substring(0, 2) + "/" + fechaDeNacimientoCompleta.Substring(3, 2) + "/" + fechaDeNacimientoCompleta.Substring(6, 4);                           


                        string s_urlWFC = ConfigurationManager.AppSettings["TUP_WebService"].ToString();
                        string s_url = s_urlWFC + "/ocuparTurnosProtegidos?idEfector=" + Session["TurnosProtegidos_EfectorHabilitadoId"].ToString().Trim() +
                                                                         "&idAgenda=" + Request["idAgenda"].ToString().Trim() +
                                                                         "&fechaTurno=" + Session["TurnosProtegidos_fechaTurnoDisponible"].ToString().Trim() +
                                                                         "&horaTurno=" + Session["TurnosProtegidos_horaTurnoDisponible"].ToString().Trim() +
                                                                         "&numerodocumento=" + Session["TurnosProtegidos_DNIPaciente"].ToString().Trim() +
                                                                         "&apellido=" + Session["TurnosProtegidos_Apellido"].ToString().Trim() +
                                                                         "&nombre=" + Session["TurnosProtegidos_Nombre"].ToString().Trim() +
                                                                         "&idsexo=" + Session["TurnosProtegidos_idSexo"].ToString().Trim() +
                                                                         "&fechaNacimiento=" + fechaDeNacimientoFormateada +
                                                                         "&idObraSocial=" + Session["TurnosProtegidos_idObraSocial"].ToString().Trim() +
                                                                         "&idUsuario=" + int.Parse(SSOHelper.CurrentIdentity.Id.ToString().Trim());

                        WebRequest request = WebRequest.Create(s_url);
                        WebResponse ws = request.GetResponse();
                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        Stream st = ws.GetResponseStream();
                        StreamReader sr = new StreamReader(st);
                        string s = sr.ReadToEnd();
                        int inicios = s.IndexOf("[");
                        int fins = s.IndexOf("]") + 1;
                        string auxs = s.Substring(inicios, fins - inicios);
                        List<turnosProtegidos> lstTurnosProtegidos = jsonSerializer.Deserialize<List<turnosProtegidos>>(auxs);

                        guardarTurnoEnTablaTUP_TurnosProtegidos(int.Parse(lstTurnosProtegidos[0].idTurno.ToString().Trim()));

                        // Muestro el turno en pantalla ...
                        Response.Redirect("mostrarTurnoPaciente.aspx", false);

                        break;
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void gvListaTurnosDisponiblesDistintoHeller_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton CmdSeleccionar = (ImageButton)e.Row.Cells[0].Controls[1];
                CmdSeleccionar.CommandArgument = this.gvListaTurnosDisponiblesDistintoHeller.DataKeys[e.Row.RowIndex].Value.ToString();
                CmdSeleccionar.CommandName = "Seleccionar";
                CmdSeleccionar.ToolTip = "Seleccionar turno";
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

    }
}
