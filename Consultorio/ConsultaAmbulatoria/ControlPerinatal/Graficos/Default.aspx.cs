using System;
using NPlot;
using System.Collections;
using System.Data;
using DalSic;
using System.Drawing;

namespace ConsultaAmbulatoria.ControlPerinatal.Graficos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            int idHCP;
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHCP))
            {
                //AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal(idHCP);
                    


           
            //int idPaciente = oHCP.IdPaciente;
            
            
                Plot(idHCP, "INDICE DE MASA CORPORAL POR EDAD GESTACIONAL", "Edad Gestacional(semanas)", "IMC");
            
            }
        }

        public void Plot(int idHCP, string titulo, string xAxis, string yAxis)
        {
            DataTable oTabla = new SubSonic.Select().From(AprCentilesIMCEdadGestacional.Schema)
                .OrderAsc(AprCentilesIMCEdadGestacional.Columns.SemanasGestacion)
                .ExecuteDataSet().Tables[0];

            //AprHistoriaClinicaPerinatalDetalleCollection oDetalles = new SubSonic.Select()
            //.From(AprHistoriaClinicaPerinatalDetalle.Schema)
            //.InnerJoin(AprHistoriaClinicaPerinatal.Schema)
            //.Where(AprHistoriaClinicaPerinatal.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(idHCP)
            //.OrderAsc(AprHistoriaClinicaPerinatalDetalle.Columns.EdadGestacional)
            //.And(AprHistoriaClinicaPerinatalDetalle.Columns.Activa).IsEqualTo(true)
            //.ExecuteAsCollection<AprHistoriaClinicaPerinatalDetalleCollection>();

            //Genero los datos de la paciente
            ArrayList abcisaPaciente = new ArrayList();
            ArrayList IMCPaciente = new ArrayList();


            //foreach (AprHistoriaClinicaPerinatalDetalle oDetalle in oDetalles)
            DataTable dt = SPs.AprGetHCPDetalle(idHCP).GetDataSet().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i ++ )
            {
                
                DataRow row=dt.Rows[i]; 
                
                int eg = row.IsNull("EdadGestacional") ? 0 : (Convert.ToInt32(dt.Rows[i]["EdadGestacional"])); 
                int imc = row.IsNull("Imc") ? 0 : (Convert.ToInt32(dt.Rows[i]["Imc"])); 
                if (eg > 0 && imc > 0) { 
               

                        abcisaPaciente.Add(dt.Rows[i]["EdadGestacional"]);
                        IMCPaciente.Add(dt.Rows[i]["Imc"]);
                }
            }

            //Agrego la linea de IMC
            LinePlot lpIMC = new LinePlot();
            lpIMC.Label = "IMC / Edad Gestacional";
            lpIMC.OrdinateData = IMCPaciente;
            lpIMC.AbscissaData = abcisaPaciente;
            lpIMC.Color = Color.Black;
            lpIMC.Pen.Width = 2.0f;
            //lpPerc97.Pen.DashStyle = DashStyle.Dash;
            //Lineas de Guia
            ArrayList abcisa = new ArrayList();
            ArrayList c03 = new ArrayList();
            ArrayList c10 = new ArrayList();
            ArrayList c50 = new ArrayList();
            ArrayList c90 = new ArrayList();
            ArrayList c97 = new ArrayList();

            //Obtengo los valores de la tabla
            foreach (DataRow row in oTabla.Rows)
            {
                c03.Add(row["C3"]);
                c10.Add(row["C10"]);
                c50.Add(row["C50"]);
                c90.Add(row["C90"]);
                c97.Add(row["C97"]);

                //la abcisa es el segundo valor
                abcisa.Add(row["SemanasGestacion"]);
            }
            //Grafico las lineas
            LinePlot lpCent03 = new LinePlot();
            lpCent03.Label = "03";
            lpCent03.OrdinateData = c03;
            lpCent03.AbscissaData = abcisa;
            lpCent03.Color = Color.Red;
            lpCent03.Pen.Width = 1.0f;
            //lpPerc03.Pen.DashStyle = DashStyle.Dash;

            LinePlot lpCent10 = new LinePlot();
            lpCent10.Label = "10";
            lpCent10.OrdinateData = c10;
            lpCent10.AbscissaData = abcisa;
            lpCent10.Color = Color.Orange;
            lpCent10.Pen.Width = 1.0f;
            //lpPerc10.Pen.DashStyle = DashStyle.Dash;

            LinePlot lpCent50 = new LinePlot();
            lpCent50.Label = "50";
            lpCent50.OrdinateData = c50;
            lpCent50.AbscissaData = abcisa;
            lpCent50.Color = Color.Green;
            lpCent50.Pen.Width = 2.0f;
            //lpPerc03.Pen.DashStyle = DashStyle.Dash;

            LinePlot lpCent90 = new LinePlot();
            lpCent90.Label = "90";
            lpCent90.OrdinateData = c90;
            lpCent90.AbscissaData = abcisa;
            lpCent90.Color = Color.LightGreen;
            lpCent90.Pen.Width = 1.0f;
            //lpPerc50.Pen.DashStyle = DashStyle.Dash;

            LinePlot lpCent97 = new LinePlot();
            lpCent97.Label = "97";
            lpCent97.OrdinateData = c97;
            lpCent97.AbscissaData = abcisa;
            lpCent97.Color = Color.LightBlue;
            lpCent97.Pen.Width = 1.0f;
            //lpPerc75.Pen.DashStyle = DashStyle.Dash;            

            //Zona Normal
            FilledRegion fr = new FilledRegion(lpCent10, lpCent90);
            fr.RectangleBrush = new RectangleBrushes.Vertical(
                Color.FromArgb(128, Color.Green),
                Color.FromArgb(128, Color.LightGreen));
            //fr.RectangleBrush = new RectangleBrushes.Vertical(Color.White, Color.LightSkyBlue);
            plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            plotSurface.Add(fr);

            Grid oGrid = new Grid();
            oGrid.HorizontalGridType = Grid.GridType.Fine;
            oGrid.VerticalGridType = Grid.GridType.Fine;
            oGrid.MinorGridPen.Color = Color.FromArgb(192, 235, 251);
            oGrid.MajorGridPen.Color = Color.FromArgb(192, 235, 251);

            plotSurface.Add(oGrid);

            plotSurface.Add(lpCent97);
            plotSurface.Add(lpCent90);
            plotSurface.Add(lpCent50);
            plotSurface.Add(lpCent10);
            plotSurface.Add(lpCent03);

            plotSurface.Add(lpIMC);

            plotSurface.Title = titulo;
            plotSurface.XAxis1.Label = xAxis;
            plotSurface.XAxis1.AutoScaleTicks = true;
            plotSurface.YAxis1.Label = yAxis;
            plotSurface.YAxis1.AutoScaleTicks = true;

            plotSurface.XAxis1 = new LinearAxis(plotSurface.XAxis1);

            // make sure plot surface colors are as we expect - the wave example changes them.
            plotSurface.Legend = new Legend();
            plotSurface.PlotBackColor = Color.White;
            //plotSurface.BackColor = System.Drawing.SystemColors.Control;
            plotSurface.XAxis1.Color = Color.Black;
            plotSurface.YAxis1.Color = Color.Black;
       
        
        }


    }
}
