using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalSic;
using SubSonic;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Salud.Security.SSO;


namespace Consultorio.PanelConsultas
{
    public partial class AgendaList : System.Web.UI.Page
    {
        public CrystalReportSource oCr = new CrystalReportSource();
        int suma1 = 0; int suma2 = 0; int suma3 = 0; int suma4 = 0; int suma5 = 0; int suma6 = 0; int suma7 = 0;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            oCr.Report.FileName = "";
            oCr.CacheDuration = 0;
            oCr.EnableCaching = false;

        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    llenarCombos();                 
                    buscarAgendas();                 
                }
        }

        protected void ddlTipoTurno_SelectedIndexChanged(object sender, EventArgs e)
        {          
            //int i_tipo = -1;
            if (ddlTipoTurno.SelectedValue == "Prestaciones") //tipo de prestacion            
            {
                SysEspecialidadCollection cte = new SubSonic.Select()
         .From(Schemas.SysEspecialidad)

         .Where(SysEspecialidad.Columns.Codigo).IsEqualTo(0)
         .OrderAsc(SysEspecialidad.Columns.Nombre)
         .ExecuteAsCollection<SysEspecialidadCollection>();
                ddlEspecialidad.DataSource = cte;
            }


            if (ddlTipoTurno.SelectedValue == "Especialidad") //especialidades
            {
                SysEspecialidadCollection cte = new SubSonic.Select()
                    .From(Schemas.SysEspecialidad)
                    .Where(SysEspecialidad.Columns.Codigo).IsNotEqualTo(0)
                    .OrderAsc(SysEspecialidad.Columns.Nombre)
                    .ExecuteAsCollection<SysEspecialidadCollection>();
                ddlEspecialidad.DataSource = cte;
            }
                        
            
            //SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));            
            //ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(us.IdEfector, i_tipo).GetDataSet();
            //ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            //ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            //ddlEspecialidad.DataBind();
            //ddlEspecialidad.Items.Insert(0, "--Todas--");
         
            
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Todas", "0"));
        }

        private void llenarCombos()
        {        

            /////Carolina: Modifico para que se muestren los servicios del efector   
            //ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(us.IdEfector,-1).GetDataSet();
            //ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            //ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            //ddlEspecialidad.DataBind();
            //ddlEspecialidad.Items.Insert(0, "--Todas--");

            SysEspecialidadCollection cte = new SubSonic.Select()
            .From(Schemas.SysEspecialidad)

            .OrderAsc(SysEspecialidad.Columns.Nombre)
            .ExecuteAsCollection<SysEspecialidadCollection>();
            ddlEspecialidad.DataSource = cte;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Todas", "0"));


            SysZonaCollection ct1 = new SubSonic.Select()
               .From(Schemas.SysZona)
               .Where(SysZona.Columns.IdZona).IsGreaterThan(1)
               .OrderAsc(SysZona.Columns.IdZona)
               .ExecuteAsCollection<SysZonaCollection>();
            ddlZona.DataSource = ct1;
            ddlZona.DataValueField = SysZona.Columns.IdZona;
            ddlZona.DataTextField = SysZona.Columns.Nombre;
            ddlZona.DataBind();

            
            ddlZona.Items.Insert(0, new ListItem("Todos", "0"));

            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (efector.IdTipoEfector >= 4)     ///Consulta para nivel central       
            {
                ddlZona.SelectedValue = efector.IdZona.ToString(); CargarEfectores();
            }



            //SysEfectorCollection  ct = new SubSonic.Select()
            //    .From(Schemas.SysEfector)
            //    .Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
            ////    .And(SysEfector.Columns.IdZona).IsEqualTo(us.SysEfector.IdZona)
            //    .OrderAsc(SysEfector.Columns.Nombre)
            //    .ExecuteAsCollection<SysEfectorCollection>();
            //ddlEfector.DataSource = ct;
            //ddlEfector.DataValueField = SysEfector.Columns.IdEfector;
            //ddlEfector.DataTextField = SysEfector.Columns.Nombre;
            //ddlEfector.DataBind();
            //ddlEfector.Items.Insert(0, new ListItem("Todos", "0"));


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
            int idAgendaEstado=0;
            DateTime fini = Convert.ToDateTime("01/01/1900");
            DateTime ffin = Convert.ToDateTime("31/12/2999");
            int tipoAgenda = -1;

            if (ddlZona.SelectedIndex > 0) { idZona = Convert.ToInt32(ddlZona.SelectedValue); }

      //      if (ddlServicios.SelectedIndex > 0) { idServicio = Convert.ToInt32(ddlServicios.SelectedValue); }
            if (ddlEspecialidad.SelectedIndex > 0) { idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); }
            //if (ddlProfesional.SelectedIndex > 0) { idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue); }
            //if (ddlTipoCons.SelectedIndex > 0) { idTipoConsultorio = Convert.ToInt32(ddlTipoCons.SelectedValue); }
            if (!(txtDesde.Text == string.Empty)) { fini = Convert.ToDateTime(txtDesde.Text); }
            if (!(txtHasta.Text == string.Empty)) { ffin = Convert.ToDateTime(txtHasta.Text); }
            if (ddlEfector.SelectedIndex > 0) { idEfector = Convert.ToInt32(ddlEfector.SelectedValue); }

            if (ddlTipoTurno.SelectedValue == "Prestaciones") tipoAgenda = 0;

            if (ddlTipoTurno.SelectedValue == "Especialidad") tipoAgenda = 1;

            //if (ddlEstado.SelectedIndex > 0) { idAgendaEstado = Convert.ToInt32(ddlEstado.SelectedValue); }

            //SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));

            gvAgendas.DataSource = SPs.ConGetAgendas(idZona, idEfector, idServicio, idEspecialidad, idProfesional, idTipoConsultorio,
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

                //switch (row.Cells[1].Text)
                //{
                //    case "True":
                //        {
                //            Image hlnk = new Image();
                //            hlnk.ImageUrl = "~/App_Themes/default/images/impreso.jpg";
                //            hlnk.ToolTip = "Protocolo Impreso";
                //            row.Cells[1].Controls.Add(hlnk);
                //        }
                //        break;
                //    case "False":
                //        {
                //            Image hlnk = new Image();
                //            hlnk.ImageUrl = "~/App_Themes/default/images/transparente.jpg";
                //            row.Cells[1].Controls.Add(hlnk);
                //        }
                //        break;

                //}

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
            if (e.Row.Cells.Count > 1)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    ConAgenda agenda = new ConAgenda(int.Parse(gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString()));

                    ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                        .From(Schemas.ConAgendaProfesional).Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(agenda.IdAgenda)
                        .ExecuteAsCollection<ConAgendaProfesionalCollection>();



                    ListView lblProfesional = (ListView)e.Row.FindControl("lsvProfesional");
                    ListView lblEspecialidad = (ListView)e.Row.FindControl("lsvEspecialidad");

                    List<string> lista = new List<string>();
                    List<string> lista_e = new List<string>();

                    //if (agenda.Multiprofesional == true)
                    //{
                    for (int x = 0; x < listaAgendaProfesional.Count; x++)
                    {
                        lista.Add(listaAgendaProfesional.ElementAt(x).SysProfesional.NombreCompleto);
                        lista_e.Add(listaAgendaProfesional.ElementAt(x).SysEspecialidad.Nombre);
                    }

                    lblProfesional.DataSource = lista;
                    lblProfesional.DataBind();

                    lblEspecialidad.DataSource = lista_e;
                    lblEspecialidad.DataBind();


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


                    LinkButton cmdAbrir = (LinkButton)e.Row.FindControl("Abrir");
                    cmdAbrir.CommandArgument = gvAgendas.DataKeys[e.Row.RowIndex].Value.ToString();
                    cmdAbrir.CommandName = "Abrir";
                    cmdAbrir.ToolTip = "Abrir Agenda";

                    if (e.Row.Cells[0].Text == "Activa") cmdAbrir.Visible = false;
                    else cmdAbrir.Visible = true;


                    if (e.Row.Cells[9].Text == "0") e.Row.Cells[9].Text = "&nbsp;";
                    if (e.Row.Cells[9].Text != "&nbsp;")
                        suma1 += int.Parse(e.Row.Cells[9].Text);

                    if (e.Row.Cells[10].Text == "0") e.Row.Cells[10].Text = "&nbsp;";
                    if (e.Row.Cells[10].Text != "&nbsp;")
                        suma2 += int.Parse(e.Row.Cells[10].Text);

                    if (e.Row.Cells[11].Text == "0") e.Row.Cells[11].Text = "&nbsp;";
                    if (e.Row.Cells[11].Text != "&nbsp;")
                        suma3 += int.Parse(e.Row.Cells[11].Text);

                    if (e.Row.Cells[12].Text == "0") e.Row.Cells[12].Text = "&nbsp;";
                    if (e.Row.Cells[12].Text != "&nbsp;")
                        suma4 += int.Parse(e.Row.Cells[12].Text);

                    if (e.Row.Cells[13].Text == "0") e.Row.Cells[13].Text = "&nbsp;";
                    if (e.Row.Cells[13].Text != "&nbsp;")
                        suma5 += int.Parse(e.Row.Cells[13].Text);





                    if (e.Row.Cells[14].Text == "0") e.Row.Cells[14].Text = "&nbsp;";
                    if (e.Row.Cells[14].Text != "&nbsp;")
                        if (int.Parse(e.Row.Cells[14].Text) > 0)
                            suma6 += int.Parse(e.Row.Cells[14].Text);
                        else
                            e.Row.Cells[14].Text = "&nbsp;";


                    if (e.Row.Cells[15].Text == "0") e.Row.Cells[15].Text = "&nbsp;";
                    if (e.Row.Cells[15].Text != "&nbsp;")
                        if (int.Parse(e.Row.Cells[15].Text) > 0)
                            suma7 += int.Parse(e.Row.Cells[15].Text);
                        else
                            e.Row.Cells[15].Text = "&nbsp;";

                    ////Calculo de sobre turnos
                    //   int sobreturnos=0;
                    //   if ((e.Row.Cells[13].Text != "&nbsp;")&&(e.Row.Cells[9].Text != "&nbsp;"))
                    //   {

                    //       if (int.Parse(e.Row.Cells[13].Text) > int.Parse(e.Row.Cells[9].Text))
                    //           sobreturnos = Math.Abs(int.Parse(e.Row.Cells[13].Text)) - Math.Abs(int.Parse(e.Row.Cells[9].Text));

                    //       suma7 += sobreturnos;
                    //   }
                    //   if (sobreturnos == 0) e.Row.Cells[15].Text = "&nbsp;";
                    //   else
                    //   e.Row.Cells[15].Text = sobreturnos.ToString();


                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[8].Text = "TOTAL";
                    e.Row.Cells[9].Text = suma1.ToString();
                    e.Row.Cells[10].Text = suma2.ToString();
                    e.Row.Cells[11].Text = suma3.ToString();
                    e.Row.Cells[12].Text = suma4.ToString();
                    e.Row.Cells[13].Text = suma5.ToString();
                    e.Row.Cells[14].Text = suma6.ToString();
                    e.Row.Cells[15].Text = suma7.ToString();

                }
            }
        }

        protected void gvAgendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
               Response.Redirect("AgendaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            if (e.CommandName== "Imprimir")
                ImprimirPlanilla( int.Parse( e.CommandArgument.ToString()));

            if (e.CommandName == "Cierre")
                Response.Redirect("../Turnos/AsistenciaEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);
            
            if (e.CommandName == "Codificar")
                Response.Redirect("~/ConsultaAmbulatoria/DiagnosticoEdit.aspx?idAgenda=" + e.CommandArgument.ToString(), false);
            
            if (e.CommandName == "Turnos")
                Response.Redirect("TurnosView.aspx?idAgenda=" + e.CommandArgument.ToString(), false);

            if (e.CommandName == "Abrir")
                AbrirAgenda(e.CommandArgument.ToString());
        }

        private void AbrirAgenda(string  idagenda)
        {
            ConAgenda ag = new ConAgenda(Convert.ToInt32(idagenda));
            ag.IdAgendaEstado = 1;
            ag.Save();
            buscarAgendas();    
        }

        protected void gvAgendas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAgendas.PageIndex = e.NewPageIndex;
            buscarAgendas();
        }

        protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEfectores();
        }

        private void CargarEfectores()
        {
            ddlEfector.Items.Clear();
            if (ddlZona.SelectedValue != "0")
            {

                SysEfectorCollection ct = new SubSonic.Select()
                      .From(Schemas.SysEfector)
                      .Where(SysEfector.Columns.IdZona).IsEqualTo(int.Parse(ddlZona.SelectedValue))
                      //.Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
                      //.And(SysEfector.Columns.IdZona).IsEqualTo(int.Parse(ddlZona.SelectedValue))
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
                //.Where(SysEfector.Columns.IdTipoEfector).IsEqualTo(1)
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


    }
}
