using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using Consultorio.Utilidades;
using ExtensionMethods;

namespace Consultorio.ConsultaAmbulatoria
{
    public partial class BuscarMenor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    txtDni.Focus();
                    if (Request.QueryString["dni"] == null) txtDni.Text = "0";
                    else txtDni.Text = Request.QueryString["dni"];
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SubSonic.Select s = new SubSonic.Select();
            s.From(SysPaciente.Schema);
            //busqueda por documento, apellido, nombre, fechanacimiento, nombrepar, apellidopar
            bool encuentradni = false;
            int nrodoc = txtDni.Text.TryParseInt();
            if (nrodoc > 0)
            {
                //llenado de la grilla con los menores bajo control
                DataTable m = SPs.AprGetMenorControl(nrodoc).GetDataSet().Tables[0];
                if (m.Rows.Count > 0)
                {
                    lblTitulo.Visible = true;
                    lblTitulo.Text = "Pacientes Bajo Control";
                    gvMenor.Visible = true;
                    gvMenor.DataSource = m;
                    gvMenor.DataBind();
                    encuentradni = true;
                }
                else
                {
                    lblTitulo.Text = "";
                    lblTitulo.Visible = false;
                    gvMenor.Visible = false;
                }
            }
            if (!encuentradni)
            {
                string nombre = txtNombreBusqueda.Text;
                string apellido = txtApellidoBusqueda.Text;
                DateTime? fnac = null;
                DateTime fnac2;
                if (DateTime.TryParse(txtFecNacBusqueda.Text, out fnac2))
                    fnac = fnac2;
                string parnomb = txtNombreMadreBusqueda.Text;
                string parape = txtApellidoMadreBusqueda.Text;
                //llenado de la grilla
                DataTable dtpac = SPs.AprGetPacientesMenores(nrodoc, nombre, apellido, fnac, parnomb, parape).GetDataSet().Tables[0];
                if (dtpac.Rows.Count > 0)
                {
                    DateTime fec = Convert.ToDateTime(dtpac.Rows[0][8]);
                    int id = Convert.ToInt32(dtpac.Rows[0][0]);
                    DateDifference oEdad = new DateDifference(fec, DateTime.Now);
                    // SetearLinks(id, oEdad);
                }
                gvPacientes.DataSource = dtpac;
                gvPacientes.DataBind();
            }
        }


        /*  private void SetearLinks(int id, DateDifference edad)
           {
               hlConsultas.NavigateUrl = String.Format("~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}", id);
               if (edad.Years < 7)
               {
                   hlControlMenor.NavigateUrl = String.Format("~/ControlMenor/?idPaciente={0}", id);
               }
               else
               {
                   hlControlMenor.Visible = false;
               } 
           }*/

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim().Length > 0)
                Response.Redirect("~/Paciente/PacienteEdit.aspx?");
            else
                Response.Redirect("~/Paciente/PacienteEdit.aspx");
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                {
                    // SetearLinks(id, oEdad);
                    // hlConsultas.NavigateUrl = String.Format("~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}", id);
                    // hlControlMenor.NavigateUrl = String.Format("~/ControlMenor/?idPaciente={0}", id);
                }
            }
        }


      /*  protected void btnAlerta_Click(object sender, EventArgs e)
        {
                Response.Redirect("~/ConsultaAmbulatoria/Alertas/ControlMenor.aspx");
        } */
    }
}
