using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using DalSic;
using System.Data;
using Salud.Security.SSO;
using System.Xml;
using System.Data.SqlClient;
using SubSonic;
using System.Xml.Linq;

namespace TurnosProtegidos
{
    /// <summary>
    /// Summary description for WebServicePrueba
    /// </summary>
    [WebService(Namespace = "http://localhost")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePrueba : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Edad(string edad)
        {
            return "Tu edad es: " + edad;
        }

        //devuleve los datos en XML
        [WebMethod(Description = "Resultados en XML")]
        public XmlDocument Consultas(int idPac)
        {
            // ,ejemplo:
            //
            //  <INTERCONSULTA>
            //      <IDPACIENTE>1111</IDPACIENTE>
            //      <IDEFECTOR>2222</IDEFECTOR>
            //      <IDPACIENTE>3333</IDPACIENTE>
            //      <IDEFECTOR>4444</IDEFECTOR>
            //  </INTERCONSULTA>

            string xml = "<INTERCONSULTA>";

            DataTable dtInterconsula = new DataTable();
            //dtInterconsula = SPs.TupPruebaWs(1).GetDataSet().Tables[0];

            //xml += "<IDPACIENTE>" + "111" + "</IDPACIENTE>";
            //xml += "<IDEFECTOR>" + "222" + "</IDEFECTOR>";
            //xml += "<IDPACIENTE>" + "333" + "</IDPACIENTE>";
            //xml += "<IDEFECTOR>" + "444" + "</IDEFECTOR>";
            //xml += "<IDPACIENTE>" + "555" + "</IDPACIENTE>";
            //xml += "<IDEFECTOR>" + "666" + "</IDEFECTOR>";

            foreach (DataRow datoIntgerconsulta in dtInterconsula.Rows)
            {
                xml += "<IDPACIENTE>" + datoIntgerconsulta[0] + "</IDPACIENTE>";
                xml += "<IDEFECTOR>" + datoIntgerconsulta[1] + "</IDEFECTOR>";
            }

            xml += "</INTERCONSULTA>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            return xmlDoc;




            //string xml = "<IDPACIENTE><IDEFECTOR>Sin Datos</IDEFECTOR></IDPACIENTE>";
            ////"<Consultas><FechaPractica><Practica><Observaciones><Efector>Sin Datos</Efector></Observaciones></Practica></FechaPractica></Consultas>";

            //try
            //{
            //    //string query = " SELECT [Code] ,[Name] ,[Price] FROM [Product] where [Name] like ‘%Name%’  FOR XML RAW ('Product'),ROOT ('Products'),ELEMENTS;";
            //    //SqlCommand cmd = new SqlCommand(query, con);
            //    //IDataReader dr = SPs.WSHistoriaCLinica(idPac).GetReader();
            //    IDataReader dr = SPs.TupPruebaWs(1).GetReader();

            //    if (dr.Read())
            //    {
            //        xml = dr[1].ToString();
            //    }
            //}
            //catch (Exception) { }

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(xml);
            //return xmlDoc;


        }    

    }
}
