using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using SIPS.Utilidades;
using Salud.Security.SSO;

namespace SIPS.ControlMenor.VisitasDomiciliarias
{
    public partial class Edit : System.Web.UI.Page
    {
        private int idVisitaDomiciliaria
        {
            get { return ViewState["idVisitaDomiciliaria"] == null ? 0 : Convert.ToInt32(ViewState["idVisitaDomiciliaria"]); }
            set { ViewState["idVisitaDomiciliaria"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        private bool PermitirGuardar
        {
            get { return ViewState["permitirGuardar"] == null ? false : Convert.ToBoolean(ViewState["permitirGuardar"]); }
            set { ViewState["permitirGuardar"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            txtFecha.Text = DateTime.Today.ToShortDateString();
            LoadMotivosVisitas();
            SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
            if (oUsuario.IsNew) return;
            getProfesionales(oUsuario.SysEfector);
            int idPacienteTemp, idVisitaTemp;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPacienteTemp))
            {
                idPaciente = idPacienteTemp;
                setPermitirGuardar(idPacienteTemp);
            }
            if (Int32.TryParse(Request.QueryString["id"], out idVisitaTemp))
            {
                idVisitaDomiciliaria = idVisitaTemp;
                LoadVisita(idVisitaTemp);
            }
        }

        private void getProfesionales(SysEfector oEfector)
        {
            //Obtengo los medicos de acuerdo al hospital del usuario logueado
            ddlPersonal.DataSource = new SysProfesionalCollection().
                Where(SysProfesional.Columns.IdEfector, oEfector.IdEfector).OrderByAsc(SysProfesional.Columns.Apellido).Load();
            ddlPersonal.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlPersonal.DataValueField = SysProfesional.Columns.NombreCompleto;
            ddlPersonal.DataBind();

            ddlPersonal.Items.Insert(0, Utils.getEmptyListItem());
        }

        private void setPermitirGuardar(int idPaciente)
        {
            SysPaciente oPaciente = new SysPaciente(idPaciente);
            if (oPaciente != null)
            {
                DateDifference oDateDifference = new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                PermitirGuardar = oDateDifference.Years <= 6;
            }
        }

        private void LoadVisita(int id)
        {
            AprVisitaDomiciliarium oVisita = new AprVisitaDomiciliarium(id);
            if (oVisita.IsNew) { Master.Message("No se encuentra el objeto a editar.", MessageStatus.alert); return; }

            txtFecha.Text = oVisita.Fecha.ToShortDateString();
            ddlPersonal.SelectedValue = oVisita.Personal;
            ddlMotivoVisita.SelectedValue = oVisita.IdMotivoVisitaDomiciliaria.ToString();
            txtOtroMotivo.Text = oVisita.OtroMotivo;
            txtObservacion.Text = oVisita.Observacion;

            setPermitirGuardar(oVisita.IdPaciente);
        }

        private void LoadMotivosVisitas()
        {
            ddlMotivoVisita.DataSource = new AprMotivoVisitaDomiciliariumCollection().OrderByAsc(AprMotivoVisitaDomiciliarium.Columns.Nombre).Load();
            ddlMotivoVisita.DataTextField = AprMotivoVisitaDomiciliarium.Columns.Nombre;
            ddlMotivoVisita.DataValueField = AprMotivoVisitaDomiciliarium.Columns.IdMotivoVisitaDomiciliaria;
            ddlMotivoVisita.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Default.aspx?idPaciente={0}", idPaciente));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!PermitirGuardar)
            {
                Master.Message("No se pueden Modificar los datos del paciente, el mismo es mayor de 6 años.", MessageStatus.alert);
                return;
            }

            DateTime fecha;
            int idMotivo;
            if (DateTime.TryParse(txtFecha.Text, out fecha) && ddlPersonal.SelectedValue.Length > 0 && Int32.TryParse(ddlMotivoVisita.SelectedValue, out idMotivo))
            {
                AprVisitaDomiciliarium oVisita = new AprVisitaDomiciliarium(idVisitaDomiciliaria);

                oVisita.IdPaciente = idPaciente;
                oVisita.Personal = ddlPersonal.SelectedValue;
                oVisita.OtroMotivo = txtOtroMotivo.Text;
                oVisita.Observacion = txtObservacion.Text;
                oVisita.Fecha = fecha;
                oVisita.IdMotivoVisitaDomiciliaria = idMotivo;

                try
                {
                   
                    oVisita.Save(SSOHelper.CurrentIdentity.Username);
                    Response.Redirect(string.Format("Default.aspx?idPaciente={0}", oVisita.IdPaciente));
                }
                catch (Exception Ex)
                {
                    string exception = "";
                    while (Ex != null)
                    {
                        exception = Ex.Message + "<br>";
                        Ex = Ex.InnerException;
                    }
                    Master.Message(exception, MessageStatus.error);
                }
            }
            else
            {
                Master.Message("Los datos en el formulario son incorrectos", MessageStatus.error);
            }
        }
    }
}
