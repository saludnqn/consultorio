using DalSic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultorio.Turnos
{
    public partial class ATerapeuticoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                if (Request["idTurno"] != null)
                {
                    int idTurno = Convert.ToInt32(Request.QueryString["idTurno"]);
                    if (idTurno > 0) mostrarTurno(idTurno);
                }
            }
        }
        private void mostrarTurno(int idTurno)
        {
            ConTurno t = new ConTurno(idTurno);
            lblPaciente.Text = t.SysPaciente.NumeroDocumento.ToString() + " " + t.SysPaciente.Apellido + " " + t.SysPaciente.Nombre;          

            actualizarTurnosAcompaniantes(idTurno);

        }

        private void actualizarTurnosAcompaniantes(int idTurno)
        {
            DataTable dt = getTurnoscompaniantes(idTurno);
            gvTurnosAcompaniante.DataSource = dt;
            gvTurnosAcompaniante.DataBind();
            
        }
        private DataTable getTurnoscompaniantes(int idTurnoAcompaniante)
        {
            DataTable dt = SPs.ConTurnosAcompaniante(idTurnoAcompaniante).GetDataSet().Tables[0];

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                int idTurno = Convert.ToInt32(dt.Rows[i]["idTurno"]);
                int idTurnoEstado = Convert.ToInt32(dt.Rows[i]["idTurnoEstado"]);

                /// si el estado es reservado chequeo caducidad de reserva
                if (idTurno > 0 & idTurnoEstado == 2)
                {
                    ConTurno t = new ConTurno(idTurno);
                    ConTurnoReserva res = t.ConTurnoReservaRecords.Last<ConTurnoReserva>();

                    DateTime fcaducidad = res.ReservaHasta;
                    if (fcaducidad <= DateTime.Now)
                    {
                        /// venció reserva
                        res.CofirmoTurno = false;
                        res.Save();

                        /// en forma lógica omito leer el paciente que reservaba el turno (luego se pisan los datos del paciente)
                        dt.Rows[i]["idPaciente"] = 0;
                        dt.Rows[i]["idTurnoEstado"] = 1;
                        dt.Rows[i]["Estado"] = "Activo";
                        dt.Rows[i]["DNI"] = "0";
                        dt.Rows[i]["HC"] = "0";
                        dt.Rows[i]["Paciente"] = "";
                        dt.AcceptChanges();
                    }
                }
            }
            return dt;
        }
        private bool tienediagnostico(ConTurno t)
        {

            ConConsultumCollection srv = new SubSonic.Select()
               .From(Schemas.ConConsultum)
                         .Where(ConConsultum.Columns.IdTurno).IsEqualTo(t.IdTurno)

                .ExecuteAsCollection<ConConsultumCollection>();

            if (srv.Count > 0) return true;
            else return false;

        }

        protected void gvTurnosAcompaniante_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                //LinkButton cmdEditar = (LinkButton)e.Row.FindControl("cmdSelTurno0");
                //cmdEditar.CommandArgument = gvTurnosAcompaniante.DataKeys[e.Row.RowIndex].Value.ToString();
                //cmdEditar.CommandName = "Editar";
                //cmdEditar.ToolTip = "Editar";

                ImageButton cmdEliminar = (ImageButton)e.Row.FindControl("cmdEliminarTurno0");
                cmdEliminar.CommandArgument = gvTurnosAcompaniante.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdEliminar.CommandName = "Eliminar";
                cmdEliminar.ToolTip = "Eliminar";



                //ImageButton cmdSelTurno = (ImageButton)e.Row.FindControl("cmdSelTurno");
                Image imgTurno = (Image)e.Row.FindControl("imgTurno0");
                //   Image imgConsulta = (Image)e.Row.FindControl("imgConsulta");
                //string Estado = dtGrilla.Rows[e.Row.RowIndex]["Estado"].ToString();
                string Consulta = e.Row.Cells[5].Text;// e.Rows[e.Row.RowIndex]["Consulta"].ToString();
                //string Asistencia = dtGrilla.Rows[e.Row.RowIndex]["Asistencia"].ToString();


                //contenedorSaludMental.Height = "1000px";
                //demanda.Visible = false;
                //nivelDeAbordaje.Visible =false;
                //tiempoInsumido.Visible = false;
                //tipoPrestacion.Visible = false;
                //recursoHumano.Visible = false;
                //lblPacienteAcompaniante.Visible = true;
                //btnAgregarAcompañante.Visible = false;

                //if ((Asistencia == "1") && (Consulta == "No"))
                //{
                //    for (int i = 0; i < gvTurnos.Columns.Count; i++)
                //    {
                //        e.Row.Cells[i].BackColor = System.Drawing.Color.LightYellow;
                //    }

                //    cmdSelTurno.Visible = true;
                //}
                //else
                if (Consulta == "Si")
                {
                    for (int i = 0; i < gvTurnosAcompaniante.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Gainsboro;
                    }
                    //         cmdSelTurno.Visible = true;
                }
                else
                {
                    for (int i = 0; i < gvTurnosAcompaniante.Columns.Count; i++)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.White;
                    }
                    //cmdSelTurno.Visible = false;
                }

                //switch (Estado)
                //{
                //    case "Activo":
                //        {
                //            string tipoTurno = dtGrilla.Rows[e.Row.RowIndex]["TipoTurno"].ToString();
                //            switch (tipoTurno)
                //            {
                //                case "":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnoactivo.png";
                //                    imgTurno.ToolTip = "Turno activo";
                //                    break;
                //                case "Turno":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/check_verde16.png";
                //                    imgTurno.ToolTip = "Turno del día";
                //                    break;
                //                case "Programado":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta1.png";
                //                    imgTurno.ToolTip = "Turno Anticipado";
                //                    break;
                //                case "SobreTurno":
                //                    imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/alerta.png";
                //                    imgTurno.ToolTip = "Sobre Turno";
                //                    break;
                //            }
                //        } break;
                //    case "Bloqueado":
                //        {
                //            imgTurno.ImageUrl = "~/App_Themes/consultorio/Agenda/turnobloqueado.png";
                //            imgTurno.ToolTip = "Turno bloqueado";
                //        } break;
                //}


            }
        }
        protected void gvTurnosAcompaniante_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Editar")
            //{
            //    ConTurno t = new ConTurno(int.Parse(e.CommandArgument.ToString()));
            //    Response.Redirect("DiagnosticoEdit.aspx?idAgenda=" + t.IdAgenda.ToString() + "&idTurno=" + t.IdTurno.ToString(), false);

            //}

            if (e.CommandName == "Eliminar")
            {
                ///Verificar si no tiene diagnostico cargado

                ConTurno t = new ConTurno(int.Parse(e.CommandArgument.ToString()));
                if (!tienediagnostico(t))
                {
                    t.IdTurnoEstado = 4;
                    t.Save();
                    actualizarTurnosAcompaniantes(t.IdTurno);
                }
                string popupScript = "<script language='JavaScript'> alert('No es posible eliminar. El paciente tiene diagnnosticos cargados'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }
    }
}