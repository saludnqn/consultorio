﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using NPlot;
using System.Drawing;
using DalSic;
using SIPS.Utilidades;

namespace SIPS.ControlMenor.UserControls
{
    public partial class PlotIMCEdad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Plot(SysPaciente oPaciente, ArrayList alIMC, ArrayList alVisitas)
        {
            DateDifference oEdad = new DateDifference(oPaciente.FechaNacimiento, DateTime.Now);
            DataTable oTabla;
            string xAxis = "";
            string Titulo = "";
            if (oEdad.Years >= 2)
            {
                //Muestro la grafica completa
                oTabla = SPs.AprGetPercentilesIMCEdadMas24meses(2).GetDataSet().Tables[0];
                xAxis = "Edad en años";
                Titulo = "IMC / Edad 2 a 18 años";
            }
            else
            {
                return;
            }

            ArrayList abcisa = new ArrayList();
            ArrayList al03 = new ArrayList();
            ArrayList al10 = new ArrayList();
            ArrayList al25 = new ArrayList();
            ArrayList al50 = new ArrayList();
            ArrayList al75 = new ArrayList();
            ArrayList al90 = new ArrayList();
            ArrayList al97 = new ArrayList();

            //Obtengo los valores de la tabla
            foreach (DataRow row in oTabla.Rows)
            {
                al03.Add(row["P3"]);
                al10.Add(row["P10"]);
                al25.Add(row["P25"]);
                al50.Add(row["P50"]);
                al75.Add(row["P75"]);
                al90.Add(row["P90"]);
                al97.Add(row["P97"]);

                //la abcisa es el primer valor (indice=0)
                abcisa.Add(row[0]);
            }
            //Grafico las lineas
            LinePlot lpPerc03 = new LinePlot();
            lpPerc03.Label = "03";
            lpPerc03.OrdinateData = al03;
            lpPerc03.AbscissaData = abcisa;
            lpPerc03.Color = Color.Red;
            lpPerc03.Pen.Width = 1.0f;

            LinePlot lpPerc10 = new LinePlot();
            lpPerc10.Label = "10";
            lpPerc10.OrdinateData = al10;
            lpPerc10.AbscissaData = abcisa;
            lpPerc10.Color = Color.Orange;
            lpPerc10.Pen.Width = 1.0f;

            LinePlot lpPerc25 = new LinePlot();
            lpPerc25.Label = "25";
            lpPerc25.OrdinateData = al25;
            lpPerc25.AbscissaData = abcisa;
            lpPerc25.Color = Color.YellowGreen;
            lpPerc25.Pen.Width = 1.0f;

            LinePlot lpPerc50 = new LinePlot();
            lpPerc50.Label = "50";
            lpPerc50.OrdinateData = al50;
            lpPerc50.AbscissaData = abcisa;
            lpPerc50.Color = Color.Green;
            lpPerc50.Pen.Width = 2.0f;

            LinePlot lpPerc75 = new LinePlot();
            lpPerc75.Label = "75";
            lpPerc75.OrdinateData = al75;
            lpPerc75.AbscissaData = abcisa;
            lpPerc75.Color = Color.LightBlue;
            lpPerc75.Pen.Width = 1.0f;

            LinePlot lpPerc90 = new LinePlot();
            lpPerc90.Label = "90";
            lpPerc90.OrdinateData = al90;
            lpPerc90.AbscissaData = abcisa;
            lpPerc90.Color = Color.Blue;
            lpPerc90.Pen.Width = 1.0f;

            LinePlot lpPerc97 = new LinePlot();
            lpPerc97.Label = "97";
            lpPerc97.OrdinateData = al97;
            lpPerc97.AbscissaData = abcisa;
            lpPerc97.Color = Color.Violet;
            lpPerc97.Pen.Width = 1.0f;

            plotSurface.Add(new Grid());

            plotSurface.Add(lpPerc97);
            plotSurface.Add(lpPerc90);
            plotSurface.Add(lpPerc75);
            plotSurface.Add(lpPerc50);
            plotSurface.Add(lpPerc25);
            plotSurface.Add(lpPerc10);
            plotSurface.Add(lpPerc03);

            if (alIMC.Count > 0)
            {
                //Agrego la linea de IMC
                LinePlot lpIMC = new LinePlot();
                lpIMC.Label = "Talla / Edad";
                lpIMC.OrdinateData = alIMC;
                lpIMC.AbscissaData = alVisitas;
                lpIMC.Color = Color.Black;
                lpIMC.Pen.Width = 2.0f;
                //lpPerc97.Pen.DashStyle = DashStyle.Dash;
                plotSurface.Add(lpIMC);
            }

            plotSurface.Title = Titulo;
            plotSurface.XAxis1.Label = xAxis;
            plotSurface.XAxis1.AutoScaleTicks = true;
            plotSurface.YAxis1.Label = "IMC (KG / M2)";
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