using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalSic;
using System.Text;

namespace UserControls
{
    public partial class CalendarioVacunacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            LoadCalendario();
        }

        private void LoadCalendario()
        {
            DataTable oCalendario = SPs.AprCalendarioVacunacion().GetDataSet().Tables[0];

            StringBuilder oHeader = new StringBuilder();
            StringBuilder oBody = new StringBuilder();
            string edad = "";
            string LastHeader = "";
            Boolean header = true;
            foreach (DataRow oRow in oCalendario.Rows)
            {
                if (edad != oRow["EdadSemanas"].ToString())
                {                    
                    if (oBody.Length == 0)
                    {
                        oBody.AppendFormat("<tr><td>{0}</td>", oRow["NombreEdad"]);
                    }
                    else
                    {
                        header = false;
                        oBody.AppendFormat("</tr><tr><td>{0}</td>", oRow["NombreEdad"]);
                    }
                    edad = oRow["EdadSemanas"].ToString();
                }
                if (header)
                {
                    oHeader.AppendFormat("<th>{0}</th>", oRow["NombreVacuna"]);
                    LastHeader = oRow["NombreVacuna"].ToString();
                }

                oBody.AppendFormat("<td>{0}</td>", oRow["nombre"]);
            }
            oBody.Append("</tr>");

            calBody.Text = oBody.ToString();
            calHeader.Text = oHeader.ToString();
        }
    }
}