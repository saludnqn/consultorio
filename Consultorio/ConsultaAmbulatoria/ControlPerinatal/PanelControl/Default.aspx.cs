using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Drawing;
using SubSonic;


namespace ConsultaAmbulatoria.ControlPerinatal.PanelControl
{
    public partial class Default : System.Web.UI.Page
    {
        HSSFWorkbook workbook;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCantidad.Text = "-";
                txtFInicio.Text = "01/01/2011";
                txtFFin.Text = DateTime.Now.ToShortDateString();
                CargarCombo();
                //gvNutricional.DataBind();
            }
        }

        private void CargarCombo()
        {
            SubSonic.Select ef = new SubSonic.Select();
            ef.From(SysEfector.Schema);
            ef.Where(SysEfector.Columns.NombreNacion).IsNotEqualTo(0);
            ef.OrderAsc("nombre");
            ddlEfector.DataSource = ef.ExecuteTypedList<SysEfector>();
            ddlEfector.DataBind();
            ddlEfector.Items.Insert(0, new ListItem("TODOS", "0"));
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
            if (DateTime.TryParse(txtFInicio.Text, out inicio))
                finicio = inicio;
            if (DateTime.TryParse(txtFFin.Text, out fin))
                ffin = fin;
            efector = Convert.ToInt32(ddlEfector.SelectedValue);
            DataTable ds = SPs.AprPacientesConHCP(efector, 0, finicio, ffin).GetDataSet().Tables[0];
            gvPacientes.DataSource = ds;
            gvPacientes.DataBind();
            if (ds.Rows.Count > 0)
            {
                lblCantidad.Text = ds.Rows.Count.ToString();
            }
            else
            {
                lblCantidad.Text = "sin registros";
            }
            //Con los mismos parametros completo los datos de la Evaluacion
            //table 0: primera Vez y ulterior
            //DataTable d1 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[0].Copy();
            //lblPrimeraVez.Text = d1.Rows[0][0].ToString();
            //lblUlterior.Text = d1.Rows[0][1].ToString();

            //table 1: edades
            DataTable d2 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[0].Copy();
            lblMenor20.Text = d2.Rows[0][0].ToString();
            lbl2040.Text = d2.Rows[0][1].ToString();
            lblMayor40.Text = d2.Rows[0][2].ToString();
           lblSinDatoEdad.Text = d2.Rows[0][3].ToString();

            //table 2: captacion oportuna
            DataTable d3 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[1].Copy();
            lblCaptacionSi.Text = d3.Rows[0][0].ToString();
            lblCaptacionNo.Text = d3.Rows[0][1].ToString();
            lblCaptacionSinDato.Text = d3.Rows[0][2].ToString();

            //table 3: patologiaEmbarazao
            DataTable d4 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[2].Copy();
            lblPatologiaSi.Text = d4.Rows[0][0].ToString();
            lblPatologiaNo.Text = d4.Rows[0][1].ToString();
            //lblPatologiaSinDato.Text = d4.Rows[0][2].ToString();

            //table 4: Factor de riesgo
            DataTable d5 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[3].Copy();
            lblFactorSi.Text = d5.Rows[0][0].ToString();
            lblFactorNo.Text = d5.Rows[0][1].ToString();
            //lblFactorSinDato.Text = d5.Rows[0][2].ToString();

            //table 5 y 6: actividades recreativas //trabajar mas aca
            //DataTable d6 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[4].Copy();
            //lblActividadesSi.Text = d6.Rows[0][0].ToString();
            //DataTable d7 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[6].Copy();
            //int actividades = Convert.ToInt32(d7.Rows[0][0]);
            //lblActividadesNo.Text = (actividades - Convert.ToInt32(d6.Rows[0][0])).ToString();

            //table 5: numeros de controles adecuados sem. gestacioneales. cantidad de controles segun semnas gestac
            DataTable d8 = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[4].Copy();
            if (d8.Rows.Count > 0)
            {
            lblAdecuados.Text = d8.Rows[0][0].ToString();
            lblInadecuados.Text = d8.Rows[0][1].ToString();
            }
   
            //table 8: puntajes en score de riesgo
            //DataTable sr = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[8].Copy();
            //if (sr.Rows.Count > 0)
            //{
            //    if (sr.Rows[0][0].ToString() != "" ) lblScore0.Text = sr.Rows[0][0].ToString();
            //    else lblScore0.Text = " 0 - Puntaje 0";
            //    lblScore13.Text = sr.Rows[0][1].ToString() + " Bajo Riesgo";
            //    lblScore44.Text = sr.Rows[0][2].ToString() + " Moderado Riesgo";
            //    lblScore6.Text = sr.Rows[0][3].ToString() + " Alto Riesgo";
            //    if (sr.Rows[0][4].ToString() != "") lblScoreSinDato.Text = sr.Rows[0][4].ToString();
            //    else lblScoreSinDato.Text = " 0 - Sin Dato";
            //}
             

            //table 9: estado nutricional
            //DataTable en = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[5].Copy();
            //gvNutricional.DataSource = en;
            //gvNutricional.DataBind();
            //if (en.Rows.Count > 0)
            //{
            //lblBajoPeso.Text = en.Rows[0][1].ToString();
            //lblPesoNormal.Text = en.Rows[1][1].ToString();
            //lblSobrePeso.Text = en.Rows[2][1].ToString();
            //lblObesidad.Text = en.Rows[3][1].ToString();
            //}
            //table 10: contidad de abandonos.. etc
            //DataTable ab = SPs.AprGetEvaluacionControlPerinatal(finicio, ffin, efector).GetDataSet().Tables[10].Copy();
            //lblAbandonoSi.Text = ab.Rows[0][0].ToString();

            //Cuento cuantas HCPerinatal tengo a la fecha
            //int cantidadTotal = new Select("idHistoriaClinicaPerinatal")
            //   .From(AprHistoriaClinicaPerinatal.Schema)
            //   .Where(AprHistoriaClinicaPerinatal.ActivaColumn).IsEqualTo(1)
            //   .GetRecordCount();
            //int abandonos = Convert.ToInt32(ab.Rows[0][0]);
            //if (cantidadTotal > 0) lblAbandonoNo.Text = (cantidadTotal - abandonos).ToString();
            //else lblAbandonoNo.Text = "--";
       }

        protected void IBExel_Click(object sender, ImageClickEventArgs e)
        {
            string filename = "PacientesConHistoriaClinicaPerinatal.xls";
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
            if (DateTime.TryParse(txtFInicio.Text, out inicio))
                finicio = inicio;
            if (DateTime.TryParse(txtFFin.Text, out fin))
                ffin = fin;
            efector = Convert.ToInt32(ddlEfector.SelectedValue);
            DataTable ds = SPs.AprPacientesConHCP(efector, 0, finicio, ffin).GetDataSet().Tables[0];

            Sheet sheet = workbook.CreateSheet("PacientesConHistoriaClinicaPerinatal");
            CreateRows(sheet, ds.Rows.Count, 14);
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

                dataRow.GetCell(0).SetCellValue(m["Nombre"].ToString());
                dataRow.GetCell(1).SetCellValue(m["Paciente"].ToString());
                dataRow.GetCell(2).SetCellValue(m["DNI"].ToString());
                dataRow.GetCell(3).SetCellValue(m["Telefono"].ToString());
                dataRow.GetCell(4).SetCellValue(m["Edad"].ToString());
                dataRow.GetCell(5).SetCellValue(m["EmbarazoPlaneado"].ToString());
                dataRow.GetCell(6).SetCellValue(m["Anticonceptivo"].ToString());
                dataRow.GetCell(7).SetCellValue(m["PesoAnterior"].ToString());
                dataRow.GetCell(8).SetCellValue(m["Talla"].ToString());
                dataRow.GetCell(9).SetCellValue(m["FUM"].ToString());
                dataRow.GetCell(10).SetCellValue(m["FPP"].ToString());
                dataRow.GetCell(11).SetCellValue(m["Primeriza"].ToString());
                dataRow.GetCell(12).SetCellValue(m["UsuarioCreacion"].ToString());
                dataRow.GetCell(13).SetCellValue(m["FechaCreacion"].ToString());
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
            sheet.AutoSizeColumn(12);
            sheet.AutoSizeColumn(13);
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

            String[] headers = new String[14]{
            "Nombre",
            "Paciente",
            "DNI",
            "Telefono",
            "Edad",
            "EmbarazoPlaneado",
            "Anticonceptivo",
            "PesoAnterior",
            "Talla",
            "FUM",
            "FPP",
            "Primeriza",
            "UsuarioCreacion",
            "FechaCreacion"
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
