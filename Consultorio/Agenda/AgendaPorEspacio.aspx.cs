using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using SubSonic;
using System.Data;
using Salud.Security.SSO;


namespace Consultorio.Agenda {
    public partial class AgendaPorEspacio : System.Web.UI.Page {

        private string fechaCalendario {
            get { return ViewState["fechaCalendario"] == null ? string.Empty : (string)(ViewState["fechaCalendario"]); }
            set { ViewState["fechaCalendario"] = value; } 
        }
        
        private DataTable dtGrilla {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                    //txtFecha.Text = fechaCalendario;

                    ClientScript.GetPostBackEventReference(this, string.Empty);
                    /// levanto el evento y argumento enviados desde cliente para llamar la funcion que necesite
                    string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
                    string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

                    switch (eventTarget) {
                        /// llamo a funcion segun string enviada como disparador de evento
                        case "callServersideMethod": cambioFecha(eventArgument); break;
                        //case "envioParametros": agregarRegistro(eventArgument); break;
                        default: break;
                    }
                } else {
                    //txtFecha.Text = DateTime.Now.ToString().Substring(0, 10);

                    cldTurno.SelectedDate = DateTime.Now;
                    //cldTurno.TodaysDate = DateTime.Now;
                    //cldTurno.VisibleDate = DateTime.Now;

                    txtFechaActivacion.Text = DateTime.Now.ToString().Substring(0, 10);
                    llenarCombos();
                    crearDtGrilla();
                    acordionGrilla.Enabled = false;
                    acordionParametros.Enabled = false;
                    Acordeon.SelectedIndex = 1;

                    ////////////////////////////////////////////////////////
                    // escribir en el page init o con eval
                    //calExttxtFechaActivacion.SelectedDate = DateTime.Now;
                    //txtFecha_CalendarExtender.SelectedDate = DateTime.Now; 
                    ////////////////////////////////////////////////////////
                    
                }            
        }

        private void crearDtGrilla() {
            dtGrilla = getDataTable();

            gvProgramacion.DataSource = dtGrilla;
            gvProgramacion.DataBind();
        }

        private DataTable getDataTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("idConsultorio", typeof(int));
            dt.Columns.Add("Consultorio", typeof(string));
            dt.Columns.Add("hIni", typeof(string));
            dt.Columns.Add("hFin", typeof(string));
            dt.Columns.Add("Duracion", typeof(int));


      //      dt.Columns.Add("SobreTurnos", typeof(string));
            dt.Columns.Add("TurnosDia", typeof(string));

            dt.Columns.Add("TurnosAnticipados", typeof(string));
            dt.Columns.Add("Bloque", typeof(string));
            
            

            dt.Columns.Add("idAgendaEstado", typeof(int));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("fActivacion", typeof(DateTime));
            dt.AcceptChanges();

            return dt;
        }

       

        private void insertarFila(DateTime fecha, int idConsultorio, string Consultorio, string hIni, string hFin, 
                                  string Duracion, string SobreTurnos, string TurnosDia,string TurnosAnticipados, string Bloque, int idAgendaEstado, string Estado, DateTime fActivacion) {
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

        private void actualizarGrilla() {
            gvProgramacion.DataSource = dtGrilla;
            gvProgramacion.DataBind();
            pnlGrilla.Update();
        }

        private string checkStr(string p) {
            if (p.Length == 1) { p = "0" + p; }
            return p;
        }

        private string getNombreEstado(int idAgendaEstado) {
            ConAgendaEstado e = new ConAgendaEstado(idAgendaEstado);
            return e.Nombre;
        }

        private string getNombreConsultorio(int idConsultorio) {
            ConConsultorio c = new ConConsultorio(idConsultorio);
            return c.Nombre;
        }

        protected void ScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e) {
            if (e.Exception.Data["ExtraInfo"] != null) {
                ToolkitScriptManager1.AsyncPostBackErrorMessage =
                                      e.Exception.Message + e.Exception.Data["ExtraInfo"].ToString();
            } else {
                ToolkitScriptManager1.AsyncPostBackErrorMessage = "An unspecified error occurred.";
            }
        }

        private void llenarCombos() {

            ddlTipoAgenda.Items.Insert(0, "Médica");
            ddlTipoAgenda.Items.Insert(1, "Prestaciones");

             ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlServicio.DataSource = SPs.SysGetServicioByEfector(SSOHelper.CurrentIdentity.IdEfector).GetDataSet();
            ddlServicio.DataTextField = SysServicio.Columns.Nombre;
            ddlServicio.DataValueField = SysServicio.Columns.IdServicio;
            ddlServicio.DataBind();
            ddlServicio.Items.Insert(0, "--Seleccione--");
            ///


            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, -1).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Seleccione--");
            ///

        

            ///Carolina: Modifico para que se muestren los profesiones del efector                        
            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();
            ddlProfesional.Items.Insert(0, "--Seleccione--");
            ///


            ConAgendaEstadoCollection e = new SubSonic.Select()
                .From(Schemas.ConAgendaEstado)
                .Where(ConAgendaEstado.Columns.IdAgendaEstado).IsLessThan(3)
                .OrderAsc(ConAgendaEstado.Columns.Nombre)
                .ExecuteAsCollection<ConAgendaEstadoCollection>();
            ddlEstado.DataSource = e;
            ddlEstado.DataValueField = ConAgendaEstado.Columns.IdAgendaEstado;
            ddlEstado.DataTextField = ConAgendaEstado.Columns.Nombre;
            ddlEstado.DataBind();


            ConConsultorioTipoCollection tc = new Select().From(Schemas.ConConsultorioTipo)
                            .Where(ConConsultorioTipo.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
                            .OrderAsc(ConConsultorioTipo.Columns.Nombre)
                            .ExecuteAsCollection<ConConsultorioTipoCollection>();
            ddlTipoConsultorio.DataSource = tc;
            ddlTipoConsultorio.DataTextField = ConConsultorioTipo.Columns.Nombre;
            ddlTipoConsultorio.DataValueField = ConConsultorioTipo.Columns.IdTipoConsultorio;
            ddlTipoConsultorio.DataBind();
        //    ddlTipoConsultorio.Items.Insert(0, "--Seleccione--");

            ddlDuracion.Items.Insert(0, "0");
            ddlDuracion.Items.Insert(1, "10");
            ddlDuracion.Items.Insert(2, "15");
            ddlDuracion.Items.Insert(3, "20");
            ddlDuracion.Items.Insert(4, "25");
            ddlDuracion.Items.Insert(5, "30");
            ddlDuracion.Items.Insert(6, "35");
            ddlDuracion.Items.Insert(7, "40");            
            ddlDuracion.Items.Insert(8, "50");
            ddlDuracion.Items.Insert(9, "60");


            ddlBloque.Items.Insert(0,"No");
            ddlBloque.Items.Insert(1, "Si");
            
        }

    

        protected void cambioFecha(string fecha) {
            limpiarParametros();
            fechaCalendario = fecha;
            inpFecha.Value = fecha;

            if (ddlTipoConsultorio.SelectedValue != "0") {
                int idTipoConsultorio = Convert.ToInt32(ddlTipoConsultorio.SelectedValue);
                actualizarConsultorios(idTipoConsultorio);
            }
        }

        private void actualizarConsultorios(int idTipoConsultorio) {
            /// se listan todos los consultorios ACTIVOS para el tipo de consultorio
            ConConsultorioCollection cons = new Select().From(Schemas.ConConsultorio)
                .Where(ConConsultorio.Columns.IdTipoConsultorio).IsEqualTo(idTipoConsultorio)
                .And(ConConsultorio.Columns.Activo).IsEqualTo(true)
                .OrderAsc(ConConsultorio.Columns.Nombre)
                .ExecuteAsCollection<ConConsultorioCollection>();

            dtlConsultorios.DataSource = cons;
            dtlConsultorios.DataKeyField = "idConsultorio";
            dtlConsultorios.DataBind();
        }

        protected void dtlConsultorios_ItemDataBound(object sender, DataListItemEventArgs e) {
            int idConsultorio = Convert.ToInt32(dtlConsultorios.DataKeys[e.Item.ItemIndex].ToString());
            
            string hoy = DateTime.Now.ToString().Substring(0, 10);
            DateTime fecha = DateTime.Parse(cldTurno.SelectedDate.ToShortDateString()); 
                //Convert.ToDateTime(txtFecha.Text);
            
            LinkButton lnkConsultorio = (LinkButton)e.Item.FindControl("lnkConsultorio");
            lnkConsultorio.CommandArgument = idConsultorio.ToString();
            lnkConsultorio.Visible = (fecha >= Convert.ToDateTime(hoy));

            Image imgLibre = (Image)e.Item.FindControl("imgLibre");
            BulletedList lstOcupa = (BulletedList)e.Item.FindControl("lstOcupa");
            Label lblEstado = (Label)e.Item.FindControl("lblEstado");
            DataTable dt = getOcupacion(idConsultorio);

            lstOcupa.Style.Value = "color:Maroon; font-Weight:bolder;";

            if (dt.Rows.Count > 0) {
                lblEstado.Text = "Ocupacion " + Rutinas.getNombreDia(DateTime.Parse(cldTurno.SelectedDate.ToShortDateString())) + ' ' + cldTurno.SelectedDate.ToShortDateString() ;
                imgLibre.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta32.png";
                for (int i = 0; i < dt.Rows.Count; i++) {
                    //lstOcupa.Items.Insert(i, "Agenda n°" + dt.Rows[i]["idAgenda"].ToString() + ' ' + dt.Rows[i]["Rango"].ToString());
                    lstOcupa.Items.Insert(i, "Agenda " + dt.Rows[i]["Rango"].ToString());
                    lstOcupa.Items[i].Value = "AgendaEdit.aspx?idAgenda=" + dt.Rows[i]["idAgenda"].ToString();
                }
                lstOcupa.Visible = true;
            } else {
                lblEstado.Text = "Libre " + Rutinas.getNombreDia(DateTime.Parse(cldTurno.SelectedDate.ToShortDateString()))  + ' ' + cldTurno.SelectedDate.ToShortDateString();
                imgLibre.ImageUrl = "~/App_Themes/consultorio/Agenda/tu-lector-icono-5536-32.png";
                lstOcupa.Visible = false;
            }
        }

        private DataTable getOcupacion(int idConsultorio) {
            DataTable dt = new Select("idAgenda, ', ' + horaInicio + ' - ' + horaFin as Rango").From(Schemas.ConAgenda)
                .Where(ConAgenda.Columns.IdConsultorio).IsEqualTo(idConsultorio)
                .And(ConAgenda.Columns.Fecha).IsEqualTo(DateTime.Parse(cldTurno.SelectedDate.ToShortDateString()) )
                .And (ConAgenda.Columns.IdAgendaEstado).IsNotEqualTo(3)
                .OrderAsc("HoraInicio, HoraFin").ExecuteDataSet().Tables[0];
            return dt;
        }

        protected void cmdActualizar_Click(object sender, ImageClickEventArgs e) {
            cambioFecha(cldTurno.SelectedDate.ToShortDateString());
        }

        protected void dtlConsultorios_SelectedIndexChanged(object sender, EventArgs e) {
            int idConsultorio = Convert.ToInt32(dtlConsultorios.SelectedValue);
            ConConsultorio c = new ConConsultorio(idConsultorio);
            Label lbl = (Label)dtlConsultorios.SelectedItem.FindControl("lblEstado");

         //   txtFecha.Text = lbl.Text.Substring((lbl.Text.Length - 10), 10);
            inpFecha.Value = cldTurno.SelectedDate.ToShortDateString(); 
            divErr.Visible = false;
            divErrFiltro.Visible = false;
            filaActivacion.Visible = false;
            filaValidacion.Visible = false;
            ddlEstado.SelectedIndex = 0;
            lblSeleccion.Text = c.Nombre + ", " + Rutinas.getNombreDia(DateTime.Parse(cldTurno.SelectedDate.ToShortDateString())) + ' ' + cldTurno.SelectedDate.ToShortDateString() ;
            acordionParametros.Enabled = true;
            acordionGrilla.Enabled = false;
            Acordeon.SelectedIndex = 0;


            if (ddlTipoAgenda.SelectedValue == "Médica")
            {
                if (ddlEspecialidad.SelectedIndex != 0)
                {
                    SysRelEspecialidadEfector r = new Select().From(Schemas.SysRelEspecialidadEfector)
                                 .Where(SysRelEspecialidadEfector.Columns.IdEfector).IsEqualTo(c.IdEfector)
                                 .And(SysRelEspecialidadEfector.Columns.IdEspecialidad).IsEqualTo(int.Parse(ddlEspecialidad.SelectedValue))
                                 .ExecuteSingle<SysRelEspecialidadEfector>();
                    if (r != null)
                    {
                        ddlDuracion.SelectedValue = r.DuracionTurno.ToString();
                      //  txtSobreturnos.Value = r.MaximoSobreturnos.ToString();

                        //txtTurnosDia.Value = r.PorcentajeTurnosDia.ToString();
                        //txtTurnosAnticipados.Value = r.PorcentajeTurnosAnticipado.ToString();
                    }

                }
            }
            else
                ddlDuracion.SelectedValue = "0";
        }

        protected void btnGrabar_Click(object sender, EventArgs e) {
           
                Label lbl = (Label)dtlConsultorios.SelectedItem.FindControl("lblEstado"); ///me aseguro la fecha seleccionada
                string fechaSel = lbl.Text.Substring((lbl.Text.Length - 10), 10);
                string st = validar(fechaSel);
                
                if (st == string.Empty) {
                    grabar();
                    Response.Redirect("AgendaporEspacio.aspx", false);
                }            
        }

        private string validar(string fechaSel) {
            string st = string.Empty;
            bool showMsg = true;

            cValidator_gr1.IsValid = true;
            divErrFiltro.Visible = false;

            if (!Page.IsValid) {
                if (st != string.Empty) { st += Environment.NewLine; }
                st += "Errores encontrados en parámetros especificados:";
                showMsg = false;
            } else {
                showMsg = true;
                if (gvProgramacion.Rows.Count < 1) {
                    if (st != string.Empty) { st += Environment.NewLine; }
                    st += "- debe antes agregar programación al paquete de agendas a grabar";
                }
                string regs = validarRegistros(fechaSel);
                if (regs != string.Empty) {
                    if (st != string.Empty) { st += Environment.NewLine; }
                    st += regs;
                    cValidator_gr1.IsValid = false;
                    cValidator_gr1.ErrorMessage = st;
                }
            }

            cValidator_gr2.ErrorMessage = (showMsg) ? st : "";
            cValidator_gr1.IsValid = (st == string.Empty) ? true : false;
            divErrFiltro.Visible = (st == string.Empty) ? false : true; 
            updfiltro.Update(); 

            return st;
        }

        private string validarRegistros(string fechaSel) {
            string st = string.Empty;

            for (int i = 0; i < dtGrilla.Rows.Count; i++) {
                int idConsultorio = Convert.ToInt32(dtlConsultorios.DataKeys[dtlConsultorios.SelectedIndex]);
                int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
                DateTime fechaProg = Convert.ToDateTime(fechaSel);
                DateTime Inicio = Convert.ToDateTime(fechaSel + " " + txtHoraDesde.Value + ":00");
                DateTime Fin = Convert.ToDateTime(fechaSel + " " +txtHoraHasta.Value + ":00");
                Image img = (Image)gvProgramacion.Rows[i].FindControl("imgEstadoErr");
                

                if (horarioValido(idConsultorio,idProfesional, fechaProg, Inicio, Fin) == string.Empty) {
                    st = parametrosCorrectos(i);
                    if (st == string.Empty) {
                        img.ImageUrl = "../App_Themes/consultorio/Agenda/check_verde16.png";
                        img.Visible = true;                     
                    } else {
                        img.ImageUrl = "../App_Themes/consultorio/Agenda/turnoreservado.png";
                        img.Visible = true;
                    }
                } else {
                    img.ImageUrl = "background-image: url('../App_Themes/consultorio/Agenda/turnoeliminado.png');background-repeat:no-repeat;";
                    img.Visible = true;
                    if (st != string.Empty) { st += Environment.NewLine; }
                    st = "- el/los horarios marcados han sido ocupados por otra agenda"; 
                }
            }
            return st;
        }

        private string parametrosCorrectos(int i) {
            string st = string.Empty;
            int cantidad = getCantidadTurnos(i);         
            return st;
        }

        private int getCantidadTurnos(int i) {
            /// no grabo txtCantidad, hago el cálculo de cantidad sobre la cantidad de tiempo / la duración en minutos <<>> //
            string hIni = dtGrilla.Rows[i]["hIni"].ToString();
            string hFin = dtGrilla.Rows[i]["hFin"].ToString();
            int duracion = Convert.ToInt32(dtGrilla.Rows[i]["Duracion"]);

            if (!(hIni == "") & !(hFin == " ")) {
                TimeSpan diff = Convert.ToDateTime(hFin) - Convert.ToDateTime(hIni);
                int h = diff.Hours;
                int m = diff.Minutes;
                m += h * 60;
                int cantidadturnos = (m / duracion);
                return cantidadturnos;
            } else return 0;
        }

        private void grabar() {
            for (int i = 0; i < gvProgramacion.Rows.Count; i++) {
                ConAgenda ag = new ConAgenda();

                ag.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                ag.IdServicio = Convert.ToInt32(ddlServicio.SelectedValue);
                if (ddlTipoAgenda.SelectedValue == "Médica")
                {
                    ag.IdEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
                    ag.IdTipoPrestacion = 0;
                }
                else
                {
                    ag.IdEspecialidad = 0;
                    ag.IdTipoPrestacion = Convert.ToInt32(ddlEspecialidad.SelectedValue); 
                }
                ag.IdProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
                ag.Fecha =Convert.ToDateTime( dtGrilla.Rows[i]["Fecha"].ToString()); // Convert.ToDateTime(fechaSel);
                ag.HoraInicio = dtGrilla.Rows[i]["hIni"].ToString();
                ag.HoraFin = dtGrilla.Rows[i]["hFin"].ToString();
                ag.Duracion = Convert.ToInt32(dtGrilla.Rows[i]["Duracion"]);
                ag.IdConsultorio = Convert.ToInt32(dtGrilla.Rows[i]["idConsultorio"]);

                if (dtGrilla.Rows[i]["Bloque"].ToString().ToUpper() == "SI")
                    ag.CitarPorBloques = true;
                else
                    ag.CitarPorBloques = false;

                ag.MaximoSobreturnos = 100;// Convert.ToInt32(txtSobreturnos.Value);
            //    ag.Reservados = 0; // Convert.ToInt32(txtReservados.Text);
                ag.CantidadInterconsulta = 0; // Convert.ToInt32(txtInterconsulta.Text);
                ag.IdAgendaEstado = Convert.ToInt32(dtGrilla.Rows[i]["idAgendaEstado"]);
                if (ag.IdAgendaEstado == 1) { ag.TurnosDisponibles = true; } else { ag.TurnosDisponibles = false; }
                ag.Save();

                if (ag.CantidadInterconsulta > 0) { grabarInterconsulta(ag); }
                if (ag.IdAgendaEstado > 1) { grabarActivacion(ag, Convert.ToDateTime(dtGrilla.Rows[i]["fActivacion"])); }
                grabarAuditoria(ag);
            }
        }

        private void grabarActivacion(ConAgenda ag, DateTime fActivacion) {
            ConAgendaBloqueo act = new ConAgendaBloqueo();

            act.IdAgenda = ag.IdAgenda;
            act.IdUsuario = SSOHelper.CurrentIdentity.Id;
            act.FechaActivacion = fActivacion;
            act.AgendaActivada = false;
            act.Save();

            /// las agendas se activan desde el SP CON_ActivarAgendasBloqueadas (programar tarea SQL)
        }

        private void grabarInterconsulta(ConAgenda ag) {
           
        }

        private string getHoraInterconsulta(int i, bool agregar) {
            string hora = string.Empty;
            string h = string.Empty;
            string m = string.Empty;
            string ultimaHora = txtHoraHasta.Value; // getHorario(txtHfin.Text, txtMfin.Text);
            int duracion = Convert.ToInt32(ddlDuracion.SelectedValue);

            h = ultimaHora.Substring(0, 2);
            m = ultimaHora.Substring(3, 2);
            int hs = Convert.ToInt32(h);
            int min = Convert.ToInt32(m);

            if (agregar) {
                min += (duracion * i);
            } else {
                min -= (duracion * i);
            }

            while (min >= 60) { if (agregar) { hs += 1; } else { hs -= 1; } min -= 60; }

            h = hs.ToString();
            m = min.ToString();

            if (h.Length == 1) { h = "0" + h; }
            if (m.Length == 1) { m = "0" + m; }
            hora = h + ":" + m;

            return hora;
        }

        private void grabarAuditoria(ConAgenda ag) {
            string h = Convert.ToString(DateTime.Now.Hour);
            string m = Convert.ToString(DateTime.Now.Minute);
            if (h.Length < 2) { h = "0" + h; }
            if (m.Length < 2) { m = "0" + m; }
            string Hora = h + ":" + m;

            ConAgendaAuditorium aud = new ConAgendaAuditorium();
            aud.IdAgenda = ag.IdAgenda;
            aud.IdUsuario = SSOHelper.CurrentIdentity.Id;
            aud.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
            aud.IdAgendaEstado = ag.IdAgendaEstado;
            aud.IdServicio = ag.IdServicio;
            aud.IdProfesional = ag.IdProfesional;
            aud.IdEspecialidad = ag.IdEspecialidad;
            aud.IdConsultorio = ag.IdConsultorio;
            aud.Fecha = ag.Fecha;
            aud.HoraInicio = ag.HoraInicio;
            aud.HoraFin = ag.HoraFin;
            aud.Duracion = ag.Duracion;
        //    aud.Reservados = ag.Reservados;
            aud.MaxSobreturnos = ag.MaximoSobreturnos;
            aud.CitarPorBloques = 1; // ag.CitarPorBloques;
            aud.FechaModificacion = DateTime.Now;
            aud.HoraModificacion = Hora;
            aud.Save();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e) {
            cValidator_gr2.IsValid = true;
            divErr.Visible = false;
            filaValidacion.Visible = false;
            filaActivacion.Visible = (Convert.ToInt32(ddlEstado.SelectedValue) == 1) ? false: true;
            pnlGrilla.Update();
        }

        protected void ddlTipoAgenda_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (ddlTipoAgenda.SelectedValue == "Prestaciones") //tipo de prestacion
            {
                ConTipoPrestacionCollection e1 = new SubSonic.Select()
             .From(Schemas.ConTipoPrestacion)
             .Where(ConTipoPrestacion.Columns.IdTipoPrestacion).IsNotEqualTo(0)
             .OrderAsc(ConAgendaEstado.Columns.Nombre)
             .ExecuteAsCollection<ConTipoPrestacionCollection>();
                ddlEspecialidad.DataSource = e1;
                ddlEspecialidad.DataValueField = ConTipoPrestacion.Columns.IdTipoPrestacion;
                ddlEspecialidad.DataTextField = ConTipoPrestacion.Columns.Nombre;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, "--Seleccione Tipo Prestacion--");

            }
            if (ddlTipoAgenda.SelectedValue == "Médica") //tipo de prestacion
            {                
                ///Carolina: Modifico para que se muestren los servicios del efector   
                ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector,-1).GetDataSet();
                ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
                ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, "--Seleccione--");
                ///
            }
            pnlGrilla.Update();
        }

        protected void btnAgregar_Click(object sender, EventArgs e) {           
            if (Page.IsValid)
            {
                    string fechaSel = inpFecha.Value.ToString();
                    string st = validacionCorrecta(fechaSel);

                    if (st == string.Empty)
                    {
                        divErr.Visible = false;

                        int idConsultorio = Convert.ToInt32(dtlConsultorios.DataKeys[dtlConsultorios.SelectedIndex]);
                        ConConsultorio c = new ConConsultorio(idConsultorio);
                        string inicio = txtHoraDesde.Value; // getHorario(txtHini.Text, txtMini.Text);
                        string fin = txtHoraHasta.Value; // getHorario(txtHfin.Text, txtMfin.Text);
                        string duracion = ddlDuracion.SelectedValue; //txtDuracion.Text;
                        int idAgendaEstado = Convert.ToInt32(ddlEstado.SelectedValue);
                        string estado = ddlEstado.SelectedItem.Text;
                        DateTime fecha = Convert.ToDateTime(fechaSel);
                        DateTime fActivacion = (idAgendaEstado == 2) ? getFechaActivacion() : Convert.ToDateTime("01/01/1900");

                        string turnosDia = "0";// txtTurnosDia.Value;
                        string turnosAnticipados = "0";// txtTurnosAnticipados.Value;
                        string bloque = ddlBloque.SelectedValue;
                        string sobreTurnos = "0";// txtSobreturnos.Value;

                      
                        insertarFila(fecha, idConsultorio, c.Nombre, inicio, fin, duracion, sobreTurnos, turnosDia, turnosAnticipados,bloque, idAgendaEstado, estado, fActivacion);
                        actualizarGrilla();
                        limpiarParametros();
                        acordionGrilla.Enabled = true;
                    }
                    else
                    {
                        divErr.Visible = true; 
                        pnlGrilla.Update();
                    }              
            }
        }

        private DateTime getFechaActivacion() {
            if (chkActivacion.Checked) {
                return Convert.ToDateTime(txtFechaActivacion.Text + " "
                                     + txtHoraActivacion.Text + ":"
                                     + txtMinutosActivacion.Text + ":00");
            } else {
                return Convert.ToDateTime("01/01/1900");
            }
        }

        private string getHorario(string h, string m) {
            if (h.Length == 1) { h = "0" + h; }
            if (m.Length == 1) { m = "0" + m; }
            return h + ":" + m;
        }

        private void limpiarParametros() {
            cValidator_gr2.IsValid = true;
            divErr.Visible = false;
            ddlEstado.SelectedIndex = 0;
            filaActivacion.Visible = false;
            lblSeleccion.Text = "";
            acordionGrilla.Enabled = (gvProgramacion.Rows.Count >0)? true: false;
            acordionParametros.Enabled = false;
            Acordeon.SelectedIndex = 1;
            pnlGrilla.Visible = true;
            pnlGrilla.Update();
        }

        private string validacionCorrecta(string fechaSel) {
            string st = string.Empty;
            bool showMsg = true;

            if (!Page.IsValid) {
                if (st != string.Empty) { st += Environment.NewLine; }
                st += "Errores encontrados en parámetros especificados";
                showMsg = false;
            } else {
                if(chkActivacion.Checked & !fechaValida(txtFechaActivacion.Text)){
                    st += "Formato de fecha de activación incorrecto (dd/MM/aaaa)";
                } else {
                    int idConsultorio = Convert.ToInt32(dtlConsultorios.DataKeys[dtlConsultorios.SelectedIndex]);
                    DateTime Inicio =Convert.ToDateTime(fechaSel);
                    DateTime Fin =Convert.ToDateTime(fechaSel);

                    int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
                    DateTime fechaProg = Convert.ToDateTime(fechaSel);
                    if (txtHoraDesde.Value == "") st += "- ingresar hora de inicio";
                    else  Inicio = Convert.ToDateTime(fechaSel + " " + txtHoraDesde.Value + ":00");

                    if (txtHoraHasta.Value == "") st += "- ingresar hora de fin";
                    else  Fin = Convert.ToDateTime(fechaSel + " " + txtHoraHasta.Value + ":00");

                    if (ddlDuracion.SelectedValue == "0") st += "- seleccionar duración del turno";

                    showMsg = true;

                    if (st=="")
                    {
                    if (Fin <= Inicio) {
                        if (st != string.Empty) { st += Environment.NewLine; }
                        st += "- hora de finalización menor o igual a hora de inicio";
                    }
                    if (pisaFilaAgregada(idConsultorio, fechaProg, Inicio, Fin)) {
                        if (st != string.Empty) { st += Environment.NewLine; }
                        st += "- el rango horario ya ha sido agregado al paquete de agendas a grabar";
                    }
                    if (Convert.ToInt32(ddlEstado.SelectedValue) == 2)
                    {
                        DateTime factivacion = Convert.ToDateTime(txtFechaActivacion.Text);
                        if (factivacion > fechaProg) {
                            if (st != string.Empty) { st += Environment.NewLine; }
                            st += "- la fecha de activacion es mayor a la fecha de programación de agenda";
                        }
                        if (factivacion < DateTime.Now) {
                            if (st != string.Empty) { st += Environment.NewLine; }
                            st += "- la fecha de activacion es una fecha vencida";
                        }
                    }
                    st += horarioValido(idConsultorio, idProfesional,fechaProg, Inicio, Fin);
                    }
                }
            }

            cValidator_gr2.ErrorMessage = (showMsg) ? st : "";
            cValidator_gr2.IsValid = (st == string.Empty) ? true : false;
            filaValidacion.Visible = (st == string.Empty) ? false : true; 
            pnlGrilla.Update();

            return st;
        }

        private bool fechaValida(string f) {
            if (f.Length < 10) {
                return false;
            } else {
                try {
                    DateTime fecha = Convert.ToDateTime(f);
                    return true;
                } catch { return false; }
            }
        }

        private bool pisaFilaAgregada(int idConsultorio, DateTime fechaProg, DateTime Inicio, DateTime Fin) {
            bool pisa = false;
            
            /// sumo un minuto al inicio y resto uno al final para que no pise un horario que inicie o termine en rango ant. o post.
            Inicio = Inicio.AddMinutes(1);
            Fin = Fin.AddMinutes(-1);

            for (int i = 0; i < dtGrilla.Rows.Count; i++) {
                int id = Convert.ToInt32(dtGrilla.Rows[i]["idConsultorio"]);
                DateTime fecha = Convert.ToDateTime(dtGrilla.Rows[i]["Fecha"]);
                DateTime finicio = Convert.ToDateTime(dtGrilla.Rows[i]["Fecha"].ToString().Substring(0,10) 
                                                    + " " + dtGrilla.Rows[i]["hIni"].ToString() + ":00");
                DateTime ffin = Convert.ToDateTime(dtGrilla.Rows[i]["Fecha"].ToString().Substring(0, 10)
                                                    + " " + dtGrilla.Rows[i]["hFin"].ToString() + ":00");
                if (fechaProg == fecha) {
                    if (Inicio >= finicio & Inicio <= ffin) { pisa = true; break; }
                    if (Fin >= finicio & Fin <= ffin) { pisa = true; break; }
                }
            }
            return pisa;
        }

        protected string horarioValido(int idConsultorio,int idProfesional, DateTime fechaProg, DateTime Inicio, DateTime Fin) {
            string st = string.Empty;           
            /// pregunto por la ocupacion restando antes un minuto al inicio enviados como parametros
            Inicio = Inicio.AddMinutes(1);
            Fin = Fin.AddMinutes(-1);

            DataRow r = SPs.ConAgendaRangoOcupado(SSOHelper.CurrentIdentity.IdEfector, idConsultorio, idProfesional, fechaProg.ToShortDateString(), Inicio.TimeOfDay.ToString(), Fin.TimeOfDay.ToString()).GetDataSet().Tables[0].Rows[0];
            bool inicioOk = (bool)r["validacionInicio"];
            bool finOk = (bool)r["validacionFin"];

            if (!inicioOk || !finOk)
            {
                st = "El profesional ya tiene asignada una agenda en el mismo horario ó";
                if (!inicioOk & finOk) { st += Environment.NewLine + " la hora de inicio se superpone con otra agenda programada en el rango solicitado"; }
                if (!inicioOk & !finOk) { st += Environment.NewLine + " la hora de inicio se superpone con otra agenda programada en el rango solicitado ó"; }
                if (!finOk) { st += Environment.NewLine + " la hora de finalización se superpone con otra agenda programada en el rango solicitado"; }
            }
            
            return st;            
        }
        
        protected void gvProgramacion_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                ImageButton cmdQuitar = (ImageButton)e.Row.FindControl("cmdQuitar");
                cmdQuitar.CommandArgument = gvProgramacion.DataKeys[e.Row.RowIndex].ToString();
                cmdQuitar.CommandName = "cmdQuitar";
            }
        }

        protected void gvProgramacion_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "cmdQuitar") { eliminarFila(gvProgramacion.SelectedIndex); }
        }

        private void messageBox(string p, string argument) {
            btnShowMsg.Text = argument;
            lblPopup.Text = p;
            mPopupMsg.Show();
        }

        protected void gvProgramacion_SelectedIndexChanged(object sender, EventArgs e) {
            eliminarFila(gvProgramacion.SelectedIndex);
        }

        private void eliminarFila(int Index) {
            dtGrilla.Rows[Index].Delete();
            dtGrilla.AcceptChanges();
            gvProgramacion.DataSource = dtGrilla;
            gvProgramacion.DataBind();
        }

        protected void limpiarListaConsultotrios() { 
            for (int i = 0; i < dtGrilla.Rows.Count; i++) {
                dtGrilla.Rows.Remove(dtGrilla.Rows[i]); 
			}
            dtlConsultorios.DataSource = dtGrilla;
            dtlConsultorios.DataBind();
        }

        protected void cmdFecha_Click(object sender, ImageClickEventArgs e) {

        }

        protected void chkActivacion_CheckedChanged(object sender, EventArgs e) {
            txtFechaActivacion.Visible = chkActivacion.Checked;
            btnFechaActivacion.Visible = chkActivacion.Checked;
            txtHoraActivacion.Visible = chkActivacion.Checked;
            txtMinutosActivacion.Visible = chkActivacion.Checked;

            txtFechaActivacion.Enabled = chkActivacion.Checked;
            btnFechaActivacion.Enabled = chkActivacion.Checked;
            txtHoraActivacion.Enabled = chkActivacion.Checked;
            nUpDownEx_txtHoraActivacion.Enabled = chkActivacion.Checked;
            txtMinutosActivacion.Enabled = chkActivacion.Checked;
            nUpDownEx_txtMinutosActivacion.Enabled = chkActivacion.Checked;

            if (chkActivacion.Checked) {
                txtFechaActivacion.Text = inpFecha.Value.ToString();
                txtHoraActivacion.Text = "0";
                txtMinutosActivacion.Text = "0";
            }
        }

        protected void cmdConsulta_Click(object sender, ImageClickEventArgs e) {
          
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            cambioFecha(cldTurno.SelectedDate.ToShortDateString());            
        }

        protected void bntVerOcupacion_Click(object sender, EventArgs e)
        {
            string url = "AgendaDistribucion.aspx";
            if (ddlTipoConsultorio.SelectedIndex > 0) { url += "?idTipoConsultorio=" + ddlTipoConsultorio.SelectedValue; }

            if (cldTurno.SelectedDate.ToShortDateString() != string.Empty)
            {
                url += (url.Length > 23) ? "&" : "?";
                url += "fechaConsulta=" + cldTurno.SelectedDate.ToShortDateString();
            }
            Response.Redirect(url);
        }

        protected void ddlProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProfesional.SelectedValue != "0")
            {
                //Busca las agendas del profesional anteriores a la fecha actual que aun esten activas (es decir sin Cerrar).
                DataTable p = new Select().From(Schemas.ConAgenda)
                                .Where(ConAgenda.Columns.IdProfesional)
                                .IsEqualTo(int.Parse(ddlProfesional.SelectedValue))
                                .And (ConAgenda.Columns.IdAgendaEstado).IsEqualTo(1)
                                .And(ConAgenda.Columns.Fecha).IsLessThan(DateTime.Now) 
                                .ExecuteDataSet().Tables[0];
                if (p.Rows.Count > 3) //Si tiene mas de tres activas no se puede crear la agenda
                {
                    cValidator_gr1.IsValid = false;
                    cValidator_gr1.ErrorMessage = "El profesional tiene más de tres agendas activas.";
                    divErrFiltro.Visible = true;                    
                }
                updfiltro.Update(); 
            }

        }
    }
}

