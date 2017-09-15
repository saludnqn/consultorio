using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalSic;
using SubSonic;
using Salud.Security.SSO;

namespace Consultorio.Abm {
    public partial class TablaConsultorios : System.Web.UI.Page {

        private DataTable dtGrilla {
            get { return ViewState["dtGrilla"] == null ? null : (DataTable)(ViewState["dtGrilla"]); }
            set { ViewState["dtGrilla"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {            
            
                if (!IsPostBack) {
                    llenarTipos();
                }
           
        }

        private void llenarTipos() {
            int idEfector = SSOHelper.CurrentIdentity.IdEfector;
            gvTipos.DataSource = new Select().From(Schemas.ConConsultorioTipo)
                                            .Where(ConConsultorioTipo.Columns.IdEfector)
                                            .IsEqualTo(idEfector)
                                            .ExecuteDataSet().Tables[0];
            gvTipos.DataBind();

            if (gvTipos.Rows.Count > 0) { gvTipos.SelectedIndex = 0; }
        }

        protected void gvTipos_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                //ImageButton cmdSel = (ImageButton)e.Row.Cells[0].FindControl("cmdSel");
                LinkButton cmdSel = (LinkButton)e.Row.FindControl("cmdSel");
                cmdSel.CommandArgument = gvTipos.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdSel.CommandName = "Select";
                cmdSel.ToolTip = "Seleccionar tipo de consultorio";
            }
        }

        protected void gvTipos_SelectedIndexChanged(object sender, EventArgs e) {
                seleccionarTipo();             
        }

        private void seleccionarTipo() {
            int idTipoConsultorio = Convert.ToInt32(gvTipos.DataKeys[gvTipos.SelectedIndex].Value);
            ConConsultorioTipo tipo = new ConConsultorioTipo(idTipoConsultorio);

            cmdEliminar.Visible = true;
            cmdRenombrar.Visible = true;

            dtGrilla = getConsultorios(tipo);
            gvConsultorios.EmptyDataText = "El tipo de consultorio seleccionado no contiene consultorios asociados";
            gvConsultorios.DataSource = dtGrilla;
            gvConsultorios.DataBind();

            inpConfirma.Value = "";
            lblConfirma.Text = "";
            lblError.Text = "";
            divBotones.Visible = true;
            divEdit.Visible = false;
            divError.Visible = false;
            divConfirma.Visible = false;
            divNuevoConsultorio.Visible = false;
            divConfirmaConsultorio.Visible = false;
            divEditConsultorio.Visible = false;
            divErrorConsultorio.Visible = false;

            updfiltro.Update();
            pnlResultados.Update();
        }

        private DataTable getConsultorios(ConConsultorioTipo tipo) {
            return new Select().From(Schemas.ConConsultorio)
                               .Where(ConConsultorio.Columns.IdTipoConsultorio)
                               .IsEqualTo(tipo.IdTipoConsultorio).OrderAsc("nombre")
                               .ExecuteDataSet().Tables[0];
        }       

        protected void gvTipos_PageIndexChanged(object sender, EventArgs e) {

        }

        protected void cmdEliminar_Click(object sender, EventArgs e) {                       
                int idTipoConsultorio = Convert.ToInt32(gvTipos.DataKeys[gvTipos.SelectedIndex].Value);
                if (tieneConsultorios(idTipoConsultorio)) {
                    inpConfirma.Value = "";
                    lblConfirma.Text = "";
                    lblError.Text = "Imposible eliminar: el tipo de consultorio seleccionado contiene consultorios asociados";
                    divEdit.Visible = false;
                    divBotones.Visible = true;
                    divError.Visible = true;
                    divConfirma.Visible = false;
                    divNuevoConsultorio.Visible = false;
                } else {
                    inpConfirma.Value = "3";
                    lblConfirma.Text = "¿Seguro desea eliminar el tipo de consultorio?";
                    lblError.Text = "";
                    divEdit.Visible = false;
                    divBotones.Visible = false;
                    divError.Visible = false;
                    divConfirma.Visible = true;
                    divNuevoConsultorio.Visible = false;
                    updfiltro.Update();
                }            
        }

        private bool tieneConsultorios(int idTipoConsultorio) {
            ConConsultorioTipo tipo = new ConConsultorioTipo(idTipoConsultorio);
            DataTable consultorios = getConsultorios(tipo);

            return (consultorios.Rows.Count > 0) ? true : false;
        }

        protected void cmdGrabar_Click(object sender, EventArgs e) {            
                string texto = txtEdit.Text;
                if (texto != string.Empty) {
                    lblError.Text = "";
                    divError.Visible = false;
                    grabarTipoConsultorio();
                    updfiltro.Update();
                } else {
                    lblError.Text = "No ha indicado el nombre del tipo de consultorio";
                    divError.Visible = true;
                    updfiltro.Update();
                }           
        }

        private void grabarTipoConsultorio() {
            int accion = Convert.ToInt32(inpConfirma.Value);
            ConConsultorioTipo t;

            if (accion == 2) {
                t = new ConConsultorioTipo(); 
            } else {
                int idTipoConsultorio = Convert.ToInt32(gvTipos.DataKeys[gvTipos.SelectedIndex].Value);
                t = new ConConsultorioTipo(idTipoConsultorio); 
            }

            t.Nombre = txtEdit.Text;
            t.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
            t.Save();

            divEdit.Visible = false;
            divError.Visible = false;
            divNuevoConsultorio.Visible = false;
            llenarTipos();
        }

        protected void cmdCancelar_Click(object sender, EventArgs e) {
            inpConfirma.Value = "";
            lblConfirma.Text = "";
            lblError.Text = "";
            divEdit.Visible = false;
            divBotones.Visible = true ;
            divError.Visible = false;
            divConfirma.Visible = false;
            divNuevoConsultorio.Visible = false;
            updfiltro.Update();   
        }

        protected void cmdNuevoTipo_Click(object sender, EventArgs e) {
            inpConfirma.Value = "2";
            lblConfirma.Text = ""; 
            lblError.Text = "";
            lblEdit.Text = "Nombre para nuevo tipo:";
            txtEdit.Text = "";
            divEdit.Visible = true;
            divBotones.Visible = true;
            divError.Visible = false;
            divConfirma.Visible = false;
            divNuevoConsultorio.Visible = false;
            updfiltro.Update();
            txtEdit.Focus();
        }

        protected void cmdRenombrar_Click(object sender, EventArgs e) {
            inpConfirma.Value = "3";
            lblConfirma.Text = "";
            lblError.Text = "";
            lblEdit.Text = "Indique nuevo nombre de tipo seleccionado:";
            txtEdit.Text = gvTipos.SelectedRow.Cells[1].Text;
            divEdit.Visible = true;
            divBotones.Visible = true;
            divError.Visible = false;
            divConfirma.Visible = false;
            divNuevoConsultorio.Visible = false;
            updfiltro.Update();
            txtEdit.Focus();
        }

        protected void cmdSi_Click(object sender, EventArgs e) {            
                int idTipoConsultorio = Convert.ToInt32(gvTipos.DataKeys[gvTipos.SelectedIndex].Value);
                if (!tieneConsultorios(idTipoConsultorio)) {
                    int accion = Convert.ToInt32(inpConfirma.Value);
                    if (accion == 3) { 
                        eliminarTipoConsultorio(idTipoConsultorio);
                        llenarTipos();
                        divBotones.Visible = true;
                        divConfirma.Visible = false;
                        divEdit.Visible = false;
                        divError.Visible = false;
                        divNuevoConsultorio.Visible = false;
                        updfiltro.Update();
                    }
                } else {
                    inpConfirma.Value = "";
                    lblConfirma.Text = "";
                    lblError.Text = "Imposible eliminar: el tipo de consultorio seleccionado contiene consultorios asociados";
                    divEdit.Visible = false;
                    divBotones.Visible = true;
                    divError.Visible = true;
                    divConfirma.Visible = false;
                    divNuevoConsultorio.Visible = false;
                }            
        }

        private void eliminarTipoConsultorio(int idTipoConsultorio) {
            Query i = new Query(Schemas.ConConsultorioTipo);
            i.QueryType = QueryType.Delete;
            i.WHERE(ConConsultorioTipo.Columns.IdTipoConsultorio, idTipoConsultorio);
            i.Execute();
        }

        protected void cmdNo_Click(object sender, EventArgs e) {
            inpConfirma.Value = "";
            lblConfirma.Text = "";
            lblError.Text = "";
            lblEdit.Text = "";
            txtEdit.Text = "";
            divEdit.Visible = false;
            divBotones.Visible = true;
            divError.Visible = false;
            divConfirma.Visible = false;
            divNuevoConsultorio.Visible = false;
            updfiltro.Update();
            txtEdit.Focus();
        }

        protected void gvConsultorios_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                ImageButton cmdRenombrar = (ImageButton)e.Row.Cells[0].FindControl("cmdRenombrar");
                ImageButton cmdActivar = (ImageButton)e.Row.Cells[0].FindControl("cmdActivar");
                ImageButton cmdEliminar = (ImageButton)e.Row.Cells[0].FindControl("cmdEliminar");

                cmdRenombrar.CommandArgument = gvConsultorios.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdRenombrar.CommandName = "cmdRenombrar";
                cmdActivar.CommandArgument = gvConsultorios.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdActivar.CommandName = "cmdActivar";
                cmdEliminar.CommandArgument = gvConsultorios.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdEliminar.CommandName = "cmdEliminar";

                int idConsultorio = Convert.ToInt32(gvConsultorios.DataKeys[e.Row.RowIndex].Value);
                ConConsultorio c = new ConConsultorio(idConsultorio);

                string imgActivar = "~/App_Themes/consultorio/Agenda/check_verde16.png";
                string imgDesActivar = "~/App_Themes/consultorio/Agenda/de-alerta-de-mensaje-icono-8710-16.png";
                cmdActivar.ToolTip = (c.Activo) ? "Desactivar consultorio (estado activo)" : "Activar consultorio (estado inactivo)";
                cmdActivar.ImageUrl = (c.Activo) ? imgActivar : imgDesActivar;                
            }
        }

        protected void gvConsultorios_RowCommand(object sender, GridViewCommandEventArgs e) {
            
                int idConsultorio = Convert.ToInt32(e.CommandArgument); inpIdConsultorio.Value = e.CommandArgument.ToString(); 
                switch (e.CommandName) {
                    case "cmdEliminar":
                       
                        divConfirmaConsultorio.Visible = true;
                        divEditConsultorio.Visible = false;
                        divErrorConsultorio.Visible = false;
                        pnlResultados.Update();
                        break;
                    case "cmdRenombrar":
                        ConConsultorio c = new ConConsultorio(idConsultorio);
                        txtConsultorio.Text = c.Nombre;
                        txtConsultorio.Focus();
                        divConfirmaConsultorio.Visible = false;
                        divEditConsultorio.Visible = true;
                        divErrorConsultorio.Visible = false;
                        pnlResultados.Update();
                        break;
                    case "cmdActivar":
                        activarConsultorio(idConsultorio);
                        seleccionarTipo();
                        break;
                }           
        }

        private void activarConsultorio(int idConsultorio) {
            ConConsultorio c = new ConConsultorio(idConsultorio);
            c.Activo = !c.Activo;
            c.Save();
        }

        protected void gvConsultorios_PageIndexChanged(object sender, EventArgs e) {

        }
         
        protected void cmdNuevoConsultorio_Click(object sender, EventArgs e) {
            inpConfirma.Value = "";
            lblConfirma.Text = "";
            lblError.Text = "";
            lblEdit.Text = "";
            txtEdit.Text = "";
            txtNuevoConsultorio.Text = "";

            divEdit.Visible = false;
            divBotones.Visible = true;
            divError.Visible = false;
            divConfirma.Visible = false;
            divNuevoConsultorio.Visible = true;
            
          //  ddlTipoCons.SelectedIndex = gvTipos.SelectedIndex;

            ConConsultorioTipoCollection ct = new SubSonic.Select()
            .From(Schemas.ConConsultorioTipo)
            .Where(ConConsultorioTipo.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
            .OrderAsc(ConConsultorioTipo.Columns.Nombre)
            .ExecuteAsCollection<ConConsultorioTipoCollection>();
            ddlTipoConsultorio.DataSource = ct;
            ddlTipoConsultorio.DataValueField = ConConsultorioTipo.Columns.IdTipoConsultorio;
            ddlTipoConsultorio.DataTextField = ConConsultorioTipo.Columns.Nombre;
            ddlTipoConsultorio.DataBind();
            ddlTipoConsultorio.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            
            updfiltro.Update();
            txtNuevoConsultorio.Focus();
        }

        protected void cmdGrabarCons_Click(object sender, EventArgs e) {
                string texto = txtNuevoConsultorio.Text;
                if (texto != string.Empty) {

                    int idTipoConsultorio = Convert.ToInt32(ddlTipoConsultorio.SelectedValue);
                    if(!existeConsultorio(idTipoConsultorio, texto)) {
                        lblError.Text = "";
                        divError.Visible = false;
                        grabarNuevoConsultorio(idTipoConsultorio);
                        seleccionarTipo();
                        updfiltro.Update();
                    } else {
                        lblError.Text = "El nombre del consultorio '" + texto + 
                                        "' ya existe para el tipo de consultorios especificado";
                        divError.Visible = true;
                        updfiltro.Update();
                    }
                } else {
                    lblError.Text = "No ha indicado el nombre del nuevo consultorio";
                    divError.Visible = true;
                    updfiltro.Update();
                }           
        }

        private bool existeConsultorio(int idTipoConsultorio, string texto) {
            int rc = new Select().From(Schemas.ConConsultorio)
                                 .Where(ConConsultorio.Columns.IdTipoConsultorio)
                                 .IsEqualTo(idTipoConsultorio)
                                 .And(ConConsultorio.Columns.Nombre)
                                 .Like(texto).GetRecordCount();
            return (rc > 0) ? true : false;
        }

        private void grabarNuevoConsultorio(int idTipoConsultorio) {
            ConConsultorio c = new ConConsultorio();
            
            c.IdTipoConsultorio = idTipoConsultorio;
            c.Nombre = txtNuevoConsultorio.Text;
            c.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
            //c.IdTipoConsultorio = 110;
            c.Activo = true;
            c.Save();
        }

        protected void cmdNoConsultorio_Click(object sender, EventArgs e) {
            divConfirmaConsultorio.Visible = false;
            divEditConsultorio.Visible = false;
            divErrorConsultorio.Visible = false;
            pnlResultados.Update();
        }

        protected void cmdSiConsultorio_Click(object sender, EventArgs e) {           
                int idConsultorio = Convert.ToInt32(inpIdConsultorio.Value);
                tratarEliminar(idConsultorio);            
        }

        private void tratarEliminar(int idConsultorio) {
            try {
                Query i = new Query(Schemas.ConConsultorio);
                i.QueryType = QueryType.Delete;
                i.WHERE(ConConsultorio.Columns.IdConsultorio, idConsultorio);
                i.Execute();
                seleccionarTipo();
            } catch {
                lblErrorConsultorio.Text = "El consultorio contiene movimientos asociados. Imposible eliminarlo.";
                divConfirmaConsultorio.Visible = false;
                divErrorConsultorio.Visible = true;
            }
        }

        protected void cmdGrabarConsultorio_Click(object sender, EventArgs e) {
            
                int idConsultorio = Convert.ToInt32(inpIdConsultorio.Value);
                ConConsultorio c = new ConConsultorio(idConsultorio);
                string texto = txtConsultorio.Text;
                
                if (!existeConsultorio(c.IdTipoConsultorio, c.IdConsultorio, texto)) {
                    grabarConsultorio(idConsultorio, texto);

                    divErrorConsultorio.Visible = false;
                    divConfirmaConsultorio.Visible = false;
                    divEditConsultorio.Visible=false;
                    seleccionarTipo();
                } else {
                    divErrorConsultorio.Visible = true;
                    lblErrorConsultorio.Text = "El nombre especificado ya está en uso por otro consultorio";
                }
            
        }

        private void grabarConsultorio(int idConsultorio, string texto) {
            ConConsultorio c = new ConConsultorio(idConsultorio);
            c.Nombre = texto;
            c.Save();
        }

        private bool existeConsultorio(int idTipoConsultorio, int idConsultorio, string texto) {
            int rc = new Select().From(Schemas.ConConsultorio)
                                 .Where(ConConsultorio.Columns.IdTipoConsultorio)
                                 .IsEqualTo(idTipoConsultorio)
                                 .And(ConConsultorio.Columns.Nombre).Like(texto)
                                 .And(ConConsultorio.Columns.IdConsultorio).IsNotEqualTo(idConsultorio)
                                 .GetRecordCount();
            return (rc > 0) ? true : false;
        } 
    }
}
