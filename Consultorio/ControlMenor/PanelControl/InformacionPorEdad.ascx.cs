using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace SIPS.ControlMenor.PanelControl
{
    public enum EdadCorte
    {
        corte6meses,
        corte12meses,
        corte2años,
        corte3años,
        corte4años,
        corte5años,
        corte6años
    };

    public partial class InformacionPorEdad : System.Web.UI.UserControl
    {
        public EdadCorte edadCorte;

        public int idEfector;

        public int diasDesde;
        public int diasHasta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string titulo = "";
            switch (edadCorte)
            {
                case EdadCorte.corte6meses:
                    diasDesde = 0;
                    diasHasta = 182;
                    titulo = "Edad de Corte: 6 meses.";
                    //Indicadores exclusivos
                    EdadPromedioPrimerConsulta();
                    PorcentajePrimerVisitaAntes15Dias();
                    break;
                case EdadCorte.corte12meses:
                    diasDesde = 182;
                    diasHasta = 365;
                    titulo = "Edad de Corte: 12 meses.";
                    break;
                case EdadCorte.corte2años:
                    diasDesde = 365;
                    diasHasta = 703;
                    titulo = "Edad de Corte: 2 años.";
                    break;
                case EdadCorte.corte3años:
                    diasDesde = 703;
                    diasHasta = 1095;
                    titulo = "Edad de Corte: 3 años.";
                    break;
                case EdadCorte.corte4años:
                    diasDesde = 1095;
                    diasHasta = 1460;
                    titulo = "Edad de Corte: 4 años.";
                    break;
                case EdadCorte.corte5años:
                    diasDesde = 1460;
                    diasHasta = 1825;
                    titulo = "Edad de Corte: 5 años.";
                    break;
                case EdadCorte.corte6años:
                    diasDesde = 1825;
                    diasHasta = 2190;
                    titulo = "Edad de Corte: 6 años.";
                    break;
                default:
                    diasDesde = -2;
                    diasHasta = -1;
                    titulo = "ERROR: No se especifico la edad de corte";
                    break;
            }

            lblTitulo.Text = titulo;

            //Indicadores Compartidos
            NiñosBajoPrograma();
            NumeroVisitas();
        }

        private void NiñosBajoPrograma()
        {
            int? efector = null;
            if (idEfector > 0) efector = idEfector;
            int temp = Convert.ToInt32(
                SPs.AprPcNiñosBajoPrograma(diasDesde, diasHasta, efector).ExecuteScalar());
            lblNiñosBajoPrograma.Text = string.Format("Niños bajo programa: {0} niños/as.", temp);
        }

        private void NumeroVisitas()
        {
            int? efector = null;
            if (idEfector > 0) efector = idEfector;
            int temp = Convert.ToInt32(
                SPs.AprPcPromedioVisitasPorNiño(diasDesde, diasHasta, efector).ExecuteScalar());
            lblNumeroVisitas.Text = string.Format("Numero de visitas por niño: {0:0.00} visitas.", temp);
        }

        private void EdadPromedioPrimerConsulta()
        {
            int? efector = null;
            if (idEfector > 0) efector = idEfector;
            decimal temp = Convert.ToDecimal(
                SPs.AprPcEdadPromedioPrimeraVisita(diasDesde, diasHasta, efector).ExecuteScalar());
            lblEdadPromedioPrimerConsulta.Text = string.Format("Edad Promedio Primer Visita: {0:0.00} dias.", temp);
            fsEdadPromedio.Visible = true;
        }

        private void PorcentajePrimerVisitaAntes15Dias()
        {
            int? efector = null;
            if (idEfector > 0) efector = idEfector;
            decimal temp = Convert.ToDecimal(
                SPs.AprPcPorcentajePrimerVisitaAntes15Dias(diasDesde, diasHasta, efector).ExecuteScalar());
            lblPorcentajePrimerVisita.Text = string.Format("Porcentaje Niños Primer Visita antes de 15 dias: {0:0.00} %.", temp);
            fsPorcentajePrimerVisita.Visible = true;
        }
    }
}