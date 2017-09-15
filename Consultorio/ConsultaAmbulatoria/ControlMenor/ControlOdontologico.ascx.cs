using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using Consultorio.Utilidades;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public class ResultadoControlOdontologico
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public string profesional = "";
        public Int32? idDiagnostico = null;
        public string observacion = "";
    }

    public partial class ControlOdontologico : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LoadDiagnosticos();
            SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
            if (oUsuario.IsNew) return;
            getMedicos(oUsuario.SysEfector);
        }

        private void LoadDiagnosticos()
        {
            ddlDiagnostico.DataSource = new AprDiagnosticoControlOdontologicoCollection().Load();
            ddlDiagnostico.DataTextField = AprDiagnosticoControlOdontologico.Columns.Nombre;
            ddlDiagnostico.DataValueField = AprDiagnosticoControlOdontologico.Columns.IdDiagnosticoControlOdontologico;
            ddlDiagnostico.DataBind();

            ddlDiagnostico.Items.Insert(0, Utils.getEmptyListItem());
        }

        private void getMedicos(SysEfector oEfector)
        {
            //Obtengo los medicos de acuerdo al hospital del usuario logueado

            ddlProfesional.DataSource = new SysProfesionalCollection().
                Where(SysProfesional.Columns.IdEfector, oEfector.IdEfector).OrderByAsc(SysProfesional.Columns.Apellido).Load();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataBind();
        }

        public ResultadoControlOdontologico getDatos()
        {
            ResultadoControlOdontologico oResultado = new ResultadoControlOdontologico();

            if (ddlDiagnostico.SelectedValue.Length > 0)
            {
                oResultado.idDiagnostico = Convert.ToInt32(ddlDiagnostico.SelectedValue);
            }
            else
            {
                oResultado.Estado = MessageStatus.error;
                oResultado.mensaje.Add("Debe seleccionar un diagnostico.");
            }
            oResultado.profesional = ddlProfesional.SelectedValue;
            if (txtObservacion.Text.Length > 0)
            {
                oResultado.observacion = txtObservacion.Text;
            }
            return oResultado;
        }
    }
}