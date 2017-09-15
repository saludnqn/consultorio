using System;
using NPlot;
using System.Collections;
using System.Data;
using DalSic;
using System.Drawing;

namespace ConsultaAmbulatoria.ControlPerinatal.AlturaUterina
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            int idHistoriaClinicaPerinatal;
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHistoriaClinicaPerinatal))
            {
                //plotSurface.XAxis1 = new Axis(13,40);
                //plotSurface.YAxis1 = new Axis(8,40);
                Plot(idHistoriaClinicaPerinatal, "CALCULO DE LA ALTURA UTERINA, SEGUN EDAD GESTACIONAL", "Edad Gestacional(semanas)", "Altura Uterina");
            } 
        }

        public void Plot(int idHistoriaClinicaPerinatal, string titulo, string xAxis, string yAxis)
        {
           //debo validar que la altura uterina sea mayor o = 13
            DataTable oTabla = new SubSonic.Select().From(AprAlturaUterina.Schema)
                //agrego el fitro
                .Where(AprAlturaUterina.Columns.SemanasGestacion).IsGreaterThanOrEqualTo(13)
                .OrderAsc(AprAlturaUterina.Columns.SemanasGestacion)
                .ExecuteDataSet().Tables[0];

            AprHistoriaClinicaPerinatalDetalleCollection oDetalles = new SubSonic.Select()
            .From(AprHistoriaClinicaPerinatalDetalle.Schema)
            .InnerJoin(AprHistoriaClinicaPerinatal.Schema)
            .Where(AprHistoriaClinicaPerinatal.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(idHistoriaClinicaPerinatal)
            .And(AprHistoriaClinicaPerinatalDetalle.Columns.EdadGestacional).IsGreaterThanOrEqualTo(13)
            .OrderAsc(AprHistoriaClinicaPerinatalDetalle.Columns.EdadGestacional)
            .ExecuteAsCollection<AprHistoriaClinicaPerinatalDetalleCollection>();

            //Genero los datos de la paciente
            ArrayList abcisaPaciente = new ArrayList();
            ArrayList IMCPaciente = new ArrayList();
            foreach (AprHistoriaClinicaPerinatalDetalle oDetalle in oDetalles)
            {
                if ((oDetalle.AlturaUterina.Value >= 8) && (oDetalle.EdadGestacional.Value >= 13))
                {
                    lblMensaje.Text = "";
                    if (oDetalle.EdadGestacional.HasValue && oDetalle.AlturaUterina.HasValue)
                    {
                        decimal eGestacional = Math.Round(oDetalle.EdadGestacional.Value);
                        //decimal eGestacional = Math.Truncate(oDetalle.EdadGestacional.Value);
                        abcisaPaciente.Add(eGestacional);
                        IMCPaciente.Add(oDetalle.AlturaUterina.Value);
                    }
                }
                else {
                    lblMensaje.Text = "El gráfico se inicia a partir de las 13 semanas de gestación.";
                }
            }

            //Agrego la linea de IMC Altura Uterina
            LinePlot lpIMC = new LinePlot();
            lpIMC.Label = "Altura Uterina / Edad Gestacional";
            lpIMC.OrdinateData = IMCPaciente;
            lpIMC.AbscissaData = abcisaPaciente;
            lpIMC.Color = Color.Black;
            lpIMC.Pen.Width = 2.0f;
            //Lineas de Guia
            ArrayList abcisa = new ArrayList();
            ArrayList c10 = new ArrayList();
            ArrayList c50 = new ArrayList();
            ArrayList c90 = new ArrayList();

            //Obtengo los valores de la tabla
            foreach (DataRow row in oTabla.Rows)
            {
                c10.Add(row["C10"]);
                c50.Add(row["C50"]);
                c90.Add(row["C90"]);
                //la abcisa es el segundo valor
                abcisa.Add(row["SemanasGestacion"]);
            }
            //Grafico las lineas
            LinePlot lpCent10 = new LinePlot();
            lpCent10.Label = "Mínimo: 10";
            lpCent10.OrdinateData = c10;
            lpCent10.AbscissaData = abcisa;
            lpCent10.Color = Color.Orange;
            lpCent10.Pen.Width = 1.0f;

            LinePlot lpCent50 = new LinePlot();
            lpCent50.Label = "Promedio: 50";
            lpCent50.OrdinateData = c50;
            lpCent50.AbscissaData = abcisa;
            lpCent50.Color = Color.Green;
            lpCent50.Pen.Width = 2.0f;

            LinePlot lpCent90 = new LinePlot();
            lpCent90.Label = "Máximo: 90";
            lpCent90.OrdinateData = c90;
            lpCent90.AbscissaData = abcisa;
            lpCent90.Color = Color.LightGreen;
            lpCent90.Pen.Width = 1.0f;
            //Zona Normal
            FilledRegion fr = new FilledRegion(lpCent10, lpCent90);
            fr.RectangleBrush = new RectangleBrushes.Vertical(
                Color.FromArgb(128, Color.Green),
                Color.FromArgb(128, Color.LightGreen));
            plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            plotSurface.Add(fr);

            Grid oGrid = new Grid();
            oGrid.HorizontalGridType = Grid.GridType.Fine;
            oGrid.VerticalGridType = Grid.GridType.Fine;
            oGrid.MinorGridPen.Color = Color.FromArgb(192, 235, 251);
            oGrid.MajorGridPen.Color = Color.FromArgb(192, 235, 251);

            plotSurface.Add(oGrid);

            plotSurface.Add(lpCent90);
            plotSurface.Add(lpCent50);
            plotSurface.Add(lpCent10);

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
