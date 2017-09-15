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
using DalSic;
using Salud.Security.SSO;

namespace Consultorio.Turnos
{
    public partial class PacienteList : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {                
                txtDni.Focus();                                
            }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;
                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }
            return newSortDirection;
        }

        protected void gvPacientes_PageIndexChangind(object sender, GridViewPageEventArgs e)
        {
            btnBuscar_Click(null, null);
            gvPacientes.PageIndex = e.NewPageIndex;
            gvPacientes.DataBind();
        }

        protected void gvPersonas_PageIndexChangind(object sender, GridViewPageEventArgs e)
        {
            btnBuscar_Click(null, null);
        }

        protected void gvPadronPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            btnBuscar_Click(null, null);
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = gvPacientes.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvPacientes.DataSource = dataView;
                gvPacientes.DataBind();
            }
        }

        /// <summary>
        /// Sil el tipo de efector es un hospital se oculta la columna "Turno de 2do Nivel", ya que solo es posible sacar un turno de 2do nivel
        /// cuando es un Centro de Salud, Puesto Sanitario, etc.
        /// </summary>
        private void ocultarTurnoSegundoNivel()
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            if (efector.IdTipoEfector == 2)
            {
                gvPacientes.Columns[10].Visible = false;
            }
            else
            {
                gvPacientes.Columns[10].Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ocultarTurnoSegundoNivel();

            SubSonic.Select s = new SubSonic.Select();
            s.From(SysPaciente.Schema);

            int nrodoc = 0;
            int dniMadre = int.Parse(txtDniMadre.Text == "" ? "0" : txtDniMadre.Text);

            if ((txtDni.Text.Trim() == "") && (txtApellidoBusqueda.Text.Trim() == "") && (txtNombreBusqueda.Text.Trim() == "") && (txtNombreMadreBusqueda.Text.Trim() == "") && (txtApellidoMadreBusqueda.Text.Trim() == "") && (dniMadre.ToString().Trim() == ""))
                lblMensajeBusqueda.Text = "Debe ingresar al menos un filtro de búsqueda";
            else
            {
                /*if (dniMadre.ToString() == "") {
                    dniMadre = ;
                }*/

                //busqueda por documento
                if (txtDni.Text.Length > 0)
                {
                    nrodoc = Convert.ToInt32(txtDni.Text);

                    //llenado de la grilla
                    gvPacientes.DataSource = SPs.GetPacientesPorDocumento(nrodoc).GetDataSet();
                    gvPacientes.DataBind();

                    return;
                }

                //busqueda por fecha de nacimiento
                DateTime fnac;
                DateTime? fnac2 = null;

                gvPacientes.DataSource = SPs.GetPacientesPorNombres(fnac2, txtNombreBusqueda.Text.Trim(), txtApellidoBusqueda.Text.Trim(), dniMadre, txtNombreMadreBusqueda.Text.Trim(), txtApellidoMadreBusqueda.Text.Trim()).GetDataSet();
                gvPacientes.DataBind();
            }

        }

        

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton CmdTurno = (LinkButton)e.Row.Cells[9].Controls[1];
                CmdTurno.CommandArgument = this.gvPacientes.DataKeys[e.Row.RowIndex].Value.ToString();
                CmdTurno.CommandName = "Historial";
                CmdTurno.ToolTip = "Historial del Paciente";

             
                switch (DataBinder.Eval(e.Row.DataItem, "estado").ToString())
                {
                    case "Identificado":
                        e.Row.BackColor = System.Drawing.Color.LightBlue;
                        e.Row.ToolTip = "Pacientes Identificados";
                        break;
                    case "Temporal":
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;
                        e.Row.ToolTip = "Pacientes Temporales";
                        break;
                    case "Validado":
                        e.Row.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        e.Row.ToolTip = "Pacientes Validados";
                        break;
                    case "Inactivo":
                        e.Row.BackColor = System.Drawing.Color.Azure;
                        e.Row.ToolTip = "Pacientes Inactivos";
                        break;
                    default: e.Row.BackColor = System.Drawing.Color.White;
                        break;
                }
            }
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Historial":
                    Response.Redirect("ConsultorioPaciente.aspx?idPaciente=" + e.CommandArgument.ToString());
                    break;
            }
        }

        private bool PacienteEsClasificado(string p)
        {

            RemClasificacionCollection srv = new SubSonic.Select()
            .From(Schemas.RemClasificacion)
                      .Where(RemClasificacion.Columns.IdPaciente).IsEqualTo(p)
                      .And(RemClasificacion.Columns.RiesgoCardiovascular).IsGreaterThan(1)////Riesgo cardiovascular mayor a 10 

             .ExecuteAsCollection<RemClasificacionCollection>();

            if (srv.Count > 0)
                return true;
            else
                return false;
        }
    }
}