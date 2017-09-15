using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using DalSic;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using Salud.Security.SSO;
using SubSonic;

namespace Consultorio.Turnos.TurnosProtegidos
{
    public partial class seleccionarInterconsulta : System.Web.UI.Page
    {
        // -----------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SysPaciente oPaciente = new SysPaciente(int.Parse(Request["idPaciente"].ToString()));
                lblDatosPaciente.Text = "Documento: " + oPaciente.NumeroDocumento + " Nombre: " + oPaciente.Apellido.Trim() + ", " + oPaciente.Nombre.Trim()  + " Fch. Nac.: " + oPaciente.FechaNacimiento.ToShortDateString().Trim();

                cargarLista();
            }            
        }

        // -----------------------------------------------------------------------------------------------------------------
        private void cargarLista()
        {
            // ------------------------
            // Tabla Fuente
            // ------------------------
            DataTable dtAux = null;
            dtAux = new DataTable();
            dtAux = SPs.TupCargarListaDeInterconsultas(int.Parse(Request["idPaciente"].ToString())).GetDataSet().Tables[0];

            // ------------------------
            // Tabla Destino
            // ------------------------
            DataTable dtInterconsultasDelPaciente = null;

            dtInterconsultasDelPaciente = new DataTable();
            dtInterconsultasDelPaciente.Columns.Add("idInterconsulta", typeof(int));
            dtInterconsultasDelPaciente.Columns.Add("idPacinte", typeof(int));
            dtInterconsultasDelPaciente.Columns.Add("fechaSolicitud", typeof(string));
            dtInterconsultasDelPaciente.Columns.Add("medicosDestinatarios", typeof(string));

            // ------------------------
            // Proceso las tablas ...
            // ------------------------

            int i;
            string registroModificado;

            if (dtAux.Rows.Count != 0)
            {

                i = 0;
                registroModificado = "NO";

                // Primer línea ...
                DataRow workRowPrimera = dtInterconsultasDelPaciente.NewRow();
                workRowPrimera[0] = int.Parse(dtAux.Rows[0][0].ToString());
                workRowPrimera[1] = int.Parse(dtAux.Rows[0][2].ToString());
                workRowPrimera[2] = dtAux.Rows[0][1].ToString();
                workRowPrimera[3] = ""; // para que no se duplique el string
                dtInterconsultasDelPaciente.Rows.Add(workRowPrimera);

                foreach (DataRow drFuente in dtAux.Rows)
                {
                    // Busco el id en la tabla destino. Si existe concateno. Si no existe creo una nueva fila.
                    registroModificado = "NO";
                    int cantidadDeRegistros = dtInterconsultasDelPaciente.Rows.Count;

                    for (int j=0; j<cantidadDeRegistros; j++)
                    {
                        if (dtAux.Rows[i][0].ToString() == dtInterconsultasDelPaciente.Rows[j][0].ToString())
                        {
                            dtInterconsultasDelPaciente.Rows[j][3] = dtInterconsultasDelPaciente.Rows[j][3] + dtAux.Rows[i][7].ToString() + " (" + dtAux.Rows[i][9].ToString() + ", " + dtAux.Rows[i][11].ToString() + "). ";
                            registroModificado = "SI";
                        }
                    }

                    // Creo una nueva fila ...
                    if (registroModificado == "NO")
                    {
                        DataRow workRow = dtInterconsultasDelPaciente.NewRow();
                        workRow[0] = int.Parse(dtAux.Rows[i][0].ToString());
                        workRow[1] = int.Parse(dtAux.Rows[i][2].ToString());
                        workRow[2] = dtAux.Rows[i][1].ToString();
                        workRow[3] = dtAux.Rows[i][7].ToString() + " (" + dtAux.Rows[i][9].ToString() + ", " + dtAux.Rows[i][11].ToString() + "). ";
                        dtInterconsultasDelPaciente.Rows.Add(workRow);
                    }                        
                
                    i = i + 1;
                }
            }

            gvListaInterconsultasDelPaciente.DataSource = dtInterconsultasDelPaciente;
            gvListaInterconsultasDelPaciente.DataBind();
        }

        // -----------------------------------------------------------------------------------------------------------------

        protected void gvListaInterconsultasDelPaciente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "seleccionarInterconsulta":

                    Session["turnosProtegidos_interconsultaId"] = e.CommandArgument.ToString();

                    string url = "buscarAgenda.aspx?idPaciente=" + int.Parse(Request["idPaciente"].ToString());
                    Response.Redirect(url, false);
                    break;
            }

        }

        // -----------------------------------------------------------------------------------------------------------------
        
        protected void gvListaInterconsultasDelPaciente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton CmdSeleccionarInterconsulta = (ImageButton)e.Row.Cells[1].Controls[1];
                CmdSeleccionarInterconsulta.CommandArgument = this.gvListaInterconsultasDelPaciente.DataKeys[e.Row.RowIndex].Value.ToString();
                CmdSeleccionarInterconsulta.CommandName = "seleccionarInterconsulta";
                CmdSeleccionarInterconsulta.ToolTip = "Seleccionar interconsulta";
            }
        }

        // -----------------------------------------------------------------------------------------------------------------

        protected void gvListaInterconsultasDelPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvListaInterconsultasDelPaciente.PageIndex = e.NewPageIndex;
            cargarLista();
        }

        // -----------------------------------------------------------------------------------------------------------------

        public int calcularEdad(DateTime fechaInicio, DateTime fechaFin)
        {
            //Obtengo la diferencia en años.
            int edad = fechaFin.Year - fechaInicio.Year;

            //Obtengo la fecha de cumpleaños de este año.
            DateTime nacimientoAhora = fechaInicio.AddYears(edad);

            return edad;
        }

        // -----------------------------------------------------------------------------------------------------------------
    }
}