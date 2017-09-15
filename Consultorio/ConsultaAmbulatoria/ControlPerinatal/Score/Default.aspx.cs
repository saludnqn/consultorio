using System;
using DalSic;
using System.Data;
using System.Drawing;

namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.Score
{
    public partial class Default : System.Web.UI.Page
    {
        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        private int idHistoriaPerinatal
        {
            get { return ViewState["idHistoriaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaPerinatal"]); }
            set { ViewState["idHistoriaPerinatal"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            int idHistoriaPerinatalTemp;
            if (Int32.TryParse(Request.QueryString["idHistoriaPerinatal"], out idHistoriaPerinatalTemp))
            {
                idHistoriaPerinatal = idHistoriaPerinatalTemp;
            }
            CargarFechas(idPaciente);
            GetScore(idPaciente);
        }

        private void CargarFechas(int idPaciente)
        {
            DataTable q = SPs.AprCPFechas(idPaciente).GetDataSet().Tables[0];
            ddlFecha.DataTextField = q.Columns[3].ColumnName;
            ddlFecha.DataValueField = q.Columns[3].ColumnName;
            ddlFecha.DataSource = q;
            ddlFecha.DataBind();
        }

        private void GetScore(int idHistoriaClinicaPerinatal)
        {
            if (ddlFecha.SelectedValue == "") return;
            DateTime fecha = Convert.ToDateTime(ddlFecha.SelectedValue);
            //carga las datos para la tabla
            DataTable sc = SPs.AprScoreBPN(idHistoriaClinicaPerinatal, fecha).GetDataSet().Tables[0];

            int scredad = Convert.ToInt32(sc.Rows[0][5]);
            int scrcivil = Convert.ToInt32(sc.Rows[0][6]);
            int scrbpn = Convert.ToInt32(sc.Rows[0][7]);
            int scrfumad = Convert.ToInt32(sc.Rows[0][8]);
            int scrImc = Convert.ToInt32(sc.Rows[0][9]);
            // el 10 es el IMC calculado en el sql en numeros
            decimal scrIMCPA = Convert.ToDecimal(sc.Rows[0][16]);
            int scrInterv = Convert.ToInt32(sc.Rows[0][11]);
            int scrmay24 = Convert.ToInt32(sc.Rows[0][12]);
            int screcpa = Convert.ToInt32(sc.Rows[0][13]);
            int scrmemb = Convert.ToInt32(sc.Rows[0][14]);
            //IMC a la fecha de control seleccionada
            decimal scrimcc = Convert.ToDecimal(sc.Rows[0][16]);
            //edad materna
            switch (sc.Rows[0][5].ToString())
            {
                case "1":
                    lblA1.Visible = true;
                    lblA1.BackColor = Color.Yellow;
                    break;
                case "2":
                    lblA2.Visible = true;
                    lblA2.BackColor = Color.Orange;
                    break;
            }
            lblA4.Text = scredad.ToString();

            //estado civil
            if (sc.Rows[0][6].ToString() == "1")
            {
                lblB1.BackColor = Color.Yellow;
                lblB1.Visible = true;
            }
            lblB4.Text = scrcivil.ToString();

            //previo menor 2500kg
            if (sc.Rows[0][7].ToString() == "2")
            {
                lblC2.BackColor = Color.Orange;
                lblC2.Visible = true;
            }
            lblC4.Text = scrbpn.ToString();

            //fumadora
            if (sc.Rows[0][8].ToString() == "1")
            {
                lblD1.BackColor = Color.Yellow;
                lblD1.Visible = true;
            }
            lblD4.Text = scrfumad.ToString();

            //IMC
            if (sc.Rows[0][9].ToString() == "1")
            {
                lblE1.BackColor = Color.Yellow;
                lblE1.Visible = true;
            }
            lblIMCPA.Text = decimal.Round(scrIMCPA, 2).ToString();
            lblE4.Text = scrImc.ToString();

            //Intervalo intergenesico
            if (sc.Rows[0][11].ToString() == "1")
            {
                lblF1.BackColor = Color.Yellow;
                lblF1.Visible = true;
            }
            lblF4.Text = scrInterv.ToString();

            //captacion < 16 semanas 12-13
            if (sc.Rows[0][12].ToString() == "2")
            {
                lblG2.BackColor = Color.Orange;
                lblG2.Visible = true;
            }
            if (sc.Rows[0][12].ToString() == "3")
            {
                lblG3.BackColor = Color.Orange;
                lblG3.Visible = true;
            }
            lblG4.Text = scrmay24.ToString();

            //eclampsia-Pre-Ec
            if (sc.Rows[0][13].ToString() == "2")
            {
                lblH2.BackColor = Color.Orange;
                lblH2.Visible = true;
            }
            lblH4.Text = screcpa.ToString();

            //membranas
            if (sc.Rows[0][14].ToString() == "3")
            {
                lblI3.ForeColor = Color.White;
                lblI3.BackColor = Color.Red;
                lblI3.Visible = true;
            }
            lblI4.Text = scrmemb.ToString();

            lblTotal.BackColor = Color.SpringGreen;
            lblTotal.ForeColor = Color.Black;

            int ScoreTotal = scredad + scrcivil + scrbpn + scrfumad + scrImc + scrInterv + scrmay24 + screcpa + scrmemb;

            lblTotal.Text = ScoreTotal.ToString();
            switch (Convert.ToInt32(lblTotal.Text))
            {
                case 0: lblTotal.BackColor = Color.Beige;
                    lblTotal.ToolTip = "Sin Score de Riesgo";
                    break;
                case 1:
                case 2:
                case 3:
                    lblTotal.BackColor = Color.Yellow;
                    lblTotal.ToolTip = "Riesgo Bajo";
                    break;
                case 4:
                case 5:
                    lblTotal.BackColor = Color.Orange;
                    lblTotal.ToolTip = "Riesgo Moderado";
                    break;
                case 6: lblTotal.BackColor = Color.Red;
                    //lblTotal.ForeColor = Color.White;
                    lblTotal.ToolTip = "Riesgo Alto";
                    break;
            }
            if (Convert.ToInt32(lblTotal.Text) > 6)
            {
                lblTotal.BackColor = Color.Red;
                //lblTotal.ForeColor = Color.White;
                lblTotal.ToolTip = "Riesgo Alto";
            }
            lblFecha.Text = sc.Rows[0][15].ToString();
            lblIMCC.Text = scrimcc.ToString();
        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetScore(idPaciente);
        }
    }
}
