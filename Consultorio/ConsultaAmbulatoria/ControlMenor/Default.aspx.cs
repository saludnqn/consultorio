using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using System.Transactions;
using SubSonic;
using Consultorio.ConsultaAmbulatoria.UserControls;

namespace Consultorio.ConsultaAmbulatoria.ControlMenor
{
    public partial class Default : System.Web.UI.Page
    {
        public int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        public bool vieneEnfermeria
        {
            get { return ViewState["vieneEnfermeria"] == null ? false : Convert.ToBoolean(ViewState["vieneEnfermeria"]); }
            set { ViewState["vieneEnfermeria"] = value; }
        }

        public int idVisita
        {
            get { return ViewState["idVisita"] == null ? 0 : Convert.ToInt32(ViewState["idVisita"]); }
            set { ViewState["idVisita"] = value; }
        }

        public bool controlMedico
        {
            get { return ViewState["controlMedico"] == null ? false : Convert.ToBoolean(ViewState["controlMedico"]); }
            set { ViewState["controlMedico"] = value; }
        }

        public bool controlEnfermeria
        {
            get { return ViewState["controlEnfermeria"] == null ? false : Convert.ToBoolean(ViewState["controlEnfermeria"]); }
            set { ViewState["controlEnfermeria"] = value; }
        }

        public bool controlOdontologico
        {
            get { return ViewState["controlOdontologico"] == null ? false : Convert.ToBoolean(ViewState["controlOdontologico"]); }
            set { ViewState["controlOdontologico"] = value; }
        }

        public bool controlHemoglobina
        {
            get { return ViewState["controlHemoglobina"] == null ? false : Convert.ToBoolean(ViewState["controlHemoglobina"]); }
            set { ViewState["controlHemoglobina"] = value; }
        }

        public string returnUrl
        {
            get { return ViewState["returnUrl"] == null ? "" : (string)ViewState["returnUrl"]; }
            set { ViewState["returnUrl"] = value; }
        }

        private bool error = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            // En caso que no sea un postback, guardamos la url de retorno
            returnUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();

            // En caso que no haya una Url de retorno, no habilitamos el botón cancelar
            btnCancelar.Enabled = !String.IsNullOrEmpty(returnUrl);
            //si viene del link de enfermeria
            int idEnf;
            if (Int32.TryParse(Request.QueryString["enfermeria"], out idEnf))
            {
                vieneEnfermeria = idEnf == 1;
                //Oculto el resto de las pestañas 
                liConsultorio.Visible = false;
                tabConsultorio.Visible = false;

                liControlOdontologico.Visible = false;
                tabControlOdontologico.Visible = false;

                liEstadoNutricional.Visible = false;
                tabEstadoNutricional.Visible = false;

                liAreasDesarrollo.Visible = false;
                tabAreasDesarrollo.Visible = false;

                liFactoresRiesgo.Visible = false;
                tabFactoresRiesgo.Visible = false;

                liFactoresProtectores.Visible = false;
                tabFactoresProtectores.Visible = false;

                liControlOdontologico.Visible = false;
                tabControlOdontologico.Visible = false;

                liControlHemoglobina.Visible = false;
                tabControlHemoglobina.Visible = false;

                liControl.Visible = false;
                tabControl.Visible = false;
            }

            int idTemp;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp))
            {
                idPaciente = idTemp;
                ConsultaAmbulatoria1.idPaciente = idPaciente;
                ConsultaAmbulatoria1.SetDiagnosticoPrincipal(9449); //11830
            }

            //De acuerdo a la visita selecciono las pestañas que se van a guardar
            int tempVisita = 0;
            if (Int32.TryParse(Request.QueryString["visita"], out tempVisita))
            {
                AprCalendarioVisita oVisita = new AprCalendarioVisita(tempVisita);
                if (!oVisita.IsNew)
                {
                    idVisita = oVisita.IdCalendarioVisitas;
                    controlEnfermeria = oVisita.Enfermeria;
                    controlMedico = oVisita.Medico;
                    controlOdontologico = oVisita.Odontologia;
                    controlHemoglobina = oVisita.Hemoglobina;
                    //Muestro u oculto las diferentes pestañas de acuerdo al calendario
                    //Consultorio deberia mmostrarse siempre?
                    liConsultorio.Visible = true;
                    tabConsultorio.Visible = true;

                    liEstadoNutricional.Visible = oVisita.Medico;
                    tabEstadoNutricional.Visible = oVisita.Medico;

                    liEnfermeria.Visible = oVisita.Enfermeria;
                    tabEnfermeria.Visible = oVisita.Enfermeria;

                    liAreasDesarrollo.Visible = oVisita.Medico;
                    tabAreasDesarrollo.Visible = oVisita.Medico;

                    liFactoresRiesgo.Visible = oVisita.Medico;
                    tabFactoresRiesgo.Visible = oVisita.Medico;

                    liFactoresProtectores.Visible = oVisita.Medico;
                    tabFactoresProtectores.Visible = oVisita.Medico;

                    liControlOdontologico.Visible = oVisita.Odontologia;
                    tabControlOdontologico.Visible = oVisita.Odontologia;

                    liControlHemoglobina.Visible = oVisita.Hemoglobina;
                    tabControlHemoglobina.Visible = oVisita.Hemoglobina;
                    //Si muestro la pestaña de Hemoglobina, reviso
                    //si el analisis ya fue hecho
                    ControlHemoglobina1.comprobarAnalisis(idPaciente);

                    //La pestaña de Proximo Control esta siempre Visible
                    liControl.Visible = true;
                    tabControl.Visible = true;

                    //Cargo los alertas de acuerdo a la visita
                    AlertasControlMenor1.SetAlertas(tempVisita);

                    //Calculo cuando va a ser la fecha de la proxima visita
                    SysPaciente oPaciente = new SysPaciente(idPaciente);
                    AprCalendarioVisita oProximaVisita = new AprCalendarioVisita(oVisita.IdCalendarioVisitas + 1);
                    if (!oPaciente.IsNew && !oProximaVisita.IsNew)
                    {
                        DateTime ofecha = oPaciente.FechaNacimiento.AddDays(oProximaVisita.EdadSemanas * 7);
                        Control1.fechaProximaVisita = ofecha;
                    }
                }
                else
                {
                    Master.Message("No se puede obtener la fecha de la visita de salud", MessageStatus.error);
                }
            }
            else
            {
                Master.Message("No se puede obtener la fecha de la visita de salud", MessageStatus.error);
            }
        }

        private AprControlNiñoSanoConsultorio ControlConsultorio()
        {
            AprControlNiñoSanoConsultorio oConsultorio = null;
            bool datoscargados = false;
            ResultadoEstadoNutricional oEstadoNutricional = null;
            ResultadoAreasDesarrollo oAreasDesarrollo = null;
            ResultadoFactorRiesgo oFactoresRiesgo = null;
            ResultadoFactorProtector oFactoresProtectores = null;
            if (controlMedico)
            {
                oEstadoNutricional = EstadoNutricional1.getDatos();
                if (oEstadoNutricional.Estado != MessageStatus.ok)
                {
                    error = true;
                    Master.Message(oEstadoNutricional.Estado, "Pestaña Tipo Alimentacion", oEstadoNutricional.mensaje);
                }
                else
                {
                    datoscargados = oEstadoNutricional.idTipoLactancia.HasValue || oEstadoNutricional.idIntervencion.HasValue;
                }

                oAreasDesarrollo = AreasDesarrollo1.getDatos();
                if (oAreasDesarrollo.Estado != MessageStatus.ok)
                {
                    error = true;
                    Master.Message(oAreasDesarrollo.Estado, "Pestaña Areas Desarrollo", oAreasDesarrollo.mensaje);
                }
                else
                {
                    datoscargados = datoscargados || oAreasDesarrollo.desarrollos.Count > 0;
                }

                oFactoresRiesgo = FactoresRiesgo1.getDatos();
                if (oFactoresRiesgo.Estado != MessageStatus.ok)
                {
                    error = true;
                    Master.Message(oFactoresRiesgo.Estado, "Pestaña Factores de Riesgo", oAreasDesarrollo.mensaje);
                }
                else
                {
                    datoscargados = datoscargados || oFactoresRiesgo.factoresriesgo.Count > 0;
                }

                oFactoresProtectores = FactoresProtectores1.getDatos();
                if (oFactoresProtectores.Estado != MessageStatus.ok)
                {
                    error = true;
                    Master.Message(oFactoresProtectores.Estado, "Pestaña Factores Protectores", oFactoresProtectores.mensaje);
                }
                else
                {
                    datoscargados = datoscargados || oFactoresProtectores.factoresprotectores.Count > 0;
                }
            }
            ResultadoControl oControl = Control1.getDatos();
            if (oControl.Estado != MessageStatus.ok)
            {
                error = true;
                Master.Message(oControl.Estado, "Pestaña Control", oControl.mensaje);
            }
            else
            {
                datoscargados = datoscargados || (oControl.observacion.Length > 0 || oControl.fechaproximocontrol.HasValue);
            }

            if (!error && datoscargados)
            {
                oConsultorio = new AprControlNiñoSanoConsultorio();
                if (controlMedico)
                {
                    //Estado Nutricional
                    oConsultorio.IdTipoLactancia = oEstadoNutricional.idTipoLactancia;
                    oConsultorio.IdIntervencion = oEstadoNutricional.idIntervencion;
                    //Areas Desarrollo
                    oConsultorio.AprRelControlNiñoSanoAreaDesarrolloRecords = oAreasDesarrollo.desarrollos;
                    //Factores de Riesgo
                    oConsultorio.AprRelControlNiñoSanoFactorRiesgoRecords = oFactoresRiesgo.factoresriesgo;
                    //Factores Protectores
                    oConsultorio.AprRelControNiñoSanoFactorProtectorRecords = oFactoresProtectores.factoresprotectores;
                }
                //Control
                oConsultorio.FechaProximoControl = oControl.fechaproximocontrol;
                if (oControl.observacion.Length > 0)
                    oConsultorio.Observacion = oControl.observacion;

                //Devuelvo el control con los datos completos
                return oConsultorio;
            }

            //Ocurrio un error o no se cargo ningun dato interesante
            //devuelvo el control vacio
            return oConsultorio;
        }

        private AprControlNiñoSanoEnfermerium ControlEnfermeria()
        {
            //Obtengo la enfermeria
            ResultadoEnfermeria oResultadoEnfermeria = Enfermeria1.getDatos();
            AprControlNiñoSanoEnfermerium oEnfermeria = null;
            if (oResultadoEnfermeria.Estado == MessageStatus.ok)
            {
                if (oResultadoEnfermeria.peso > 0 || oResultadoEnfermeria.talla > 0 || oResultadoEnfermeria.perimetrocefalico > 0)
                {
                    //Se cargó algun dato, lo guardo en el registro de enfermeria
                    oEnfermeria = new AprControlNiñoSanoEnfermerium();
                    if (oResultadoEnfermeria.peso > 0)
                        oEnfermeria.Peso = oResultadoEnfermeria.peso;
                    if (oResultadoEnfermeria.talla > 0)
                        oEnfermeria.Talla = oResultadoEnfermeria.talla;
                    if (oResultadoEnfermeria.perimetrocefalico > 0)
                        oEnfermeria.PerimetroCefalico = oResultadoEnfermeria.perimetrocefalico;
                    if (oResultadoEnfermeria.estadonutricional > 0)
                        oEnfermeria.IdEstadoNutricional = oResultadoEnfermeria.estadonutricional;
                    if (oResultadoEnfermeria.tallaedad > 0)
                        oEnfermeria.IdTallaEdad = oResultadoEnfermeria.tallaedad;
                    //nuevos datos
                    oEnfermeria.IdPaciente = oResultadoEnfermeria.paciente;
                    if (oResultadoEnfermeria.ta != "")
                        oEnfermeria.Ta = oResultadoEnfermeria.ta;
                    oEnfermeria.FechaControl = oResultadoEnfermeria.fecha;
                    if (oResultadoEnfermeria.observacion != "")
                        oEnfermeria.Observaciones = oResultadoEnfermeria.observacion;
                    if (oResultadoEnfermeria.profesional > 0)
                        oEnfermeria.IdProfesional = oResultadoEnfermeria.profesional;
                    //si viene de enfermeria guardo el idControlNiñoSano=0
                    if (vieneEnfermeria == true)
                    {
                        oEnfermeria.IdControlNiñoSano = 0;
                    }
                    return oEnfermeria;
                }
                else
                {
                    //No se cargo ningun dato devuelvo null.
                    return oEnfermeria;
                }
            }
            else
            {
                error = true;
                Master.Message(oResultadoEnfermeria.Estado, "Pestaña Enfermeria", oResultadoEnfermeria.mensaje);
                return oEnfermeria;
            }
        }

        private AprControlNiñoSanoHemoglobina ControlHemoglobina()
        {
            AprControlNiñoSanoHemoglobina oControlHemoglobina = null;

            ResultadoHemoglobina oResultadoHemoglobina = ControlHemoglobina1.getDatos();
            if (controlHemoglobina)
            {
                if (oResultadoHemoglobina.Estado == MessageStatus.ok)
                {
                    if (oResultadoHemoglobina.resultado > 0)
                    {
                        oControlHemoglobina = new AprControlNiñoSanoHemoglobina();
                        oControlHemoglobina.Valor = oResultadoHemoglobina.resultado;
                        oControlHemoglobina.IdPaciente = idPaciente;
                    }
                }
                else
                {
                    error = true;
                    Master.Message(oResultadoHemoglobina.Estado, "Pestaña Analisis Hemoglobina", oResultadoHemoglobina.mensaje);
                }
            }

            return oControlHemoglobina;
        }

        private AprControlNiñoSanoOdontologico ControlOdontologico()
        {
            AprControlNiñoSanoOdontologico oControlOdontologico = null;
            ResultadoControlOdontologico oResultadoControlodontologico = ControlOdontologico1.getDatos();
            if (controlOdontologico)
            {
                if (oResultadoControlodontologico.Estado == MessageStatus.ok)
                {
                    oControlOdontologico = new AprControlNiñoSanoOdontologico();
                    oControlOdontologico.IdDiagnosticoControlOdontologico = oResultadoControlodontologico.idDiagnostico.Value;
                    oControlOdontologico.Profesional = oResultadoControlodontologico.profesional;
                    if (oResultadoControlodontologico.observacion.Length > 0)
                        oControlOdontologico.Observacion = oResultadoControlodontologico.observacion;
                }
                else
                {
                    error = true;
                    Master.Message(oResultadoControlodontologico.Estado, "Pestaña Control Odontologico", oResultadoControlodontologico.mensaje);
                }
            }
            return oControlOdontologico;
        }

        private ConConsultum ConsultaAmbulatoria()
        {
            ConConsultum oConsulta = null;
            ResultadoConsulta oResultadoConsulta = ConsultaAmbulatoria1.getDatos();
            if (oResultadoConsulta.Estado == MessageStatus.ok)
            {
                oConsulta = new ConConsultum();
                oConsulta.FechaRegistro = DateTime.Now;
                oConsulta.Fecha = oResultadoConsulta.fecha;
                if (oResultadoConsulta.hora.Length > 0)
                    oConsulta.Hora = oResultadoConsulta.hora;

                oConsulta.IdProfesional = oResultadoConsulta.profesional;
                oConsulta.IdEspecialidad = oResultadoConsulta.especialidad;

                if (oResultadoConsulta.motivo.Length > 0)
                    oConsulta.MotivoConsulta = oResultadoConsulta.motivo;
                if (oResultadoConsulta.informe.Length > 0)
                    oConsulta.InformeConsulta = oResultadoConsulta.informe;
                //   oConsulta.ConConsultaDiagnosticoRecords = oResultadoConsulta.diagnosticos; ????
                oConsulta.ConConsultaMedicamentoRecords = oResultadoConsulta.medicamentos;
                //oConsulta.PrimerConsulta = oResultadoConsulta.primerconsulta;
                // Buscamos el usuario.
                SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
                // Guardamos las cositas que faltaban.
                oConsulta.IdUsuarioRegistro = oUsuario.IdUsuario;
                oConsulta.IdEfector = oUsuario.IdEfector;
                oConsulta.IdPaciente = idPaciente;
                SysPaciente oPaciente = new SysPaciente(idPaciente);
                if (oPaciente != null)
                    oConsulta.IdObraSocial = oPaciente.IdObraSocial;
            }
            else
            {
                error = true;
                Master.Message(oResultadoConsulta.Estado, "Pestaña Consultorio", oResultadoConsulta.mensaje);
            }
            return oConsulta;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(returnUrl);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Paciente/PacienteView.aspx?id={0}", idPaciente));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Recupero la consulta
            ConConsultum oConsulta = ConsultaAmbulatoria();
            //recupero el control de enfermeria
            AprControlNiñoSanoEnfermerium oControlEnfermeria = ControlEnfermeria();
            //recupero el control de consultorio
            AprControlNiñoSanoConsultorio oControlConsultorio = ControlConsultorio();
            //recupero el control odontologico
            AprControlNiñoSanoOdontologico oControlOdontologico = ControlOdontologico();
            //recupero el analisis de hemoglobina
            AprControlNiñoSanoHemoglobina oControlHemoglobina = ControlHemoglobina();

            if ((oConsulta != null) && (vieneEnfermeria == false))
            {
                //Genero la relacion abstracta para guardar la consulta del menor
                AprControlNiñoSano oControl = new AprControlNiñoSano();
                oControl.IdCalendarioVisitas = idVisita;
                oControl.Edad = new Utilidades.DateDifference(new SysPaciente(idPaciente).FechaNacimiento, DateTime.Now).FullDays;

                if (oControlEnfermeria != null)
                {
                    oControl.AprControlNiñoSanoEnfermeria.Add(oControlEnfermeria);
                    oConsulta.AprControlNiñoSanoRecords.Add(oControl);
                }
                if (oControlConsultorio != null)
                {
                    oControl.AprControlNiñoSanoConsultorioRecords.Add(oControlConsultorio);
                    oConsulta.AprControlNiñoSanoRecords.Add(oControl);
                }
                if (oControlOdontologico != null)
                {
                    oControl.AprControlNiñoSanoOdontologicoRecords.Add(oControlOdontologico);
                    oConsulta.AprControlNiñoSanoRecords.Add(oControl);
                }
                if (oControlHemoglobina != null)
                {
                    oControl.AprControlNiñoSanoHemoglobinaRecords.Add(oControlHemoglobina);
                    oConsulta.AprControlNiñoSanoRecords.Add(oControl);
                }

                //if (!error)
                //{
                //    using (TransactionScope ts = new TransactionScope())
                //    {
                //        using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                //        {
                //            try
                //            {
                //              //  oConsulta.Save(Master.Usuario.Username);
                //              ////  oConsulta.ConConsultaDiagnosticoRecords.SaveAll(Master.Usuario.Username);  ???
                //              //  oConsulta.ConConsultaMedicamentoRecords.SaveAll(Master.Usuario.Username);
                //              //  oConsulta.AprControlNiñoSanoRecords.SaveAll(Master.Usuario.Username); /*error al insertar un key en APR_Calendariovacunacion*/
                //              //  foreach (AprControlNiñoSano acn in oConsulta.AprControlNiñoSanoRecords)
                //              //  {
                //              //      acn.AprControlNiñoSanoEnfermeria.SaveAll(Master.Usuario.Username);
                //              //      acn.AprControlNiñoSanoOdontologicoRecords.SaveAll(Master.Usuario.Username);
                //              //      acn.AprControlNiñoSanoHemoglobinaRecords.SaveAll(Master.Usuario.Username);
                //              //      acn.AprControlNiñoSanoConsultorioRecords.SaveAll(Master.Usuario.Username);
                //              //      foreach (AprControlNiñoSanoConsultorio ocon in acn.AprControlNiñoSanoConsultorioRecords)
                //              //      {
                //              //          ocon.AprRelControlNiñoSanoAreaDesarrolloRecords.SaveAll(Master.Usuario.Username);
                //              //          ocon.AprRelControlNiñoSanoFactorRiesgoRecords.SaveAll(Master.Usuario.Username);
                //              //          ocon.AprRelControNiñoSanoFactorProtectorRecords.SaveAll(Master.Usuario.Username);
                //              //      }
                //              //  }
                //            } ts.Complete();

                //                Master.Message("La consulta se guardo con exito.", MessageStatus.ok);
                //            }
                //            catch (Exception ex)
                //            {
                //                ts.Dispose();
                //                List<string> m = new List<string>();
                //                while (ex != null)
                //                {
                //                    m.Add(ex.Message);
                //                    ex = ex.InnerException;
                //                }
                //                Master.Message(MessageStatus.error, "Error al guardar", m);
                //            }
                //        }
                //    }
                //}
                // }
                // agrego el else para guardar solo los datos de enfermeria
                // y el apr_controlniñosano con idcalendariovacunas= 0 y poder llenar el plot con las graficas
                //else
                //{
                //    if (vieneEnfermeria == true)
                //    {
                //        //Aca pierdo los datos del control de enfermeria
                //        AprControlNiñoSanoEnfermerium oControl = new AprControlNiñoSanoEnfermerium(idPaciente);
                //        oControl.IdControlNiñoSano = 0;
                //        if (oControlEnfermeria != null)
                //        {
                //                oControlEnfermeria.Save(Master.Usuario.Username);
                //         }
                //        Master.Message("La consulta se guardo con exito.", MessageStatus.ok);
                //    }
                //    else
                //        Master.Message("Error al guardar", MessageStatus.ok);
                //}
            }
        }
    }
}