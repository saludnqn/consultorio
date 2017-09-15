using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using SIPS.Utilidades;
using Salud.Security.SSO;

namespace SIPS.ControlMenor.Intervenciones
{
    public partial class Edit : Page
    {
        private int idIntervencionProfesional
        {
            get { return ViewState["idIntervencionProfesional"] == null ? 0 : Convert.ToInt32(ViewState["idIntervencionProfesional"]); }
            set { ViewState["idIntervencionProfesional"] = value; }
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
            SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
            if (oUsuario.IsNew) return;
            getProfesionales(oUsuario.SysEfector);
            LoadActividades();
            LoadEspecialidades();
            int idPacienteTemp, idIntervencionTemp;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPacienteTemp))
            {
                idPaciente = idPacienteTemp;
                setPermitirGuardar(idPacienteTemp);
            }
            if (Int32.TryParse(Request.QueryString["id"], out idIntervencionTemp))
            {
                idIntervencionProfesional = idIntervencionTemp;
                LoadIntervencion(idIntervencionTemp);
            }
            
        }

        private void getProfesionales(SysEfector oEfector)
        {
            //Obtengo los medicos de acuerdo al hospital del usuario logueado

            ddlProfesional.DataSource = new SysProfesionalCollection().
                Where(SysProfesional.Columns.IdEfector, oEfector.IdEfector).OrderByAsc(SysProfesional.Columns.Apellido).Load();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataBind();

            ddlProfesional.Items.Insert(0, Utils.getEmptyListItem());
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

        private void LoadIntervencion(int id)
        {
            AprIntervencionProfesional oIntervencion = new AprIntervencionProfesional(id);
            if (oIntervencion.IsNew) { Master.Message("No se encuentra el objeto a editar.", MessageStatus.alert); return; }

            txtFecha.Text = oIntervencion.Fecha.HasValue ? oIntervencion.Fecha.Value.ToShortDateString() : "S/D";
            ddlProfesional.SelectedValue = oIntervencion.Profesional;
            ddlEspecialidad.SelectedValue = oIntervencion.IdEspecialidad.HasValue ? oIntervencion.IdEspecialidad.Value.ToString() : "";
            ddlActividad.SelectedValue = oIntervencion.IdActividad.HasValue ? oIntervencion.IdActividad.Value.ToString() : "";
            txtObservacion.Text = oIntervencion.Observacion;

            setPermitirGuardar(oIntervencion.IdPaciente);
        }

        private void LoadActividades()
        {
            ddlActividad.DataSource = new AprActividadCollection().OrderByAsc(AprActividad.Columns.Nombre).Load();
            ddlActividad.DataTextField = AprActividad.Columns.Nombre;
            ddlActividad.DataValueField = AprActividad.Columns.IdActividad;
            ddlActividad.DataBind();

            ddlActividad.Items.Insert(0, Utils.getEmptyListItem());
        }

        private void LoadEspecialidades()
        {
            ddlEspecialidad.DataSource = new SysEspecialidadCollection().OrderByAsc(SysEspecialidad.Columns.Nombre).Load();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, Utils.getEmptyListItem());
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
            if (DateTime.TryParse(txtFecha.Text, out fecha) && ddlProfesional.SelectedValue.Length > 0)
            {
                AprIntervencionProfesional oIntervencion = new AprIntervencionProfesional(idIntervencionProfesional);

                oIntervencion.IdPaciente = idPaciente;
                oIntervencion.Profesional = ddlProfesional.SelectedValue;
                oIntervencion.Observacion = txtObservacion.Text;
                oIntervencion.Fecha = fecha;

                int idEspecialidad, idActividad;
                if (Int32.TryParse(ddlEspecialidad.SelectedValue, out idEspecialidad))
                    oIntervencion.IdEspecialidad = idEspecialidad;

                if (Int32.TryParse(ddlActividad.SelectedValue, out idActividad))
                    oIntervencion.IdActividad = idActividad;
                try
                {
                    
                    oIntervencion.Save(SSOHelper.CurrentIdentity.Username);
                    Response.Redirect(string.Format("Default.aspx?idPaciente={0}", oIntervencion.IdPaciente));
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
