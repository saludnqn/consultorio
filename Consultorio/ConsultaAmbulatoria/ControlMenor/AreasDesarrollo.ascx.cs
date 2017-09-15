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
    public class ResultadoAreasDesarrollo
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public AprRelControlNiñoSanoAreaDesarrolloCollection desarrollos = new AprRelControlNiñoSanoAreaDesarrolloCollection();
    }

    public partial class AreasDesarrollo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            int idPaciente;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPaciente))
                LoadAreasDesarrollo(idPaciente);
        }

        private void LoadAreasDesarrollo(int idPaciente)
        {
            SysPaciente oPaciente = new SysPaciente(idPaciente);
            if (oPaciente.IsNew) return;

            DateDifference edadPaciente = new DateDifference(oPaciente.FechaNacimiento, DateTime.Now);
            rptAreaDesarrollo.DataSource = new SubSonic.Select().From(Schemas.AprAreaDesarrollo)
                .Where(AprAreaDesarrollo.Columns.EdadLimite).IsLessThanOrEqualTo(edadPaciente.Weeks)
                .OrderAsc(AprAreaDesarrollo.Columns.Orden)
                .ExecuteAsCollection<AprAreaDesarrolloCollection>();
            rptAreaDesarrollo.DataBind();
        }

        public ResultadoAreasDesarrollo getDatos()
        {
            ResultadoAreasDesarrollo oResultado = new ResultadoAreasDesarrollo();

            foreach (RepeaterItem oRow in rptAreaDesarrollo.Items)
            {
                HiddenField hfAreaDesarrolloID = oRow.FindControl("hfAreaDesarrolloID") as HiddenField;
                RadioButton cbAreaDesarrolloSi = oRow.FindControl("cbAreaDesarrolloSi") as RadioButton;
                RadioButton cbAreaDesarrolloNo = oRow.FindControl("cbAreaDesarrolloNo") as RadioButton;
                TextBox txtAreaDesarrolloItem = oRow.FindControl("txtAreaDesarrolloItem") as TextBox;
                int idAreaDesarrollo;
                if (hfAreaDesarrolloID != null && cbAreaDesarrolloSi != null
                    && cbAreaDesarrolloNo != null && txtAreaDesarrolloItem != null
                    && Int32.TryParse(hfAreaDesarrolloID.Value, out idAreaDesarrollo))
                {
                    int Item;
                    if (txtAreaDesarrolloItem.Text.Length > 0 && Int32.TryParse(txtAreaDesarrolloItem.Text, out Item))
                    {
                        if (cbAreaDesarrolloSi.Checked || cbAreaDesarrolloNo.Checked)
                        {
                            //Se marco alguno, deberia guardarlo
                            AprRelControlNiñoSanoAreaDesarrollo oAreaDesarrollo = new AprRelControlNiñoSanoAreaDesarrollo();
                            oAreaDesarrollo.IdAreaDesarrollo = idAreaDesarrollo;
                            oAreaDesarrollo.Item = Item;
                            oAreaDesarrollo.Adecuado = cbAreaDesarrolloSi.Checked ? true : cbAreaDesarrolloNo.Checked ? false : false;

                            oResultado.desarrollos.Add(oAreaDesarrollo);
                        }
                        else
                        {
                            //NO se marco si o no, deberia marcarse
                            oResultado.Estado = MessageStatus.error;
                            oResultado.mensaje.Add("Debe seleccionar aguna opcion.");
                        }
                    }
                    else
                    {
                        if (txtAreaDesarrolloItem.Text.Length > 0)
                        {
                            //Se escribio un item, pero no es un numero
                            oResultado.Estado = MessageStatus.error;
                            oResultado.mensaje.Add("El item debe ser numerico");
                        }
                    }
                }
            }
            return oResultado;
        }
    }
}