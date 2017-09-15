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

namespace Consultorio.Turnos {
    public partial class TurnosAdminBusqueda : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {            
                txtFecha.Value = System.DateTime.Now.ToString().Substring(0, 10);
                if (!IsPostBack) {
                    txtDNI.Focus();
                }            
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                BuscarPaciente();
                resultados.Visible = true;
            }
        }

        protected void BuscarPaciente() {
            SubSonic.Select s = new SubSonic.Select();
            s.From(SysPaciente.Schema);

            if (txtDNI.Text.Length > 0) {
                int nrodoc = 0;
                nrodoc = Convert.ToInt32(txtDNI.Text);
                gvPacientes.DataSource = SPs.GetPacientesPorDocumento(nrodoc).GetDataSet().Tables[0];
                gvPacientes.DataBind();
                return;
            }
            if (txtHC.Text != "") {
                int hc = 0;
                hc = Convert.ToInt32(txtHC.Text);
                gvPacientes.DataSource = SPs.GetPacientesPorHistoriaClinica(hc).GetDataSet().Tables[0];
                gvPacientes.DataBind();
                return;
            }
            if ((txtApellido.Text != "") || (txtNombre.Text != "")) {
                string vAp = Convert.ToString(txtApellido.Text);
                string vNom = Convert.ToString(txtNombre.Text);
                gvPacientes.DataSource = SPs.ConGetPacientesByApyNom(vNom, vAp).GetDataSet().Tables[0];
                gvPacientes.DataBind();
                return;
            }
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e) {
            DataTable dataTable = gvPacientes.DataSource as DataTable;

            if (dataTable != null) {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvPacientes.DataSource = dataView;
                gvPacientes.DataBind();
            }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection) {
            string newSortDirection = String.Empty;

            switch (sortDirection) {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;
                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }
            return newSortDirection;
        }

        protected void gvPacientes_PageIndexChangind(object sender, GridViewPageEventArgs e) {
            BuscarPaciente();
            gvPacientes.PageIndex = e.NewPageIndex;
            gvPacientes.DataBind();
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                ImageButton CmdSel = (ImageButton)e.Row.Cells[6].FindControl("cmdSel");
                DataRowView dr = (DataRowView)e.Row.DataItem;
                CmdSel.CommandArgument = dr["idPaciente"].ToString();
                CmdSel.CommandName = "Seleccionar Paciente";
                CmdSel.ToolTip = "Buscar turnos para el paciente seleccionado";

                switch (DataBinder.Eval(e.Row.DataItem, "estado").ToString()) {
                    case "Identificado":
                        e.Row.BackColor = System.Drawing.Color.LightBlue;
                        e.Row.ToolTip = "Identificado";
                        break;
                    case "Temporal":
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;
                        e.Row.ToolTip = "Temporal";
                        break;
                    case "Validado":
                        e.Row.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        e.Row.ToolTip = "Validado";
                        break;
                    case "Inactivo":
                        e.Row.BackColor = System.Drawing.Color.Azure;
                        e.Row.ToolTip = "Inactivo";
                        break;
                    default: e.Row.BackColor = System.Drawing.Color.White;
                        break;
                }
            }
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e) {            
            int idPaciente = Convert.ToInt32(e.CommandArgument);

            if (tieneTurnosPac(idPaciente)) {
                Response.Redirect("TurnosAdmin.aspx?tipoBusqueda=1&id=" + idPaciente.ToString(), false);
            } 
            else {
                Rutinas.MessageBox("No se han encontrado turnos para el paciente seleccionado", Page);
            }            
        }

        private bool tieneTurnosPac(int idPaciente) {
            int cantidad = new Select().From(Schemas.ConTurno).Where(ConTurno.Columns.IdPaciente)
                                       .IsEqualTo(idPaciente).GetRecordCount();
            return (cantidad > 0);
        }

        protected void btnParametros_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                int idServicio = Convert.ToInt32(ddlServicio.SelectedValue);
                int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
                int idProfesional = (ddlProfesional.SelectedIndex > 0) ? Convert.ToInt32(ddlProfesional.SelectedValue) : 0;
                DateTime fI = Convert.ToDateTime(txtFecha.Value);

                buscarAgenda(idServicio, idEspecialidad, idProfesional, fI);
                resultadosAgenda.Visible = true;
            }
        }

        private void buscarAgenda(int idServicio, int idEspecialidad, int idProfesional, DateTime fechaInicial) {
            
        }

        protected void btnAgenda_Click(object sender, EventArgs e) {
            if (Page.IsValid) { buscarAgenda(Convert.ToInt32(txtAgenda.Text)); 
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args) {
            bool valido = false;

            if (!(txtDNI.Text == "")) { valido = true; }
            if (!(txtHC.Text == "")) { valido = true; }
            if (!(txtApellido.Text == "")) { valido = true; }
            if (!(txtNombre.Text == "")) { valido = true; }

            args.IsValid = valido;
        }

        private void buscarAgenda(int idBusca)
        {
            ConAgenda Agenda = new ConAgenda(idBusca);
            if (Agenda.IdAgendaEstado == 1)
            {
                if (Agenda.ConTurnoRecords.Count > 0)
                {
                    Response.Redirect("TurnosAdmin.aspx?tipoBusqueda=2&id=" + idBusca.ToString(), false);
                }
                else Rutinas.MessageBox("No se encontraron turnos para el número de agenda especificado", Page);
            }
            else Rutinas.MessageBox("El estado de la agenda no permite la edición de los turnos contenidos", Page);
        }

        protected void gvAgendas_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                ImageButton CmdSel = (ImageButton)e.Row.Cells[6].FindControl("cmdSel");
                DataRowView dr = (DataRowView)e.Row.DataItem;
                CmdSel.CommandArgument = dr["idAgendaDetalle"].ToString();
                CmdSel.CommandName = "Seleccionar";
                CmdSel.ToolTip = "Buscar turnos para la agenda seleccionada";

                switch (DataBinder.Eval(e.Row.DataItem, "Estado").ToString()) {
                    case "Activa":
                        CmdSel.Enabled = true;
                        e.Row.BackColor = System.Drawing.Color.LightBlue;
                        e.Row.ToolTip = "Agenda activa";
                        break;
                    case "Bloqueada":
                        CmdSel.Enabled = false;
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;
                        e.Row.ToolTip = "Agenda bloqueada";
                        break;
                }
            }
        }

        protected void gvAgendas_RowCommand(object sender, GridViewCommandEventArgs e) {
           buscarAgenda(Convert.ToInt32(e.CommandArgument));
        }        
    }
}
