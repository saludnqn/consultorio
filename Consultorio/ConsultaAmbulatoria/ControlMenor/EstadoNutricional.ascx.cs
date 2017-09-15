using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public class ResultadoEstadoNutricional
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public int? idTipoLactancia = null;
        public int? idIntervencion = null;
    }

    public partial class EstadoNutricional : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LoadLactancia();
            LoadIntervencion();
        }

        private void LoadLactancia()
        {
            rblLactancia.DataSource = new AprTipoLactanciumCollection().Load();
            rblLactancia.DataTextField = AprTipoLactancium.Columns.Nombre;
            rblLactancia.DataValueField = AprTipoLactancium.Columns.IdTipoLactancia;
            rblLactancia.DataBind();
        }

        private void LoadIntervencion()
        {
            ddlIntervencion.DataSource = new AprIntervencionCollection().Load();
            ddlIntervencion.DataTextField = AprIntervencion.Columns.Nombre;
            ddlIntervencion.DataValueField = AprIntervencion.Columns.IdIntervencion;
            ddlIntervencion.DataBind();

            ddlIntervencion.Items.Insert(0, new ListItem("[SELECCIONE]", ""));
        }

        public ResultadoEstadoNutricional getDatos()
        {
            ResultadoEstadoNutricional oResultado = new ResultadoEstadoNutricional();
            
            int idTipoLactancia, idIntervencion;
            if (Int32.TryParse(rblLactancia.SelectedValue, out idTipoLactancia))
            {
                oResultado.idTipoLactancia = idTipoLactancia;
            }
            if (Int32.TryParse(ddlIntervencion.SelectedValue, out idIntervencion))
            {
                oResultado.idIntervencion = idIntervencion;
            }

            return oResultado;
        }
    }
}