using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using SubSonic;
using DalSic;
using Salud.Security.SSO;


namespace Consultorio.Informes
{
    public partial class DemandaRechazada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
                if (!IsPostBack)
                {                    
                    llenarCombos();
                    txtDesde.Text = DateTime.Now.ToString().Substring(0, 10);
                    txtHasta.Text = DateTime.Now.ToString().Substring(0, 10);                  
                }           
        }        

        private void llenarCombos()
        {            
            ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, -1).GetDataSet();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, "--Seleccione--");
        }
  
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            MostrarPacientes();
        }        

        private void MostrarPacientes()
        {
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }

            gvPacientes.DataSource = SPs.ConGetDemandaRechazada(SSOHelper.CurrentIdentity.IdEfector, int.Parse(ddlEspecialidad.SelectedValue), fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), 0).GetDataSet();
            gvPacientes.DataBind();
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton cmdEditar = (LinkButton)e.Row.FindControl("Asignar");
                cmdEditar.CommandArgument = gvPacientes.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdEditar.CommandName = "Asignar";
                cmdEditar.ToolTip = "Asignar";
            }
        }

         protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != "")
            {
                ConDemandaRechazada DemandaRechazada = new ConDemandaRechazada(int.Parse(e.CommandArgument.ToString()));
                if (e.CommandName == "Asignar")
                    Response.Redirect("../Turnos/TurnoNuevo.aspx?idDemandaRechazada=" + e.CommandArgument.ToString() + "&idPaciente=" + DemandaRechazada.IdPaciente.ToString(), false);
            }
        }
       
        protected void btInsert_Click(object sender, EventArgs e)
        {
            ConDemandaRechazada demandaRechazada = new ConDemandaRechazada();           

            TextBox tbInsert = ((Button)sender).Parent.FindControl("tbInsert") as TextBox;
            HiddenField hf = ((Button)sender).Parent.FindControl("hdnidDemandaRechazada") as HiddenField;

            string param = hf.Value;
            demandaRechazada.ObservacionLLamada = tbInsert.Text;
            demandaRechazada.IdUsuario = SSOHelper.CurrentIdentity.Id;

            SPs.ConUpdateLLamadaDemandaRechazada(Convert.ToInt16(param), demandaRechazada.ObservacionLLamada, demandaRechazada.IdUsuario).ExecuteScalar();

            string popupScript = "<script language='JavaScript'> alert('La Demanda se guardó correctamente')</script>";
            ClientScript.RegisterClientScriptBlock(GetType(), "PopupScript", popupScript);
        }      
    }
}
