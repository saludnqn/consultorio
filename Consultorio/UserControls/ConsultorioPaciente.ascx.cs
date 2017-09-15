using DalSic;
using Salud.Security.SSO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Consultorio.Utilidades;

namespace UserControls
{
    public partial class ConsultorioPaciente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void HabilitarBotonesConsulta(SysPaciente p, int idturno)
        {
            HfidPaciente.Value = p.IdPaciente.ToString();
            HfDNI.Value = p.NumeroDocumento.ToString();
            HfidEfector.Value = SSOHelper.CurrentIdentity.IdEfector.ToString();
            HfidTurno.Value = idturno.ToString();

            string strIdHospital = SSOHelper.Configuration["idHospital"] as string;
            if (strIdHospital != "0")
            {               

                BtnLabo.Visible = false; BtnVerInter.Visible = false; BtnNvaInter.Visible = false; BtnEventos.Visible = false; BtnControl.Visible = false;
                ////////////////77
                BtnEventosHospital.Visible = true;
                BtnLaboHospital.Visible = true;
                BtnPedidoPAP.Visible = false;
            }
            else
            {  
                //consultar si tiene algun laboratorio, habilitar para ingresar
                BtnLaboHospital.Visible = false;             
            
                LabResultadoEncabezado conLab = new SubSonic.Select()
                      .From(Schemas.LabResultadoEncabezado)
                        .Where(LabResultadoEncabezado.Columns.NumeroDocumento).IsEqualTo(p.NumeroDocumento)
                          .ExecuteSingle<LabResultadoEncabezado>();
                if (conLab != null)
                    BtnLabo.Visible = true;
                else
                    BtnLabo.Visible = false;

                //consultar si tiene alguna interconsulta, habilitar para ingresa
                //IcoInterconsultum conInterconsulta = new SubSonic.Select()
                //      .From(Schemas.IcoInterconsultum)
                //        .Where(IcoInterconsultum.Columns.IdPaciente).IsEqualTo(p.IdPaciente)
                //          .ExecuteSingle<IcoInterconsultum>();
                //if (conInterconsulta != null)
                //    BtnVerInter.Visible = true;
                //else
                //    BtnVerInter.Visible = false;

                DataTable dtInterconsultas = new DataTable();
                dtInterconsultas = SPs.IcoVerificarSiTieneInterconsultas(p.IdPaciente).GetDataSet().Tables[0];

                if (dtInterconsultas.Rows.Count != 0)
                {
                    BtnVerInter.Visible = true;
                }
                else
                {
                    BtnVerInter.Visible = false;                
                }

                //Habilito las consultas a los demas modulos
                //Si es femenino podra ingresar al modulo del control perinatal
                if (p.IdSexo == 2) //Femenino
                {
                    BtnControl.Visible = true;
                    BtnMamas.Visible = true;
                    ///pongo visible Pedido de PAP y HPV solo para nivel central
                    DateDifference oEdad = new DateDifference(p.FechaNacimiento, DateTime.Now);
                    if ((oEdad.Years > 30) && (oEdad.Years < 64))
                        BtnPedidoPAP.Visible = true;
                }

                else
                {
                    BtnControl.Visible = false;
                    BtnMamas.Visible = false;
                }
            }

            if ((!BtnPedidoPAP.Visible) && (!BtnMamas.Visible)) pnlPrestaciones.Visible = false;
            /// Pacientes para VGI
            DateDifference oEdadGeriatrico = new DateDifference(p.FechaNacimiento, DateTime.Now);
            if (oEdadGeriatrico.Years > 60) // definir la edad de pacientes geriatricos para VGI.
                BtnNuevoVGI.Visible = true;
            else
                BtnNuevoVGI.Visible = false;
            ////
        }


        private bool getLaboratorios(int p)
        {
            bool hay = false;
            string s_urlWFC = ConfigurationManager.AppSettings["WSLaboratorio"].ToString();
            string s_url = s_urlWFC + "/GetLaboratoriosPaciente?idPaciente=" + p.ToString(); ;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(s_url);
            HttpWebResponse ws1 = (HttpWebResponse)request.GetResponse();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            Stream st = ws1.GetResponseStream();
            StreamReader sr = new StreamReader(st);

            string s = sr.ReadToEnd();
            if (s != "0")
            {
                int inicio = s.IndexOf("[");
                int fin = s.IndexOf("]") + 1;
                string aux = s.Substring(inicio, fin - inicio);

                List<PacienteLabo> lista = jsonSerializer.Deserialize<List<PacienteLabo>>(aux);

                if (lista.Count > 0) hay = true;
            }
            return hay;
        }

        public class PacienteLabo
        {
            public int Documento { get; set; }
            public string Apellidos { get; set; }
            public string Nombres { get; set; }
            public string FechaNacimiento { get; set; }
            public string Sexo { get; set; }
            public string Efector { get; set; }
            public string NumeroProtocolo { get; set; }
            public string FechaProtocolo { get; set; }
            public int idProtocolo { get; set; }
            public int idEfector { get; set; }
        }
    }
}