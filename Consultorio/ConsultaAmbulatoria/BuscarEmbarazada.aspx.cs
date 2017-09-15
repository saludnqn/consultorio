using System;
using System.Web.UI.WebControls;
using System.Data;
using Consultorio.Utilidades;
using DalSic;


namespace Consultorio.ConsultaAmbulatoria
{
    public partial class BuscarEmbarazada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDni.Focus();
                txtDni.Text = Request.QueryString["dni"];
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
            //btnBuscar_Click(null, null);
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

        //protected void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    //busqueda por documento
        //    if (txtDni.Text.Length > 0)
        //    {
        //        int nrodoc = 0;
        //        nrodoc = Convert.ToInt32(txtDni.Text);
        //        //llenado de la grilla con las que tengan una HCPerinatal abierta o actual
        //        DataTable pchc = SPs.AprGetPacientesConHCP(nrodoc).GetDataSet().Tables[0];
        //        if (pchc.Rows.Count > 0)
        //        {
        //            lblTitulo.Visible = true;
        //            lblTitulo.Text = "Pacientes con Historia Clínica Perinatal Abierta";
        //            gvEmbarazadas.Visible = true;
        //            gvEmbarazadas.DataSource = pchc;
        //            gvEmbarazadas.DataBind();
        //        }
        //        else {
        //            //llenado de la grilla con el resultado de la busqueda en SysPaciente con opcion a crear una nueva Historia Perinatal
        //            gvPacientes.DataSource = SPs.GetPacientesPorDocumento(nrodoc).GetDataSet();
        //            gvPacientes.DataBind();
        //        }
        //        //HCP Anterior
        //        SubSonic.Select hcpAnterior = new SubSonic.Select(new string[] { "idPaciente, idHistoriaClinicaPerinatal, apellido, nombre, createdOn, edad, idEfector, FPP, activa, observaciones" });
        //        hcpAnterior.From(AprHistoriaClinicaPerinatal.Schema);
        //        hcpAnterior.Where(AprHistoriaClinicaPerinatal.DniColumn).IsEqualTo(nrodoc);
        //        hcpAnterior.And(AprHistoriaClinicaPerinatal.ActivaColumn).IsEqualTo(0);
        //        hcpAnterior.OrderDesc("ModifiedOn");
        //        if (hcpAnterior.ExecuteTypedList<AprHistoriaClinicaPerinatal>().Count > 0)
        //        {
        //            pnHistoriaAnterior.Visible = true;
        //            gvHistoriaAnterior.DataSource = hcpAnterior.ExecuteTypedList<AprHistoriaClinicaPerinatal>();
        //            gvHistoriaAnterior.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        //busco ppaciente por nombres
        //        DateTime? fnac2 = null;
        //        DataTable dt = SPs.GetPacientesPorNombres(fnac2, txtNombreBusqueda.Text.Trim(), txtApellidoBusqueda.Text.Trim(), 0, null, null).GetDataSet().Tables[0];
        //        gvPacientes.DataSource = dt;
        //        gvPacientes.DataBind();

        //        if (dt.Rows.Count > 0)
        //        {
        //            DateTime fec = Convert.ToDateTime(dt.Rows[0][7]);
        //            int id = Convert.ToInt32(dt.Rows[0][0]);
        //            DateDifference oEdad = new DateDifference(fec, DateTime.Now);
        //            SetearLinks(id, oEdad);
        //        }
        //    }
        //}

        private void SetearLinks(int id, DateDifference edad)
        {
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim().Length > 0)
                Response.Redirect("~/Paciente/PacienteEdit.aspx?", false);
            else
                txtDni.Text = "";// Response.Redirect("", false);
        }
    }
}
