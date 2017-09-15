using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DalSic;
using Consultorio.Utilidades;
using Salud.Security.SSO;

namespace Consultorio.UserControls
{
    public partial class ResumenPaciente : System.Web.UI.UserControl
    {
        private int idHCP
        {
            
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idTemp)) ? idTemp : 0; }
        }

        private int semanas
        {
            get { return ViewState["semanas"] == null ? -1 : Convert.ToInt32(ViewState["semanas"]); }
            set { ViewState["semanas"] = value; }
        }

        private DateDifference edad
        {
            get { return ViewState["edad"] == null ? new DateDifference(DateTime.Now, DateTime.Now) : ViewState["edad"] as DateDifference; }
            set { ViewState["edad"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (idHCP == 0)
            {
                divResumenPaciente.Attributes["class"]+= " ui-helper-hidden";
            }
            else
            {
                AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal(idHCP);
                SysPaciente oPaciente = new SysPaciente(oHCP.IdPaciente);
                int idPaciente = oHCP.IdPaciente;
                if (!oPaciente.IsNew)
                {
                    DateDifference oEdad=new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                    edad = oEdad;
                    ltPaciente.Text = String.Format("{0}, {1}", oPaciente.Apellido, oPaciente.Nombre);
                    ltDocumentoUnico.Text = oPaciente.NumeroDocumento.ToString();
                    ltFechaNacimiento.Text = oPaciente.FechaNacimiento.ToShortDateString();
                    ltEdad.Text = oEdad.ToString();
                    semanas = oEdad.Weeks;
                    ltObraSocial.Text = oPaciente.SysObraSocial.Nombre;
                    ltSexo.Text = oPaciente.SysSexo.Nombre;
                    //ltCronico.Text = oPaciente.Cronico ? "SI" : "NO";

                    //traigo el numero de historia clinica en el efector
                    int efector = SSOHelper.CurrentIdentity.IdEfector;
                    DataTable dt = SPs.SysGetPacientesHC(oPaciente.NumeroDocumento, efector).GetDataSet().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0][9].ToString()))
                        {
                            int numeroHistoria = Convert.ToInt32(dt.Rows[0][9]);
                            ltHC.Text = numeroHistoria.ToString();
                        }
                    } 

                    lkEditar.NavigateUrl = "~/Paciente/PacienteEdit.aspx?id=" + idPaciente.ToString();
                    if (oEdad.Years > 6)
                    {
                        //mayor de 6 años, oculto el link de control del menor
                        lkControlmenor.Visible = false;
                    }
                    else
                    {
                        //Menor o igual a 6 años, muestro el link del controles del menor
                        lkControlmenor.NavigateUrl = String.Format("~/ControlMenor/?idPaciente={0}", idPaciente);
                    }
                }
                else
                {
                    divResumenPaciente.Attributes["class"]+= " ui-helper-hidden";
                }
            }
        }

        public int getSemanas()
        {
            return semanas;
        }

        public DateDifference edadPaciente()
        {
            return edad;
        }
    }
}