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
    public partial class buscarAgenda : System.Web.UI.Page
    {

        // ---------------------------------------------------------------------------------------------------------------------------
        // Definiciones globales
        // ---------------------------------------------------------------------------------------------------------------------------

        string hayError = "NO";
        string datosHellerCompletos = "SI";

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaInicio.Value = DateTime.Now.ToString("dd/MM/yyyy");  // Fecha por defecto.

                hlCargarDatosPaciente.Visible = false;

                if (Request["idPaciente"].ToString() == "0")
                {
                    lblDatosPaciente.Text = "";
                }
                else
                {
                    SysPaciente oPaciente = new SysPaciente(int.Parse(Request["idPaciente"].ToString()));
                    lblDatosPaciente.Text = "Documento: " + oPaciente.NumeroDocumento + "</br>" + "Nombre: " + oPaciente.Apellido.Trim() + ", " + oPaciente.Nombre.Trim() + " </br>" + "Fch. Nac.: " + oPaciente.FechaNacimiento.ToShortDateString().Trim();

                    Session["TurnosProtegidos_DNIPaciente"] = oPaciente.NumeroDocumento.ToString().Trim();
                    Session["TurnosProtegidos_Apellido"] = oPaciente.Apellido.Trim();
                    Session["TurnosProtegidos_Nombre"] = oPaciente.Nombre.Trim();
                    Session["TurnosProtegidos_idSexo"] = oPaciente.IdSexo.ToString().Trim();
                    Session["TurnosProtegidos_fechaNacimiento"] = oPaciente.FechaNacimiento.ToString().Trim();
                    Session["TurnosProtegidos_idObraSocial"] = oPaciente.IdObraSocial.ToString().Trim();

                    cargarCombo();
                    // ,nota: Para que no de error asigno por defecto un valor en el combo (el primer item de la lista)
                    ddlEfectorHabilitado.SelectedIndex = 0;
                    cargarComboEspecialidad();
                }

                if (lblDatosPaciente.Text == "")
                {
                    pnlFiltros.Visible = false;
                    lblSeleccionarFiltros.Visible = false;
                    lblConsultar.Visible = false;
                    pnlVerAgendas.Visible = false;
                }
                else
                {
                    pnlFiltros.Visible = true;
                    lblSeleccionarFiltros.Visible = true;
                    lblConsultar.Visible = true;
                    pnlVerAgendas.Visible = true;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        private void cargarCombo()
        {
            ddlEfectorHabilitado.DataSource = SPs.TupCargarEfectoresHabilitados().GetDataSet().Tables[0];
            ddlEfectorHabilitado.DataBind();
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        private void cargarComboEspecialidad()
        {
            if (ddlEfectorHabilitado.SelectedValue.ToString() == "221") // H. Heller
            {
                // --------------------------------
                // Cargo el combo de Especialidades
                // --------------------------------

                WebRequest request = WebRequest.Create("http://10.1.104.37/optic/consultaEspecialidades.php");
                WebResponse ws = request.GetResponse();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Stream st = ws.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                string s = HttpUtility.HtmlDecode(sr.ReadToEnd());
                List<especialidades> lstEspecialidad = jsonSerializer.Deserialize<List<especialidades>>(Server.HtmlDecode(s));

                ddlEspecialidad.DataSource = lstEspecialidad;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }
            else // Distinto de H. Heller
            {
                // ,nota: "TUP_WebService" es una clave en el Web.config de la forma:
                //        <add key="TUP_WebService" value="http://10.1.232.15/WsTurnos/Turnos.asmx" />

                string s_urlWFC = ConfigurationManager.AppSettings["TUP_WebService"].ToString();
                string s_url = s_urlWFC + "/getEspecialidadesTurnos?idEfector=" + ddlEfectorHabilitado.SelectedValue.ToString().Trim();

                // Para probar ...
                //WebRequest request = WebRequest.Create("http://10.1.232.15/WsTurnos/Turnos.asmx/getEspecialidadesTurnos?idEfector=2");

                WebRequest request = WebRequest.Create(s_url);
                WebResponse ws = request.GetResponse();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Stream st = ws.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                string s = sr.ReadToEnd();
                int inicios = s.IndexOf("[");
                int fins = s.IndexOf("]") + 1;
                string auxs = s.Substring(inicios, fins - inicios);
                List<especialidades> lstEspecialidad = jsonSerializer.Deserialize<List<especialidades>>(auxs);

                ddlEspecialidad.DataSource = lstEspecialidad;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar", "0"));                
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        private void cargarLista()
        {
            if (ddlEfectorHabilitado.SelectedValue.ToString() == "221") // H. Heller
            {
                // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                // Para Probar --> http://10.1.104.37//sss/getAgendas.php?f1=2013-09-04&f2=2013-09-08
                // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                // ----------------------------------------------------------------------------------------
                // Cargo la lista de agendas según la especialidad y el profesional que seleccionó el usuario
                // ----------------------------------------------------------------------------------------

                string fechaInicio = txtFechaInicio.Value.Substring(6, 4) + txtFechaInicio.Value.Substring(3, 2) + txtFechaInicio.Value.Substring(0, 2);
                string fechaFin = txtFechaFin.Value.Substring(6, 4) + txtFechaFin.Value.Substring(3, 2) + txtFechaFin.Value.Substring(0, 2);

                WebRequest request = WebRequest.Create(" http://10.1.104.37//sss/getAgendas.php?f1=" + fechaInicio + "&f2=" + fechaFin);
                WebResponse ws = request.GetResponse();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Stream st = ws.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                string s = sr.ReadToEnd();

                if (s == "0") // El webservice devuelve "0" si no encontró resultados
                {
                    hayError = "SI";

                    // Limpio el grid

                    gvListaAgendas.DataSource = null;
                    gvListaAgendas.DataBind();
                }

                if ((hayError == "NO") && (datosHellerCompletos == "SI"))
                {
                    int id_especialidad = int.Parse(ddlEspecialidad.SelectedItem.Value);
                    int id_profesional = int.Parse(ddlProfesional.SelectedItem.Value);

                    var agendas = jsonSerializer.Deserialize<List<agenda>>(Server.HtmlDecode(s)).Where(a => a.idespecialidad == id_especialidad & a.cp == id_profesional);

                    gvListaAgendas.DataSource = agendas;
                    gvListaAgendas.DataBind();
                }

            }
            else // Distinto de H. Heller
            {
                // ,nota: "TUP_WebService" es una clave en el Web.config de la forma:
                //        <add key="TUP_WebService" value="http://10.1.232.15/WsTurnos/Turnos.asmx" />

                string s_urlWFC = ConfigurationManager.AppSettings["TUP_WebService"].ToString();
                string s_url = s_urlWFC + "/getAgendasTurnos?idEfector=" + ddlEfectorHabilitado.SelectedValue.ToString().Trim()
                                                         + "&idEspecialidad=" + ddlEspecialidad.SelectedValue.ToString().Trim()
                                                         + "&idProfesional=" + ddlProfesional.SelectedValue.ToString().Trim();

                // Para probar ...
                //WebRequest request = WebRequest.Create("http://10.1.232.15/WsTurnos/Turnos.asmx/getEspecialidadesTurnos?idEfector=1+&......");

                WebRequest requestAgendas = WebRequest.Create(s_url);
                WebResponse wsAgendas = requestAgendas.GetResponse();
                JavaScriptSerializer jsonSerializerAgendas = new JavaScriptSerializer();
                Stream stAgendas = wsAgendas.GetResponseStream();
                StreamReader srAgendas = new StreamReader(stAgendas);
                string sAgendas = srAgendas.ReadToEnd();
                int inicios = sAgendas.IndexOf("[");
                int fins = sAgendas.IndexOf("]") + 1;
                string auxs = sAgendas.Substring(inicios, fins - inicios);
                List<agenda> lstAgenda = jsonSerializerAgendas.Deserialize<List<agenda>>(auxs);

                // Cargo el grid !

                gvListaAgendas.DataSource = lstAgenda;
                gvListaAgendas.DataBind();

            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void gvListaAgendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hago nada.
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEfectorHabilitado.SelectedValue.ToString() == "221") // H. Heller
            {
                // ,nota: El combo de profesionales se cargar respecto de la especialidad que selecciona el usuario mediante
                //        el combo de especialidades.

                WebRequest request = WebRequest.Create("http://10.1.104.37/optic/consultaProfesionales.php");
                WebResponse ws = request.GetResponse();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Stream st = ws.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                string s = sr.ReadToEnd();
                var prof = jsonSerializer.Deserialize<List<profesional>>(Server.HtmlDecode(s)).Where(p => p.esp == ddlEspecialidad.SelectedItem.Text);

                List<profesional> profesionales = prof.ToList<profesional>();

                //list<profesional> profFiltrado = profesional.Where<profesional>(p => p.esp == ddlEspecialidad.SelectedValue);

                ddlProfesional.DataSource = profesionales;
                ddlProfesional.DataBind();
                ddlProfesional.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }
            else // Distinto de H. Heller
            {
                // ,nota: "TUP_WebService" es una clave en el Web.config de la forma:
                //        <add key="TUP_WebService" value="http://10.1.232.15/WsTurnos/Turnos.asmx" />

                string s_urlWFC = ConfigurationManager.AppSettings["TUP_WebService"].ToString();
                string s_url = s_urlWFC + "/getProfesionalesTurnos?idEfector=" + ddlEfectorHabilitado.SelectedValue.ToString().Trim() + 
                                                                 "&idEspecialidad=" + ddlEspecialidad.SelectedValue.ToString().Trim();

                // Para probar ...
                //WebRequest request = WebRequest.Create("http://10.1.232.15/WsTurnos/Turnos.asmx/getProfesionalesTurnos?idEfector=2...");

                WebRequest request = WebRequest.Create(s_url);
                WebResponse ws = request.GetResponse();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Stream st = ws.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                string s = sr.ReadToEnd();
                int inicios = s.IndexOf("[");
                int fins = s.IndexOf("]") + 1;
                string auxs = s.Substring(inicios, fins - inicios);
                List<profesional> lstProfesional = jsonSerializer.Deserialize<List<profesional>>(auxs);

                ddlProfesional.DataSource = lstProfesional;
                ddlProfesional.DataBind();
                ddlProfesional.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void verificarPacienteDatosCompletosHeller()
        {
            SysPaciente oPaciente = new SysPaciente(int.Parse(Request["idPaciente"]));

            DataTable dtPacientes = new DataTable();
            dtPacientes = SPs.TupObtenerDatosPaciente(oPaciente.NumeroDocumento.ToString().Trim()).GetDataSet().Tables[0];

            Session["turnosProtegidos_idPaciente"] = dtPacientes.Rows[0][0].ToString();

            // -------------------------------
            // Verificaciones
            // -------------------------------

            string mensajeFaltanDatosPaciente = "Falta cargar algunos datos del paciente para asignar el truno protegido (";

            if (dtPacientes.Rows[0][1].ToString() == "")
            {
                mensajeFaltanDatosPaciente += "número de documento, ";
                datosHellerCompletos = "NO";
            }

            if (dtPacientes.Rows[0][2].ToString() == "")
            {
                mensajeFaltanDatosPaciente += "apellido, ";
                datosHellerCompletos = "NO";
            }

            if (dtPacientes.Rows[0][3].ToString() == "")
            {
                mensajeFaltanDatosPaciente += "nombre, ";
                datosHellerCompletos = "NO";
            }

            if (dtPacientes.Rows[0][4].ToString() == "")
            {
                mensajeFaltanDatosPaciente += "sexo, ";
                datosHellerCompletos = "NO";
            }

            if (dtPacientes.Rows[0][6].ToString() == "")
            {
                mensajeFaltanDatosPaciente += "fecha de nacimiento, ";
                datosHellerCompletos = "NO";
            }

            if (dtPacientes.Rows[0][9].ToString() == "")
            {
                mensajeFaltanDatosPaciente += "calle, ";
                datosHellerCompletos = "NO";
            }

            // ,nota: -1 = "Seleccionar"
            //        0 = "Sin datos"

            // ,nota 2: No considero un campo incompleto cuando se selecciona "sin datos", ya qyue solo estan cargados algunos barrios de Nqn. De otras provincias
            //          casi no hay datos.

            if (dtPacientes.Rows[0][14].ToString() == "-1")
            {
                mensajeFaltanDatosPaciente += "barrio, ";
                datosHellerCompletos = "NO";
            }

            // ,nota: -1 = "Seleccionar"
            //        0 = "Sin datos"

            // ,nota 2: No considero un campo incompleto cuando se selecciona "sin datos".

            if (dtPacientes.Rows[0][16].ToString() == "-1")
            {
                mensajeFaltanDatosPaciente += "localidad, ";
                datosHellerCompletos = "NO";
            }

            // ,nota: -1 = "Seleccionar"
            //        0 = "Sin datos"

            // ,nota 2: No considero un campo incompleto cuando se selecciona "sin datos".

            if (dtPacientes.Rows[0][18].ToString() == "-1")
            {
                mensajeFaltanDatosPaciente += "provincia de nacimiento, ";
                datosHellerCompletos = "NO";
            }

            // ,nota: Si alguno de los teléfonos (fijo o celular) es vacío, debo asignarle un 0. A pedido del Heller.

            if (dtPacientes.Rows[0][22].ToString() == "")
            { 
                // update en la base, asigno un 0
                // ,nota: Forma de ejecutar un sp que no devuelve valores, solo hace update de un registro en la base
                SPs.TupUpdateTelefonoFijo(int.Parse(Request["idPaciente"].ToString())).Execute();
            }

            if (dtPacientes.Rows[0][23].ToString() == "")
            {
                // update en la base, asigno un 0
                // ,nota: Forma de ejecutar un sp que no devuelve valores, solo hace update de un registro en la base
                SPs.TupUpdateTelefonoCelular(int.Parse(Request["idPaciente"].ToString())).Execute();
            }   

            // ,nota: -1 = "Seleccionar"
            //        0 = "Sin datos"

            // ,nota 2: No considero un campo incompleto cuando se selecciona "sin datos".

            if (dtPacientes.Rows[0][24].ToString() == "-1")
            {
                mensajeFaltanDatosPaciente += "provincia del domicilio, ";
                datosHellerCompletos = "NO";
            }

            Session["turnosProtegidos_mensajeFaltanDatosPaciente"] = mensajeFaltanDatosPaciente + "). Click en este mensaje para cargar los datos faltantes (se abre una nueva pestaña en el navegador).";

            if (datosHellerCompletos == "NO")
            {
                hlCargarDatosPaciente.Visible = true;
                hlCargarDatosPaciente.Text = Session["turnosProtegidos_mensajeFaltanDatosPaciente"].ToString().Trim();
                hlCargarDatosPaciente.Target = "_blank";
                hlCargarDatosPaciente.NavigateUrl = "~/Paciente/PacienteEdit.aspx?id=" + Session["turnosProtegidos_idPaciente"].ToString().Trim();
            }
        }

        // -----------------------------------------------------------------------------------------------------------------

        protected void ibVerDatos_Click(object sender, ImageClickEventArgs e)
        {
            gvListaAgendas.Visible = true;

            // -----------------------------------------------------------------
            // Verifico que se completen los campos
            // -----------------------------------------------------------------

            if ((int.Parse(ddlEspecialidad.SelectedValue) == 0) || (int.Parse(ddlProfesional.SelectedValue) == 0))
            {
                hayError = "SI";
                Response.Write("<script language=javascript>alert('Debe completar todos los campos con (*)');</script>");
            }

            if ((ddlEfectorHabilitado.SelectedValue.ToString() == "221") && ((txtFechaInicio.Value == "") || (txtFechaFin.Value == ""))) // H. Heller
            {
                hayError = "SI";
                Response.Write("<script language=javascript>alert('Debe completar todos los campos con (*)');</script>");            
            }

            // -----------------------------------------------------------------
            // Verifico que la fecha de inicio sea menor que la fecha de fin
            // -----------------------------------------------------------------

            if (hayError == "NO")
            {

                if (ddlEfectorHabilitado.SelectedValue.ToString().Trim() == "221") // 221: id del H. Heller
                {
                    if ((DateTime.Parse(txtFechaInicio.Value) > DateTime.Parse(txtFechaFin.Value)))
                    {
                        hayError = "SI";
                        Response.Write("<script language=javascript>alert('La fecha de inicio debe ser menor a la fecha de fin');</script>");
                    }                        

                    // -----------------------------------------------------------------
                    // Verifico que el rango de fechas no supere los dos meses
                    // -----------------------------------------------------------------            

                    DateTime fechaInicio, fechaFin;
                    TimeSpan diferencia;

                    fechaInicio = DateTime.Parse(txtFechaInicio.Value);
                    fechaFin = DateTime.Parse(txtFechaFin.Value);

                    diferencia = fechaFin - fechaInicio;

                    if (diferencia.Days > 60)
                    {
                        hayError = "SI";
                        Response.Write("<script language=javascript>alert('El rango de fehas no puede superar los dos meses');</script>");
                    }            

                    // -----------------------------------------------------------------
                    // ¿ Datos completos ? (para H. Heller)
                    // -----------------------------------------------------------------

                    //        // ,nota:
                    //        // H. Heller: Hay una exigencia desde este hospital para que ciertos campos no esten vacíos (por políticas internas
                    //        // no se puede insertar en su base de datos un paciente al que le falte alguno de esos datos).

                    if (hayError == "NO")
                    {
                        verificarPacienteDatosCompletosHeller();                    
                    }
                }

                Session["TurnosProtegidos_DatosPaciente"] = lblDatosPaciente.Text;
                Session["TurnosProtegidos_OtrosDatos"] = "Efector: " + ddlEfectorHabilitado.SelectedItem + " </br>" + "Especialidad: " + ddlEspecialidad.SelectedItem.Text + " </br>" + "Profesional: " + ddlProfesional.SelectedItem.Text + " </br>" + "Fechas: " + txtFechaInicio.Value.ToString() + " - " + txtFechaFin.Value.ToString();
                
                Session["TurnosProtegidos_EfectorHabilitadoId"] = ddlEfectorHabilitado.SelectedValue.ToString();
                Session["TurnosProtegidos_EfectorHabilitadoNombre"] = ddlEfectorHabilitado.SelectedItem.ToString();
              

                Session["TurnosProtegidos_idExternoEspecialidad"] = ddlEspecialidad.SelectedValue.ToString();
                Session["TurnosProtegidos_nombreEspecialidad"] = ddlEspecialidad.SelectedItem.ToString();

                Session["TurnosProtegidos_idExternoProfesional"] = ddlProfesional.SelectedValue.ToString();
                Session["TurnosProtegidos_nombreProfesional"] = ddlProfesional.SelectedItem.ToString();
                
                cargarLista();            
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void ddlEfectorHabilitado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEspecialidad.Items.Clear();
            ddlProfesional.Items.Clear();

            txtFechaInicio.Value = DateTime.Now.ToString("dd/MM/yyyy");  // Fecha por defecto.
            if (ddlEfectorHabilitado.SelectedValue.ToString() == "221") // H. Heller
            {
                pnlFechas.Visible = true;
            }
            else // Distinto de H. Heller
            {
                pnlFechas.Visible = false;
            }

            txtFechaFin.Value = "";

            gvListaAgendas.Visible = false;

            cargarComboEspecialidad();
        }

        // ---------------------------------------------------------------------------------------------------------------------------
    }
}