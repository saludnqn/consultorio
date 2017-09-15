using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using DalSic;
using Salud.Security.SSO;

namespace Consultorio.AtencionConsultorio
{
    public partial class AgendaList : System.Web.UI.Page
    {
        public CrystalReportSource oCr = new CrystalReportSource();


        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //int us = SSOHelper.CurrentIdentity.Id;
            llenarCombos();                              
        }

   

        private void llenarCombos()
        {                    
            SysZonaCollection ct1 = new SubSonic.Select()
               .From(Schemas.SysZona)
               .Where(SysZona.Columns.IdZona).IsGreaterThan(1)
               .OrderAsc(SysZona.Columns.IdZona)
               .ExecuteAsCollection<SysZonaCollection>();
            ddlZona.DataSource = ct1;
            ddlZona.DataValueField = SysZona.Columns.IdZona;
            ddlZona.DataTextField = SysZona.Columns.Nombre;
            ddlZona.DataBind();
            ddlZona.SelectedValue = "9";


            SysEfectorCollection ct = new SubSonic.Select()
                         .From(Schemas.SysEfector)
                         .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                         .And(SysEfector.Columns.IdZona).IsEqualTo(int.Parse(ddlZona.SelectedValue))
                         .OrderAsc(SysEfector.Columns.Nombre)
                         .ExecuteAsCollection<SysEfectorCollection>();
            ddlEfector.DataSource = ct;
            ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
            ddlEfector.DataTextField = SysEfector.Columns.Nombre;
            ddlEfector.DataBind();
            ddlEfector.Items.Insert(0, new ListItem("Seleccione", "0"));


            txtDesde.Text = DateTime.Now.ToString().Substring(0, 10);
            txtHasta.Text = DateTime.Now.ToString().Substring(0, 10);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            buscarAgendas();
        }

        private void buscarAgendas()
        {
            int idZona = 0;
            int idEfector = 0;
            int idServicio = 0;
            int idEspecialidad = 0;
            int idProfesional = 0;
            int idTipoConsultorio = 0;
            int idAgendaEstado = 0;
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;

            if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }
            if (ddlEfector.SelectedIndex > 0) { idEfector = Convert.ToInt32(ddlEfector.SelectedValue); }
                       

            gvAgendas.DataSource = SPs.ConGetAgendas(idZona,idEfector, idServicio, idEspecialidad, idProfesional, idTipoConsultorio,
                                   fini.ToString("yyyyMMdd"), ffin.ToString("yyyyMMdd"), tipoAgenda, idAgendaEstado).GetDataSet().Tables[0];
            //gvAgendas.DataKeyField = "idAgenda";
            gvAgendas.DataBind();
            lblCantidadRegistros.Text = "Se han encontrado " + gvAgendas.Rows.Count.ToString() + " agendas";
            PintarReferencias();
        }


        private void PintarReferencias()
        {
            foreach (GridViewRow row in gvAgendas.Rows)
            {
                switch (row.Cells[0].Text)
                {
                    case "Inactiva": ///Abierto
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Red;
                            //Image hlnk = new Image();
                            //hlnk.ImageUrl = "~/App_Themes/consultorio/Agenda/turnobloqueado.png";
                            //row.Cells[0].Controls.Add(hlnk);
                        }
                        break;
                    case "Bloqueada": //en proceso
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Red;
                            //Image hlnk = new Image();
                            //hlnk.ImageUrl = "~/App_Themes/consultorio/images/amarillo.gif";
                            //row.Cells[0].Controls.Add(hlnk);
                        }
                        break;
                    case "Activa": //terminado
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Black;
                            //Image hlnk = new Image();
                            //hlnk.ImageUrl = "~/App_Themes/consultorio/images/verde.gif";
                            //row.Cells[0].Controls.Add(hlnk);
                        }
                        break;

                    case "Cerrada": //terminado
                        {
                            row.Cells[0].ForeColor = System.Drawing.Color.Blue;
                            //Image hlnk = new Image();
                            //hlnk.ImageUrl = "~/App_Themes/consultorio/images/verde.gif";
                            //row.Cells[0].Controls.Add(hlnk);
                        }
                        break;
                }
              

            }

        }




        protected void gvAgendas_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void ImprimirPlanilla(int idAgenda)
        {
            //Aca se deberá consultar los parametros para mostrar una hoja de trabajo u otra
            //this.CrystalReportSource1.Report.FileName = "HTrabajo2.rpt";
            string informe = "../Informes/Planilla.rpt";


            ConAgenda agenda = new ConAgenda(idAgenda);

            if ((agenda.IdEspecialidad == 50) || (agenda.IdEspecialidad == 52) || (agenda.IdEspecialidad == 25))///Salud Mental
                informe = "../Informes/PlanillaSaludMental.rpt";

            if (agenda.IdEspecialidad == 34)///Odontologia
                informe = "../Informes/PlanillaOdontologia2.rpt";


            //informe = "../Informes/ModeloPlanilla.rpt";
            //informe = "../Informes/ModeloPlanillaSaludMental.rpt";
            //informe = "../Informes/ModeloPlanillaOdontologia.rpt";

            ParameterDiscreteValue encabezado1 = new ParameterDiscreteValue();
            encabezado1.Value = agenda.SysEfector.Nombre;

            DataTable dt = getPlanillaTurnos(agenda);
            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);
            oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(encabezado1);

            oCr.DataBind();

            MemoryStream oStream; // using System.IO
            oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=PlanillaConsultorio.pdf");

            Response.BinaryWrite(oStream.ToArray());
            Response.End();

        }

        private DataTable getPlanillaTurnos(ConAgenda agenda)
        {
            return SPs.ConPlanillaPorAgenda(agenda.IdAgenda).GetDataSet().Tables[0];
        }

        protected void gvAgendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton cmdEditar = (LinkButton)e.Row.FindControl("Editar");
                cmdEditar.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdEditar.CommandName = "Editar";
                cmdEditar.ToolTip = "Editar";

                LinkButton cmdPlanilla = (LinkButton)e.Row.FindControl("Planilla");
                cmdPlanilla.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdPlanilla.CommandName = "Imprimir";
                cmdPlanilla.ToolTip = "Imprimir Planilla";


                //LinkButton cmdCierre = (LinkButton)e.Row.FindControl("Cierre");
                //cmdCierre.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                //cmdCierre.CommandName = "Cierre";
                //cmdCierre.ToolTip = "Cerrar Agenda";


                LinkButton cmdCodificar = (LinkButton)e.Row.FindControl("Codificar");
                cmdCodificar.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdCodificar.CommandName = "Codificar";
                cmdCodificar.ToolTip = "Codificar Agenda";



                LinkButton cmdTurnos = (LinkButton)e.Row.FindControl("Turnos");
                cmdTurnos.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                cmdTurnos.CommandName = "Turnos";
                cmdTurnos.ToolTip = "Ver Turnos";
                //ConAgenda Agenda= new ConAgenda( int.Parse(gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString()));
                //if (Agenda.SysEfector.IdTipoEfector <= 1) //Centro de salud
                //    e.Row.Cells[2].Text = "-";



                //if (e.Row.Cells[9].Text == "0") e.Row.Cells[9].Text = "&nbsp;";
                //if (e.Row.Cells[9].Text != "&nbsp;")
                //    suma1 += int.Parse(e.Row.Cells[9].Text);

                //if (e.Row.Cells[10].Text == "0") e.Row.Cells[10].Text = "&nbsp;";
                //if (e.Row.Cells[10].Text != "&nbsp;")
                //    suma2 += int.Parse(e.Row.Cells[10].Text);

                //if (e.Row.Cells[11].Text == "0") e.Row.Cells[11].Text = "&nbsp;";
                //if (e.Row.Cells[11].Text != "&nbsp;")
                //    suma3 += int.Parse(e.Row.Cells[11].Text);

                //if (e.Row.Cells[12].Text == "0") e.Row.Cells[12].Text = "&nbsp;";
                //if (e.Row.Cells[12].Text != "&nbsp;")
                //    suma4 += int.Parse(e.Row.Cells[12].Text);



                ////Calculo de sobre turnos
                //int sobreturnos = 0;
                //if (e.Row.Cells[13].Text != "&nbsp;")
                //{
                //    if (int.Parse(e.Row.Cells[13].Text) < 0)
                //        sobreturnos = Math.Abs(int.Parse(e.Row.Cells[13].Text));

                //    suma6 += sobreturnos;
                //}
                //if (sobreturnos == 0) e.Row.Cells[14].Text = "&nbsp;";
                //else
                //    e.Row.Cells[14].Text = sobreturnos.ToString();


                //if (e.Row.Cells[13].Text == "0") e.Row.Cells[13].Text = "&nbsp;";
                //if (e.Row.Cells[13].Text != "&nbsp;")
                //    if (int.Parse(e.Row.Cells[13].Text) > 0)
                //        suma5 += int.Parse(e.Row.Cells[13].Text);
                //    else
                //        e.Row.Cells[13].Text = "&nbsp;";




            }
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.Cells[8].Text = "TOTAL";
            //    e.Row.Cells[9].Text = suma1.ToString();
            //    e.Row.Cells[10].Text = suma2.ToString();
            //    e.Row.Cells[11].Text = suma3.ToString();
            //    e.Row.Cells[12].Text = suma4.ToString();
            //    e.Row.Cells[13].Text = suma5.ToString();
            //    e.Row.Cells[14].Text = suma6.ToString();

            //}
        }

        protected void gvAgendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
                Response.Redirect("AgendaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            if (e.CommandName == "Imprimir")
                ImprimirPlanilla(int.Parse(e.CommandArgument.ToString()));

            if (e.CommandName == "Cierre")
                Response.Redirect("../Turnos/AsistenciaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            if (e.CommandName == "Codificar")
                Response.Redirect("../../ConsultaAmbulatoria/DiagnosticoEdit.aspx?idAgenda=" + e.CommandArgument.ToString()+"&Tipo=Atencion", false);


            if (e.CommandName == "Turnos")
                Response.Redirect("TurnosView.aspx?idAgenda=" + e.CommandArgument.ToString(), false);
        }

        protected void gvAgendas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAgendas.PageIndex = e.NewPageIndex;
            buscarAgendas();
        }

        protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEfector.Items.Clear();
            if (ddlZona.SelectedValue != "0")
            {

                SysEfectorCollection ct = new SubSonic.Select()
                      .From(Schemas.SysEfector)
                      .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                      .And(SysEfector.Columns.IdZona).IsEqualTo(int.Parse(ddlZona.SelectedValue))
                      .OrderAsc(SysEfector.Columns.Nombre)
                      .ExecuteAsCollection<SysEfectorCollection>();
                ddlEfector.DataSource = ct;
                ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
                ddlEfector.DataTextField = SysEfector.Columns.Nombre;
                ddlEfector.DataBind();
                ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));
            }
            else
            {
                SysEfectorCollection ct = new SubSonic.Select()
                .From(Schemas.SysEfector)
                .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                    //    .And(SysEfector.Columns.IdZona).IsEqualTo(us.SysEfector.IdZona)
                .OrderAsc(SysEfector.Columns.Nombre)
                .ExecuteAsCollection<SysEfectorCollection>();
                ddlEfector.DataSource = ct;
                ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
                ddlEfector.DataTextField = SysEfector.Columns.Nombre;
                ddlEfector.DataBind();
                ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));
            }
        }

        protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProfesional();
        }

        private void CargarProfesional()
        {

            if (ddlEfector.SelectedValue != "0")
            {
                ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(int.Parse( ddlEfector.SelectedValue), 0).GetDataSet();
                ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
                ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
                ddlProfesional.DataBind();

                ddlProfesional.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }


    }
}
