using System;
using DalSic;
using System.Data;

namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.Evaluacion {
    public partial class Default : System.Web.UI.Page {
        private int idPaciente {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) return;
            int idHistoriaClinicaPerinatalTemp;
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHistoriaClinicaPerinatalTemp))
            {
                idHistoriaClinicaPerinatal = idHistoriaClinicaPerinatalTemp;
            }
            if (idHistoriaClinicaPerinatal > 0) GetEvaluacion(idHistoriaClinicaPerinatal);
            else return;
        }

        private void GetEvaluacion(int idHistoriaClinicaPerinatal)
        {
            //carga las datos para la tabla
            DataTable sc = SPs.AprGetEvaluacionIndividual(idHistoriaClinicaPerinatal).GetDataSet().Tables[0];
            gvControles.DataSource = sc;
            if (sc.Rows.Count > 0)
            {
                gvControles.DataBind();
                lblCantidad.Text = sc.Rows.Count.ToString();
                string dom = sc.Rows[0][2].ToString();
                int edad = Convert.ToInt32(sc.Rows[0][3]);
                string getareo = sc.Rows[0][4].ToString();
                string primig = sc.Rows[0][5].ToString();
                string captac = sc.Rows[0][6].ToString();
                string patol = sc.Rows[0][7].ToString() + sc.Rows[0][8].ToString() + sc.Rows[0][9].ToString() + sc.Rows[0][10].ToString() +
                    sc.Rows[0][11].ToString() + sc.Rows[0][12].ToString() + sc.Rows[0][13].ToString() + sc.Rows[0][14].ToString() +
                    sc.Rows[0][15].ToString() + sc.Rows[0][16].ToString() + sc.Rows[0][17].ToString() + sc.Rows[0][18].ToString();
                string fr1 = sc.Rows[0][19].ToString();
                string fr2 = sc.Rows[0][20].ToString();
                string fr3 = sc.Rows[0][21].ToString();
                string fr4 = sc.Rows[0][22].ToString();
                string fr5 = sc.Rows[0][23].ToString();
                string fpp = sc.Rows[0][32].ToString();
                // asignacion de valores fijos a las etiquetas
                lblDom.Text = dom;
                lblEdad.Text = edad.ToString();
                lblGrupoE.Text = getareo;
                lblPrimigesta.Text = primig;
                lblCaptacion.Text = captac.ToString();
                lblPatologias.Text = patol.ToString();
                lblFactorR.Text = fr1.ToString() + "-" + fr2.ToString() + "-" + fr3.ToString() + "-" + fr4.ToString() + "-" + fr5.ToString();
                //si se recomienda y realiza actividades
                //desde aca son variables los valores segun el registro del control
                for (int i = 0; i < sc.Rows.Count; i++)
                {
                    string fCtrol = sc.Rows[i][25].ToString();
                    decimal egestacional = Convert.ToInt32(sc.Rows[i][26]);
                    int nroCotrl = Convert.ToInt32(sc.Rows[i][27]);
                    decimal IMC = Convert.ToInt32(sc.Rows[i][28]);
                    string estNut = sc.Rows[i][29].ToString();
                    string pcita = sc.Rows[i][30].ToString();
                    string asiste = sc.Rows[i][31].ToString();
                    //string puerp = sc.Rows[i][33].ToString(); //7
                    //ver como traer el scrore!! Que lo vean en la otra pestaña idem Actividades
                }
            }
            else return;
        }
    }
}
