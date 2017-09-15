using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalSic;
using SIPS.Utilidades;
using System.Collections;

namespace SIPS.ControlMenor.UserControls
{
    public partial class CurvasCrecimiento : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void graficarCurvas(int idPaciente)
        {
            SysPaciente oPaciente = new SysPaciente(idPaciente);

            if (oPaciente.IsNew) return;

            DateDifference oEdad = new DateDifference(oPaciente.FechaNacimiento, DateTime.Now);

            DataTable oPlotData = SPs.AprGetPlotData(oPaciente.IdPaciente).GetDataSet().Tables[0];

            ArrayList oVisitas = new ArrayList();
            ArrayList oPesoData = new ArrayList();
            ArrayList oTallaData = new ArrayList();
            ArrayList oPerimetroCefalicoData = new ArrayList();
            ArrayList oIMCData = new ArrayList();
            ArrayList oVisitasIMC = new ArrayList();
            decimal divisor = 0;
            if (oEdad.Years < 2)
            {
                divisor = 28;
            }
            else
            {
                divisor = 365;
            }

            foreach (DataRow oRow in oPlotData.Rows)
            {
                DateDifference oDif = new DateDifference(oPaciente.FechaNacimiento, Convert.ToDateTime(oRow["fecha"]));
                decimal edad = (oDif.Weeks * 7) / divisor;
                decimal peso = Convert.ToDecimal(oRow["Peso"]);
                decimal talla = Convert.ToDecimal(oRow["Talla"]);
               // decimal tallam = talla / 100;
                decimal percefalico = Convert.ToDecimal(oRow["PerimetroCefalico"]);
                decimal imc = peso / (talla * talla);
                oVisitas.Add(edad);
                oPesoData.Add(peso);
                oTallaData.Add(talla*100);
                oPerimetroCefalicoData.Add(percefalico);
                if (oDif.Years >= 2)
                {
                    oVisitasIMC.Add(edad);
                    oIMCData.Add(imc);
                }
            }

            plotPesoEdad.Plot(oPaciente, oPesoData, oVisitas);
            plotLongEstEdad.Plot(oPaciente, oTallaData, oVisitas);
            plotPerCefEdad.Plot(oPaciente, oPerimetroCefalicoData, oVisitas);
            if (oEdad.Years >= 2)
            {
                plotIMCEdad.Plot(oPaciente, oIMCData, oVisitasIMC);
            }
            else
            {
                divIMcEdad.Visible = false;
                liIMcEdad.Visible = false;
            }
        }
    }
}