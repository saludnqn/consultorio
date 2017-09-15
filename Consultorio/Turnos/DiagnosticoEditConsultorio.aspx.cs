using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using Consultorio.Utilidades;
using SubSonic;
using Salud.Security.SSO;
using System.Text;
using CrystalDecisions.Web;
using System.IO;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Net;
using System.Web.Script.Serialization;

namespace Consultorio.Turnos
{

    /// <summary>
    ///  Comentario para subir de nuevo
    /// </summary>
    public partial class DiagnosticoEditConsultorio : System.Web.UI.Page
    {
        public CrystalReportSource oCr = new CrystalReportSource();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;
        }

        private DataTable dtGrilla
        {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        private int idConsulta
        {
            get { return ViewState["idConsulta"] == null ? 0 : Convert.ToInt32(ViewState["idConsulta"]); }
            set { ViewState["idConsulta"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreventingDoubleSubmit(btnGuardar);

                int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                ConAgenda ag = new ConAgenda(idAgenda);
                SysProfesional p = new SysProfesional(ag.IdProfesional);
                string especialidad = "";
                llenarCombos();

                try
                {
                    //cargamos sesiones para levantar las interconsultas
                    DataTable dtTipoUsuario = new DataTable();
                    dtTipoUsuario = SPs.IcoObtenerTipoUsuario(SSOHelper.CurrentIdentity.Id).GetDataSet().Tables[0];
                    string tipoUsuario = dtTipoUsuario.Rows[0].ItemArray[2].ToString().Trim();

                    Session["Interconsultas_TipoUsuario"] = tipoUsuario;
                    Session["llamadaExterna"] = "SI"; // ,nota: Esta variable de sesión dse utiliza en "Interconsultas".
                }
                catch (Exception ex)
                {
                }
                ///
                if (ag.IdEspecialidad > 0)
                {
                    SysEspecialidad oEspecialidad = new SysEspecialidad(ag.IdEspecialidad);
                    especialidad = oEspecialidad.Nombre;
                }

                if (ag.Multiprofesional == true)
                {
                    ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                            .From(Schemas.ConAgendaProfesional).InnerJoin(Schemas.SysProfesional)
                            .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                            .ExecuteAsCollection<ConAgendaProfesionalCollection>();

                    List<string> listaProfesionales = new List<string>();

                    foreach (ConAgendaProfesional data in listaAgendaProfesional)
                    {
                        listaProfesionales.Add(data.SysProfesional.NombreCompleto + "- " + data.SysEspecialidad.Nombre + "<br/>");
                    }

                    lblTituloAgenda.Text = especialidad;

                    lstProfesionales.DataSource = listaProfesionales.ToList();
                    lstProfesionales.DataBind();
                }
                else
                    lblTituloAgenda.Text = p.ApellidoyNombre + " - " + especialidad;

                lblFechaAgenda.Text = Rutinas.getNombreDia(ag.Fecha).ToUpper() + " " + ag.Fecha.ToShortDateString();
                lblHoraAgenda.Text = " (" + ag.HoraInicio + " - " + ag.HoraFin + ")";
                actualizarTurnos(idAgenda);
                pnlHola.Visible = true;
                pnlDiagnostico.Visible = false;

                if (Request["idTurno"] != null)
                {
                    int idTurno = Convert.ToInt32(Request.QueryString["idTurno"]);
                    if (idTurno > 0) mostrarTurno(idTurno);
                }
            }
        }

        private void PreventingDoubleSubmit(Button button)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("if (typeof(Page_ClientValidate) == ' ') { ");
            sb.Append("var oldPage_IsValid = Page_IsValid; var oldPage_BlockSubmit = Page_BlockSubmit;");
            sb.Append("if (Page_ClientValidate('" + button.ValidationGroup + "') == false) {");
            sb.Append(" Page_IsValid = oldPage_IsValid; Page_BlockSubmit = oldPage_BlockSubmit; return false; }} ");
            sb.Append("this.value = 'Procesando...';");
            sb.Append("this.disabled = true;");
            sb.Append(ClientScript.GetPostBackEventReference(button, null) + ";");
            sb.Append("return true;");

            string submit_Button_onclick_js = sb.ToString();
            button.Attributes.Add("onclick", submit_Button_onclick_js);
        }


        public void llenarCombos()
        {
            ddlNivelDeAbordaje.DataValueField = "idNivelDeAbordaje";
            ddlNivelDeAbordaje.DataTextField = "nombre";
            ddlNivelDeAbordaje.DataSource = ConNivelDeAbordaje.FetchAll();
            ddlNivelDeAbordaje.DataBind();
            ddlNivelDeAbordaje.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlTipoPrestacion.DataValueField = "idTipoPrestacion";
            ddlTipoPrestacion.DataTextField = "nombre";
            ddlTipoPrestacion.DataSource = ConTipoDePrestacionSaludMental.FetchAll();
            ddlTipoPrestacion.DataBind();
            ddlTipoPrestacion.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlTiempoInsumido.DataValueField = "idTiempoInsumido";
            ddlTiempoInsumido.DataTextField = "nombre";
            ddlTiempoInsumido.DataSource = ConTiempoInsumido.FetchAll();
            ddlTiempoInsumido.DataBind();
            ddlTiempoInsumido.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlDemanda.DataValueField = "idDemanda";
            ddlDemanda.DataTextField = "nombre";
            ddlDemanda.DataSource = ConDemanda.FetchAll();
            ddlDemanda.DataBind();
            ddlDemanda.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            DataTable dtEquipo = new DataTable();
            dtEquipo = SPs.ConCargarComboEquipos().GetDataSet().Tables[0];
            ddlEquipo.DataSource = dtEquipo;
            ddlEquipo.DataBind();

            // ,nota: Si tengo solo un equipo lo cargo por defecto en el combo
            if (dtEquipo.Rows.Count == 1)
            {
                ddlEquipo.SelectedValue = dtEquipo.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                ddlEquipo.Items.Insert(0, new ListItem("--Seleccione--", "0"));
            }
        }

        private void actualizarTurnos(int idAgenda)
        {
            //Carga los turnos de la agenda
            ConAgenda oAgenda = new ConAgenda(idAgenda);

            SysProfesional oProfesional = new SysProfesional(oAgenda.IdProfesional);

            dtGrilla = construirTurnos(idAgenda);
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.DataBind();
            gvTurnos.Visible = true;
        }

        private DataTable getTurnoscompaniantes(int idTurnoAcompaniante)
        {
            DataTable dt = SPs.ConTurnosAcompaniante(idTurnoAcompaniante).GetDataSet().Tables[0];

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                int idTurno = Convert.ToInt32(dt.Rows[i]["idTurno"]);
                int idTurnoEstado = Convert.ToInt32(dt.Rows[i]["idTurnoEstado"]);

                /// si el estado es reservado chequeo caducidad de reserva
                if (idTurno > 0 & idTurnoEstado == 2)
                {
                    ConTurno t = new ConTurno(idTurno);
                    ConTurnoReserva res = t.ConTurnoReservaRecords.Last<ConTurnoReserva>();

                    DateTime fcaducidad = res.ReservaHasta;
                    if (fcaducidad <= DateTime.Now)
                    {
                        /// venció reserva
                        res.CofirmoTurno = false;
                        res.Save();

                        /// en forma lógica omito leer el paciente que reservaba el turno (luego se pisan los datos del paciente)
                        dt.Rows[i]["idPaciente"] = 0;
                        dt.Rows[i]["idTurnoEstado"] = 1;
                        dt.Rows[i]["Estado"] = "Activo";
                        dt.Rows[i]["DNI"] = "0";
                        dt.Rows[i]["HC"] = "0";
                        dt.Rows[i]["Paciente"] = "";
                        dt.AcceptChanges();
                    }
                }
            }
            return dt;
        }
        private DataTable getTurnosPorAgenda(int idAgenda)
        {
            DataTable dt = SPs.ConTurnosPorAgenda(idAgenda).GetDataSet().Tables[0];

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                int idTurno = Convert.ToInt32(dt.Rows[i]["idTurno"]);
                int idTurnoEstado = Convert.ToInt32(dt.Rows[i]["idTurnoEstado"]);

                /// si el estado es reservado chequeo caducidad de reserva
                if (idTurno > 0 & idTurnoEstado == 2)
                {
                    ConTurno t = new ConTurno(idTurno);
                    ConTurnoReserva res = t.ConTurnoReservaRecords.Last<ConTurnoReserva>();

                    DateTime fcaducidad = res.ReservaHasta;
                    if (fcaducidad <= DateTime.Now)
                    {
                        /// venció reserva
                        res.CofirmoTurno = false;
                        res.Save();

                        /// en forma lógica omito leer el paciente que reservaba el turno (luego se pisan los datos del paciente)
                        dt.Rows[i]["idPaciente"] = 0;
                        dt.Rows[i]["idTurnoEstado"] = 1;
                        dt.Rows[i]["Estado"] = "Activo";
                        dt.Rows[i]["DNI"] = "0";
                        dt.Rows[i]["HC"] = "0";
                        dt.Rows[i]["Paciente"] = "";
                        dt.AcceptChanges();
                    }
                }
            }
            return dt;
        }

        private DataTable construirTurnos(int idAgenda)
        {
            ConAgenda ag = new ConAgenda(idAgenda);
            DataTable dt = getTurnosPorAgenda(idAgenda);

            DateTime fecha = ag.Fecha;
            int duracion = ag.Duracion;
            //  int reserva = ag.Reservados;
            int maxSbts = ag.MaximoSobreturnos;
            string hIni = ag.HoraInicio;
            string hFin = ag.HoraFin;
            string hora = hIni;

            //DateTime hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            //DateTime horafin1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hFin);


            //do
            //{
            //    if (!existeHoraEnDataTable(dt, hora))
            //    {
            //        insertarDataRow(dt, fecha, hora, idAgenda);
            //    }
            //    hora = incrementarHora(hora, duracion);
            //    hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            //} while (!(hora1 >= horafin1));

            dt = Rutinas.getDataTableOrdenado(dt, "Fecha, Hora");

            return dt;
        }

        private bool existeHoraEnDataTable(DataTable dt, string hora)
        {
            bool existe = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string horaDt = Convert.ToString(dt.Rows[i]["Hora"]);
                if (hora == horaDt) { existe = true; break; }
            }
            return existe;
        }

        private string incrementarHora(string Hora, int duracion)
        {
            string h = Hora.Substring(0, 2);
            string m = Hora.Substring(3, 2);
            int horas = Convert.ToInt32(h);
            int minutos = Convert.ToInt32(m);

            minutos += duracion;
            while (minutos >= 60)
            {
                horas += 1;
                minutos -= 60;
            }
            m = minutos.ToString();
            h = horas.ToString();
            if (m.Length < 2) { m = "0" + m; }
            if (h.Length < 2) { h = "0" + h; }

            return h + ":" + m;
        }

        private void insertarDataRow(DataTable dt, DateTime f, string hora, int idAgenda)
        {
            /// inserto en dataset un fila en blanco para la fecha generada
            ConAgenda ag = new ConAgenda(idAgenda);

            DataRow newRow;
            newRow = dt.NewRow();
            newRow["idTurno"] = 0;
            newRow["Sobreturno"] = false;
            newRow["Fecha"] = ag.Fecha.ToString().Substring(0, 10);
            newRow["Hora"] = hora;
            newRow["idPaciente"] = 0;
            newRow["idTurnoEstado"] = 1;
            newRow["Estado"] = "Activo";
            newRow["DNI"] = "0";
            newRow["HC"] = "0";
            newRow["Paciente"] = "";
            newRow["TipoTurno"] = "";
            newRow["Asistencia"] = "0";

            ConTurnoBloqueo r = new Select().From(Schemas.ConTurnoBloqueo)
                       .Where(ConTurnoBloqueo.Columns.IdAgenda).IsEqualTo(idAgenda)
                       .And(ConTurnoBloqueo.Columns.FechaTurno).IsEqualTo(ag.Fecha)
                       .And(ConTurnoBloqueo.Columns.HoraTurno).IsEqualTo(hora)
                       .ExecuteSingle<ConTurnoBloqueo>();

            if (r != null)
                newRow["Estado"] = "Bloqueado";
            else
                newRow["Estado"] = "Activo";

            dt.Rows.Add(newRow);

        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = gvTurnos.SelectedRow.RowIndex;
            if (Request["Tipo"] != null)
            {
                Response.Redirect("DiagnosticoEditConsultorio.aspx?idAgenda=" + Convert.ToInt32(Request.QueryString["idAgenda"]) + "&Tipo=Atencion&idTurno=" + Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]), false);
            }
            else
            {
                Session["idTurnoSeleccionado"] = dtGrilla.Rows[i]["idTurno"].ToString();
                Response.Redirect("DiagnosticoEditConsultorio.aspx?idAgenda=" + Convert.ToInt32(Request.QueryString["idAgenda"]) + "&idTurno=" + Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]), false);            
            }
        }

        private void mostrarTurno(int idTurno)
        {

            //    if (Request["Tipo"] != null)
            //    {                //pnlAtencion.Visible = true;
            //        pnlModulos.Visible = true;
            //    }
            //    else
            //    {                //pnlAtencion.Visible = false;
            //        pnlModulos.Visible = false;
            //    }

            pnlHola.Visible = false;
            pnlDiagnostico.Visible = true;
            ConTurno t = new ConTurno(idTurno);
            lblPaciente.Text = t.SysPaciente.NumeroDocumento.ToString() + " " + t.SysPaciente.Apellido + " " + t.SysPaciente.Nombre;
            lblFechaNacimiento.Text = "Fecha de Nacimiento: " + t.SysPaciente.FechaNacimiento.ToShortDateString();
            HfidPaciente.Value = t.IdPaciente.ToString();
            HfDNI.Value = t.SysPaciente.NumeroDocumento.ToString();

            DateDifference oEdad = new DateDifference(t.SysPaciente.FechaNacimiento, t.Fecha);
            if (oEdad.Years > 0)
                lblFechaNacimiento.Text += " - Edad: " + oEdad.Years.ToString() + " años";
            else
            {
                if (oEdad.Months > 0)
                    lblFechaNacimiento.Text += " - Edad: " + oEdad.Months.ToString() + " meses";
                else
                    if (oEdad.Days > 0)
                        lblFechaNacimiento.Text += " - Edad: " + oEdad.Days.ToString() + " días";
            }
            lblIdTurno.Text = idTurno.ToString();

            dtHistorial.DataSource = SPs.ConGetTurnosPacientes(t.Fecha.ToString("yyyyMMdd"), t.SysPaciente.IdPaciente, 1).GetDataSet();
            dtHistorial.DataBind();


            /// salud mental
            if ((t.ConAgenda.IdEspecialidad == 50) || (t.ConAgenda.IdEspecialidad == 52) || (t.ConAgenda.IdEspecialidad == 25))
            {   /////control de codigo para mostrar o no los acompañantes terapeuticos
                if (t.IdTurnoAcompaniante > 0)
                {
                    ConTurno t2 = new ConTurno(t.IdTurnoAcompaniante);
                    lblPacienteAcompaniante.Text = "Acompañante de " + t2.SysPaciente.NumeroDocumento.ToString() + " " + t2.SysPaciente.Apellido + " " + t2.SysPaciente.Nombre;
                    btnVolverPacientePrincipal.ID = t.IdTurnoAcompaniante.ToString();
                    btnAgregarAcompañante.Visible = false;
                    btnVolverPacientePrincipal.Visible = true;
                    demanda.Visible = false;
                    nivelDeAbordaje.Visible = false;
                    tiempoInsumido.Visible = false;
                    tipoPrestacion.Visible = false;
                    recursoHumano.Visible = false;
                }
                else
                    lblPacienteAcompaniante.Text = "";

            }
            /// fin de salud mental
            ///   if (t.ConAgenda.IdEspecialidad==49) /// ecografia
            if (t.ConAgenda.IdEspecialidad == 49) /// ecografia
            {
                tdMotivoConsulta.Visible = true;
                tdDiagnosticoSecundario.Visible = false;
                tdDatosControl.Visible = false;
                tdEquipo.Visible = true;
            }

            MostrarConsulta(idTurno);



            //me fijo la edad para habilitar campos
            ///Habilito carga RCVG para mayores de 18 años
            if (oEdad.Years >= 18)
            {
                lblRCVG.Visible = true;
                ddlRCVG.Visible = true;
                //txtRCVG.Visible = true;
            }
            else
            {
                lblRCVG.Visible = false;
                ddlRCVG.Visible = false;
                //txtRCVG.Visible = false;
            }
            ///Habilito carga perimetro cefalico para menores de 3 años
            if (oEdad.Years <= 3)
            {
                lblPC.Visible = true;
                txtPerimetro.Visible = true;
            }
            else
            {
                txtPerimetro.Visible = false;
                lblPC.Visible = false;
            }

            ConsultorioPaciente1.HabilitarBotonesConsulta(t.SysPaciente, idTurno);
            //HabilitarBotonesConsulta(t.SysPaciente);

            actualizarTurnosAcompaniantes(idTurno);

        }

        private void actualizarTurnosAcompaniantes(int idTurno)
        {
            DataTable dt = getTurnoscompaniantes(idTurno);
            gvTurnosAcompaniante.DataSource = dt;
            gvTurnosAcompaniante.DataBind();
            gvTurnosAcompaniante.Visible = true;
        }

        private void MostrarConsulta(int idTurno)
        {
            ConTurno t = new ConTurno(int.Parse(lblIdTurno.Text));
            ConConsultum oConsulta = new SubSonic.Select()
              .From(Schemas.ConConsultum)
                        .Where(ConConsultum.Columns.IdTurno).IsEqualTo(idTurno)
                          .ExecuteSingle<ConConsultum>();

            imgImprimir.Visible = false;
            if (oConsulta != null)
            {
                if (oConsulta.IdUsuarioRegistro == SSOHelper.CurrentIdentity.Id)
                {
                    btnGuardar.Visible = true;
                }
                else
                {
                    btnGuardar.Visible = false;                
                }

                imgImprimir.Visible = true;
                lblIdConsulta.Text = oConsulta.IdConsulta.ToString();
                txtInformeConsulta.Text = oConsulta.InformeConsulta;
                txtMotivoConsulta.Text = oConsulta.MotivoConsulta;
                ddlEquipo.SelectedValue = oConsulta.IdEquipo.ToString();
                //muestro los datos del control anterior
                txtPeso.Value = oConsulta.Peso.ToString().Replace(",", ".");
                txtTalla.Value = oConsulta.Talla.ToString().Replace(",", ".");
                txtImc.Value = oConsulta.Imc.ToString().Replace(",", ".");
                txtTAS.Value = oConsulta.TAS.ToString().Replace(",", ".");
                if (oConsulta.TAD.ToString().Length >= 5)

                    txtTAD.Value = oConsulta.TAD.ToString().Substring(0, 5).Replace(",", ".");
                else
                    txtTAD.Value = oConsulta.TAD.ToString().Replace(",", ".");

                //string.Format("{0:0.00}",txtTAD.Value);
                txtPerimetro.Value = oConsulta.PerimetroCefalico.ToString().Replace(",", ".");
                ddlRCVG.SelectedValue = oConsulta.RiesgoCardiovascular.ToString().Replace(",", ".");
                //txtRCVG.Value = oConsulta.RiesgoCardiovascular.ToString().Replace(",", ".");

                ConConsultaDiagnosticoCollection tempDiagSec = new ConConsultaDiagnosticoCollection();

                foreach (ConConsultaDiagnostico oDiagnostico in oConsulta.ConConsultaDiagnosticoRecords)
                {
                    if (oDiagnostico.Principal.GetValueOrDefault(false))
                    {
                        //Linea comentada para probar el UserControl *************Descomentar************** 05/12/2013
                        DiagnosticoPrincipal1.setDiagnosticoPrincipal(oDiagnostico.CODCIE10.GetValueOrDefault(0));
                        ddlPrimerConsulta.SelectedValue = oDiagnostico.PrimerConsulta.ToString();
                        ddlNivelDeAbordaje.SelectedValue = oDiagnostico.IdNivelDeAbordaje.ToString();
                        ddlTipoPrestacion.SelectedValue = oDiagnostico.IdTipoPrestacionSaludMental.ToString();
                        ddlTiempoInsumido.SelectedValue = oDiagnostico.IdTiempoInsumido.ToString();
                        txtRHInterviniente.Text = oDiagnostico.RecursoHumano;
                        ddlDemanda.SelectedValue = oDiagnostico.IdDemanda.ToString();
                    }
                    else
                    {
                        tempDiagSec.Add(oDiagnostico);
                    }
                }
                DiagnosticoSecundario1.setDiagnosticos(tempDiagSec);

                //   pnlInterConsulta.Enabled = true;

            }

            else
            {
                lblIdConsulta.Text = "0";
                //  DiagnosticoPrincipal1.Controls.Clear();
                ddlPrimerConsulta.SelectedValue = "-1";

                // pnlInterConsulta.Enabled = false;
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string hayError = "NO";

                // Si se trata de una ecografía, debo verificar que se cargue un equipo.
                ConTurno t = new ConTurno(int.Parse(Request["idTurno"].ToString()));
                if (t.ConAgenda.IdEspecialidad == 49)  // 49: Ecografía
                {
                    if (ddlEquipo.SelectedValue.ToString() == "0")
                    {
                        hayError = "SI";
                        lblFaltaEquipo.Text = "Debe seleccionar el equipo utilizado";
                    }
                    else
                    {
                        lblFaltaEquipo.Text = "";
                    }
                }

                if (hayError == "NO")
                {
                    int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                    //    grabarAsistencia();
                    GuardarDiagnosticos();

                    if (Request["Tipo"] != null)
                        Response.Redirect("DiagnosticoEditConsultorio.aspx?idAgenda=" + idAgenda + "&Tipo=Atencion", false);
                    else
                        Response.Redirect("DiagnosticoEditConsultorio.aspx?idAgenda=" + idAgenda, false);
                }
            }
            else
            {
                //Agregamos estos errores para poder detectar en TEST problemas por falta de feedback
                lblFaltaEquipo.Text = "Esta página no es válida, verificar los campos cargados";
            }
        }

        //private void grabarAsistencia()
        //{
        //    ConTurnoAsistencium asist = new ConTurnoAsistencium();
        //    asist.IdTurno = int.Parse(lblIdTurno.Text); //Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
        //    asist.FechaAsistencia = DateTime.Now;
        //    asist.IdUsuario = SSOHelper.CurrentIdentity.Id;
        //    asist.Save();
        //}

        private void GuardarDiagnosticos()
        {
            ConTurno t = new ConTurno(int.Parse(lblIdTurno.Text));

            //graba la asistencia
            ConTurnoAsistencium asist = new ConTurnoAsistencium();
            asist.IdTurno = t.IdTurno;
            asist.FechaAsistencia = DateTime.Now;
            asist.IdUsuario = SSOHelper.CurrentIdentity.Id;
            asist.Save();
            ///
            ConConsultum oConsulta = new ConConsultum(int.Parse(lblIdConsulta.Text));

            oConsulta.Fecha = t.Fecha;
            oConsulta.Hora = t.Hora;
            oConsulta.IdTurno = int.Parse(lblIdTurno.Text);
            oConsulta.IdPaciente = t.IdPaciente;

            oConsulta.IdProfesional = t.ConAgenda.IdProfesional;
            oConsulta.IdEspecialidad = t.ConAgenda.IdEspecialidad;
            oConsulta.IdTipoPrestacion = t.ConAgenda.IdTipoPrestacion;

            oConsulta.MotivoConsulta = "";
            oConsulta.InformeConsulta = txtInformeConsulta.Text;
            oConsulta.MotivoConsulta = txtMotivoConsulta.Text;

            // Si se trata de una ecografía, guardo el id del equipo.            
            if (t.ConAgenda.IdEspecialidad == 49)  // 49: Ecografía
            {
                oConsulta.IdEquipo = int.Parse(ddlEquipo.SelectedValue);
            }

            //Datos del control
            if (txtPeso.Value != "")
                oConsulta.Peso = decimal.Parse(txtPeso.Value, System.Globalization.CultureInfo.InvariantCulture);
            if (txtTalla.Value != "")
                oConsulta.Talla = decimal.Parse(txtTalla.Value, System.Globalization.CultureInfo.InvariantCulture);
            if (txtImc.Value != "")
                oConsulta.Imc = decimal.Parse(txtImc.Value, System.Globalization.CultureInfo.InvariantCulture);
            if (txtTAS.Value != "")
                oConsulta.TAS = int.Parse(txtTAS.Value, System.Globalization.CultureInfo.InvariantCulture);
            if (txtTAD.Value != "")
                oConsulta.TAD = decimal.Parse(txtTAD.Value, System.Globalization.CultureInfo.InvariantCulture);
            //if (txtRCVG.Value != "")
            if (ddlRCVG.SelectedValue != "-1")
                oConsulta.RiesgoCardiovascular = int.Parse(ddlRCVG.SelectedValue);
            //oConsulta.RiesgoCardiovascular = int.Parse(txtRCVG.Value, System.Globalization.CultureInfo.InvariantCulture);
            if (txtPerimetro.Value != "")
                oConsulta.PerimetroCefalico = decimal.Parse(txtPerimetro.Value, System.Globalization.CultureInfo.InvariantCulture);
            // Buscamos el usuario.

            // Guardamos las cositas que faltaban.
            oConsulta.IdUsuarioRegistro = SSOHelper.CurrentIdentity.Id;
            oConsulta.IdEfector = SSOHelper.CurrentIdentity.IdEfector;

            SysPaciente oPaciente = new SysPaciente(t.IdPaciente);
            if (oPaciente != null) oConsulta.IdObraSocial = oPaciente.IdObraSocial;

            using (TransactionScope ts = new TransactionScope())
            {
                using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                {
                    try
                    {
                        oConsulta.Save();


                        BorrarDiagnosticos(oConsulta);

                        ConConsultaDiagnostico oDiagnostico = new ConConsultaDiagnostico();
                        oDiagnostico.IdConsulta = oConsulta.IdConsulta;
                        oDiagnostico.IdEfector = oConsulta.IdEfector.Value;
                        oDiagnostico.CODCIE10 = DiagnosticoPrincipal1.getDiagnostico();
                        oDiagnostico.Principal = true;
                        oDiagnostico.PrimerConsulta = int.Parse(ddlPrimerConsulta.SelectedValue);
                        oDiagnostico.IdNivelDeAbordaje = int.Parse(ddlNivelDeAbordaje.SelectedValue);
                        oDiagnostico.IdTipoPrestacionSaludMental = int.Parse(ddlTipoPrestacion.SelectedValue);
                        oDiagnostico.IdTiempoInsumido = int.Parse(ddlTiempoInsumido.SelectedValue);
                        oDiagnostico.IdDemanda = int.Parse(ddlDemanda.SelectedValue);
                        oDiagnostico.RecursoHumano = txtRHInterviniente.Text;

                        oDiagnostico.Save();

                        //oConsulta.ConConsultaDiagnosticoRecords.SaveAll();
                        //oConsulta.ConConsultaMedicamentoRecords.SaveAll();

                        try
                        {
                            string[] oDiagnosticos = DiagnosticoSecundario1.getDiagnosticos().Split(',');
                            if (oDiagnosticos.Length > 0)
                            {
                                foreach (string sDiagnosticoSecundario in oDiagnosticos)
                                {
                                    string[] sDiagnosticoSecundarioNotificacion = sDiagnosticoSecundario.Split(';');
                                    if (sDiagnosticoSecundarioNotificacion.Length > 0)
                                    {
                                        string sidDiasgnostico = sDiagnosticoSecundarioNotificacion[0].ToString();
                                        string snotificacion = sDiagnosticoSecundarioNotificacion[1].ToString();
                                        if (sidDiasgnostico.Length > 0)
                                        {
                                            int idDiagnostico;
                                            if (Int32.TryParse(sidDiasgnostico, out idDiagnostico))
                                            {
                                                ConConsultaDiagnostico oDiagnosticoSecundario = new ConConsultaDiagnostico();
                                                oDiagnosticoSecundario.IdConsulta = oConsulta.IdConsulta;
                                                oDiagnosticoSecundario.Principal = false;
                                                oDiagnosticoSecundario.CODCIE10 = idDiagnostico;
                                                oDiagnosticoSecundario.IdEfector = oConsulta.IdEfector.Value;
                                                oDiagnosticoSecundario.PrimerConsulta = int.Parse(snotificacion);
                                                oDiagnostico.IdNivelDeAbordaje = int.Parse(ddlNivelDeAbordaje.SelectedValue);
                                                oDiagnostico.IdTipoPrestacionSaludMental = int.Parse(ddlTipoPrestacion.SelectedValue);
                                                oDiagnostico.IdTiempoInsumido = int.Parse(ddlTiempoInsumido.SelectedValue);
                                                oDiagnostico.IdDemanda = int.Parse(ddlDemanda.SelectedValue);
                                                oDiagnostico.RecursoHumano = txtRHInterviniente.Text;
                                                oDiagnosticoSecundario.Save();
                                            }
                                            else
                                            {
                                                //oResultado.Estado = MessageStatus.error;
                                                //oResultado.mensaje.Add("Unos de los codigo de diagnostico secundario no se reconoce.");
                                            }
                                        }
                                    }
                                } ///foreach
                            }
                        }
                        catch (Exception ex)
                        {
                            //Agregamos el error aca para probar TEST
                            lblFaltaEquipo.Text = "Error 750 al guardar: " + ex.Message;
                        }
                        ts.Complete();



                        //Master.Message("La consulta se guardo con exito.", MessageStatus.ok);
                    }
                    catch (Exception ex)
                    {
                        ts.Dispose();
                        List<string> m = new List<string>();
                        while (ex != null)
                        {
                            m.Add(ex.Message);
                            ex = ex.InnerException;
                        }
                        //   Master.Message(MessageStatus.error, "Error al guardar", m);

                        //Agregamos el error aca para probar TEST
                        lblFaltaEquipo.Text = "Error 700 al guardar: " + m;
                    }
                }
            }

        }
        private void Imprimir(string filtro, string nombreArchivo, int especialidad)
        {
            string informe = "../Informes/ConsultorioPaciente.rpt";
            string s_titulo = "ATENCION DE CONSULTORIO";
            if (especialidad == 49) //ecografia
            {
                s_titulo = "ECOGRAFIA";
                informe = "../Informes/ConsultorioPacienteEcografia.rpt";
            }

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = s_titulo;


            DataTable dt = SPs.ConGetAtencionPacientes(filtro).GetDataSet().Tables[0];
            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);
            oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);
            oCr.DataBind();

            MemoryStream oStream;
            oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nombreArchivo + ".pdf");


            Response.BinaryWrite(oStream.ToArray());
            Response.End();

        }


        private void BorrarDiagnosticos(ConConsultum oConsulta)
        {
            Query i = new Query(Schemas.ConConsultaDiagnostico);
            i.QueryType = QueryType.Delete;
            i.WHERE(ConConsultaDiagnostico.Columns.IdConsulta, oConsulta.IdConsulta);
            i.Execute();
        }

        private void mostrarSaludMental(int idAgenda)
        {

            ConAgenda agenda = ConAgenda.FetchByID(idAgenda);

            if ((agenda.IdEspecialidad == 50) || (agenda.IdEspecialidad == 52) || (agenda.IdEspecialidad == 25))
            {///Salud Mental
                contenedorSaludMental.Height = "1000px";
                demanda.Visible = true;
                nivelDeAbordaje.Visible = true;
                tiempoInsumido.Visible = true;
                tipoPrestacion.Visible = true;
                recursoHumano.Visible = true;

                rvDemanda.Enabled = true;
                rvNivelAbordaje.Enabled = true;
                rvTiempoInsumido.Enabled = true;
                rvTipoPrestacion.Enabled = true;


                lblPacienteAcompaniante.Visible = true;
                btnAgregarAcompañante.Visible = true;
                btnVolverPacientePrincipal.Visible = false;

                tdDatosControl.Visible = false;

            }
        }

        private void mostrarEcografia(int idAgenda)
        {
            ConAgenda agenda = ConAgenda.FetchByID(idAgenda);

            if (agenda.IdEspecialidad == 49)
            {///Salud Mental
                //  contenedorSaludMental.Height = "1000px";
                tdDatosControl.Visible = false;
                tdDiagnosticoSecundario.Visible = true;
                tdEquipo.Visible = true;
                tdMotivoConsulta.Visible = true;
                rfvMotivoConsulta.Enabled = true;

            }
        }
        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton cmdSelTurno = (ImageButton)e.Row.FindControl("cmdSelTurno");
                Image imgTurno = (Image)e.Row.FindControl("imgTurno");
                Image imgConsulta = (Image)e.Row.FindControl("imgConsulta");
                string Estado = dtGrilla.Rows[e.Row.RowIndex]["Estado"].ToString();
                string Consulta = dtGrilla.Rows[e.Row.RowIndex]["Consulta"].ToString();
                string Asistencia = dtGrilla.Rows[e.Row.RowIndex]["Asistencia"].ToString();

                contenedorSaludMental.Height = "300px";
                tdVacio_1.Visible = false;
                tdVacio_2.Visible = false;
                tdVacio_3.Visible = false;
                tdVacio_4.Visible = false;
                tdVacio_5.Visible = false;
                tdVacio_6.Visible = false;
                demanda.Visible = false;
                nivelDeAbordaje.Visible = false;
                tiempoInsumido.Visible = false;
                tipoPrestacion.Visible = false;
                recursoHumano.Visible = false;
                lblPacienteAcompaniante.Visible = false;
                btnAgregarAcompañante.Visible = false;
                btnVolverPacientePrincipal.Visible = false;
                tdEquipo.Visible = false;
                tdMotivoConsulta.Visible = false;


                int idAgenda = int.Parse(Request["idAgenda"].ToString());

                mostrarSaludMental(idAgenda);
                mostrarEcografia(idAgenda);

                if ((Asistencia == "1") && (Consulta == "No"))
                {
                    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.LightYellow;
                    }

                    //cmdSelTurno.Visible = false;
                }
                else if (Consulta == "Si")
                {
                    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Gainsboro;
                    }
                }
                else
                {
                    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.White;
                    }
                }


                switch (Estado)
                {
                    case "Activo":
                        {
                            string tipoTurno = dtGrilla.Rows[e.Row.RowIndex]["TipoTurno"].ToString();
                            switch (tipoTurno)
                            {
                                case "":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnoactivo.png";
                                    imgTurno.ToolTip = "Turno activo";
                                    break;
                                case "Turno":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/check_verde16.png";
                                    imgTurno.ToolTip = "Turno del día";
                                    break;
                                case "Programado":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta1.png";
                                    imgTurno.ToolTip = "Turno Anticipado";
                                    break;
                                case "SobreTurno":
                                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta.png";
                                    imgTurno.ToolTip = "Sobre Turno";
                                    break;
                            }
                        } break;
                    case "Bloqueado":
                        {
                            imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnobloqueado.png";
                            imgTurno.ToolTip = "Turno bloqueado";
                        } break;
                }
            }
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            //if (Request["Tipo"] != null)
            //    Response.Redirect("../../Consultorio/AtencionConsultorio/AgendaList.aspx", false);
            //else
            Response.Redirect("../../Consultorio/Agenda/AgendaList.aspx?llamada=consultorio", false);
        }

        protected void cvDiagnostico_ServerValidate(object source, ServerValidateEventArgs args)
        {////verificar que DiagnosticoPrincipal1.getDiagnostico()<>"-1"
            if (DiagnosticoPrincipal1.getDiagnostico() == -1)
                args.IsValid = false;
            else
                args.IsValid = true;
            return;

        }

        protected void imgImprimir_Click(object sender, ImageClickEventArgs e)
        {
            ConConsultum oConsulta = new ConConsultum(int.Parse(lblIdConsulta.Text));
            if (oConsulta != null)
                Imprimir(" Cons.idconsulta = " + oConsulta.IdConsulta.ToString(), lblPaciente.Text.Trim(), oConsulta.IdEspecialidad.Value);
        }

        protected void imgImprimirHistorial_Click(object sender, ImageClickEventArgs e)
        {
            int idTurno = Convert.ToInt32(lblIdTurno.Text);
            ConTurno t = new ConTurno(idTurno);
            if (t != null)
            {
                string informe = "../Informes/ConsultorioPacienteHistorial.rpt";


                string nombreArchivo = lblPaciente.Text.Trim() + "_Historial";

                ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
                encabezado1.Value = "HISTORIAL DE ATENCION DEL PACIENTE";

                DataTable dt = SPs.ConGetTurnosPacientes(DateTime.Now.ToString("yyyyMMdd"), t.IdPaciente, 1).GetDataSet().Tables[0];
                oCr.Report.FileName = informe;
                oCr.ReportDocument.SetDataSource(dt);
                oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);
                oCr.DataBind();

                MemoryStream oStream;
                oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + nombreArchivo + ".pdf");

                Response.BinaryWrite(oStream.ToArray());
                Response.End();
            }
        }



        private string GenerarListaTurnoaImprimir()
        {
            string m_lista = "";
            foreach (GridViewRow row in gvTurnos.Rows)
            {
                if (m_lista == "")
                    m_lista += gvTurnos.DataKeys[row.RowIndex].Value.ToString();
                else
                    m_lista += "," + gvTurnos.DataKeys[row.RowIndex].Value.ToString();

            }
            return m_lista;
        }


        protected void btnImprimirConsultorioCompleto_Click(object sender, EventArgs e)
        {
            ////imprimir el consultorio completo
            string l = GenerarListaTurnoaImprimir();
            Imprimir(" T.idTurno in (" + l + ")", "consultorio", 0);

        }

        protected void btnAgregarAcompañante_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarAcompañante_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TurnoNuevoDefault.aspx?Desde=DiagnosticoEditConsultorio.aspx&idTurnoAcompaniante=" + lblIdTurno.Text, false);
        }

        protected void gvTurnosAcompaniante_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                LinkButton cmdEditar = (LinkButton)e.Row.FindControl("cmdSelTurno0");
                cmdEditar.CommandArgument = gvTurnosAcompaniante.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdEditar.CommandName = "Editar";
                cmdEditar.ToolTip = "Editar";

                ImageButton cmdEliminar = (ImageButton)e.Row.FindControl("cmdEliminarTurno0");
                cmdEliminar.CommandArgument = gvTurnosAcompaniante.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdEliminar.CommandName = "Eliminar";
                cmdEliminar.ToolTip = "Eliminar";



                //ImageButton cmdSelTurno = (ImageButton)e.Row.FindControl("cmdSelTurno");
                Image imgTurno = (Image)e.Row.FindControl("imgTurno0");
                //   Image imgConsulta = (Image)e.Row.FindControl("imgConsulta");
                string Estado = dtGrilla.Rows[e.Row.RowIndex]["Estado"].ToString();
                string Consulta = e.Row.Cells[5].Text;// e.Rows[e.Row.RowIndex]["Consulta"].ToString();
                string Asistencia = dtGrilla.Rows[e.Row.RowIndex]["Asistencia"].ToString();


                //contenedorSaludMental.Height = "1000px";
                //demanda.Visible = false;
                //nivelDeAbordaje.Visible =false;
                //tiempoInsumido.Visible = false;
                //tipoPrestacion.Visible = false;
                //recursoHumano.Visible = false;
                //lblPacienteAcompaniante.Visible = true;
                //btnAgregarAcompañante.Visible = false;

                //if ((Asistencia == "1") && (Consulta == "No"))
                //{
                //    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                //    {
                //        e.Row.Cells[i].BackColor = System.Drawing.Color.LightYellow;
                //    }

                //    cmdSelTurno.Visible = true;
                //}
                //else
                if (Consulta == "Si")
                {
                    for (int i = 0; i < gvTurnosAcompaniante.Columns.Count; i++)
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Gainsboro;

                    //         cmdSelTurno.Visible = true;
                }
                else
                {
                    for (int i = 0; i < gvTurnosAcompaniante.Columns.Count; i++)

                        e.Row.Cells[i].BackColor = System.Drawing.Color.White;

                    //cmdSelTurno.Visible = false;
                }

                //switch (Estado)
                //{
                //    case "Activo":
                //        {
                //            string tipoTurno = dtGrilla.Rows[e.Row.RowIndex]["TipoTurno"].ToString();
                //            switch (tipoTurno)
                //            {
                //                case "":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnoactivo.png";
                //                    imgTurno.ToolTip = "Turno activo";
                //                    break;
                //                case "Turno":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/check_verde16.png";
                //                    imgTurno.ToolTip = "Turno del día";
                //                    break;
                //                case "Programado":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta1.png";
                //                    imgTurno.ToolTip = "Turno Anticipado";
                //                    break;
                //                case "SobreTurno":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta.png";
                //                    imgTurno.ToolTip = "Sobre Turno";
                //                    break;
                //            }
                //        } break;
                //    case "Bloqueado":
                //        {
                //            imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnobloqueado.png";
                //            imgTurno.ToolTip = "Turno bloqueado";
                //        } break;
                //}


            }
        }

        protected void gvTurnosAcompaniante_SelectedIndexChanged(object sender, EventArgs e)
        {



            //int i =gvTurnosAcompaniante.SelectedRow.RowIndex;
            ////if (Request["Tipo"] != null)

            ////    Response.Redirect("DiagnosticoEdit.aspx?idAgenda=" + Convert.ToInt32(Request.QueryString["idAgenda"]) + "&Tipo=Atencion&idTurno=" + Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]), false);
            ////else
            // Response.Redirect("DiagnosticoEdit.aspx?idAgenda=" + Convert.ToInt32(Request.QueryString["idAgenda"]) + "&idTurno=" + Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]), false);
        }

        protected void gvTurnosAcompaniante_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                ConTurno t = new ConTurno(int.Parse(e.CommandArgument.ToString()));
                Response.Redirect("DiagnosticoEditConsultorio.aspx?idAgenda=" + t.IdAgenda.ToString() + "&idTurno=" + t.IdTurno.ToString(), false);

            }

            if (e.CommandName == "Eliminar")
            {
                ///Verificar si no tiene diagnostico cargado

                ConTurno t = new ConTurno(int.Parse(e.CommandArgument.ToString()));
                if (!tienediagnostico(t))
                {
                    t.IdTurnoEstado = 4;
                    t.Save();

                    ConTurno tprincipal = new ConTurno(t.IdTurnoAcompaniante);
                    Response.Redirect("DiagnosticoEditConsultorio.aspx?idAgenda=" + tprincipal.IdAgenda.ToString() + "&idTurno=" + tprincipal.IdTurno.ToString(), false);
                }
                string popupScript = "<script language='JavaScript'> alert('No es posible eliminar. El paciente tiene diagnnosticos cargados'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }

        private bool tienediagnostico(ConTurno t)
        {

            ConConsultumCollection srv = new SubSonic.Select()
               .From(Schemas.ConConsultum)
                         .Where(ConConsultum.Columns.IdTurno).IsEqualTo(t.IdTurno)

                .ExecuteAsCollection<ConConsultumCollection>();

            if (srv.Count > 0) return true;
            else return false;

        }

        protected void btnVolverPacientePrincipal_Click(object sender, EventArgs e)
        {

            ConTurno t = new ConTurno(int.Parse(Request["idTurno"].ToString()));
            Response.Redirect("DiagnosticoEditConsultorio.aspx?idAgenda=" + t.IdAgenda.ToString() + "&idTurno=" + t.IdTurnoAcompaniante.ToString(), false);
            //Response.Redirect("TurnoNuevoDefault.aspx", false);
        }

        protected void dtHistorial_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            ConAgenda agenda = new ConAgenda(int.Parse(dtHistorial.DataKeys[e.Item.ItemIndex].ToString()));//   int.Parse(gvHistorial.DataKeys[e.Row.RowIndex].Value.ToString()));

            ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
    .From(Schemas.ConAgendaProfesional).Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(agenda.IdAgenda)
    .ExecuteAsCollection<ConAgendaProfesionalCollection>();

            DataList innerDataList = e.Item.FindControl("lstProfesionales") as DataList;

            List<string> lista = new List<string>();

            if (agenda.Multiprofesional == true)
            {
                for (int x = 0; x < listaAgendaProfesional.Count; x++)
                {
                    lista.Add(listaAgendaProfesional.ElementAt(x).SysProfesional.NombreCompleto);
                }

                innerDataList.DataSource = lista;
                innerDataList.DataBind();
            }
            else
            {
                lista.Add(agenda.SysProfesional.NombreCompleto);

                innerDataList.DataSource = lista;
                innerDataList.DataBind();
            }
        }
    }
}
