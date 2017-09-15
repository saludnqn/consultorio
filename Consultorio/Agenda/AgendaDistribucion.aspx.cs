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
using System.Text.RegularExpressions;

namespace Consultorio.Agenda
{
    public partial class AgendaDistribucion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int idTipoConsultorio = 0;
            DateTime fechaConsulta = DateTime.MinValue;

            if (!IsPostBack)
            {
                llenarCombos();

                idTipoConsultorio = Convert.ToInt32(Request.QueryString["idTipoConsultorio"]);
                fechaConsulta = Convert.ToDateTime(Request.QueryString["fechaConsulta"]);
                txtFecha.Text = (fechaConsulta > DateTime.MinValue)
                        ? fechaConsulta.ToString().Substring(0, 10)
                        : DateTime.Now.ToString().Substring(0, 10);

                if (idTipoConsultorio > 0)
                {
                    ddlTipoCons.SelectedValue = Convert.ToString(idTipoConsultorio);
                    ddlHini.SelectedIndex = 8;
                    ddlHfin.SelectedIndex = 23;
                    lblMsg.Text = "";
                    divMsg.Visible = false;
                    actualizarVista();
                }
                MostrarGrilla();
            }
        }

        private void llenarCombos()
        {
            ConConsultorioTipoCollection ct = new SubSonic.Select()
                .From(Schemas.ConConsultorioTipo)
                .Where(ConConsultorioTipo.Columns.IdEfector).IsEqualTo(SSOHelper.CurrentIdentity.IdEfector)
                .OrderAsc(ConConsultorioTipo.Columns.Nombre)
                .ExecuteAsCollection<ConConsultorioTipoCollection>();
            ddlTipoCons.DataSource = ct;
            ddlTipoCons.DataValueField = ConConsultorioTipo.Columns.IdTipoConsultorio;
            ddlTipoCons.DataTextField = ConConsultorioTipo.Columns.Nombre;
            ddlTipoCons.DataBind();

            ddlTipoCons.Items.Insert(0, new ListItem("Todos", "0"));

            string h = string.Empty;
            int n = 0;
            for (int i = 0; i < 24; i++)
            {
                h = i.ToString();
                if (h.Length == 1) { h = "0" + h; }
                h += ":00";
                ddlHini.Items.Insert(n, new ListItem(h));
                ddlHfin.Items.Insert(n, new ListItem(h));
                n++;
            }
            ddlHini.SelectedIndex = 8;
            ddlHfin.SelectedIndex = 23;
        }

        protected void cmdFecha_Click(object sender, ImageClickEventArgs e)
        {
            txtFecha.Focus();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarGrilla();
        }

        private void MostrarGrilla()
        {
            if (txtFecha.Text.Length == 10)
            {
                if (ddlHini.SelectedIndex < ddlHfin.SelectedIndex)
                {
                    lblMsg.Text = "";
                    divMsg.Visible = false;
                    actualizarVista();
                }
                else { showMsg("* La hora inicial debe ser menor a la hora final", true); }
            }
            else { showMsg("* Indique una fecha válida", true); }
            updfiltro.Update();
        }

        private void showMsg(string msg, bool error)
        {
            string strError = "~/App_Themes/consultorio/Agenda/boton-de-error-icono-5371-32.png";
            string strInfo = "~/App_Themes/consultorio/Agenda/informacion-de-mensaje-de-alerta-icono-4460-32.png";

            imgMsg.ImageUrl = (error) ? strError : strInfo;
            imgMsg.AlternateText = (error) ? "error" : "info";
            lblMsg.Text = msg;
            divMsg.Visible = true;
        }

        protected void actualizarVista()
        {

            DataTable dt = getDataTable(SSOHelper.CurrentIdentity.IdEfector);
            StringBuilder st = new StringBuilder();

            try
            {
                st.Append("<table style='width:100%;background:White;font-size: 10pt;	font-family: Calibri;' cellpadding='0' cellspacing='0' >");
                st.Append("<tr>");
                for (int x = 0; x < dt.Columns.Count; x++)
                {
                    st.Append("<td  style='border:solid 1px #2B7EBD;background-color: #CCCCCC;width:10px;background-image:none;cursor:auto;'>");
                    st.Append(dt.Columns[x].ToString());
                    st.Append("</td>");
                }
                st.Append("</tr>");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    st.Append("<tr>");
                    int idConsultorio = Convert.ToInt32(dt.Rows[i][0]);
                    ConConsultorio c = new ConConsultorio(idConsultorio);

                    st.Append("<td  style='border:solid 1px #2B7EBD;background-color: #CCCCCC;width:10px;background-image:none;cursor:auto;'>");
                    string TipoConsultorio = c.ConConsultorioTipo.Nombre;
                    st.Append(c.Nombre + " - " + TipoConsultorio);
                    st.Append("</td>");

                    int nspan = 0;
                    for (int x = 1; x < dt.Columns.Count; x++)
                    {
                        int idAgenda = Convert.ToInt32(dt.Rows[i][x]);

                        if (idAgenda == 0)
                        {
                            st.Append("<td style='border:dashed 1px #CCCCCC;width:10px;color:Transparent;'></td>");
                        }
                        else
                        {
                            if (nspan == 0)
                            {
                                nspan = getColSpan(idAgenda);

                                ConAgenda ag = new ConAgenda(idAgenda);

                                string forecolor = "#000000";
                                string backcolor = "#FFFFFF";
                                if (ag.IdEspecialidad > 0)
                                {
                                    forecolor = ag.SysEspecialidad.ForeColor;
                                    backcolor = ag.SysEspecialidad.BackColor;
                                    if (backcolor == "White")
                                        backcolor = "#CCCCCC";
                                }

                                st.Append("<td colspan='" + nspan.ToString() + "' style='border:solid 1px Black;background-color:"
                                        + backcolor + ";color:" + forecolor + ";'>");

                                string profesional = nombreProfesional(ag);

                                string str = "<span id='lbl" + i.ToString() + x.ToString() + "' " +
                                                 "style='background-color:" + backcolor + ";" +
                                                 "color:" + forecolor + ";" +
                                                 "width:100%;height100%;font-weight:bold;'>" + profesional +
                                " </span><br>";

                                st.Append(str);
                            }
                            else
                            {
                                if (nspan - 1 == 1)
                                {
                                    st.Append("</td>");
                                }
                                nspan -= 1;
                            }
                        }
                    }
                    st.Append("</tr>");
                }
                st.Append("</table>");
                ltrOcupacion.Text = st.ToString();
                divMsg.Visible = false;
            }
            catch
            {
                lblMsg.Text = "Error al generar la grilla de ocupación";
                divMsg.Visible = true;
            }
            updfiltro.Update();
        }

        private string nombreProfesional(ConAgenda agenda)
        {
            string nombre = string.Empty;

            string nombreprofesional = "";

            if (agenda.Multiprofesional == true)
            {
                ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                       .From(Schemas.ConAgendaProfesional).Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(agenda.IdAgenda)
                       .ExecuteAsCollection<ConAgendaProfesionalCollection>();

                foreach (ConAgendaProfesional data in listaAgendaProfesional)
                {
                    nombre = string.Concat(nombre, data.SysProfesional.NombreCompleto);
                    nombre = string.Concat(nombre, "<br>");
                }

                if (nombre.EndsWith("<br>"))
                    nombre = nombre.Substring(0, nombre.Length - 4);
            }
            else
            {
                if (agenda.SysProfesional.Nombre.Length >= 2)
                    nombreprofesional = agenda.SysProfesional.Nombre.Substring(0, 2);

                nombre = (agenda.SysProfesional.IdProfesional != -1 ? agenda.SysProfesional.Apellido + ", " + nombreprofesional : "");
            }

            return nombre;
        }

        private int getColSpan(int idAgenda)
        {
            ConAgenda ag = new ConAgenda(idAgenda);
            DateTime hini = Convert.ToDateTime(ag.Fecha.ToString().Substring(0, 10) + " " + ag.HoraInicio.ToString() + ":00");
            DateTime hfin = Convert.ToDateTime(ag.Fecha.ToString().Substring(0, 10) + " " + ag.HoraFin.ToString() + ":00");

            TimeSpan diff = hfin.AddMinutes(-15) - hini;
            int mins = Convert.ToInt32(diff.TotalMinutes);
            int frecuencia = 15;

            return (mins / frecuencia) + 1;
        }

        private DataTable getDataTable(int idEfector)
        {

            DataTable dtAgendas = new Select().From(ConVistaAgenda.Schema)
                                    .Where(ConVistaAgenda.Columns.Fecha).IsEqualTo(DateTime.Parse(txtFecha.Text))
                                    .And(ConVistaAgenda.Columns.IdAgendaEstado).IsNotEqualTo(3)
                                     .And(ConVistaAgenda.Columns.IdEfector).IsEqualTo(idEfector)

                                    .OrderAsc(ConVistaAgenda.Columns.HoraInicio)
                                    .ExecuteDataSet().Tables[0];

            DataTable dtHoras = getListaHorarios();
            DataTable dtConsultorios = getListaConsultorios(idEfector);
            DataTable dt = new DataTable();

            ////////////////////////////////////////
            ////  GENERACION DE VISTA VERTICAL  ////
            //dt = getColumnas(dt, dtConsultorios);
            //dt = getFilas(dt, dtHoras, dtAgendas);
            //dt = renombrarColumnas(dt);
            ///////////////////////////////////////

            ////////////////////////////////////////
            //// GENERACION DE VISTA HORIZONTAL ////
            dt = generarColumnas(dt, dtHoras);
            dt = generarFilas(dt, dtConsultorios, dtAgendas);
            ////////////////////////////////////////

            return dt;
        }

        private DataTable renombrarColumnas(DataTable dt)
        {
            for (int x = 1; x < dt.Columns.Count; x++)
            {
                int idConsultorio = Convert.ToInt32(dt.Columns[x].ColumnName);
                ConConsultorio c = new ConConsultorio(idConsultorio);
                dt.Columns[x].ColumnName = c.Nombre;
                dt.AcceptChanges();
            }
            return dt;
        }

        private DataTable getColumnas(DataTable dt, DataTable dtConsultorios)
        {
            dt.Columns.Add("Hora");
            for (int i = 0; i < dtConsultorios.Rows.Count; i++)
            {
                dt.Columns.Add(dtConsultorios.Rows[i]["idConsultorio"].ToString());
            }
            return dt;
        }

        private DataTable getFilas(DataTable dt, DataTable dtHoras, DataTable dtAgendas)
        {
            for (int i = 0; i < dtHoras.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                for (int x = 0; x < dt.Columns.Count; x++)
                {
                    int idConsultorio = (x == 0) ? 0 : Convert.ToInt32(dt.Columns[x].ColumnName);
                    string hora = dtHoras.Rows[i]["Hora"].ToString();
                    int idAgenda = (x == 0) ? 0 : getIdAgenda(idConsultorio, hora, dtAgendas);
                    row[x] = (x == 0) ? hora : idAgenda.ToString(); ;

                }
                dt.Rows.Add(row);
            }

            dt.AcceptChanges();
            return dt;
        }

        private DataTable generarFilas(DataTable dt, DataTable dtConsultorios, DataTable dtAgendas)
        {
            for (int i = 0; i < dtConsultorios.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                for (int x = 0; x < dt.Columns.Count; x++)
                {
                    int idConsultorio = Convert.ToInt32(dtConsultorios.Rows[i]["idConsultorio"]);
                    string hora = dt.Columns[x].ColumnName;
                    int idAgenda = (x == 0) ? 0 : getIdAgenda(idConsultorio, hora, dtAgendas);
                    row[x] = (x == 0) ? idConsultorio.ToString() : idAgenda.ToString(); ;
                }
                dt.Rows.Add(row);
            }
            dt.AcceptChanges();
            return dt;

        }

        private int getIdAgenda(int idConsultorio, string hora, DataTable dtAgendas)
        {
            DateTime fechaAgenda = Convert.ToDateTime(txtFecha.Text);
            DateTime horaComparada = Convert.ToDateTime(txtFecha.Text + " " + hora + ":00");

            string filtro = "(idConsultorio = " + idConsultorio.ToString() + ") "
                          + "AND ('#" + horaComparada.ToString() + "#' >= HoraInicio) "
                          + "AND ('#" + horaComparada.ToString() + "#' < HoraFin)";

            DataRow[] row = dtAgendas.Select(filtro);

            return (row.Length == 0) ? 0 : Convert.ToInt32(row[0]["idAgenda"]);
        }

        private DataTable generarColumnas(DataTable dt, DataTable dtHoras)
        {
            dt.Columns.Add("Consultorio");

            for (int i = 0; i < dtHoras.Rows.Count; i++)
            {
                dt.Columns.Add(dtHoras.Rows[i]["Hora"].ToString());
            }
            return dt;
        }

        private DataTable getListaConsultorios(int idEfector)
        {
            DataTable dt = new DataTable();

            if (ddlTipoCons.SelectedValue != "")
            {
                if (ddlTipoCons.SelectedValue != "0")
                {
                    dt = new Select("idConsultorio, Nombre").From(Schemas.ConConsultorio)
                                     .Where(ConConsultorio.Columns.IdTipoConsultorio)
                                     .IsEqualTo(Convert.ToInt32(ddlTipoCons.SelectedValue))
                                     .And(ConConsultorio.Columns.IdEfector).IsEqualTo(idEfector)
                                     .OrderAsc(ConConsultorio.Columns.Nombre)
                                     .ExecuteDataSet().Tables[0];
                }
                else
                {
                    dt = new Select("idConsultorio, Nombre").From(Schemas.ConConsultorio)
                                     .Where(ConConsultorio.Columns.IdEfector).IsEqualTo(idEfector)
                                     .OrderAsc(ConConsultorio.Columns.Nombre)
                                     .ExecuteDataSet().Tables[0];
                }
            }
            return dt;
        }

        private DataTable getListaHorarios()
        {
            DataTable dtHoras = new DataTable();
            dtHoras.Columns.Add("Hora");

            string hini = ddlHini.SelectedItem.Text;
            string hFin = ddlHfin.SelectedItem.Text;
            int intHini = Convert.ToInt32(hini.Substring(0, 2));
            int intHfin = Convert.ToInt32(hFin.Substring(0, 2));

            string h = string.Empty;
            string m = string.Empty;
            int frecuencia = 15;

            for (int i = intHini; i < intHfin; i++)
            {
                for (int x = 0; x < 60; x += frecuencia)
                {
                    h = i.ToString(); m = x.ToString();
                    if (h.Length == 1) { h = "0" + h; }
                    if (m.Length == 1) { m = "0" + m; }
                    DataRow hora = dtHoras.NewRow();
                    hora["Hora"] = h + ":" + m;
                    dtHoras.Rows.Add(hora);
                }
            }
            return dtHoras;
        }

        protected void ddlTipoCons_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrilla();
        }
    }
}
