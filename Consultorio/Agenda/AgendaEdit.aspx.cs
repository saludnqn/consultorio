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

namespace Consultorio.Agenda
{
    public partial class AgendaEdit : System.Web.UI.Page
    {

        private int idAgenda
        {
            get { return ViewState["idAgenda"] == null ? 0 : (int)(ViewState["idAgenda"]); }
            set { ViewState["idAgenda"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try { idAgenda = Convert.ToInt32(Request.QueryString["idAgenda"]); }
                catch { }
                llenarCombos();
                leerAgenda(idAgenda);
                llenarTablaProfesionales(idAgenda);
            }
        }

        private void llenarTablaProfesionales(int idAgenda)
        {
            ConAgendaProfesionalCollection listaProfesionales = new SubSonic.Select().From(Schemas.ConAgendaProfesional)
            .InnerJoin(Schemas.SysProfesional)
            .LeftOuterJoin(Schemas.SysEspecialidad)
            .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(idAgenda).ExecuteAsCollection<ConAgendaProfesionalCollection>();

            gdvListaProfesionales.DataSource = listaProfesionales.ToList();
            gdvListaProfesionales.DataBind();
        
        }

        private void llenarCombos() 
        {
            SysEfector oEfector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            if (oEfector.IdTipoEfector <= 2) //Centro de salud
                pnlServicio.Visible = false;
            else
                pnlServicio.Visible = true;

            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlServicio.DataSource = SPs.SysGetServicioByEfector(SSOHelper.CurrentIdentity.IdEfector).GetDataSet();
            ddlServicio.DataTextField = SysServicio.Columns.Nombre;
            ddlServicio.DataValueField = SysServicio.Columns.IdServicio;
            ddlServicio.DataBind();

            //ddlEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, -1).GetDataSet();
            //ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            //ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            //ddlEspecialidad.DataBind();
            //ddlEspecialidad.Items.Insert(0, "--Seleccione--");
            ///

            ConConsultorioTipoCollection ct = new SubSonic.Select()
                .From(Schemas.ConConsultorioTipo)
                .OrderAsc(ConConsultorioTipo.Columns.Nombre)
                .ExecuteAsCollection<ConConsultorioTipoCollection>();
            ddlTipoConsultorio.DataSource = ct;
            ddlTipoConsultorio.DataValueField = ConConsultorioTipo.Columns.IdTipoConsultorio;
            ddlTipoConsultorio.DataTextField = ConConsultorioTipo.Columns.Nombre;
            ddlTipoConsultorio.DataBind();


            ///Carolina: Modifico para que se muestren los profesiones del efector                        
            ddlProfesional.DataSource = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet();
            ddlProfesional.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlProfesional.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlProfesional.DataBind();
            ListItem item = new ListItem();
            item.Value = "-1";
            item.Text = "--(Sin especificar)--";
            ddlProfesional.Items.Insert(0, item);
            ///

            ddlEspecialidadXProfesional.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, -1).GetDataSet();
            ddlEspecialidadXProfesional.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidadXProfesional.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidadXProfesional.DataBind();
            ddlEspecialidadXProfesional.Items.Insert(0, "--Seleccione--");

            ddlMotivoInactivacion.DataSource = SPs.ConGetMotivoInactivacionAgenda().GetDataSet();
            ddlMotivoInactivacion.DataTextField = "Descripcion";
            ddlMotivoInactivacion.DataValueField = "idMotivoInactivacion";
            ddlMotivoInactivacion.DataBind();
            ddlMotivoInactivacion.Items.Insert(0, new ListItem("Seleccione un Motivo", "0"));
            motivoInactivacion.Visible = false;


            
            ConAgendaEstadoCollection est = new SubSonic.Select()
                .From(Schemas.ConAgendaEstado)
                .Where(ConAgendaEstado.Columns.IdAgendaEstado).IsNotEqualTo(2) // no permito la opcion de bloqueada                
                .And (ConAgendaEstado.Columns.IdAgendaEstado).IsNotEqualTo(4)
                .OrderDesc(ConAgendaEstado.Columns.Nombre)
                .ExecuteAsCollection<ConAgendaEstadoCollection>();
            ddlEstado.DataSource = est;
            ddlEstado.DataValueField = ConAgendaEstado.Columns.IdAgendaEstado;
            ddlEstado.DataTextField = ConAgendaEstado.Columns.Nombre;
            ddlEstado.DataBind();
        }

        private void leerAgenda(int idAgenda)
        {
            ConAgenda ag = new ConAgenda(idAgenda);

            int totalTurnos = getCantidadTotal(ag);
            DateTime fagenda = ag.Fecha;

            lblFecha.Text = fagenda.ToString().Substring(0, 10);
            lblNroAgenda.Text = ag.IdAgenda.ToString();
            ddlEstado.SelectedValue = ag.IdAgendaEstado.ToString();
            cmdFecha.Visible = (ag.IdAgendaEstado == 2) ? true : false;
            cmdFecha.Enabled = (ag.IdAgendaEstado == 2) ? true : false;

            if (ag.IdAgendaEstado == 2)
            {///Bloqueada
                ConAgendaBloqueo b = ag.ConAgendaBloqueoRecords.First<ConAgendaBloqueo>();
                txtActivacion.Enabled = true;
                txtActivacion.Text = (b.FechaActivacion.ToString().Substring(0, 10) == "01/01/1999") ? "" : b.FechaActivacion.ToString().Substring(0, 10);
            }

            if (ag.IdAgendaEstado == 3) ///Eliminada-Inactiva
            {
                ddlEstado.SelectedValue = "3";
                ddlEstado.Enabled = false;
            }
       //     ddlProfesional.SelectedValue = ag.IdProfesional.ToString();
            //  ddlEspecialidad.SelectedValue = ag.IdEspecialidad.ToString();
            ddlServicio.SelectedValue = ag.IdServicio.ToString();
            ddlTipoConsultorio.SelectedValue = ag.ConConsultorio.IdTipoConsultorio.ToString();
            llenarConsultorios(ag.ConConsultorio.IdTipoConsultorio);
            ddlConsultorio.Text = ag.IdConsultorio.ToString();



            // agrego validacion de profesionales.
            //DataTable dtProfesionales = (DataTable)ViewState["dtProfesionales"];          
            ConAgendaProfesionalCollection listaAgendaProfesional = new Select().From(Schemas.ConAgendaProfesional)
                             .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(ag.IdAgenda).ExecuteAsCollection<ConAgendaProfesionalCollection>();

            int i = 0;
            foreach (ConAgendaProfesional data1 in listaAgendaProfesional)
            {
                if (i == 0)
                {
                    ddlProfesional.SelectedValue = data1.SysProfesional.IdProfesional.ToString();
                    ddlEspecialidadXProfesional.SelectedValue = data1.SysEspecialidad.IdEspecialidad.ToString();
                }
                
            }


            if (ag.IdAgendaEstado == 4)
            {///cerrada
             ///
                ListItem item = new ListItem();
                item.Value = "4";
                item.Text = "Cerrada";
                ddlEstado.Items.Insert(0, item);

                ddlProfesional.Enabled = false;
                ddlEspecialidadXProfesional.Enabled = false;
                ddlEstado.Enabled = false;
                imgAgregarProfesionales.Enabled = false;
                gdvListaProfesionales.Enabled = false;

            }
            /////////////////////7
           // ddlEspecialidad.SelectedValue = ag.IdEspecialidad.ToString();
        }

        private void CargarPrestaciones()
        {
            ConTipoPrestacionCollection e1 = new SubSonic.Select()
             .From(Schemas.ConTipoPrestacion)
             .Where(ConTipoPrestacion.Columns.IdTipoPrestacion).IsNotEqualTo(0)
             .OrderAsc(ConAgendaEstado.Columns.Nombre)
             .ExecuteAsCollection<ConTipoPrestacionCollection>();
            ddlEspecialidadXProfesional.DataSource = e1;
            ddlEspecialidadXProfesional.DataValueField = ConTipoPrestacion.Columns.IdTipoPrestacion;
            ddlEspecialidadXProfesional.DataTextField = ConTipoPrestacion.Columns.Nombre;
            ddlEspecialidadXProfesional.DataBind();
        }

        private void CargarEspecialidades()
        {
            
            ///Carolina: Modifico para que se muestren los servicios del efector   
            ddlEspecialidadXProfesional.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, -1).GetDataSet();
            ddlEspecialidadXProfesional.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidadXProfesional.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidadXProfesional.DataBind();
        }

        private int getMinimoInterconsulta(ConAgenda ag)
        {
            return new Select().From(Schemas.ConTurnoReservaInterconsultum)
                               .Where(ConTurnoReservaInterconsultum.Columns.IdAgenda)
                               .IsEqualTo(ag.IdAgenda)
                               .GetRecordCount();
        }

        private int getMinimoSobreturnos(ConAgenda ag)
        {
            return new Select().From(Schemas.ConTurno)
                               .Where(ConTurno.Columns.IdAgenda)
                               .IsEqualTo(ag.IdAgenda)
                               .And(ConTurno.Columns.Sobreturno)
                               .IsEqualTo(true).GetRecordCount();
        }

        private int getMinimoReserva(ConAgenda ag)
        {
            return new Select().From(Schemas.ConTurno)
                               .Where(ConTurno.Columns.IdAgenda)
                               .IsEqualTo(ag.IdAgenda)
                               .And(ConTurno.Columns.IdTurnoEstado)
                               .IsEqualTo(getIdEstadoReserva()).GetRecordCount();
        }

        private object getIdEstadoReserva()
        {
            ConTurnoEstado t = new Select("idTurnoEstado")
                                    .From(Schemas.ConTurnoEstado)
                                    .Where(ConTurnoEstado.Columns.Nombre)
                                    .Like("Reservado")
                                    .ExecuteSingle<ConTurnoEstado>();
            return t.IdTurnoEstado;
        }

        private void llenarConsultorios(int idTipoConsultorio)
        {
            ConConsultorioCollection c = new SubSonic.Select()
                .From(Schemas.ConConsultorio)
                .Where(ConConsultorio.Columns.IdTipoConsultorio).IsEqualTo(idTipoConsultorio)
                .OrderAsc(ConConsultorio.Columns.Nombre)
                .ExecuteAsCollection<ConConsultorioCollection>();
            ddlConsultorio.DataSource = c;
            ddlConsultorio.DataValueField = ConConsultorio.Columns.IdConsultorio;
            ddlConsultorio.DataTextField = ConConsultorio.Columns.Nombre;
            ddlConsultorio.DataBind();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                ConAgenda ag = new ConAgenda(idAgenda);

                string st = datosValidos(ag);

                if (st == string.Empty)
                {
                    grabarAgenda(ag);

                    imgErr.Src = "../../App_Themes/consultorio/Agenda/check_verde.png";
                    lblError.Text = "Agenda grabada correctamente";
                    divErr.Visible = true;
                    btnReset.Enabled = false;
                }
                else
                {
                    imgErr.Src = "../../App_Themes/consultorio/Agenda/boton-de-error-icono-5371-48.png";
                    lblError.Text = st;
                    divErr.Visible = true;
                }

                updPanel.Update();
            }
            else
            {
                imgErr.Src = "../../App_Themes/consultorio/Agenda/boton-de-error-icono-5371-48.png";
                lblError.Text = "Errores en datos ingresados marcados con asterisco";
                divErr.Visible = true;
                updPanel.Update();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //Se pone inactiva o se elimina siempre y cuando no tenga turnos
            ConAgenda ag = new ConAgenda(idAgenda);

            if (noTieneTurnos(ag))
            {
                ag.IdMotivoInactivacion = Convert.ToInt16(ddlMotivoInactivacion.SelectedValue);

                if (ag.IdMotivoInactivacion == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('Debe seleccionar un motivo de inactivación')", true);
                }
                else
                {
                    ag.IdAgendaEstado = 3;
                    ag.Save();
                    grabarAuditoria(ag);
                    Response.Redirect("AgendaList.aspx", false);
                }
            }
            else
            {
                imgErr.Src = "../../App_Themes/consultorio/Agenda/boton-de-error-icono-5371-48.png";
                lblError.Text = "La agenda ya tiene turnos asignados. No es posible eliminar la misma.";
                divErr.Visible = true;
                updPanel.Update();
            }
        }

        private bool noTieneTurnos(ConAgenda ag)
        {
            int r = new Select().From(Schemas.ConTurno)
                              .Where(ConTurno.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                              .And(ConTurno.Columns.IdTurnoEstado).IsEqualTo(1)
                              .GetRecordCount();


            return (r > 0) ? false : true;
        }

        private string datosValidos(ConAgenda ag)
        {
            string st = string.Empty;

            // agrego validacion de profesionales.
            //DataTable dtProfesionales = (DataTable)ViewState["dtProfesionales"];          
            ConAgendaProfesionalCollection listaAgendaProfesional = new Select().From(Schemas.ConAgendaProfesional)
                             .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(ag.IdAgenda).ExecuteAsCollection<ConAgendaProfesionalCollection>();
            
            if (listaAgendaProfesional.Count==0)           
           //   st = "* Debe seleccionar un profesional y una especialidad y hacer clic en Agregar Profesional";
            {
                    ConAgendaProfesional agendaProfesional = new ConAgendaProfesional(ag.IdAgenda);

                    agendaProfesional.IdAgenda = ag.IdAgenda;
                    agendaProfesional.IdProfesional = int.Parse(ddlProfesional.SelectedValue);
                    agendaProfesional.IdEspecialidad = int.Parse(ddlEspecialidadXProfesional.SelectedValue);
                    agendaProfesional.Baja = false;

                    agendaProfesional.Save(SSOHelper.CurrentIdentity.Username);

                    ////agenda
                    ag.IdProfesional = int.Parse(ddlProfesional.SelectedValue);
                    ag.IdEspecialidad = int.Parse(ddlEspecialidadXProfesional.SelectedValue);
                    ag.Save();

                    llenarTablaProfesionales(ag.IdAgenda);
        }
            /////////////////////7
            if (ddlEstado.SelectedValue == "2" && txtActivacion.Text != string.Empty)
            {
                DateTime fact = Convert.ToDateTime(txtActivacion.Text);
                if (fact < DateTime.Now || fact > ag.Fecha)
                {
                    st = "* La fecha de activación es menor a hoy o mayor a la fecha de la agenda.";
                }
            }

            if (ddlEstado.SelectedValue == "3")
            {
                if (!noTieneTurnos(ag))
                {
                    st = "La agenda ya tiene turnos asignados. No es posible inactivar la misma. Mueva los turnos a una agenda activa.";
                }
                else
                {
                    if (ddlEstado.SelectedValue == "3" && ddlMotivoInactivacion.SelectedValue == "0")
                        st = "* Debe seleccionar motivo de inactivacion";
                }
            }
            else
            { // si no se desactiva la agenda verifica superposicion
                if (validaProfesionalAgenda(ag))
                {
                    st = "El profesional ya tiene asignada una agenda en el mismo horario ó";
                    st += Environment.NewLine + " la hora de inicio se superpone con otra agenda programada en el rango solicitado";
                    st += Environment.NewLine + " la hora de inicio se superpone con otra agenda programada en el rango solicitado ó";
                    st += Environment.NewLine + " la hora de finalización se superpone con otra agenda programada en el rango solicitado";
                }
            }

            return st;
        }


        //Valida que el profesional seleccionado no se encuentre asignado a otro agenda en el mismo horario.
        private bool validaProfesionalAgenda(ConAgenda agenda)
        {
            bool valido = false;

            int idProfesionalSeleccionado = int.Parse(ddlProfesional.SelectedValue);

            ConAgendaCollection listaAgendas = new SubSonic.Select().From(Schemas.ConAgenda)
            .Where(ConAgenda.Columns.Fecha).IsEqualTo(agenda.Fecha).ExecuteAsCollection<ConAgendaCollection>();

            foreach (ConAgenda dataAgenda in listaAgendas)
            {
                if (validaAgenda(dataAgenda))
                {
                    if (dataAgenda.Multiprofesional)
                    {
                        ConAgendaProfesionalCollection listaAgendaProfesional = new Select().From(Schemas.ConAgendaProfesional)
                            .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(dataAgenda.IdAgenda).ExecuteAsCollection<ConAgendaProfesionalCollection>();

                        foreach (ConAgendaProfesional data1 in listaAgendaProfesional)
                        {
                            if ((idProfesionalSeleccionado == data1.IdProfesional) && (agenda.IdAgenda != data1.IdAgenda))
                            {
                                valido = true;
                            }
                        }
                    }
                    else
                    {
                        if ((idProfesionalSeleccionado == dataAgenda.IdProfesional) && (agenda.IdAgenda != dataAgenda.IdAgenda))
                            valido = true;
                    }
                }
            }

            return valido;
        }

        private bool validaAgenda(ConAgenda agenda)
        {
            bool valido = false;

            ConAgenda ag = new ConAgenda(idAgenda);

            string hInicio = ag.HoraInicio.Remove(2, 1);
            string hFin = ag.HoraFin.Remove(2, 1);

            int horaInicio = int.Parse(hInicio);
            int horaFin = int.Parse(hFin);
            string fecha = ag.Fecha.ToShortDateString();

            if ((agenda.Fecha.ToShortDateString() == fecha) && (int.Parse(agenda.HoraInicio.Remove(2, 1)) >= horaInicio) && (int.Parse(agenda.HoraFin.Remove(2, 1)) <= horaFin))
            {
                valido = true;
            }


            return valido;
        }

        private bool rangoOcupado(ConAgenda ag, DateTime hIni, DateTime hFin)
        {
            bool ocupado = false;
            int idConsultorio = Convert.ToInt32(ddlConsultorio.SelectedValue);

            DataTable dt = new Select().From(Schemas.ConAgenda)
                                .Where(ConAgenda.Columns.IdAgenda)
                                .IsNotEqualTo(ag.IdAgenda)
                                .And(ConAgenda.Columns.Fecha)
                                .IsEqualTo(ag.Fecha)
                                .And(ConAgenda.Columns.IdConsultorio)
                                .IsNotEqualTo(ag.IdConsultorio).ExecuteDataSet().Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime inicioAgenda = Convert.ToDateTime(dt.Rows[i]["Fecha"].ToString().Substring(0, 10)
                                        + " " + sumarMinuto(dt.Rows[i]["horaInicio"].ToString()) + ":00");
                DateTime finAgenda = Convert.ToDateTime(dt.Rows[i]["Fecha"].ToString().Substring(0, 10)
                                        + " " + sumarMinuto(dt.Rows[i]["horaFin"].ToString()) + ":00");

                if (hIni >= inicioAgenda | hIni <= finAgenda) { ocupado = true; break; }
                if (hFin >= inicioAgenda | hIni <= finAgenda) { ocupado = true; break; }
            }

            return ocupado;
        }

        private string sumarMinuto(string hora)
        {
            int h = Convert.ToInt32(hora.Substring(0, 2));
            int m = Convert.ToInt32(hora.Substring(3, 2));

            if (m + 1 > 59)
            {
                h += 1; m = 0;
            }
            else
            {
                m += 1;
            }

            string hr = h.ToString();
            string min = m.ToString();
            if (hr.Length == 1) { hr = "0" + hr; }
            if (min.Length == 1) { min = "0" + min; }

            return hr + ":" + min;
        }

        private string restarMinuto(string h)
        {
            throw new NotImplementedException();
        }

        private string getHoraTurno(ConAgenda ag, bool pri)
        {
            ConTurnoCollection tc = new Select().From(Schemas.ConTurno)
                                                .Where(ConTurno.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                                                .OrderAsc(ConTurno.Columns.Hora)
                                                .ExecuteAsCollection<ConTurnoCollection>();
            return (pri) ? tc.First<ConTurno>().Hora : tc.Last<ConTurno>().Hora;
        }

        private void grabarAgenda(ConAgenda ag)
        {
            int idEstadoAgendaAnterior = ag.IdAgendaEstado;

            ag.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
            ag.IdServicio = Convert.ToInt32(ddlServicio.SelectedValue);
         //   ag.IdEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            //if ((ag.IdEspecialidad == 25) || (ag.IdEspecialidad == 50) || (ag.IdEspecialidad == 52))


            /// corrijo para que no guarde en la agenda valores -1

            ConAgendaProfesionalCollection listaAgendaProfesional = new Select().From(Schemas.ConAgendaProfesional)
                           .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(ag.IdAgenda).ExecuteAsCollection<ConAgendaProfesionalCollection>();
            int i_primeraEspecialidadSeleccionada = 0;
            int i_primerProfesionalSeleccionado = 0;

            foreach (ConAgendaProfesional data1 in listaAgendaProfesional)
            {
                if (i_primeraEspecialidadSeleccionada==0)                    
                {
                     i_primeraEspecialidadSeleccionada = data1.SysEspecialidad.IdEspecialidad;
                i_primerProfesionalSeleccionado = data1.SysProfesional.IdProfesional;
                }
            }

       
            ///////////////////////
            if (gdvListaProfesionales.Rows.Count > 1)
            {
                ag.Multiprofesional = true;
            }
            /*    ag.IdProfesional = i_primerProfesionalSeleccionado;
                ag.IdEspecialidad = i_primeraEspecialidadSeleccionada;
            }
            else
            {
                ag.IdProfesional = ag.IdProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
                ag.IdEspecialidad = Convert.ToInt32(ddlEspecialidadXProfesional.SelectedIndex);
            }*/


            ag.IdProfesional = i_primerProfesionalSeleccionado;
            ag.IdEspecialidad = i_primeraEspecialidadSeleccionada;

            ag.IdConsultorio = Convert.ToInt32(ddlConsultorio.SelectedValue);
            ag.IdAgendaEstado = Convert.ToInt32(ddlEstado.SelectedValue);
            ag.IdMotivoInactivacion = int.Parse(ddlMotivoInactivacion.SelectedValue);

            if (ddlEstado.SelectedValue.ToString() == "1")
            {
                if (idEstadoAgendaAnterior == 2)
                {
                    eliminarBloqueo(ag); /// si la agenda antes estaba bloqueada, además de grabarla activa, elimino el registro del bloqueo
                }
                ag.TurnosDisponibles = tieneTurnosDisponibles(ag);
            }
            else
            {
                ag.TurnosDisponibles = false; /// ==>> agendas bloqueadas no tienen turnos disponibles
                if (txtActivacion.Text != string.Empty) { grabarActivacion(ag); }

            }
            ag.Save();
            grabarAuditoria(ag);
        }

        private string getUltimaHoraIntercolsulta(ConAgenda ag)
        {
            DataTable dt = new Select().From(Schemas.ConTurnoReservaInterconsultum)
                                                        .Where(ConTurnoReservaInterconsultum.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                                                        .OrderDesc(ConTurnoReservaInterconsultum.Columns.HoraTurno)
                                                        .ExecuteDataSet().Tables[0];
            return dt.Rows[0]["HoraTurno"].ToString();
        }

        private bool tieneTurnosDisponibles(ConAgenda ag)
        {
            int cantidadTotal = getCantidadTotal(ag);
            int cantidadTurnos = getCantidadTurnos(ag);

            return (cantidadTurnos < cantidadTotal);
        }

        private int getCantidadTotal(ConAgenda ag)
        {
            DateTime fecha = ag.Fecha;
            string hora = ag.HoraInicio;
            string hFin = ag.HoraFin;
            int duracion = ag.Duracion;

            int cantidad = 0;

            DateTime hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            DateTime horafin1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hFin);

            do
            {
                cantidad += 1;
                hora = incrementarHora(hora, duracion);
                hora1 = DateTime.Parse(ag.Fecha.ToShortDateString() + " " + hora);
            } while (!(hora1 >= horafin1));

            return cantidad;
        }

        private string incrementarHora(string Hora, int duracion)
        {
            string h = Hora.Substring(0, 2);
            string m = Hora.Substring(3, 2);
            int horas = Convert.ToInt32(h);
            int minutos = Convert.ToInt32(m);

            minutos += duracion;
            while (minutos >= 60)
            {
                horas += 1;
                minutos -= 60;
            }
            m = minutos.ToString();
            h = horas.ToString();
            if (m.Length < 2) { m = "0" + m; }
            if (h.Length < 2) { h = "0" + h; }

            return h + ":" + m;
        }

        private int getCantidadTurnos(ConAgenda ag)
        {
            return new Select()
                        .From(Schemas.ConTurno)
                        .Where(ConTurno.Columns.IdAgenda)
                        .IsEqualTo(ag.IdAgenda)
                        .GetRecordCount();
        }

        private void eliminarBloqueo(ConAgenda ag)
        {
            Query i = new Query(Schemas.ConAgendaBloqueo);
            i.QueryType = QueryType.Delete;
            i.WHERE(ConAgendaBloqueo.Columns.IdAgenda, ag.IdAgenda);
            i.Execute();
        }

        private void grabarActivacion(ConAgenda ag)
        {
            ConAgendaBloqueo act = new ConAgendaBloqueo();
            DateTime fActivacion = Convert.ToDateTime(txtActivacion.Text);

            act.IdAgenda = ag.IdAgenda;
            act.IdUsuario = SSOHelper.CurrentIdentity.Id;
            act.FechaActivacion = fActivacion;
            act.AgendaActivada = false;
            act.Save();
        }

        private void grabarInterconsulta(ConAgenda ag, string ultimaHora)
        {
            // grabo el mismo idEfector (p/efector que solicite turnos) 
            // faltaría editar graficamente para que el usuario pueda decidir por parametros de reserva de interconsulta
            // idEfector, reservar hasta, y opcion para tomar últimos dos turnos de la agenda
            // o bien agregar dos mas al final

            //for (int i = 0; i < Convert.ToInt32(txtInterconsulta.Text); i++) {
            //    ConTurnoReservaInterconsultum inter = new ConTurnoReservaInterconsultum();

            //    inter.IdAgenda = ag.IdAgenda;
            //    inter.IdEfector = us.IdEfector; // grabo mismo efector = reservado para cualquiera
            //    inter.ReservaHasta = DateTime.Now; // grabo la reserva vencida => cambiar cuando esté operativo
            //    inter.HoraTurno = getHoraInterconsulta(i + 1, true, ultimaHora); // obtengo la cantidad de turnos especificados, 
            //    inter.Save();                                        // por defecto despues de la hora de fin
            //                                                         // con un check puedo cambiarlo
            //}
        }

        //private string getHoraInterconsulta(int i, bool agregar, string ultimaHora) {
        //    string hora = string.Empty;
        //    string h = string.Empty;
        //    string m = string.Empty;
        //    int duracion = Convert.ToInt32(txtDuracion.Text);

        //    h = ultimaHora.Substring(0, 2);
        //    m = ultimaHora.Substring(3, 2);
        //    int hs = Convert.ToInt32(h);
        //    int min = Convert.ToInt32(m);

        //    if (agregar) {
        //        min += (duracion * i);
        //    } else {
        //        min -= (duracion * i);
        //    }

        //    while (min >= 60) { if (agregar) { hs += 1; } else { hs -= 1; } min -= 60; }

        //    h = hs.ToString();
        //    m = min.ToString();

        //    if (h.Length == 1) { h = "0" + h; }
        //    if (m.Length == 1) { m = "0" + m; }
        //    hora = h + ":" + m;

        //    return hora;
        //}

        private void grabarAuditoria(ConAgenda ag)
        {
            string h = Convert.ToString(DateTime.Now.Hour);
            string m = Convert.ToString(DateTime.Now.Minute);
            if (h.Length < 2) { h = "0" + h; }
            if (m.Length < 2) { m = "0" + m; }
            string Hora = h + ":" + m;

            ConAgendaAuditorium aud = new ConAgendaAuditorium();
            aud.IdAgenda = ag.IdAgenda;
            aud.IdUsuario = SSOHelper.CurrentIdentity.Id;
            aud.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
            aud.IdAgendaEstado = ag.IdAgendaEstado;
            aud.IdServicio = ag.IdServicio;
            aud.IdProfesional = ag.IdProfesional;
            aud.IdEspecialidad = ag.IdEspecialidad;
            aud.IdConsultorio = ag.IdConsultorio;
            aud.Fecha = ag.Fecha;
            aud.HoraInicio = ag.HoraInicio;
            aud.HoraFin = ag.HoraFin;
            aud.Duracion = ag.Duracion;
            //     aud.Reservados = ag.Reservados;
            aud.MaxSobreturnos = ag.MaximoSobreturnos;
            aud.CitarPorBloques = 1; // ag.CitarPorBloques;
            aud.FechaModificacion = DateTime.Now;
            aud.HoraModificacion = Hora;
            aud.Save();
        }

        protected void ddlTipoConsultorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTipoConsultorio = Convert.ToInt32(ddlTipoConsultorio.SelectedValue.ToString());
            llenarConsultorios(idTipoConsultorio);
            btnReset.Enabled = true;
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int estado = Convert.ToInt32(ddlEstado.SelectedValue);

            string estadoAgenda = ddlEstado.SelectedItem.ToString();

            motivoInactivacion.Visible = (estadoAgenda == "Activa" || estadoAgenda == "Bloqueada") ? false : true;

            btnReset.Enabled = true;
            cmdFecha.Visible = (estado == 2) ? true : false;
            txtActivacion.Enabled = (estado == 2) ? true : false;
            txtActivacion.Focus();

            if (estadoAgenda == "3")
                rvMotivoInactivacion.Enabled = true;
            else
                rvMotivoInactivacion.Enabled = false;
        }

        protected void cmdFecha_Click(object sender, ImageClickEventArgs e)
        {
            txtActivacion.Focus();
        }

        protected void lnkAuditoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgendaAuditoria.aspx?idAgenda=" + idAgenda.ToString());
        }

        protected void lnkTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Turnos/TurnosAdmin.aspx?idAgenda=" + idAgenda.ToString());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            leerAgenda(idAgenda);
            btnReset.Enabled = false;
            updPanel.Update();
        }

        protected void txtActivacion_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        private bool validaProfesionalesDuplicados()
        {
            bool valida = false;

            string idProfesional = ddlProfesional.SelectedValue;

            foreach (GridViewRow row in gdvListaProfesionales.Rows)
            {
                string idProfTabla = row.Cells[0].Text;

                if (idProfTabla == idProfesional)
                    valida = true;
            }

            return valida;
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void ddlConsultorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void txtHini_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void txtHfin_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void txtDuracion_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void txtBloque_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void txtInterconsulta_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void txtReservados_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void txtSobreturnos_TextChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
        }

        protected void gdvListaProfesionales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gdvListaProfesionales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gdvListaProfesionales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gdvListaProfesionales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvListaProfesionales.EditIndex = e.NewEditIndex;

            llenarTablaProfesionales(idAgenda);
        }

        protected void gdvListaProfesionales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow row = (GridViewRow)gdvListaProfesionales.Rows[e.RowIndex];

            ConAgendaProfesional.Delete(gdvListaProfesionales.DataKeys[e.RowIndex].Value.ToString());

            llenarTablaProfesionales(idAgenda);
        }

        protected void imgAgregarProfesionales_Click(object sender, ImageClickEventArgs e)
        {
            AgregarProfesionales();
        }

        private void AgregarProfesionales()
        {
            if (Page.IsValid)
            {
                //   int idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);

                ConAgenda ag = new ConAgenda(idAgenda);

                string st = datosValidos(ag);

                if (validaProfesionalesDuplicados())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('El profesional ya se encuentra agregado.');", true);
                }
                else
                { 
                    if (String.IsNullOrEmpty(st))
                    {
                        ConAgendaProfesional agendaProfesional = new ConAgendaProfesional();

                        agendaProfesional.IdAgenda = idAgenda;
                        agendaProfesional.IdProfesional = int.Parse(ddlProfesional.SelectedValue);
                        agendaProfesional.IdEspecialidad = int.Parse(ddlEspecialidadXProfesional.SelectedValue);
                        agendaProfesional.Baja = false;

                        agendaProfesional.Save(SSOHelper.CurrentIdentity.Username);                        

                        llenarTablaProfesionales(idAgenda);

                        divErr.Visible = false;
                        btnReset.Enabled = true;
                    }
                    else
                    {
                        st = "El profesional ya tiene asignada una agenda en el mismo horario ó";
                        st += Environment.NewLine + " la hora de inicio se superpone con otra agenda programada en el rango solicitado";
                        st += Environment.NewLine + " la hora de inicio se superpone con otra agenda programada en el rango solicitado ó";
                        st += Environment.NewLine + " la hora de finalización se superpone con otra agenda programada en el rango solicitado";

                        lblError.Text = st;
                        divErr.Visible = true;
                    }
                }
            }
            else
            {
                imgErr.Src = "../../App_Themes/consultorio/Agenda/boton-de-error-icono-5371-48.png";
                lblError.Text = "Errores en datos ingresados marcados con asterisco";
                divErr.Visible = true;
                updPanel.Update();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
             ConAgenda ag = new ConAgenda(idAgenda);

                string st = datosValidos(ag);

                if (st == string.Empty)
                    Response.Redirect("AgendaList.aspx", false);
                 
        }
    }
}
