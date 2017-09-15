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
using Salud.Security.SSO;

namespace Consultorio.Turnos
{
    public partial class TurnoNuevoDefault : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {                
                txtDni.Focus();                                
            }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;
                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }
            return newSortDirection;
        }

        protected void gvPacientes_PageIndexChangind(object sender, GridViewPageEventArgs e)
        {
            btnBuscar_Click(null, null);
            gvPacientes.PageIndex = e.NewPageIndex;
            gvPacientes.DataBind();
        }

        protected void gvPersonas_PageIndexChangind(object sender, GridViewPageEventArgs e)
        {
            btnBuscar_Click(null, null);
        }

        protected void gvPadronPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            btnBuscar_Click(null, null);
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = gvPacientes.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvPacientes.DataSource = dataView;
                gvPacientes.DataBind();
            }
        }

        /// <summary>
        /// Sil el tipo de efector es un hospital se oculta la columna "Turno de 2do Nivel", ya que solo es posible sacar un turno de 2do nivel
        /// cuando es un Centro de Salud, Puesto Sanitario, etc.
        /// </summary>
        private void ocultarTurnoSegundoNivel()
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            if (efector.IdTipoEfector == 2)
            {
                gvPacientes.Columns[10].Visible = false;//turno segundo nivel
                gvPacientes.Columns[11].Visible = false;//turno en otros centros
            }
            else
            {
                gvPacientes.Columns[10].Visible = true;
                gvPacientes.Columns[11].Visible = true;
            }

              if (Request["idTurnoAcompaniante"] != null)
              {   gvPacientes.Columns[10].Visible = false;//turno segundo nivel
                gvPacientes.Columns[11].Visible = false;//turno en otros centros
              }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ocultarTurnoSegundoNivel();

            SubSonic.Select s = new SubSonic.Select();
            s.From(SysPaciente.Schema);

            int nrodoc = 0;
            int dniMadre = int.Parse(txtDniMadre.Text == "" ? "0" : txtDniMadre.Text);

            if ((txtDni.Text.Trim() == "") && (txtApellidoBusqueda.Text.Trim() == "") && (txtNombreBusqueda.Text.Trim() == "") && (txtNombreMadreBusqueda.Text.Trim() == "") && (txtApellidoMadreBusqueda.Text.Trim() == "") && (dniMadre.ToString().Trim() == ""))
                lblMensajeBusqueda.Text = "Debe ingresar al menos un filtro de búsqueda";
            else
            {
                /*if (dniMadre.ToString() == "") {
                    dniMadre = ;
                }*/

                //busqueda por documento
                if (txtDni.Text.Length > 0)
                {
                    nrodoc = Convert.ToInt32(txtDni.Text);

                    //llenado de la grilla
                    gvPacientes.DataSource = SPs.GetPacientesPorDocumento(nrodoc).GetDataSet();
                    gvPacientes.DataBind();

                    return;
                }

                //busqueda por fecha de nacimiento
                DateTime fnac;
                DateTime? fnac2 = null;

                gvPacientes.DataSource = SPs.GetPacientesPorNombres(fnac2, txtNombreBusqueda.Text.Trim(), txtApellidoBusqueda.Text.Trim(), dniMadre, txtNombreMadreBusqueda.Text.Trim(), txtApellidoMadreBusqueda.Text.Trim()).GetDataSet();
                gvPacientes.DataBind();
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim().Length > 0)
                Response.Redirect("~/Paciente/PacienteEdit.aspx?dni=" + txtDni.Text.Trim() + "&llamada=Consultorio", false);
            else
            {
                if (Request["idTurnoAcompaniante"] == null)            
                    Response.Redirect("~/Paciente/PacienteEdit.aspx?idPaciente=0&llamada=Consultorio", false);
                else
                    Response.Redirect("~/Paciente/PacienteEdit.aspx?idPaciente=0", false);
            }
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton CmdTurno = (LinkButton)e.Row.Cells[9].Controls[1];
                CmdTurno.CommandArgument = this.gvPacientes.DataKeys[e.Row.RowIndex].Value.ToString();
                CmdTurno.CommandName = "Turno";
                CmdTurno.ToolTip = "Turno";

                LinkButton CmdTurnoInterconsulta = (LinkButton)e.Row.Cells[10].Controls[1];
                CmdTurnoInterconsulta.CommandArgument = this.gvPacientes.DataKeys[e.Row.RowIndex].Value.ToString();
                CmdTurnoInterconsulta.CommandName = "Turno Interconsulta";
                CmdTurnoInterconsulta.ToolTip = "Turno Interconsulta";

                LinkButton CmdTurnoCentroSalud = (LinkButton)e.Row.Cells[11].Controls[1];
                CmdTurnoCentroSalud.CommandArgument = this.gvPacientes.DataKeys[e.Row.RowIndex].Value.ToString();
                CmdTurnoCentroSalud.CommandName = "Turno Centro Salud";
                CmdTurnoCentroSalud.ToolTip = "Turno Centro Salud";

                switch (DataBinder.Eval(e.Row.DataItem, "estado").ToString())
                {
                    case "Identificado":
                        e.Row.BackColor = System.Drawing.Color.LightBlue;
                        e.Row.ToolTip = "Pacientes Identificados";
                        break;
                    case "Temporal":
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;
                        e.Row.ToolTip = "Pacientes Temporales";
                        break;
                    case "Validado":
                        e.Row.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        e.Row.ToolTip = "Pacientes Validados";
                        break;
                    case "Inactivo":
                        e.Row.BackColor = System.Drawing.Color.Azure;
                        e.Row.ToolTip = "Pacientes Inactivos";
                        break;
                    default: e.Row.BackColor = System.Drawing.Color.White;
                        break;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void verificarSiEfectorDelUsuarioEsDependienteDelHeller(string idPaciente)
        {
            // ,nota: Verifico que el efector del paciente sea dependiente del H. Heller

            DataTable dtEfectorSuperior = new DataTable();
            dtEfectorSuperior = SPs.TupObtenerIdEfectorSuperior(SSOHelper.CurrentIdentity.IdEfector).GetDataSet().Tables[0];

            if (dtEfectorSuperior.Rows[0][2].ToString() == "221") // id del H. Heller
            {
                verificarSiTieneInterconsultaHabilitada(idPaciente);
            }
            else
            {
                Response.Write("<script language=javascript>alert('Su efector no es dependiente del H. Heller. Por tal motivo no se puede gestionar el turno protegido.');</script>");            
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void verificarSiTieneInterconsultaHabilitada(string idPaciente)
        {
            // ,nota: Verifico que el paciente tenga una interconsulta abierta, caso contrario no permito que se saque el turno protegido.

            SysPaciente oPaciente = new SysPaciente(int.Parse(idPaciente));

            DataTable registroInterconsultaAbierta = new DataTable();
            registroInterconsultaAbierta = SPs.TupVerificarSiExisteInterconsultaAbierta(oPaciente.IdPaciente).GetDataSet().Tables[0];

            if (registroInterconsultaAbierta.Rows.Count != 0) // Existe al menos una interconsulta abierta para el paciente
            {
                string url = "TurnosProtegidos/seleccionarInterconsulta.aspx?idPaciente=" + int.Parse(idPaciente).ToString().Trim();
                Response.Redirect(url, false);
            }
            else
            {
                Response.Write("<script language=javascript>alert('El paciente seleccionado no posee una interconsulta abierta, por lo tanto no se puede asignar un turno protegido.');</script>");                      
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Turno":
                    if (Request["idTurnoAcompaniante"] != null)
                        {
                            generarNuevoTurnoAcompaniante(int.Parse(Request["idTurnoAcompaniante"].ToString()), e.CommandArgument.ToString());

                        }
                        else
                        {
                            Response.Redirect("TurnoNuevo.aspx?idPaciente=" + e.CommandArgument.ToString());
                        }

                    break;

                case "Turno Interconsulta":
                    {
                        //if (PacienteEsClasificado(e.CommandArgument.ToString()))
                        //    Response.Redirect("TurnoNuevo.aspx?idPaciente=" + e.CommandArgument.ToString() + "&Interconsulta=0");
                        //else
                        //{
                        //    string popupScript = "<script language='JavaScript'> alert('Los turnos de segundo nivel estan reservados para pacientes Clasificados con Riesgo Cardiovascular. Verifique que el paciente haya sido clasificado.')</script>";
                        //    Page.RegisterClientScriptBlock("PopupScript", popupScript);                            
                        //}

                        // ******************************************************************************************
                        // ******************************************************************************************
                        // Por el momento lo comentamos. Para hacer pruebas !
                        // ******************************************************************************************
                        // ******************************************************************************************
                        //verificarSiEfectorDelUsuarioEsDependienteDelHeller(e.CommandArgument.ToString());
                        // ******************************************************************************************
                        // ******************************************************************************************

                        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                        // Por el momento habilito esta línea para hacer pruebas en el 15 (25-02-2015). Dani.
                        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                        verificarSiTieneInterconsultaHabilitada(e.CommandArgument.ToString());

                        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                    }
                    break;

                case  "Turno Centro Salud":
                    Response.Redirect("TurnoNuevoSinEfector.aspx?idPaciente=" + e.CommandArgument.ToString());
                    break;
            }
        }

        private void generarNuevoTurnoAcompaniante(int p1, string p2)
        {
           //instancio el turno del paciente principal
            ConTurno t = new ConTurno(p1);
            //creo un nuevo turno  
            ConTurno tnuevo = new ConTurno();
            tnuevo.IdAgenda = t.IdAgenda;
            tnuevo.IdObraSocial = t.IdObraSocial;
            tnuevo.IdPaciente =int.Parse( p2);
            tnuevo.IdTipoTurno = t.IdTipoTurno;
            tnuevo.Fecha = t.Fecha;
            tnuevo.Hora = t.Hora;
            tnuevo.IdTurnoEstado = 1; // t.IdTurnoEstado;
            tnuevo.IdUsuario = SSOHelper.CurrentIdentity.Id;
            tnuevo.IdTurnoAcompaniante = p1;
            
            tnuevo.Save();


            grabarAuditoriaTurno(tnuevo);


            ConTurnoAsistencium asist = new ConTurnoAsistencium();
            asist.IdTurno = tnuevo.IdTurno;
            asist.FechaAsistencia = DateTime.Now;
            asist.IdUsuario = SSOHelper.CurrentIdentity.Id;
            asist.Save();

            string s_pagina=Request["desde"].ToString();
            Response.Redirect(s_pagina+"?idAgenda=" +t.IdAgenda.ToString()+ "&idTurno="+p1.ToString()  , false);
            

        }
        private void grabarAuditoriaTurno(ConTurno turno)
        {
            string h = Convert.ToString(DateTime.Now.Hour);
            string m = Convert.ToString(DateTime.Now.Minute);
            if (h.Length < 2) { h = "0" + h; }
            if (m.Length < 2) { m = "0" + m; }
            string hora = h + ":" + m;

            ConTurnoAuditorium aud = new ConTurnoAuditorium();
            aud.IdTurno = turno.IdTurno;
            aud.IdPaciente = turno.IdPaciente;
            aud.IdTurnoEstado = turno.IdTurnoEstado;
            aud.IdUsuario = SSOHelper.CurrentIdentity.Id;
            aud.IdServicio = turno.ConAgenda.IdServicio;
            aud.IdProfesional = turno.ConAgenda.IdProfesional;
            aud.IdEspecialidad = turno.ConAgenda.IdEspecialidad;
            aud.IdConsultorio = turno.ConAgenda.IdConsultorio;
            aud.Fecha = turno.Fecha;
            aud.Hora = turno.Hora;
            aud.FechaModificacion = System.DateTime.Now;
            aud.HoraModificacion = hora;
            aud.Save();
        }
        private bool PacienteEsClasificado(string p)
        {

            RemClasificacionCollection srv = new SubSonic.Select()
            .From(Schemas.RemClasificacion)
                      .Where(RemClasificacion.Columns.IdPaciente).IsEqualTo(p)
                      .And(RemClasificacion.Columns.RiesgoCardiovascular).IsGreaterThan(1)////Riesgo cardiovascular mayor a 10 

             .ExecuteAsCollection<RemClasificacionCollection>();

            if (srv.Count > 0)
                return true;
            else
                return false;
        }
    }
}