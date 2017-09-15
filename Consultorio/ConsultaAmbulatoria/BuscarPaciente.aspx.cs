using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Consultorio.Utilidades;
using DalSic;
using Salud.Security.SSO;

namespace Consultorio.ConsultaAmbulatoria
{
    public partial class BuscarPaciente : System.Web.UI.Page
    {
        public bool MostrarAlerta
        {
            get { return Session["alertaModal"] == null; }
            set { Session["alertaModal"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (!IsPostBack)
                {
                    txtDni.Focus();


                    //aca llamo al store de muestra los alertas si los hubiese
                    DataTable d = SPs.AprGetAlertaCP(SSOHelper.CurrentIdentity.IdEfector).GetDataSet().Tables[0];
                    if (d.Rows.Count > 0)
                    {
                        GridView1.DataSource = d;
                        GridView1.DataBind();
                        upAlertas.Visible = true;

                    }
                    else  {
                        upAlertas.Visible = false;
                    //DatosUsuarios.Visible = false;
                    //MensajePacienteNoE.Visible = false;
                    }

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

            //busqueda por documento
            if (txtDni.Text.Length > 0)
            {
                int nrodoc = 0;
                nrodoc = Convert.ToInt32(txtDni.Text);

                //llenado de la grilla
                gvPacientes.DataSource = SPs.GetPacientesPorDocumento(nrodoc).GetDataSet();
                gvPacientes.DataBind();
                return;
            }

            //busqueda por nombres
            DateTime? fnac2 = null;
            DataTable dt = SPs.GetPacientesPorNombres(fnac2, txtNombreBusqueda.Text.Trim(), txtApellidoBusqueda.Text.Trim(), 0,null, null).GetDataSet().Tables[0];
            gvPacientes.DataSource = dt;
            gvPacientes.DataBind();

            if (dt.Rows.Count > 0)
            {
                DateTime fec = Convert.ToDateTime(dt.Rows[0][7]);
                int id = Convert.ToInt32(dt.Rows[0][0]);
                DateDifference oEdad = new DateDifference(fec, DateTime.Now);
                SetearLinks(id, oEdad);
            }
        }

        private void SetearLinks(int id, DateDifference edad)
        {
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim().Length > 0)
                Response.Redirect("~/Paciente/PacienteEdit.aspx?");
            else
                Response.Redirect("~/Paciente/PacienteEdit.aspx");
        }
    }
}
