using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace DalSic
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string AprAborto = @"APR_Aborto";
        
		public static string AprAcompañante = @"APR_Acompañante";
        
		public static string AprActividad = @"APR_Actividad";
        
		public static string AprActividadControlPerinatal = @"APR_ActividadControlPerinatal";
        
		public static string AprActividadEmbarazo = @"APR_ActividadEmbarazo";
        
		public static string AprActividadFisica = @"APR_ActividadFisica";
        
		public static string AprActualPatologiaEmbarazo = @"APR_ActualPatologiaEmbarazo";
        
		public static string AprAlertaControlMenor = @"APR_AlertaControlMenor";
        
		public static string AprAlimentacionRecienNacido = @"APR_AlimentacionRecienNacido";
        
		public static string AprAlturaUterina = @"APR_AlturaUterina";
        
		public static string AprAmbienteProcedimiento = @"APR_AmbienteProcedimiento";
        
		public static string AprAntecedentePatologiaEmbarazo = @"APR_AntecedentePatologiaEmbarazo";
        
		public static string AprAntecedentePerinatal = @"APR_AntecedentePerinatal";
        
		public static string AprAntecedentePerinatalNacimiento = @"APR_AntecedentePerinatalNacimiento";
        
		public static string AprAplicacionVacuna = @"APR_AplicacionVacuna";
        
		public static string AprAreaDesarrollo = @"APR_AreaDesarrollo";
        
		public static string AprCalendarioVacuna = @"APR_CalendarioVacuna";
        
		public static string AprCalendarioVisita = @"APR_CalendarioVisitas";
        
		public static string AprCategoriaPesoNacimiento = @"APR_CategoriaPesoNacimiento";
        
		public static string AprCentilesIMCEdadGestacional = @"APR_CentilesIMCEdadGestacional";
        
		public static string AprCMOtrosDato = @"APR_CMOtrosDatos";
        
		public static string AprComplicacionAborto = @"APR_ComplicacionAborto";
        
		public static string AprComplicacionIntraoperatorium = @"APR_ComplicacionIntraoperatoria";
        
		public static string AprConcejerium = @"APR_Concejeria";
        
		public static string AprCondicionesVivienda = @"APR_CondicionesVivienda";
        
		public static string AprCondicionIngreso = @"APR_CondicionIngreso";
        
		public static string AprConsultaAntenatal = @"APR_ConsultaAntenatal";
        
		public static string AprControlNiñoSano = @"APR_ControlNiñoSano";
        
		public static string AprControlNiñoSanoConsultorio = @"APR_ControlNiñoSanoConsultorio";
        
		public static string AprControlNiñoSanoEnfermerium = @"APR_ControlNiñoSanoEnfermeria";
        
		public static string AprControlNiñoSanoHemoglobina = @"APR_ControlNiñoSanoHemoglobina";
        
		public static string AprControlNiñoSanoOdontologico = @"APR_ControlNiñoSanoOdontologico";
        
		public static string AprControlOdontologico = @"APR_ControlOdontologico";
        
		public static string AprDefectoCongenito = @"APR_DefectoCongenito";
        
		public static string AprDiagnosticoControlOdontologico = @"APR_DiagnosticoControlOdontologico";
        
		public static string AprEgresoMaterno = @"APR_EgresoMaterno";
        
		public static string AprEgresoPorAborto = @"APR_EgresoPorAborto";
        
		public static string AprEmbarazo = @"APR_Embarazo";
        
		public static string AprEstadoNacimiento = @"APR_EstadoNacimiento";
        
		public static string AprEstadoNutricional = @"APR_EstadoNutricional";
        
		public static string AprEstiloVida = @"APR_EstiloVida";
        
		public static string AprEtnium = @"APR_Etnia";
        
		public static string AprFactorProtector = @"APR_FactorProtector";
        
		public static string AprFactorRiesgo = @"APR_FactorRiesgo";
        
		public static string AprFactorRiesgoEstiloVida = @"APR_FactorRiesgoEstiloVida";
        
		public static string AprFactorRiesgoPsicosocial = @"APR_FactorRiesgoPsicosocial";
        
		public static string AprFormaConcejerium = @"APR_FormaConcejeria";
        
		public static string AprHistoriaClinicaPerinatal = @"APR_HistoriaClinicaPerinatal";
        
		public static string AprHistoriaClinicaPerinatalDetalle = @"APR_HistoriaClinicaPerinatalDetalle";
        
		public static string AprInicioEmbarazo = @"APR_InicioEmbarazo";
        
		public static string AprInterconsultum = @"APR_Interconsulta";
        
		public static string AprIntervencion = @"APR_Intervencion";
        
		public static string AprIntervencionProfesional = @"APR_IntervencionProfesional";
        
		public static string AprMomentoNacimiento = @"APR_MomentoNacimiento";
        
		public static string AprMotivoVisitaDomiciliarium = @"APR_MotivoVisitaDomiciliaria";
        
		public static string AprNumeroDosi = @"APR_NumeroDosis";
        
		public static string AprPartoProvisorio = @"APR_PartoProvisorio";
        
		public static string AprPercentilesIMCEdad = @"APR_PercentilesIMCEdad";
        
		public static string AprPercentilesLongitudEstaturaEdad = @"APR_PercentilesLongitudEstaturaEdad";
        
		public static string AprPercentilesPerimetroCefalicoEdad = @"APR_PercentilesPerimetroCefalicoEdad";
        
		public static string AprPercentilesPesoEdad = @"APR_PercentilesPesoEdad";
        
		public static string AprPercentilesPesoEstatura = @"APR_PercentilesPesoEstatura";
        
		public static string AprPercentilesPesoLongitud = @"APR_PercentilesPesoLongitud";
        
		public static string AprProblemasMenor = @"APR_ProblemasMenor";
        
		public static string AprRecienNacido = @"APR_RecienNacido";
        
		public static string AprRelControlNiñoSanoAreaDesarrollo = @"APR_RelControlNiñoSanoAreaDesarrollo";
        
		public static string AprRelControlNiñoSanoFactorRiesgo = @"APR_RelControlNiñoSanoFactorRiesgo";
        
		public static string AprRelControNiñoSanoFactorProtector = @"APR_RelControNiñoSanoFactorProtector";
        
		public static string AprRelPersonaFactorRiesgoInicial = @"APR_RelPersonaFactorRiesgoInicial";
        
		public static string AprRelRecienNacidoDefectoCongenito = @"APR_RelRecienNacidoDefectoCongenito";
        
		public static string AprRelRecienNacidoEnfermedad = @"APR_RelRecienNacidoEnfermedad";
        
		public static string AprTallaEdad = @"APR_TallaEdad";
        
		public static string AprTerminacionParto = @"APR_TerminacionParto";
        
		public static string AprTipoActividadEmbarazo = @"APR_TipoActividadEmbarazo";
        
		public static string AprTipoLactancium = @"APR_TipoLactancia";
        
		public static string AprTipoParto = @"APR_TipoParto";
        
		public static string AprTipoProfesional = @"APR_TipoProfesional";
        
		public static string AprVisitaDomiciliarium = @"APR_VisitaDomiciliaria";
        
		public static string AprZScoreIMCEdad = @"APR_ZScoreIMCEdad";
        
		public static string AprZScoreLongitudEstaturaEdad = @"APR_ZScoreLongitudEstaturaEdad";
        
		public static string AprZScorePerimetroCefalicoEdad = @"APR_ZScorePerimetroCefalicoEdad";
        
		public static string AprZScorePesoEdad = @"APR_ZScorePesoEdad";
        
		public static string AprZScorePesoEstatura = @"APR_ZScorePesoEstatura";
        
		public static string AprZScorePesoLongitud = @"APR_ZScorePesoLongitud";
        
		public static string AutHistoricoVehiculoPmp = @"AUT_Historico_Vehiculo_PMP";
        
		public static string AutTipoPNP = @"Aut_TipoPNP";
        
		public static string BdsTipoDonante = @"BDS_TipoDonante";
        
		public static string BkpOdoNomenclador = @"bkp_ODO_Nomenclador";
        
		public static string ConAgenda = @"CON_Agenda";
        
		public static string ConAgendaAuditorium = @"CON_AgendaAuditoria";
        
		public static string ConAgendaBloqueo = @"CON_AgendaBloqueo";
        
		public static string ConAgendaEstado = @"CON_AgendaEstado";
        
		public static string ConAgendaGrupal = @"CON_AgendaGrupal";
        
		public static string ConAgendaGrupalOrganismo = @"CON_AgendaGrupalOrganismo";
        
		public static string ConAgendaGrupalPaciente = @"CON_AgendaGrupalPaciente";
        
		public static string ConAgendaGrupalProfesional = @"CON_AgendaGrupalProfesional";
        
		public static string ConAgendaProfesional = @"CON_AgendaProfesional";
        
		public static string ConConsultum = @"CON_Consulta";
        
		public static string ConConsultaDiagnostico = @"CON_ConsultaDiagnostico";
        
		public static string ConConsultaMedicamento = @"CON_ConsultaMedicamento";
        
		public static string ConConsultaOdontologium = @"CON_ConsultaOdontologia";
        
		public static string ConConsultorio = @"CON_Consultorio";
        
		public static string ConConsultorioTipo = @"CON_ConsultorioTipo";
        
		public static string ConDemanda = @"CON_Demanda";
        
		public static string ConDemandaRechazada = @"CON_DemandaRechazada";
        
		public static string ConEquipo = @"CON_Equipo";
        
		public static string ConLugarActividadGrupal = @"CON_LugarActividadGrupal";
        
		public static string ConMotivoBaja = @"CON_MotivoBaja";
        
		public static string ConMotivoInactivacionAgenda = @"CON_MotivoInactivacionAgenda";
        
		public static string ConMotivosDeBloqueo = @"CON_MotivosDeBloqueo";
        
		public static string ConMotivosRechazo = @"CON_MotivosRechazo";
        
		public static string ConNivelDeAbordaje = @"CON_NivelDeAbordaje";
        
		public static string ConTematica = @"CON_Tematica";
        
		public static string ConTiempoInsumido = @"CON_TiempoInsumido";
        
		public static string ConTipoActividadGrupal = @"CON_TipoActividadGrupal";
        
		public static string ConTipoDePrestacionSaludMental = @"CON_TipoDePrestacionSaludMental";
        
		public static string ConTipoPrestacion = @"CON_TipoPrestacion";
        
		public static string ConTurno = @"CON_Turno";
        
		public static string ConTurnoAsistencium = @"CON_TurnoAsistencia";
        
		public static string ConTurnoAuditorium = @"CON_TurnoAuditoria";
        
		public static string ConTurnoBloqueo = @"CON_TurnoBloqueo";
        
		public static string ConTurnoEstado = @"CON_TurnoEstado";
        
		public static string ConTurnoRecitum = @"CON_TurnoRecita";
        
		public static string ConTurnoReserva = @"CON_TurnoReserva";
        
		public static string ConTurnoReservaInterconsultum = @"CON_TurnoReservaInterconsulta";
        
		public static string EmrRelTraumaPrehospitalarium = @"EMR_RelTraumaPrehospitalaria";
        
		public static string FacContratoObraSocial = @"FAC_ContratoObraSocial";
        
		public static string FacJefeLaboratorio = @"FAC_JefeLaboratorio";
        
		public static string FacOrdenLaboratorio = @"FAC_OrdenLaboratorio";
        
		public static string FacRelPerfilPaginaPrincipal = @"FAC_RelPerfilPaginaPrincipal";
        
		public static string GuardiaAntecedente = @"Guardia_Antecedentes";
        
		public static string GuardiaC2 = @"Guardia_C2";
        
		public static string GuardiaMedicosFuncione = @"Guardia_Medicos_Funciones";
        
		public static string GuardiaMedicosRegistroIngreso = @"Guardia_Medicos_registroIngreso";
        
		public static string GuardiaMedicosTiposFuncione = @"Guardia_Medicos_TiposFunciones";
        
		public static string GuardiaMensaje = @"Guardia_Mensajes";
        
		public static string GuardiaPracticasClase = @"Guardia_Practicas_Clases";
        
		public static string GuardiaPracticasEstado = @"Guardia_Practicas_Estados";
        
		public static string GuardiaPracticasPrioridade = @"Guardia_Practicas_Prioridades";
        
		public static string GuardiaPrescripcione = @"Guardia_Prescripciones";
        
		public static string GuardiaRegistro = @"Guardia_Registros";
        
		public static string GuardiaRegistrosClasificacione = @"Guardia_Registros_Clasificaciones";
        
		public static string GuardiaRegistrosDiagnostico = @"Guardia_Registros_Diagnosticos";
        
		public static string GuardiaRegistrosDiagnosticosCie10 = @"Guardia_Registros_Diagnosticos_Cie10";
        
		public static string GuardiaRegistrosEstado = @"Guardia_Registros_Estados";
        
		public static string GuardiaRegistrosHistorial = @"Guardia_Registros_Historial";
        
		public static string GuardiaRegistrosMedicosResponsable = @"Guardia_Registros_MedicosResponsables";
        
		public static string GuardiaRegistrosPractica = @"Guardia_Registros_Practicas";
        
		public static string GuardiaRegistrosPracticasLaboratorio = @"Guardia_Registros_Practicas_Laboratorio";
        
		public static string GuardiaTipoPractica = @"Guardia_TipoPracticas";
        
		public static string GuardiaTiposEgreso = @"Guardia_TiposEgresos";
        
		public static string GuardiaTiposIngreso = @"Guardia_TiposIngreso";
        
		public static string GuardiaTriage = @"Guardia_Triage";
        
		public static string GuardiaTurnero = @"Guardia_Turnero";
        
		public static string HidHidatidosi = @"Hid_Hidatidosis";
        
		public static string HidHidatidosisParcial = @"Hid_HidatidosisParcial";
        
		public static string IcoDestinatarioInterconsultum = @"ICO_DestinatarioInterconsulta";
        
		public static string IcoDialogoInterconsultum = @"ICO_DialogoInterconsulta";
        
		public static string IcoInterconsultum = @"ICO_Interconsulta";
        
		public static string IcoTiposUsuario = @"ICO_TiposUsuario";
        
		public static string IcoUbicacionArchivo = @"ICO_UbicacionArchivos";
        
		public static string InsDatoFarmaceutico = @"INS_DatoFarmaceutico";
        
		public static string JmCertificadoMedico = @"JM_CertificadoMedico";
        
		public static string LabAcceso = @"LAB_Acceso";
        
		public static string LabAccesoResultado = @"LAB_AccesoResultado";
        
		public static string LabAlarmaScreening = @"LAB_AlarmaScreening";
        
		public static string LabDetalleSolicitudScreening = @"LAB_DetalleSolicitudScreening";
        
		public static string LabItemRepeticionScreening = @"LAB_ItemRepeticionScreening";
        
		public static string LabItemScreening = @"LAB_ItemScreening";
        
		public static string LabItemScreeningResultado = @"LAB_ItemScreeningResultado";
        
		public static string LabMetodoScreening = @"LAB_MetodoScreening";
        
		public static string LabMotivoRechazoScreening = @"LAB_MotivoRechazoScreening";
        
		public static string LabMotivoRepeticionScreening = @"LAB_MotivoRepeticionScreening";
        
		public static string LabProtocoloScreening = @"LAB_ProtocoloScreening";
        
		public static string LabProtocoloScreeningDetalle = @"LAB_ProtocoloScreeningDetalle";
        
		public static string LabReactivo = @"LAB_Reactivo";
        
		public static string LabResultadoDetalle = @"LAB_ResultadoDetalle";
        
		public static string LabResultadoEncabezado = @"LAB_ResultadoEncabezado";
        
		public static string LabResultadoScreening = @"LAB_ResultadoScreening";
        
		public static string LabSolicitudScreening = @"LAB_SolicitudScreening";
        
		public static string LabSolicitudScreeningEstado = @"Lab_SolicitudScreeningEstados";
        
		public static string LabSolicitudScreeningRepeticion = @"LAB_SolicitudScreeningRepeticion";
        
		public static string LabTempResultadoDetalle = @"LAB_Temp_ResultadoDetalle";
        
		public static string LabTempResultadoEncabezado = @"LAB_Temp_ResultadoEncabezado";
        
		public static string LabTempSolicitudScreening20131209 = @"Lab_temp_SolicitudScreening20131209";
        
		public static string LabTempResultadoTarjetasScreening = @"Lab_TempResultadoTarjetasScreening";
        
		public static string MamAnatomiaPatologica = @"MAM_AnatomiaPatologica";
        
		public static string MamAntecedente = @"MAM_Antecedentes";
        
		public static string MamBirad = @"MAM_Birads";
        
		public static string MamCirugium = @"MAM_Cirugia";
        
		public static string MamDiagnosticoCitologico = @"MAM_DiagnosticoCitologico";
        
		public static string MamDiagnoticoHistologico = @"MAM_DiagnoticoHistologico";
        
		public static string MamEcografium = @"MAM_Ecografia";
        
		public static string MamEstadio = @"MAM_Estadio";
        
		public static string MamEstadioClinico = @"MAM_EstadioClinico";
        
		public static string MamEstudiosAdicionale = @"MAM_EstudiosAdicionales";
        
		public static string MamEstudiosHospitalProvincial = @"MAM_EstudiosHospitalProvincial";
        
		public static string MamExamenFisico = @"MAM_ExamenFisico";
        
		public static string MamIndicadorM = @"MAM_IndicadorM";
        
		public static string MamIndicadorN = @"MAM_IndicadorN";
        
		public static string MamIndicadorT = @"MAM_IndicadorT";
        
		public static string MamMaterial = @"MAM_Material";
        
		public static string MamMotivo = @"MAM_Motivo";
        
		public static string MamMotivoConsultum = @"MAM_MotivoConsulta";
        
		public static string MamPiezaQuirurgica = @"MAM_PiezaQuirurgica";
        
		public static string MamRegistro = @"MAM_Registro";
        
		public static string MamResultadoExFisico = @"MAM_ResultadoExFisico";
        
		public static string MamTipoCirugium = @"MAM_TipoCirugia";
        
		public static string MamTipoEquipo = @"MAM_TipoEquipo";
        
		public static string MamTipoEstudio = @"MAM_TipoEstudio";
        
		public static string MamTipoMotivoConsultum = @"MAM_TipoMotivoConsulta";
        
		public static string MamTratamiento = @"MAM_Tratamientos";
        
		public static string OdoNomenclador = @"ODO_Nomenclador";
        
		public static string OdoPrograma = @"ODO_Programa";
        
		public static string PnAccidentesLab = @"PN_accidentes_lab";
        
		public static string PnAfjp = @"PN_afjp";
        
		public static string PnAgenteInscriptor = @"PN_agente_inscriptor";
        
		public static string PnAltum = @"PN_alta";
        
		public static string PnAnexo = @"PN_anexo";
        
		public static string PnArbol = @"PN_arbol";
        
		public static string PnArchivoManual = @"PN_archivo_manual";
        
		public static string PnArchivosCaso = @"PN_archivos_casos";
        
		public static string PnArchivosEnviado = @"PN_archivos_enviados";
        
		public static string PnArchivosRecibido = @"PN_archivos_recibidos";
        
		public static string PnArea = @"PN_areas";
        
		public static string PnAsistencium = @"PN_asistencia";
        
		public static string PnAusentismo = @"PN_ausentismo";
        
		public static string PnBarrio = @"PN_barrios";
        
		public static string PnBeneficiario = @"PN_beneficiarios";
        
		public static string PnBorrar = @"PN_Borrar";
        
		public static string PnCalculaPrecio = @"PN_calcula_precio";
        
		public static string PnCalificacion = @"PN_calificacion";
        
		public static string PnCapacitacione = @"PN_capacitaciones";
        
		public static string PnCapacitado = @"PN_capacitados";
        
		public static string PnCapsHacenParto = @"PN_caps_hacen_partos";
        
		public static string PnCategoria = @"PN_categorias";
        
		public static string PnClasificacionManual = @"PN_clasificacion_manual";
        
		public static string PnComprobante = @"PN_comprobante";
        
		public static string PnCredito = @"PN_credito";
        
		public static string PnCurriculumIdioma = @"PN_curriculum_idiomas";
        
		public static string PnCurriculumReferencium = @"PN_curriculum_referencia";
        
		public static string PnDatMinObl = @"PN_dat_min_obl";
        
		public static string PnDatosReportable = @"PN_datos_reportables";
        
		public static string PnDebito = @"PN_debito";
        
		public static string PnDepartamento = @"PN_departamentos";
        
		public static string PnDescIndicadorIn = @"PN_desc_indicador_ins";
        
		public static string PnDiasSemana = @"PN_dias_semana";
        
		public static string PnDirectoriosArchivo = @"PN_directorios_archivos";
        
		public static string PnDistrito = @"PN_distrito";
        
		public static string PnDosisApli = @"PN_dosis_apli";
        
		public static string PnDpto = @"PN_dpto";
        
		public static string PnEfeConv = @"PN_efe_conv";
        
		public static string PnEfecNom = @"PN_efec_nom";
        
		public static string PnEgreso = @"PN_egreso";
        
		public static string PnEmbarazada = @"PN_embarazadas";
        
		public static string PnEnfermedade = @"PN_enfermedades";
        
		public static string PnEntrega = @"PN_entrega";
        
		public static string PnEvaluadore = @"PN_evaluadores";
        
		public static string PnEvento = @"PN_evento";
        
		public static string PnExpediente = @"PN_expediente";
        
		public static string PnFactura = @"PN_factura";
        
		public static string PnFamilium = @"PN_familia";
        
		public static string PnFeriado = @"PN_feriados";
        
		public static string PnGrupoPrestacion = @"PN_grupo_prestacion";
        
		public static string PnGrupo = @"PN_grupos";
        
		public static string PnGruposUsuario = @"PN_grupos_usuarios";
        
		public static string PnHistoricotemp = @"PN_historicotemp";
        
		public static string PnHorariosTrabajo = @"PN_horarios_trabajo";
        
		public static string PnInasistencium = @"PN_inasistencia";
        
		public static string PnInciso = @"PN_inciso";
        
		public static string PnIncisoItemGasto = @"PN_inciso_item_gasto";
        
		public static string PnIndicadoresGlobale = @"PN_indicadores_globales";
        
		public static string PnIndicadoresIn = @"PN_indicadores_ins";
        
		public static string PnIngreso = @"PN_ingreso";
        
		public static string PnItemGasto = @"PN_item_gasto";
        
		public static string PnLegajo = @"PN_legajos";
        
		public static string PnLegajosExt = @"PN_legajos_ext";
        
		public static string PnLengua = @"PN_lenguas";
        
		public static string PnLocalidade = @"PN_localidades";
        
		public static string PnLogComprobante = @"PN_log_comprobante";
        
		public static string PnLogEvento = @"PN_log_evento";
        
		public static string PnLogFactura = @"PN_log_factura";
        
		public static string PnLogManual = @"PN_log_manual";
        
		public static string PnLogPacPap = @"PN_log_pac_pap";
        
		public static string PnLogPlanilla = @"PN_log_planilla";
        
		public static string PnLogPrestacion = @"PN_log_prestacion";
        
		public static string PnMailEfeConv = @"PN_mail_efe_conv";
        
		public static string PnManual = @"PN_manual";
        
		public static string PnMensaje = @"PN_mensajes";
        
		public static string PnMotivoD = @"PN_motivo_d";
        
		public static string PnMu = @"PN_mu";
        
		public static string PnMunicipio = @"PN_municipios";
        
		public static string PnNino = @"PN_nino";
        
		public static string PnNinoNew = @"PN_nino_new";
        
		public static string PnNoConformidad = @"PN_no_conformidad";
        
		public static string PnNomenclador = @"PN_nomenclador";
        
		public static string PnNomencladorDetalle = @"PN_nomenclador_detalle";
        
		public static string PnNomencladorXPatologium = @"PN_NomencladorXPatologia";
        
		public static string PnObrasSociale = @"PN_obras_sociales";
        
		public static string PnOri = @"PN_ori";
        
		public static string PnPacPap = @"PN_pac_pap";
        
		public static string PnPai = @"PN_pais";
        
		public static string PnParametro = @"PN_parametros";
        
		public static string PnParto = @"PN_partos";
        
		public static string PnPatologia = @"PN_patologias";
        
		public static string PnPatologiasFrecuente = @"PN_patologias_frecuentes";
        
		public static string PnPeriodo = @"PN_periodo";
        
		public static string PnPermiso = @"PN_permisos";
        
		public static string PnPermisosActuale = @"PN_permisos_actuales";
        
		public static string PnPermisosGrupo = @"PN_permisos_grupos";
        
		public static string PnPermisosSesion = @"PN_permisos_sesion";
        
		public static string PnPermisosUsuario = @"PN_permisos_usuarios";
        
		public static string PnPlanilla = @"PN_planillas";
        
		public static string PnPrestacion = @"PN_prestacion";
        
		public static string PnPrestacionesNOp = @"PN_prestaciones_n_op";
        
		public static string PnPrestacionesNueva = @"PN_PrestacionesNuevas";
        
		public static string PnPromocione = @"PN_promociones";
        
		public static string PnProvincia = @"PN_provincias";
        
		public static string PnPuco = @"PN_puco";
        
		public static string PnRecibe = @"PN_recibe";
        
		public static string PnRelNomencladorXDatoReportable = @"PN_Rel_NomencladorXDatoReportable";
        
		public static string PnRelPrestacionXDatoReportable = @"PN_Rel_PrestacionXDatoReportable";
        
		public static string PnRelPacienteAfiliado = @"PN_RelPacienteAfiliado";
        
		public static string PnReporteHipoacustium = @"PN_reporte_hipoacustia";
        
		public static string PnResponsable = @"PN_responsables";
        
		public static string PnServicio = @"PN_servicio";
        
		public static string PnSmiafiliado = @"PN_smiafiliados";
        
		public static string PnSmiafiliadosaux = @"PN_smiafiliadosaux";
        
		public static string PnSmiefectore = @"PN_smiefectores";
        
		public static string PnSmiprocesoafiliado = @"PN_smiprocesoafiliados";
        
		public static string PnSmitiposcategoria = @"PN_smitiposcategorias";
        
		public static string PnSubirArchivo = @"PN_subir_archivos";
        
		public static string PnSumariosPersonal = @"PN_sumarios_personal";
        
		public static string PnSuspensione = @"PN_suspensiones";
        
		public static string PnTareasDesemp = @"PN_tareas_desemp";
        
		public static string PnTipoDeMensaje = @"PN_tipo_de_mensaje";
        
		public static string PnTipoDocumento = @"PN_tipo_documento";
        
		public static string PnTipoEvento = @"PN_tipo_evento";
        
		public static string PnTipoPermiso = @"PN_tipo_permiso";
        
		public static string PnTipoDePrestacion = @"PN_TipoDePrestacion";
        
		public static string PnTransaccion = @"PN_transaccion";
        
		public static string PnTransaccionCertificado = @"PN_transaccion_certificado";
        
		public static string PnTribu = @"PN_tribus";
        
		public static string PnTrzPre = @"PN_trz_pres";
        
		public static string PnUadParametro = @"PN_uad_parametros";
        
		public static string PnUsuario = @"PN_usuarios";
        
		public static string PnVacApli = @"PN_vac_apli";
        
		public static string PnVacuna = @"PN_vacunas";
        
		public static string PnValidacionPrestacion = @"PN_validacion_prestacion";
        
		public static string PnZonaSani = @"PN_zona_sani";
        
		public static string PsmEFisico = @"PSM_EFisico";
        
		public static string RemActividadFisica = @"Rem_ActividadFisica";
        
		public static string RemAgente = @"Rem_Agente";
        
		public static string RemClasificacion = @"Rem_Clasificacion";
        
		public static string RemComplicacione = @"Rem_Complicaciones";
        
		public static string RemEstudioOcular = @"Rem_EstudioOcular";
        
		public static string RemExamenPie = @"Rem_ExamenPie";
        
		public static string RemFormulario = @"Rem_Formulario";
        
		public static string RemInternacion = @"Rem_Internacion";
        
		public static string RemMedicamentoCronico = @"Rem_MedicamentoCronico";
        
		public static string RemRelMedicamentoClasificacion = @"Rem_RelMedicamentoClasificacion";
        
		public static string RemRelMedicamentoSeguimiento = @"Rem_RelMedicamentoSeguimiento";
        
		public static string RemSeguimiento = @"Rem_Seguimiento";
        
		public static string RemTablaExaman = @"Rem_TablaExamen";
        
		public static string RemTipoCobertura = @"Rem_TipoCobertura";
        
		public static string RisAreaTematica = @"RIS_AreaTematica";
        
		public static string RisAseguradora = @"RIS_Aseguradora";
        
		public static string RisCaracteristica = @"RIS_Caracteristica";
        
		public static string RisComiteEtica = @"RIS_ComiteEtica";
        
		public static string RisConcentimiento = @"RIS_Concentimiento";
        
		public static string RisEnmienda = @"RIS_Enmienda";
        
		public static string RisEnmiendaItemDesaprobado = @"RIS_EnmiendaItemDesaprobado";
        
		public static string RisEntidad = @"RIS_Entidad";
        
		public static string RisEstudio = @"RIS_Estudio";
        
		public static string RisEstudioAseguradora = @"RIS_EstudioAseguradora";
        
		public static string RisEstudioCaracteristica = @"RIS_EstudioCaracteristica";
        
		public static string RisEstudioComiteEtica = @"RIS_EstudioComiteEtica";
        
		public static string RisEstudioEntidad = @"RIS_EstudioEntidad";
        
		public static string RisEstudioFuenteRecoleccionDato = @"RIS_EstudioFuenteRecoleccionDatos";
        
		public static string RisEstudioInvestigador = @"RIS_EstudioInvestigador";
        
		public static string RisEstudioItemAprobado = @"RIS_EstudioItemAprobado";
        
		public static string RisEstudioItemDesaprobado = @"RIS_EstudioItemDesaprobado";
        
		public static string RisEstudioPoblacionVulnerable = @"RIS_EstudioPoblacionVulnerable";
        
		public static string RisEstudioSysEfectorMulticentrico = @"RIS_EstudioSysEfectorMulticentrico";
        
		public static string RisEstudioSysPaisMulticentrico = @"RIS_EstudioSysPaisMulticentrico";
        
		public static string RisEstudioSysProvinciaMulticentrico = @"RIS_EstudioSysProvinciaMulticentrico";
        
		public static string RisEvaluacionRechazada = @"RIS_EvaluacionRechazada";
        
		public static string RisFuenteRecoleccionDato = @"RIS_FuenteRecoleccionDatos";
        
		public static string RisFuncionEnElEquipo = @"RIS_FuncionEnElEquipo";
        
		public static string RisInvestigadore = @"RIS_Investigadores";
        
		public static string RisItemAprobado = @"RIS_ItemAprobado";
        
		public static string RisItemDesaprobado = @"RIS_ItemDesaprobado";
        
		public static string RisLugarRealizacion = @"RIS_LugarRealizacion";
        
		public static string RisNotum = @"RIS_Nota";
        
		public static string RisPoblacionVulnerable = @"RIS_PoblacionVulnerable";
        
		public static string RisPresentacionInforme = @"RIS_PresentacionInforme";
        
		public static string RisProfesion = @"RIS_Profesion";
        
		public static string RisTipoDocumento = @"RIS_TipoDocumento";
        
		public static string RisTipoTelefono = @"RIS_TipoTelefono";
        
		public static string RisVigenciaPoliza = @"RIS_VigenciaPoliza";
        
		public static string SysAntecedente = @"Sys_Antecedente";
        
		public static string SysAntecedenteEnfermedad = @"Sys_AntecedenteEnfermedad";
        
		public static string SysBarrio = @"Sys_Barrio";
        
		public static string SysCepSap = @"Sys_CepSap";
        
		public static string SysCIE10 = @"Sys_CIE10";
        
		public static string SysCIE10Capitulo = @"Sys_CIE10Capitulo";
        
		public static string SysDefuncion = @"sys_Defuncion";
        
		public static string SysDepartamento = @"Sys_Departamento";
        
		public static string SysDireccione = @"Sys_Direcciones";
        
		public static string SysEfector = @"Sys_Efector";
        
		public static string SysEspecialidad = @"Sys_Especialidad";
        
		public static string SysEspecialidad2 = @"Sys_Especialidad2";
        
		public static string SysEstablecimiento = @"sys_Establecimiento";
        
		public static string SysEstado = @"Sys_Estado";
        
		public static string SysEstadoCivil = @"Sys_EstadoCivil";
        
		public static string SysHistoriaClinica = @"Sys_HistoriaClinica";
        
		public static string SysIdioma = @"Sys_Idioma";
        
		public static string SysLocalidad = @"Sys_Localidad";
        
		public static string SysMedicamento = @"Sys_Medicamento";
        
		public static string SysMedicamentoRubro = @"Sys_MedicamentoRubro";
        
		public static string SysMenu = @"Sys_Menu";
        
		public static string SysModulo = @"Sys_Modulo";
        
		public static string SysMotivoNI = @"Sys_MotivoNI";
        
		public static string SysMovimientoHistoriaClinica = @"Sys_MovimientoHistoriaClinica";
        
		public static string SysMunicipio = @"Sys_Municipio";
        
		public static string SysNivelInstruccion = @"Sys_NivelInstruccion";
        
		public static string SysObraSocial = @"Sys_ObraSocial";
        
		public static string SysOcupacion = @"Sys_Ocupacion";
        
		public static string SysOrganismo = @"Sys_Organismo";
        
		public static string SysPaciente = @"Sys_Paciente";
        
		public static string SysPacienteAntecedentesFamiliare = @"Sys_PacienteAntecedentesFamiliares";
        
		public static string SysPacienteCeliaco = @"Sys_PacienteCeliaco";
        
		public static string SysPai = @"Sys_Pais";
        
		public static string SysParentesco = @"Sys_Parentesco";
        
		public static string SysParentescoTipo = @"Sys_ParentescoTipo";
        
		public static string SysPerfil = @"Sys_Perfil";
        
		public static string SysPermiso = @"Sys_Permiso";
        
		public static string SysPoblacion = @"Sys_Poblacion";
        
		public static string SysPoblacion1 = @"Sys_Poblacion1";
        
		public static string SysProfesion = @"Sys_Profesion";
        
		public static string SysProfesional = @"Sys_Profesional";
        
		public static string SysProvincium = @"Sys_Provincia";
        
		public static string SysRelAntecedentePaciente = @"Sys_RelAntecedentePaciente";
        
		public static string SysRelEspecialidadEfector = @"Sys_RelEspecialidadEfector";
        
		public static string SysRelEstadoMotivoNI = @"Sys_RelEstadoMotivoNI";
        
		public static string SysRelFormularioCobertura = @"Sys_RelFormularioCobertura";
        
		public static string SysRelHistoriaClinicaEfector = @"Sys_RelHistoriaClinicaEfector";
        
		public static string SysRelPacienteObraSocial = @"Sys_RelPacienteObraSocial";
        
		public static string SysRelProfesionalEfector = @"Sys_RelProfesionalEfector";
        
		public static string SysRelServicioEfector = @"Sys_RelServicioEfector";
        
		public static string SysServicio = @"Sys_Servicio";
        
		public static string SysSexo = @"Sys_Sexo";
        
		public static string SysSituacionLaboral = @"Sys_SituacionLaboral";
        
		public static string SysTipoAntecedente = @"Sys_TipoAntecedente";
        
		public static string SysTipoCobertura = @"Sys_TipoCobertura";
        
		public static string SysTipoDocumento = @"Sys_TipoDocumento";
        
		public static string SysTipoEfector = @"Sys_TipoEfector";
        
		public static string SysTipoObraSocial = @"Sys_TipoObraSocial";
        
		public static string SysTipoProfesional = @"Sys_TipoProfesional";
        
		public static string SysUsuario = @"Sys_Usuario";
        
		public static string SysZona = @"Sys_Zona";
        
		public static string TabControl = @"TAB_Control";
        
		public static string TamDiagnostico = @"TAM_Diagnostico";
        
		public static string TamHallazgosColposcopico = @"TAM_HallazgosColposcopicos";
        
		public static string TamMetodoAnticonceptivo = @"TAM_MetodoAnticonceptivo";
        
		public static string TupEfectoresHabilitado = @"TUP_EfectoresHabilitados";
        
		public static string TupTurnosProtegido = @"TUP_TurnosProtegidos";
        
		public static string VgiAClinicosDet = @"VGI_AClinicosDet";
        
		public static string VgiCInterconsultaItem = @"VGI_CInterconsultaItems";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table AprAborto{
            get { return DataService.GetSchema("APR_Aborto","sicProvider"); }
		}
        
		public static TableSchema.Table AprAcompañante{
            get { return DataService.GetSchema("APR_Acompañante","sicProvider"); }
		}
        
		public static TableSchema.Table AprActividad{
            get { return DataService.GetSchema("APR_Actividad","sicProvider"); }
		}
        
		public static TableSchema.Table AprActividadControlPerinatal{
            get { return DataService.GetSchema("APR_ActividadControlPerinatal","sicProvider"); }
		}
        
		public static TableSchema.Table AprActividadEmbarazo{
            get { return DataService.GetSchema("APR_ActividadEmbarazo","sicProvider"); }
		}
        
		public static TableSchema.Table AprActividadFisica{
            get { return DataService.GetSchema("APR_ActividadFisica","sicProvider"); }
		}
        
		public static TableSchema.Table AprActualPatologiaEmbarazo{
            get { return DataService.GetSchema("APR_ActualPatologiaEmbarazo","sicProvider"); }
		}
        
		public static TableSchema.Table AprAlertaControlMenor{
            get { return DataService.GetSchema("APR_AlertaControlMenor","sicProvider"); }
		}
        
		public static TableSchema.Table AprAlimentacionRecienNacido{
            get { return DataService.GetSchema("APR_AlimentacionRecienNacido","sicProvider"); }
		}
        
		public static TableSchema.Table AprAlturaUterina{
            get { return DataService.GetSchema("APR_AlturaUterina","sicProvider"); }
		}
        
		public static TableSchema.Table AprAmbienteProcedimiento{
            get { return DataService.GetSchema("APR_AmbienteProcedimiento","sicProvider"); }
		}
        
		public static TableSchema.Table AprAntecedentePatologiaEmbarazo{
            get { return DataService.GetSchema("APR_AntecedentePatologiaEmbarazo","sicProvider"); }
		}
        
		public static TableSchema.Table AprAntecedentePerinatal{
            get { return DataService.GetSchema("APR_AntecedentePerinatal","sicProvider"); }
		}
        
		public static TableSchema.Table AprAntecedentePerinatalNacimiento{
            get { return DataService.GetSchema("APR_AntecedentePerinatalNacimiento","sicProvider"); }
		}
        
		public static TableSchema.Table AprAplicacionVacuna{
            get { return DataService.GetSchema("APR_AplicacionVacuna","sicProvider"); }
		}
        
		public static TableSchema.Table AprAreaDesarrollo{
            get { return DataService.GetSchema("APR_AreaDesarrollo","sicProvider"); }
		}
        
		public static TableSchema.Table AprCalendarioVacuna{
            get { return DataService.GetSchema("APR_CalendarioVacuna","sicProvider"); }
		}
        
		public static TableSchema.Table AprCalendarioVisita{
            get { return DataService.GetSchema("APR_CalendarioVisitas","sicProvider"); }
		}
        
		public static TableSchema.Table AprCategoriaPesoNacimiento{
            get { return DataService.GetSchema("APR_CategoriaPesoNacimiento","sicProvider"); }
		}
        
		public static TableSchema.Table AprCentilesIMCEdadGestacional{
            get { return DataService.GetSchema("APR_CentilesIMCEdadGestacional","sicProvider"); }
		}
        
		public static TableSchema.Table AprCMOtrosDato{
            get { return DataService.GetSchema("APR_CMOtrosDatos","sicProvider"); }
		}
        
		public static TableSchema.Table AprComplicacionAborto{
            get { return DataService.GetSchema("APR_ComplicacionAborto","sicProvider"); }
		}
        
		public static TableSchema.Table AprComplicacionIntraoperatorium{
            get { return DataService.GetSchema("APR_ComplicacionIntraoperatoria","sicProvider"); }
		}
        
		public static TableSchema.Table AprConcejerium{
            get { return DataService.GetSchema("APR_Concejeria","sicProvider"); }
		}
        
		public static TableSchema.Table AprCondicionesVivienda{
            get { return DataService.GetSchema("APR_CondicionesVivienda","sicProvider"); }
		}
        
		public static TableSchema.Table AprCondicionIngreso{
            get { return DataService.GetSchema("APR_CondicionIngreso","sicProvider"); }
		}
        
		public static TableSchema.Table AprConsultaAntenatal{
            get { return DataService.GetSchema("APR_ConsultaAntenatal","sicProvider"); }
		}
        
		public static TableSchema.Table AprControlNiñoSano{
            get { return DataService.GetSchema("APR_ControlNiñoSano","sicProvider"); }
		}
        
		public static TableSchema.Table AprControlNiñoSanoConsultorio{
            get { return DataService.GetSchema("APR_ControlNiñoSanoConsultorio","sicProvider"); }
		}
        
		public static TableSchema.Table AprControlNiñoSanoEnfermerium{
            get { return DataService.GetSchema("APR_ControlNiñoSanoEnfermeria","sicProvider"); }
		}
        
		public static TableSchema.Table AprControlNiñoSanoHemoglobina{
            get { return DataService.GetSchema("APR_ControlNiñoSanoHemoglobina","sicProvider"); }
		}
        
		public static TableSchema.Table AprControlNiñoSanoOdontologico{
            get { return DataService.GetSchema("APR_ControlNiñoSanoOdontologico","sicProvider"); }
		}
        
		public static TableSchema.Table AprControlOdontologico{
            get { return DataService.GetSchema("APR_ControlOdontologico","sicProvider"); }
		}
        
		public static TableSchema.Table AprDefectoCongenito{
            get { return DataService.GetSchema("APR_DefectoCongenito","sicProvider"); }
		}
        
		public static TableSchema.Table AprDiagnosticoControlOdontologico{
            get { return DataService.GetSchema("APR_DiagnosticoControlOdontologico","sicProvider"); }
		}
        
		public static TableSchema.Table AprEgresoMaterno{
            get { return DataService.GetSchema("APR_EgresoMaterno","sicProvider"); }
		}
        
		public static TableSchema.Table AprEgresoPorAborto{
            get { return DataService.GetSchema("APR_EgresoPorAborto","sicProvider"); }
		}
        
		public static TableSchema.Table AprEmbarazo{
            get { return DataService.GetSchema("APR_Embarazo","sicProvider"); }
		}
        
		public static TableSchema.Table AprEstadoNacimiento{
            get { return DataService.GetSchema("APR_EstadoNacimiento","sicProvider"); }
		}
        
		public static TableSchema.Table AprEstadoNutricional{
            get { return DataService.GetSchema("APR_EstadoNutricional","sicProvider"); }
		}
        
		public static TableSchema.Table AprEstiloVida{
            get { return DataService.GetSchema("APR_EstiloVida","sicProvider"); }
		}
        
		public static TableSchema.Table AprEtnium{
            get { return DataService.GetSchema("APR_Etnia","sicProvider"); }
		}
        
		public static TableSchema.Table AprFactorProtector{
            get { return DataService.GetSchema("APR_FactorProtector","sicProvider"); }
		}
        
		public static TableSchema.Table AprFactorRiesgo{
            get { return DataService.GetSchema("APR_FactorRiesgo","sicProvider"); }
		}
        
		public static TableSchema.Table AprFactorRiesgoEstiloVida{
            get { return DataService.GetSchema("APR_FactorRiesgoEstiloVida","sicProvider"); }
		}
        
		public static TableSchema.Table AprFactorRiesgoPsicosocial{
            get { return DataService.GetSchema("APR_FactorRiesgoPsicosocial","sicProvider"); }
		}
        
		public static TableSchema.Table AprFormaConcejerium{
            get { return DataService.GetSchema("APR_FormaConcejeria","sicProvider"); }
		}
        
		public static TableSchema.Table AprHistoriaClinicaPerinatal{
            get { return DataService.GetSchema("APR_HistoriaClinicaPerinatal","sicProvider"); }
		}
        
		public static TableSchema.Table AprHistoriaClinicaPerinatalDetalle{
            get { return DataService.GetSchema("APR_HistoriaClinicaPerinatalDetalle","sicProvider"); }
		}
        
		public static TableSchema.Table AprInicioEmbarazo{
            get { return DataService.GetSchema("APR_InicioEmbarazo","sicProvider"); }
		}
        
		public static TableSchema.Table AprInterconsultum{
            get { return DataService.GetSchema("APR_Interconsulta","sicProvider"); }
		}
        
		public static TableSchema.Table AprIntervencion{
            get { return DataService.GetSchema("APR_Intervencion","sicProvider"); }
		}
        
		public static TableSchema.Table AprIntervencionProfesional{
            get { return DataService.GetSchema("APR_IntervencionProfesional","sicProvider"); }
		}
        
		public static TableSchema.Table AprMomentoNacimiento{
            get { return DataService.GetSchema("APR_MomentoNacimiento","sicProvider"); }
		}
        
		public static TableSchema.Table AprMotivoVisitaDomiciliarium{
            get { return DataService.GetSchema("APR_MotivoVisitaDomiciliaria","sicProvider"); }
		}
        
		public static TableSchema.Table AprNumeroDosi{
            get { return DataService.GetSchema("APR_NumeroDosis","sicProvider"); }
		}
        
		public static TableSchema.Table AprPartoProvisorio{
            get { return DataService.GetSchema("APR_PartoProvisorio","sicProvider"); }
		}
        
		public static TableSchema.Table AprPercentilesIMCEdad{
            get { return DataService.GetSchema("APR_PercentilesIMCEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprPercentilesLongitudEstaturaEdad{
            get { return DataService.GetSchema("APR_PercentilesLongitudEstaturaEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprPercentilesPerimetroCefalicoEdad{
            get { return DataService.GetSchema("APR_PercentilesPerimetroCefalicoEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprPercentilesPesoEdad{
            get { return DataService.GetSchema("APR_PercentilesPesoEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprPercentilesPesoEstatura{
            get { return DataService.GetSchema("APR_PercentilesPesoEstatura","sicProvider"); }
		}
        
		public static TableSchema.Table AprPercentilesPesoLongitud{
            get { return DataService.GetSchema("APR_PercentilesPesoLongitud","sicProvider"); }
		}
        
		public static TableSchema.Table AprProblemasMenor{
            get { return DataService.GetSchema("APR_ProblemasMenor","sicProvider"); }
		}
        
		public static TableSchema.Table AprRecienNacido{
            get { return DataService.GetSchema("APR_RecienNacido","sicProvider"); }
		}
        
		public static TableSchema.Table AprRelControlNiñoSanoAreaDesarrollo{
            get { return DataService.GetSchema("APR_RelControlNiñoSanoAreaDesarrollo","sicProvider"); }
		}
        
		public static TableSchema.Table AprRelControlNiñoSanoFactorRiesgo{
            get { return DataService.GetSchema("APR_RelControlNiñoSanoFactorRiesgo","sicProvider"); }
		}
        
		public static TableSchema.Table AprRelControNiñoSanoFactorProtector{
            get { return DataService.GetSchema("APR_RelControNiñoSanoFactorProtector","sicProvider"); }
		}
        
		public static TableSchema.Table AprRelPersonaFactorRiesgoInicial{
            get { return DataService.GetSchema("APR_RelPersonaFactorRiesgoInicial","sicProvider"); }
		}
        
		public static TableSchema.Table AprRelRecienNacidoDefectoCongenito{
            get { return DataService.GetSchema("APR_RelRecienNacidoDefectoCongenito","sicProvider"); }
		}
        
		public static TableSchema.Table AprRelRecienNacidoEnfermedad{
            get { return DataService.GetSchema("APR_RelRecienNacidoEnfermedad","sicProvider"); }
		}
        
		public static TableSchema.Table AprTallaEdad{
            get { return DataService.GetSchema("APR_TallaEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprTerminacionParto{
            get { return DataService.GetSchema("APR_TerminacionParto","sicProvider"); }
		}
        
		public static TableSchema.Table AprTipoActividadEmbarazo{
            get { return DataService.GetSchema("APR_TipoActividadEmbarazo","sicProvider"); }
		}
        
		public static TableSchema.Table AprTipoLactancium{
            get { return DataService.GetSchema("APR_TipoLactancia","sicProvider"); }
		}
        
		public static TableSchema.Table AprTipoParto{
            get { return DataService.GetSchema("APR_TipoParto","sicProvider"); }
		}
        
		public static TableSchema.Table AprTipoProfesional{
            get { return DataService.GetSchema("APR_TipoProfesional","sicProvider"); }
		}
        
		public static TableSchema.Table AprVisitaDomiciliarium{
            get { return DataService.GetSchema("APR_VisitaDomiciliaria","sicProvider"); }
		}
        
		public static TableSchema.Table AprZScoreIMCEdad{
            get { return DataService.GetSchema("APR_ZScoreIMCEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprZScoreLongitudEstaturaEdad{
            get { return DataService.GetSchema("APR_ZScoreLongitudEstaturaEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprZScorePerimetroCefalicoEdad{
            get { return DataService.GetSchema("APR_ZScorePerimetroCefalicoEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprZScorePesoEdad{
            get { return DataService.GetSchema("APR_ZScorePesoEdad","sicProvider"); }
		}
        
		public static TableSchema.Table AprZScorePesoEstatura{
            get { return DataService.GetSchema("APR_ZScorePesoEstatura","sicProvider"); }
		}
        
		public static TableSchema.Table AprZScorePesoLongitud{
            get { return DataService.GetSchema("APR_ZScorePesoLongitud","sicProvider"); }
		}
        
		public static TableSchema.Table AutHistoricoVehiculoPmp{
            get { return DataService.GetSchema("AUT_Historico_Vehiculo_PMP","sicProvider"); }
		}
        
		public static TableSchema.Table AutTipoPNP{
            get { return DataService.GetSchema("Aut_TipoPNP","sicProvider"); }
		}
        
		public static TableSchema.Table BdsTipoDonante{
            get { return DataService.GetSchema("BDS_TipoDonante","sicProvider"); }
		}
        
		public static TableSchema.Table BkpOdoNomenclador{
            get { return DataService.GetSchema("bkp_ODO_Nomenclador","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgenda{
            get { return DataService.GetSchema("CON_Agenda","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaAuditorium{
            get { return DataService.GetSchema("CON_AgendaAuditoria","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaBloqueo{
            get { return DataService.GetSchema("CON_AgendaBloqueo","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaEstado{
            get { return DataService.GetSchema("CON_AgendaEstado","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaGrupal{
            get { return DataService.GetSchema("CON_AgendaGrupal","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaGrupalOrganismo{
            get { return DataService.GetSchema("CON_AgendaGrupalOrganismo","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaGrupalPaciente{
            get { return DataService.GetSchema("CON_AgendaGrupalPaciente","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaGrupalProfesional{
            get { return DataService.GetSchema("CON_AgendaGrupalProfesional","sicProvider"); }
		}
        
		public static TableSchema.Table ConAgendaProfesional{
            get { return DataService.GetSchema("CON_AgendaProfesional","sicProvider"); }
		}
        
		public static TableSchema.Table ConConsultum{
            get { return DataService.GetSchema("CON_Consulta","sicProvider"); }
		}
        
		public static TableSchema.Table ConConsultaDiagnostico{
            get { return DataService.GetSchema("CON_ConsultaDiagnostico","sicProvider"); }
		}
        
		public static TableSchema.Table ConConsultaMedicamento{
            get { return DataService.GetSchema("CON_ConsultaMedicamento","sicProvider"); }
		}
        
		public static TableSchema.Table ConConsultaOdontologium{
            get { return DataService.GetSchema("CON_ConsultaOdontologia","sicProvider"); }
		}
        
		public static TableSchema.Table ConConsultorio{
            get { return DataService.GetSchema("CON_Consultorio","sicProvider"); }
		}
        
		public static TableSchema.Table ConConsultorioTipo{
            get { return DataService.GetSchema("CON_ConsultorioTipo","sicProvider"); }
		}
        
		public static TableSchema.Table ConDemanda{
            get { return DataService.GetSchema("CON_Demanda","sicProvider"); }
		}
        
		public static TableSchema.Table ConDemandaRechazada{
            get { return DataService.GetSchema("CON_DemandaRechazada","sicProvider"); }
		}
        
		public static TableSchema.Table ConEquipo{
            get { return DataService.GetSchema("CON_Equipo","sicProvider"); }
		}
        
		public static TableSchema.Table ConLugarActividadGrupal{
            get { return DataService.GetSchema("CON_LugarActividadGrupal","sicProvider"); }
		}
        
		public static TableSchema.Table ConMotivoBaja{
            get { return DataService.GetSchema("CON_MotivoBaja","sicProvider"); }
		}
        
		public static TableSchema.Table ConMotivoInactivacionAgenda{
            get { return DataService.GetSchema("CON_MotivoInactivacionAgenda","sicProvider"); }
		}
        
		public static TableSchema.Table ConMotivosDeBloqueo{
            get { return DataService.GetSchema("CON_MotivosDeBloqueo","sicProvider"); }
		}
        
		public static TableSchema.Table ConMotivosRechazo{
            get { return DataService.GetSchema("CON_MotivosRechazo","sicProvider"); }
		}
        
		public static TableSchema.Table ConNivelDeAbordaje{
            get { return DataService.GetSchema("CON_NivelDeAbordaje","sicProvider"); }
		}
        
		public static TableSchema.Table ConTematica{
            get { return DataService.GetSchema("CON_Tematica","sicProvider"); }
		}
        
		public static TableSchema.Table ConTiempoInsumido{
            get { return DataService.GetSchema("CON_TiempoInsumido","sicProvider"); }
		}
        
		public static TableSchema.Table ConTipoActividadGrupal{
            get { return DataService.GetSchema("CON_TipoActividadGrupal","sicProvider"); }
		}
        
		public static TableSchema.Table ConTipoDePrestacionSaludMental{
            get { return DataService.GetSchema("CON_TipoDePrestacionSaludMental","sicProvider"); }
		}
        
		public static TableSchema.Table ConTipoPrestacion{
            get { return DataService.GetSchema("CON_TipoPrestacion","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurno{
            get { return DataService.GetSchema("CON_Turno","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurnoAsistencium{
            get { return DataService.GetSchema("CON_TurnoAsistencia","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurnoAuditorium{
            get { return DataService.GetSchema("CON_TurnoAuditoria","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurnoBloqueo{
            get { return DataService.GetSchema("CON_TurnoBloqueo","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurnoEstado{
            get { return DataService.GetSchema("CON_TurnoEstado","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurnoRecitum{
            get { return DataService.GetSchema("CON_TurnoRecita","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurnoReserva{
            get { return DataService.GetSchema("CON_TurnoReserva","sicProvider"); }
		}
        
		public static TableSchema.Table ConTurnoReservaInterconsultum{
            get { return DataService.GetSchema("CON_TurnoReservaInterconsulta","sicProvider"); }
		}
        
		public static TableSchema.Table EmrRelTraumaPrehospitalarium{
            get { return DataService.GetSchema("EMR_RelTraumaPrehospitalaria","sicProvider"); }
		}
        
		public static TableSchema.Table FacContratoObraSocial{
            get { return DataService.GetSchema("FAC_ContratoObraSocial","sicProvider"); }
		}
        
		public static TableSchema.Table FacJefeLaboratorio{
            get { return DataService.GetSchema("FAC_JefeLaboratorio","sicProvider"); }
		}
        
		public static TableSchema.Table FacOrdenLaboratorio{
            get { return DataService.GetSchema("FAC_OrdenLaboratorio","sicProvider"); }
		}
        
		public static TableSchema.Table FacRelPerfilPaginaPrincipal{
            get { return DataService.GetSchema("FAC_RelPerfilPaginaPrincipal","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaAntecedente{
            get { return DataService.GetSchema("Guardia_Antecedentes","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaC2{
            get { return DataService.GetSchema("Guardia_C2","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaMedicosFuncione{
            get { return DataService.GetSchema("Guardia_Medicos_Funciones","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaMedicosRegistroIngreso{
            get { return DataService.GetSchema("Guardia_Medicos_registroIngreso","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaMedicosTiposFuncione{
            get { return DataService.GetSchema("Guardia_Medicos_TiposFunciones","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaMensaje{
            get { return DataService.GetSchema("Guardia_Mensajes","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaPracticasClase{
            get { return DataService.GetSchema("Guardia_Practicas_Clases","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaPracticasEstado{
            get { return DataService.GetSchema("Guardia_Practicas_Estados","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaPracticasPrioridade{
            get { return DataService.GetSchema("Guardia_Practicas_Prioridades","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaPrescripcione{
            get { return DataService.GetSchema("Guardia_Prescripciones","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistro{
            get { return DataService.GetSchema("Guardia_Registros","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosClasificacione{
            get { return DataService.GetSchema("Guardia_Registros_Clasificaciones","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosDiagnostico{
            get { return DataService.GetSchema("Guardia_Registros_Diagnosticos","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosDiagnosticosCie10{
            get { return DataService.GetSchema("Guardia_Registros_Diagnosticos_Cie10","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosEstado{
            get { return DataService.GetSchema("Guardia_Registros_Estados","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosHistorial{
            get { return DataService.GetSchema("Guardia_Registros_Historial","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosMedicosResponsable{
            get { return DataService.GetSchema("Guardia_Registros_MedicosResponsables","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosPractica{
            get { return DataService.GetSchema("Guardia_Registros_Practicas","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaRegistrosPracticasLaboratorio{
            get { return DataService.GetSchema("Guardia_Registros_Practicas_Laboratorio","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaTipoPractica{
            get { return DataService.GetSchema("Guardia_TipoPracticas","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaTiposEgreso{
            get { return DataService.GetSchema("Guardia_TiposEgresos","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaTiposIngreso{
            get { return DataService.GetSchema("Guardia_TiposIngreso","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaTriage{
            get { return DataService.GetSchema("Guardia_Triage","sicProvider"); }
		}
        
		public static TableSchema.Table GuardiaTurnero{
            get { return DataService.GetSchema("Guardia_Turnero","sicProvider"); }
		}
        
		public static TableSchema.Table HidHidatidosi{
            get { return DataService.GetSchema("Hid_Hidatidosis","sicProvider"); }
		}
        
		public static TableSchema.Table HidHidatidosisParcial{
            get { return DataService.GetSchema("Hid_HidatidosisParcial","sicProvider"); }
		}
        
		public static TableSchema.Table IcoDestinatarioInterconsultum{
            get { return DataService.GetSchema("ICO_DestinatarioInterconsulta","sicProvider"); }
		}
        
		public static TableSchema.Table IcoDialogoInterconsultum{
            get { return DataService.GetSchema("ICO_DialogoInterconsulta","sicProvider"); }
		}
        
		public static TableSchema.Table IcoInterconsultum{
            get { return DataService.GetSchema("ICO_Interconsulta","sicProvider"); }
		}
        
		public static TableSchema.Table IcoTiposUsuario{
            get { return DataService.GetSchema("ICO_TiposUsuario","sicProvider"); }
		}
        
		public static TableSchema.Table IcoUbicacionArchivo{
            get { return DataService.GetSchema("ICO_UbicacionArchivos","sicProvider"); }
		}
        
		public static TableSchema.Table InsDatoFarmaceutico{
            get { return DataService.GetSchema("INS_DatoFarmaceutico","sicProvider"); }
		}
        
		public static TableSchema.Table JmCertificadoMedico{
            get { return DataService.GetSchema("JM_CertificadoMedico","sicProvider"); }
		}
        
		public static TableSchema.Table LabAcceso{
            get { return DataService.GetSchema("LAB_Acceso","sicProvider"); }
		}
        
		public static TableSchema.Table LabAccesoResultado{
            get { return DataService.GetSchema("LAB_AccesoResultado","sicProvider"); }
		}
        
		public static TableSchema.Table LabAlarmaScreening{
            get { return DataService.GetSchema("LAB_AlarmaScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabDetalleSolicitudScreening{
            get { return DataService.GetSchema("LAB_DetalleSolicitudScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabItemRepeticionScreening{
            get { return DataService.GetSchema("LAB_ItemRepeticionScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabItemScreening{
            get { return DataService.GetSchema("LAB_ItemScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabItemScreeningResultado{
            get { return DataService.GetSchema("LAB_ItemScreeningResultado","sicProvider"); }
		}
        
		public static TableSchema.Table LabMetodoScreening{
            get { return DataService.GetSchema("LAB_MetodoScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabMotivoRechazoScreening{
            get { return DataService.GetSchema("LAB_MotivoRechazoScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabMotivoRepeticionScreening{
            get { return DataService.GetSchema("LAB_MotivoRepeticionScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabProtocoloScreening{
            get { return DataService.GetSchema("LAB_ProtocoloScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabProtocoloScreeningDetalle{
            get { return DataService.GetSchema("LAB_ProtocoloScreeningDetalle","sicProvider"); }
		}
        
		public static TableSchema.Table LabReactivo{
            get { return DataService.GetSchema("LAB_Reactivo","sicProvider"); }
		}
        
		public static TableSchema.Table LabResultadoDetalle{
            get { return DataService.GetSchema("LAB_ResultadoDetalle","sicProvider"); }
		}
        
		public static TableSchema.Table LabResultadoEncabezado{
            get { return DataService.GetSchema("LAB_ResultadoEncabezado","sicProvider"); }
		}
        
		public static TableSchema.Table LabResultadoScreening{
            get { return DataService.GetSchema("LAB_ResultadoScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabSolicitudScreening{
            get { return DataService.GetSchema("LAB_SolicitudScreening","sicProvider"); }
		}
        
		public static TableSchema.Table LabSolicitudScreeningEstado{
            get { return DataService.GetSchema("Lab_SolicitudScreeningEstados","sicProvider"); }
		}
        
		public static TableSchema.Table LabSolicitudScreeningRepeticion{
            get { return DataService.GetSchema("LAB_SolicitudScreeningRepeticion","sicProvider"); }
		}
        
		public static TableSchema.Table LabTempResultadoDetalle{
            get { return DataService.GetSchema("LAB_Temp_ResultadoDetalle","sicProvider"); }
		}
        
		public static TableSchema.Table LabTempResultadoEncabezado{
            get { return DataService.GetSchema("LAB_Temp_ResultadoEncabezado","sicProvider"); }
		}
        
		public static TableSchema.Table LabTempSolicitudScreening20131209{
            get { return DataService.GetSchema("Lab_temp_SolicitudScreening20131209","sicProvider"); }
		}
        
		public static TableSchema.Table LabTempResultadoTarjetasScreening{
            get { return DataService.GetSchema("Lab_TempResultadoTarjetasScreening","sicProvider"); }
		}
        
		public static TableSchema.Table MamAnatomiaPatologica{
            get { return DataService.GetSchema("MAM_AnatomiaPatologica","sicProvider"); }
		}
        
		public static TableSchema.Table MamAntecedente{
            get { return DataService.GetSchema("MAM_Antecedentes","sicProvider"); }
		}
        
		public static TableSchema.Table MamBirad{
            get { return DataService.GetSchema("MAM_Birads","sicProvider"); }
		}
        
		public static TableSchema.Table MamCirugium{
            get { return DataService.GetSchema("MAM_Cirugia","sicProvider"); }
		}
        
		public static TableSchema.Table MamDiagnosticoCitologico{
            get { return DataService.GetSchema("MAM_DiagnosticoCitologico","sicProvider"); }
		}
        
		public static TableSchema.Table MamDiagnoticoHistologico{
            get { return DataService.GetSchema("MAM_DiagnoticoHistologico","sicProvider"); }
		}
        
		public static TableSchema.Table MamEcografium{
            get { return DataService.GetSchema("MAM_Ecografia","sicProvider"); }
		}
        
		public static TableSchema.Table MamEstadio{
            get { return DataService.GetSchema("MAM_Estadio","sicProvider"); }
		}
        
		public static TableSchema.Table MamEstadioClinico{
            get { return DataService.GetSchema("MAM_EstadioClinico","sicProvider"); }
		}
        
		public static TableSchema.Table MamEstudiosAdicionale{
            get { return DataService.GetSchema("MAM_EstudiosAdicionales","sicProvider"); }
		}
        
		public static TableSchema.Table MamEstudiosHospitalProvincial{
            get { return DataService.GetSchema("MAM_EstudiosHospitalProvincial","sicProvider"); }
		}
        
		public static TableSchema.Table MamExamenFisico{
            get { return DataService.GetSchema("MAM_ExamenFisico","sicProvider"); }
		}
        
		public static TableSchema.Table MamIndicadorM{
            get { return DataService.GetSchema("MAM_IndicadorM","sicProvider"); }
		}
        
		public static TableSchema.Table MamIndicadorN{
            get { return DataService.GetSchema("MAM_IndicadorN","sicProvider"); }
		}
        
		public static TableSchema.Table MamIndicadorT{
            get { return DataService.GetSchema("MAM_IndicadorT","sicProvider"); }
		}
        
		public static TableSchema.Table MamMaterial{
            get { return DataService.GetSchema("MAM_Material","sicProvider"); }
		}
        
		public static TableSchema.Table MamMotivo{
            get { return DataService.GetSchema("MAM_Motivo","sicProvider"); }
		}
        
		public static TableSchema.Table MamMotivoConsultum{
            get { return DataService.GetSchema("MAM_MotivoConsulta","sicProvider"); }
		}
        
		public static TableSchema.Table MamPiezaQuirurgica{
            get { return DataService.GetSchema("MAM_PiezaQuirurgica","sicProvider"); }
		}
        
		public static TableSchema.Table MamRegistro{
            get { return DataService.GetSchema("MAM_Registro","sicProvider"); }
		}
        
		public static TableSchema.Table MamResultadoExFisico{
            get { return DataService.GetSchema("MAM_ResultadoExFisico","sicProvider"); }
		}
        
		public static TableSchema.Table MamTipoCirugium{
            get { return DataService.GetSchema("MAM_TipoCirugia","sicProvider"); }
		}
        
		public static TableSchema.Table MamTipoEquipo{
            get { return DataService.GetSchema("MAM_TipoEquipo","sicProvider"); }
		}
        
		public static TableSchema.Table MamTipoEstudio{
            get { return DataService.GetSchema("MAM_TipoEstudio","sicProvider"); }
		}
        
		public static TableSchema.Table MamTipoMotivoConsultum{
            get { return DataService.GetSchema("MAM_TipoMotivoConsulta","sicProvider"); }
		}
        
		public static TableSchema.Table MamTratamiento{
            get { return DataService.GetSchema("MAM_Tratamientos","sicProvider"); }
		}
        
		public static TableSchema.Table OdoNomenclador{
            get { return DataService.GetSchema("ODO_Nomenclador","sicProvider"); }
		}
        
		public static TableSchema.Table OdoPrograma{
            get { return DataService.GetSchema("ODO_Programa","sicProvider"); }
		}
        
		public static TableSchema.Table PnAccidentesLab{
            get { return DataService.GetSchema("PN_accidentes_lab","sicProvider"); }
		}
        
		public static TableSchema.Table PnAfjp{
            get { return DataService.GetSchema("PN_afjp","sicProvider"); }
		}
        
		public static TableSchema.Table PnAgenteInscriptor{
            get { return DataService.GetSchema("PN_agente_inscriptor","sicProvider"); }
		}
        
		public static TableSchema.Table PnAltum{
            get { return DataService.GetSchema("PN_alta","sicProvider"); }
		}
        
		public static TableSchema.Table PnAnexo{
            get { return DataService.GetSchema("PN_anexo","sicProvider"); }
		}
        
		public static TableSchema.Table PnArbol{
            get { return DataService.GetSchema("PN_arbol","sicProvider"); }
		}
        
		public static TableSchema.Table PnArchivoManual{
            get { return DataService.GetSchema("PN_archivo_manual","sicProvider"); }
		}
        
		public static TableSchema.Table PnArchivosCaso{
            get { return DataService.GetSchema("PN_archivos_casos","sicProvider"); }
		}
        
		public static TableSchema.Table PnArchivosEnviado{
            get { return DataService.GetSchema("PN_archivos_enviados","sicProvider"); }
		}
        
		public static TableSchema.Table PnArchivosRecibido{
            get { return DataService.GetSchema("PN_archivos_recibidos","sicProvider"); }
		}
        
		public static TableSchema.Table PnArea{
            get { return DataService.GetSchema("PN_areas","sicProvider"); }
		}
        
		public static TableSchema.Table PnAsistencium{
            get { return DataService.GetSchema("PN_asistencia","sicProvider"); }
		}
        
		public static TableSchema.Table PnAusentismo{
            get { return DataService.GetSchema("PN_ausentismo","sicProvider"); }
		}
        
		public static TableSchema.Table PnBarrio{
            get { return DataService.GetSchema("PN_barrios","sicProvider"); }
		}
        
		public static TableSchema.Table PnBeneficiario{
            get { return DataService.GetSchema("PN_beneficiarios","sicProvider"); }
		}
        
		public static TableSchema.Table PnBorrar{
            get { return DataService.GetSchema("PN_Borrar","sicProvider"); }
		}
        
		public static TableSchema.Table PnCalculaPrecio{
            get { return DataService.GetSchema("PN_calcula_precio","sicProvider"); }
		}
        
		public static TableSchema.Table PnCalificacion{
            get { return DataService.GetSchema("PN_calificacion","sicProvider"); }
		}
        
		public static TableSchema.Table PnCapacitacione{
            get { return DataService.GetSchema("PN_capacitaciones","sicProvider"); }
		}
        
		public static TableSchema.Table PnCapacitado{
            get { return DataService.GetSchema("PN_capacitados","sicProvider"); }
		}
        
		public static TableSchema.Table PnCapsHacenParto{
            get { return DataService.GetSchema("PN_caps_hacen_partos","sicProvider"); }
		}
        
		public static TableSchema.Table PnCategoria{
            get { return DataService.GetSchema("PN_categorias","sicProvider"); }
		}
        
		public static TableSchema.Table PnClasificacionManual{
            get { return DataService.GetSchema("PN_clasificacion_manual","sicProvider"); }
		}
        
		public static TableSchema.Table PnComprobante{
            get { return DataService.GetSchema("PN_comprobante","sicProvider"); }
		}
        
		public static TableSchema.Table PnCredito{
            get { return DataService.GetSchema("PN_credito","sicProvider"); }
		}
        
		public static TableSchema.Table PnCurriculumIdioma{
            get { return DataService.GetSchema("PN_curriculum_idiomas","sicProvider"); }
		}
        
		public static TableSchema.Table PnCurriculumReferencium{
            get { return DataService.GetSchema("PN_curriculum_referencia","sicProvider"); }
		}
        
		public static TableSchema.Table PnDatMinObl{
            get { return DataService.GetSchema("PN_dat_min_obl","sicProvider"); }
		}
        
		public static TableSchema.Table PnDatosReportable{
            get { return DataService.GetSchema("PN_datos_reportables","sicProvider"); }
		}
        
		public static TableSchema.Table PnDebito{
            get { return DataService.GetSchema("PN_debito","sicProvider"); }
		}
        
		public static TableSchema.Table PnDepartamento{
            get { return DataService.GetSchema("PN_departamentos","sicProvider"); }
		}
        
		public static TableSchema.Table PnDescIndicadorIn{
            get { return DataService.GetSchema("PN_desc_indicador_ins","sicProvider"); }
		}
        
		public static TableSchema.Table PnDiasSemana{
            get { return DataService.GetSchema("PN_dias_semana","sicProvider"); }
		}
        
		public static TableSchema.Table PnDirectoriosArchivo{
            get { return DataService.GetSchema("PN_directorios_archivos","sicProvider"); }
		}
        
		public static TableSchema.Table PnDistrito{
            get { return DataService.GetSchema("PN_distrito","sicProvider"); }
		}
        
		public static TableSchema.Table PnDosisApli{
            get { return DataService.GetSchema("PN_dosis_apli","sicProvider"); }
		}
        
		public static TableSchema.Table PnDpto{
            get { return DataService.GetSchema("PN_dpto","sicProvider"); }
		}
        
		public static TableSchema.Table PnEfeConv{
            get { return DataService.GetSchema("PN_efe_conv","sicProvider"); }
		}
        
		public static TableSchema.Table PnEfecNom{
            get { return DataService.GetSchema("PN_efec_nom","sicProvider"); }
		}
        
		public static TableSchema.Table PnEgreso{
            get { return DataService.GetSchema("PN_egreso","sicProvider"); }
		}
        
		public static TableSchema.Table PnEmbarazada{
            get { return DataService.GetSchema("PN_embarazadas","sicProvider"); }
		}
        
		public static TableSchema.Table PnEnfermedade{
            get { return DataService.GetSchema("PN_enfermedades","sicProvider"); }
		}
        
		public static TableSchema.Table PnEntrega{
            get { return DataService.GetSchema("PN_entrega","sicProvider"); }
		}
        
		public static TableSchema.Table PnEvaluadore{
            get { return DataService.GetSchema("PN_evaluadores","sicProvider"); }
		}
        
		public static TableSchema.Table PnEvento{
            get { return DataService.GetSchema("PN_evento","sicProvider"); }
		}
        
		public static TableSchema.Table PnExpediente{
            get { return DataService.GetSchema("PN_expediente","sicProvider"); }
		}
        
		public static TableSchema.Table PnFactura{
            get { return DataService.GetSchema("PN_factura","sicProvider"); }
		}
        
		public static TableSchema.Table PnFamilium{
            get { return DataService.GetSchema("PN_familia","sicProvider"); }
		}
        
		public static TableSchema.Table PnFeriado{
            get { return DataService.GetSchema("PN_feriados","sicProvider"); }
		}
        
		public static TableSchema.Table PnGrupoPrestacion{
            get { return DataService.GetSchema("PN_grupo_prestacion","sicProvider"); }
		}
        
		public static TableSchema.Table PnGrupo{
            get { return DataService.GetSchema("PN_grupos","sicProvider"); }
		}
        
		public static TableSchema.Table PnGruposUsuario{
            get { return DataService.GetSchema("PN_grupos_usuarios","sicProvider"); }
		}
        
		public static TableSchema.Table PnHistoricotemp{
            get { return DataService.GetSchema("PN_historicotemp","sicProvider"); }
		}
        
		public static TableSchema.Table PnHorariosTrabajo{
            get { return DataService.GetSchema("PN_horarios_trabajo","sicProvider"); }
		}
        
		public static TableSchema.Table PnInasistencium{
            get { return DataService.GetSchema("PN_inasistencia","sicProvider"); }
		}
        
		public static TableSchema.Table PnInciso{
            get { return DataService.GetSchema("PN_inciso","sicProvider"); }
		}
        
		public static TableSchema.Table PnIncisoItemGasto{
            get { return DataService.GetSchema("PN_inciso_item_gasto","sicProvider"); }
		}
        
		public static TableSchema.Table PnIndicadoresGlobale{
            get { return DataService.GetSchema("PN_indicadores_globales","sicProvider"); }
		}
        
		public static TableSchema.Table PnIndicadoresIn{
            get { return DataService.GetSchema("PN_indicadores_ins","sicProvider"); }
		}
        
		public static TableSchema.Table PnIngreso{
            get { return DataService.GetSchema("PN_ingreso","sicProvider"); }
		}
        
		public static TableSchema.Table PnItemGasto{
            get { return DataService.GetSchema("PN_item_gasto","sicProvider"); }
		}
        
		public static TableSchema.Table PnLegajo{
            get { return DataService.GetSchema("PN_legajos","sicProvider"); }
		}
        
		public static TableSchema.Table PnLegajosExt{
            get { return DataService.GetSchema("PN_legajos_ext","sicProvider"); }
		}
        
		public static TableSchema.Table PnLengua{
            get { return DataService.GetSchema("PN_lenguas","sicProvider"); }
		}
        
		public static TableSchema.Table PnLocalidade{
            get { return DataService.GetSchema("PN_localidades","sicProvider"); }
		}
        
		public static TableSchema.Table PnLogComprobante{
            get { return DataService.GetSchema("PN_log_comprobante","sicProvider"); }
		}
        
		public static TableSchema.Table PnLogEvento{
            get { return DataService.GetSchema("PN_log_evento","sicProvider"); }
		}
        
		public static TableSchema.Table PnLogFactura{
            get { return DataService.GetSchema("PN_log_factura","sicProvider"); }
		}
        
		public static TableSchema.Table PnLogManual{
            get { return DataService.GetSchema("PN_log_manual","sicProvider"); }
		}
        
		public static TableSchema.Table PnLogPacPap{
            get { return DataService.GetSchema("PN_log_pac_pap","sicProvider"); }
		}
        
		public static TableSchema.Table PnLogPlanilla{
            get { return DataService.GetSchema("PN_log_planilla","sicProvider"); }
		}
        
		public static TableSchema.Table PnLogPrestacion{
            get { return DataService.GetSchema("PN_log_prestacion","sicProvider"); }
		}
        
		public static TableSchema.Table PnMailEfeConv{
            get { return DataService.GetSchema("PN_mail_efe_conv","sicProvider"); }
		}
        
		public static TableSchema.Table PnManual{
            get { return DataService.GetSchema("PN_manual","sicProvider"); }
		}
        
		public static TableSchema.Table PnMensaje{
            get { return DataService.GetSchema("PN_mensajes","sicProvider"); }
		}
        
		public static TableSchema.Table PnMotivoD{
            get { return DataService.GetSchema("PN_motivo_d","sicProvider"); }
		}
        
		public static TableSchema.Table PnMu{
            get { return DataService.GetSchema("PN_mu","sicProvider"); }
		}
        
		public static TableSchema.Table PnMunicipio{
            get { return DataService.GetSchema("PN_municipios","sicProvider"); }
		}
        
		public static TableSchema.Table PnNino{
            get { return DataService.GetSchema("PN_nino","sicProvider"); }
		}
        
		public static TableSchema.Table PnNinoNew{
            get { return DataService.GetSchema("PN_nino_new","sicProvider"); }
		}
        
		public static TableSchema.Table PnNoConformidad{
            get { return DataService.GetSchema("PN_no_conformidad","sicProvider"); }
		}
        
		public static TableSchema.Table PnNomenclador{
            get { return DataService.GetSchema("PN_nomenclador","sicProvider"); }
		}
        
		public static TableSchema.Table PnNomencladorDetalle{
            get { return DataService.GetSchema("PN_nomenclador_detalle","sicProvider"); }
		}
        
		public static TableSchema.Table PnNomencladorXPatologium{
            get { return DataService.GetSchema("PN_NomencladorXPatologia","sicProvider"); }
		}
        
		public static TableSchema.Table PnObrasSociale{
            get { return DataService.GetSchema("PN_obras_sociales","sicProvider"); }
		}
        
		public static TableSchema.Table PnOri{
            get { return DataService.GetSchema("PN_ori","sicProvider"); }
		}
        
		public static TableSchema.Table PnPacPap{
            get { return DataService.GetSchema("PN_pac_pap","sicProvider"); }
		}
        
		public static TableSchema.Table PnPai{
            get { return DataService.GetSchema("PN_pais","sicProvider"); }
		}
        
		public static TableSchema.Table PnParametro{
            get { return DataService.GetSchema("PN_parametros","sicProvider"); }
		}
        
		public static TableSchema.Table PnParto{
            get { return DataService.GetSchema("PN_partos","sicProvider"); }
		}
        
		public static TableSchema.Table PnPatologia{
            get { return DataService.GetSchema("PN_patologias","sicProvider"); }
		}
        
		public static TableSchema.Table PnPatologiasFrecuente{
            get { return DataService.GetSchema("PN_patologias_frecuentes","sicProvider"); }
		}
        
		public static TableSchema.Table PnPeriodo{
            get { return DataService.GetSchema("PN_periodo","sicProvider"); }
		}
        
		public static TableSchema.Table PnPermiso{
            get { return DataService.GetSchema("PN_permisos","sicProvider"); }
		}
        
		public static TableSchema.Table PnPermisosActuale{
            get { return DataService.GetSchema("PN_permisos_actuales","sicProvider"); }
		}
        
		public static TableSchema.Table PnPermisosGrupo{
            get { return DataService.GetSchema("PN_permisos_grupos","sicProvider"); }
		}
        
		public static TableSchema.Table PnPermisosSesion{
            get { return DataService.GetSchema("PN_permisos_sesion","sicProvider"); }
		}
        
		public static TableSchema.Table PnPermisosUsuario{
            get { return DataService.GetSchema("PN_permisos_usuarios","sicProvider"); }
		}
        
		public static TableSchema.Table PnPlanilla{
            get { return DataService.GetSchema("PN_planillas","sicProvider"); }
		}
        
		public static TableSchema.Table PnPrestacion{
            get { return DataService.GetSchema("PN_prestacion","sicProvider"); }
		}
        
		public static TableSchema.Table PnPrestacionesNOp{
            get { return DataService.GetSchema("PN_prestaciones_n_op","sicProvider"); }
		}
        
		public static TableSchema.Table PnPrestacionesNueva{
            get { return DataService.GetSchema("PN_PrestacionesNuevas","sicProvider"); }
		}
        
		public static TableSchema.Table PnPromocione{
            get { return DataService.GetSchema("PN_promociones","sicProvider"); }
		}
        
		public static TableSchema.Table PnProvincia{
            get { return DataService.GetSchema("PN_provincias","sicProvider"); }
		}
        
		public static TableSchema.Table PnPuco{
            get { return DataService.GetSchema("PN_puco","sicProvider"); }
		}
        
		public static TableSchema.Table PnRecibe{
            get { return DataService.GetSchema("PN_recibe","sicProvider"); }
		}
        
		public static TableSchema.Table PnRelNomencladorXDatoReportable{
            get { return DataService.GetSchema("PN_Rel_NomencladorXDatoReportable","sicProvider"); }
		}
        
		public static TableSchema.Table PnRelPrestacionXDatoReportable{
            get { return DataService.GetSchema("PN_Rel_PrestacionXDatoReportable","sicProvider"); }
		}
        
		public static TableSchema.Table PnRelPacienteAfiliado{
            get { return DataService.GetSchema("PN_RelPacienteAfiliado","sicProvider"); }
		}
        
		public static TableSchema.Table PnReporteHipoacustium{
            get { return DataService.GetSchema("PN_reporte_hipoacustia","sicProvider"); }
		}
        
		public static TableSchema.Table PnResponsable{
            get { return DataService.GetSchema("PN_responsables","sicProvider"); }
		}
        
		public static TableSchema.Table PnServicio{
            get { return DataService.GetSchema("PN_servicio","sicProvider"); }
		}
        
		public static TableSchema.Table PnSmiafiliado{
            get { return DataService.GetSchema("PN_smiafiliados","sicProvider"); }
		}
        
		public static TableSchema.Table PnSmiafiliadosaux{
            get { return DataService.GetSchema("PN_smiafiliadosaux","sicProvider"); }
		}
        
		public static TableSchema.Table PnSmiefectore{
            get { return DataService.GetSchema("PN_smiefectores","sicProvider"); }
		}
        
		public static TableSchema.Table PnSmiprocesoafiliado{
            get { return DataService.GetSchema("PN_smiprocesoafiliados","sicProvider"); }
		}
        
		public static TableSchema.Table PnSmitiposcategoria{
            get { return DataService.GetSchema("PN_smitiposcategorias","sicProvider"); }
		}
        
		public static TableSchema.Table PnSubirArchivo{
            get { return DataService.GetSchema("PN_subir_archivos","sicProvider"); }
		}
        
		public static TableSchema.Table PnSumariosPersonal{
            get { return DataService.GetSchema("PN_sumarios_personal","sicProvider"); }
		}
        
		public static TableSchema.Table PnSuspensione{
            get { return DataService.GetSchema("PN_suspensiones","sicProvider"); }
		}
        
		public static TableSchema.Table PnTareasDesemp{
            get { return DataService.GetSchema("PN_tareas_desemp","sicProvider"); }
		}
        
		public static TableSchema.Table PnTipoDeMensaje{
            get { return DataService.GetSchema("PN_tipo_de_mensaje","sicProvider"); }
		}
        
		public static TableSchema.Table PnTipoDocumento{
            get { return DataService.GetSchema("PN_tipo_documento","sicProvider"); }
		}
        
		public static TableSchema.Table PnTipoEvento{
            get { return DataService.GetSchema("PN_tipo_evento","sicProvider"); }
		}
        
		public static TableSchema.Table PnTipoPermiso{
            get { return DataService.GetSchema("PN_tipo_permiso","sicProvider"); }
		}
        
		public static TableSchema.Table PnTipoDePrestacion{
            get { return DataService.GetSchema("PN_TipoDePrestacion","sicProvider"); }
		}
        
		public static TableSchema.Table PnTransaccion{
            get { return DataService.GetSchema("PN_transaccion","sicProvider"); }
		}
        
		public static TableSchema.Table PnTransaccionCertificado{
            get { return DataService.GetSchema("PN_transaccion_certificado","sicProvider"); }
		}
        
		public static TableSchema.Table PnTribu{
            get { return DataService.GetSchema("PN_tribus","sicProvider"); }
		}
        
		public static TableSchema.Table PnTrzPre{
            get { return DataService.GetSchema("PN_trz_pres","sicProvider"); }
		}
        
		public static TableSchema.Table PnUadParametro{
            get { return DataService.GetSchema("PN_uad_parametros","sicProvider"); }
		}
        
		public static TableSchema.Table PnUsuario{
            get { return DataService.GetSchema("PN_usuarios","sicProvider"); }
		}
        
		public static TableSchema.Table PnVacApli{
            get { return DataService.GetSchema("PN_vac_apli","sicProvider"); }
		}
        
		public static TableSchema.Table PnVacuna{
            get { return DataService.GetSchema("PN_vacunas","sicProvider"); }
		}
        
		public static TableSchema.Table PnValidacionPrestacion{
            get { return DataService.GetSchema("PN_validacion_prestacion","sicProvider"); }
		}
        
		public static TableSchema.Table PnZonaSani{
            get { return DataService.GetSchema("PN_zona_sani","sicProvider"); }
		}
        
		public static TableSchema.Table PsmEFisico{
            get { return DataService.GetSchema("PSM_EFisico","sicProvider"); }
		}
        
		public static TableSchema.Table RemActividadFisica{
            get { return DataService.GetSchema("Rem_ActividadFisica","sicProvider"); }
		}
        
		public static TableSchema.Table RemAgente{
            get { return DataService.GetSchema("Rem_Agente","sicProvider"); }
		}
        
		public static TableSchema.Table RemClasificacion{
            get { return DataService.GetSchema("Rem_Clasificacion","sicProvider"); }
		}
        
		public static TableSchema.Table RemComplicacione{
            get { return DataService.GetSchema("Rem_Complicaciones","sicProvider"); }
		}
        
		public static TableSchema.Table RemEstudioOcular{
            get { return DataService.GetSchema("Rem_EstudioOcular","sicProvider"); }
		}
        
		public static TableSchema.Table RemExamenPie{
            get { return DataService.GetSchema("Rem_ExamenPie","sicProvider"); }
		}
        
		public static TableSchema.Table RemFormulario{
            get { return DataService.GetSchema("Rem_Formulario","sicProvider"); }
		}
        
		public static TableSchema.Table RemInternacion{
            get { return DataService.GetSchema("Rem_Internacion","sicProvider"); }
		}
        
		public static TableSchema.Table RemMedicamentoCronico{
            get { return DataService.GetSchema("Rem_MedicamentoCronico","sicProvider"); }
		}
        
		public static TableSchema.Table RemRelMedicamentoClasificacion{
            get { return DataService.GetSchema("Rem_RelMedicamentoClasificacion","sicProvider"); }
		}
        
		public static TableSchema.Table RemRelMedicamentoSeguimiento{
            get { return DataService.GetSchema("Rem_RelMedicamentoSeguimiento","sicProvider"); }
		}
        
		public static TableSchema.Table RemSeguimiento{
            get { return DataService.GetSchema("Rem_Seguimiento","sicProvider"); }
		}
        
		public static TableSchema.Table RemTablaExaman{
            get { return DataService.GetSchema("Rem_TablaExamen","sicProvider"); }
		}
        
		public static TableSchema.Table RemTipoCobertura{
            get { return DataService.GetSchema("Rem_TipoCobertura","sicProvider"); }
		}
        
		public static TableSchema.Table RisAreaTematica{
            get { return DataService.GetSchema("RIS_AreaTematica","sicProvider"); }
		}
        
		public static TableSchema.Table RisAseguradora{
            get { return DataService.GetSchema("RIS_Aseguradora","sicProvider"); }
		}
        
		public static TableSchema.Table RisCaracteristica{
            get { return DataService.GetSchema("RIS_Caracteristica","sicProvider"); }
		}
        
		public static TableSchema.Table RisComiteEtica{
            get { return DataService.GetSchema("RIS_ComiteEtica","sicProvider"); }
		}
        
		public static TableSchema.Table RisConcentimiento{
            get { return DataService.GetSchema("RIS_Concentimiento","sicProvider"); }
		}
        
		public static TableSchema.Table RisEnmienda{
            get { return DataService.GetSchema("RIS_Enmienda","sicProvider"); }
		}
        
		public static TableSchema.Table RisEnmiendaItemDesaprobado{
            get { return DataService.GetSchema("RIS_EnmiendaItemDesaprobado","sicProvider"); }
		}
        
		public static TableSchema.Table RisEntidad{
            get { return DataService.GetSchema("RIS_Entidad","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudio{
            get { return DataService.GetSchema("RIS_Estudio","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioAseguradora{
            get { return DataService.GetSchema("RIS_EstudioAseguradora","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioCaracteristica{
            get { return DataService.GetSchema("RIS_EstudioCaracteristica","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioComiteEtica{
            get { return DataService.GetSchema("RIS_EstudioComiteEtica","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioEntidad{
            get { return DataService.GetSchema("RIS_EstudioEntidad","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioFuenteRecoleccionDato{
            get { return DataService.GetSchema("RIS_EstudioFuenteRecoleccionDatos","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioInvestigador{
            get { return DataService.GetSchema("RIS_EstudioInvestigador","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioItemAprobado{
            get { return DataService.GetSchema("RIS_EstudioItemAprobado","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioItemDesaprobado{
            get { return DataService.GetSchema("RIS_EstudioItemDesaprobado","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioPoblacionVulnerable{
            get { return DataService.GetSchema("RIS_EstudioPoblacionVulnerable","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioSysEfectorMulticentrico{
            get { return DataService.GetSchema("RIS_EstudioSysEfectorMulticentrico","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioSysPaisMulticentrico{
            get { return DataService.GetSchema("RIS_EstudioSysPaisMulticentrico","sicProvider"); }
		}
        
		public static TableSchema.Table RisEstudioSysProvinciaMulticentrico{
            get { return DataService.GetSchema("RIS_EstudioSysProvinciaMulticentrico","sicProvider"); }
		}
        
		public static TableSchema.Table RisEvaluacionRechazada{
            get { return DataService.GetSchema("RIS_EvaluacionRechazada","sicProvider"); }
		}
        
		public static TableSchema.Table RisFuenteRecoleccionDato{
            get { return DataService.GetSchema("RIS_FuenteRecoleccionDatos","sicProvider"); }
		}
        
		public static TableSchema.Table RisFuncionEnElEquipo{
            get { return DataService.GetSchema("RIS_FuncionEnElEquipo","sicProvider"); }
		}
        
		public static TableSchema.Table RisInvestigadore{
            get { return DataService.GetSchema("RIS_Investigadores","sicProvider"); }
		}
        
		public static TableSchema.Table RisItemAprobado{
            get { return DataService.GetSchema("RIS_ItemAprobado","sicProvider"); }
		}
        
		public static TableSchema.Table RisItemDesaprobado{
            get { return DataService.GetSchema("RIS_ItemDesaprobado","sicProvider"); }
		}
        
		public static TableSchema.Table RisLugarRealizacion{
            get { return DataService.GetSchema("RIS_LugarRealizacion","sicProvider"); }
		}
        
		public static TableSchema.Table RisNotum{
            get { return DataService.GetSchema("RIS_Nota","sicProvider"); }
		}
        
		public static TableSchema.Table RisPoblacionVulnerable{
            get { return DataService.GetSchema("RIS_PoblacionVulnerable","sicProvider"); }
		}
        
		public static TableSchema.Table RisPresentacionInforme{
            get { return DataService.GetSchema("RIS_PresentacionInforme","sicProvider"); }
		}
        
		public static TableSchema.Table RisProfesion{
            get { return DataService.GetSchema("RIS_Profesion","sicProvider"); }
		}
        
		public static TableSchema.Table RisTipoDocumento{
            get { return DataService.GetSchema("RIS_TipoDocumento","sicProvider"); }
		}
        
		public static TableSchema.Table RisTipoTelefono{
            get { return DataService.GetSchema("RIS_TipoTelefono","sicProvider"); }
		}
        
		public static TableSchema.Table RisVigenciaPoliza{
            get { return DataService.GetSchema("RIS_VigenciaPoliza","sicProvider"); }
		}
        
		public static TableSchema.Table SysAntecedente{
            get { return DataService.GetSchema("Sys_Antecedente","sicProvider"); }
		}
        
		public static TableSchema.Table SysAntecedenteEnfermedad{
            get { return DataService.GetSchema("Sys_AntecedenteEnfermedad","sicProvider"); }
		}
        
		public static TableSchema.Table SysBarrio{
            get { return DataService.GetSchema("Sys_Barrio","sicProvider"); }
		}
        
		public static TableSchema.Table SysCepSap{
            get { return DataService.GetSchema("Sys_CepSap","sicProvider"); }
		}
        
		public static TableSchema.Table SysCIE10{
            get { return DataService.GetSchema("Sys_CIE10","sicProvider"); }
		}
        
		public static TableSchema.Table SysCIE10Capitulo{
            get { return DataService.GetSchema("Sys_CIE10Capitulo","sicProvider"); }
		}
        
		public static TableSchema.Table SysDefuncion{
            get { return DataService.GetSchema("sys_Defuncion","sicProvider"); }
		}
        
		public static TableSchema.Table SysDepartamento{
            get { return DataService.GetSchema("Sys_Departamento","sicProvider"); }
		}
        
		public static TableSchema.Table SysDireccione{
            get { return DataService.GetSchema("Sys_Direcciones","sicProvider"); }
		}
        
		public static TableSchema.Table SysEfector{
            get { return DataService.GetSchema("Sys_Efector","sicProvider"); }
		}
        
		public static TableSchema.Table SysEspecialidad{
            get { return DataService.GetSchema("Sys_Especialidad","sicProvider"); }
		}
        
		public static TableSchema.Table SysEspecialidad2{
            get { return DataService.GetSchema("Sys_Especialidad2","sicProvider"); }
		}
        
		public static TableSchema.Table SysEstablecimiento{
            get { return DataService.GetSchema("sys_Establecimiento","sicProvider"); }
		}
        
		public static TableSchema.Table SysEstado{
            get { return DataService.GetSchema("Sys_Estado","sicProvider"); }
		}
        
		public static TableSchema.Table SysEstadoCivil{
            get { return DataService.GetSchema("Sys_EstadoCivil","sicProvider"); }
		}
        
		public static TableSchema.Table SysHistoriaClinica{
            get { return DataService.GetSchema("Sys_HistoriaClinica","sicProvider"); }
		}
        
		public static TableSchema.Table SysIdioma{
            get { return DataService.GetSchema("Sys_Idioma","sicProvider"); }
		}
        
		public static TableSchema.Table SysLocalidad{
            get { return DataService.GetSchema("Sys_Localidad","sicProvider"); }
		}
        
		public static TableSchema.Table SysMedicamento{
            get { return DataService.GetSchema("Sys_Medicamento","sicProvider"); }
		}
        
		public static TableSchema.Table SysMedicamentoRubro{
            get { return DataService.GetSchema("Sys_MedicamentoRubro","sicProvider"); }
		}
        
		public static TableSchema.Table SysMenu{
            get { return DataService.GetSchema("Sys_Menu","sicProvider"); }
		}
        
		public static TableSchema.Table SysModulo{
            get { return DataService.GetSchema("Sys_Modulo","sicProvider"); }
		}
        
		public static TableSchema.Table SysMotivoNI{
            get { return DataService.GetSchema("Sys_MotivoNI","sicProvider"); }
		}
        
		public static TableSchema.Table SysMovimientoHistoriaClinica{
            get { return DataService.GetSchema("Sys_MovimientoHistoriaClinica","sicProvider"); }
		}
        
		public static TableSchema.Table SysMunicipio{
            get { return DataService.GetSchema("Sys_Municipio","sicProvider"); }
		}
        
		public static TableSchema.Table SysNivelInstruccion{
            get { return DataService.GetSchema("Sys_NivelInstruccion","sicProvider"); }
		}
        
		public static TableSchema.Table SysObraSocial{
            get { return DataService.GetSchema("Sys_ObraSocial","sicProvider"); }
		}
        
		public static TableSchema.Table SysOcupacion{
            get { return DataService.GetSchema("Sys_Ocupacion","sicProvider"); }
		}
        
		public static TableSchema.Table SysOrganismo{
            get { return DataService.GetSchema("Sys_Organismo","sicProvider"); }
		}
        
		public static TableSchema.Table SysPaciente{
            get { return DataService.GetSchema("Sys_Paciente","sicProvider"); }
		}
        
		public static TableSchema.Table SysPacienteAntecedentesFamiliare{
            get { return DataService.GetSchema("Sys_PacienteAntecedentesFamiliares","sicProvider"); }
		}
        
		public static TableSchema.Table SysPacienteCeliaco{
            get { return DataService.GetSchema("Sys_PacienteCeliaco","sicProvider"); }
		}
        
		public static TableSchema.Table SysPai{
            get { return DataService.GetSchema("Sys_Pais","sicProvider"); }
		}
        
		public static TableSchema.Table SysParentesco{
            get { return DataService.GetSchema("Sys_Parentesco","sicProvider"); }
		}
        
		public static TableSchema.Table SysParentescoTipo{
            get { return DataService.GetSchema("Sys_ParentescoTipo","sicProvider"); }
		}
        
		public static TableSchema.Table SysPerfil{
            get { return DataService.GetSchema("Sys_Perfil","sicProvider"); }
		}
        
		public static TableSchema.Table SysPermiso{
            get { return DataService.GetSchema("Sys_Permiso","sicProvider"); }
		}
        
		public static TableSchema.Table SysPoblacion{
            get { return DataService.GetSchema("Sys_Poblacion","sicProvider"); }
		}
        
		public static TableSchema.Table SysPoblacion1{
            get { return DataService.GetSchema("Sys_Poblacion1","sicProvider"); }
		}
        
		public static TableSchema.Table SysProfesion{
            get { return DataService.GetSchema("Sys_Profesion","sicProvider"); }
		}
        
		public static TableSchema.Table SysProfesional{
            get { return DataService.GetSchema("Sys_Profesional","sicProvider"); }
		}
        
		public static TableSchema.Table SysProvincium{
            get { return DataService.GetSchema("Sys_Provincia","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelAntecedentePaciente{
            get { return DataService.GetSchema("Sys_RelAntecedentePaciente","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelEspecialidadEfector{
            get { return DataService.GetSchema("Sys_RelEspecialidadEfector","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelEstadoMotivoNI{
            get { return DataService.GetSchema("Sys_RelEstadoMotivoNI","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelFormularioCobertura{
            get { return DataService.GetSchema("Sys_RelFormularioCobertura","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelHistoriaClinicaEfector{
            get { return DataService.GetSchema("Sys_RelHistoriaClinicaEfector","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelPacienteObraSocial{
            get { return DataService.GetSchema("Sys_RelPacienteObraSocial","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelProfesionalEfector{
            get { return DataService.GetSchema("Sys_RelProfesionalEfector","sicProvider"); }
		}
        
		public static TableSchema.Table SysRelServicioEfector{
            get { return DataService.GetSchema("Sys_RelServicioEfector","sicProvider"); }
		}
        
		public static TableSchema.Table SysServicio{
            get { return DataService.GetSchema("Sys_Servicio","sicProvider"); }
		}
        
		public static TableSchema.Table SysSexo{
            get { return DataService.GetSchema("Sys_Sexo","sicProvider"); }
		}
        
		public static TableSchema.Table SysSituacionLaboral{
            get { return DataService.GetSchema("Sys_SituacionLaboral","sicProvider"); }
		}
        
		public static TableSchema.Table SysTipoAntecedente{
            get { return DataService.GetSchema("Sys_TipoAntecedente","sicProvider"); }
		}
        
		public static TableSchema.Table SysTipoCobertura{
            get { return DataService.GetSchema("Sys_TipoCobertura","sicProvider"); }
		}
        
		public static TableSchema.Table SysTipoDocumento{
            get { return DataService.GetSchema("Sys_TipoDocumento","sicProvider"); }
		}
        
		public static TableSchema.Table SysTipoEfector{
            get { return DataService.GetSchema("Sys_TipoEfector","sicProvider"); }
		}
        
		public static TableSchema.Table SysTipoObraSocial{
            get { return DataService.GetSchema("Sys_TipoObraSocial","sicProvider"); }
		}
        
		public static TableSchema.Table SysTipoProfesional{
            get { return DataService.GetSchema("Sys_TipoProfesional","sicProvider"); }
		}
        
		public static TableSchema.Table SysUsuario{
            get { return DataService.GetSchema("Sys_Usuario","sicProvider"); }
		}
        
		public static TableSchema.Table SysZona{
            get { return DataService.GetSchema("Sys_Zona","sicProvider"); }
		}
        
		public static TableSchema.Table TabControl{
            get { return DataService.GetSchema("TAB_Control","sicProvider"); }
		}
        
		public static TableSchema.Table TamDiagnostico{
            get { return DataService.GetSchema("TAM_Diagnostico","sicProvider"); }
		}
        
		public static TableSchema.Table TamHallazgosColposcopico{
            get { return DataService.GetSchema("TAM_HallazgosColposcopicos","sicProvider"); }
		}
        
		public static TableSchema.Table TamMetodoAnticonceptivo{
            get { return DataService.GetSchema("TAM_MetodoAnticonceptivo","sicProvider"); }
		}
        
		public static TableSchema.Table TupEfectoresHabilitado{
            get { return DataService.GetSchema("TUP_EfectoresHabilitados","sicProvider"); }
		}
        
		public static TableSchema.Table TupTurnosProtegido{
            get { return DataService.GetSchema("TUP_TurnosProtegidos","sicProvider"); }
		}
        
		public static TableSchema.Table VgiAClinicosDet{
            get { return DataService.GetSchema("VGI_AClinicosDet","sicProvider"); }
		}
        
		public static TableSchema.Table VgiCInterconsultaItem{
            get { return DataService.GetSchema("VGI_CInterconsultaItems","sicProvider"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static string AprGetUltimoControl = @"APR_GetUltimoControl";
        
		public static string AprVwCondicionesVivienda = @"APR_VwCondicionesVivienda";
        
		public static string AprVwOtrosDato = @"APR_VwOtrosDatos";
        
		public static string AutFechaMaximaHistoricoPMP = @"AUT_FechaMaximaHistoricoPMP";
        
		public static string ConCantidadSobreTurno = @"CON_CantidadSobreTurnos";
        
		public static string ConCantidadTipoTurnosEspecialidad = @"CON_CantidadTipoTurnosEspecialidad";
        
		public static string ConCantidadTurnosAusente = @"CON_CantidadTurnosAusentes";
        
		public static string ConCantidadTurnosBloqueado = @"CON_CantidadTurnosBloqueados";
        
		public static string ConCantidadTurnosCodificado = @"CON_CantidadTurnosCodificados";
        
		public static string ConCantidadTurnosDado = @"CON_CantidadTurnosDados";
        
		public static string ConCantidadTurnosDadosAnticipado = @"CON_CantidadTurnosDadosAnticipados";
        
		public static string ConCantidadTurnosDadosDium = @"CON_CantidadTurnosDadosDia";
        
		public static string ConCantidadTurnosEspecialidad = @"CON_CantidadTurnosEspecialidad";
        
		public static string ConCantidadTurnosGenerado = @"CON_CantidadTurnosGenerados";
        
		public static string ConCantidadTurnosPresente = @"CON_CantidadTurnosPresentes";
        
		public static string ConCantidadTurnosPrestacion = @"CON_CantidadTurnosPrestacion";
        
		public static string ConDiagPrincipalTurno = @"CON_DiagPrincipalTurnos";
        
		public static string ConLauraPacientesNutricion2012 = @"CON_laura_pacientesNutricion2012";
        
		public static string ConLauraPacientesNutricion2013 = @"CON_laura_pacientesNutricion2013";
        
		public static string ConLauraTurnosDadosAnticipadosMedicinaGeneral = @"CON_laura_turnosDadosAnticipadosMedicinaGeneral";
        
		public static string ConLauraTurnosGeneradosClinicaMedica = @"CON_laura_turnosGeneradosClinicaMedica";
        
		public static string ConSobreTurno = @"CON_SobreTurnos";
        
		public static string ConTurnoGrupoEtareo = @"Con_TurnoGrupoEtareo";
        
		public static string ConTurnoGrupoEtareoC2 = @"CON_TurnoGrupoEtareoC2";
        
		public static string ConTurnosAnticipadosAusente = @"CON_TurnosAnticipadosAusentes";
        
		public static string ConTurnosCantidadDemandaRechazada = @"CON_TurnosCantidadDemandaRechazada";
        
		public static string ConTurnosDelDiaConAsistencium = @"CON_TurnosDelDiaConAsistencia";
        
		public static string ConTurnosDelDiaSinAsistencium = @"CON_TurnosDelDiaSinAsistencia";
        
		public static string ConTurnosProgramadosConAsistencium = @"CON_TurnosProgramadosConAsistencia";
        
		public static string ConTurnosProgramadosSinAsistencium = @"CON_TurnosProgramadosSinAsistencia";
        
		public static string ConVistaAgenda = @"CON_VistaAgendas";
        
		public static string ConVwConsulta = @"CON_VwConsultas";
        
		public static string ConsultaInterconsulta = @"ConsultaInterconsultas";
        
		public static string FacPacientesConObraSocial = @"FAC_PacientesConObraSocial";
        
		public static string GuardiaGrupoEtareoC2 = @"GUARDIA_GrupoEtareoC2";
        
		public static string GuardiaUltimoTriage = @"Guardia_Ultimo_Triage";
        
		public static string LabConsultasxAño = @"LAB_ConsultasxAño";
        
		public static string LabImprimeResultado = @"LAB_ImprimeResultado";
        
		public static string PnCantidadEmb = @"PN_CantidadEmb";
        
		public static string PnCantidadNin = @"PN_CantidadNin";
        
		public static string PnCantidadOrdenesAfiliado = @"PN_CantidadOrdenesAfiliados";
        
		public static string PnCantidadPar = @"PN_CantidadPar";
        
		public static string PnCantidadTrazadorasAfiliado = @"PN_CantidadTrazadorasAfiliados";
        
		public static string PnListaOrdene = @"PN_ListaOrdenes";
        
		public static string RemClasificado = @"REM_Clasificados";
        
		public static string SysPerfilEfector = @"SYS_PerfilEfector";
        
		public static string VwAspnetApplication = @"vw_aspnet_Applications";
        
		public static string VwAspnetMembershipUser = @"vw_aspnet_MembershipUsers";
        
		public static string VwAspnetProfile = @"vw_aspnet_Profiles";
        
		public static string VwAspnetRole = @"vw_aspnet_Roles";
        
		public static string VwAspnetUser = @"vw_aspnet_Users";
        
		public static string VwAspnetUsersInRole = @"vw_aspnet_UsersInRoles";
        
		public static string VwAspnetWebPartStatePath = @"vw_aspnet_WebPartState_Paths";
        
		public static string VwAspnetWebPartStateShared = @"vw_aspnet_WebPartState_Shared";
        
		public static string VwAspnetWebPartStateUser = @"vw_aspnet_WebPartState_User";
        
		public static string VwLabScreeningHojaTrabajo = @"vw_LAB_ScreeningHojaTrabajo";
        
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["sicProvider"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository {
            get {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
	
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
            
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
     
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static string sicProvider = @"sicProvider";
    
}
#endregion