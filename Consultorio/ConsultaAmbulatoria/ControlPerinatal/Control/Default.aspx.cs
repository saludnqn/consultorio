using DalSic;
using Salud.Security.SSO;
using Consultorio.Utilidades;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using System.Data;

namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.Control
{

    static class globales
    {

        public static int activaAlertas;
    }


    public partial class Default : System.Web.UI.Page
    {

     
        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        private int idConsulta
        {
            get { return ViewState["idConsulta"] == null ? 0 : Convert.ToInt32(ViewState["idConsulta"]); }
            set { ViewState["idConsulta"] = value; }
        }

        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        private int idHistoriaClinicaPerinatalDetalle
        {
            get { return ViewState["idHistoriaClinicaPerinatalDetalle"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatalDetalle"]); }
            set { ViewState["idHistoriaClinicaPerinatalDetalle"] = value; }
        }

        private bool controlOdontologicoAnormal
        {
            get { return ViewState["controlOdontologicoAnormal"] == null ? false : Convert.ToBoolean(ViewState["controlOdontologicoAnormal"]); }
            set { ViewState["controlOdontologicoAnormal"] = value; }
        }

        private bool tallerPsicoprofilaxisRealizado
        {
            get { return ViewState["tallerPsicoprofilaxisRealizado"] == null ? false : Convert.ToBoolean(ViewState["tallerPsicoprofilaxisRealizado"]); }
            set { ViewState["tallerPsicoprofilaxisRealizado"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            CargarEfectores();

            //Activa el alerta de que se borro el detalle de la historiaclinica perinatal.
            if(globales.activaAlertas == 1){

                ClientScript.RegisterStartupScript(GetType(), "MostraralertaOFF", "alertaDeQueSeBorro();", true);
                globales.activaAlertas = 0;
            }
            //Activa el alerta de que se actualizo el detalle de la historia clinica perinatal.
             if(globales.activaAlertas == 2){

            ClientScript.RegisterStartupScript(GetType(), "MostraralertaOK", "alertaDeQueSeGuardo();", true);
            globales.activaAlertas = 0;
             }
             //Activa el alerta de que se guardo la historia clinica perinatal.
             if (globales.activaAlertas == 3)
             {

                 ClientScript.RegisterStartupScript(GetType(), "MostraralertaOK", "alertaDeQueSeGuardo();", true);
                 globales.activaAlertas = 0;
             }

            int idHCPDTemp;
            if (Int32.TryParse(Request.QueryString["IdHistoriaClinicaPerinatalDetalle"], out idHCPDTemp))
            {
                //Muestra modal si encuentra id HCPD

                int HCPDjs = idHCPDTemp;
                AprHistoriaClinicaPerinatalDetalle oDetalle = new SubSonic.Select().From(Schemas.AprHistoriaClinicaPerinatalDetalle)
                   .Where(AprHistoriaClinicaPerinatalDetalle.Columns.IdHistoriaClinicaPerinatalDetalle).IsEqualTo(HCPDjs)
                   .And(AprHistoriaClinicaPerinatalDetalle.Columns.Activa).IsEqualTo(true)
                   .ExecuteSingle<AprHistoriaClinicaPerinatalDetalle>();
                if (oDetalle != null)
                {
                    txtDetalleFecha2.Text = oDetalle.Fecha.HasValue ? oDetalle.Fecha.Value.ToShortDateString() : "";
                    txtDetalleEdadGestacional2.Text = oDetalle.EdadGestacional.HasValue ? oDetalle.EdadGestacional.Value.ToString() : "";
                    txtDetallePeso2.Text = oDetalle.Peso.HasValue ? oDetalle.Peso.Value.ToString() : "";
                    if (!string.IsNullOrEmpty(oDetalle.Pa))
                    {
                        string[] pa = oDetalle.Pa.Split('/');
                        if (pa.Count() == 2)
                        {
                            txtDetallePresionArterialSistolica2.Text = pa[0];
                            txtDetallePresionArterialDistolica2.Text = pa[1];
                        }
                    }
                    txtDetallePresentacion2.Text = oDetalle.Presentacion;
                    txtDetalleFrecuenciaCardiacaFetal2.Text = oDetalle.Fcf.HasValue ? oDetalle.Fcf.Value.ToString() : "";
                    txtDetalleMovimientosFetales2.Text = oDetalle.MovimientosFetales;
                    txtDetalleProteinuria2.Text = oDetalle.Proteinuria;
                    txtDetalleAlarmaExamenesTratamientos2.Text = oDetalle.AlarmaExamenesTratamientos;
                    txtDetallesInicialesTecnico2.Text = oDetalle.InicialesTecnico;
                    txtDetalleProximaCita2.Text = oDetalle.ProximaCita.HasValue ? oDetalle.ProximaCita.Value.ToShortDateString() : "";
                    txtDetalleIMC2.Text = oDetalle.Imc.HasValue ? oDetalle.Imc.Value.ToString() : "";
                    txtDetalleObservaciones2.Text = oDetalle.Observaciones;
                    txtDetalleAlturaUterina2.Text = oDetalle.AlturaUterina.HasValue ? oDetalle.Imc.Value.ToString() : "";
                }



                ClientScript.RegisterStartupScript(GetType(), "MostrarModal", "ModalDetalles();", true);


            }



            int id, idConsultaTemp;
            //ALta de nuevo control perinatal
            if (Int32.TryParse(Request.QueryString["IdPaciente"], out id))
            {
                AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal();
                if (oHCP.IsNew)
                {
                    if (Int32.TryParse(Request.QueryString["idConsulta"], out idConsultaTemp))
                    {
                        idConsulta = idConsultaTemp;
                        cargarDatosDetalle(idConsultaTemp);
                    }

                    SysPaciente oPaciente = new SysPaciente(id);
                    idPaciente = oPaciente.IdPaciente;

                    //Carolina: esta es la validacion que hay que comentar para permitir cargar una nueva ficha
                    // a pesar de tener una ficha abierta
                    //Verifico si tiene alguna Historia perinatal Abierta
                    AprHistoriaClinicaPerinatal oHistoria = new SubSonic.Select()
                    .From(AprHistoriaClinicaPerinatal.Schema)
                    .Where(AprHistoriaClinicaPerinatal.Columns.IdHistoriaClinicaPerinatal)
                    .IsEqualTo(oHCP.IdHistoriaClinicaPerinatal)
                    .ExecuteSingle<AprHistoriaClinicaPerinatal>();
                    if ((oHistoria == null) || (oHistoria.Activa == false))
                    {
                        CargarDatosDelPaciente(oPaciente);
                    }
                    else
                    {
                        if (oHistoria.Activa == true)
                        {
                            CargarDatosDeHistoriaClinica(oHistoria);
                            idHistoriaClinicaPerinatal = oHistoria.IdHistoriaClinicaPerinatal;
                        }
                    }
                    /// fin de validacion
                    /// 

                    //Verifico si realizo el taller de psicoprofilaxis
                    AprActividadControlPerinatal oActividad = new SubSonic.Select()
                    .From(AprActividadControlPerinatal.Schema)
                    .Where(AprActividadControlPerinatal.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(oHCP.IdHistoriaClinicaPerinatal)
                    .And(AprActividadControlPerinatal.Columns.IdActividadEmbarazo).IsEqualTo(13)//Control Psicoprofilaxis
                    .ExecuteSingle<AprActividadControlPerinatal>();

                    tallerPsicoprofilaxisRealizado = oActividad != null;
                }
            }
            
            if (Int32.TryParse(Request.QueryString["IdHistoriaClinicaPerinatal"], out id))
            {
                AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal(id);
                if (!oHCP.IsNew)
                {
                    if (Int32.TryParse(Request.QueryString["idConsulta"], out idConsultaTemp))
                    {
                        idConsulta = idConsultaTemp;
                        cargarDatosDetalle(idConsultaTemp);
                    }

                    SysPaciente oPaciente = new SysPaciente(oHCP.IdPaciente);
                    idPaciente = oPaciente.IdPaciente;                 

                    AprHistoriaClinicaPerinatal oHistoria = new SubSonic.Select()
                    .From(AprHistoriaClinicaPerinatal.Schema)
                    .Where(AprHistoriaClinicaPerinatal.Columns.IdHistoriaClinicaPerinatal)
                    .IsEqualTo(oHCP.IdHistoriaClinicaPerinatal)
                    .ExecuteSingle<AprHistoriaClinicaPerinatal>();

                    if ((oHistoria == null) || (oHistoria.Activa == false))
                    {
                        CargarDatosDelPaciente(oPaciente);
                        btnGuardar.Enabled = false;
                        printPanel.Enabled = false;
                    }
                    else
                    {
                        if (oHistoria.Activa == true)
                        {
                            CargarDatosDeHistoriaClinica(oHistoria);
                            idHistoriaClinicaPerinatal = oHistoria.IdHistoriaClinicaPerinatal;
                            btnGuardar.Enabled = true;
                            printPanel.Enabled = true;
                        }
                    }
                    /// fin de validacion
                    /// 

                    //Verifico si realizo el taller de psicoprofilaxis
                //    AprActividadControlPerinatal oActividad = new SubSonic.Select()
                //    .From(AprActividadControlPerinatal.Schema)
                //    .Where(AprActividadControlPerinatal.Columns.IdPaciente).IsEqualTo(oPaciente.IdPaciente)
                //    .And(AprActividadControlPerinatal.Columns.IdActividadEmbarazo).IsEqualTo(13)//Control Psicoprofilaxis
                //    .ExecuteSingle<AprActividadControlPerinatal>();

                //    tallerPsicoprofilaxisRealizado = oActividad != null;
                }
            }

        }

        private void CargarEfectores()
        {
            //cargo efector de traslado intrauterino
            SubSonic.Select ef = new SubSonic.Select(new string[] { "idEfector, nombre, nombreNacion" });
            ef.From(SysEfector.Schema);
            //ef.Where(SysEfector.IdTipoEfectorColumn).IsEqualTo(2);
            ef.And(SysEfector.NombreColumn).StartsWith("H");
            ef.OrderAsc("nombre");
            ddlEfectorTraslado.DataSource = ef.ExecuteTypedList<SysEfector>();
            ddlEfectorTraslado.DataBind();
            ddlEfectorTraslado.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        private void cargarDatosDetalle(int id)
        {
            AprHistoriaClinicaPerinatalDetalle oDetalle = new SubSonic.Select().From(Schemas.AprHistoriaClinicaPerinatalDetalle)
                .Where(AprHistoriaClinicaPerinatalDetalle.Columns.IdConsulta).IsEqualTo(id)
                .And(AprHistoriaClinicaPerinatal.Columns.Activa).IsEqualTo(true)
                .And(AprHistoriaClinicaPerinatalDetalle.Columns.Activa).IsEqualTo(true)
                .ExecuteSingle<AprHistoriaClinicaPerinatalDetalle>();
            if (oDetalle != null)
            {
                txtDetalleFecha.Text = oDetalle.Fecha.HasValue ? oDetalle.Fecha.Value.ToShortDateString() : "";
                txtDetalleEdadGestacional.Text = oDetalle.EdadGestacional.HasValue ? oDetalle.EdadGestacional.Value.ToString() : "";
                txtDetallePeso.Text = oDetalle.Peso.HasValue ? oDetalle.Peso.Value.ToString() : "";
                if (!string.IsNullOrEmpty(oDetalle.Pa))
                {
                    string[] pa = oDetalle.Pa.Split('/');
                    if (pa.Count() == 2)
                    {
                        txtDetallePresionArterialSistolica.Text = pa[0];
                        txtDetallePresionArterialDistolica.Text = pa[1];
                    }
                }
                txtDetallePresentacion.Text = oDetalle.Presentacion;
                txtDetalleFrecuenciaCardiacaFetal.Text = oDetalle.Fcf.HasValue ? oDetalle.Fcf.Value.ToString() : "";
                txtDetalleMovimientosFetales.Text = oDetalle.MovimientosFetales;
                txtDetalleProteinuria.Text = oDetalle.Proteinuria;
                txtDetalleAlarmaExamenesTratamientos.Text = oDetalle.AlarmaExamenesTratamientos;
                txtDetallesInicialesTecnico.Text = oDetalle.InicialesTecnico;
                txtDetalleProximaCita.Text = oDetalle.ProximaCita.HasValue ? oDetalle.ProximaCita.Value.ToShortDateString() : "";
                txtDetalleIMC.Text = oDetalle.Imc.HasValue ? oDetalle.Imc.Value.ToString() : "";
                txtDetalleObservaciones.Text = oDetalle.Observaciones;
            }
        }

        private void CargarDatosDeHistoriaClinica(AprHistoriaClinicaPerinatal oHistoriaClinicaPerinatal)
        {
            hfPrimerControl.Value = "0";
            // Datos basicos
            lblNombre.Text = oHistoriaClinicaPerinatal.Nombre;
            lblApellido.Text = oHistoriaClinicaPerinatal.Apellido;
            lblDomicilio.Text = oHistoriaClinicaPerinatal.Domicilio;
            lblTelefono.Text = oHistoriaClinicaPerinatal.Telefono;
            lblLocalidad.Text = oHistoriaClinicaPerinatal.Localidad;
            lblDocumento.Text = oHistoriaClinicaPerinatal.Dni;
            //Datos de Contacto
            txtDatosContacto.Text = oHistoriaClinicaPerinatal.DatosDeContacto;
            //lugar de control
            lblLugarControlPerinatal.Text = oHistoriaClinicaPerinatal.LugarControlPerinatal;
            //lugar de Parto/Aborto
            //Verifico si tiene datos de Parto y puerperio
            AprPartoProvisorio oParto = new SubSonic.Select()
             .From(AprPartoProvisorio.Schema)
             .Where(AprPartoProvisorio.Columns.IdPaciente).IsEqualTo(idPaciente)
             .And(AprPartoProvisorio.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(oHistoriaClinicaPerinatal.IdHistoriaClinicaPerinatal)
             .ExecuteSingle<AprPartoProvisorio>();
            if (oParto != null)
            {
                lblLugarPartoAborto.Text = oParto.SysEfector.NombreNacion;
            }
            //lugar de traslado
            if (oHistoriaClinicaPerinatal.IdEfectorTrasladoUt > 0)
            {
                lblLugarTraslado.Text = oHistoriaClinicaPerinatal.SysEfector.NombreNacion;
                ddlEfectorTraslado.SelectedValue = oHistoriaClinicaPerinatal.IdEfectorTrasladoUt.ToString();
            }
            //Fecha Nacimiento
            lblDiaNacimeinto.Text = String.Format("{0:00}", oHistoriaClinicaPerinatal.FechaNacimiento.HasValue ? oHistoriaClinicaPerinatal.FechaNacimiento.Value.Day : 0);
            lblMesNacimiento.Text = String.Format("{0:00}", oHistoriaClinicaPerinatal.FechaNacimiento.HasValue ? oHistoriaClinicaPerinatal.FechaNacimiento.Value.Month : 0);
            lblAñoNacimiento.Text = String.Format("{0:00}", oHistoriaClinicaPerinatal.FechaNacimiento.HasValue ? oHistoriaClinicaPerinatal.FechaNacimiento.Value.Year.ToString().Substring(2) : "00");
            hfFechaNacimiento.Value = oHistoriaClinicaPerinatal.FechaNacimiento.HasValue ? oHistoriaClinicaPerinatal.FechaNacimiento.Value.ToShortDateString() : "";
            //Edad
            lblEdad.Text = oHistoriaClinicaPerinatal.Edad.HasValue ? oHistoriaClinicaPerinatal.Edad.Value.ToString() : "";
            rbEdad.Checked = oHistoriaClinicaPerinatal.EdadMenor15Mayor35.HasValue ? oHistoriaClinicaPerinatal.EdadMenor15Mayor35.Value : false;
            //Etnia
            rbEtniaBlanca.Checked = oHistoriaClinicaPerinatal.EtniaBlanca.HasValue ? oHistoriaClinicaPerinatal.EtniaBlanca.Value : false;
            rbEtniaIndigena.Checked = oHistoriaClinicaPerinatal.EtniaIndigena.HasValue ? oHistoriaClinicaPerinatal.EtniaIndigena.Value : false;
            rbEtniaMestiza.Checked = oHistoriaClinicaPerinatal.EtniaMestiza.HasValue ? oHistoriaClinicaPerinatal.EtniaMestiza.Value : false;
            rbEtniaNegra.Checked = oHistoriaClinicaPerinatal.EtniaNegra.HasValue ? oHistoriaClinicaPerinatal.EtniaNegra.Value : false;
            rbEtniaOtra.Checked = oHistoriaClinicaPerinatal.EtniaOtra.HasValue ? oHistoriaClinicaPerinatal.EtniaOtra.Value : false;
            //Alfabeta
            rbAlfabetaNo.Checked = oHistoriaClinicaPerinatal.AlfabetaNo.HasValue ? oHistoriaClinicaPerinatal.AlfabetaNo.Value : false;
            rbAlfabetaSi.Checked = oHistoriaClinicaPerinatal.AlfabetaSi.HasValue ? oHistoriaClinicaPerinatal.AlfabetaSi.Value : false;
            //Estudios
            rbEstudiosNinguno.Checked = oHistoriaClinicaPerinatal.EstudiosNinguno.HasValue ? oHistoriaClinicaPerinatal.EstudiosNinguno.Value : false;
            rbEstudiosPrimaria.Checked = oHistoriaClinicaPerinatal.EstudiosPrimario.HasValue ? oHistoriaClinicaPerinatal.EstudiosPrimario.Value : false;
            rbEstudiosSecundario.Checked = oHistoriaClinicaPerinatal.EstudiosSecundario.HasValue ? oHistoriaClinicaPerinatal.EstudiosSecundario.Value : false;
            rbEstudiosUniversitarios.Checked = oHistoriaClinicaPerinatal.EstudiosUniversitario.HasValue ? oHistoriaClinicaPerinatal.EstudiosUniversitario.Value : false;
            txtEstudiosAniosMayorNivel.Text = oHistoriaClinicaPerinatal.AñosMayorNivel.HasValue ? oHistoriaClinicaPerinatal.AñosMayorNivel.Value.ToString() : "";
            //Estado Civil
            rbEstadoCivilCasada.Checked = oHistoriaClinicaPerinatal.EstadoCivilCasada.HasValue ? oHistoriaClinicaPerinatal.EstadoCivilCasada.Value : false;
            rbEstadoCivilUnionEstable.Checked = oHistoriaClinicaPerinatal.EstadoCivilUnionEstable.HasValue ? oHistoriaClinicaPerinatal.EstadoCivilUnionEstable.Value : false;
            rbEstadoCivilSoltera.Checked = oHistoriaClinicaPerinatal.EstadoCivilSoltera.HasValue ? oHistoriaClinicaPerinatal.EstadoCivilSoltera.Value : false;
            rbEstadoCivilOtro.Checked = oHistoriaClinicaPerinatal.EstadoCivilOtro.HasValue ? oHistoriaClinicaPerinatal.EstadoCivilOtro.Value : false;
            //Vive Sola
            rbViveSolaNo.Checked = oHistoriaClinicaPerinatal.ViveSolaNo.HasValue ? oHistoriaClinicaPerinatal.ViveSolaNo.Value : false;
            rbViveSolaSi.Checked = oHistoriaClinicaPerinatal.ViveSolaSi.HasValue ? oHistoriaClinicaPerinatal.ViveSolaSi.Value : false;
            //Antecedentes Familiares
            rbAntecedenteFamiliarTBCNo.Checked = oHistoriaClinicaPerinatal.AntFamTBCNo.HasValue ? oHistoriaClinicaPerinatal.AntFamTBCNo.Value : false;
            rbAntecedenteFamiliarTBCSi.Checked = oHistoriaClinicaPerinatal.AntFamTBCSi.HasValue ? oHistoriaClinicaPerinatal.AntFamTBCSi.Value : false;
            rbAntecedenteFamiliarDiabetesNo.Checked = oHistoriaClinicaPerinatal.AntFamDiabetesNo.HasValue ? oHistoriaClinicaPerinatal.AntFamDiabetesNo.Value : false;
            rbAntecedenteFamiliarDiabetesSi.Checked = oHistoriaClinicaPerinatal.AntFamDiabetesSi.HasValue ? oHistoriaClinicaPerinatal.AntFamDiabetesSi.Value : false;
            rbAntecedenteFamiliarHipertensionNo.Checked = oHistoriaClinicaPerinatal.AntFamHipertensionNo.HasValue ? oHistoriaClinicaPerinatal.AntFamHipertensionNo.Value : false;
            rbAntecedenteFamiliarHipertensionSi.Checked = oHistoriaClinicaPerinatal.AntFamHipertensionSi.HasValue ? oHistoriaClinicaPerinatal.AntFamHipertensionSi.Value : false;
            rbAntecedenteFamiliarInfUrinariaNo.Checked = oHistoriaClinicaPerinatal.AntFamInfeccionUrinariaNo.HasValue ? oHistoriaClinicaPerinatal.AntFamInfeccionUrinariaNo.Value : false;
            rbAntecedenteFamiliarInfUrinariaSi.Checked = oHistoriaClinicaPerinatal.AntFamInfeccionUrinariaSi.HasValue ? oHistoriaClinicaPerinatal.AntFamInfeccionUrinariaSi.Value : false;
            rbAntecedenteFamiliarOtrasInfeccionesNo.Checked = oHistoriaClinicaPerinatal.AntFamOtrasInfeccionesNo.HasValue ? oHistoriaClinicaPerinatal.AntFamOtrasInfeccionesNo.Value : false;
            rbAntecedenteFamiliarOtrasInfeccionesSi.Checked = oHistoriaClinicaPerinatal.AntFamOtrasInfeccionesSi.HasValue ? oHistoriaClinicaPerinatal.AntFamOtrasInfeccionesSi.Value : false;
            rbAntecedenteFamiliarOtraCondNo.Checked = oHistoriaClinicaPerinatal.AntFamOtroNo.HasValue ? oHistoriaClinicaPerinatal.AntFamOtroNo.Value : false;
            rbAntecedenteFamiliarOtraCondSi.Checked = oHistoriaClinicaPerinatal.AntFamOtroSi.HasValue ? oHistoriaClinicaPerinatal.AntFamOtroSi.Value : false;

            //Antecedentes Personales
            rbAntecedentePersonalTBCNo.Checked = oHistoriaClinicaPerinatal.AntPerTBCNo.HasValue ? oHistoriaClinicaPerinatal.AntPerTBCNo.Value : false;
            rbAntecedentePersonalTBCSi.Checked = oHistoriaClinicaPerinatal.AntPerTBCSi.HasValue ? oHistoriaClinicaPerinatal.AntPerTBCSi.Value : false;
            rbAntecedentePersonalDiabetesNo.Checked = oHistoriaClinicaPerinatal.AntPerDiabetesNo.HasValue ? oHistoriaClinicaPerinatal.AntPerDiabetesNo.Value : false;
            rbAntecedentePersonalDiabetesI.Checked = oHistoriaClinicaPerinatal.AntPerDiabetesI.HasValue ? oHistoriaClinicaPerinatal.AntPerDiabetesI.Value : false;
            rbAntecedentePersonalDiabetesII.Checked = oHistoriaClinicaPerinatal.AntPerDiabetesII.HasValue ? oHistoriaClinicaPerinatal.AntPerDiabetesII.Value : false;
            rbAntecedentePersonalDiabetesG.Checked = oHistoriaClinicaPerinatal.AntPerDiabetesG.HasValue ? oHistoriaClinicaPerinatal.AntPerDiabetesG.Value : false;
            rbAntecedentePersonalHipertensionNo.Checked = oHistoriaClinicaPerinatal.AntPerHipertensionNo.HasValue ? oHistoriaClinicaPerinatal.AntPerHipertensionNo.Value : false;
            rbAntecedentePersonalHipertensionSi.Checked = oHistoriaClinicaPerinatal.AntPerHipertensionSi.HasValue ? oHistoriaClinicaPerinatal.AntPerHipertensionSi.Value : false;
            rbAntecedentePersonalInfUrinariaNo.Checked = oHistoriaClinicaPerinatal.AntPerInfeccionUrinariaNo.HasValue ? oHistoriaClinicaPerinatal.AntPerInfeccionUrinariaNo.Value : false;
            rbAntecedentePersonalInfUrinariaSi.Checked = oHistoriaClinicaPerinatal.AntPerInfeccionUrinariaSi.HasValue ? oHistoriaClinicaPerinatal.AntPerInfeccionUrinariaSi.Value : false;
            rbAntecedentePersonalOtrasInfeccionesNo.Checked = oHistoriaClinicaPerinatal.AntPerOtrasInfeccionesNo.HasValue ? oHistoriaClinicaPerinatal.AntPerOtrasInfeccionesNo.Value : false;
            rbAntecedentePersonalOtrasInfeccionesSi.Checked = oHistoriaClinicaPerinatal.AntPerOtrasInfeccionesSi.HasValue ? oHistoriaClinicaPerinatal.AntPerOtrasInfeccionesSi.Value : false;
            rbAntecedentePersonalOtraCondNo.Checked = oHistoriaClinicaPerinatal.AntPerOtroNo.HasValue ? oHistoriaClinicaPerinatal.AntPerOtroNo.Value : false;
            rbAntecedentePersonalOtraCondSi.Checked = oHistoriaClinicaPerinatal.AntPerOtroSi.HasValue ? oHistoriaClinicaPerinatal.AntPerOtroSi.Value : false;
            rbAntecedentePersonalInfertilidadNo.Checked = oHistoriaClinicaPerinatal.AntPerInfertilidadNo.HasValue ? oHistoriaClinicaPerinatal.AntPerInfertilidadNo.Value : false;
            rbAntecedentePersonalInfertilidadSi.Checked = oHistoriaClinicaPerinatal.AntPerInfertilidadSi.HasValue ? oHistoriaClinicaPerinatal.AntPerInfertilidadSi.Value : false;
            rbAntecedentePersonalCardiopatiaNo.Checked = oHistoriaClinicaPerinatal.AntPerCardiopatiaNo.HasValue ? oHistoriaClinicaPerinatal.AntPerCardiopatiaNo.Value : false;
            rbAntecedentePersonalCardiopatiaSi.Checked = oHistoriaClinicaPerinatal.AntPerCardiopatiaSi.HasValue ? oHistoriaClinicaPerinatal.AntPerCardiopatiaSi.Value : false;
            rbAntecedentePersonalNefropatiaNo.Checked = oHistoriaClinicaPerinatal.AntPerNefropatiaNo.HasValue ? oHistoriaClinicaPerinatal.AntPerNefropatiaNo.Value : false;
            rbAntecedentePersonalNefropatiaSi.Checked = oHistoriaClinicaPerinatal.AntPerNefropatiaSi.HasValue ? oHistoriaClinicaPerinatal.AntPerNefropatiaSi.Value : false;
            rbAntecedentePersonalViolenciaNo.Checked = oHistoriaClinicaPerinatal.AntPerViolenciaNo.HasValue ? oHistoriaClinicaPerinatal.AntPerViolenciaNo.Value : false;
            rbAntecedentePersonalViolenciaSi.Checked = oHistoriaClinicaPerinatal.AntPerViolenciaSi.HasValue ? oHistoriaClinicaPerinatal.AntPerViolenciaSi.Value : false;
            rbAntecedentePersonalAlergiaMedicamentoNo.Checked = oHistoriaClinicaPerinatal.AntPerAlergiaMedicamentoNo.HasValue ? oHistoriaClinicaPerinatal.AntPerAlergiaMedicamentoNo.Value : false;
            rbAntecedentePersonalAlergiaMedicamentoSi.Checked = oHistoriaClinicaPerinatal.AntPerAlergiaMedicamentoSi.HasValue ? oHistoriaClinicaPerinatal.AntPerAlergiaMedicamentoSi.Value : false;

            txtAntecedentesObervaciones.Text = oHistoriaClinicaPerinatal.AntecedentesObservacion;
            //Antecedente Obstetricos
            txtGestasPrevias.Text = oHistoriaClinicaPerinatal.GestasPrevias.HasValue ? oHistoriaClinicaPerinatal.GestasPrevias.Value.ToString() : "";
            txtAbortos.Text = oHistoriaClinicaPerinatal.Abortos.HasValue ? oHistoriaClinicaPerinatal.Abortos.Value.ToString() : "";
            txtEmbarazosEctopicos.Text = oHistoriaClinicaPerinatal.EmbEctopicos.HasValue ? oHistoriaClinicaPerinatal.EmbEctopicos.Value.ToString() : "";
            rbAbortos3Concecutivos.Checked = oHistoriaClinicaPerinatal.Abortos3concecutivos.HasValue ? oHistoriaClinicaPerinatal.Abortos3concecutivos.Value : false;
            txtPartos.Text = oHistoriaClinicaPerinatal.Partos.HasValue ? oHistoriaClinicaPerinatal.Partos.Value.ToString() : "";
            rbAntecedentesGemelaresNo.Checked = oHistoriaClinicaPerinatal.AntecedentesGemelaresNo.HasValue ? oHistoriaClinicaPerinatal.AntecedentesGemelaresNo.Value : false;
            rbAntecedentesGemelaresSi.Checked = oHistoriaClinicaPerinatal.AntecedentesGemelaresSi.HasValue ? oHistoriaClinicaPerinatal.AntecedentesGemelaresSi.Value : false;
            rbUltimoPrevioNoCorresponde.Checked = oHistoriaClinicaPerinatal.UltPrevioNC.HasValue ? oHistoriaClinicaPerinatal.UltPrevioNC.Value : false;
            rbUltimoPrevioNormal.Checked = oHistoriaClinicaPerinatal.UltPrevioNormal.HasValue ? oHistoriaClinicaPerinatal.UltPrevioNormal.Value : false;
            rbUltimoPrevioMenor2500.Checked = oHistoriaClinicaPerinatal.UltPrevioMenor2500.HasValue ? oHistoriaClinicaPerinatal.UltPrevioMenor2500.Value : false;
            rbUltimoPrevioMayor4000.Checked = oHistoriaClinicaPerinatal.UltPrevioMayor4000.HasValue ? oHistoriaClinicaPerinatal.UltPrevioMayor4000.Value : false;
            txtPartosVaginales.Text = oHistoriaClinicaPerinatal.PartosVaginales.HasValue ? oHistoriaClinicaPerinatal.PartosVaginales.Value.ToString() : "";
            txtCesareas.Text = oHistoriaClinicaPerinatal.Cesareas.HasValue ? oHistoriaClinicaPerinatal.Cesareas.Value.ToString() : "";
            txtNacidosMuertos.Text = oHistoriaClinicaPerinatal.NacidosMuertos.HasValue ? oHistoriaClinicaPerinatal.NacidosMuertos.Value.ToString() : "";
            txtNacidosVivos.Text = oHistoriaClinicaPerinatal.NacidosVivos.HasValue ? oHistoriaClinicaPerinatal.NacidosVivos.Value.ToString() : "";
            txtMuertosPrimerSemana.Text = oHistoriaClinicaPerinatal.MuertosPrimerSemana.HasValue ? oHistoriaClinicaPerinatal.MuertosPrimerSemana.Value.ToString() : "";
            txtMuertosDespuesPrimerSemana.Text = oHistoriaClinicaPerinatal.MuertosDespuesPrimerSemana.HasValue ? oHistoriaClinicaPerinatal.MuertosDespuesPrimerSemana.Value.ToString() : "";
            txtViven.Text = oHistoriaClinicaPerinatal.Viven.HasValue ? oHistoriaClinicaPerinatal.Viven.Value.ToString() : "";
            txtFinEmbAnterior.Text = oHistoriaClinicaPerinatal.FinEmbarazoAnterior.HasValue ? oHistoriaClinicaPerinatal.FinEmbarazoAnterior.Value.ToShortDateString() : "";
            rbFinEmbAnteriorMenor1Año.Checked = oHistoriaClinicaPerinatal.FinEmbAnteriorMenor1Año.HasValue ? oHistoriaClinicaPerinatal.FinEmbAnteriorMenor1Año.Value : false;
            rbEmbarazoPlaneadoNo.Checked = oHistoriaClinicaPerinatal.EmbarazoPlaneadoNo.HasValue ? oHistoriaClinicaPerinatal.EmbarazoPlaneadoNo.Value : false;
            rbEmbarazoPlaneadoSi.Checked = oHistoriaClinicaPerinatal.EmbarazoPlaneadoSi.HasValue ? oHistoriaClinicaPerinatal.EmbarazoPlaneadoSi.Value : false;
            rbFracMetAnticonceptivoNoUsaba.Checked = oHistoriaClinicaPerinatal.FracMetAnticonceptivoNoUsaba.HasValue ? oHistoriaClinicaPerinatal.FracMetAnticonceptivoNoUsaba.Value : false;
            rbFracMetAnticonceptivoBarrera.Checked = oHistoriaClinicaPerinatal.FracMetAnticonceptivoBarrera.HasValue ? oHistoriaClinicaPerinatal.FracMetAnticonceptivoBarrera.Value : false;
            rbFracMetAnticonceptivoDIU.Checked = oHistoriaClinicaPerinatal.FracMetAnticonceptivoDIU.HasValue ? oHistoriaClinicaPerinatal.FracMetAnticonceptivoDIU.Value : false;
            rbFracMetAnticonceptivoHormonal.Checked = oHistoriaClinicaPerinatal.FracMetAnticonceptivoHormonal.HasValue ? oHistoriaClinicaPerinatal.FracMetAnticonceptivoHormonal.Value : false;
            rbFracMetAnticonceptivoEmergencia.Checked = oHistoriaClinicaPerinatal.FracMetAnticonceptivoEmergencia.HasValue ? oHistoriaClinicaPerinatal.FracMetAnticonceptivoEmergencia.Value : false;
            rbFracMetAnticonceptivoNatural.Checked = oHistoriaClinicaPerinatal.FracMetAnticonceptivoNatural.HasValue ? oHistoriaClinicaPerinatal.FracMetAnticonceptivoNatural.Value : false;
            //Gestacion Actual
            txtPesoAnterior.Text = oHistoriaClinicaPerinatal.PesoAnterior.HasValue ? oHistoriaClinicaPerinatal.PesoAnterior.Value.ToString() : "";
            txtTalla.Text = oHistoriaClinicaPerinatal.Talla.HasValue ? oHistoriaClinicaPerinatal.Talla.Value.ToString() : "";
            txtFUM.Text = oHistoriaClinicaPerinatal.Fum.HasValue ? oHistoriaClinicaPerinatal.Fum.Value.ToShortDateString() : "";
            txtFPP.Text = oHistoriaClinicaPerinatal.Fpp.HasValue ? oHistoriaClinicaPerinatal.Fpp.Value.ToShortDateString() : "";
            //EG Confiable
            rbEGConfiableFUMNo.Checked = oHistoriaClinicaPerinatal.EGConfiableFUMNo.HasValue ? oHistoriaClinicaPerinatal.EGConfiableFUMNo.Value : false;
            rbEGConfiableFUMSi.Checked = oHistoriaClinicaPerinatal.EGConfiableFUMSi.HasValue ? oHistoriaClinicaPerinatal.EGConfiableFUMSi.Value : false;
            rbEGConfiableEco20No.Checked = oHistoriaClinicaPerinatal.EGConfiableEcoMenor20semanasNo.HasValue ? oHistoriaClinicaPerinatal.EGConfiableEcoMenor20semanasNo.Value : false;
            rbEGConfiableEco20Si.Checked = oHistoriaClinicaPerinatal.EGConfiableEcoMenor20semanasSi.HasValue ? oHistoriaClinicaPerinatal.EGConfiableEcoMenor20semanasSi.Value : false;
            //Drogas
            rbFumaActiva1TrimNo.Checked = oHistoriaClinicaPerinatal.FumaActivo1TrimNo.HasValue ? oHistoriaClinicaPerinatal.FumaActivo1TrimNo.Value : false;
            rbFumaActiva1TrimSi.Checked = oHistoriaClinicaPerinatal.FumaActivo1TrimSi.HasValue ? oHistoriaClinicaPerinatal.FumaActivo1TrimSi.Value : false;
            rbFumaActiva2TrimNo.Checked = oHistoriaClinicaPerinatal.FumaActivo2TrimNo.HasValue ? oHistoriaClinicaPerinatal.FumaActivo2TrimNo.Value : false;
            rbFumaActiva2TrimSi.Checked = oHistoriaClinicaPerinatal.FumaActivo2TrimSi.HasValue ? oHistoriaClinicaPerinatal.FumaActivo2TrimSi.Value : false;
            rbFumaActiva3TrimNo.Checked = oHistoriaClinicaPerinatal.FumaActivo3TrimNo.HasValue ? oHistoriaClinicaPerinatal.FumaActivo3TrimNo.Value : false;
            rbFumaActiva3TrimSi.Checked = oHistoriaClinicaPerinatal.FumaActivo3TrimSi.HasValue ? oHistoriaClinicaPerinatal.FumaActivo3TrimSi.Value : false;

            rbFumaPasiva1TrimNo.Checked = oHistoriaClinicaPerinatal.FumaPasivo1TrimNo.HasValue ? oHistoriaClinicaPerinatal.FumaPasivo1TrimNo.Value : false;
            rbFumaPasiva1TrimSi.Checked = oHistoriaClinicaPerinatal.FumaPasivo1TrimSi.HasValue ? oHistoriaClinicaPerinatal.FumaPasivo1TrimSi.Value : false;
            rbFumaPasiva2TrimNo.Checked = oHistoriaClinicaPerinatal.FumaPasivo2TrimNo.HasValue ? oHistoriaClinicaPerinatal.FumaPasivo2TrimNo.Value : false;
            rbFumaPasiva2TrimSi.Checked = oHistoriaClinicaPerinatal.FumaPasivo2TrimSi.HasValue ? oHistoriaClinicaPerinatal.FumaPasivo2TrimSi.Value : false;
            rbFumaPasiva3TrimNo.Checked = oHistoriaClinicaPerinatal.FumaPasivo3TrimNo.HasValue ? oHistoriaClinicaPerinatal.FumaPasivo3TrimNo.Value : false;
            rbFumaPasiva3TrimSi.Checked = oHistoriaClinicaPerinatal.FumaPasivo3TrimSi.HasValue ? oHistoriaClinicaPerinatal.FumaPasivo3TrimSi.Value : false;

            rbDrogas1TrimNo.Checked = oHistoriaClinicaPerinatal.Drogas1TrimNo.HasValue ? oHistoriaClinicaPerinatal.Drogas1TrimNo.Value : false;
            rbDrogas1TrimSi.Checked = oHistoriaClinicaPerinatal.Drogas1TrimSi.HasValue ? oHistoriaClinicaPerinatal.Drogas1TrimSi.Value : false;
            rbDrogas2TrimNo.Checked = oHistoriaClinicaPerinatal.Drogas2TrimNo.HasValue ? oHistoriaClinicaPerinatal.Drogas2TrimNo.Value : false;
            rbDrogas2TrimSi.Checked = oHistoriaClinicaPerinatal.Drogas2TrimSi.HasValue ? oHistoriaClinicaPerinatal.Drogas2TrimSi.Value : false;
            rbDrogas3TrimNo.Checked = oHistoriaClinicaPerinatal.Drogas3TrimNo.HasValue ? oHistoriaClinicaPerinatal.Drogas3TrimNo.Value : false;
            rbDrogas3TrimSi.Checked = oHistoriaClinicaPerinatal.Drogas3TrimSi.HasValue ? oHistoriaClinicaPerinatal.Drogas3TrimSi.Value : false;

            rbAlcohol1TrimNo.Checked = oHistoriaClinicaPerinatal.Alcohol1TrimNo.HasValue ? oHistoriaClinicaPerinatal.Alcohol1TrimNo.Value : false;
            rbAlcohol1TrimSi.Checked = oHistoriaClinicaPerinatal.Alcohol1TrimSi.HasValue ? oHistoriaClinicaPerinatal.Alcohol1TrimSi.Value : false;
            rbAlcohol2TrimNo.Checked = oHistoriaClinicaPerinatal.Alcohol2TrimNo.HasValue ? oHistoriaClinicaPerinatal.Alcohol2TrimNo.Value : false;
            rbAlcohol2TrimSi.Checked = oHistoriaClinicaPerinatal.Alcohol2TrimSi.HasValue ? oHistoriaClinicaPerinatal.Alcohol2TrimSi.Value : false;
            rbAlcohol3TrimNo.Checked = oHistoriaClinicaPerinatal.Alcohol3TrimNo.HasValue ? oHistoriaClinicaPerinatal.Alcohol3TrimNo.Value : false;
            rbAlcohol3TrimSi.Checked = oHistoriaClinicaPerinatal.Alcohol3TrimSi.HasValue ? oHistoriaClinicaPerinatal.Alcohol3TrimSi.Value : false;

            rbViolencia1TrimNo.Checked = oHistoriaClinicaPerinatal.Violencia1TrimNo.HasValue ? oHistoriaClinicaPerinatal.Violencia1TrimNo.Value : false;
            rbViolencia1TrimSi.Checked = oHistoriaClinicaPerinatal.Violencia1TrimSi.HasValue ? oHistoriaClinicaPerinatal.Violencia1TrimSi.Value : false;
            rbViolencia2TrimNo.Checked = oHistoriaClinicaPerinatal.Violencia2TrimNo.HasValue ? oHistoriaClinicaPerinatal.Violencia2TrimNo.Value : false;
            rbViolencia2TrimSi.Checked = oHistoriaClinicaPerinatal.Violencia2TrimSi.HasValue ? oHistoriaClinicaPerinatal.Violencia2TrimSi.Value : false;
            rbViolencia3TrimNo.Checked = oHistoriaClinicaPerinatal.Violencia3TrimNo.HasValue ? oHistoriaClinicaPerinatal.Violencia3TrimNo.Value : false;
            rbViolencia3TrimSi.Checked = oHistoriaClinicaPerinatal.Violencia3TrimSi.HasValue ? oHistoriaClinicaPerinatal.Violencia3TrimSi.Value : false;
            //Antirubeola
            rbAntirubeolaPrevia.Checked = oHistoriaClinicaPerinatal.AntirubeolaPrevia.HasValue ? oHistoriaClinicaPerinatal.AntirubeolaPrevia.Value : false;
            rbAntirubeolaNoSabe.Checked = oHistoriaClinicaPerinatal.AntirubeolaNoSabe.HasValue ? oHistoriaClinicaPerinatal.AntirubeolaNoSabe.Value : false;
            rbAntirubeolaEmbarazo.Checked = oHistoriaClinicaPerinatal.AntirubeolaEmbarazo.HasValue ? oHistoriaClinicaPerinatal.AntirubeolaEmbarazo.Value : false;
            rbAntirubeolaNo.Checked = oHistoriaClinicaPerinatal.AntirubeolaNo.HasValue ? oHistoriaClinicaPerinatal.AntirubeolaNo.Value : false;
            //Antitetanica
            rbAntitetanicaVigenteNo.Checked = oHistoriaClinicaPerinatal.AntitetanicaVigenteNo.HasValue ? oHistoriaClinicaPerinatal.AntitetanicaVigenteNo.Value : false;
            rbAntitetanicaVigenteSi.Checked = oHistoriaClinicaPerinatal.AntitetanicaVigenteSi.HasValue ? oHistoriaClinicaPerinatal.AntitetanicaVigenteSi.Value : false;
            txtAntitetanicaDosis1.Text = oHistoriaClinicaPerinatal.Antitetanica1DosisMesGestacion.HasValue ? oHistoriaClinicaPerinatal.Antitetanica1DosisMesGestacion.Value.ToString() : "";
            txtAntitetanicaDosis2.Text = oHistoriaClinicaPerinatal.Antitetanica2DosisMesGestacion.HasValue ? oHistoriaClinicaPerinatal.Antitetanica2DosisMesGestacion.Value.ToString() : "";
            //Ex.Normal
            //Seteo la variable que me indica si ya se marco antes el control anormal odontologico
            controlOdontologicoAnormal = oHistoriaClinicaPerinatal.ExamenOdotologicoNormalNo.HasValue ? oHistoriaClinicaPerinatal.ExamenOdotologicoNormalNo.Value : false;

            rbExNormalOdontNo.Checked = oHistoriaClinicaPerinatal.ExamenOdotologicoNormalNo.HasValue ? oHistoriaClinicaPerinatal.ExamenOdotologicoNormalNo.Value : false;
            rbExNormalOdontSi.Checked = oHistoriaClinicaPerinatal.ExamenOdotologicoNormalSi.HasValue ? oHistoriaClinicaPerinatal.ExamenOdotologicoNormalSi.Value : false;
            rbExNormalMamasNo.Checked = oHistoriaClinicaPerinatal.ExamenMamasNormalNo.HasValue ? oHistoriaClinicaPerinatal.ExamenMamasNormalNo.Value : false;
            rbExNormalMamasSi.Checked = oHistoriaClinicaPerinatal.ExamenMamasNormalSi.HasValue ? oHistoriaClinicaPerinatal.ExamenMamasNormalSi.Value : false;
            //Cervix
            rbCervixVisualNormal.Checked = oHistoriaClinicaPerinatal.CervixInspeccionVisualNormal.HasValue ? oHistoriaClinicaPerinatal.CervixInspeccionVisualNormal.Value : false;
            rbCervixVisualANormal.Checked = oHistoriaClinicaPerinatal.CervixInspeccionVisualAnormal.HasValue ? oHistoriaClinicaPerinatal.CervixInspeccionVisualAnormal.Value : false;
            rbCervixVisualNoSeHizo.Checked = oHistoriaClinicaPerinatal.CervixInspeccionVisualNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.CervixInspeccionVisualNoSeHizo.Value : false;
            rbCervixPAPNormal.Checked = oHistoriaClinicaPerinatal.CervixPAPNormal.HasValue ? oHistoriaClinicaPerinatal.CervixPAPNormal.Value : false;
            rbCervixPAPANormal.Checked = oHistoriaClinicaPerinatal.CervixPAPAnormal.HasValue ? oHistoriaClinicaPerinatal.CervixPAPAnormal.Value : false;
            rbCervixPAPNoSeHizo.Checked = oHistoriaClinicaPerinatal.CervixPAPNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.CervixPAPNoSeHizo.Value : false;
            rbCervixCOLPNormal.Checked = oHistoriaClinicaPerinatal.CervixCOLPNormal.HasValue ? oHistoriaClinicaPerinatal.CervixCOLPNormal.Value : false;
            rbCervixCOLPANormal.Checked = oHistoriaClinicaPerinatal.CervixCOLPAnormal.HasValue ? oHistoriaClinicaPerinatal.CervixCOLPAnormal.Value : false;
            rbCervixCOLPNoSeHizo.Checked = oHistoriaClinicaPerinatal.CervixCOLPNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.CervixCOLPNoSeHizo.Value : false;
            //Sangre
            txtGrupo.Text = oHistoriaClinicaPerinatal.Grupo;
            rbSangreRhNegativo.Checked = oHistoriaClinicaPerinatal.RHNegativo.HasValue ? oHistoriaClinicaPerinatal.RHNegativo.Value : false;
            rbSangreRhPositivo.Checked = oHistoriaClinicaPerinatal.RHPositivo.HasValue ? oHistoriaClinicaPerinatal.RHPositivo.Value : false;
            rbSangreInmunizNo.Checked = oHistoriaClinicaPerinatal.InmunizacionNo.HasValue ? oHistoriaClinicaPerinatal.InmunizacionNo.Value : false;
            rbSangreInmunizSi.Checked = oHistoriaClinicaPerinatal.InmunizacionSi.HasValue ? oHistoriaClinicaPerinatal.InmunizacionSi.Value : false;
            //Toxoplasmosis
            rbToxoplasmosisMenos20IgGNegativo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGNegativo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGNegativo.Value : false;
            rbToxoplasmosisMenos20IgGPositivo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGPositivo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGPositivo.Value : false;
            rbToxoplasmosisMenos20IgGNoSeHizo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGNoSeHizo.Value : false;
            rbToxoplasmosisMas20IgGNegativo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGNegativo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGNegativo.Value : false;
            rbToxoplasmosisMas20IgGPositivo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGPositivo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGPositivo.Value : false;
            rbToxoplasmosisMas20IgGNoSeHizo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGNoSeHizo.Value : false;
            rbToxoplasmosis1ConsultaIgMNegativo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMNegativo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMNegativo.Value : false;
            rbToxoplasmosis1ConsultaIgMPositivo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMPositivo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMPositivo.Value : false;
            rbToxoplasmosis1ConsultaIgMNoSeHizo.Checked = oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMNoSeHizo.Value : false;
            //VIH
            rbVIHCRNo.Checked = oHistoriaClinicaPerinatal.VIHCRNo.HasValue ? oHistoriaClinicaPerinatal.VIHCRNo.Value : false;
            rbVIHCRSi.Checked = oHistoriaClinicaPerinatal.VIHCRSi.HasValue ? oHistoriaClinicaPerinatal.VIHCRSi.Value : false;
            //VIH Primer Muestra
            rbVIHPrimerMuestraSolicitadoNo.Checked = oHistoriaClinicaPerinatal.VIHPrimerMuestraSolicitadoNo.HasValue ? oHistoriaClinicaPerinatal.VIHPrimerMuestraSolicitadoNo.Value : false;
            rbVIHPrimerMuestraSolicitadoSi.Checked = oHistoriaClinicaPerinatal.VIHPrimerMuestraSolicitadoSi.HasValue ? oHistoriaClinicaPerinatal.VIHPrimerMuestraSolicitadoSi.Value : false;
            rbVIHPrimerMuestraRealizadoNo.Checked = oHistoriaClinicaPerinatal.VIHPrimerMuestraRealizadoNo.HasValue ? oHistoriaClinicaPerinatal.VIHPrimerMuestraRealizadoNo.Value : false;
            rbVIHPrimerMuestraRealizadoSi.Checked = oHistoriaClinicaPerinatal.VIHPrimerMuestraRealizadoSi.HasValue ? oHistoriaClinicaPerinatal.VIHPrimerMuestraRealizadoSi.Value : false;
            txtVIHPrimerMuestraFecha.Text = oHistoriaClinicaPerinatal.VIHPrimerMuestraFecha.HasValue ? oHistoriaClinicaPerinatal.VIHPrimerMuestraFecha.Value.ToShortDateString() : "";
            //VIH Segunda Muestra
            rbVIHSegundaMuestraSolicitadoNo.Checked = oHistoriaClinicaPerinatal.VIHSegundaMuestraSolicitadoNo.HasValue ? oHistoriaClinicaPerinatal.VIHSegundaMuestraSolicitadoNo.Value : false;
            rbVIHSegundaMuestraSolicitadoSi.Checked = oHistoriaClinicaPerinatal.VIHSegundaMuestraSolicitadoSi.HasValue ? oHistoriaClinicaPerinatal.VIHSegundaMuestraSolicitadoSi.Value : false;
            rbVIHSegundaMuestraRealizadoNo.Checked = oHistoriaClinicaPerinatal.VIHSegundaMuestraRealizadoNo.HasValue ? oHistoriaClinicaPerinatal.VIHSegundaMuestraRealizadoNo.Value : false;
            rbVIHSegundaMuestraRealizadoSi.Checked = oHistoriaClinicaPerinatal.VIHSegundaMuestraRealizadoSi.HasValue ? oHistoriaClinicaPerinatal.VIHSegundaMuestraRealizadoSi.Value : false;
            txtVIHSegundaMuestraFecha.Text = oHistoriaClinicaPerinatal.VIHSegundaMuestraFecha.HasValue ? oHistoriaClinicaPerinatal.VIHSegundaMuestraFecha.Value.ToShortDateString() : "";
            //VIH Tercer Muestra
            rbVIHTercerMuestraSolicitadoNo.Checked = oHistoriaClinicaPerinatal.VIHTercerMuestraSolicitadoNo.HasValue ? oHistoriaClinicaPerinatal.VIHTercerMuestraSolicitadoNo.Value : false;
            rbVIHTercerMuestraSolicitadoSi.Checked = oHistoriaClinicaPerinatal.VIHTercerMuestraSolicitadoSi.HasValue ? oHistoriaClinicaPerinatal.VIHTercerMuestraSolicitadoSi.Value : false;
            rbVIHTercerMuestraRealizadoNo.Checked = oHistoriaClinicaPerinatal.VIHTercerMuestraRealizadoNo.HasValue ? oHistoriaClinicaPerinatal.VIHTercerMuestraRealizadoNo.Value : false;
            rbVIHTercerMuestraRealizadoSi.Checked = oHistoriaClinicaPerinatal.VIHTercerMuestraRealizadoSi.HasValue ? oHistoriaClinicaPerinatal.VIHTercerMuestraRealizadoSi.Value : false;
            txtVIHTercerMuestraFecha.Text = oHistoriaClinicaPerinatal.VIHTercerMuestraFecha.HasValue ? oHistoriaClinicaPerinatal.VIHTercerMuestraFecha.Value.ToShortDateString() : "";
            //Hemoglobina
            txtHBMenos20.Text = oHistoriaClinicaPerinatal.HBMenor20Sem.HasValue ? oHistoriaClinicaPerinatal.HBMenor20Sem.Value.ToString() : "";
            rbHemoglobinaMenos20Menor11.Checked = oHistoriaClinicaPerinatal.HBMenor20SemMenor11.HasValue ? oHistoriaClinicaPerinatal.HBMenor20SemMenor11.Value : false;
            txtHBMas20.Text = oHistoriaClinicaPerinatal.HBMayor20Sem.HasValue ? oHistoriaClinicaPerinatal.HBMayor20Sem.Value.ToString() : "";
            rbHemoglobinaMas20Menor11.Checked = oHistoriaClinicaPerinatal.HBMayor20SemMenor11.HasValue ? oHistoriaClinicaPerinatal.HBMayor20SemMenor11.Value : false;
            rbHierroIndicadoNo.Checked = oHistoriaClinicaPerinatal.FeIndicadoNo.HasValue ? oHistoriaClinicaPerinatal.FeIndicadoNo.Value : false;
            rbHierroIndicadoSi.Checked = oHistoriaClinicaPerinatal.FeIndicadoSi.HasValue ? oHistoriaClinicaPerinatal.FeIndicadoSi.Value : false;
            rbFolatosIndicadosNo.Checked = oHistoriaClinicaPerinatal.FolatosIndicadosNo.HasValue ? oHistoriaClinicaPerinatal.FolatosIndicadosNo.Value : false;
            rbFolatosIndicadosSi.Checked = oHistoriaClinicaPerinatal.FolatosIndicadosSi.HasValue ? oHistoriaClinicaPerinatal.FolatosIndicadosSi.Value : false;
            //Chagas
            rbChagasNegativo.Checked = oHistoriaClinicaPerinatal.ChagasNegativo.HasValue ? oHistoriaClinicaPerinatal.ChagasNegativo.Value : false;
            rbChagasPositivo.Checked = oHistoriaClinicaPerinatal.ChagasPositivo.HasValue ? oHistoriaClinicaPerinatal.ChagasPositivo.Value : false;
            rbChagasNoSeHizo.Checked = oHistoriaClinicaPerinatal.ChagasNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.ChagasNoSeHizo.Value : false;
            //Hepatitis B
            rbHepatitisBNegativo.Checked = oHistoriaClinicaPerinatal.HepatitisBNegativo.HasValue ? oHistoriaClinicaPerinatal.HepatitisBNegativo.Value : false;
            rbHepatitisBPositivo.Checked = oHistoriaClinicaPerinatal.HepatitisBPositivo.HasValue ? oHistoriaClinicaPerinatal.HepatitisBPositivo.Value : false;
            rbHepatitisBNoSeHizo.Checked = oHistoriaClinicaPerinatal.HepatitisBNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.HepatitisBNoSeHizo.Value : false;
            //Bacteriura
            rbBacteriuriaMenos20Normal.Checked = oHistoriaClinicaPerinatal.BacteriuraMenor20SemNormal.HasValue ? oHistoriaClinicaPerinatal.BacteriuraMenor20SemNormal.Value : false;
            rbBacteriuriaMenos20Anormal.Checked = oHistoriaClinicaPerinatal.BacteriuraMenor20SemAnormal.HasValue ? oHistoriaClinicaPerinatal.BacteriuraMenor20SemAnormal.Value : false;
            rbBacteriuriaMenos20NoSeHizo.Checked = oHistoriaClinicaPerinatal.BacteriuraMenor20SemNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.BacteriuraMenor20SemNoSeHizo.Value : false;
            rbBacteriuriaMas20Normal.Checked = oHistoriaClinicaPerinatal.BacteriuraMayor20SemNormal.HasValue ? oHistoriaClinicaPerinatal.BacteriuraMayor20SemNormal.Value : false;
            rbBacteriuriaMas20Anormal.Checked = oHistoriaClinicaPerinatal.BacteriuraMayor20SemAnormal.HasValue ? oHistoriaClinicaPerinatal.BacteriuraMayor20SemAnormal.Value : false;
            rbBacteriuriaMas20NoSeHizo.Checked = oHistoriaClinicaPerinatal.BacteriuraMayor20SemNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.BacteriuraMayor20SemNoSeHizo.Value : false;
            //Glucemia
            txtGlucemiaMenos20Valor.Text = oHistoriaClinicaPerinatal.GlucemiaMenor20Sem.HasValue ? oHistoriaClinicaPerinatal.GlucemiaMenor20Sem.Value.ToString() : "";
            rbGlucemiaMenos20Mayor105.Checked = oHistoriaClinicaPerinatal.GlucemiaMenor20SemMayor105.HasValue ? oHistoriaClinicaPerinatal.GlucemiaMenor20SemMayor105.Value : false;
            txtGlucemiaMas30Valor.Text = oHistoriaClinicaPerinatal.GlucemiaMayor20Sem.HasValue ? oHistoriaClinicaPerinatal.GlucemiaMayor20Sem.Value.ToString() : "";
            rbGlucemiaMas30Mayor105.Checked = oHistoriaClinicaPerinatal.GlucemiaMayor20SemMayor105.HasValue ? oHistoriaClinicaPerinatal.GlucemiaMayor20SemMayor105.Value : false;
            //Estreptococo B
            rbEstreptococoBNegativo.Checked = oHistoriaClinicaPerinatal.EstreptococoB3537SemanasNegativo.HasValue ? oHistoriaClinicaPerinatal.EstreptococoB3537SemanasNegativo.Value : false;
            rbEstreptococoBPositivo.Checked = oHistoriaClinicaPerinatal.EstreptococoB3537SemanasPositivo.HasValue ? oHistoriaClinicaPerinatal.EstreptococoB3537SemanasPositivo.Value : false;
            rbEstreptococoBNoSeHizo.Checked = oHistoriaClinicaPerinatal.EstreptococoB3537SemanasNoSeHizo.HasValue ? oHistoriaClinicaPerinatal.EstreptococoB3537SemanasNoSeHizo.Value : false;
            //Preparacion Parto
            rbPreparacionPartoNo.Checked = oHistoriaClinicaPerinatal.PreparacionPartoNo.HasValue ? oHistoriaClinicaPerinatal.PreparacionPartoNo.Value : false;
            rbPreparacionPartoSi.Checked = oHistoriaClinicaPerinatal.PreparacionPartoSi.HasValue ? oHistoriaClinicaPerinatal.PreparacionPartoSi.Value : false;
            //Consejeria Lactancia Materna
            rbConsejeriaLactanciaNo.Checked = oHistoriaClinicaPerinatal.ConsejeriaLactanciaMaternaNo.HasValue ? oHistoriaClinicaPerinatal.ConsejeriaLactanciaMaternaNo.Value : false;
            rbConsejeriaLactanciaSi.Checked = oHistoriaClinicaPerinatal.ConsejeriaLactanciaMaternaSi.HasValue ? oHistoriaClinicaPerinatal.ConsejeriaLactanciaMaternaSi.Value : false;
            //Sifilis
            //Prueba no trepo
            rbSifilisPruebaNTPrimerMuestraNegativo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraNegativo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraNegativo.Value : false;
            rbSifilisPruebaNTPrimerMuestraPositivo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraPositivo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraPositivo.Value : false;
            rbSifilisPruebaNTPrimerMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraSinDatos.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraSinDatos.Value : false;
            /*txtSifilisPruebaNTPrimerMuestra.Text = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra.Value.ToString() : "";*/
            txtSifilisPruebaNTPrimerMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraFecha.Value.ToShortDateString() : "";

            rbSifilisPruebaNTSegundaMuestraNegativo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraNegativo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraNegativo.Value : false;
            rbSifilisPruebaNTSegundaMuestraPositivo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraPositivo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraPositivo.Value : false;
            rbSifilisPruebaNTSegundaMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraSinDatos.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraSinDatos.Value : false;
            /*txtSifilisPruebaNTPrimerMuestra.Text = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra.Value.ToString() : "";*/
            txtSifilisPruebaNTSegundaMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraFecha.Value.ToShortDateString() : "";

            rbSifilisPruebaNTTercerMuestraNegativo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraNegativo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraNegativo.Value : false;
            rbSifilisPruebaNTTercerMuestraPositivo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraPositivo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraPositivo.Value : false;
            rbSifilisPruebaNTTercerMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraSinDatos.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraSinDatos.Value : false;
            /*txtSifilisPruebaNTPrimerMuestra.Text = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra.Value.ToString() : "";*/
            txtSifilisPruebaNTTercerMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraFecha.Value.ToShortDateString() : "";
            //Prueba Trepo
            rbSifilisPruebaTPrimerMuestraNegativo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraNegativo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraNegativo.Value : false;
            rbSifilisPruebaTPrimerMuestraPositivo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraPositivo.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraPositivo.Value : false;
            rbSifilisPruebaTPrimerMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraSinDatos.Value : false;
            rbSifilisPruebaTPrimerMuestraNC.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraNoCorresponde.Value : false;
            /*txtSifilisPruebaTPrimerMuestra.Text = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra.Value.ToString() : "";*/
            txtSifilisPruebaTPrimerMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraFecha.Value.ToShortDateString() : "";

            rbSifilisPruebaTSegundaMuestraNegativo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraNegativo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraNegativo.Value : false;
            rbSifilisPruebaTSegundaMuestraPositivo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraPositivo.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraPositivo.Value : false;
            rbSifilisPruebaTSegundaMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraSinDatos.Value : false;
            rbSifilisPruebaTSegundaMuestraNC.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraNoCorresponde.Value : false;
            /*txtSifilisPruebaTPrimerMuestra.Text = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra.Value.ToString() : "";*/
            txtSifilisPruebaTSegundaMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraFecha.Value.ToShortDateString() : "";

            rbSifilisPruebaTTercerMuestraNegativo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraNegativo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraNegativo.Value : false;
            rbSifilisPruebaTTercerMuestraPositivo.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraPositivo.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraPositivo.Value : false;
            rbSifilisPruebaTTercerMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraSinDatos.Value : false;
            rbSifilisPruebaTTercerMuestraNC.Checked = oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraNoCorresponde.Value : false;
            /*txtSifilisPruebaTPrimerMuestra.Text = oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra.Value.ToString() : "";*/
            txtSifilisPruebaTTercerMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraFecha.Value.ToShortDateString() : "";

            //Tratamiento
            rbSifilisTratamientoPrimerMuestraNo.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraNo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraNo.Value : false;
            rbSifilisTratamientoPrimerMuestraSi.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraSi.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraSi.Value : false;
            rbSifilisTratamientoPrimerMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraSinDatos.Value : false;
            rbSifilisTratamientoPrimerMuestraNC.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraNoCorresponde.Value : false;
            txtSifilisTratamientoPrimerMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraFecha.Value.ToShortDateString() : "";

            rbSifilisTratamientoSegundaMuestraNo.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraNo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraNo.Value : false;
            rbSifilisTratamientoSegundaMuestraSi.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraSi.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraSi.Value : false;
            rbSifilisTratamientoSegundaMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraSinDatos.Value : false;
            rbSifilisTratamientoSegundaMuestraNC.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraNoCorresponde.Value : false;
            txtSifilisTratamientoSegundaMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraFecha.Value.ToShortDateString() : "";

            rbSifilisTratamientoTercerMuestraNo.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraNo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraNo.Value : false;
            rbSifilisTratamientoTercerMuestraSi.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraSi.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraSi.Value : false;
            rbSifilisTratamientoTercerMuestraSD.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraSinDatos.Value : false;
            rbSifilisTratamientoTercerMuestraNC.Checked = oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraNoCorresponde.Value : false;
            txtSifilisTratamientoTercerMuestraFecha.Text = oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraFecha.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraFecha.Value.ToShortDateString() : "";

            //Pareja
            rbSifilisParejaMenos20No.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemNo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemNo.Value : false;
            rbSifilisParejaMenos20Si.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemSi.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemSi.Value : false;
            rbSifilisParejaMenos20SD.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemSinDatos.Value : false;
            rbSifilisParejaMenos20NC.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemNoCorresponde.Value : false;

            rbSifilisParejaMas20No.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemNo.HasValue ?
                oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemNo.Value : false;
            rbSifilisParejaMas20Si.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemSi.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemSi.Value : false;
            rbSifilisParejaMas20SD.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemSinDatos.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemSinDatos.Value : false;
            rbSifilisParejaMas20NC.Checked = oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemNoCorresponde.HasValue ?
                            oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemNoCorresponde.Value : false;

            //Datos Extras
            //AGO-Antecedentes
            rbAgoAntecedenteEclampsiaNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteEclampsiaNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteEclampsiaNo.Value : false;
            rbAgoAntecedenteEclampsiaSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteEclampsiaSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteEclampsiaSi.Value : false;

            rbAgoAntecedentePreeclampsiaNo.Checked = oHistoriaClinicaPerinatal.OAAntecedentePreeclampsiaNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedentePreeclampsiaNo.Value : false;
            rbAgoAntecedentePreeclampsiaSi.Checked = oHistoriaClinicaPerinatal.OAAntecedentePreeclampsiaSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedentePreeclampsiaSi.Value : false;

            rbAgoAntecedenteCirugiaGUNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteCirugiaGinUrinarNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteCirugiaGinUrinarNo.Value : false;
            rbAgoAntecedenteCirugiaGUSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteCirugiaGinUrinarSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteCirugiaGinUrinarSi.Value : false;

            rbAgoAntecedenteAPPrematuraNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteAPPrematuroNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteAPPrematuroNo.Value : false;
            rbAgoAntecedenteAPPrematuraSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteAPPrematuroSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteAPPrematuroSi.Value : false;

            rbAgoAntecedenteRCIUNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteRCIUNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteRCIUNo.Value : false;
            rbAgoAntecedenteRCIUSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteRCIUSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteRCIUSi.Value : false;

            rbAgoAntecedenteHemorragiaObstetricaNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteHemorragiaObstetricaNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteHemorragiaObstetricaNo.Value : false;
            rbAgoAntecedenteHemorragiaObstetricaSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteHemorragiaObstetricaSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteHemorragiaObstetricaSi.Value : false;

            rbAgoAntecedenteMacrosomoiaFetalNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteMacrosomiaFetalNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteMacrosomiaFetalNo.Value : false;
            rbAgoAntecedenteMacrosomoiaFetalSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteMacrosomiaFetalSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteMacrosomiaFetalSi.Value : false;

            rbAgoAntecedentePolihidramniosNo.Checked = oHistoriaClinicaPerinatal.OAAntecedentePolihidramniosNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedentePolihidramniosNo.Value : false;
            rbAgoAntecedentePolihidramniosSi.Checked = oHistoriaClinicaPerinatal.OAAntecedentePolihidramniosSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedentePolihidramniosSi.Value : false;

            rbAgoAntecedenteOligoanmiosNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteOligoanmiosNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteOligoanmiosNo.Value : false;
            rbAgoAntecedenteOligoanmiosSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteOligoanmiosSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteOligoanmiosSi.Value : false;

            rbAgoAntecedenteRPMembranasNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteRotPremMembranasNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteRotPremMembranasNo.Value : false;
            rbAgoAntecedenteRPMembranasSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteRotPremMembranasSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteRotPremMembranasSi.Value : false;

            rbAgoAntecedenteIsoInmunizacionesNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteIsoinmunizacionesNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteIsoinmunizacionesNo.Value : false;
            rbAgoAntecedenteIsoInmunizacionesSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteIsoinmunizacionesSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteIsoinmunizacionesSi.Value : false;

            rbAgoAntecedenteColestasisNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteColestasisNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteColestasisNo.Value : false;
            rbAgoAntecedenteColestasisSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteColestasisSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteColestasisSi.Value : false;

            rbAgoAntecedenteMortPerinRecurrenteNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteMortPerinatalRecurrenteNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteMortPerinatalRecurrenteNo.Value : false;
            rbAgoAntecedenteMortPerinRecurrenteSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteMortPerinatalRecurrenteSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteMortPerinatalRecurrenteSi.Value : false;

            rbAgoAntecedenteRetencionPlacentaNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteRetencionPlacentaNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteRetencionPlacentaNo.Value : false;
            rbAgoAntecedenteRetencionPlacentaSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteRetencionPlacentaSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteRetencionPlacentaSi.Value : false;

            rbAgoAntecedenteDistociaHombrosNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteDistociaHombrosNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteDistociaHombrosNo.Value : false;
            rbAgoAntecedenteDistociaHombrosSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteDistociaHombrosSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteDistociaHombrosSi.Value : false;

            rbAgoAntecedenteMalformCongenNo.Checked = oHistoriaClinicaPerinatal.OAAntecedenteMalformCongenNo.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteMalformCongenNo.Value : false;
            rbAgoAntecedenteMalformCongenSi.Checked = oHistoriaClinicaPerinatal.OAAntecedenteMalformCongenSi.HasValue ?
                oHistoriaClinicaPerinatal.OAAntecedenteMalformCongenSi.Value : false;

            //AGO-Actual
            rbAgoActualEclampsiaNo.Checked = oHistoriaClinicaPerinatal.OAActualEclampsiaNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualEclampsiaNo.Value : false;
            rbAgoActualEclampsiaSi.Checked = oHistoriaClinicaPerinatal.OAActualEclampsiaSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualEclampsiaSi.Value : false;

            rbAgoActualPreeclampsiaNo.Checked = oHistoriaClinicaPerinatal.OAActualPreeclampsiaNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualPreeclampsiaNo.Value : false;
            rbAgoActualPreeclampsiaSi.Checked = oHistoriaClinicaPerinatal.OAActualPreeclampsiaSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualPreeclampsiaSi.Value : false;

            rbAgoActualCirugiaGUNo.Checked = oHistoriaClinicaPerinatal.OAActualCirugiaGinUrinarNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualCirugiaGinUrinarNo.Value : false;
            rbAgoActualCirugiaGUSi.Checked = oHistoriaClinicaPerinatal.OAActualCirugiaGinUrinarSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualCirugiaGinUrinarSi.Value : false;

            rbAgoActualAPPrematuraNo.Checked = oHistoriaClinicaPerinatal.OAActualAPPrematuroNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualAPPrematuroNo.Value : false;
            rbAgoActualAPPrematuraSi.Checked = oHistoriaClinicaPerinatal.OAActualAPPrematuroSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualAPPrematuroSi.Value : false;

            rbAgoActualRCIUNo.Checked = oHistoriaClinicaPerinatal.OAActualRCIUNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualRCIUNo.Value : false;
            rbAgoActualRCIUSi.Checked = oHistoriaClinicaPerinatal.OAActualRCIUSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualRCIUSi.Value : false;

            rbAgoActualHemorragiaObstetricaNo.Checked = oHistoriaClinicaPerinatal.OAActualHemorragiaObstetricaNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualHemorragiaObstetricaNo.Value : false;
            rbAgoActualHemorragiaObstetricaSi.Checked = oHistoriaClinicaPerinatal.OAActualHemorragiaObstetricaSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualHemorragiaObstetricaSi.Value : false;

            rbAgoActualMacrosomoiaFetalNo.Checked = oHistoriaClinicaPerinatal.OAActualMacrosomiaFetalNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualMacrosomiaFetalNo.Value : false;
            rbAgoActualMacrosomoiaFetalSi.Checked = oHistoriaClinicaPerinatal.OAActualMacrosomiaFetalSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualMacrosomiaFetalSi.Value : false;

            rbAgoActualPolihidramniosNo.Checked = oHistoriaClinicaPerinatal.OAActualPolihidramniosNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualPolihidramniosNo.Value : false;
            rbAgoActualPolihidramniosSi.Checked = oHistoriaClinicaPerinatal.OAActualPolihidramniosSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualPolihidramniosSi.Value : false;

            rbAgoActualOligoanmiosNo.Checked = oHistoriaClinicaPerinatal.OAActualOligoanmiosNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualOligoanmiosNo.Value : false;
            rbAgoActualOligoanmiosSi.Checked = oHistoriaClinicaPerinatal.OAActualOligoanmiosSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualOligoanmiosSi.Value : false;

            rbAgoActualRPMembranasNo.Checked = oHistoriaClinicaPerinatal.OAActualRotPremMembranasNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualRotPremMembranasNo.Value : false;
            rbAgoActualRPMembranasSi.Checked = oHistoriaClinicaPerinatal.OAActualRotPremMembranasSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualRotPremMembranasSi.Value : false;

            rbAgoActualIsoInmunizacionesNo.Checked = oHistoriaClinicaPerinatal.OAActualIsoinmunizacionesNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualIsoinmunizacionesNo.Value : false;
            rbAgoActualIsoInmunizacionesSi.Checked = oHistoriaClinicaPerinatal.OAActualIsoinmunizacionesSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualIsoinmunizacionesSi.Value : false;

            rbAgoActualColestasisNo.Checked = oHistoriaClinicaPerinatal.OAActualColestasisNo.HasValue ?
                oHistoriaClinicaPerinatal.OAActualColestasisNo.Value : false;
            rbAgoActualColestasisSi.Checked = oHistoriaClinicaPerinatal.OAActualColestasisSi.HasValue ?
                oHistoriaClinicaPerinatal.OAActualColestasisSi.Value : false;
            //Factores de Riego
            rbFactorRiesgoEmbarazoSinContSocialNo.Checked = oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoSinContSocialNo.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoSinContSocialNo.Value : false;
            rbFactorRiesgoEmbarazoSinContSocialSi.Checked = oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoSinContSocialSi.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoSinContSocialSi.Value : false;

            rbFactorRiesgoFamiliaSinIngresosFijosNo.Checked = oHistoriaClinicaPerinatal.FactorRiesgoFamiliaSinIngresosFijosNo.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoFamiliaSinIngresosFijosNo.Value : false;
            rbFactorRiesgoFamiliaSinIngresosFijosSi.Checked = oHistoriaClinicaPerinatal.FactorRiesgoFamiliaSinIngresosFijosSi.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoFamiliaSinIngresosFijosSi.Value : false;

            rbFactorRiesgoEmbarazoFuertRechazadoNo.Checked = oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoFuertRechazadoNo.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoFuertRechazadoNo.Value : false;
            rbFactorRiesgoEmbarazoFuertRechazadoSi.Checked = oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoFuertRechazadoSi.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoFuertRechazadoSi.Value : false;

            rbFactorRiesgoHijosDadosAdopcionNo.Checked = oHistoriaClinicaPerinatal.FactorRiesgoHijosDadosAdopcionNo.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoHijosDadosAdopcionNo.Value : false;
            rbFactorRiesgoHijosDadosAdopcionSi.Checked = oHistoriaClinicaPerinatal.FactorRiesgoHijosDadosAdopcionSi.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoHijosDadosAdopcionSi.Value : false;

            rbFactorRiesgoViviendaSinServiciosBasicosNo.Checked = oHistoriaClinicaPerinatal.FactorRiesgoViviendaSinServiciosBasicosNo.HasValue ?
                oHistoriaClinicaPerinatal.FactorRiesgoViviendaSinServiciosBasicosNo.Value : false;
            rbFactorRiesgoViviendaSinServiciosBasicosSi.Checked = oHistoriaClinicaPerinatal.FactorRiesgoViviendaSinServiciosBasicosSi.HasValue ?
               oHistoriaClinicaPerinatal.FactorRiesgoViviendaSinServiciosBasicosSi.Value : false;
            //Captacion Oportuna
            rbCaptacionOportunaAntes16Sem.Checked = oHistoriaClinicaPerinatal.CaptacionOportunaAntes16sem.HasValue ?
                oHistoriaClinicaPerinatal.CaptacionOportunaAntes16sem.Value : false;
            rbCaptacionOportunaDespues16Sem.Checked = oHistoriaClinicaPerinatal.CaptacionOportunaDespues16sem.HasValue ?
                oHistoriaClinicaPerinatal.CaptacionOportunaDespues16sem.Value : false;

            txtFechaMuestraPAP.Text = oHistoriaClinicaPerinatal.FechaMuestraPAP.HasValue ?
                oHistoriaClinicaPerinatal.FechaMuestraPAP.Value.ToShortDateString() : "";
            //Fecha Triple Acelular
            txtFechaTripleAcelular.Text = oHistoriaClinicaPerinatal.FechaTripleAcelular.HasValue ?
                oHistoriaClinicaPerinatal.FechaTripleAcelular.Value.ToShortDateString() : "";
            //Fecha antigripal es obligatoria
            txtFechaAntigripal.Text = oHistoriaClinicaPerinatal.FechaAntigripal.HasValue ?
                oHistoriaClinicaPerinatal.FechaAntigripal.Value.ToShortDateString() : "";

            ////Datos agregados de activa y observaciones
            //if (oHistoriaClinicaPerinatal.Activa == true) ckbActivo.Checked = true;
            //else oHistoriaClinicaPerinatal.Activa = false;
            //txtObservaciones.Text = oHistoriaClinicaPerinatal.Observaciones;
           
            //datos de enfermedades actuales 22/09/2014
            rbDesarrollaAnemiaNo.Checked = oHistoriaClinicaPerinatal.AnemiaNo.HasValue ?
            oHistoriaClinicaPerinatal.AnemiaNo.Value : false;
            rbDesarrollaAnemiaSi.Checked = oHistoriaClinicaPerinatal.AnemiaSi.HasValue ?
            oHistoriaClinicaPerinatal.AnemiaSi.Value : false;
            //Diabetes actual
            rbDesarrollaDiabetesNo.Checked = oHistoriaClinicaPerinatal.DiabetesActualNo.HasValue ?
            oHistoriaClinicaPerinatal.DiabetesActualNo.Value : false;
            rbDesarrollaDiabetesSi.Checked = oHistoriaClinicaPerinatal.DiabetesActualSi.HasValue ?
            oHistoriaClinicaPerinatal.DiabetesActualSi.Value : false;

            //Detalles de Historia Clinica
            //rptDetalles.DataSource = oHistoriaClinicaPerinatal.AprHistoriaClinicaPerinatalDetalleRecords.Where(P => P.Activa == true);
            //rptDetalles.DataSource = SPs.AprGetHCPDetalle(oHistoriaClinicaPerinatal.IdHistoriaClinicaPerinatal);

            DataTable dtHCPDetalle = SPs.AprGetHCPDetalle(oHistoriaClinicaPerinatal.IdHistoriaClinicaPerinatal).GetDataSet().Tables[0];
            rptDetalles.DataSource = dtHCPDetalle;

            rptDetalles.DataBind();
           
        }

        private void CargarDatosDelPaciente(SysPaciente oPaciente)
        {
            SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            hfPrimerControl.Value = "1";

            // Datos basicos
            lblNombre.Text = oPaciente.Nombre;
            lblApellido.Text = oPaciente.Apellido;
            lblDomicilio.Text = String.Format("{0} {1} {2} {3}", oPaciente.Calle, oPaciente.Numero, oPaciente.Manzana, oPaciente.Lote);
            lblDocumento.Text = oPaciente.NumeroDocumento.ToString();
            lblTelefono.Text = oPaciente.TelefonoFijo + oPaciente.TelefonoCelular;
            lblLocalidad.Text = oPaciente.IdLocalidad == -1 ? "" : oPaciente.SysLocalidad.Nombre;
            //lblNumeroIdentidad.Text = oPaciente.HistoriaClinica.ToString();

            if (SSOHelper.CurrentIdentity.Username != null && efector.Nombre != null)
            {
                lblLugarControlPerinatal.Text = efector.NombreNacion;
            }
            else
            {
                lblLugarControlPerinatal.Text = "00000000";
            }
            //Fecha Nacimiento
            lblDiaNacimeinto.Text = String.Format("{0:00}", oPaciente.FechaNacimiento.Day);
            lblMesNacimiento.Text = String.Format("{0:00}", oPaciente.FechaNacimiento.Month);
            lblAñoNacimiento.Text = String.Format("{0:00}", oPaciente.FechaNacimiento.Year.ToString().Substring(2));
            hfFechaNacimiento.Value = oPaciente.FechaNacimiento.ToShortDateString();
            //Edad
            DateDifference oEdad = new DateDifference(oPaciente.FechaNacimiento, DateTime.Now);
            lblEdad.Text = String.Format("{0:00}", oEdad.Years);
            if (oEdad.Years < 15 || oEdad.Years > 35)
            {
                rbEdad.Checked = true;
            }
            //Etnia
            /*  if (oPaciente.IdEtnia > -1)
              {
                  switch (oPaciente.IdEtnia)
                  {
                      case 1: rbEtniaBlanca.Checked = true; break;
                      case 2: rbEtniaIndigena.Checked = true; break;
                      case 3: rbEtniaMestiza.Checked = true; break;
                      case 4: rbEtniaNegra.Checked = true; break;
                      case 5: rbEtniaOtra.Checked = true; break;
                  }
              }
              //Estado Civil
              if (oPaciente.IdEstadoCivil > 0)
              {
                  switch (oPaciente.IdEstadoCivil)
                  {
                      case 1: rbEstadoCivilCasada.Checked = true; break;
                      case 2: rbEstadoCivilSoltera.Checked = true; break;
                      case 3: rbEstadoCivilOtro.Checked = true; break;
                      case 4: rbEstadoCivilOtro.Checked = true; break;
                      case 5: rbEstadoCivilOtro.Checked = true; break;
                  }
              } 

              //Nivel de estudios
              if (oPaciente.IdNivelInstruccion > -1)
              {
                  switch (oPaciente.IdNivelInstruccion)
                  {
                      case 0: rbEstudiosNinguno.Checked = true; break;
                      case 1: rbEstudiosNinguno.Checked = true; break;
                      case 2: rbEstudiosNinguno.Checked = true; break;
                      case 3: rbEstudiosNinguno.Checked = true; break;

                      case 4: rbEstudiosPrimaria.Checked = true; break;
                      //A partir de primaria completa, se considera alfabeta.
                      case 5: rbEstudiosPrimaria.Checked = true; rbAlfabetaSi.Checked = true; break;

                      case 6: rbEstudiosSecundario.Checked = true; rbAlfabetaSi.Checked = true; break;
                      case 7: rbEstudiosSecundario.Checked = true; rbAlfabetaSi.Checked = true; break;

                      case 8: rbEstudiosUniversitarios.Checked = true; rbAlfabetaSi.Checked = true; break;
                      case 9: rbEstudiosUniversitarios.Checked = true; rbAlfabetaSi.Checked = true; break;
                      case 10: rbEstudiosUniversitarios.Checked = true; rbAlfabetaSi.Checked = true; break;
                      case 11: rbEstudiosUniversitarios.Checked = true; rbAlfabetaSi.Checked = true; break;
                  }
              }  ???? */

        }

        private void AsignarValores(AprHistoriaClinicaPerinatal oHistoriaClinicaPerinatal)
        {
            oHistoriaClinicaPerinatal.LugarControlPerinatal = lblLugarControlPerinatal.Text;
            // Datos basicos
            oHistoriaClinicaPerinatal.Nombre = lblNombre.Text;
            oHistoriaClinicaPerinatal.Apellido = lblApellido.Text;
            oHistoriaClinicaPerinatal.Domicilio = lblDomicilio.Text;
            oHistoriaClinicaPerinatal.Dni = lblDocumento.Text;
            oHistoriaClinicaPerinatal.Telefono = lblTelefono.Text;
            oHistoriaClinicaPerinatal.Localidad = lblLocalidad.Text;
            DateTime fechaNacimiento;
            if (DateTime.TryParse(hfFechaNacimiento.Value, out fechaNacimiento))
                oHistoriaClinicaPerinatal.FechaNacimiento = fechaNacimiento;
            int edad;
            if (Int32.TryParse(lblEdad.Text, out edad))
                oHistoriaClinicaPerinatal.Edad = edad;
            //Datos de Contacto
            oHistoriaClinicaPerinatal.DatosDeContacto = txtDatosContacto.Text;
            oHistoriaClinicaPerinatal.EdadMenor15Mayor35 = rbEdad.Checked;
            //Etnia
            oHistoriaClinicaPerinatal.EtniaBlanca = rbEtniaBlanca.Checked;
            oHistoriaClinicaPerinatal.EtniaIndigena = rbEtniaIndigena.Checked;
            oHistoriaClinicaPerinatal.EtniaMestiza = rbEtniaMestiza.Checked;
            oHistoriaClinicaPerinatal.EtniaNegra = rbEtniaNegra.Checked;
            oHistoriaClinicaPerinatal.EtniaOtra = rbEtniaOtra.Checked;
            //Alfabeta
            oHistoriaClinicaPerinatal.AlfabetaNo = rbAlfabetaNo.Checked;
            oHistoriaClinicaPerinatal.AlfabetaSi = rbAlfabetaSi.Checked;
            //Estudios
            oHistoriaClinicaPerinatal.EstudiosNinguno = rbEstudiosNinguno.Checked;
            oHistoriaClinicaPerinatal.EstudiosPrimario = rbEstudiosPrimaria.Checked;
            oHistoriaClinicaPerinatal.EstudiosSecundario = rbEstudiosSecundario.Checked;
            oHistoriaClinicaPerinatal.EstudiosUniversitario = rbEstudiosUniversitarios.Checked;
            int AñosMayorNivel = 0;
            if (Int32.TryParse(txtEstudiosAniosMayorNivel.Text, out AñosMayorNivel))
                oHistoriaClinicaPerinatal.AñosMayorNivel = AñosMayorNivel;
            else oHistoriaClinicaPerinatal.AñosMayorNivel = 0;
            //Estado Civil
            oHistoriaClinicaPerinatal.EstadoCivilCasada = rbEstadoCivilCasada.Checked;
            oHistoriaClinicaPerinatal.EstadoCivilUnionEstable = rbEstadoCivilUnionEstable.Checked;
            oHistoriaClinicaPerinatal.EstadoCivilSoltera = rbEstadoCivilSoltera.Checked;
            oHistoriaClinicaPerinatal.EstadoCivilOtro = rbEstadoCivilOtro.Checked;
            //Vive Sola
            oHistoriaClinicaPerinatal.ViveSolaNo = rbViveSolaNo.Checked;
            oHistoriaClinicaPerinatal.ViveSolaSi = rbViveSolaSi.Checked;
            //Antecedentes Familiares
            oHistoriaClinicaPerinatal.AntFamTBCNo = rbAntecedenteFamiliarTBCNo.Checked;
            oHistoriaClinicaPerinatal.AntFamTBCSi = rbAntecedenteFamiliarTBCSi.Checked;
            oHistoriaClinicaPerinatal.AntFamDiabetesNo = rbAntecedenteFamiliarDiabetesNo.Checked;
            oHistoriaClinicaPerinatal.AntFamDiabetesSi = rbAntecedenteFamiliarDiabetesSi.Checked;
            oHistoriaClinicaPerinatal.AntFamHipertensionNo = rbAntecedenteFamiliarHipertensionNo.Checked;
            oHistoriaClinicaPerinatal.AntFamHipertensionSi = rbAntecedenteFamiliarHipertensionSi.Checked;
            oHistoriaClinicaPerinatal.AntFamInfeccionUrinariaNo = rbAntecedenteFamiliarInfUrinariaNo.Checked;
            oHistoriaClinicaPerinatal.AntFamInfeccionUrinariaSi = rbAntecedenteFamiliarInfUrinariaSi.Checked;
            oHistoriaClinicaPerinatal.AntFamOtrasInfeccionesNo = rbAntecedenteFamiliarOtrasInfeccionesNo.Checked;
            oHistoriaClinicaPerinatal.AntFamOtrasInfeccionesSi = rbAntecedenteFamiliarOtrasInfeccionesSi.Checked;
            oHistoriaClinicaPerinatal.AntFamOtroNo = rbAntecedenteFamiliarOtraCondNo.Checked;
            oHistoriaClinicaPerinatal.AntFamOtroSi = rbAntecedenteFamiliarOtraCondSi.Checked;

            //Antecedentes Personales
            oHistoriaClinicaPerinatal.AntPerTBCNo = rbAntecedentePersonalTBCNo.Checked;
            oHistoriaClinicaPerinatal.AntPerTBCSi = rbAntecedentePersonalTBCSi.Checked;
            oHistoriaClinicaPerinatal.AntPerDiabetesNo = rbAntecedentePersonalDiabetesNo.Checked;
            oHistoriaClinicaPerinatal.AntPerDiabetesI = rbAntecedentePersonalDiabetesI.Checked;
            oHistoriaClinicaPerinatal.AntPerDiabetesII = rbAntecedentePersonalDiabetesII.Checked;
            oHistoriaClinicaPerinatal.AntPerDiabetesG = rbAntecedentePersonalDiabetesG.Checked;
            oHistoriaClinicaPerinatal.AntPerHipertensionNo = rbAntecedentePersonalHipertensionNo.Checked;
            oHistoriaClinicaPerinatal.AntPerHipertensionSi = rbAntecedentePersonalHipertensionSi.Checked;
            oHistoriaClinicaPerinatal.AntPerInfeccionUrinariaNo = rbAntecedentePersonalInfUrinariaNo.Checked;
            oHistoriaClinicaPerinatal.AntPerInfeccionUrinariaSi = rbAntecedentePersonalInfUrinariaSi.Checked;
            oHistoriaClinicaPerinatal.AntPerOtrasInfeccionesNo = rbAntecedentePersonalOtrasInfeccionesNo.Checked;
            oHistoriaClinicaPerinatal.AntPerOtrasInfeccionesSi = rbAntecedentePersonalOtrasInfeccionesSi.Checked;
            oHistoriaClinicaPerinatal.AntPerOtroNo = rbAntecedentePersonalOtraCondNo.Checked;
            oHistoriaClinicaPerinatal.AntPerOtroSi = rbAntecedentePersonalOtraCondSi.Checked;
            oHistoriaClinicaPerinatal.AntPerInfertilidadNo = rbAntecedentePersonalInfertilidadNo.Checked;
            oHistoriaClinicaPerinatal.AntPerInfertilidadSi = rbAntecedentePersonalInfertilidadSi.Checked;
            oHistoriaClinicaPerinatal.AntPerCardiopatiaNo = rbAntecedentePersonalCardiopatiaNo.Checked;
            oHistoriaClinicaPerinatal.AntPerCardiopatiaSi = rbAntecedentePersonalCardiopatiaSi.Checked;
            oHistoriaClinicaPerinatal.AntPerNefropatiaNo = rbAntecedentePersonalNefropatiaNo.Checked;
            oHistoriaClinicaPerinatal.AntPerNefropatiaSi = rbAntecedentePersonalNefropatiaSi.Checked;
            oHistoriaClinicaPerinatal.AntPerViolenciaNo = rbAntecedentePersonalViolenciaNo.Checked;
            oHistoriaClinicaPerinatal.AntPerViolenciaSi = rbAntecedentePersonalViolenciaSi.Checked;
            oHistoriaClinicaPerinatal.AntPerAlergiaMedicamentoNo = rbAntecedentePersonalAlergiaMedicamentoNo.Checked;
            oHistoriaClinicaPerinatal.AntPerAlergiaMedicamentoSi = rbAntecedentePersonalAlergiaMedicamentoSi.Checked;

            oHistoriaClinicaPerinatal.AntecedentesObservacion = txtAntecedentesObervaciones.Text;
            //Antecedente Obstetricos
            int gestasprevias, abortos, embarazosectopicos, partos, partosvaginales, cesareas, nacidosmuertos, nacidosvivos, muertosprimersemana,
                muertosdespuesprimersemana, viven;
            if (Int32.TryParse(txtGestasPrevias.Text, out gestasprevias))
                oHistoriaClinicaPerinatal.GestasPrevias = gestasprevias;
            if (Int32.TryParse(txtAbortos.Text, out abortos))
                oHistoriaClinicaPerinatal.Abortos = abortos;
            if (Int32.TryParse(txtEmbarazosEctopicos.Text, out embarazosectopicos))
                oHistoriaClinicaPerinatal.EmbEctopicos = embarazosectopicos;
            oHistoriaClinicaPerinatal.Abortos3concecutivos = rbAbortos3Concecutivos.Checked;
            if (Int32.TryParse(txtPartos.Text, out partos))
                oHistoriaClinicaPerinatal.Partos = partos;
            oHistoriaClinicaPerinatal.AntecedentesGemelaresNo = rbAntecedentesGemelaresNo.Checked;
            oHistoriaClinicaPerinatal.AntecedentesGemelaresSi = rbAntecedentesGemelaresSi.Checked;
            oHistoriaClinicaPerinatal.UltPrevioNC = rbUltimoPrevioNoCorresponde.Checked;
            oHistoriaClinicaPerinatal.UltPrevioNormal = rbUltimoPrevioNormal.Checked;
            oHistoriaClinicaPerinatal.UltPrevioMenor2500 = rbUltimoPrevioMenor2500.Checked;
            oHistoriaClinicaPerinatal.UltPrevioMayor4000 = rbUltimoPrevioMayor4000.Checked;
            if (Int32.TryParse(txtPartosVaginales.Text, out partosvaginales))
                oHistoriaClinicaPerinatal.PartosVaginales = partosvaginales;
            if (Int32.TryParse(txtCesareas.Text, out cesareas))
                oHistoriaClinicaPerinatal.Cesareas = cesareas;
            if (Int32.TryParse(txtNacidosMuertos.Text, out nacidosmuertos))
                oHistoriaClinicaPerinatal.NacidosMuertos = nacidosmuertos;
            if (Int32.TryParse(txtNacidosVivos.Text, out nacidosvivos))
                oHistoriaClinicaPerinatal.NacidosVivos = nacidosvivos;
            if (Int32.TryParse(txtMuertosPrimerSemana.Text, out muertosprimersemana))
                oHistoriaClinicaPerinatal.MuertosPrimerSemana = muertosprimersemana;
            if (Int32.TryParse(txtMuertosDespuesPrimerSemana.Text, out muertosdespuesprimersemana))
                oHistoriaClinicaPerinatal.MuertosDespuesPrimerSemana = muertosdespuesprimersemana;
            if (Int32.TryParse(txtViven.Text, out viven))
                oHistoriaClinicaPerinatal.Viven = viven;
            DateTime finembanterior;
            if (DateTime.TryParse(txtFinEmbAnterior.Text, out finembanterior))
                oHistoriaClinicaPerinatal.FinEmbarazoAnterior = finembanterior;
            oHistoriaClinicaPerinatal.FinEmbAnteriorMenor1Año = rbFinEmbAnteriorMenor1Año.Checked;
            oHistoriaClinicaPerinatal.EmbarazoPlaneadoNo = rbEmbarazoPlaneadoNo.Checked;
            oHistoriaClinicaPerinatal.EmbarazoPlaneadoSi = rbEmbarazoPlaneadoSi.Checked;
            oHistoriaClinicaPerinatal.FracMetAnticonceptivoNoUsaba = rbFracMetAnticonceptivoNoUsaba.Checked;
            oHistoriaClinicaPerinatal.FracMetAnticonceptivoBarrera = rbFracMetAnticonceptivoBarrera.Checked;
            oHistoriaClinicaPerinatal.FracMetAnticonceptivoDIU = rbFracMetAnticonceptivoDIU.Checked;
            oHistoriaClinicaPerinatal.FracMetAnticonceptivoHormonal = rbFracMetAnticonceptivoHormonal.Checked;
            oHistoriaClinicaPerinatal.FracMetAnticonceptivoEmergencia = rbFracMetAnticonceptivoEmergencia.Checked;
            oHistoriaClinicaPerinatal.FracMetAnticonceptivoNatural = rbFracMetAnticonceptivoNatural.Checked;
            //Gestacion Actual // Peso Anterior
            decimal pesoanterior; int talla; DateTime fum, fpp;
            // if (Decimal.TryParse(txtPesoAnterior.Text, out pesoanterior))
            //     oHistoriaClinicaPerinatal.PesoAnterior = pesoanterior;
            // else oHistoriaClinicaPerinatal.PesoAnterior = 0;
            if (Decimal.TryParse(txtPesoAnterior.Text.Replace(",", "."), System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out pesoanterior))
                oHistoriaClinicaPerinatal.PesoAnterior = pesoanterior;
            else oHistoriaClinicaPerinatal.PesoAnterior = 0;
            if (Int32.TryParse(txtTalla.Text, out talla))
                oHistoriaClinicaPerinatal.Talla = talla;
            else oHistoriaClinicaPerinatal.Talla = 0;
            if (DateTime.TryParse(txtFUM.Text, out fum))
                oHistoriaClinicaPerinatal.Fum = fum;
            if (DateTime.TryParse(txtFPP.Text, out fpp))
                oHistoriaClinicaPerinatal.Fpp = fpp;
            //EG Confiable
            oHistoriaClinicaPerinatal.EGConfiableFUMNo = rbEGConfiableFUMNo.Checked;
            oHistoriaClinicaPerinatal.EGConfiableFUMSi = rbEGConfiableFUMSi.Checked;
            oHistoriaClinicaPerinatal.EGConfiableEcoMenor20semanasNo = rbEGConfiableEco20No.Checked;
            oHistoriaClinicaPerinatal.EGConfiableEcoMenor20semanasSi = rbEGConfiableEco20Si.Checked;
            //Drogas
            oHistoriaClinicaPerinatal.FumaActivo1TrimNo = rbFumaActiva1TrimNo.Checked;
            oHistoriaClinicaPerinatal.FumaActivo1TrimSi = rbFumaActiva1TrimSi.Checked;
            oHistoriaClinicaPerinatal.FumaActivo2TrimNo = rbFumaActiva2TrimNo.Checked;
            oHistoriaClinicaPerinatal.FumaActivo2TrimSi = rbFumaActiva2TrimSi.Checked;
            oHistoriaClinicaPerinatal.FumaActivo3TrimNo = rbFumaActiva3TrimNo.Checked;
            oHistoriaClinicaPerinatal.FumaActivo3TrimSi = rbFumaActiva3TrimSi.Checked;

            oHistoriaClinicaPerinatal.FumaPasivo1TrimNo = rbFumaPasiva1TrimNo.Checked;
            oHistoriaClinicaPerinatal.FumaPasivo1TrimSi = rbFumaPasiva1TrimSi.Checked;
            oHistoriaClinicaPerinatal.FumaPasivo2TrimNo = rbFumaPasiva2TrimNo.Checked;
            oHistoriaClinicaPerinatal.FumaPasivo2TrimSi = rbFumaPasiva2TrimSi.Checked;
            oHistoriaClinicaPerinatal.FumaPasivo3TrimNo = rbFumaPasiva3TrimNo.Checked;
            oHistoriaClinicaPerinatal.FumaPasivo3TrimSi = rbFumaPasiva3TrimSi.Checked;

            oHistoriaClinicaPerinatal.Drogas1TrimNo = rbDrogas1TrimNo.Checked;
            oHistoriaClinicaPerinatal.Drogas1TrimSi = rbDrogas1TrimSi.Checked;
            oHistoriaClinicaPerinatal.Drogas2TrimNo = rbDrogas2TrimNo.Checked;
            oHistoriaClinicaPerinatal.Drogas2TrimSi = rbDrogas2TrimSi.Checked;
            oHistoriaClinicaPerinatal.Drogas3TrimNo = rbDrogas3TrimNo.Checked;
            oHistoriaClinicaPerinatal.Drogas3TrimSi = rbDrogas3TrimSi.Checked;

            oHistoriaClinicaPerinatal.Alcohol1TrimNo = rbAlcohol1TrimNo.Checked;
            oHistoriaClinicaPerinatal.Alcohol1TrimSi = rbAlcohol1TrimSi.Checked;
            oHistoriaClinicaPerinatal.Alcohol2TrimNo = rbAlcohol2TrimNo.Checked;
            oHistoriaClinicaPerinatal.Alcohol2TrimSi = rbAlcohol2TrimSi.Checked;
            oHistoriaClinicaPerinatal.Alcohol3TrimNo = rbAlcohol3TrimNo.Checked;
            oHistoriaClinicaPerinatal.Alcohol3TrimSi = rbAlcohol3TrimSi.Checked;

            oHistoriaClinicaPerinatal.Violencia1TrimNo = rbViolencia1TrimNo.Checked;
            oHistoriaClinicaPerinatal.Violencia1TrimSi = rbViolencia1TrimSi.Checked;
            oHistoriaClinicaPerinatal.Violencia2TrimNo = rbViolencia2TrimNo.Checked;
            oHistoriaClinicaPerinatal.Violencia2TrimSi = rbViolencia2TrimSi.Checked;
            oHistoriaClinicaPerinatal.Violencia3TrimNo = rbViolencia3TrimNo.Checked;
            oHistoriaClinicaPerinatal.Violencia3TrimSi = rbViolencia3TrimSi.Checked;
            //Antirubeola
            oHistoriaClinicaPerinatal.AntirubeolaPrevia = rbAntirubeolaPrevia.Checked;
            oHistoriaClinicaPerinatal.AntirubeolaNoSabe = rbAntirubeolaNoSabe.Checked;
            oHistoriaClinicaPerinatal.AntirubeolaEmbarazo = rbAntirubeolaEmbarazo.Checked;
            oHistoriaClinicaPerinatal.AntirubeolaNo = rbAntirubeolaNo.Checked;
            //Antitetanica
            oHistoriaClinicaPerinatal.AntitetanicaVigenteNo = rbAntitetanicaVigenteNo.Checked;
            oHistoriaClinicaPerinatal.AntitetanicaVigenteSi = rbAntitetanicaVigenteSi.Checked;
            int antitetanicadosis1, antitetanicadosis2;
            if (Int32.TryParse(txtAntitetanicaDosis1.Text, out antitetanicadosis1))
                oHistoriaClinicaPerinatal.Antitetanica1DosisMesGestacion = antitetanicadosis1;
            else oHistoriaClinicaPerinatal.Antitetanica1DosisMesGestacion = 0;
            if (Int32.TryParse(txtAntitetanicaDosis2.Text, out antitetanicadosis2))
                oHistoriaClinicaPerinatal.Antitetanica2DosisMesGestacion = antitetanicadosis2;
            else oHistoriaClinicaPerinatal.Antitetanica2DosisMesGestacion = 0;
            //Ex.Normal
            oHistoriaClinicaPerinatal.ExamenOdotologicoNormalNo = rbExNormalOdontNo.Checked;
            oHistoriaClinicaPerinatal.ExamenOdotologicoNormalSi = rbExNormalOdontSi.Checked;
            oHistoriaClinicaPerinatal.ExamenMamasNormalNo = rbExNormalMamasNo.Checked;
            oHistoriaClinicaPerinatal.ExamenMamasNormalSi = rbExNormalMamasSi.Checked;
            //Cervix
            oHistoriaClinicaPerinatal.CervixInspeccionVisualNormal = rbCervixVisualNormal.Checked;
            oHistoriaClinicaPerinatal.CervixInspeccionVisualAnormal = rbCervixVisualANormal.Checked;
            oHistoriaClinicaPerinatal.CervixInspeccionVisualNoSeHizo = rbCervixVisualNoSeHizo.Checked;
            oHistoriaClinicaPerinatal.CervixPAPNormal = rbCervixPAPNormal.Checked;
            oHistoriaClinicaPerinatal.CervixPAPAnormal = rbCervixPAPANormal.Checked;
            oHistoriaClinicaPerinatal.CervixPAPNoSeHizo = rbCervixPAPNoSeHizo.Checked;
            oHistoriaClinicaPerinatal.CervixCOLPNormal = rbCervixCOLPNormal.Checked;
            oHistoriaClinicaPerinatal.CervixCOLPAnormal = rbCervixCOLPANormal.Checked;
            oHistoriaClinicaPerinatal.CervixCOLPNoSeHizo = rbCervixCOLPNoSeHizo.Checked;
            //Sangre
            oHistoriaClinicaPerinatal.Grupo = txtGrupo.Text;
            oHistoriaClinicaPerinatal.RHNegativo = rbSangreRhNegativo.Checked;
            oHistoriaClinicaPerinatal.RHPositivo = rbSangreRhPositivo.Checked;
            oHistoriaClinicaPerinatal.InmunizacionNo = rbSangreInmunizNo.Checked;
            oHistoriaClinicaPerinatal.InmunizacionSi = rbSangreInmunizSi.Checked;
            //Toxoplasmosis
            oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGNegativo = rbToxoplasmosisMenos20IgGNegativo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGPositivo = rbToxoplasmosisMenos20IgGPositivo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosisMenor20SemLGGNoSeHizo = rbToxoplasmosisMenos20IgGNoSeHizo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGNegativo = rbToxoplasmosisMas20IgGNegativo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGPositivo = rbToxoplasmosisMas20IgGPositivo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosisMayor20SemLGGNoSeHizo = rbToxoplasmosisMas20IgGNoSeHizo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMNegativo = rbToxoplasmosis1ConsultaIgMNegativo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMPositivo = rbToxoplasmosis1ConsultaIgMPositivo.Checked;
            oHistoriaClinicaPerinatal.ToxoPlasmosis1ConsultaLGMNoSeHizo = rbToxoplasmosis1ConsultaIgMNoSeHizo.Checked;
            //VIH Condicion de Riesgo
            oHistoriaClinicaPerinatal.VIHCRNo = rbVIHCRNo.Checked;
            oHistoriaClinicaPerinatal.VIHCRSi = rbVIHCRSi.Checked;
            // VIH Primer Muestra
            oHistoriaClinicaPerinatal.VIHPrimerMuestraSolicitadoNo = rbVIHPrimerMuestraSolicitadoNo.Checked;
            oHistoriaClinicaPerinatal.VIHPrimerMuestraSolicitadoSi = rbVIHPrimerMuestraSolicitadoSi.Checked;
            oHistoriaClinicaPerinatal.VIHPrimerMuestraRealizadoNo = rbVIHPrimerMuestraRealizadoNo.Checked;
            oHistoriaClinicaPerinatal.VIHPrimerMuestraRealizadoSi = rbVIHPrimerMuestraRealizadoSi.Checked;
            DateTime vihprimermuestrafecha;
            if (DateTime.TryParse(txtVIHPrimerMuestraFecha.Text, out vihprimermuestrafecha))
                oHistoriaClinicaPerinatal.VIHPrimerMuestraFecha = vihprimermuestrafecha;
            // VIH Segunda Muestra
            oHistoriaClinicaPerinatal.VIHSegundaMuestraSolicitadoNo = rbVIHSegundaMuestraSolicitadoNo.Checked;
            oHistoriaClinicaPerinatal.VIHSegundaMuestraSolicitadoSi = rbVIHSegundaMuestraSolicitadoSi.Checked;
            oHistoriaClinicaPerinatal.VIHSegundaMuestraRealizadoNo = rbVIHSegundaMuestraRealizadoNo.Checked;
            oHistoriaClinicaPerinatal.VIHSegundaMuestraRealizadoSi = rbVIHSegundaMuestraRealizadoSi.Checked;
            DateTime vihsegundamuestrafecha;
            if (DateTime.TryParse(txtVIHSegundaMuestraFecha.Text, out vihsegundamuestrafecha))
                oHistoriaClinicaPerinatal.VIHSegundaMuestraFecha = vihsegundamuestrafecha;
            // VIH tercer Muestra
            oHistoriaClinicaPerinatal.VIHTercerMuestraSolicitadoNo = rbVIHTercerMuestraSolicitadoNo.Checked;
            oHistoriaClinicaPerinatal.VIHTercerMuestraSolicitadoSi = rbVIHTercerMuestraSolicitadoSi.Checked;
            oHistoriaClinicaPerinatal.VIHTercerMuestraRealizadoNo = rbVIHTercerMuestraRealizadoNo.Checked;
            oHistoriaClinicaPerinatal.VIHTercerMuestraRealizadoSi = rbVIHTercerMuestraRealizadoSi.Checked;
            DateTime vihtercermuestrafecha;
            if (DateTime.TryParse(txtVIHTercerMuestraFecha.Text, out vihtercermuestrafecha))
                oHistoriaClinicaPerinatal.VIHTercerMuestraFecha = vihtercermuestrafecha;
            //Hemoglobina
            decimal hbmenor20sem, hbmayor20sem;
            if (Decimal.TryParse(txtHBMenos20.Text.Replace(",", "."), System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out hbmenor20sem))
                oHistoriaClinicaPerinatal.HBMenor20Sem = hbmenor20sem;
            else oHistoriaClinicaPerinatal.HBMenor20Sem = 0;
            oHistoriaClinicaPerinatal.HBMenor20SemMenor11 = rbHemoglobinaMenos20Menor11.Checked;
            if (Decimal.TryParse(txtHBMas20.Text.Replace(",", "."), System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out hbmayor20sem))
                oHistoriaClinicaPerinatal.HBMayor20Sem = hbmayor20sem;
            else oHistoriaClinicaPerinatal.HBMayor20Sem = 0;
            oHistoriaClinicaPerinatal.HBMayor20SemMenor11 = rbHemoglobinaMas20Menor11.Checked;

            oHistoriaClinicaPerinatal.FeIndicadoNo = rbHierroIndicadoNo.Checked;
            oHistoriaClinicaPerinatal.FeIndicadoSi = rbHierroIndicadoSi.Checked;
            oHistoriaClinicaPerinatal.FolatosIndicadosNo = rbFolatosIndicadosNo.Checked;
            oHistoriaClinicaPerinatal.FolatosIndicadosSi = rbFolatosIndicadosSi.Checked;
            //Chagas
            oHistoriaClinicaPerinatal.ChagasNegativo = rbChagasNegativo.Checked;
            oHistoriaClinicaPerinatal.ChagasPositivo = rbChagasPositivo.Checked;
            oHistoriaClinicaPerinatal.ChagasNoSeHizo = rbChagasNoSeHizo.Checked;
            //Hepatitis B
            oHistoriaClinicaPerinatal.HepatitisBNegativo = rbHepatitisBNegativo.Checked;
            oHistoriaClinicaPerinatal.HepatitisBPositivo = rbHepatitisBPositivo.Checked;
            oHistoriaClinicaPerinatal.HepatitisBNoSeHizo = rbHepatitisBNoSeHizo.Checked;
            //Bacteriura
            oHistoriaClinicaPerinatal.BacteriuraMenor20SemNormal = rbBacteriuriaMenos20Normal.Checked;
            oHistoriaClinicaPerinatal.BacteriuraMenor20SemAnormal = rbBacteriuriaMenos20Anormal.Checked;
            oHistoriaClinicaPerinatal.BacteriuraMenor20SemNoSeHizo = rbBacteriuriaMenos20NoSeHizo.Checked;
            oHistoriaClinicaPerinatal.BacteriuraMayor20SemNormal = rbBacteriuriaMas20Normal.Checked;
            oHistoriaClinicaPerinatal.BacteriuraMayor20SemAnormal = rbBacteriuriaMas20Anormal.Checked;
            oHistoriaClinicaPerinatal.BacteriuraMayor20SemNoSeHizo = rbBacteriuriaMas20NoSeHizo.Checked;
            //Validar Glucemia*****
            /* decimal glucemiamenos20, glucemiamas20;
             if (Convert.ToDecimal(txtGlucemiaMenos20Valor.Text) < 100)
             {
                 if (Decimal.TryParse(txtGlucemiaMenos20Valor.Text, out glucemiamenos20))
                     oHistoriaClinicaPerinatal.GlucemiaMenor20Sem = glucemiamenos20;
             }
             else
             {
                 Master.Message("El valor de GLucemia es mayor 100.", MessageStatus.alert);
                 oHistoriaClinicaPerinatal.GlucemiaMenor20SemMayor105 = rbGlucemiaMenos20Mayor105.Checked;
                 if (Decimal.TryParse(txtGlucemiaMas30Valor.Text, out glucemiamas20))
                     oHistoriaClinicaPerinatal.GlucemiaMayor20Sem = glucemiamas20;
                 oHistoriaClinicaPerinatal.GlucemiaMayor20SemMayor105 = rbGlucemiaMas30Mayor105.Checked;
             }*/
            decimal glucemiamenos20, glucemiamas20;
            if (Decimal.TryParse(txtGlucemiaMenos20Valor.Text.Replace(",", "."), System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out glucemiamenos20))
                oHistoriaClinicaPerinatal.GlucemiaMenor20Sem = glucemiamenos20;
            else oHistoriaClinicaPerinatal.GlucemiaMenor20Sem = 0;
            if (glucemiamenos20 >= 100) oHistoriaClinicaPerinatal.GlucemiaMenor20SemMayor105 = rbGlucemiaMenos20Mayor105.Checked;
            if (Decimal.TryParse(txtGlucemiaMas30Valor.Text.Replace(",", "."), System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out glucemiamas20))
                oHistoriaClinicaPerinatal.GlucemiaMayor20Sem = glucemiamas20;
            else oHistoriaClinicaPerinatal.GlucemiaMayor20Sem = 0;
            if (glucemiamas20 >= 100) oHistoriaClinicaPerinatal.GlucemiaMayor20SemMayor105 = rbGlucemiaMas30Mayor105.Checked;
            //Estreptococo B
            oHistoriaClinicaPerinatal.EstreptococoB3537SemanasNegativo = rbEstreptococoBNegativo.Checked;
            oHistoriaClinicaPerinatal.EstreptococoB3537SemanasPositivo = rbEstreptococoBPositivo.Checked;
            oHistoriaClinicaPerinatal.EstreptococoB3537SemanasNoSeHizo = rbEstreptococoBNoSeHizo.Checked;
            //Preparacion Parto
            oHistoriaClinicaPerinatal.PreparacionPartoNo = rbPreparacionPartoNo.Checked;
            oHistoriaClinicaPerinatal.PreparacionPartoSi = rbPreparacionPartoSi.Checked;
            //Consejeria Lactancia Materna
            oHistoriaClinicaPerinatal.ConsejeriaLactanciaMaternaNo = rbConsejeriaLactanciaNo.Checked;
            oHistoriaClinicaPerinatal.ConsejeriaLactanciaMaternaSi = rbConsejeriaLactanciaSi.Checked;
            //Sifilis
            //Prueba No Trepo
            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraNegativo = rbSifilisPruebaNTPrimerMuestraNegativo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraPositivo = rbSifilisPruebaNTPrimerMuestraPositivo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraSinDatos = rbSifilisPruebaNTPrimerMuestraSD.Checked;
            /*int pruebantmenos20,pruebatPrimerMuestra, sifilistratamientomenor20sem, sifilistratamientomayor20sem;*/
            DateTime pruebantPrimerMuestrafecha, pruebatPrimerMuestrafecha;
            /*if (Int32.TryParse(txtSifilisPruebaNTMenos20.Text, out pruebantmenos20))
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra = pruebantmenos20;*/
            if (DateTime.TryParse(txtSifilisPruebaNTPrimerMuestraFecha.Text, out pruebantPrimerMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestraFecha = pruebantPrimerMuestrafecha;

            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraNegativo = rbSifilisPruebaNTSegundaMuestraNegativo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraPositivo = rbSifilisPruebaNTSegundaMuestraPositivo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraSinDatos = rbSifilisPruebaNTSegundaMuestraSD.Checked;
            /*int pruebantmenos20,pruebatPrimerMuestra, sifilistratamientomenor20sem, sifilistratamientomayor20sem;*/
            DateTime pruebantSegundaMuestrafecha, pruebatSegundaMuestrafecha;
            /*if (Int32.TryParse(txtSifilisPruebaNTMenos20.Text, out pruebantmenos20))
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra = pruebantmenos20;*/
            if (DateTime.TryParse(txtSifilisPruebaNTSegundaMuestraFecha.Text, out pruebantSegundaMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoSegundaMuestraFecha = pruebantSegundaMuestrafecha;

            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraNegativo = rbSifilisPruebaNTTercerMuestraNegativo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraPositivo = rbSifilisPruebaNTTercerMuestraPositivo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraSinDatos = rbSifilisPruebaNTTercerMuestraSD.Checked;
            /*int pruebantmenos20,pruebatPrimerMuestra, sifilistratamientomenor20sem, sifilistratamientomayor20sem;*/
            DateTime pruebantTercerMuestrafecha, pruebatTercerMuestrafecha;
            /*if (Int32.TryParse(txtSifilisPruebaNTMenos20.Text, out pruebantmenos20))
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoPrimerMuestra = pruebantmenos20;*/
            if (DateTime.TryParse(txtSifilisPruebaNTTercerMuestraFecha.Text, out pruebantTercerMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisPruebaNoTrepoTercerMuestraFecha = pruebantTercerMuestrafecha;

            //Prueba Trepo
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraNegativo = rbSifilisPruebaTPrimerMuestraNegativo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraPositivo = rbSifilisPruebaTPrimerMuestraPositivo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraSinDatos = rbSifilisPruebaTPrimerMuestraSD.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraNoCorresponde = rbSifilisPruebaTPrimerMuestraNC.Checked;
            /*if (Int32.TryParse(txtSifilisPruebaTMenos20.Text, out pruebatmenos20))
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra = pruebatmenos20;*/
            if (DateTime.TryParse(txtSifilisPruebaTPrimerMuestraFecha.Text, out pruebatPrimerMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestraFecha = pruebatPrimerMuestrafecha;

            oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraNegativo = rbSifilisPruebaTSegundaMuestraNegativo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraPositivo = rbSifilisPruebaTSegundaMuestraPositivo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraSinDatos = rbSifilisPruebaTSegundaMuestraSD.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraNoCorresponde = rbSifilisPruebaTSegundaMuestraNC.Checked;
            /*if (Int32.TryParse(txtSifilisPruebaTMenos20.Text, out pruebatmenos20))
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra = pruebatmenos20;*/
            if (DateTime.TryParse(txtSifilisPruebaTSegundaMuestraFecha.Text, out pruebatSegundaMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoSegundaMuestraFecha = pruebatSegundaMuestrafecha;

            oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraNegativo = rbSifilisPruebaTTercerMuestraNegativo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraPositivo = rbSifilisPruebaTTercerMuestraPositivo.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraSinDatos = rbSifilisPruebaTTercerMuestraSD.Checked;
            oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraNoCorresponde = rbSifilisPruebaTTercerMuestraNC.Checked;
            /*if (Int32.TryParse(txtSifilisPruebaTMenos20.Text, out pruebatmenos20))
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoPrimerMuestra = pruebatmenos20;*/
            if (DateTime.TryParse(txtSifilisPruebaTTercerMuestraFecha.Text, out pruebatTercerMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisPruebaTrepoTercerMuestraFecha = pruebatTercerMuestrafecha;

            //Tratamiento
            DateTime tratamientoPrimerMuestrafecha, tratamientoSegundaMuestrafecha, tratamientoTercerMuestrafecha;
            oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraNo = rbSifilisTratamientoPrimerMuestraNo.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraSi = rbSifilisTratamientoPrimerMuestraSi.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraSinDatos = rbSifilisTratamientoPrimerMuestraSD.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraNoCorresponde = rbSifilisTratamientoPrimerMuestraNC.Checked;
            /*if (Int32.TryParse(txtSifilisTratamientoMenos20.Text, out sifilistratamientomenor20sem))
                oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestra = sifilistratamientomenor20sem;*/
            if (DateTime.TryParse(txtSifilisTratamientoPrimerMuestraFecha.Text, out tratamientoPrimerMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestraFecha = tratamientoPrimerMuestrafecha;

            oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraNo = rbSifilisTratamientoSegundaMuestraNo.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraSi = rbSifilisTratamientoSegundaMuestraSi.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraSinDatos = rbSifilisTratamientoSegundaMuestraSD.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraNoCorresponde = rbSifilisTratamientoSegundaMuestraNC.Checked;
            /*if (Int32.TryParse(txtSifilisTratamientoMenos20.Text, out sifilistratamientomenor20sem))
                oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestra = sifilistratamientomenor20sem;*/
            if (DateTime.TryParse(txtSifilisTratamientoSegundaMuestraFecha.Text, out tratamientoSegundaMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisTratamientoSegundaMuestraFecha = tratamientoSegundaMuestrafecha;

            oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraNo = rbSifilisTratamientoTercerMuestraNo.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraSi = rbSifilisTratamientoTercerMuestraSi.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraSinDatos = rbSifilisTratamientoTercerMuestraSD.Checked;
            oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraNoCorresponde = rbSifilisTratamientoTercerMuestraNC.Checked;
            /*if (Int32.TryParse(txtSifilisTratamientoMenos20.Text, out sifilistratamientomenor20sem))
                oHistoriaClinicaPerinatal.SifilisTratamientoPrimerMuestra = sifilistratamientomenor20sem;*/
            if (DateTime.TryParse(txtSifilisTratamientoTercerMuestraFecha.Text, out tratamientoTercerMuestrafecha))
                oHistoriaClinicaPerinatal.SifilisTratamientoTercerMuestraFecha = tratamientoTercerMuestrafecha;

            //Pareja
            oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemNo = rbSifilisParejaMenos20No.Checked;
            oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemSi = rbSifilisParejaMenos20Si.Checked;
            oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemSinDatos = rbSifilisParejaMenos20SD.Checked;
            oHistoriaClinicaPerinatal.SifilisTratParejaMenor20SemNoCorresponde = rbSifilisParejaMenos20NC.Checked;

            oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemNo = rbSifilisParejaMas20No.Checked;
            oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemSi = rbSifilisParejaMas20Si.Checked;
            oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemSinDatos = rbSifilisParejaMas20SD.Checked;
            oHistoriaClinicaPerinatal.SifilisTratParejaMayor20SemNoCorresponde = rbSifilisParejaMas20NC.Checked;

            //Datos Extras
            //AGO-Antecedentes
            oHistoriaClinicaPerinatal.OAAntecedenteEclampsiaNo = rbAgoAntecedenteEclampsiaNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteEclampsiaSi = rbAgoAntecedenteEclampsiaSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedentePreeclampsiaNo = rbAgoAntecedentePreeclampsiaNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedentePreeclampsiaSi = rbAgoAntecedentePreeclampsiaSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteCirugiaGinUrinarNo = rbAgoAntecedenteCirugiaGUNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteCirugiaGinUrinarSi = rbAgoAntecedenteCirugiaGUSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteAPPrematuroNo = rbAgoAntecedenteAPPrematuraNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteAPPrematuroSi = rbAgoAntecedenteAPPrematuraSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteRCIUNo = rbAgoAntecedenteRCIUNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteRCIUSi = rbAgoAntecedenteRCIUSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteHemorragiaObstetricaNo = rbAgoAntecedenteHemorragiaObstetricaNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteHemorragiaObstetricaSi = rbAgoAntecedenteHemorragiaObstetricaSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteMacrosomiaFetalNo = rbAgoAntecedenteMacrosomoiaFetalNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteMacrosomiaFetalSi = rbAgoAntecedenteMacrosomoiaFetalSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedentePolihidramniosNo = rbAgoAntecedentePolihidramniosNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedentePolihidramniosSi = rbAgoAntecedentePolihidramniosSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteOligoanmiosNo = rbAgoAntecedenteOligoanmiosNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteOligoanmiosSi = rbAgoAntecedenteOligoanmiosSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteRotPremMembranasNo = rbAgoAntecedenteRPMembranasNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteRotPremMembranasSi = rbAgoAntecedenteRPMembranasSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteIsoinmunizacionesNo = rbAgoAntecedenteIsoInmunizacionesNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteIsoinmunizacionesSi = rbAgoAntecedenteIsoInmunizacionesSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteColestasisNo = rbAgoAntecedenteColestasisNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteColestasisSi = rbAgoAntecedenteColestasisSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteMortPerinatalRecurrenteNo = rbAgoAntecedenteMortPerinRecurrenteNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteMortPerinatalRecurrenteSi = rbAgoAntecedenteMortPerinRecurrenteSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteRetencionPlacentaNo = rbAgoAntecedenteRetencionPlacentaNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteRetencionPlacentaSi = rbAgoAntecedenteRetencionPlacentaSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteDistociaHombrosNo = rbAgoAntecedenteDistociaHombrosNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteDistociaHombrosSi = rbAgoAntecedenteDistociaHombrosSi.Checked;

            oHistoriaClinicaPerinatal.OAAntecedenteMalformCongenNo = rbAgoAntecedenteMalformCongenNo.Checked;
            oHistoriaClinicaPerinatal.OAAntecedenteMalformCongenSi = rbAgoAntecedenteMalformCongenSi.Checked;

            //AGO-Actual
            oHistoriaClinicaPerinatal.OAActualEclampsiaNo = rbAgoActualEclampsiaNo.Checked;
            oHistoriaClinicaPerinatal.OAActualEclampsiaSi = rbAgoActualEclampsiaSi.Checked;

            oHistoriaClinicaPerinatal.OAActualPreeclampsiaNo = rbAgoActualPreeclampsiaNo.Checked;
            oHistoriaClinicaPerinatal.OAActualPreeclampsiaSi = rbAgoActualPreeclampsiaSi.Checked;

            oHistoriaClinicaPerinatal.OAActualCirugiaGinUrinarNo = rbAgoActualCirugiaGUNo.Checked;
            oHistoriaClinicaPerinatal.OAActualCirugiaGinUrinarSi = rbAgoActualCirugiaGUSi.Checked;

            oHistoriaClinicaPerinatal.OAActualAPPrematuroNo = rbAgoActualAPPrematuraNo.Checked;
            oHistoriaClinicaPerinatal.OAActualAPPrematuroSi = rbAgoActualAPPrematuraSi.Checked;

            oHistoriaClinicaPerinatal.OAActualRCIUNo = rbAgoActualRCIUNo.Checked;
            oHistoriaClinicaPerinatal.OAActualRCIUSi = rbAgoActualRCIUSi.Checked;

            oHistoriaClinicaPerinatal.OAActualHemorragiaObstetricaNo = rbAgoActualHemorragiaObstetricaNo.Checked;
            oHistoriaClinicaPerinatal.OAActualHemorragiaObstetricaSi = rbAgoActualHemorragiaObstetricaSi.Checked;

            oHistoriaClinicaPerinatal.OAActualMacrosomiaFetalNo = rbAgoActualMacrosomoiaFetalNo.Checked;
            oHistoriaClinicaPerinatal.OAActualMacrosomiaFetalSi = rbAgoActualMacrosomoiaFetalSi.Checked;

            oHistoriaClinicaPerinatal.OAActualPolihidramniosNo = rbAgoActualPolihidramniosNo.Checked;
            oHistoriaClinicaPerinatal.OAActualPolihidramniosSi = rbAgoActualPolihidramniosSi.Checked;

            oHistoriaClinicaPerinatal.OAActualOligoanmiosNo = rbAgoActualOligoanmiosNo.Checked;
            oHistoriaClinicaPerinatal.OAActualOligoanmiosSi = rbAgoActualOligoanmiosSi.Checked;

            oHistoriaClinicaPerinatal.OAActualRotPremMembranasNo = rbAgoActualRPMembranasNo.Checked;
            oHistoriaClinicaPerinatal.OAActualRotPremMembranasSi = rbAgoActualRPMembranasSi.Checked;

            oHistoriaClinicaPerinatal.OAActualIsoinmunizacionesNo = rbAgoActualIsoInmunizacionesNo.Checked;
            oHistoriaClinicaPerinatal.OAActualIsoinmunizacionesSi = rbAgoActualIsoInmunizacionesSi.Checked;

            oHistoriaClinicaPerinatal.OAActualColestasisNo = rbAgoActualColestasisNo.Checked;
            oHistoriaClinicaPerinatal.OAActualColestasisSi = rbAgoActualColestasisSi.Checked;
            //Factores de Riego
            oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoSinContSocialNo = rbFactorRiesgoEmbarazoSinContSocialNo.Checked;
            oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoSinContSocialSi = rbFactorRiesgoEmbarazoSinContSocialSi.Checked;

            oHistoriaClinicaPerinatal.FactorRiesgoFamiliaSinIngresosFijosNo = rbFactorRiesgoFamiliaSinIngresosFijosNo.Checked;
            oHistoriaClinicaPerinatal.FactorRiesgoFamiliaSinIngresosFijosSi = rbFactorRiesgoFamiliaSinIngresosFijosSi.Checked;

            oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoFuertRechazadoNo = rbFactorRiesgoEmbarazoFuertRechazadoNo.Checked;
            oHistoriaClinicaPerinatal.FactorRiesgoEmbarazoFuertRechazadoSi = rbFactorRiesgoEmbarazoFuertRechazadoSi.Checked;

            oHistoriaClinicaPerinatal.FactorRiesgoHijosDadosAdopcionNo = rbFactorRiesgoHijosDadosAdopcionNo.Checked;
            oHistoriaClinicaPerinatal.FactorRiesgoHijosDadosAdopcionSi = rbFactorRiesgoHijosDadosAdopcionSi.Checked;

            oHistoriaClinicaPerinatal.FactorRiesgoViviendaSinServiciosBasicosNo = rbFactorRiesgoViviendaSinServiciosBasicosNo.Checked;
            oHistoriaClinicaPerinatal.FactorRiesgoViviendaSinServiciosBasicosSi = rbFactorRiesgoViviendaSinServiciosBasicosSi.Checked;
            //Captacion Oportuna
            oHistoriaClinicaPerinatal.CaptacionOportunaAntes16sem = rbCaptacionOportunaAntes16Sem.Checked;
            oHistoriaClinicaPerinatal.CaptacionOportunaDespues16sem = rbCaptacionOportunaDespues16Sem.Checked;

            //Fecha PAP
            DateTime fechaPAP;
            if (DateTime.TryParse(txtFechaMuestraPAP.Text, out fechaPAP))
                oHistoriaClinicaPerinatal.FechaMuestraPAP = fechaPAP;

            List<string> mensaje = new List<string>();

            //Fecha Triple Acelular
            DateTime fechaAcelular;
            if (DateTime.TryParse(txtFechaTripleAcelular.Text, out fechaAcelular))
                oHistoriaClinicaPerinatal.FechaTripleAcelular = fechaAcelular;
            else mensaje.Add("Indicar Vacuna Triple Antigripal para > 20 semanas, por única vez.");

            //Fecha N1H1
            DateTime fechaAntigripal;
            if (DateTime.TryParse(txtFechaAntigripal.Text, out fechaAntigripal))
                oHistoriaClinicaPerinatal.FechaAntigripal = fechaAntigripal;
            else mensaje.Add("Se sugiere la indicación de la vacuna Antigripal.");

            //seccion de nuevos datos 22/09/2014
            //Efector de traslado intrauterino
            if (ddlEfectorTraslado.SelectedValue != "0")
            {
                hfIdEfectorTraslado.Value = ddlEfectorTraslado.SelectedValue;
                oHistoriaClinicaPerinatal.IdEfectorTrasladoUt = Convert.ToInt32(hfIdEfectorTraslado.Value);
            }
            //desarrolla enfermedades en el embarazo actual
            oHistoriaClinicaPerinatal.AnemiaNo = rbDesarrollaAnemiaNo.Checked;
            oHistoriaClinicaPerinatal.AnemiaSi = rbDesarrollaAnemiaSi.Checked;

            oHistoriaClinicaPerinatal.DiabetesActualNo = rbDesarrollaDiabetesNo.Checked;
            oHistoriaClinicaPerinatal.DiabetesActualSi = rbDesarrollaDiabetesSi.Checked;

            //oHistoriaClinicaPerinatal.Activa = ckbActivo.Checked;
            //oHistoriaClinicaPerinatal.Observaciones = txtObservaciones.Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool tallerPsicoprofilaxis = false;
            List<string> mensaje = new List<string>();

            //Verifico que la consulta tenga algo
            DateTime fechaProximaCita, fechaAcelular, fechaAntigripal, fechaDetalle;

            if (DateTime.TryParse(txtFechaTripleAcelular.Text, out fechaAcelular))
            {
                if (txtFechaTripleAcelular.Text == "") mensaje.Add("Indicar Vacuna Triple Antigripal para > 20 semanas, por única vez.");
            }

            if (DateTime.TryParse(txtFechaAntigripal.Text, out fechaAntigripal))
            {
                if (txtFechaAntigripal.Text == "") mensaje.Add("Se sugiere la indicación de la vacuna Antigripal.");
            }

            if (DateTime.TryParse(txtDetalleFecha.Text, out fechaDetalle))
            {
                if (txtDetalleFecha.Text == "") mensaje.Add("Falta fecha detalle.");
            }
                //Deberia Guardar todo....
                AprHistoriaClinicaPerinatal oHistoria;
                if (idHistoriaClinicaPerinatal > 0)
                {
                    oHistoria = new AprHistoriaClinicaPerinatal(idHistoriaClinicaPerinatal);
                }
                else
                {
                    oHistoria = new AprHistoriaClinicaPerinatal();
                    oHistoria.IdPaciente = idPaciente;
                    oHistoria.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                }

                AsignarValores(oHistoria);
                ConConsultum oConsulta = new ConConsultum();
                if (idConsulta == 0)
                {
                    /* Creo una consulta */
                    oConsulta = new ConConsultum();
                    oConsulta.IdPaciente = idPaciente;
                    oConsulta.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                    // Coloco la misma fecha del detalle de la historia clinica
                    //oConsulta.Fecha = fechaDetalle;
                    oConsulta.FechaRegistro = DateTime.Now;
                    oConsulta.Hora = DateTime.Now.ToShortTimeString();
                    oConsulta.InformeConsulta =
                        String.Format("{0}/n{1}", txtDetalleAlarmaExamenesTratamientos.Text,
                        txtDetalleObservaciones.Text);
                    //Diagnostico es control perinatal
                    ConConsultaDiagnostico oDiagnostico = new ConConsultaDiagnostico();
                    oDiagnostico.Principal = true;
                    oDiagnostico.CODCIE10 = 9620;// 12003 - Supervisión de embarazo normal no especificado
                    /*             if (oConsulta.ConConsultaDiagnosticoRecords == null)   ?????
                                     oConsulta.ConConsultaDiagnosticoRecords = new ConConsultaDiagnosticoCollection();
                                 oConsulta.ConConsultaDiagnosticoRecords.Add(oDiagnostico);    */
                }
                /* Guardo el detalle de la historia clinica perinatal */
                AprHistoriaClinicaPerinatalDetalle oDetalle;
                if (idConsulta == 0)
                {
                    oDetalle = new AprHistoriaClinicaPerinatalDetalle();
                }
                else
                {
                    oDetalle = new SubSonic.Select().From(Schemas.AprHistoriaClinicaPerinatalDetalle)
                        .Where(AprHistoriaClinicaPerinatalDetalle.Columns.IdConsulta).IsEqualTo(idConsulta)
                        .ExecuteSingle<AprHistoriaClinicaPerinatalDetalle>();
                }
                //Solo si se cargo algun dato
                if ((txtDetalleFecha.Text.Length > 0))
                {
                    Decimal edadgestacional, peso, imc, alturauterina;
                    int fcf;
                    //oDetalle.Fecha = fechaDetalle;
                    if (Decimal.TryParse(txtDetalleEdadGestacional.Text, out edadgestacional))
                    {
                        oDetalle.EdadGestacional = edadgestacional;
                        //si edad mayor a 4 meses
                        tallerPsicoprofilaxis = edadgestacional > 28;
                    }
                    CultureInfo ci = null;
                    ci = CultureInfo.InvariantCulture;
                    if (!string.IsNullOrEmpty(txtDetallePeso.Text))
                    {
                        peso = decimal.Parse(txtDetallePeso.Text.Replace(",", "."), ci);
                        oDetalle.Peso = peso;
                    }
                    else oDetalle.Peso = 0;
                    if (!string.IsNullOrEmpty(txtDetalleIMC.Text))
                    {
                        imc = decimal.Parse(txtDetalleIMC.Text.Replace(",", "."), ci);
                        oDetalle.Imc = imc;
                    }
                    else oDetalle.Imc = 0;
                    if (txtDetallePresionArterialSistolica.Text.Length > 0 && txtDetallePresionArterialDistolica.Text.Length > 0)
                    {
                        oDetalle.Pa = String.Format("{0}/{1}", txtDetallePresionArterialSistolica.Text, txtDetallePresionArterialDistolica.Text);
                    }
                    if (Decimal.TryParse(txtDetalleAlturaUterina.Text, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out alturauterina))
                        oDetalle.AlturaUterina = alturauterina;
                    else oDetalle.AlturaUterina = 0;

                    oDetalle.Presentacion = txtDetallePresentacion.Text;
                    if (Int32.TryParse(txtDetalleFrecuenciaCardiacaFetal.Text, out fcf))
                        oDetalle.Fcf = fcf;
                    else oDetalle.Fcf = 0;
                    oDetalle.MovimientosFetales = txtDetalleMovimientosFetales.Text;
                    oDetalle.Proteinuria = txtDetalleProteinuria.Text;
                    oDetalle.AlarmaExamenesTratamientos = txtDetalleAlarmaExamenesTratamientos.Text;
                    oDetalle.Observaciones = txtDetalleObservaciones.Text;
                    oDetalle.InicialesTecnico = txtDetallesInicialesTecnico.Text;
                    if (DateTime.TryParse(txtDetalleFecha.Text, out fechaDetalle))
                        oDetalle.Fecha = fechaDetalle;
                    if (DateTime.TryParse(txtDetalleProximaCita.Text, out fechaProximaCita))
                        oDetalle.ProximaCita = fechaProximaCita;
                    oDetalle.Activa = true;
                    oDetalle.IdEfector = SSOHelper.CurrentIdentity.IdEfector;

                    if (idConsulta == 0)
                        oHistoria.AprHistoriaClinicaPerinatalDetalleRecords.Add(oDetalle);
                }

                using (TransactionScope ts = new TransactionScope())
                {
                    using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                    {
                        try
                        {
                            if (idConsulta == 0)
                            {
                                oConsulta.Save(SSOHelper.CurrentIdentity.Username);
                                //  oConsulta.ConConsultaDiagnosticoRecords.SaveAll(Master.Usuario.Username);  ???
                                oDetalle.ConConsultum = oConsulta;
                            }
                            else
                            {
                                
                                oDetalle.Save(SSOHelper.CurrentIdentity.Username);
                            }

                            oHistoria.Activa = true;
                            oHistoria.Save(SSOHelper.CurrentIdentity.Username);
                            oHistoria.AprHistoriaClinicaPerinatalDetalleRecords.SaveAll(SSOHelper.CurrentIdentity.Username);
                            //oHistoria.AprPartoProvisorioRecords.SaveAll(SSOHelper.CurrentIdentity.Username);

                            ts.Complete();

                            //List<string> mensaje = new List<string>();

                            if (oHistoria.ExamenOdotologicoNormalNo.HasValue && oHistoria.ExamenOdotologicoNormalNo.Value &&
                                !controlOdontologicoAnormal)
                            {
                                //muestro mensaje de control odontologico
                                mensaje.Add(String.Format(@"El control odontologico no es normal, por favor complete la ficha <a href='{0}'>Control Odontologico</a>.",
                                ResolveUrl(String.Format("~/ConsultaAmbulatoria/ControlPerinatal/ControlOdontologico/?idPaciente={0}", idPaciente))));
                            }
                            if (!tallerPsicoprofilaxisRealizado && tallerPsicoprofilaxis)
                            {
                                mensaje.Add("Se sugiere la realizacion del Taller de Psicoprofilaxis (curso y preparacion para el parto).");
                            }

                            globales.activaAlertas = 3;
                            Response.Redirect("/SIPS/ConsultaAmbulatoria/ControlPerinatal/Control/?idHistoriaClinicaPerinatal=" + idHistoriaClinicaPerinatal);
       
                        }
                        catch (Exception ex)
                        {
                            ts.Dispose();
                            List<string> m = new List<string>();
                            while (ex != null)
                            {
                                m.Add(ex.Message);
                                ex = ex.InnerException;
                            }
                            Master.Message(MessageStatus.error, "Error al guardar", m);
                        }
                    }
                }
            }
            //else
            //{
            //    Master.Message("Es obligatorio ingresar la fecha de la consulta antenatal.", MessageStatus.alert);
            //}
       // }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaAmbulatoria/ControlPerinatal/Control/?idPaciente=" + idPaciente);
        }









        protected void ddlEfectorTraslado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEfectorTraslado.SelectedValue != "0")
            {
                int idEfectorTraslado = Convert.ToInt32(ddlEfectorTraslado.SelectedValue);
                hfIdEfectorTraslado.Value = idEfectorTraslado.ToString();

                SysEfector ef = new SysEfector(idEfectorTraslado);
                lblLugarTraslado.Text = ef.NombreNacion;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaAmbulatoria/inicio.aspx?idPaciente=" + idPaciente);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
             List<string> mensaje = new List<string>();

            int idHCPD = SubSonic.Sugar.Web.QueryString<int>("idHistoriaClinicaPerinatalDetalle");
            AprHistoriaClinicaPerinatalDetalle h = new AprHistoriaClinicaPerinatalDetalle(idHCPD);
            int idPaciente = h.AprHistoriaClinicaPerinatal.IdPaciente;
            //AprHistoriaClinicaPerinatalDetalle op = new AprHistoriaClinicaPerinatalDetalle(idHCPD);

            h.Activa = false;
            h.Save(SSOHelper.CurrentIdentity.Username);
            globales.activaAlertas = 1;
            Response.Redirect("/SIPS/ConsultaAmbulatoria/ControlPerinatal/Control/?idHistoriaClinicaPerinatal=" + idHistoriaClinicaPerinatal);
        }

        protected void btnGuardar2_Click(object sender, EventArgs e)
        {


            List<string> mensaje = new List<string>();

            int idHCPD = SubSonic.Sugar.Web.QueryString<int>("idHistoriaClinicaPerinatalDetalle");
            AprHistoriaClinicaPerinatalDetalle d = new AprHistoriaClinicaPerinatalDetalle();
            if (idHCPD > 0)
            {
                // edito el detalle
                d = new AprHistoriaClinicaPerinatalDetalle(idHCPD);
            }
            // traigo los datos y guardo
            DateTime fechaProximaCita;
            if ((txtDetalleFecha2.Text.Length > 0))
            {
                Decimal edadgestacional, peso, imc, alturauterina;
                int fcf;
                d.Fecha = Convert.ToDateTime(txtDetalleFecha2.Text);
                if (Decimal.TryParse(txtDetalleEdadGestacional2.Text, out edadgestacional))
                {
                    d.EdadGestacional = edadgestacional;
                }
                CultureInfo ci = null;
                ci = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(txtDetallePeso2.Text))
                {
                    peso = decimal.Parse(txtDetallePeso2.Text.Replace(",", "."), ci);
                    d.Peso = peso;
                }
                else txtDetallePeso.Text = "0";
                if (!string.IsNullOrEmpty(txtDetalleIMC2.Text))
                {
                    imc = decimal.Parse(txtDetalleIMC2.Text.Replace(",", "."), ci);
                    d.Imc = imc;
                }
                else txtDetalleIMC2.Text = "0";
                if (txtDetallePresionArterialSistolica.Text.Length > 0 && txtDetallePresionArterialDistolica.Text.Length > 0)
                {
                    d.Pa = String.Format("{0}/{1}", txtDetallePresionArterialSistolica.Text, txtDetallePresionArterialDistolica.Text);
                }
                if (txtDetalleAlturaUterina2.Text.Length > 0)
                    d.AlturaUterina = decimal.Parse(txtDetalleAlturaUterina2.Text);
                else d.AlturaUterina = 0;

                d.Presentacion = txtDetallePresentacion2.Text;
                if (Int32.TryParse(txtDetalleFrecuenciaCardiacaFetal2.Text, out fcf))
                    d.Fcf = fcf;
                d.MovimientosFetales = txtDetalleMovimientosFetales2.Text;
                d.Proteinuria = txtDetalleProteinuria2.Text;
                d.AlarmaExamenesTratamientos = txtDetalleAlarmaExamenesTratamientos2.Text;
                d.Observaciones = txtDetalleObservaciones2.Text;
                d.InicialesTecnico = txtDetallesInicialesTecnico2.Text;
                if (DateTime.TryParse(txtDetalleProximaCita2.Text, out fechaProximaCita))
                    d.ProximaCita = fechaProximaCita;
                d.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                d.Save(SSOHelper.CurrentIdentity.Username);
                //Master.Message(MessageStatus.ok, "Los cambios se guardaron con exito.", mensaje);
                globales.activaAlertas = 2;
                Response.Redirect("/SIPS/ConsultaAmbulatoria/ControlPerinatal/Control/?idHistoriaClinicaPerinatal=" + idHistoriaClinicaPerinatal);
       
            }
        }




        //    List<string> mensaje = new List<string>();

        //    int idHCPD = SubSonic.Sugar.Web.QueryString<int>("idHistoriaClinicaPerinatalDetalle");
        //    AprHistoriaClinicaPerinatalDetalle d = new AprHistoriaClinicaPerinatalDetalle();
        //    if (idHCPD > 0)
        //    {
        //        // edito el detalle
        //        d = new AprHistoriaClinicaPerinatalDetalle(idHCPD);
        //    }
        //    // traigo los datos y guardo
        //    DateTime fechaProximaCita;
        //    if ((txtDetalleFecha2.Text.Length > 0))
        //    {
        //        Decimal edadgestacional, peso, imc, alturauterina;
        //        int fcf;
        //        d.Fecha = Convert.ToDateTime(txtDetalleFecha2.Text);
        //        if (Decimal.TryParse(txtDetalleEdadGestacional2.Text, out edadgestacional))
        //        {
        //            d.EdadGestacional = edadgestacional;
        //        }
        //        CultureInfo ci = null;
        //        ci = CultureInfo.InvariantCulture;
        //        if (!string.IsNullOrEmpty(txtDetallePeso2.Text))
        //        {
        //            peso = decimal.Parse(txtDetallePeso2.Text.Replace(",", "."), ci);
        //            d.Peso = peso;
        //        }
        //        else txtDetallePeso.Text = "0";
        //        if (!string.IsNullOrEmpty(txtDetalleIMC2.Text))
        //        {
        //            imc = decimal.Parse(txtDetalleIMC2.Text.Replace(",", "."), ci);
        //            d.Imc = imc;
        //        }
        //        else txtDetalleIMC2.Text = "0";
        //        if (txtDetallePresionArterialSistolica2.Text.Length > 0 && txtDetallePresionArterialDistolica2.Text.Length > 0)
        //        {
        //            d.Pa = String.Format("{0}/{1}", txtDetallePresionArterialSistolica2.Text, txtDetallePresionArterialDistolica2.Text);
        //        }
        //        if (Decimal.TryParse(txtDetalleAlturaUterina2.Text, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out alturauterina))
        //            d.AlturaUterina = alturauterina;
        //        else d.AlturaUterina = 0;

        //        d.Presentacion = txtDetallePresentacion2.Text;
        //        if (Int32.TryParse(txtDetalleFrecuenciaCardiacaFetal2.Text, out fcf))
        //            d.Fcf = fcf;
        //        d.MovimientosFetales = txtDetalleMovimientosFetales2.Text;
        //        d.Proteinuria = txtDetalleProteinuria2.Text;
        //        d.AlarmaExamenesTratamientos = txtDetalleAlarmaExamenesTratamientos2.Text;
        //        d.Observaciones = txtDetalleObservaciones2.Text;
        //        d.InicialesTecnico = txtDetallesInicialesTecnico2.Text;
        //        if (DateTime.TryParse(txtDetalleProximaCita2.Text, out fechaProximaCita))
        //            d.ProximaCita = fechaProximaCita;
        //        d.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
        //        d.Save(SSOHelper.CurrentIdentity.Username);
        //        //Master.Message(MessageStatus.ok, "Los cambios se guardaron con exito.", mensaje);
        //        globales.activaAlertas = 2;
        //        Response.Redirect("/SIPS/ConsultaAmbulatoria/ControlPerinatal/Control/?idHistoriaClinicaPerinatal=" + idHistoriaClinicaPerinatal);
       
        //    }
        //}
       

    

        /*  protected void btnParto_Click(object sender, EventArgs e)
          {
              ResolveUrl(String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Parto/?idPaciente=" + idPaciente + "&idHistoriaClinicaPerinatal=" + Request.QueryString["idHistoriaClinicaPerinatal"]));
              //Response.Redirect(String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Parto/?idPaciente=" + idPaciente + "&idHistoriaClinicaPerinatal=" + Request.QueryString["idHistoriaClinicaPerinatal"]));
          }  */
    }
}
