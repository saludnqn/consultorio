using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DalSic;
using SubSonic;
using Salud.Security.SSO;

namespace Consultorio.Agenda {
    public partial class AgendaPorRango : System.Web.UI.Page {

        private DataTable dtGrilla {
            get { return ViewState["dtGrilla"] == null ? generarCalendario() : ViewState["dtGrilla"] as DataTable; }
            set { ViewState["dtGrilla"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {           
        
                if (!IsPostBack) {
                    if (Acordeon.SelectedIndex == 0) { divbusqueda.Visible = true; }
                }          
        }

        private void LlenarDropDowns() {
            /// estos ddls son cargados con condiciones where, por eso no son subsonic <<>> //
            ConAgendaEstadoCollection eag = new SubSonic.Select()
                .From(Schemas.ConAgendaEstado)
                .Where(ConAgendaEstado.Columns.IdAgendaEstado).IsLessThan(3)
                .ExecuteAsCollection<ConAgendaEstadoCollection>();
            ddlEstadoAgenda.DataSource = eag;
            ddlEstadoAgenda.DataTextField = ConAgendaEstado.Columns.Nombre;
            ddlEstadoAgenda.DataValueField = ConAgendaEstado.Columns.IdAgendaEstado;
            ddlEstadoAgenda.DataBind();
            ddlEstadoAgenda.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlCons.DataSource = new ConConsultorioCollection()
                .Where("idTipoConsultorio", ddlTipoConsultorio.SelectedValue).Load();
            ddlCons.DataTextField = ConConsultorio.Columns.Nombre;
            ddlCons.DataValueField = ConConsultorio.Columns.IdConsultorio;
            ddlCons.DataBind();
            ddlCons.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args) {
            bool valido = true;
            string st = "";

            if (ddlServicio.SelectedIndex == 0) {
                valido = false;
                st += "servicio";
            }
            if (ddlEspecialidad.SelectedIndex == 0) {
                valido = false;
                if (st.Length > 0) st += ", ";
                st += "especialidad";
            }
            if (ddlProfesional.SelectedIndex == 0) {
                valido = false;
                if (st.Length > 0) st += ", ";
                st += "profesional";
            }
            if (ddlTipoConsultorio.SelectedIndex == 0) {
                valido = false;
                if (st.Length > 0) st += ", ";
                st += "tipo de consultorio";
            }
            if (txtFinicio.Value  == "") {
                valido = false;
                if (st.Length > 0) st += ", ";
                st +=  "fecha de inicio";
            }
            if (txtFfin.Value == "") {
                valido = false;
                if (st.Length > 0) st += ", ";
                st += "fecha de fin";
            }
            if (!valido) { 
                CustomValidator1.ErrorMessage = "* Debe proporcionar los datos siguientes para continuar: " + st;
                args.IsValid = valido;
                return;
            }

            DateTime fi = Convert.ToDateTime(txtFinicio.Value);
            DateTime ff = Convert.ToDateTime(txtFfin.Value);
            if (ff < fi) {
                CustomValidator1.ErrorMessage = "* La fecha final no puede ser menor a la inicial";
                args.IsValid =false;
                return;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                divbusqueda.Visible = true ;
                divcalendario.Visible = true;
                divinfo.Visible = false;
                LlenarDropDowns();
                Actualizar();
                Acordeon.SelectedIndex = 1;
            }
        }

        private void Actualizar() {
            dtGrilla = generarCalendario();
            gvAgendas.DataSource = dtGrilla;
            gvAgendas.DataBind();

            for (int i = 0; i < gvAgendas.Rows.Count -1; i++) {
                DateTime f = Convert.ToDateTime(gvAgendas.Rows[i].Cells[1].Text);
                if (f < DateTime.Now.Date) { deshabilitarFila(i); }
            }
        }

        private void deshabilitarFila(int i) {
            CheckBox ch = (CheckBox)gvAgendas.Rows[i].FindControl("Checkbox1");
            ch.Checked = false;
            ch.Visible = false;

            ImageButton im1 = (ImageButton)gvAgendas.Rows[i].FindControl("cmdEliminar");
            im1.Enabled = false;
            im1.Visible = false;

            ImageButton im2 = (ImageButton)gvAgendas.Rows[i].FindControl("cmdDuplicar");
            im2.Enabled = false;
            im2.Visible = false;
            //falta para control detalles
        }

        private DataTable generarCalendario() {
            DataTable dTable = new DataTable();
            
            int idServicio = Convert.ToInt32(ddlServicio.SelectedValue);
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
            int idConsultorioTipo = Convert.ToInt32(ddlTipoConsultorio.SelectedValue);
            DateTime fi = Convert.ToDateTime(txtFinicio.Value);
            DateTime ff = Convert.ToDateTime(txtFfin.Value);

            dTable = getDataTableLleno(SPs.ConGetAgendasByParam( idServicio, idEspecialidad, idProfesional, idConsultorioTipo, fi, ff).GetDataSet().Tables[0]);
            dTable = Rutinas.getDataTableOrdenado(dTable, "Fecha");

            return dTable;                            
        }

        private DataTable getDataTableLleno(DataTable dTable) {
            DateTime f = Convert.ToDateTime(txtFinicio.Value);
            DateTime ffin = Convert.ToDateTime(txtFfin.Value);
            ffin = ffin.AddDays(1);

            while (f <= ffin) {
                if (!existeFechaEnDataTable(dTable, f)) { insertarFilaEnDataTable(dTable, f, 0); }
                f = f.AddDays(1);
            }
            return dTable;
        }

        private bool existeFechaEnDataTable(DataTable dTable, DateTime f) {
            /// determino si en datatable existe o no fecha especificada
            bool existe = false;
            for (int i = 0; i < dTable.Rows.Count; i++) {
                DateTime fDt = Convert.ToDateTime(dTable.Rows[i]["Fecha"]);
                if (f == fDt) { existe = true; break; }
            }
            return existe;
        }

        private void insertarFilaEnDataTable(DataTable dt, DateTime f, int idAg) {
            /// inserto en datatable una fila en blanco para la fecha especificada
            DataRow newRow;
            newRow = dt.NewRow();
            newRow["idAgenda"] = idAg;
            newRow["Fecha"] = Convert.ToString(f).Substring(0, 10);
            newRow["hIni"] = "__:__";
            newRow["hFin"] = "__:__";
            newRow["Duracion"] = "0";
            newRow["idConsultorio"] = "0";
            newRow["Consultorio"] = "-";
            newRow["Bloques"] = "0";
            newRow["MaxSbts"] = "0";
            newRow["Reservados"] = "0";
            newRow["idAgendaEstado"] = "0";
            newRow["Estado"] = "-";
            dt.Rows.Add(newRow);
        }

        protected void gvAgendas_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            //revisar formato de datos
            dtGrilla = dtGrilla;
        }

        protected void gvAgendas_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                string url;
                ImageButton cmdDetalles = (ImageButton)e.Row.Cells[10].FindControl("cmdDetalles");
                cmdDetalles.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString()  ;
                ImageButton cmdEliminar = (ImageButton)e.Row.Cells[10].FindControl("cmdEliminar");
                cmdEliminar.CommandArgument = Convert.ToString(e.Row.RowIndex);
                ImageButton cmdDuplicar = (ImageButton)e.Row.Cells[11].FindControl("cmdDuplicar");
                cmdDuplicar.CommandArgument = Convert.ToString(e.Row.RowIndex);

                if (e.Row.Cells[2].Text != "__:__") {
                    resaltarFila(e.Row, true);
                    bool tieneTurnos = contieneTurnos(e.Row.RowIndex);
                    url = (tieneTurnos ? "../../App_Themes/consultorio/Agenda/eliminardisabled.png" : "../../App_Themes/consultorio/Agenda/eliminar.png");
                    cmdEliminar.ImageUrl = url;
                    cmdEliminar.Enabled = !tieneTurnos;
                    e.Row.Enabled = !tieneTurnos;
                } else {
                    url = "../../App_Themes/consultorio/Agenda/eliminardisabled.png";
                    cmdEliminar.ImageUrl = url;
                    cmdEliminar.Enabled = false;
                    resaltarFila(e.Row, false);
                }
            }
        }

        private bool contieneTurnos(int rowIndex) {
            /// determino si el registro de la fecha seleccionada ya corresponde a una agenda grabada, y si la misma tiene turnos asociados
            int IdAgenda = Convert.ToInt32(dtGrilla.Rows[rowIndex]["idAgenda"]);
            if (IdAgenda > 0) {
                ConTurnoCollection t = new SubSonic.Select().From(Schemas.ConTurno)
                                    .Where(ConTurno.Columns.IdAgenda).IsEqualTo(IdAgenda)
                                    .ExecuteAsCollection<ConTurnoCollection>();
                return (t.Count > 0);
            } else return false;
        }

        private int getIdAgendaByParam(int rowIndex) {
          
            int idEfector = SSOHelper.CurrentIdentity.IdEfector;
            int idServicio = Convert.ToInt32(ddlServicio.SelectedValue);
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
            int idConsultorio = Convert.ToInt32(dtGrilla.Rows[rowIndex]["idConsultorio"]);
            string hIni = gvAgendas.Rows[rowIndex].Cells[2].Text;
            string hFin = gvAgendas.Rows[rowIndex].Cells[3].Text;
            DateTime fecha = Convert.ToDateTime(gvAgendas.Rows[rowIndex].Cells[1].Text);

            ConAgenda Agenda = new Select().From(Schemas.ConAgenda)
               .Where(ConAgenda.Columns.Fecha).IsEqualTo(fecha)
               .And(ConAgenda.Columns.IdServicio).IsEqualTo(idServicio)
               .And(ConAgenda.Columns.IdEspecialidad).IsEqualTo(idEspecialidad)
               .And(ConAgenda.Columns.IdProfesional).IsEqualTo(idProfesional)
               .And(ConAgenda.Columns.IdConsultorio).IsEqualTo(idConsultorio)
               .And(ConAgenda.Columns.HoraInicio).IsEqualTo(hIni)
               .And(ConAgenda.Columns.HoraFin).IsEqualTo(hFin)
               .ExecuteSingle<ConAgenda>();
            return Agenda.IdAgenda;
        }

        private void resaltarFila(GridViewRow gvRow, bool p) {
            /// resalto solo las filas con datos de agenda aplicados al calendario <<>> //
            for (int c = 0; c < gvAgendas.Columns.Count - 1; c++) { gvRow.Cells[c].Font.Bold = p; }
        }

        protected void gvAgendas_RowCommand(object sender, GridViewCommandEventArgs e) {
            string cmd = e.CommandName;

            divbusqueda.Visible = true;
            divcalendario.Visible = true;
            divinfo.Visible = false;

            switch (cmd) {
                case "cmdDetalles":
                    Response.Redirect("AgendaEdit.aspx?idAgenda=" + e.CommandArgument);
                    break;
                case "cmdEliminar":
                    eliminar(Convert.ToInt32(e.CommandArgument));
                    break;
                case "cmdDuplicar":
                    duplicar(Convert.ToInt32(e.CommandArgument));
                    break;
            }
        }

        private void duplicar(int fila) {
            /// almaceno fechas seleccionadas
            DataTable dtemp = getDataTableTemp();

            /// inserta un nuevo row para la fecha seleccionada
            DateTime fecha = Convert.ToDateTime(gvAgendas.Rows[fila].Cells[1].Text);
            int idAgenda = Convert.ToInt32(dtGrilla.Rows[fila]["idAgenda"]);

            DataRow dr = getDataRowInsertado(dtGrilla, fecha, idAgenda);
            gvAgendas.UpdateRow(fila + 1, true);
            dr.AcceptChanges();

            gvAgendas.DataSource = Rutinas.getDataTableOrdenado(dtGrilla, "Fecha, hIni"); 
            gvAgendas.DataBind();

            ///vuelvo a tildar filas antes tildadas
            for (int i = 0; i < dtemp.Rows.Count -1; i++) {
                DateTime f = Convert.ToDateTime(dtemp.Rows[i]["fecha"]);
                int filatemp = getFila(f);
                CheckBox ch = (CheckBox)gvAgendas.Rows[filatemp].FindControl("Checkbox1");
                ch.Checked = true;                
            }

            /// tildo filas de fecha duplicada
            CheckBox ch1 = (CheckBox)gvAgendas.Rows[fila].FindControl("Checkbox1");
            ch1.Checked = true;
            try {
                CheckBox ch2 = (CheckBox)gvAgendas.Rows[fila + 1].FindControl("Checkbox1");
                ch2.Checked = true;
            } catch { }
        }

        private int getFila(DateTime f) {
            int filatemp = 0;
            for (int i = 0; i < gvAgendas.Rows.Count -1 ; i++) {
                DateTime ffila = Convert.ToDateTime(gvAgendas.Rows[i].Cells[1].Text);
                if (f == ffila) { filatemp = i; }    
            }
            return filatemp;
        }

        private DataTable getDataTableTemp() {
            ///almaceno los números de filas checkeadas para volver a tildarlas luego
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("fecha");

            for (int i = 0; i < gvAgendas.Rows.Count -1 ; i++) {
                CheckBox ch = (CheckBox)gvAgendas.Rows[i].FindControl("Checkbox1");
                if (ch.Checked) {
                    DataRow dr = dtemp.Rows.Add();
                    dr["fecha"] = gvAgendas.Rows[i].Cells[1].Text;
                    dtemp.AcceptChanges();
                }
            }
            return dtemp;
        }

        private DataRow getDataRowInsertado(DataTable dt, DateTime f, int idAg) {
            /// inserto en dataset un nueva fila en blanco para la fecha generada y devuelvo la fila insertada <<>> //
            DataRow newRow = dt.NewRow();
            newRow["idAgenda"] = idAg;
            newRow["Fecha"] = Convert.ToString(f).Substring(0, 10);
            newRow["hIni"] = "__:__";
            newRow["hFin"] = "__:__";
            newRow["Duracion"] = "0";
            newRow["idConsultorio"] = "0";
            newRow["Consultorio"] = "-";
            newRow["Bloques"] = "0";
            newRow["MaxSbts"] = "0";
            newRow["Reservados"] = "0";
            newRow["idAgendaEstado"] = "0";
            newRow["Estado"] = "-";
            dt.Rows.Add(newRow);

            return newRow;
        }

        private void eliminar(int fila) {
            /// si estoy trabajando sobre una agenda deshabilito la agenda (no elimino), sino actualizo el dtGrilla en memoria <<>> //
            int idAgenda = Convert.ToInt32(dtGrilla.Rows[fila]["idAgenda"]);
            if (idAgenda > 0) {
                /// marco campo idAgendaEstado = 3 (agenda inactiva) <<>> //
                
                ConAgenda ag = new ConAgenda(idAgenda);
                
                ag.IdAgendaEstado = 3;
                ag.Save();
                grabarAuditoria(ag);
            } else {
                /// cargo en memoria el datatable con la fila limpia
                resetearDataRow(dtGrilla.Rows[fila], fila);
            }
            Actualizar();
        }

        private void resetearDataRow(DataRow dr, int fila) {
            /// reseteo la fila del dtGrilla
            dr.BeginEdit();

            dr["hIni"] = "__:__";
            dr["hFin"] = "__:__";
            dr["Duracion"] = "0";
            dr["idConsultorio"] = "0";
            dr["Consultorio"] = "-";
            dr["Bloques"] = "0";
            dr["MaxSbts"] = "0";
            dr["Reservados"] = "0";
            dr["idAgendaEstado"] = "0";
            dr["Estado"] = "-";

            dr.EndEdit();
            gvAgendas.UpdateRow(fila, true);
            dr.AcceptChanges();
        }

        protected void ChkBList1_SelectedIndexChanged(object sender, EventArgs e) {
            if (gvAgendas.Rows.Count > 0) {
                if (ChkBList1.SelectedItem.Selected) {
                    int dia = Convert.ToInt32(ChkBList1.SelectedValue);
                    tildarFechas(dia);
                }
            }
        }

        private void tildarFechas(int dia) {
            /// tilda la las filas correspondientes al de día de semana según parámetro
            for (int i = 0; i < gvAgendas.Rows.Count; i++) {
                DateTime fecha = Convert.ToDateTime(gvAgendas.Rows[i].Cells[1].Text);
                CheckBox chk = (CheckBox)gvAgendas.Rows[i].Cells[0].FindControl("CheckBox1");

                if (dia == 0) { chk.Checked = true; } else { if (dia == Rutinas.getNroDia(fecha)) { chk.Checked = true; } }
            }
        }

        private bool TildoFilas() {
            bool tildo = false;
            string nFila = string.Empty;

            for (int i = 0; i < gvAgendas.Rows.Count; i++) {
                CheckBox chk = (CheckBox)gvAgendas.Rows[i].Cells[0].FindControl("CheckBox1");
                if (chk.Checked) {
                    tildo = true;
                    nFila += i.ToString() + ";";
                }
            }
            Session["nFila"] = nFila;
            return tildo;
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            bool tildo = TildoFilas();

            divinfo.Visible = false;
            divbusqueda.Visible = true;
            
            if (tildo) {
                LlenarDropDowns();
                dvcontroles.Visible = true;
                Acordeon.SelectedIndex = 2;
                txtHini.Focus();
            } else {
                dvcontroles.Visible = false;
                Rutinas.MessageBox("Debe seleccionar antes las fechas a editar", Page);
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args) {
            /// para ganar tiempo y no crear demasiados validadores cargué todas las validaciones a un label <<>> //
            /// la/el guapo/a que se anime, lo cambia sin pedir permiso ;-) <<>> //
            bool valido = true;
            string st = "";

            if (string.IsNullOrEmpty(txtHini.Value)) {
                valido = false;
                if (st != "") { st += " - "; }
                st += "Debe indicar la hora de inicio";
            }
            if (string.IsNullOrEmpty(txtHfin.Value)) {
                valido = false;
                if (st != "") { st += " - "; }
                st += "* Debe indicar la hora de fin";
            }
            if (string.IsNullOrEmpty(txtDurac.Value)) {
                valido = false;
                if (st != "") { st += " - "; }
                st += "* Debe indicar la duración en minutos de cada turno";
            }
            if (txtDurac.Value == "0") {
                valido = false;
                if (st != "") { st += " - "; }
                st += "* Debe indicar la duración en minutos de cada turno";
            } else {
                if (string.IsNullOrEmpty(txtBloque.Value)) {
                    valido = false;
                    if (st != "") { st += Environment.NewLine; }
                    st += "* Debe indicar la cantidad de pacientes a citar por bloque (1 a " + getCantidadTurnos() + ")";
                } else {
                    int v = Convert.ToInt32(txtBloque.Value);
                    int max = getCantidadTurnos();
                    if (!(v > 0) || !(v <= max)) {
                        valido = false;
                        if (st != "") { st += Environment.NewLine; }
                        st += "*La cantidad de pacientes a citar por bloque debe estar entre 1 y " + max;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtReservados.Value)) {
                int v = Convert.ToInt32(txtReservados.Value);
                int max = getCantidadTurnos();
                if (!(v >= 0) || !(v <= max)) {
                    valido = false;
                    if (st != "") { st += Environment.NewLine; }
                    st += "*La cantidad de turnos a reservar debe ser un valor entre 0 y " + max;
                }
            }
            if (!string.IsNullOrEmpty(txtMaxSbts.Value)) {
                int v = Convert.ToInt32(txtMaxSbts.Value);
                int max = getCantidadTurnos();
                if (!(v >= 0) || !(v <= max)) {
                    valido = false;
                    if (st != "") { st += Environment.NewLine; }
                    st += "*La cantidad máxima de sobreturnos debe ser un valor entre 0 y " + max;
                }
            }
            if (ddlCons.SelectedIndex == 0) {
                valido = false;
                if (st != "") { st += Environment.NewLine; }
                st += "* Debe indicar el consultorio";
            }
            if (ddlEstadoAgenda.SelectedIndex == 0) {
                valido = false;
                if (st != "") { st += Environment.NewLine; }
                st += "* Debe indicar un estado para la agenda";
            }

            args.IsValid = valido;
            CustomValidator3.ErrorMessage = st;
            CustomValidator3.IsValid = valido;
        }

        private int getCantidadTurnos() {
            /// no grabo txtCantidad, hago el cálculo de cantidad sobre la cantidad de tiempo / la duración en minutos <<>> //
            string hIni = txtHini.Value;
            string hFin = txtHfin.Value;
            int duracion = Convert.ToInt32(txtDurac.Value);

            if (!(hIni == "") & !(hFin == " ")) {
                TimeSpan diff = Convert.ToDateTime(hFin) - Convert.ToDateTime(hIni);
                int h = diff.Hours;
                int m = diff.Minutes;
                m += h * 60;
                int cantidadturnos = (m / duracion);
                return cantidadturnos;
            } else return 0;
        }

        protected void btnGrabar_Click(object sender, EventArgs e) {
            
                if (Page.IsValid) {
                    //if (dtFilas.Rows.Count > 0) {
                        inicioGrabado();
                    //} else Rutinas.MessageBox("No se esctablecieron fechas seleccionadas para la edición", Page); 
                }           
        }

        private void inicioGrabado() {
            string[] array = Session["nFila"].ToString().Split(';');

            for (int i = 0; i < array.Length -1 ; i++) {
                int fila = Convert.ToInt32(array[i]);
                int idAgenda = Convert.ToInt32(dtGrilla.Rows[fila]["idAgenda"]);
                actualizarDataTable(idAgenda, fila);
                grabarAgenda(idAgenda, fila);
            }
        }

        private void actualizarDataTable(int idAgenda, int i) {
            /// reseteo la fila del dtGrilla

            DataRow dr = dtGrilla.Rows[i];
            dr.BeginEdit();
            dr["idAgenda"] = Convert.ToInt32(dtGrilla.Rows[i]["idAgenda"]);
            dr["Fecha"] = Convert.ToDateTime(gvAgendas.Rows[i].Cells[1].Text);
            dr["hIni"] = txtHini.Value;
            dr["hFin"] = txtHfin.Value;
            dr["Duracion"] = Convert.ToInt32(txtDurac.Value);
            dr["idConsultorio"] = Convert.ToInt32(ddlCons.SelectedValue);
            dr["Consultorio"] = ddlCons.SelectedItem.Text;
            dr["Bloques"] = Convert.ToInt32(txtBloque.Value);
            dr["MaxSbts"] = Convert.ToInt32(txtMaxSbts.Value);
            dr["Reservados"] = Convert.ToInt32(txtReservados.Value);
            dr["idAgendaEstado"] = Convert.ToInt32(ddlEstadoAgenda.SelectedValue);
            dr["Estado"] = ddlEstadoAgenda.SelectedItem.Text;
            dr.EndEdit();
            dr.AcceptChanges();
            gvAgendas.UpdateRow(i, true);
        }

        private void grabarAgenda(int idAgenda, int rowIndex) {
            ConAgenda ag = new ConAgenda(idAgenda);

            ag.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
            ag.IdServicio = Convert.ToInt32(ddlServicio.SelectedValue);
            ag.IdEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            ag.IdProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
            ag.Fecha = Convert.ToDateTime(dtGrilla.Rows[rowIndex]["Fecha"]);
            ag.HoraInicio = dtGrilla.Rows[rowIndex]["hIni"].ToString();
            ag.HoraFin = dtGrilla.Rows[rowIndex]["hFin"].ToString();
            ag.Duracion = Convert.ToInt32(dtGrilla.Rows[rowIndex]["Duracion"]);
            ag.IdConsultorio = Convert.ToInt32(dtGrilla.Rows[rowIndex]["idConsultorio"]);
          //  ag.CitarPorBloques = Convert.ToInt32(dtGrilla.Rows[rowIndex]["Bloques"]);
            ag.MaximoSobreturnos= Convert.ToInt32(dtGrilla.Rows[rowIndex]["MaxSbts"]);
          //  ag.Reservados = Convert.ToInt32(dtGrilla.Rows[rowIndex]["Reservados"]);
            ag.IdAgendaEstado = Convert.ToInt32(dtGrilla.Rows[rowIndex]["idAgendaEstado"]);
            if (ag.IdAgendaEstado == 1) { ag.TurnosDisponibles = true; } else { ag.TurnosDisponibles = false; }
            ag.Save();

            grabarAuditoria(ag);

            divinfo.Visible = true;
            Actualizar();
            Acordeon.SelectedIndex = 1;
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
            aud.IdUsuario = SSOHelper.CurrentIdentity.IdEfector;
            aud.IdAgendaEstado = ag.IdAgendaEstado;
            aud.IdServicio = ag.IdServicio;
            aud.IdProfesional = ag.IdProfesional;
            aud.IdEspecialidad = ag.IdEspecialidad;
            aud.IdConsultorio = ag.IdConsultorio;
            aud.Fecha = ag.Fecha;
            aud.HoraInicio = ag.HoraInicio;
            aud.HoraFin = ag.HoraFin;
            aud.Duracion = ag.Duracion;
         //   aud.Reservados = ag.Reservados;
            aud.MaxSobreturnos = ag.MaximoSobreturnos;
            aud.CitarPorBloques = 1;// ag.CitarPorBloques;
            aud.FechaModificacion = DateTime.Now;
            aud.HoraModificacion = Hora;
            aud.Save();
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {
            Acordeon.SelectedIndex = 1;
        }

        protected void gvAgendas_SelectedIndexChanged(object sender, EventArgs e) {

        }       
    }
}
