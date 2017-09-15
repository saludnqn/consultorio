using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Data;
using ExtensionMethods;
using System.Globalization;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public class ResultadoEnfermeria
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public decimal peso = -1;
        public decimal talla = -1;
        public float perimetrocefalico = -1;
        public int estadonutricional = -1;
        public int tallaedad;
        //nuevos datos
        public int profesional;
        public string observacion;
        public int paciente;
        public DateTime fecha;
        public string ta;
    }

    public partial class Enfermeria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            hfPaciente.Value = Request.QueryString["idPaciente"];

            SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
            if (oUsuario.IsNew) return;

            txtFecha.Text = DateTime.Now.ToShortDateString();
            LoadEstadosNutricionales();
            LoadTallaEdad();
            LoadProfesional(oUsuario.SysEfector);
            int idPaciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
            DataTable dt = SPs.AprGetMaxPerimetroCefalico(idPaciente).GetDataSet().Tables[0];
            rvperimetrocefalico.MinimumValue = dt.Rows[0][0].ToString();
          
            //  AlternarIMC();
        }

        private void LoadProfesional(SysEfector oEfector)
        {
            //Obtengo los profesionales de acuerdo al hospital del usuario logueado
            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(oEfector.IdEfector, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();
            ddlProfesional.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
        }

        private void AlternarIMC()
        {
            ConsultaAmbulatoria.MasterPages.Consultorio oMaster = Page.Master as ConsultaAmbulatoria.MasterPages.Consultorio;
            if (oMaster != null)
            {
                if (oMaster.getAños() >= 2)
                {
                    hfHabilitarIMC.Value = "1";
                }
                else
                {
                    hfHabilitarIMC.Value = "0";
                }
            }
        }

        private void LoadEstadosNutricionales()
        {
            ConsultaAmbulatoria.MasterPages.Consultorio oMaster = Page.Master as ConsultaAmbulatoria.MasterPages.Consultorio;
            if (oMaster != null)
            {
                ddlEstadoNutricional.DataSource = new AprEstadoNutricionalCollection().
                    Where(AprEstadoNutricional.Columns.MinSemanas, SubSonic.Comparison.LessOrEquals, oMaster.getSemanas()).
                    Where(AprEstadoNutricional.Columns.MaxSemanas, SubSonic.Comparison.GreaterOrEquals, oMaster.getSemanas()).Load();
                ddlEstadoNutricional.DataTextField = AprEstadoNutricional.Columns.Nombre;
                ddlEstadoNutricional.DataValueField = AprEstadoNutricional.Columns.IdEstadoNutricional;
                ddlEstadoNutricional.DataBind();

                ddlEstadoNutricional.Items.Insert(0, Utilidades.Utils.getEmptyListItem());
            }
        }

        private void LoadTallaEdad()
        {
            ddlTallaEdad.DataSource = new AprTallaEdadCollection().Load();
            ddlTallaEdad.DataTextField = AprTallaEdad.Columns.Nombre;
            ddlTallaEdad.DataValueField = AprTallaEdad.Columns.IdTallaEdad;
            ddlTallaEdad.DataBind();

            ddlTallaEdad.Items.Insert(0, Utilidades.Utils.getEmptyListItem());
        }

        public ResultadoEnfermeria getDatos()
        {
            ResultadoEnfermeria oResultado = new ResultadoEnfermeria();
            CultureInfo ci = null;
            ci = CultureInfo.InvariantCulture;
            decimal peso; decimal talla; float perimetrocefalico; int estadonutricional, tallaedad;
            if (!string.IsNullOrEmpty(txtPeso.Text)) 
            {
               peso = decimal.Parse(txtPeso.Text.Replace(",","."), ci);
                if ((peso>=2) && (peso<=45))
                {
                    oResultado.peso = peso;
                }
                else
                {
                    oResultado.Estado = MessageStatus.alert;
                    oResultado.mensaje.Add("El peso debe ser un valor numerico entre 2 y 45.");
                }
            }
            if (!string.IsNullOrEmpty(txtTalla.Text))
            {
                decimal tallaminima = Convert.ToDecimal(45/100);
                decimal tallamaxina = Convert.ToDecimal(210/100);
                talla = decimal.Parse(txtTalla.Text.Replace(",", "."), ci);
                if (talla >= tallaminima && talla <= tallamaxina)
                {
                    oResultado.talla = talla;
                }
                else
                {
                    oResultado.Estado = MessageStatus.alert;
                    oResultado.mensaje.Add("La talla debe ser un valor numerico entre 45 y 210.");
                }
            }
            if (!string.IsNullOrEmpty(txtPerimetroCefalico.Text))
            {
                if (float.TryParse(txtPerimetroCefalico.Text, out perimetrocefalico) && perimetrocefalico >= 30 && perimetrocefalico <= 60)
                {
                    //validar que el nuevo perímetro cefálico no sea menor al anterior
                    oResultado.perimetrocefalico = perimetrocefalico;
                }
                else
                {
                    oResultado.Estado = MessageStatus.alert;
                    oResultado.mensaje.Add("El perimetro debe ser un valor numerico entre 30 y 60.");
                }
            }
            if (!string.IsNullOrEmpty(ddlEstadoNutricional.SelectedValue))
            {
                if (Int32.TryParse(ddlEstadoNutricional.SelectedValue, out estadonutricional))
                {
                    oResultado.estadonutricional = estadonutricional;
                }
                else
                {
                    oResultado.Estado = MessageStatus.alert;
                    oResultado.mensaje.Add("No se puede recuperar el valor del estado nutricional.");
                }
            }
            if (!string.IsNullOrEmpty(ddlTallaEdad.SelectedValue))
            {
                if (Int32.TryParse(ddlTallaEdad.SelectedValue, out tallaedad))
                {
                    oResultado.tallaedad = tallaedad;
                }
                else
                {
                    oResultado.Estado = MessageStatus.alert;
                    oResultado.mensaje.Add("No se puede recuperar el valor de la talla para la edad.");
                }
            }

            //datos nuevos
            if (!string.IsNullOrEmpty(txtFecha.Text))
            {
                oResultado.fecha = Convert.ToDateTime(txtFecha.Text);
            }
            if (!string.IsNullOrEmpty(txtTA.Text))
            {
                oResultado.ta = txtTA.Text;
            }
            if (!string.IsNullOrEmpty(ddlProfesional.SelectedValue))
            {
                oResultado.profesional = Convert.ToInt32(ddlProfesional.SelectedValue);
            }
            if (!string.IsNullOrEmpty(txtObservaciones.Text))
            {
                oResultado.observacion = txtObservaciones.Text;
            }
            oResultado.paciente = Convert.ToInt32(hfPaciente.Value);
            return oResultado;
        }
    }
}