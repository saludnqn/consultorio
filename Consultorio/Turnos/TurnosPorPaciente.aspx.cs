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
using CrystalDecisions.Web;
using DalSic;
using SubSonic;
using Salud.Security.SSO;

namespace Consultorio.Turnos
{
    public partial class TurnosPorPaciente : System.Web.UI.Page
    {
        private DataTable dtGrilla
        {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        public CrystalReportSource oCr = new CrystalReportSource();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idAgenda"] != string.Empty)
                {
                    int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);
                    if (idAgenda > 0)
                    {
                        leerAgenda(idAgenda);
                    }
                }
                if (Request.QueryString["idPaciente"] != string.Empty)
                {
                    int idPaciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
                    if (idPaciente > 0) { leerPaciente(idPaciente); }
                }

                txtFechaDesde.Text = DateTime.Now.ToShortDateString();
            }
            else
            {

            }
        }

        private void leerAgenda(int idAgenda)
        {
            actualizarTurnos(idAgenda);
        }

        private void leerPaciente(int idPaciente)
        {
            SysPaciente paciente = new SysPaciente(idPaciente);
            txtDNI.Text = paciente.NumeroDocumento.ToString();
            buscarPaciente();

            if (gvPacientes.Rows.Count > 0)
            {
                dtGrilla = getTurnos(paciente);
                gvTurnos.EmptyDataText = "No se encontraron turnos para el paciente seleccionado";
                gvTurnos.DataSource = dtGrilla;
                gvTurnos.DataBind();
                gvPacientes.SelectedIndex = 0;
                pnlResultados.Update();
            }
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {

            if (!establecioParametros())
            {
                lblMsgErr.Text = "Debe proporcionar algún parámetro de búsqueda";
                divErr.Visible = true;
                resultadosPacientes.Visible = false;
            }
            else
            {
                lblMsgErr.Text = "";
                divErr.Visible = false;
                resultadosPacientes.Visible = true;

                limpiarInfoTurno();
                buscarPaciente();
                gvPacientes.SelectedIndex = -1;
                gvPacientes.Focus();
            }
        }

        private void buscarPaciente()
        {
            SubSonic.Select s = new SubSonic.Select();
            s.From(SysPaciente.Schema);

            if (txtDNI.Text.Length > 0)
            {
                int nrodoc = 0;
                nrodoc = Convert.ToInt32(txtDNI.Text);
                gvPacientes.DataSource = SPs.ConGetPacientesPorDocumento(nrodoc).GetDataSet();
                gvPacientes.DataBind();
                return;
            }

            if ((txtApellido.Text != string.Empty) || (txtNombre.Text != string.Empty))
            {
                string vAp = Convert.ToString(txtApellido.Text);
                string vNom = Convert.ToString(txtNombre.Text);
                gvPacientes.DataSource = SPs.ConGetPacientesByApyNom(vNom, vAp).GetDataSet();
                gvPacientes.DataBind();
                return;
            }
            limpiarInfoTurno();
            limpiarGrillaTurnos();
        }

        private bool establecioParametros()
        {
            bool establecio = false;
            if (!(txtDNI.Text == string.Empty)) { establecio = true; }
            if (!(txtApellido.Text == string.Empty)) { establecio = true; }
            if (!(txtNombre.Text == string.Empty)) { establecio = true; }
            return establecio;
        }

        private void limpiarInfoTurno()
        {
            lblInfoPaciente.Text = "";
            lblInfoDni.Text = "";
            pnlInfo.Visible = false;
            pnlResultados.Update();
        }

        private void limpiarGrillaTurnos()
        {
            gvTurnos.SelectedIndex = -1;
            if (dtGrilla != null)
            {
                for (int i = dtGrilla.Rows.Count - 1; i >= 0; i--)
                {
                    dtGrilla.Rows.Remove(dtGrilla.Rows[i]);
                    dtGrilla.AcceptChanges();
                }
                gvTurnos.DataSource = dtGrilla;
                gvTurnos.DataBind();
            }
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.SelectedIndex = -1;
            buscarPaciente();
            gvPacientes.PageIndex = e.NewPageIndex;
            gvPacientes.DataBind();
            pnlResultados.Update();
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Rutinas.Capitalizar(e.Row.Cells[1].Text);
                e.Row.Cells[2].Text = Rutinas.Capitalizar(e.Row.Cells[2].Text);
                ImageButton cmdSel = (ImageButton)e.Row.Cells[3].FindControl("cmdSel");

                cmdSel.CommandArgument = gvPacientes.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdSel.CommandName = "Select";
                cmdSel.ToolTip = "Mostrar turnos del paciente id n°" + cmdSel.CommandArgument;
            }
        }

        protected void gvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;

            int idPaciente = Convert.ToInt32(gvPacientes.DataKeys[gvPacientes.SelectedIndex].Value);
            SysPaciente paciente = new SysPaciente(idPaciente);

            lblPaciente.Text = paciente.Apellido + " " + paciente.Nombre;
            lblDni.Text = "DNI:" + paciente.NumeroDocumento.ToString();
            //lblHC.Text = "HC:" + paciente.HistoriaClinica.ToString();

            dtGrilla = getTurnos(paciente);
            gvTurnos.EmptyDataText = "No se encontraron turnos para el paciente seleccionado";
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.DataBind();
            pnlResultados.Update();
        }

        private DataTable getTurnos(SysPaciente paciente)
        {
            DateTime fecha = DateTime.Parse(txtFechaDesde.Text);

            return SPs.ConGetTurnosPacientes(fecha.ToString("yyyyMMdd"), paciente.IdPaciente, 0).GetDataSet().Tables[0];
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
                        dt.Rows[i]["TipoTurno"] = "";
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
            int maxSbts = ag.MaximoSobreturnos;
            string hIni = ag.HoraInicio;
            string hFin = ag.HoraFin;
            string hora = hIni;

            do
            {
                if (!existeHoraEnDataTable(dt, hora))
                {
                    insertarDataRow(dt, fecha, hora, idAgenda);
                }
                hora = incrementarHora(hora, duracion);
            } while (!(hora == hFin));
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

            newRow["DNI"] = "0";
            newRow["HC"] = "0";
            newRow["Paciente"] = "";
            newRow["TipoTurno"] = "";

            ConTurnoBloqueo r = new Select().From(Schemas.ConTurnoBloqueo)
                         .Where(ConTurnoBloqueo.Columns.IdAgenda).IsEqualTo(idAgenda)
                         .And(ConTurnoBloqueo.Columns.FechaTurno).IsEqualTo(ag.Fecha)
                         .And(ConTurnoBloqueo.Columns.HoraTurno).IsEqualTo(hora)
                         .ExecuteSingle<ConTurnoBloqueo>();

            if (r != null)
            { newRow["Estado"] = "Bloqueado"; }
            else
                newRow["Estado"] = "Activo";

            dt.Rows.Add(newRow);


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
        private void actualizarTurnos(int idPaciente)
        {
            SysPaciente paciente = new SysPaciente(idPaciente);

            dtGrilla = getTurnos(paciente);
            gvTurnos.EmptyDataText = "No se encontraron turnos para el paciente seleccionado";
            gvTurnos.DataSource = dtGrilla;
            gvTurnos.DataBind();
            pnlResultados.Update();
        }


        private DataTable getTurnos(ConAgenda agenda)
        {
            return SPs.ConTurnosPorAgenda(agenda.IdAgenda).GetDataSet().Tables[0];
        }

        private DataTable getPlanillaTurnos(ConAgenda agenda)
        {
            return SPs.ConPlanillaPorAgenda(agenda.IdAgenda).GetDataSet().Tables[0];
        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgTurno = (Image)e.Row.FindControl("imgTurno");
                ImageButton cmdSelTurno = (ImageButton)e.Row.FindControl("cmdSelTurno");
                cmdSelTurno.CommandArgument = gvTurnos.DataKeys[0].Value.ToString();
                cmdSelTurno.CommandName = "Select";
                cmdSelTurno.ToolTip = "Seleccionar turno";
                cmdSelTurno.CommandArgument = dtGrilla.Rows[e.Row.RowIndex]["Hora"].ToString();
                int dni = Convert.ToInt32(dtGrilla.Rows[e.Row.RowIndex]["DNI"]);

                string Estado = dtGrilla.Rows[e.Row.RowIndex]["Estado"].ToString();

                switch (Estado)
                {
                    case "Activo":
                        {

                            string tipoTurno = dtGrilla.Rows[e.Row.RowIndex]["TipoTurno"].ToString();
                            switch (tipoTurno)
                            {

                                case "":
                                    imgTurno.ImageUrl = "../App_Themes/consultorio/Agenda/turnoactivo.png";
                                    imgTurno.ToolTip = "Turno activo";
                                    break;

                                case "Turno":
                                    imgTurno.ImageUrl = "../App_Themes/consultorio/Agenda/check_verde16.png";
                                    imgTurno.ToolTip = "Turno habitaul";


                                    break;
                                case "Programado":
                                    imgTurno.ImageUrl = "../App_Themes/consultorio/Agenda/alerta1.png";
                                    imgTurno.ToolTip = "Turno Programado por el Medico";

                                    break;
                                case "Interconsulta":
                                    imgTurno.ImageUrl = "../App_Themes/consultorio/Agenda/alerta.png";
                                    imgTurno.ToolTip = "Turno reservado para interconsulta";

                                    break;
                            }


                        } break;
                    case "Bloqueado":
                        {
                            imgTurno.ImageUrl = "../App_Themes/consultorio/Agenda/turnobloqueado.png";
                            imgTurno.ToolTip = "Turno bloqueado";
                        } break;


                }
            }
        }

        private string getDatosReserva(int idTurno)
        {
            ConTurnoReserva r = new Select().From(Schemas.ConTurnoReserva)
                            .Where(ConTurnoReserva.Columns.IdTurno).IsEqualTo(idTurno)
                            .ExecuteSingle<ConTurnoReserva>();
            return "(caduca " + r.ReservaHasta.ToString() + ")";
        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(gvTurnos.DataKeys[gvTurnos.SelectedIndex].Value);

            if (idTurno != 0) ///Si es un turno muestra datos del mismo
            {
                ConTurno turno = new ConTurno(idTurno);
                llenarInfoTurno(turno);
                Calendario.DataBind();
                pnlResultados.Update();
                divInfoPaciente.Visible = true;

            }
        }

        private void llenarInfoTurno(ConTurno turno)
        {
            imgInfoPaciente.ImageUrl = getImageUrl(turno.SysPaciente.IdSexo);
            lnkPaciente.NavigateUrl = "~/Paciente/PacienteView.aspx?id=" + turno.IdPaciente.ToString();
            lnkPaciente.ToolTip = "click para ver datos del paciente";
            lblInfoDni.Text = " Dni " + turno.SysPaciente.NumeroDocumento.ToString();
            lblInfoPaciente.Text = Rutinas.Capitalizar(turno.SysPaciente.Apellido) + ", "
                             + Rutinas.Capitalizar(turno.SysPaciente.Nombre);
            lnkInfoAgenda.PostBackUrl = "~/Consultorio/Agenda/AgendaEdit.aspx?idAgenda=" + turno.ConAgenda.IdAgenda.ToString();
            lnkInfoAgenda.Text = Rutinas.getNombreDia(turno.Fecha) + " " + turno.Fecha.ToShortDateString();
            lnkInfoAgenda.ToolTip = "click para editar agenda";
            divConfirma.Visible = false;
            divError.Visible = false;
            pnlInfo.Visible = true;

            lblNoAsistencia.Visible = true;
            cmdRecitar.Visible = true;
            cmdLiberar.Visible = true;
            cmdSuspender.Visible = true;
            lnkAsistenciaNo.Visible = true;
            cmdBloquear.Visible = false;
        }

        private string getImageUrl(int sexo)
        {
            string url = string.Empty;
            switch (sexo)
            {
                case 1: url = "../App_Themes/consultorio/Agenda/ayuda32.png"; break;
                case 2: url = "../App_Themes/consultorio/Agenda/mujer32.png"; break;
                case 3: url = "../App_Themes/consultorio/Agenda/hombre32.png"; break;
            }
            return url;
        }

        protected void lnkAsistenciaNo_Click(object sender, EventArgs e)
        {
            divAsistenciaNo.Visible = true;
            divAsistenciaSi.Visible = false;
            divAsistenciaEdit.Visible = false;
            divConfirma.Visible = false;
            divError.Visible = false;
        }

        protected void cmdBorrarAsistencia_Click(object sender, EventArgs e)
        {
            // acá tendría que preguntar si el turno tiene consultas
            // si el turno tiene consulta, no puedo borrar la asistencia
            borrarAsistencia();
            divAsistenciaNo.Visible = true;
            divAsistenciaSi.Visible = false;
            divAsistenciaEdit.Visible = false;
            divConfirma.Visible = false;
            divError.Visible = false;

        }

        protected void cmdEditarAsistencia_Click(object sender, EventArgs e)
        {
            divAsistenciaNo.Visible = false;
            divAsistenciaSi.Visible = false;
            divAsistenciaEdit.Visible = true;
            divConfirma.Visible = false;
            divError.Visible = false;
        }

        protected void cmdCancelarAsistencia_Click(object sender, EventArgs e)
        {
            //  leerAsistencia();
        }

        protected bool validarFecha()
        {
            bool valido = true;
            try
            {
                DateTime f = Convert.ToDateTime(txtFechaAsistencia.Text + " " + txtHoraAsistencia.Value + ":00");
                DateTime fechaTurno = Convert.ToDateTime(gvTurnos.SelectedRow.Cells[1].Text + " " + gvTurnos.SelectedRow.Cells[2].Text + ":00");
                valido = (fechaTurno > f) ? false : true;
            }
            catch { valido = false; }
            return valido;
        }

        protected void cmdGrabarAsistencia_Click(object sender, EventArgs e)
        {
            if (rqfvHoraAsistencia.IsValid)
            {
                DateTime fechaNueva = Convert.ToDateTime(txtFechaAsistencia.Text + " " + txtHoraAsistencia.Value + ":00");
                //  grabarAsistencia(us, fechaNueva);
                //leerAsistencia();
                divAsistenciaNo.Visible = false;
                divAsistenciaSi.Visible = true;
                divAsistenciaEdit.Visible = false;
            }
        }

        private void borrarAsistencia()
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);

            Query asist = new Query(Schemas.ConTurnoAsistencium);
            asist.QueryType = QueryType.Delete;
            asist.WHERE(ConTurnoAsistencium.Columns.IdTurno, idTurno);
            asist.Execute();
        }

        protected void cmdRecitar_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            if (!tieneAsistencia(t))
            {
                Response.Redirect("TurnoNuevo.aspx?accion=1&idTurno=" + idTurno.ToString());
            }
            else
            {
                divError.Visible = true;
                divConfirma.Visible = false;
            }
        }

        protected void cmdLiberar_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            if (!tieneAsistencia(t))
            {
                inpConfirma.Value = "4";
                divError.Visible = false;
                divConfirma.Visible = true;
                lblConfirma.Text = "No podrá revertir esta acción ¿Confirma liberar el turno?";
            }
            else
            {
                divError.Visible = true;
                divConfirma.Visible = false;
            }
        }

        protected void cmdSuspender_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            if (!tieneAsistencia(t))
            {
                inpConfirma.Value = "5";
                divError.Visible = false;
                divConfirma.Visible = true;
                lblConfirma.Text = "No podrá revertir esta acción ¿Confirma eliminar el turno?";
            }
            else
            {
                divError.Visible = true;
                divConfirma.Visible = false;
            }
        }

        private bool tieneAsistencia(ConTurno t)
        {
            int r = new Select().From(Schemas.ConTurnoAsistencium)
                                .Where(ConTurnoAsistencium.Columns.IdTurno)
                                .IsEqualTo(t.IdTurno).GetRecordCount();
            return (r > 0) ? true : false;
        }

        protected void cmdNo_Click(object sender, EventArgs e)
        {
            inpConfirma.Value = "";
            divConfirma.Visible = false;
            divError.Visible = false;
        }

        protected void cmdSi_Click(object sender, EventArgs e)
        {
            int idTurnoEstado = Convert.ToInt32(inpConfirma.Value);
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            ConTurno t = new ConTurno(idTurno);

            establecerEstado(t, idTurnoEstado);

            divConfirma.Visible = false;
            divError.Visible = false;
            pnlInfo.Visible = false;

        }

        private void establecerEstado(ConTurno t, int idTurnoEstado)
        {
            int idAgenda = t.IdAgenda;

            t.IdTurnoEstado = idTurnoEstado;
            t.Save();

            grabarAuditoriaTurno(t);

            actualizarTurnos(t.IdPaciente);
            //            leerAgenda(idAgenda);
        }

        private void grabarAuditoriaTurno(ConTurno turno)
        {
            string h = Convert.ToString(DateTime.Now.Hour);
            string m = Convert.ToString(DateTime.Now.Minute);
            if (h.Length < 2) { h = "0" + h; }
            if (m.Length < 2) { m = "0" + m; }
            string hora = h + ":" + m;

            ConTurnoAuditorium aud = new ConTurnoAuditorium();
            aud.IdTurno = turno.IdTurno;
            aud.IdTurnoEstado = turno.IdTurnoEstado;
            aud.IdUsuario = SSOHelper.CurrentIdentity.Id;
            aud.IdServicio = turno.ConAgenda.IdServicio;
            aud.IdProfesional = turno.ConAgenda.IdProfesional;
            aud.IdEspecialidad = turno.ConAgenda.IdEspecialidad;
            aud.IdConsultorio = turno.ConAgenda.IdConsultorio;
            aud.Fecha = turno.Fecha;
            aud.Hora = turno.Hora;
            aud.FechaModificacion = System.DateTime.Now;
            aud.HoraModificacion = hora;
            aud.Save();
        }



        protected void cmdAuditoria_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            Response.Redirect("TurnosAuditoria.aspx?idTurno=" + idTurno.ToString());
        }

        protected void lnkImprimir_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(dtGrilla.Rows[gvTurnos.SelectedIndex]["idTurno"]);
            generarPDF(idTurno);
        }

        protected void generarPDF(int idTurno)
        {
            //ConTurno turno = new ConTurno(idTurno);
            //MemoryStream mStream = new MemoryStream();

            //iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 90, 10);
            //iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, mStream);

            //doc.Open();
            //iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("Paragraph. " + turno.IdTurno.ToString());
            ////iTextSharp.text.Phrase pharse = new iTextSharp.text.Phrase("Pharse.");
            ////iTextSharp.text.Chunk chunk = new iTextSharp.text.Chunk(" Chunk.");

            //doc.Add(paragraph);
            ////doc.Add(pharse);
            ////doc.Add(chunk);

            ////writer.CloseStream = false;
            //doc.Close();

            ////Response.Buffer = false; 
            //Response.Clear();
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.ContentType = "application/pdf";
            //Response.OutputStream.Write(mStream.GetBuffer(), 0, mStream.GetBuffer().Length);
            ////Response.OutputStream.Flush();
            //Response.OutputStream.Close();

        }
    }
}
