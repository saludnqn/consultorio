using System;
using DalSic;
using System.Data;
using Salud.Security.SSO;
using Consultorio.Utilidades;
using System.Web.UI.WebControls;


namespace Consultorio.ConsultaAmbulatoria
{
    public partial class Inicio : System.Web.UI.Page
    {

        public bool MostrarAlerta
        {
            get { return Session["alertaModal"] == null; }
            set { Session["alertaModal"] = value; }
        }

        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                //if (this.MostrarAlerta)
                //{
                //    //muestro alerta
                //    //Session["alertaModal"] = true;
                //    this.MostrarAlerta = true;
                //}


                Session["modulo"] = "APS";
                //aca llamo al store de muestra los alertas si los hubiese
                DataTable d = SPs.AprGetAlertaCP(SSOHelper.CurrentIdentity.IdEfector).GetDataSet().Tables[0];
                if (d.Rows.Count > 0)
                {
                    gvPacientes.DataSource = d;
                    gvPacientes.DataBind();
                    upAlertas.Visible = true;

                }
                else upAlertas.Visible = false;
                DatosUsuarios.Visible = false;
                MensajePacienteNoE.Visible = false;

                //*******************************************************************
                //Cargo los datos del paciente
                //*******************************************************************
                int id = Convert.ToInt32(Request.QueryString["idPaciente"]);
                SysPaciente oPaciente = new SysPaciente(id);
                hfPaciente.Value = oPaciente.IdPaciente.ToString();

                DateDifference oEdad=new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                //edad = oEdad;
                ltPaciente.Text = String.Format("{0}, {1}", oPaciente.Apellido, oPaciente.Nombre);
                ltDocumentoUnico.Text = oPaciente.NumeroDocumento.ToString();
                ltFechaNacimiento.Text = oPaciente.FechaNacimiento.ToShortDateString();
                ltEdad.Text = oEdad.ToString();
                //semanas = oEdad.Weeks;
                ltObraSocial.Text = oPaciente.SysObraSocial.Nombre;
                ltSexo.Text = oPaciente.SysSexo.Nombre;
                
                lkEditar.NavigateUrl = "~/Paciente/PacienteEdit.aspx?id=" + oPaciente.IdPaciente.ToString();
                    //if (oEdad.Years > 6)
                    //{
                    //    //mayor de 6 años, oculto el link de control del menor
                    //    lkControlmenor.Visible = false;
                    //}
                    //else
                    //{
                    //    //Menor o igual a 6 años, muestro el link del controles del menor
                    //    lkControlmenor.NavigateUrl = String.Format("~/ControlMenor/?idPaciente={0}", idPaciente);
                    //}
                MensajePacienteNoE.Visible = false;
                DatosUsuarios.Visible = true;
                    //llenado de la grilla con las que tengan una HCPerinatal abierta o actual
                DataTable pchc = SPs.AprGetPacientesConHCP(oPaciente.IdPaciente).GetDataSet().Tables[0];
                if (pchc.Rows.Count > 0)
                {
                    lblTitulo.Visible = true;
                    lblTitulo.Text = "Historia Clínica Perinatal";
                    gvEmbarazadas.Visible = true;
                    gvEmbarazadas.DataSource = pchc;
                    gvEmbarazadas.DataBind();
                }             
                
                else
                {
                    MensajePacienteNoE.Visible = true;
                    DatosUsuarios.Visible = false;                
                }                
            }            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaAmbulatoria/ControlPerinatal/Control/?idPaciente=" + hfPaciente.Value);
        }

        protected void cerrarHCP(object sender, EventArgs e)
        {
            string MotivoCierre = motivoCierreHCP.Text;
            int idHCP= int.Parse(Server.HtmlEncode(txtoculto.Text));
            AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal(idHCP);
            oHCP.Activa = false;
            oHCP.Observaciones = MotivoCierre;
            oHCP.Save(SSOHelper.CurrentIdentity.Username);

            Response.Redirect(Request.RawUrl);
        }

        protected void gvEmbarazadas_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "True")
                {
                    Image hlE = new Image();
                    hlE = (Image)e.Row.FindControl("imgEstado");
                    hlE.ImageUrl = "../App_Themes/Default/images/abierto.jpg";
                    hlE.ToolTip = "Estado Abierta";
                }
                else
                {
                    Image hlE = new Image();
                    hlE = (Image)e.Row.FindControl("imgEstado");
                    hlE.ImageUrl = "../App_Themes/Default/images/cerrado.jpg";
                    hlE.ToolTip = "Estado Cerrada";
                    e.Row.Cells[9].Text = "";
                    //e.Row.Cells[9].Enabled = false;                   
                }
            }
        }
    }
}
