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
using CrystalDecisions.Shared;
using System.IO;
using CrystalDecisions.Web;
//using CrystalDecisions.Shared;
//using CrystalDecisions.Web;
//using System.IO;

namespace Consultorio.Turnos
{

    /// <summary>
    ///  Comentario para subir de nuevo
    /// </summary>
    public partial class DiagnosticoEditOdontologia : System.Web.UI.Page
    {
        private DataTable dtGrilla
        {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        private DataTable dtGrillaPrestaciones
        {
            get { return ViewState["dtGrillaPrestaciones"] == null ? null : (DataTable)(ViewState["dtGrillaPrestaciones"]); }
            set { ViewState["dtGrillaPrestaciones"] = value; }
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

                if (ag.IdEspecialidad > 0)
                {
                    SysEspecialidad oEspecialidad = new SysEspecialidad(ag.IdEspecialidad);
                    especialidad = oEspecialidad.Nombre;
                }

                lblTituloAgenda.Text = p.ApellidoyNombre + " - " + especialidad;
                lblFechaAgenda.Text = Rutinas.getNombreDia(ag.Fecha).ToUpper() + " " + ag.Fecha.ToShortDateString();
                lblHoraAgenda.Text = " (" + ag.HoraInicio + " - " + ag.HoraFin + ")";
                actualizarTurnos(idAgenda);
                pnlHola.Visible = true;
                pnlDiagnostico.Visible = false;
                crearDtGrilla();
                if (Request["idTurno"] != null)
                {
                    int idTurno = Convert.ToInt32(Request.QueryString["idTurno"]);
                    if (idTurno > 0) mostrarTurno(idTurno);
                }
            }
        }
        private void crearDtGrilla()
        {
            dtGrillaPrestaciones = getDataTable();

            GridView1.DataSource = dtGrillaPrestaciones;
            GridView1.DataBind();
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

        private DataTable getDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idNomenclador", typeof(string));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Diente", typeof(string));
            dt.Columns.Add("Cara", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));

            dt.AcceptChanges();

            return dt;
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
        protected void btnImprimirConsultorio_Click(object sender, EventArgs e)
        {
            ////imprimir el consultorio completo
            string l = GenerarListaTurnoaImprimir();
            Imprimir(" T.idTurno in (" + l + ")", "consultorio");

        }
        private void Imprimir(string filtro, string nombreArchivo)
        {
            string informe = "../Informes/ConsultorioPaciente.rpt";

            //  nombreArchivo = "Consultorio";

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = "ATENCION DE CONSULTORIO";


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


            rdbPrograma.DataValueField = "idProgramaOdontologia";
            rdbPrograma.DataTextField = "nombre";
            rdbPrograma.DataSource = OdoPrograma.FetchAll();
            rdbPrograma.DataBind();


        }

        private void insertarFila(DateTime fecha, int idConsultorio, string Consultorio, string hIni, string hFin,
                                string Duracion, string SobreTurnos, string TurnosDia, string TurnosAnticipados, string Bloque, int idAgendaEstado, string Estado, DateTime fActivacion)
        {
            DataRow dr = dtGrilla.Rows.Add();
            dr["Fecha"] = fecha;
            dr["idConsultorio"] = idConsultorio;
            dr["Consultorio"] = Consultorio;
            dr["hIni"] = hIni;
            dr["hFin"] = hFin;
            dr["Duracion"] = Duracion;

            //    dr["SobreTurnos"] = SobreTurnos;
            dr["TurnosDia"] = TurnosDia;
            dr["TurnosAnticipados"] = TurnosAnticipados;
            dr["Bloque"] = Bloque;


            dr["idAgendaEstado"] = idAgendaEstado;
            dr["Estado"] = Estado;
            dr["fActivacion"] = fActivacion;
            dr.AcceptChanges();
            dtGrilla.AcceptChanges();
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

                Response.Redirect("DiagnosticoEditOdontologia.aspx?idAgenda=" + Convert.ToInt32(Request.QueryString["idAgenda"]) + "&Desde=" + Request["Desde"].ToString() + "&Tipo=Atencion&idTurno=" + Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]), false);
            else
                Response.Redirect("DiagnosticoEditOdontologia.aspx?idAgenda=" + Convert.ToInt32(Request.QueryString["idAgenda"]) + "&Desde=" + Request["Desde"].ToString() + "&idTurno=" + Convert.ToInt32(dtGrilla.Rows[i]["idTurno"]), false);
        }

        private void mostrarTurno(int idTurno)
        {
            pnlHola.Visible = false;
            pnlDiagnostico.Visible = true;
            ConTurno t = new ConTurno(idTurno);
            lblPaciente.Text = t.SysPaciente.NumeroDocumento.ToString() + " " + t.SysPaciente.Apellido + " " + t.SysPaciente.Nombre;
            lblFechaNacimiento.Text = "Fecha de Nacimiento: " + t.SysPaciente.FechaNacimiento.ToShortDateString();
            HfidPaciente.Value = t.IdPaciente.ToString();
            HfDNI.Value = t.SysPaciente.NumeroDocumento.ToString();

            DateDifference oEdad = new DateDifference(t.SysPaciente.FechaNacimiento, t.Fecha);
            if (oEdad.Years > 0)
            {

                lblFechaNacimiento.Text += " - Edad: " + oEdad.Years.ToString() + " años";
            }
            else
            {
                if (oEdad.Months > 0)
                    lblFechaNacimiento.Text += " - Edad: " + oEdad.Months.ToString() + " meses";
                else
                    if (oEdad.Days > 0)
                        lblFechaNacimiento.Text += " - Edad: " + oEdad.Days.ToString() + " días";
            }
            lblIdTurno.Text = idTurno.ToString();

            gvHistorial.DataSource = SPs.ConGetTurnosPacientes(t.Fecha.ToString("yyyyMMdd"), t.SysPaciente.IdPaciente, 1).GetDataSet();
            gvHistorial.DataBind();

            dlHistorialOdontologia.DataSource = SPs.ConGetHistorialOdontologia(t.Fecha.ToString("yyyyMMdd"), t.SysPaciente.IdPaciente).GetDataSet();
            dlHistorialOdontologia.DataBind();

            MostrarConsulta(idTurno);

            if (oEdad.Years > 6) rdbPrograma.Items[0].Enabled = false;

            ConsultorioPaciente1.HabilitarBotonesConsulta(t.SysPaciente, t.IdTurno);
            //actualizarTurnosAcompaniantes(idTurno);
        }

        protected void dlHistorialOdontologia_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label Turno = (Label)e.Item.FindControl("idTurno");

            int idTurno = int.Parse(Turno.Text);

            ConTurno t = new ConTurno(idTurno);

            GridView oList = (GridView)e.Item.FindControl("gvHistorialOdontologia");            
            oList.DataSource = SPs.ConGetHistorialOdontologiaPrestacion(t.IdTurno, t.SysPaciente.IdPaciente).GetDataSet();
            oList.DataBind();
        }

        private void MostrarConsulta(int idTurno)
        {
            ConTurno t = new ConTurno(int.Parse(lblIdTurno.Text));
            ConConsultum oConsulta = new SubSonic.Select()
              .From(Schemas.ConConsultum)
                        .Where(ConConsultum.Columns.IdTurno).IsEqualTo(idTurno)
                          .ExecuteSingle<ConConsultum>();


            if (oConsulta != null)
            {
                lblIdConsulta.Text = oConsulta.IdConsulta.ToString();
                txtInformeConsulta.Text = oConsulta.InformeConsulta;
                rdbPrograma.SelectedValue = oConsulta.IdProgramaOdontologia.ToString();
                ddlNotificacion.SelectedValue = oConsulta.PrimerConsultaOdontologia.ToString();

                ConConsultaOdontologiumCollection srv = new SubSonic.Select()
              .From(Schemas.ConConsultaOdontologium)
                        .Where(ConConsultaOdontologium.Columns.IdConsulta).IsEqualTo(oConsulta.IdConsulta)

               .ExecuteAsCollection<ConConsultaOdontologiumCollection>();



                foreach (ConConsultaOdontologium oOdonto in srv)
                {
                    OdoNomenclador prestacion = new OdoNomenclador(oOdonto.IdNomenclador);
                    string s_caras = "";
                    if (oOdonto.CaraO) s_caras += "O";
                    if (oOdonto.CaraV) s_caras += "V";
                    if (oOdonto.CaraL) s_caras += "L";
                    if (oOdonto.CaraP) s_caras += "P";
                    if (oOdonto.CaraM) s_caras += "M";
                    if (oOdonto.CaraD) s_caras += "D";

                    insertarFilaOdontologica(prestacion.IdNomenclador.ToString(), prestacion.Codigo, prestacion.Descripcion, oOdonto.Diente.ToString(), s_caras, oOdonto.Cantidad.ToString());
                    actualizarGrillaOdontologica();
                }


            }

            else
            {
                lblIdConsulta.Text = "0";

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]);

                GuardarPrestaciones();
                //grabarAsistencia();

                if (Request["Tipo"] != null)
                    Response.Redirect("DiagnosticoEditOdontologia.aspx?idAgenda=" + idAgenda + "&Tipo=Atencion&Desde=" + Request["Desde"].ToString(), false);
                else
                    Response.Redirect("DiagnosticoEditOdontologia.aspx?idAgenda=" + idAgenda + "&Desde=" + Request["Desde"].ToString(), false);
            }
        }

        private void grabarAsistencia()
        {
            ConTurnoAsistencium asist = new ConTurnoAsistencium();
            asist.IdTurno = int.Parse(lblIdTurno.Text);
            asist.FechaAsistencia = DateTime.Now;
            asist.IdUsuario = SSOHelper.CurrentIdentity.Id;
            asist.Save();
        }

        private void GuardarPrestaciones()
        {
            ConTurno t = new ConTurno(int.Parse(lblIdTurno.Text));

            ///
            if (Request["Desde"].ToString() == "Consultorio")
            {   //graba la asistencia
                ConTurnoAsistencium asist = new ConTurnoAsistencium();
                asist.IdTurno = t.IdTurno;
                asist.FechaAsistencia = DateTime.Now;
                asist.IdUsuario = SSOHelper.CurrentIdentity.Id;
                asist.Save();
            }
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

            /////variables de odontologia
            oConsulta.IdProgramaOdontologia = int.Parse(rdbPrograma.SelectedValue);
            oConsulta.PrimerConsultaOdontologia = int.Parse(ddlNotificacion.SelectedValue);
            //////////////////

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

                        BorrarPrestaciones(oConsulta);

                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            ConConsultaOdontologium oOdonto = new ConConsultaOdontologium();
                            oOdonto.IdConsulta = oConsulta.IdConsulta;
                            oOdonto.IdNomenclador = int.Parse(dtGrillaPrestaciones.Rows[i]["idNomenclador"].ToString());
                            if (dtGrillaPrestaciones.Rows[i]["diente"].ToString() == "")
                                oOdonto.Diente = 0;
                            else oOdonto.Diente = int.Parse(dtGrillaPrestaciones.Rows[i]["diente"].ToString());
                            oOdonto.CaraD = esCara(dtGrillaPrestaciones.Rows[i]["cara"].ToString(), "D");
                            oOdonto.CaraL = esCara(dtGrillaPrestaciones.Rows[i]["cara"].ToString(), "L");
                            oOdonto.CaraM = esCara(dtGrillaPrestaciones.Rows[i]["cara"].ToString(), "M");
                            oOdonto.CaraO = esCara(dtGrillaPrestaciones.Rows[i]["cara"].ToString(), "O");
                            oOdonto.CaraP = esCara(dtGrillaPrestaciones.Rows[i]["cara"].ToString(), "P");
                            oOdonto.CaraV = esCara(dtGrillaPrestaciones.Rows[i]["cara"].ToString(), "V");
                            oOdonto.Cantidad = int.Parse(dtGrillaPrestaciones.Rows[i]["cantidad"].ToString());
                            oOdonto.Save();
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
                    }
                }///using
            }//using


        }


        private bool esCara(string p1, string p2)
        {
            if (p1.IndexOf(p2) != -1)
                return true;
            else
                return false;
        }

        void BorrarPrestaciones(ConConsultum oConsulta)
        {
            Query i = new Query(Schemas.ConConsultaOdontologium);
            i.QueryType = QueryType.Delete;
            i.WHERE(ConConsultaOdontologium.Columns.IdConsulta, oConsulta.IdConsulta);
            i.Execute();
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



                int idAgenda = int.Parse(Request["idAgenda"].ToString());



                if ((Asistencia == "1") && (Consulta == "No"))
                {
                    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.LightYellow;
                    }

                    cmdSelTurno.Visible = true;
                }
                else if (Consulta == "Si")
                {
                    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Gainsboro;
                    }
                    cmdSelTurno.Visible = true;
                }
                else
                {
                    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.White;
                    }
                    if (Request["Desde"].ToString() != "Consultorio") cmdSelTurno.Visible = false;
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
            string s_paginaDesde = "";
            if (Request["Desde"].ToString() == "Consultorio")
                s_paginaDesde = "?llamada=consultorio";// +Request["llamada"].ToString();

            Response.Redirect("../Consultorio/Agenda/AgendaList.aspx" + s_paginaDesde, false);
        }





        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
                AgregarPrestacion();

        }

        private void AgregarPrestacion()
        {
            int idPrestacion = PrestacionP1.getPrestacion();
            if (idPrestacion > -1)
            {
                OdoNomenclador prestacion = new OdoNomenclador(idPrestacion);
                if (prestacion != null)
                {
                    string s_diente = ""; string s_caras = "";
                    if (prestacion.PiezaDental)// si la prestacion requiere pieza dental graba la misma, sino no.
                    {
                        s_diente = txtDiente.Text;
                        if (chkCaraO.Checked) s_caras += "O";
                        if (chkCaraV.Checked) s_caras += "V";
                        if (chkCaraL.Checked) s_caras += "L";
                        if (chkCaraP.Checked) s_caras += "P";
                        if (chkCaraM.Checked) s_caras += "M";
                        if (chkCaraD.Checked) s_caras += "D";
                    }
                    //insertarFilaOdontologica(6.ToString(), "01060", "CONSULTA DE CONTROL DE TRATAMIENTOS Y/O INSPECCIÓN Y/O MEDICACIÓN.  EXCLUYE CONTROL POST QUIRÚRGICO. ", "18", "OM", "1");
                    insertarFilaOdontologica(prestacion.IdNomenclador.ToString(), prestacion.Codigo, prestacion.Descripcion.Trim(), s_diente, s_caras, txtCantidad.Text);
                    actualizarGrillaOdontologica();
                    limpiarParametros();
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('Código no válido')</script>";
                    Page.RegisterClientScriptBlock("PopupScript", popupScript);
                }

            }
        }

        private void limpiarParametros()
        {
            //txtCodigoPrestacion.Text = "";
            txtDiente.Text = "";
            txtCantidad.Text = "1";
            chkCaraD.Checked = false;
            chkCaraL.Checked = false;
            chkCaraM.Checked = false;
            chkCaraO.Checked = false;
            chkCaraP.Checked = false;
            chkCaraV.Checked = false;
            PrestacionP1.Limpiar();
            pnlGrilla.Update();
        }
        private void insertarFilaOdontologica(string idNomenclador, string codigo, string descripcion, string diente, string cara, string cantidad)
        {
            DataRow dr1 = dtGrillaPrestaciones.Rows.Add();
            dr1["idNomenclador"] = idNomenclador;
            dr1["Codigo"] = codigo;
            dr1["Descripcion"] = descripcion;
            dr1["Diente"] = diente;
            dr1["Cara"] = cara;
            dr1["Cantidad"] = cantidad;


            dr1.AcceptChanges();
            dtGrillaPrestaciones.AcceptChanges();
        }
        private void actualizarGrillaOdontologica()
        {
            GridView1.DataSource = dtGrillaPrestaciones;
            GridView1.DataBind();
            pnlGrilla.Update();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    ImageButton cmdQuitar = (ImageButton)e.Row.FindControl("cmdQuitar");
            //    cmdQuitar.CommandArgument = GridView1.DataKeys[e.Row.RowIndex].ToString();
            //    cmdQuitar.CommandName = "cmdQuitar";
            //}
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "cmdQuitar") {
            //    string popupScript = "<script language='JavaScript'> alert('" + GridView1.SelectedIndex.ToString() + "')</script>";
            //    Page.RegisterClientScriptBlock("PopupScript", popupScript); 
            //    eliminarFila(GridView1.SelectedIndex);
            //}
        }

        private void eliminarFila(int Index)
        {
            dtGrillaPrestaciones.Rows[Index].Delete();
            dtGrillaPrestaciones.AcceptChanges();
            GridView1.DataSource = dtGrillaPrestaciones;
            GridView1.DataBind();
            // pnlGrilla.Update();
        }



        protected void cvDiagnostico_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void cvCodigoPrestacion_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (PrestacionP1.getPrestacion() == -1)
                args.IsValid = false;
            else
                args.IsValid = true;
            return;
        }

        protected void cvPrestacion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (GridView1.Rows.Count > 0) args.IsValid = true;
            else args.IsValid = false;
            return;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            eliminarFila(GridView1.SelectedIndex);
        }

        protected void cvDiente_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void cvDiente_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            if (!numeroDienteValido(txtDiente.Text))
                args.IsValid = false;
            else
                args.IsValid = true;
            return;

        }

        private bool numeroDienteValido(string p)
        {
            int[] dientesValidos = new int[52] { 11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23, 24, 25, 26, 27, 28, 31, 32, 33, 34, 35, 36, 37, 38, 41, 42, 43, 44, 45, 46, 47, 48, 51, 52, 53, 54, 55, 61, 62, 63, 64, 65, 71, 72, 73, 74, 75, 81, 82, 83, 84, 85 };
            bool valido = false;
            for (int i = 0; i < dientesValidos.Count(); i++)
            {
                if (p == dientesValidos[i].ToString())
                {
                    valido = true; break;
                }
            }
            return valido;
        }

        protected void cvDiente0_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (piezaCompleta())
                args.IsValid = true;
            else
                args.IsValid = false;
            return;

        }

        private bool piezaCompleta()
        {
            bool p_completa = true;
            int idPrestacion = PrestacionP1.getPrestacion();
            if (idPrestacion > -1)
            {
                OdoNomenclador prestacion = new OdoNomenclador(idPrestacion);
                if (prestacion != null)
                {
                    if ((prestacion.PiezaDental) && (txtDiente.Text.Trim() == ""))
                        p_completa = false;
                    else
                        p_completa = true;

                }

            }
            return p_completa;
        }

        protected void imgImprimirHistorialOdontologia_Click(object sender, ImageClickEventArgs e)
        {
            int idTurno = Convert.ToInt32(lblIdTurno.Text);
            ConTurno t = new ConTurno(idTurno);
            if (t != null)
            {
                string informe = "../Informes/ConsultorioPacienteHistorialOdontologia.rpt";


                string nombreArchivo = lblPaciente.Text.Trim() + "_Historial";

                ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
                encabezado1.Value = "HISTORIAL DE ATENCION ODONTOLOGICA DEL PACIENTE";

                DataTable dt = SPs.ConGetHistorialOdontologia(DateTime.Now.ToString("yyyyMMdd"), t.IdPaciente).GetDataSet().Tables[0];
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
    }
}
