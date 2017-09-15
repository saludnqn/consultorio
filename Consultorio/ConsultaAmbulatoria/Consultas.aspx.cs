using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Salud.Security.SSO;

namespace Consultorio.ConsultaAmbulatoria
{
    public partial class Consultas : System.Web.UI.Page
    {
        HSSFWorkbook workbook;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    lblCantidad.Text = "-";
                    txtFInicio.Text = "01/01/2011";
                    txtFFin.Text = DateTime.Now.ToShortDateString();
                    CargarCombos();
                }            
        }

        private void CargarCombos()
        {
            SubSonic.Select ef = new SubSonic.Select();
            ef.From(SysEfector.Schema);
            ef.Where(SysEfector.Columns.NombreNacion).IsNotEqualTo(0);
            //ef.And(SysEfector.Columns.IdZona).IsEqualTo(9);
            ef.OrderAsc("nombre");
            ddlEfector.DataSource = ef.ExecuteTypedList<SysEfector>();
            ddlEfector.DataBind();
            ddlEfector.Items.Insert(0, new ListItem("TODOS", "0")); 

            SubSonic.Select tp = new SubSonic.Select();
            tp.From(SysTipoProfesional.Schema);
            tp.OrderAsc("nombre");
            ddlTipoProfesional.DataSource = tp.ExecuteTypedList<SysTipoProfesional>();
            ddlTipoProfesional.DataBind();
            ddlTipoProfesional.Items.Insert(0, new ListItem("TODOS", "0")); 
        }

        protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDatos();
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

        protected void gvConsultas_PageIndexChangind(object sender, GridViewPageEventArgs e)
        {
            btnBuscar_Click(null, null);
            gvConsultas.PageIndex = e.NewPageIndex;
            gvConsultas.DataBind();
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = gvConsultas.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvConsultas.DataSource = dataView;
                gvConsultas.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void BuscarDatos()
        {
            lblCantidad.Text = "";
            int efector;
            DateTime? finicio = null;
            DateTime? ffin = null;
            DateTime inicio;
            DateTime fin;
            int tprof;
            if (DateTime.TryParse(txtFInicio.Text, out inicio))
                finicio = inicio;
            if (DateTime.TryParse(txtFFin.Text, out fin))
                ffin = fin;
            efector = Convert.ToInt32(ddlEfector.SelectedValue);
            tprof = Convert.ToInt32(ddlTipoProfesional.SelectedValue);
            DataTable ds = SPs.ConGetConsultas(efector, finicio, ffin, tprof).GetDataSet().Tables[0];
            gvConsultas.DataSource = ds;
            gvConsultas.DataBind();
            if (ds.Rows.Count > 0)
            {
                lblCantidad.Text = ds.Rows.Count.ToString();
            }
            else
            {
                lblCantidad.Text = "sin registros";
            }
        }

        protected void IBExel_Click(object sender, ImageClickEventArgs e)
        {
            string filename = "ConsultasPacientes.xls";
            Response.ContentType = "application/vnd.ms-excel"; //vnd.text
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            Response.Clear();

            InitializeWorkbook();

            lblCantidad.Text = "";
            int efector;
            DateTime? finicio = null;
            DateTime? ffin = null;
            DateTime inicio;
            DateTime fin;
            int tprof;
            if (DateTime.TryParse(txtFInicio.Text, out inicio))
                finicio = inicio;
            if (DateTime.TryParse(txtFFin.Text, out fin))
                ffin = fin;
            efector = Convert.ToInt32(ddlEfector.SelectedValue);
            tprof = Convert.ToInt32(ddlTipoProfesional.SelectedValue);
            DataTable ds = SPs.ConGetConsultas(efector, finicio, ffin, tprof).GetDataSet().Tables[0];
            Sheet sheet = workbook.CreateSheet("ConsultasPacientes");
            CreateRows(sheet, ds.Rows.Count, 12);
            CreateHeader(sheet);
            CreateData(ds, sheet);

            Response.BinaryWrite(WriteToStream().GetBuffer());
            Response.End();
        }

        private void CreateData(DataTable consultas, Sheet sheet)
        {
            int i = 1;
            foreach (DataRow m in consultas.Rows)
            {
                // Getting the row... 0 is the first row.
                Row dataRow = sheet.GetRow(i);

                dataRow.GetCell(0).SetCellValue(m["Efector"].ToString());
                dataRow.GetCell(1).SetCellValue(m["Especialidad"].ToString());
                dataRow.GetCell(2).SetCellValue(m["Profesional"].ToString()); 
                dataRow.GetCell(3).SetCellValue(m["tipoProfesional"].ToString()); 
                dataRow.GetCell(4).SetCellValue(m["numeroDocumento"].ToString());
                dataRow.GetCell(5).SetCellValue(m["Paciente"].ToString());
                dataRow.GetCell(6).SetCellValue(m["FechaNacimiento"].ToString());
                dataRow.GetCell(7).SetCellValue(m["Edad"].ToString());
                dataRow.GetCell(8).SetCellValue(m["Codigo"].ToString());
                dataRow.GetCell(9).SetCellValue(m["Diagnostico"].ToString());
                dataRow.GetCell(10).SetCellValue(m["FechaConsulta"].ToString());
                dataRow.GetCell(11).SetCellValue(m["FechaRegistro"].ToString());
                i++;
            }
            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
            sheet.AutoSizeColumn(3);
            sheet.AutoSizeColumn(4);
            sheet.AutoSizeColumn(5);
            sheet.AutoSizeColumn(6);
            sheet.AutoSizeColumn(7);
            sheet.AutoSizeColumn(8);
            sheet.AutoSizeColumn(9);
            sheet.AutoSizeColumn(10);
            sheet.AutoSizeColumn(11);
        }

        MemoryStream WriteToStream()
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            workbook.Write(file);
            return file;
        }

        private void CreateRows(Sheet sheet, int rows, int cells)
        {
            for (int i = 0; i <= rows; i++)
            {
                sheet.CreateRow(i);
                Row row = sheet.GetRow(i);

                for (int j = 0; j <= cells; j++)
                {
                    row.CreateCell(j);
                }
            }
        }

        private void CreateHeader(Sheet sheet)
        {
            Row row = sheet.GetRow(0);

            String[] headers = new String[12]{
            "Efector",
            "Especialidad",
            "Profesional",
            "tipoProfesional",
            "numeroDocumento",
            "Paciente",
            "FechaNacimiento",
            "Edad",
            "Codigo",
            "Diagnostico",
            "FechaConsulta",
            "FechaRegistro"
            };

            for (int j = 0; j <= headers.Length - 1; j++)
            {
                row.GetCell(j).SetCellValue(headers[j]);
            }
            CellStyle cellstyle = workbook.CreateCellStyle();
            cellstyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_BLUE.index;
            row.RowStyle = cellstyle;
        }

        void InitializeWorkbook()
        {
            workbook = new HSSFWorkbook();
        }
    }
}
