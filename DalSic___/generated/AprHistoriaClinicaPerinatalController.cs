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
    /// <summary>
    /// Controller class for APR_HistoriaClinicaPerinatal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprHistoriaClinicaPerinatalController
    {
        // Preload our schema..
        AprHistoriaClinicaPerinatal thisSchemaLoad = new AprHistoriaClinicaPerinatal();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public AprHistoriaClinicaPerinatalCollection FetchAll()
        {
            AprHistoriaClinicaPerinatalCollection coll = new AprHistoriaClinicaPerinatalCollection();
            Query qry = new Query(AprHistoriaClinicaPerinatal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprHistoriaClinicaPerinatalCollection FetchByID(object IdHistoriaClinicaPerinatal)
        {
            AprHistoriaClinicaPerinatalCollection coll = new AprHistoriaClinicaPerinatalCollection().Where("idHistoriaClinicaPerinatal", IdHistoriaClinicaPerinatal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprHistoriaClinicaPerinatalCollection FetchByQuery(Query qry)
        {
            AprHistoriaClinicaPerinatalCollection coll = new AprHistoriaClinicaPerinatalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdHistoriaClinicaPerinatal)
        {
            return (AprHistoriaClinicaPerinatal.Delete(IdHistoriaClinicaPerinatal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdHistoriaClinicaPerinatal)
        {
            return (AprHistoriaClinicaPerinatal.Destroy(IdHistoriaClinicaPerinatal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,string Nombre,string Apellido,string Domicilio,string Dni,string Localidad,string Telefono,DateTime? FechaNacimiento,int? Edad,string DatosDeContacto,bool? EdadMenor15Mayor35,bool? EtniaBlanca,bool? EtniaIndigena,bool? EtniaMestiza,bool? EtniaNegra,bool? EtniaOtra,bool? AlfabetaSi,bool? AlfabetaNo,bool? EstudiosNinguno,bool? EstudiosPrimario,bool? EstudiosSecundario,bool? EstudiosUniversitario,int? AñosMayorNivel,bool? EstadoCivilCasada,bool? EstadoCivilUnionEstable,bool? EstadoCivilSoltera,bool? EstadoCivilOtro,bool? ViveSolaSi,bool? ViveSolaNo,string LugarControlPerinatal,string LugarPartoAborto,bool? AntFamTBCSi,bool? AntFamTBCNo,bool? AntFamDiabetesSi,bool? AntFamDiabetesNo,bool? AntFamHipertensionSi,bool? AntFamHipertensionNo,bool? AntFamInfeccionUrinariaSi,bool? AntFamInfeccionUrinariaNo,bool? AntFamOtrasInfeccionesSi,bool? AntFamOtrasInfeccionesNo,bool? AntFamOtroSi,bool? AntFamOtroNo,bool? AntPerTBCSi,bool? AntPerTBCNo,bool? AntPerDiabetesI,bool? AntPerDiabetesII,bool? AntPerDiabetesG,bool? AntPerDiabetesNo,bool? AntPerHipertensionSi,bool? AntPerHipertensionNo,bool? AntPerInfeccionUrinariaSi,bool? AntPerInfeccionUrinariaNo,bool? AntPerOtrasInfeccionesSi,bool? AntPerOtrasInfeccionesNo,bool? AntPerOtroSi,bool? AntPerOtroNo,bool? AntPerInfertilidadSi,bool? AntPerInfertilidadNo,bool? AntPerCardiopatiaSi,bool? AntPerCardiopatiaNo,bool? AntPerNefropatiaSi,bool? AntPerNefropatiaNo,bool? AntPerViolenciaSi,bool? AntPerViolenciaNo,bool? AntPerAlergiaMedicamentoSi,bool? AntPerAlergiaMedicamentoNo,string AntecedentesObservacion,int? GestasPrevias,int? Abortos,int? EmbEctopicos,bool? Abortos3concecutivos,int? Partos,int? PartosVaginales,int? Cesareas,int? NacidosVivos,int? NacidosMuertos,int? Viven,int? MuertosPrimerSemana,int? MuertosDespuesPrimerSemana,bool? AntecedentesGemelaresSi,bool? AntecedentesGemelaresNo,bool? UltPrevioNC,bool? UltPrevioNormal,bool? UltPrevioMenor2500,bool? UltPrevioMayor4000,DateTime? FinEmbarazoAnterior,bool? FinEmbAnteriorMenor1Año,bool? EmbarazoPlaneadoSi,bool? EmbarazoPlaneadoNo,bool? FracMetAnticonceptivoNoUsaba,bool? FracMetAnticonceptivoBarrera,bool? FracMetAnticonceptivoDIU,bool? FracMetAnticonceptivoHormonal,bool? FracMetAnticonceptivoEmergencia,bool? FracMetAnticonceptivoNatural,decimal? PesoAnterior,int? Talla,DateTime? Fum,DateTime? Fpp,bool? EGConfiableFUMSi,bool? EGConfiableFUMNo,bool? EGConfiableEcoMenor20semanasSi,bool? EGConfiableEcoMenor20semanasNo,bool? FumaActivo1TrimSi,bool? FumaActivo1TrimNo,bool? FumaActivo2TrimSi,bool? FumaActivo2TrimNo,bool? FumaActivo3TrimSi,bool? FumaActivo3TrimNo,bool? FumaPasivo1TrimSi,bool? FumaPasivo1TrimNo,bool? FumaPasivo2TrimSi,bool? FumaPasivo2TrimNo,bool? FumaPasivo3TrimSi,bool? FumaPasivo3TrimNo,bool? Drogas1TrimSi,bool? Drogas1TrimNo,bool? Drogas2TrimSi,bool? Drogas2TrimNo,bool? Drogas3TrimSi,bool? Drogas3TrimNo,bool? Alcohol1TrimSi,bool? Alcohol1TrimNo,bool? Alcohol2TrimSi,bool? Alcohol2TrimNo,bool? Alcohol3TrimSi,bool? Alcohol3TrimNo,bool? Violencia1TrimSi,bool? Violencia1TrimNo,bool? Violencia2TrimSi,bool? Violencia2TrimNo,bool? Violencia3TrimSi,bool? Violencia3TrimNo,bool? AntirubeolaPrevia,bool? AntirubeolaNoSabe,bool? AntirubeolaEmbarazo,bool? AntirubeolaNo,bool? AntitetanicaVigenteNo,bool? AntitetanicaVigenteSi,int? Antitetanica1DosisMesGestacion,int? Antitetanica2DosisMesGestacion,bool? ExamenOdotologicoNormalSi,bool? ExamenOdotologicoNormalNo,bool? ExamenMamasNormalSi,bool? ExamenMamasNormalNo,bool? CervixInspeccionVisualNormal,bool? CervixInspeccionVisualAnormal,bool? CervixInspeccionVisualNoSeHizo,bool? CervixPAPNormal,bool? CervixPAPAnormal,bool? CervixPAPNoSeHizo,bool? CervixCOLPNormal,bool? CervixCOLPAnormal,bool? CervixCOLPNoSeHizo,string Grupo,bool? RHPositivo,bool? RHNegativo,bool? InmunizacionSi,bool? InmunizacionNo,bool? GammaGlobulinaNo,bool? GammaGlobulinaSi,bool? GammaGlobulinaNoCorresponde,bool? ToxoPlasmosisMenor20SemLGGNegativo,bool? ToxoPlasmosisMenor20SemLGGPositivo,bool? ToxoPlasmosisMenor20SemLGGNoSeHizo,bool? ToxoPlasmosisMayor20SemLGGNegativo,bool? ToxoPlasmosisMayor20SemLGGPositivo,bool? ToxoPlasmosisMayor20SemLGGNoSeHizo,bool? ToxoPlasmosis1ConsultaLGMNegativo,bool? ToxoPlasmosis1ConsultaLGMPositivo,bool? ToxoPlasmosis1ConsultaLGMNoSeHizo,bool? ChagasNegativo,bool? ChagasPositivo,bool? ChagasNoSeHizo,bool? HepatitisBNegativo,bool? HepatitisBPositivo,bool? HepatitisBNoSeHizo,bool? BacteriuraMenor20SemNormal,bool? BacteriuraMenor20SemAnormal,bool? BacteriuraMenor20SemNoSeHizo,bool? BacteriuraMayor20SemNormal,bool? BacteriuraMayor20SemAnormal,bool? BacteriuraMayor20SemNoSeHizo,decimal? GlucemiaMenor20Sem,bool? GlucemiaMenor20SemMayor105,decimal? GlucemiaMayor20Sem,bool? GlucemiaMayor20SemMayor105,bool? VIHCRSi,bool? VIHCRNo,bool? VIHPrimerMuestraSolicitadoSi,bool? VIHPrimerMuestraSolicitadoNo,bool? VIHPrimerMuestraRealizadoSi,bool? VIHPrimerMuestraRealizadoNo,DateTime? VIHPrimerMuestraFecha,decimal? HBMenor20Sem,bool? HBMenor20SemMenor11,decimal? HBMayor20Sem,bool? HBMayor20SemMenor11,bool? FeIndicadoSi,bool? FeIndicadoNo,bool? FolatosIndicadosSi,bool? FolatosIndicadosNo,bool? EstreptococoB3537SemanasNegativo,bool? EstreptococoB3537SemanasPositivo,bool? EstreptococoB3537SemanasNoSeHizo,bool? PreparacionPartoSi,bool? PreparacionPartoNo,bool? ConsejeriaLactanciaMaternaSi,bool? ConsejeriaLactanciaMaternaNo,bool? SifilisTratParejaMenor20SemNo,bool? SifilisTratParejaMenor20SemSi,bool? SifilisTratParejaMenor20SemSinDatos,bool? SifilisTratParejaMenor20SemNoCorresponde,bool? SifilisTratParejaMayor20SemNo,bool? SifilisTratParejaMayor20SemSi,bool? SifilisTratParejaMayor20SemSinDatos,bool? SifilisTratParejaMayor20SemNoCorresponde,bool? OAAntecedenteEclampsiaSi,bool? OAAntecedenteEclampsiaNo,bool? OAActualEclampsiaSi,bool? OAActualEclampsiaNo,bool? OAAntecedentePreeclampsiaSi,bool? OAAntecedentePreeclampsiaNo,bool? OAActualPreeclampsiaSi,bool? OAActualPreeclampsiaNo,bool? OAAntecedenteCirugiaGinUrinarSi,bool? OAAntecedenteCirugiaGinUrinarNo,bool? OAActualCirugiaGinUrinarSi,bool? OAActualCirugiaGinUrinarNo,bool? OAAntecedenteAPPrematuroSi,bool? OAAntecedenteAPPrematuroNo,bool? OAActualAPPrematuroSi,bool? OAActualAPPrematuroNo,bool? OAAntecedenteRCIUSi,bool? OAAntecedenteRCIUNo,bool? OAActualRCIUSi,bool? OAActualRCIUNo,bool? OAAntecedenteHemorragiaObstetricaSi,bool? OAAntecedenteHemorragiaObstetricaNo,bool? OAActualHemorragiaObstetricaSi,bool? OAActualHemorragiaObstetricaNo,bool? OAAntecedenteMacrosomiaFetalSi,bool? OAAntecedenteMacrosomiaFetalNo,bool? OAActualMacrosomiaFetalSi,bool? OAActualMacrosomiaFetalNo,bool? OAAntecedentePolihidramniosSi,bool? OAAntecedentePolihidramniosNo,bool? OAActualPolihidramniosSi,bool? OAActualPolihidramniosNo,bool? OAAntecedenteOligoanmiosSi,bool? OAAntecedenteOligoanmiosNo,bool? OAActualOligoanmiosSi,bool? OAActualOligoanmiosNo,bool? OAAntecedenteRotPremMembranasSi,bool? OAAntecedenteRotPremMembranasNo,bool? OAActualRotPremMembranasSi,bool? OAActualRotPremMembranasNo,bool? OAAntecedenteIsoinmunizacionesSi,bool? OAAntecedenteIsoinmunizacionesNo,bool? OAActualIsoinmunizacionesSi,bool? OAActualIsoinmunizacionesNo,bool? OAAntecedenteColestasisSi,bool? OAAntecedenteColestasisNo,bool? OAActualColestasisSi,bool? OAActualColestasisNo,bool? OAAntecedenteMortPerinatalRecurrenteSi,bool? OAAntecedenteMortPerinatalRecurrenteNo,bool? OAAntecedenteRetencionPlacentaSi,bool? OAAntecedenteRetencionPlacentaNo,bool? OAAntecedenteDistociaHombrosSi,bool? OAAntecedenteDistociaHombrosNo,bool? OAAntecedenteMalformCongenSi,bool? OAAntecedenteMalformCongenNo,bool? FactorRiesgoEmbarazoSinContSocialSi,bool? FactorRiesgoEmbarazoSinContSocialNo,bool? FactorRiesgoFamiliaSinIngresosFijosSi,bool? FactorRiesgoFamiliaSinIngresosFijosNo,bool? FactorRiesgoEmbarazoFuertRechazadoSi,bool? FactorRiesgoEmbarazoFuertRechazadoNo,bool? FactorRiesgoHijosDadosAdopcionSi,bool? FactorRiesgoHijosDadosAdopcionNo,bool? FactorRiesgoViviendaSinServiciosBasicosSi,bool? FactorRiesgoViviendaSinServiciosBasicosNo,bool? CaptacionOportunaAntes16sem,bool? CaptacionOportunaDespues16sem,DateTime? FechaMuestraPAP,DateTime? FechaTripleAcelular,DateTime? FechaAntigripal,bool? VIHSegundaMuestraSolicitadoSi,bool? VIHSegundaMuestraSolicitadoNo,bool? VIHSegundaMuestraRealizadoSi,bool? VIHSegundaMuestraRealizadoNo,DateTime? VIHSegundaMuestraFecha,bool? VIHTercerMuestraSolicitadoSi,bool? VIHTercerMuestraSolicitadoNo,bool? VIHTercerMuestraRealizadoSi,bool? VIHTercerMuestraRealizadoNo,DateTime? VIHTercerMuestraFecha,decimal? SifilisPruebaNoTrepoPrimerMuestra,bool? SifilisPruebaNoTrepoPrimerMuestraNegativo,bool? SifilisPruebaNoTrepoPrimerMuestraPositivo,bool? SifilisPruebaNoTrepoPrimerMuestraSinDatos,DateTime? SifilisPruebaNoTrepoPrimerMuestraFecha,decimal? SifilisPruebaNoTrepoSegundaMuestra,bool? SifilisPruebaNoTrepoSegundaMuestraNegativo,bool? SifilisPruebaNoTrepoSegundaMuestraPositivo,bool? SifilisPruebaNoTrepoSegundaMuestraSinDatos,DateTime? SifilisPruebaNoTrepoSegundaMuestraFecha,decimal? SifilisPruebaNoTrepoTercerMuestra,bool? SifilisPruebaNoTrepoTercerMuestraNegativo,bool? SifilisPruebaNoTrepoTercerMuestraPositivo,bool? SifilisPruebaNoTrepoTercerMuestraSinDatos,DateTime? SifilisPruebaNoTrepoTercerMuestraFecha,decimal? SifilisPruebaTrepoPrimerMuestra,bool? SifilisPruebaTrepoPrimerMuestraNegativo,bool? SifilisPruebaTrepoPrimerMuestraPositivo,bool? SifilisPruebaTrepoPrimerMuestraSinDatos,bool? SifilisPruebaTrepoPrimerMuestraNoCorresponde,DateTime? SifilisPruebaTrepoPrimerMuestraFecha,decimal? SifilisPruebaTrepoSegundaMuestra,bool? SifilisPruebaTrepoSegundaMuestraNegativo,bool? SifilisPruebaTrepoSegundaMuestraPositivo,bool? SifilisPruebaTrepoSegundaMuestraSinDatos,bool? SifilisPruebaTrepoSegundaMuestraNoCorresponde,DateTime? SifilisPruebaTrepoSegundaMuestraFecha,decimal? SifilisPruebaTrepoTercerMuestra,bool? SifilisPruebaTrepoTercerMuestraNegativo,bool? SifilisPruebaTrepoTercerMuestraPositivo,bool? SifilisPruebaTrepoTercerMuestraSinDatos,bool? SifilisPruebaTrepoTercerMuestraNoCorresponde,DateTime? SifilisPruebaTrepoTercerMuestraFecha,decimal? SifilisTratamientoPrimerMuestra,bool? SifilisTratamientoPrimerMuestraNo,bool? SifilisTratamientoPrimerMuestraSi,bool? SifilisTratamientoPrimerMuestraSinDatos,bool? SifilisTratamientoPrimerMuestraNoCorresponde,DateTime? SifilisTratamientoPrimerMuestraFecha,decimal? SifilisTratamientoSegundaMuestra,bool? SifilisTratamientoSegundaMuestraNo,bool? SifilisTratamientoSegundaMuestraSi,bool? SifilisTratamientoSegundaMuestraSinDatos,bool? SifilisTratamientoSegundaMuestraNoCorresponde,DateTime? SifilisTratamientoSegundaMuestraFecha,decimal? SifilisTratamientoTercerMuestra,bool? SifilisTratamientoTercerMuestraNo,bool? SifilisTratamientoTercerMuestraSi,bool? SifilisTratamientoTercerMuestraSinDatos,bool? SifilisTratamientoTercerMuestraNoCorresponde,DateTime? SifilisTratamientoTercerMuestraFecha,bool Activa,string Observaciones,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdEfectorTrasladoUt,bool? DiabetesActualSi,bool? DiabetesActualNo,bool? AnemiaSi,bool? AnemiaNo,string NumeroIdentidad)
	    {
		    AprHistoriaClinicaPerinatal item = new AprHistoriaClinicaPerinatal();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.Nombre = Nombre;
            
            item.Apellido = Apellido;
            
            item.Domicilio = Domicilio;
            
            item.Dni = Dni;
            
            item.Localidad = Localidad;
            
            item.Telefono = Telefono;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.Edad = Edad;
            
            item.DatosDeContacto = DatosDeContacto;
            
            item.EdadMenor15Mayor35 = EdadMenor15Mayor35;
            
            item.EtniaBlanca = EtniaBlanca;
            
            item.EtniaIndigena = EtniaIndigena;
            
            item.EtniaMestiza = EtniaMestiza;
            
            item.EtniaNegra = EtniaNegra;
            
            item.EtniaOtra = EtniaOtra;
            
            item.AlfabetaSi = AlfabetaSi;
            
            item.AlfabetaNo = AlfabetaNo;
            
            item.EstudiosNinguno = EstudiosNinguno;
            
            item.EstudiosPrimario = EstudiosPrimario;
            
            item.EstudiosSecundario = EstudiosSecundario;
            
            item.EstudiosUniversitario = EstudiosUniversitario;
            
            item.AñosMayorNivel = AñosMayorNivel;
            
            item.EstadoCivilCasada = EstadoCivilCasada;
            
            item.EstadoCivilUnionEstable = EstadoCivilUnionEstable;
            
            item.EstadoCivilSoltera = EstadoCivilSoltera;
            
            item.EstadoCivilOtro = EstadoCivilOtro;
            
            item.ViveSolaSi = ViveSolaSi;
            
            item.ViveSolaNo = ViveSolaNo;
            
            item.LugarControlPerinatal = LugarControlPerinatal;
            
            item.LugarPartoAborto = LugarPartoAborto;
            
            item.AntFamTBCSi = AntFamTBCSi;
            
            item.AntFamTBCNo = AntFamTBCNo;
            
            item.AntFamDiabetesSi = AntFamDiabetesSi;
            
            item.AntFamDiabetesNo = AntFamDiabetesNo;
            
            item.AntFamHipertensionSi = AntFamHipertensionSi;
            
            item.AntFamHipertensionNo = AntFamHipertensionNo;
            
            item.AntFamInfeccionUrinariaSi = AntFamInfeccionUrinariaSi;
            
            item.AntFamInfeccionUrinariaNo = AntFamInfeccionUrinariaNo;
            
            item.AntFamOtrasInfeccionesSi = AntFamOtrasInfeccionesSi;
            
            item.AntFamOtrasInfeccionesNo = AntFamOtrasInfeccionesNo;
            
            item.AntFamOtroSi = AntFamOtroSi;
            
            item.AntFamOtroNo = AntFamOtroNo;
            
            item.AntPerTBCSi = AntPerTBCSi;
            
            item.AntPerTBCNo = AntPerTBCNo;
            
            item.AntPerDiabetesI = AntPerDiabetesI;
            
            item.AntPerDiabetesII = AntPerDiabetesII;
            
            item.AntPerDiabetesG = AntPerDiabetesG;
            
            item.AntPerDiabetesNo = AntPerDiabetesNo;
            
            item.AntPerHipertensionSi = AntPerHipertensionSi;
            
            item.AntPerHipertensionNo = AntPerHipertensionNo;
            
            item.AntPerInfeccionUrinariaSi = AntPerInfeccionUrinariaSi;
            
            item.AntPerInfeccionUrinariaNo = AntPerInfeccionUrinariaNo;
            
            item.AntPerOtrasInfeccionesSi = AntPerOtrasInfeccionesSi;
            
            item.AntPerOtrasInfeccionesNo = AntPerOtrasInfeccionesNo;
            
            item.AntPerOtroSi = AntPerOtroSi;
            
            item.AntPerOtroNo = AntPerOtroNo;
            
            item.AntPerInfertilidadSi = AntPerInfertilidadSi;
            
            item.AntPerInfertilidadNo = AntPerInfertilidadNo;
            
            item.AntPerCardiopatiaSi = AntPerCardiopatiaSi;
            
            item.AntPerCardiopatiaNo = AntPerCardiopatiaNo;
            
            item.AntPerNefropatiaSi = AntPerNefropatiaSi;
            
            item.AntPerNefropatiaNo = AntPerNefropatiaNo;
            
            item.AntPerViolenciaSi = AntPerViolenciaSi;
            
            item.AntPerViolenciaNo = AntPerViolenciaNo;
            
            item.AntPerAlergiaMedicamentoSi = AntPerAlergiaMedicamentoSi;
            
            item.AntPerAlergiaMedicamentoNo = AntPerAlergiaMedicamentoNo;
            
            item.AntecedentesObservacion = AntecedentesObservacion;
            
            item.GestasPrevias = GestasPrevias;
            
            item.Abortos = Abortos;
            
            item.EmbEctopicos = EmbEctopicos;
            
            item.Abortos3concecutivos = Abortos3concecutivos;
            
            item.Partos = Partos;
            
            item.PartosVaginales = PartosVaginales;
            
            item.Cesareas = Cesareas;
            
            item.NacidosVivos = NacidosVivos;
            
            item.NacidosMuertos = NacidosMuertos;
            
            item.Viven = Viven;
            
            item.MuertosPrimerSemana = MuertosPrimerSemana;
            
            item.MuertosDespuesPrimerSemana = MuertosDespuesPrimerSemana;
            
            item.AntecedentesGemelaresSi = AntecedentesGemelaresSi;
            
            item.AntecedentesGemelaresNo = AntecedentesGemelaresNo;
            
            item.UltPrevioNC = UltPrevioNC;
            
            item.UltPrevioNormal = UltPrevioNormal;
            
            item.UltPrevioMenor2500 = UltPrevioMenor2500;
            
            item.UltPrevioMayor4000 = UltPrevioMayor4000;
            
            item.FinEmbarazoAnterior = FinEmbarazoAnterior;
            
            item.FinEmbAnteriorMenor1Año = FinEmbAnteriorMenor1Año;
            
            item.EmbarazoPlaneadoSi = EmbarazoPlaneadoSi;
            
            item.EmbarazoPlaneadoNo = EmbarazoPlaneadoNo;
            
            item.FracMetAnticonceptivoNoUsaba = FracMetAnticonceptivoNoUsaba;
            
            item.FracMetAnticonceptivoBarrera = FracMetAnticonceptivoBarrera;
            
            item.FracMetAnticonceptivoDIU = FracMetAnticonceptivoDIU;
            
            item.FracMetAnticonceptivoHormonal = FracMetAnticonceptivoHormonal;
            
            item.FracMetAnticonceptivoEmergencia = FracMetAnticonceptivoEmergencia;
            
            item.FracMetAnticonceptivoNatural = FracMetAnticonceptivoNatural;
            
            item.PesoAnterior = PesoAnterior;
            
            item.Talla = Talla;
            
            item.Fum = Fum;
            
            item.Fpp = Fpp;
            
            item.EGConfiableFUMSi = EGConfiableFUMSi;
            
            item.EGConfiableFUMNo = EGConfiableFUMNo;
            
            item.EGConfiableEcoMenor20semanasSi = EGConfiableEcoMenor20semanasSi;
            
            item.EGConfiableEcoMenor20semanasNo = EGConfiableEcoMenor20semanasNo;
            
            item.FumaActivo1TrimSi = FumaActivo1TrimSi;
            
            item.FumaActivo1TrimNo = FumaActivo1TrimNo;
            
            item.FumaActivo2TrimSi = FumaActivo2TrimSi;
            
            item.FumaActivo2TrimNo = FumaActivo2TrimNo;
            
            item.FumaActivo3TrimSi = FumaActivo3TrimSi;
            
            item.FumaActivo3TrimNo = FumaActivo3TrimNo;
            
            item.FumaPasivo1TrimSi = FumaPasivo1TrimSi;
            
            item.FumaPasivo1TrimNo = FumaPasivo1TrimNo;
            
            item.FumaPasivo2TrimSi = FumaPasivo2TrimSi;
            
            item.FumaPasivo2TrimNo = FumaPasivo2TrimNo;
            
            item.FumaPasivo3TrimSi = FumaPasivo3TrimSi;
            
            item.FumaPasivo3TrimNo = FumaPasivo3TrimNo;
            
            item.Drogas1TrimSi = Drogas1TrimSi;
            
            item.Drogas1TrimNo = Drogas1TrimNo;
            
            item.Drogas2TrimSi = Drogas2TrimSi;
            
            item.Drogas2TrimNo = Drogas2TrimNo;
            
            item.Drogas3TrimSi = Drogas3TrimSi;
            
            item.Drogas3TrimNo = Drogas3TrimNo;
            
            item.Alcohol1TrimSi = Alcohol1TrimSi;
            
            item.Alcohol1TrimNo = Alcohol1TrimNo;
            
            item.Alcohol2TrimSi = Alcohol2TrimSi;
            
            item.Alcohol2TrimNo = Alcohol2TrimNo;
            
            item.Alcohol3TrimSi = Alcohol3TrimSi;
            
            item.Alcohol3TrimNo = Alcohol3TrimNo;
            
            item.Violencia1TrimSi = Violencia1TrimSi;
            
            item.Violencia1TrimNo = Violencia1TrimNo;
            
            item.Violencia2TrimSi = Violencia2TrimSi;
            
            item.Violencia2TrimNo = Violencia2TrimNo;
            
            item.Violencia3TrimSi = Violencia3TrimSi;
            
            item.Violencia3TrimNo = Violencia3TrimNo;
            
            item.AntirubeolaPrevia = AntirubeolaPrevia;
            
            item.AntirubeolaNoSabe = AntirubeolaNoSabe;
            
            item.AntirubeolaEmbarazo = AntirubeolaEmbarazo;
            
            item.AntirubeolaNo = AntirubeolaNo;
            
            item.AntitetanicaVigenteNo = AntitetanicaVigenteNo;
            
            item.AntitetanicaVigenteSi = AntitetanicaVigenteSi;
            
            item.Antitetanica1DosisMesGestacion = Antitetanica1DosisMesGestacion;
            
            item.Antitetanica2DosisMesGestacion = Antitetanica2DosisMesGestacion;
            
            item.ExamenOdotologicoNormalSi = ExamenOdotologicoNormalSi;
            
            item.ExamenOdotologicoNormalNo = ExamenOdotologicoNormalNo;
            
            item.ExamenMamasNormalSi = ExamenMamasNormalSi;
            
            item.ExamenMamasNormalNo = ExamenMamasNormalNo;
            
            item.CervixInspeccionVisualNormal = CervixInspeccionVisualNormal;
            
            item.CervixInspeccionVisualAnormal = CervixInspeccionVisualAnormal;
            
            item.CervixInspeccionVisualNoSeHizo = CervixInspeccionVisualNoSeHizo;
            
            item.CervixPAPNormal = CervixPAPNormal;
            
            item.CervixPAPAnormal = CervixPAPAnormal;
            
            item.CervixPAPNoSeHizo = CervixPAPNoSeHizo;
            
            item.CervixCOLPNormal = CervixCOLPNormal;
            
            item.CervixCOLPAnormal = CervixCOLPAnormal;
            
            item.CervixCOLPNoSeHizo = CervixCOLPNoSeHizo;
            
            item.Grupo = Grupo;
            
            item.RHPositivo = RHPositivo;
            
            item.RHNegativo = RHNegativo;
            
            item.InmunizacionSi = InmunizacionSi;
            
            item.InmunizacionNo = InmunizacionNo;
            
            item.GammaGlobulinaNo = GammaGlobulinaNo;
            
            item.GammaGlobulinaSi = GammaGlobulinaSi;
            
            item.GammaGlobulinaNoCorresponde = GammaGlobulinaNoCorresponde;
            
            item.ToxoPlasmosisMenor20SemLGGNegativo = ToxoPlasmosisMenor20SemLGGNegativo;
            
            item.ToxoPlasmosisMenor20SemLGGPositivo = ToxoPlasmosisMenor20SemLGGPositivo;
            
            item.ToxoPlasmosisMenor20SemLGGNoSeHizo = ToxoPlasmosisMenor20SemLGGNoSeHizo;
            
            item.ToxoPlasmosisMayor20SemLGGNegativo = ToxoPlasmosisMayor20SemLGGNegativo;
            
            item.ToxoPlasmosisMayor20SemLGGPositivo = ToxoPlasmosisMayor20SemLGGPositivo;
            
            item.ToxoPlasmosisMayor20SemLGGNoSeHizo = ToxoPlasmosisMayor20SemLGGNoSeHizo;
            
            item.ToxoPlasmosis1ConsultaLGMNegativo = ToxoPlasmosis1ConsultaLGMNegativo;
            
            item.ToxoPlasmosis1ConsultaLGMPositivo = ToxoPlasmosis1ConsultaLGMPositivo;
            
            item.ToxoPlasmosis1ConsultaLGMNoSeHizo = ToxoPlasmosis1ConsultaLGMNoSeHizo;
            
            item.ChagasNegativo = ChagasNegativo;
            
            item.ChagasPositivo = ChagasPositivo;
            
            item.ChagasNoSeHizo = ChagasNoSeHizo;
            
            item.HepatitisBNegativo = HepatitisBNegativo;
            
            item.HepatitisBPositivo = HepatitisBPositivo;
            
            item.HepatitisBNoSeHizo = HepatitisBNoSeHizo;
            
            item.BacteriuraMenor20SemNormal = BacteriuraMenor20SemNormal;
            
            item.BacteriuraMenor20SemAnormal = BacteriuraMenor20SemAnormal;
            
            item.BacteriuraMenor20SemNoSeHizo = BacteriuraMenor20SemNoSeHizo;
            
            item.BacteriuraMayor20SemNormal = BacteriuraMayor20SemNormal;
            
            item.BacteriuraMayor20SemAnormal = BacteriuraMayor20SemAnormal;
            
            item.BacteriuraMayor20SemNoSeHizo = BacteriuraMayor20SemNoSeHizo;
            
            item.GlucemiaMenor20Sem = GlucemiaMenor20Sem;
            
            item.GlucemiaMenor20SemMayor105 = GlucemiaMenor20SemMayor105;
            
            item.GlucemiaMayor20Sem = GlucemiaMayor20Sem;
            
            item.GlucemiaMayor20SemMayor105 = GlucemiaMayor20SemMayor105;
            
            item.VIHCRSi = VIHCRSi;
            
            item.VIHCRNo = VIHCRNo;
            
            item.VIHPrimerMuestraSolicitadoSi = VIHPrimerMuestraSolicitadoSi;
            
            item.VIHPrimerMuestraSolicitadoNo = VIHPrimerMuestraSolicitadoNo;
            
            item.VIHPrimerMuestraRealizadoSi = VIHPrimerMuestraRealizadoSi;
            
            item.VIHPrimerMuestraRealizadoNo = VIHPrimerMuestraRealizadoNo;
            
            item.VIHPrimerMuestraFecha = VIHPrimerMuestraFecha;
            
            item.HBMenor20Sem = HBMenor20Sem;
            
            item.HBMenor20SemMenor11 = HBMenor20SemMenor11;
            
            item.HBMayor20Sem = HBMayor20Sem;
            
            item.HBMayor20SemMenor11 = HBMayor20SemMenor11;
            
            item.FeIndicadoSi = FeIndicadoSi;
            
            item.FeIndicadoNo = FeIndicadoNo;
            
            item.FolatosIndicadosSi = FolatosIndicadosSi;
            
            item.FolatosIndicadosNo = FolatosIndicadosNo;
            
            item.EstreptococoB3537SemanasNegativo = EstreptococoB3537SemanasNegativo;
            
            item.EstreptococoB3537SemanasPositivo = EstreptococoB3537SemanasPositivo;
            
            item.EstreptococoB3537SemanasNoSeHizo = EstreptococoB3537SemanasNoSeHizo;
            
            item.PreparacionPartoSi = PreparacionPartoSi;
            
            item.PreparacionPartoNo = PreparacionPartoNo;
            
            item.ConsejeriaLactanciaMaternaSi = ConsejeriaLactanciaMaternaSi;
            
            item.ConsejeriaLactanciaMaternaNo = ConsejeriaLactanciaMaternaNo;
            
            item.SifilisTratParejaMenor20SemNo = SifilisTratParejaMenor20SemNo;
            
            item.SifilisTratParejaMenor20SemSi = SifilisTratParejaMenor20SemSi;
            
            item.SifilisTratParejaMenor20SemSinDatos = SifilisTratParejaMenor20SemSinDatos;
            
            item.SifilisTratParejaMenor20SemNoCorresponde = SifilisTratParejaMenor20SemNoCorresponde;
            
            item.SifilisTratParejaMayor20SemNo = SifilisTratParejaMayor20SemNo;
            
            item.SifilisTratParejaMayor20SemSi = SifilisTratParejaMayor20SemSi;
            
            item.SifilisTratParejaMayor20SemSinDatos = SifilisTratParejaMayor20SemSinDatos;
            
            item.SifilisTratParejaMayor20SemNoCorresponde = SifilisTratParejaMayor20SemNoCorresponde;
            
            item.OAAntecedenteEclampsiaSi = OAAntecedenteEclampsiaSi;
            
            item.OAAntecedenteEclampsiaNo = OAAntecedenteEclampsiaNo;
            
            item.OAActualEclampsiaSi = OAActualEclampsiaSi;
            
            item.OAActualEclampsiaNo = OAActualEclampsiaNo;
            
            item.OAAntecedentePreeclampsiaSi = OAAntecedentePreeclampsiaSi;
            
            item.OAAntecedentePreeclampsiaNo = OAAntecedentePreeclampsiaNo;
            
            item.OAActualPreeclampsiaSi = OAActualPreeclampsiaSi;
            
            item.OAActualPreeclampsiaNo = OAActualPreeclampsiaNo;
            
            item.OAAntecedenteCirugiaGinUrinarSi = OAAntecedenteCirugiaGinUrinarSi;
            
            item.OAAntecedenteCirugiaGinUrinarNo = OAAntecedenteCirugiaGinUrinarNo;
            
            item.OAActualCirugiaGinUrinarSi = OAActualCirugiaGinUrinarSi;
            
            item.OAActualCirugiaGinUrinarNo = OAActualCirugiaGinUrinarNo;
            
            item.OAAntecedenteAPPrematuroSi = OAAntecedenteAPPrematuroSi;
            
            item.OAAntecedenteAPPrematuroNo = OAAntecedenteAPPrematuroNo;
            
            item.OAActualAPPrematuroSi = OAActualAPPrematuroSi;
            
            item.OAActualAPPrematuroNo = OAActualAPPrematuroNo;
            
            item.OAAntecedenteRCIUSi = OAAntecedenteRCIUSi;
            
            item.OAAntecedenteRCIUNo = OAAntecedenteRCIUNo;
            
            item.OAActualRCIUSi = OAActualRCIUSi;
            
            item.OAActualRCIUNo = OAActualRCIUNo;
            
            item.OAAntecedenteHemorragiaObstetricaSi = OAAntecedenteHemorragiaObstetricaSi;
            
            item.OAAntecedenteHemorragiaObstetricaNo = OAAntecedenteHemorragiaObstetricaNo;
            
            item.OAActualHemorragiaObstetricaSi = OAActualHemorragiaObstetricaSi;
            
            item.OAActualHemorragiaObstetricaNo = OAActualHemorragiaObstetricaNo;
            
            item.OAAntecedenteMacrosomiaFetalSi = OAAntecedenteMacrosomiaFetalSi;
            
            item.OAAntecedenteMacrosomiaFetalNo = OAAntecedenteMacrosomiaFetalNo;
            
            item.OAActualMacrosomiaFetalSi = OAActualMacrosomiaFetalSi;
            
            item.OAActualMacrosomiaFetalNo = OAActualMacrosomiaFetalNo;
            
            item.OAAntecedentePolihidramniosSi = OAAntecedentePolihidramniosSi;
            
            item.OAAntecedentePolihidramniosNo = OAAntecedentePolihidramniosNo;
            
            item.OAActualPolihidramniosSi = OAActualPolihidramniosSi;
            
            item.OAActualPolihidramniosNo = OAActualPolihidramniosNo;
            
            item.OAAntecedenteOligoanmiosSi = OAAntecedenteOligoanmiosSi;
            
            item.OAAntecedenteOligoanmiosNo = OAAntecedenteOligoanmiosNo;
            
            item.OAActualOligoanmiosSi = OAActualOligoanmiosSi;
            
            item.OAActualOligoanmiosNo = OAActualOligoanmiosNo;
            
            item.OAAntecedenteRotPremMembranasSi = OAAntecedenteRotPremMembranasSi;
            
            item.OAAntecedenteRotPremMembranasNo = OAAntecedenteRotPremMembranasNo;
            
            item.OAActualRotPremMembranasSi = OAActualRotPremMembranasSi;
            
            item.OAActualRotPremMembranasNo = OAActualRotPremMembranasNo;
            
            item.OAAntecedenteIsoinmunizacionesSi = OAAntecedenteIsoinmunizacionesSi;
            
            item.OAAntecedenteIsoinmunizacionesNo = OAAntecedenteIsoinmunizacionesNo;
            
            item.OAActualIsoinmunizacionesSi = OAActualIsoinmunizacionesSi;
            
            item.OAActualIsoinmunizacionesNo = OAActualIsoinmunizacionesNo;
            
            item.OAAntecedenteColestasisSi = OAAntecedenteColestasisSi;
            
            item.OAAntecedenteColestasisNo = OAAntecedenteColestasisNo;
            
            item.OAActualColestasisSi = OAActualColestasisSi;
            
            item.OAActualColestasisNo = OAActualColestasisNo;
            
            item.OAAntecedenteMortPerinatalRecurrenteSi = OAAntecedenteMortPerinatalRecurrenteSi;
            
            item.OAAntecedenteMortPerinatalRecurrenteNo = OAAntecedenteMortPerinatalRecurrenteNo;
            
            item.OAAntecedenteRetencionPlacentaSi = OAAntecedenteRetencionPlacentaSi;
            
            item.OAAntecedenteRetencionPlacentaNo = OAAntecedenteRetencionPlacentaNo;
            
            item.OAAntecedenteDistociaHombrosSi = OAAntecedenteDistociaHombrosSi;
            
            item.OAAntecedenteDistociaHombrosNo = OAAntecedenteDistociaHombrosNo;
            
            item.OAAntecedenteMalformCongenSi = OAAntecedenteMalformCongenSi;
            
            item.OAAntecedenteMalformCongenNo = OAAntecedenteMalformCongenNo;
            
            item.FactorRiesgoEmbarazoSinContSocialSi = FactorRiesgoEmbarazoSinContSocialSi;
            
            item.FactorRiesgoEmbarazoSinContSocialNo = FactorRiesgoEmbarazoSinContSocialNo;
            
            item.FactorRiesgoFamiliaSinIngresosFijosSi = FactorRiesgoFamiliaSinIngresosFijosSi;
            
            item.FactorRiesgoFamiliaSinIngresosFijosNo = FactorRiesgoFamiliaSinIngresosFijosNo;
            
            item.FactorRiesgoEmbarazoFuertRechazadoSi = FactorRiesgoEmbarazoFuertRechazadoSi;
            
            item.FactorRiesgoEmbarazoFuertRechazadoNo = FactorRiesgoEmbarazoFuertRechazadoNo;
            
            item.FactorRiesgoHijosDadosAdopcionSi = FactorRiesgoHijosDadosAdopcionSi;
            
            item.FactorRiesgoHijosDadosAdopcionNo = FactorRiesgoHijosDadosAdopcionNo;
            
            item.FactorRiesgoViviendaSinServiciosBasicosSi = FactorRiesgoViviendaSinServiciosBasicosSi;
            
            item.FactorRiesgoViviendaSinServiciosBasicosNo = FactorRiesgoViviendaSinServiciosBasicosNo;
            
            item.CaptacionOportunaAntes16sem = CaptacionOportunaAntes16sem;
            
            item.CaptacionOportunaDespues16sem = CaptacionOportunaDespues16sem;
            
            item.FechaMuestraPAP = FechaMuestraPAP;
            
            item.FechaTripleAcelular = FechaTripleAcelular;
            
            item.FechaAntigripal = FechaAntigripal;
            
            item.VIHSegundaMuestraSolicitadoSi = VIHSegundaMuestraSolicitadoSi;
            
            item.VIHSegundaMuestraSolicitadoNo = VIHSegundaMuestraSolicitadoNo;
            
            item.VIHSegundaMuestraRealizadoSi = VIHSegundaMuestraRealizadoSi;
            
            item.VIHSegundaMuestraRealizadoNo = VIHSegundaMuestraRealizadoNo;
            
            item.VIHSegundaMuestraFecha = VIHSegundaMuestraFecha;
            
            item.VIHTercerMuestraSolicitadoSi = VIHTercerMuestraSolicitadoSi;
            
            item.VIHTercerMuestraSolicitadoNo = VIHTercerMuestraSolicitadoNo;
            
            item.VIHTercerMuestraRealizadoSi = VIHTercerMuestraRealizadoSi;
            
            item.VIHTercerMuestraRealizadoNo = VIHTercerMuestraRealizadoNo;
            
            item.VIHTercerMuestraFecha = VIHTercerMuestraFecha;
            
            item.SifilisPruebaNoTrepoPrimerMuestra = SifilisPruebaNoTrepoPrimerMuestra;
            
            item.SifilisPruebaNoTrepoPrimerMuestraNegativo = SifilisPruebaNoTrepoPrimerMuestraNegativo;
            
            item.SifilisPruebaNoTrepoPrimerMuestraPositivo = SifilisPruebaNoTrepoPrimerMuestraPositivo;
            
            item.SifilisPruebaNoTrepoPrimerMuestraSinDatos = SifilisPruebaNoTrepoPrimerMuestraSinDatos;
            
            item.SifilisPruebaNoTrepoPrimerMuestraFecha = SifilisPruebaNoTrepoPrimerMuestraFecha;
            
            item.SifilisPruebaNoTrepoSegundaMuestra = SifilisPruebaNoTrepoSegundaMuestra;
            
            item.SifilisPruebaNoTrepoSegundaMuestraNegativo = SifilisPruebaNoTrepoSegundaMuestraNegativo;
            
            item.SifilisPruebaNoTrepoSegundaMuestraPositivo = SifilisPruebaNoTrepoSegundaMuestraPositivo;
            
            item.SifilisPruebaNoTrepoSegundaMuestraSinDatos = SifilisPruebaNoTrepoSegundaMuestraSinDatos;
            
            item.SifilisPruebaNoTrepoSegundaMuestraFecha = SifilisPruebaNoTrepoSegundaMuestraFecha;
            
            item.SifilisPruebaNoTrepoTercerMuestra = SifilisPruebaNoTrepoTercerMuestra;
            
            item.SifilisPruebaNoTrepoTercerMuestraNegativo = SifilisPruebaNoTrepoTercerMuestraNegativo;
            
            item.SifilisPruebaNoTrepoTercerMuestraPositivo = SifilisPruebaNoTrepoTercerMuestraPositivo;
            
            item.SifilisPruebaNoTrepoTercerMuestraSinDatos = SifilisPruebaNoTrepoTercerMuestraSinDatos;
            
            item.SifilisPruebaNoTrepoTercerMuestraFecha = SifilisPruebaNoTrepoTercerMuestraFecha;
            
            item.SifilisPruebaTrepoPrimerMuestra = SifilisPruebaTrepoPrimerMuestra;
            
            item.SifilisPruebaTrepoPrimerMuestraNegativo = SifilisPruebaTrepoPrimerMuestraNegativo;
            
            item.SifilisPruebaTrepoPrimerMuestraPositivo = SifilisPruebaTrepoPrimerMuestraPositivo;
            
            item.SifilisPruebaTrepoPrimerMuestraSinDatos = SifilisPruebaTrepoPrimerMuestraSinDatos;
            
            item.SifilisPruebaTrepoPrimerMuestraNoCorresponde = SifilisPruebaTrepoPrimerMuestraNoCorresponde;
            
            item.SifilisPruebaTrepoPrimerMuestraFecha = SifilisPruebaTrepoPrimerMuestraFecha;
            
            item.SifilisPruebaTrepoSegundaMuestra = SifilisPruebaTrepoSegundaMuestra;
            
            item.SifilisPruebaTrepoSegundaMuestraNegativo = SifilisPruebaTrepoSegundaMuestraNegativo;
            
            item.SifilisPruebaTrepoSegundaMuestraPositivo = SifilisPruebaTrepoSegundaMuestraPositivo;
            
            item.SifilisPruebaTrepoSegundaMuestraSinDatos = SifilisPruebaTrepoSegundaMuestraSinDatos;
            
            item.SifilisPruebaTrepoSegundaMuestraNoCorresponde = SifilisPruebaTrepoSegundaMuestraNoCorresponde;
            
            item.SifilisPruebaTrepoSegundaMuestraFecha = SifilisPruebaTrepoSegundaMuestraFecha;
            
            item.SifilisPruebaTrepoTercerMuestra = SifilisPruebaTrepoTercerMuestra;
            
            item.SifilisPruebaTrepoTercerMuestraNegativo = SifilisPruebaTrepoTercerMuestraNegativo;
            
            item.SifilisPruebaTrepoTercerMuestraPositivo = SifilisPruebaTrepoTercerMuestraPositivo;
            
            item.SifilisPruebaTrepoTercerMuestraSinDatos = SifilisPruebaTrepoTercerMuestraSinDatos;
            
            item.SifilisPruebaTrepoTercerMuestraNoCorresponde = SifilisPruebaTrepoTercerMuestraNoCorresponde;
            
            item.SifilisPruebaTrepoTercerMuestraFecha = SifilisPruebaTrepoTercerMuestraFecha;
            
            item.SifilisTratamientoPrimerMuestra = SifilisTratamientoPrimerMuestra;
            
            item.SifilisTratamientoPrimerMuestraNo = SifilisTratamientoPrimerMuestraNo;
            
            item.SifilisTratamientoPrimerMuestraSi = SifilisTratamientoPrimerMuestraSi;
            
            item.SifilisTratamientoPrimerMuestraSinDatos = SifilisTratamientoPrimerMuestraSinDatos;
            
            item.SifilisTratamientoPrimerMuestraNoCorresponde = SifilisTratamientoPrimerMuestraNoCorresponde;
            
            item.SifilisTratamientoPrimerMuestraFecha = SifilisTratamientoPrimerMuestraFecha;
            
            item.SifilisTratamientoSegundaMuestra = SifilisTratamientoSegundaMuestra;
            
            item.SifilisTratamientoSegundaMuestraNo = SifilisTratamientoSegundaMuestraNo;
            
            item.SifilisTratamientoSegundaMuestraSi = SifilisTratamientoSegundaMuestraSi;
            
            item.SifilisTratamientoSegundaMuestraSinDatos = SifilisTratamientoSegundaMuestraSinDatos;
            
            item.SifilisTratamientoSegundaMuestraNoCorresponde = SifilisTratamientoSegundaMuestraNoCorresponde;
            
            item.SifilisTratamientoSegundaMuestraFecha = SifilisTratamientoSegundaMuestraFecha;
            
            item.SifilisTratamientoTercerMuestra = SifilisTratamientoTercerMuestra;
            
            item.SifilisTratamientoTercerMuestraNo = SifilisTratamientoTercerMuestraNo;
            
            item.SifilisTratamientoTercerMuestraSi = SifilisTratamientoTercerMuestraSi;
            
            item.SifilisTratamientoTercerMuestraSinDatos = SifilisTratamientoTercerMuestraSinDatos;
            
            item.SifilisTratamientoTercerMuestraNoCorresponde = SifilisTratamientoTercerMuestraNoCorresponde;
            
            item.SifilisTratamientoTercerMuestraFecha = SifilisTratamientoTercerMuestraFecha;
            
            item.Activa = Activa;
            
            item.Observaciones = Observaciones;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdEfectorTrasladoUt = IdEfectorTrasladoUt;
            
            item.DiabetesActualSi = DiabetesActualSi;
            
            item.DiabetesActualNo = DiabetesActualNo;
            
            item.AnemiaSi = AnemiaSi;
            
            item.AnemiaNo = AnemiaNo;
            
            item.NumeroIdentidad = NumeroIdentidad;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdHistoriaClinicaPerinatal,int IdEfector,int IdPaciente,string Nombre,string Apellido,string Domicilio,string Dni,string Localidad,string Telefono,DateTime? FechaNacimiento,int? Edad,string DatosDeContacto,bool? EdadMenor15Mayor35,bool? EtniaBlanca,bool? EtniaIndigena,bool? EtniaMestiza,bool? EtniaNegra,bool? EtniaOtra,bool? AlfabetaSi,bool? AlfabetaNo,bool? EstudiosNinguno,bool? EstudiosPrimario,bool? EstudiosSecundario,bool? EstudiosUniversitario,int? AñosMayorNivel,bool? EstadoCivilCasada,bool? EstadoCivilUnionEstable,bool? EstadoCivilSoltera,bool? EstadoCivilOtro,bool? ViveSolaSi,bool? ViveSolaNo,string LugarControlPerinatal,string LugarPartoAborto,bool? AntFamTBCSi,bool? AntFamTBCNo,bool? AntFamDiabetesSi,bool? AntFamDiabetesNo,bool? AntFamHipertensionSi,bool? AntFamHipertensionNo,bool? AntFamInfeccionUrinariaSi,bool? AntFamInfeccionUrinariaNo,bool? AntFamOtrasInfeccionesSi,bool? AntFamOtrasInfeccionesNo,bool? AntFamOtroSi,bool? AntFamOtroNo,bool? AntPerTBCSi,bool? AntPerTBCNo,bool? AntPerDiabetesI,bool? AntPerDiabetesII,bool? AntPerDiabetesG,bool? AntPerDiabetesNo,bool? AntPerHipertensionSi,bool? AntPerHipertensionNo,bool? AntPerInfeccionUrinariaSi,bool? AntPerInfeccionUrinariaNo,bool? AntPerOtrasInfeccionesSi,bool? AntPerOtrasInfeccionesNo,bool? AntPerOtroSi,bool? AntPerOtroNo,bool? AntPerInfertilidadSi,bool? AntPerInfertilidadNo,bool? AntPerCardiopatiaSi,bool? AntPerCardiopatiaNo,bool? AntPerNefropatiaSi,bool? AntPerNefropatiaNo,bool? AntPerViolenciaSi,bool? AntPerViolenciaNo,bool? AntPerAlergiaMedicamentoSi,bool? AntPerAlergiaMedicamentoNo,string AntecedentesObservacion,int? GestasPrevias,int? Abortos,int? EmbEctopicos,bool? Abortos3concecutivos,int? Partos,int? PartosVaginales,int? Cesareas,int? NacidosVivos,int? NacidosMuertos,int? Viven,int? MuertosPrimerSemana,int? MuertosDespuesPrimerSemana,bool? AntecedentesGemelaresSi,bool? AntecedentesGemelaresNo,bool? UltPrevioNC,bool? UltPrevioNormal,bool? UltPrevioMenor2500,bool? UltPrevioMayor4000,DateTime? FinEmbarazoAnterior,bool? FinEmbAnteriorMenor1Año,bool? EmbarazoPlaneadoSi,bool? EmbarazoPlaneadoNo,bool? FracMetAnticonceptivoNoUsaba,bool? FracMetAnticonceptivoBarrera,bool? FracMetAnticonceptivoDIU,bool? FracMetAnticonceptivoHormonal,bool? FracMetAnticonceptivoEmergencia,bool? FracMetAnticonceptivoNatural,decimal? PesoAnterior,int? Talla,DateTime? Fum,DateTime? Fpp,bool? EGConfiableFUMSi,bool? EGConfiableFUMNo,bool? EGConfiableEcoMenor20semanasSi,bool? EGConfiableEcoMenor20semanasNo,bool? FumaActivo1TrimSi,bool? FumaActivo1TrimNo,bool? FumaActivo2TrimSi,bool? FumaActivo2TrimNo,bool? FumaActivo3TrimSi,bool? FumaActivo3TrimNo,bool? FumaPasivo1TrimSi,bool? FumaPasivo1TrimNo,bool? FumaPasivo2TrimSi,bool? FumaPasivo2TrimNo,bool? FumaPasivo3TrimSi,bool? FumaPasivo3TrimNo,bool? Drogas1TrimSi,bool? Drogas1TrimNo,bool? Drogas2TrimSi,bool? Drogas2TrimNo,bool? Drogas3TrimSi,bool? Drogas3TrimNo,bool? Alcohol1TrimSi,bool? Alcohol1TrimNo,bool? Alcohol2TrimSi,bool? Alcohol2TrimNo,bool? Alcohol3TrimSi,bool? Alcohol3TrimNo,bool? Violencia1TrimSi,bool? Violencia1TrimNo,bool? Violencia2TrimSi,bool? Violencia2TrimNo,bool? Violencia3TrimSi,bool? Violencia3TrimNo,bool? AntirubeolaPrevia,bool? AntirubeolaNoSabe,bool? AntirubeolaEmbarazo,bool? AntirubeolaNo,bool? AntitetanicaVigenteNo,bool? AntitetanicaVigenteSi,int? Antitetanica1DosisMesGestacion,int? Antitetanica2DosisMesGestacion,bool? ExamenOdotologicoNormalSi,bool? ExamenOdotologicoNormalNo,bool? ExamenMamasNormalSi,bool? ExamenMamasNormalNo,bool? CervixInspeccionVisualNormal,bool? CervixInspeccionVisualAnormal,bool? CervixInspeccionVisualNoSeHizo,bool? CervixPAPNormal,bool? CervixPAPAnormal,bool? CervixPAPNoSeHizo,bool? CervixCOLPNormal,bool? CervixCOLPAnormal,bool? CervixCOLPNoSeHizo,string Grupo,bool? RHPositivo,bool? RHNegativo,bool? InmunizacionSi,bool? InmunizacionNo,bool? GammaGlobulinaNo,bool? GammaGlobulinaSi,bool? GammaGlobulinaNoCorresponde,bool? ToxoPlasmosisMenor20SemLGGNegativo,bool? ToxoPlasmosisMenor20SemLGGPositivo,bool? ToxoPlasmosisMenor20SemLGGNoSeHizo,bool? ToxoPlasmosisMayor20SemLGGNegativo,bool? ToxoPlasmosisMayor20SemLGGPositivo,bool? ToxoPlasmosisMayor20SemLGGNoSeHizo,bool? ToxoPlasmosis1ConsultaLGMNegativo,bool? ToxoPlasmosis1ConsultaLGMPositivo,bool? ToxoPlasmosis1ConsultaLGMNoSeHizo,bool? ChagasNegativo,bool? ChagasPositivo,bool? ChagasNoSeHizo,bool? HepatitisBNegativo,bool? HepatitisBPositivo,bool? HepatitisBNoSeHizo,bool? BacteriuraMenor20SemNormal,bool? BacteriuraMenor20SemAnormal,bool? BacteriuraMenor20SemNoSeHizo,bool? BacteriuraMayor20SemNormal,bool? BacteriuraMayor20SemAnormal,bool? BacteriuraMayor20SemNoSeHizo,decimal? GlucemiaMenor20Sem,bool? GlucemiaMenor20SemMayor105,decimal? GlucemiaMayor20Sem,bool? GlucemiaMayor20SemMayor105,bool? VIHCRSi,bool? VIHCRNo,bool? VIHPrimerMuestraSolicitadoSi,bool? VIHPrimerMuestraSolicitadoNo,bool? VIHPrimerMuestraRealizadoSi,bool? VIHPrimerMuestraRealizadoNo,DateTime? VIHPrimerMuestraFecha,decimal? HBMenor20Sem,bool? HBMenor20SemMenor11,decimal? HBMayor20Sem,bool? HBMayor20SemMenor11,bool? FeIndicadoSi,bool? FeIndicadoNo,bool? FolatosIndicadosSi,bool? FolatosIndicadosNo,bool? EstreptococoB3537SemanasNegativo,bool? EstreptococoB3537SemanasPositivo,bool? EstreptococoB3537SemanasNoSeHizo,bool? PreparacionPartoSi,bool? PreparacionPartoNo,bool? ConsejeriaLactanciaMaternaSi,bool? ConsejeriaLactanciaMaternaNo,bool? SifilisTratParejaMenor20SemNo,bool? SifilisTratParejaMenor20SemSi,bool? SifilisTratParejaMenor20SemSinDatos,bool? SifilisTratParejaMenor20SemNoCorresponde,bool? SifilisTratParejaMayor20SemNo,bool? SifilisTratParejaMayor20SemSi,bool? SifilisTratParejaMayor20SemSinDatos,bool? SifilisTratParejaMayor20SemNoCorresponde,bool? OAAntecedenteEclampsiaSi,bool? OAAntecedenteEclampsiaNo,bool? OAActualEclampsiaSi,bool? OAActualEclampsiaNo,bool? OAAntecedentePreeclampsiaSi,bool? OAAntecedentePreeclampsiaNo,bool? OAActualPreeclampsiaSi,bool? OAActualPreeclampsiaNo,bool? OAAntecedenteCirugiaGinUrinarSi,bool? OAAntecedenteCirugiaGinUrinarNo,bool? OAActualCirugiaGinUrinarSi,bool? OAActualCirugiaGinUrinarNo,bool? OAAntecedenteAPPrematuroSi,bool? OAAntecedenteAPPrematuroNo,bool? OAActualAPPrematuroSi,bool? OAActualAPPrematuroNo,bool? OAAntecedenteRCIUSi,bool? OAAntecedenteRCIUNo,bool? OAActualRCIUSi,bool? OAActualRCIUNo,bool? OAAntecedenteHemorragiaObstetricaSi,bool? OAAntecedenteHemorragiaObstetricaNo,bool? OAActualHemorragiaObstetricaSi,bool? OAActualHemorragiaObstetricaNo,bool? OAAntecedenteMacrosomiaFetalSi,bool? OAAntecedenteMacrosomiaFetalNo,bool? OAActualMacrosomiaFetalSi,bool? OAActualMacrosomiaFetalNo,bool? OAAntecedentePolihidramniosSi,bool? OAAntecedentePolihidramniosNo,bool? OAActualPolihidramniosSi,bool? OAActualPolihidramniosNo,bool? OAAntecedenteOligoanmiosSi,bool? OAAntecedenteOligoanmiosNo,bool? OAActualOligoanmiosSi,bool? OAActualOligoanmiosNo,bool? OAAntecedenteRotPremMembranasSi,bool? OAAntecedenteRotPremMembranasNo,bool? OAActualRotPremMembranasSi,bool? OAActualRotPremMembranasNo,bool? OAAntecedenteIsoinmunizacionesSi,bool? OAAntecedenteIsoinmunizacionesNo,bool? OAActualIsoinmunizacionesSi,bool? OAActualIsoinmunizacionesNo,bool? OAAntecedenteColestasisSi,bool? OAAntecedenteColestasisNo,bool? OAActualColestasisSi,bool? OAActualColestasisNo,bool? OAAntecedenteMortPerinatalRecurrenteSi,bool? OAAntecedenteMortPerinatalRecurrenteNo,bool? OAAntecedenteRetencionPlacentaSi,bool? OAAntecedenteRetencionPlacentaNo,bool? OAAntecedenteDistociaHombrosSi,bool? OAAntecedenteDistociaHombrosNo,bool? OAAntecedenteMalformCongenSi,bool? OAAntecedenteMalformCongenNo,bool? FactorRiesgoEmbarazoSinContSocialSi,bool? FactorRiesgoEmbarazoSinContSocialNo,bool? FactorRiesgoFamiliaSinIngresosFijosSi,bool? FactorRiesgoFamiliaSinIngresosFijosNo,bool? FactorRiesgoEmbarazoFuertRechazadoSi,bool? FactorRiesgoEmbarazoFuertRechazadoNo,bool? FactorRiesgoHijosDadosAdopcionSi,bool? FactorRiesgoHijosDadosAdopcionNo,bool? FactorRiesgoViviendaSinServiciosBasicosSi,bool? FactorRiesgoViviendaSinServiciosBasicosNo,bool? CaptacionOportunaAntes16sem,bool? CaptacionOportunaDespues16sem,DateTime? FechaMuestraPAP,DateTime? FechaTripleAcelular,DateTime? FechaAntigripal,bool? VIHSegundaMuestraSolicitadoSi,bool? VIHSegundaMuestraSolicitadoNo,bool? VIHSegundaMuestraRealizadoSi,bool? VIHSegundaMuestraRealizadoNo,DateTime? VIHSegundaMuestraFecha,bool? VIHTercerMuestraSolicitadoSi,bool? VIHTercerMuestraSolicitadoNo,bool? VIHTercerMuestraRealizadoSi,bool? VIHTercerMuestraRealizadoNo,DateTime? VIHTercerMuestraFecha,decimal? SifilisPruebaNoTrepoPrimerMuestra,bool? SifilisPruebaNoTrepoPrimerMuestraNegativo,bool? SifilisPruebaNoTrepoPrimerMuestraPositivo,bool? SifilisPruebaNoTrepoPrimerMuestraSinDatos,DateTime? SifilisPruebaNoTrepoPrimerMuestraFecha,decimal? SifilisPruebaNoTrepoSegundaMuestra,bool? SifilisPruebaNoTrepoSegundaMuestraNegativo,bool? SifilisPruebaNoTrepoSegundaMuestraPositivo,bool? SifilisPruebaNoTrepoSegundaMuestraSinDatos,DateTime? SifilisPruebaNoTrepoSegundaMuestraFecha,decimal? SifilisPruebaNoTrepoTercerMuestra,bool? SifilisPruebaNoTrepoTercerMuestraNegativo,bool? SifilisPruebaNoTrepoTercerMuestraPositivo,bool? SifilisPruebaNoTrepoTercerMuestraSinDatos,DateTime? SifilisPruebaNoTrepoTercerMuestraFecha,decimal? SifilisPruebaTrepoPrimerMuestra,bool? SifilisPruebaTrepoPrimerMuestraNegativo,bool? SifilisPruebaTrepoPrimerMuestraPositivo,bool? SifilisPruebaTrepoPrimerMuestraSinDatos,bool? SifilisPruebaTrepoPrimerMuestraNoCorresponde,DateTime? SifilisPruebaTrepoPrimerMuestraFecha,decimal? SifilisPruebaTrepoSegundaMuestra,bool? SifilisPruebaTrepoSegundaMuestraNegativo,bool? SifilisPruebaTrepoSegundaMuestraPositivo,bool? SifilisPruebaTrepoSegundaMuestraSinDatos,bool? SifilisPruebaTrepoSegundaMuestraNoCorresponde,DateTime? SifilisPruebaTrepoSegundaMuestraFecha,decimal? SifilisPruebaTrepoTercerMuestra,bool? SifilisPruebaTrepoTercerMuestraNegativo,bool? SifilisPruebaTrepoTercerMuestraPositivo,bool? SifilisPruebaTrepoTercerMuestraSinDatos,bool? SifilisPruebaTrepoTercerMuestraNoCorresponde,DateTime? SifilisPruebaTrepoTercerMuestraFecha,decimal? SifilisTratamientoPrimerMuestra,bool? SifilisTratamientoPrimerMuestraNo,bool? SifilisTratamientoPrimerMuestraSi,bool? SifilisTratamientoPrimerMuestraSinDatos,bool? SifilisTratamientoPrimerMuestraNoCorresponde,DateTime? SifilisTratamientoPrimerMuestraFecha,decimal? SifilisTratamientoSegundaMuestra,bool? SifilisTratamientoSegundaMuestraNo,bool? SifilisTratamientoSegundaMuestraSi,bool? SifilisTratamientoSegundaMuestraSinDatos,bool? SifilisTratamientoSegundaMuestraNoCorresponde,DateTime? SifilisTratamientoSegundaMuestraFecha,decimal? SifilisTratamientoTercerMuestra,bool? SifilisTratamientoTercerMuestraNo,bool? SifilisTratamientoTercerMuestraSi,bool? SifilisTratamientoTercerMuestraSinDatos,bool? SifilisTratamientoTercerMuestraNoCorresponde,DateTime? SifilisTratamientoTercerMuestraFecha,bool Activa,string Observaciones,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdEfectorTrasladoUt,bool? DiabetesActualSi,bool? DiabetesActualNo,bool? AnemiaSi,bool? AnemiaNo,string NumeroIdentidad)
	    {
		    AprHistoriaClinicaPerinatal item = new AprHistoriaClinicaPerinatal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.Nombre = Nombre;
				
			item.Apellido = Apellido;
				
			item.Domicilio = Domicilio;
				
			item.Dni = Dni;
				
			item.Localidad = Localidad;
				
			item.Telefono = Telefono;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.Edad = Edad;
				
			item.DatosDeContacto = DatosDeContacto;
				
			item.EdadMenor15Mayor35 = EdadMenor15Mayor35;
				
			item.EtniaBlanca = EtniaBlanca;
				
			item.EtniaIndigena = EtniaIndigena;
				
			item.EtniaMestiza = EtniaMestiza;
				
			item.EtniaNegra = EtniaNegra;
				
			item.EtniaOtra = EtniaOtra;
				
			item.AlfabetaSi = AlfabetaSi;
				
			item.AlfabetaNo = AlfabetaNo;
				
			item.EstudiosNinguno = EstudiosNinguno;
				
			item.EstudiosPrimario = EstudiosPrimario;
				
			item.EstudiosSecundario = EstudiosSecundario;
				
			item.EstudiosUniversitario = EstudiosUniversitario;
				
			item.AñosMayorNivel = AñosMayorNivel;
				
			item.EstadoCivilCasada = EstadoCivilCasada;
				
			item.EstadoCivilUnionEstable = EstadoCivilUnionEstable;
				
			item.EstadoCivilSoltera = EstadoCivilSoltera;
				
			item.EstadoCivilOtro = EstadoCivilOtro;
				
			item.ViveSolaSi = ViveSolaSi;
				
			item.ViveSolaNo = ViveSolaNo;
				
			item.LugarControlPerinatal = LugarControlPerinatal;
				
			item.LugarPartoAborto = LugarPartoAborto;
				
			item.AntFamTBCSi = AntFamTBCSi;
				
			item.AntFamTBCNo = AntFamTBCNo;
				
			item.AntFamDiabetesSi = AntFamDiabetesSi;
				
			item.AntFamDiabetesNo = AntFamDiabetesNo;
				
			item.AntFamHipertensionSi = AntFamHipertensionSi;
				
			item.AntFamHipertensionNo = AntFamHipertensionNo;
				
			item.AntFamInfeccionUrinariaSi = AntFamInfeccionUrinariaSi;
				
			item.AntFamInfeccionUrinariaNo = AntFamInfeccionUrinariaNo;
				
			item.AntFamOtrasInfeccionesSi = AntFamOtrasInfeccionesSi;
				
			item.AntFamOtrasInfeccionesNo = AntFamOtrasInfeccionesNo;
				
			item.AntFamOtroSi = AntFamOtroSi;
				
			item.AntFamOtroNo = AntFamOtroNo;
				
			item.AntPerTBCSi = AntPerTBCSi;
				
			item.AntPerTBCNo = AntPerTBCNo;
				
			item.AntPerDiabetesI = AntPerDiabetesI;
				
			item.AntPerDiabetesII = AntPerDiabetesII;
				
			item.AntPerDiabetesG = AntPerDiabetesG;
				
			item.AntPerDiabetesNo = AntPerDiabetesNo;
				
			item.AntPerHipertensionSi = AntPerHipertensionSi;
				
			item.AntPerHipertensionNo = AntPerHipertensionNo;
				
			item.AntPerInfeccionUrinariaSi = AntPerInfeccionUrinariaSi;
				
			item.AntPerInfeccionUrinariaNo = AntPerInfeccionUrinariaNo;
				
			item.AntPerOtrasInfeccionesSi = AntPerOtrasInfeccionesSi;
				
			item.AntPerOtrasInfeccionesNo = AntPerOtrasInfeccionesNo;
				
			item.AntPerOtroSi = AntPerOtroSi;
				
			item.AntPerOtroNo = AntPerOtroNo;
				
			item.AntPerInfertilidadSi = AntPerInfertilidadSi;
				
			item.AntPerInfertilidadNo = AntPerInfertilidadNo;
				
			item.AntPerCardiopatiaSi = AntPerCardiopatiaSi;
				
			item.AntPerCardiopatiaNo = AntPerCardiopatiaNo;
				
			item.AntPerNefropatiaSi = AntPerNefropatiaSi;
				
			item.AntPerNefropatiaNo = AntPerNefropatiaNo;
				
			item.AntPerViolenciaSi = AntPerViolenciaSi;
				
			item.AntPerViolenciaNo = AntPerViolenciaNo;
				
			item.AntPerAlergiaMedicamentoSi = AntPerAlergiaMedicamentoSi;
				
			item.AntPerAlergiaMedicamentoNo = AntPerAlergiaMedicamentoNo;
				
			item.AntecedentesObservacion = AntecedentesObservacion;
				
			item.GestasPrevias = GestasPrevias;
				
			item.Abortos = Abortos;
				
			item.EmbEctopicos = EmbEctopicos;
				
			item.Abortos3concecutivos = Abortos3concecutivos;
				
			item.Partos = Partos;
				
			item.PartosVaginales = PartosVaginales;
				
			item.Cesareas = Cesareas;
				
			item.NacidosVivos = NacidosVivos;
				
			item.NacidosMuertos = NacidosMuertos;
				
			item.Viven = Viven;
				
			item.MuertosPrimerSemana = MuertosPrimerSemana;
				
			item.MuertosDespuesPrimerSemana = MuertosDespuesPrimerSemana;
				
			item.AntecedentesGemelaresSi = AntecedentesGemelaresSi;
				
			item.AntecedentesGemelaresNo = AntecedentesGemelaresNo;
				
			item.UltPrevioNC = UltPrevioNC;
				
			item.UltPrevioNormal = UltPrevioNormal;
				
			item.UltPrevioMenor2500 = UltPrevioMenor2500;
				
			item.UltPrevioMayor4000 = UltPrevioMayor4000;
				
			item.FinEmbarazoAnterior = FinEmbarazoAnterior;
				
			item.FinEmbAnteriorMenor1Año = FinEmbAnteriorMenor1Año;
				
			item.EmbarazoPlaneadoSi = EmbarazoPlaneadoSi;
				
			item.EmbarazoPlaneadoNo = EmbarazoPlaneadoNo;
				
			item.FracMetAnticonceptivoNoUsaba = FracMetAnticonceptivoNoUsaba;
				
			item.FracMetAnticonceptivoBarrera = FracMetAnticonceptivoBarrera;
				
			item.FracMetAnticonceptivoDIU = FracMetAnticonceptivoDIU;
				
			item.FracMetAnticonceptivoHormonal = FracMetAnticonceptivoHormonal;
				
			item.FracMetAnticonceptivoEmergencia = FracMetAnticonceptivoEmergencia;
				
			item.FracMetAnticonceptivoNatural = FracMetAnticonceptivoNatural;
				
			item.PesoAnterior = PesoAnterior;
				
			item.Talla = Talla;
				
			item.Fum = Fum;
				
			item.Fpp = Fpp;
				
			item.EGConfiableFUMSi = EGConfiableFUMSi;
				
			item.EGConfiableFUMNo = EGConfiableFUMNo;
				
			item.EGConfiableEcoMenor20semanasSi = EGConfiableEcoMenor20semanasSi;
				
			item.EGConfiableEcoMenor20semanasNo = EGConfiableEcoMenor20semanasNo;
				
			item.FumaActivo1TrimSi = FumaActivo1TrimSi;
				
			item.FumaActivo1TrimNo = FumaActivo1TrimNo;
				
			item.FumaActivo2TrimSi = FumaActivo2TrimSi;
				
			item.FumaActivo2TrimNo = FumaActivo2TrimNo;
				
			item.FumaActivo3TrimSi = FumaActivo3TrimSi;
				
			item.FumaActivo3TrimNo = FumaActivo3TrimNo;
				
			item.FumaPasivo1TrimSi = FumaPasivo1TrimSi;
				
			item.FumaPasivo1TrimNo = FumaPasivo1TrimNo;
				
			item.FumaPasivo2TrimSi = FumaPasivo2TrimSi;
				
			item.FumaPasivo2TrimNo = FumaPasivo2TrimNo;
				
			item.FumaPasivo3TrimSi = FumaPasivo3TrimSi;
				
			item.FumaPasivo3TrimNo = FumaPasivo3TrimNo;
				
			item.Drogas1TrimSi = Drogas1TrimSi;
				
			item.Drogas1TrimNo = Drogas1TrimNo;
				
			item.Drogas2TrimSi = Drogas2TrimSi;
				
			item.Drogas2TrimNo = Drogas2TrimNo;
				
			item.Drogas3TrimSi = Drogas3TrimSi;
				
			item.Drogas3TrimNo = Drogas3TrimNo;
				
			item.Alcohol1TrimSi = Alcohol1TrimSi;
				
			item.Alcohol1TrimNo = Alcohol1TrimNo;
				
			item.Alcohol2TrimSi = Alcohol2TrimSi;
				
			item.Alcohol2TrimNo = Alcohol2TrimNo;
				
			item.Alcohol3TrimSi = Alcohol3TrimSi;
				
			item.Alcohol3TrimNo = Alcohol3TrimNo;
				
			item.Violencia1TrimSi = Violencia1TrimSi;
				
			item.Violencia1TrimNo = Violencia1TrimNo;
				
			item.Violencia2TrimSi = Violencia2TrimSi;
				
			item.Violencia2TrimNo = Violencia2TrimNo;
				
			item.Violencia3TrimSi = Violencia3TrimSi;
				
			item.Violencia3TrimNo = Violencia3TrimNo;
				
			item.AntirubeolaPrevia = AntirubeolaPrevia;
				
			item.AntirubeolaNoSabe = AntirubeolaNoSabe;
				
			item.AntirubeolaEmbarazo = AntirubeolaEmbarazo;
				
			item.AntirubeolaNo = AntirubeolaNo;
				
			item.AntitetanicaVigenteNo = AntitetanicaVigenteNo;
				
			item.AntitetanicaVigenteSi = AntitetanicaVigenteSi;
				
			item.Antitetanica1DosisMesGestacion = Antitetanica1DosisMesGestacion;
				
			item.Antitetanica2DosisMesGestacion = Antitetanica2DosisMesGestacion;
				
			item.ExamenOdotologicoNormalSi = ExamenOdotologicoNormalSi;
				
			item.ExamenOdotologicoNormalNo = ExamenOdotologicoNormalNo;
				
			item.ExamenMamasNormalSi = ExamenMamasNormalSi;
				
			item.ExamenMamasNormalNo = ExamenMamasNormalNo;
				
			item.CervixInspeccionVisualNormal = CervixInspeccionVisualNormal;
				
			item.CervixInspeccionVisualAnormal = CervixInspeccionVisualAnormal;
				
			item.CervixInspeccionVisualNoSeHizo = CervixInspeccionVisualNoSeHizo;
				
			item.CervixPAPNormal = CervixPAPNormal;
				
			item.CervixPAPAnormal = CervixPAPAnormal;
				
			item.CervixPAPNoSeHizo = CervixPAPNoSeHizo;
				
			item.CervixCOLPNormal = CervixCOLPNormal;
				
			item.CervixCOLPAnormal = CervixCOLPAnormal;
				
			item.CervixCOLPNoSeHizo = CervixCOLPNoSeHizo;
				
			item.Grupo = Grupo;
				
			item.RHPositivo = RHPositivo;
				
			item.RHNegativo = RHNegativo;
				
			item.InmunizacionSi = InmunizacionSi;
				
			item.InmunizacionNo = InmunizacionNo;
				
			item.GammaGlobulinaNo = GammaGlobulinaNo;
				
			item.GammaGlobulinaSi = GammaGlobulinaSi;
				
			item.GammaGlobulinaNoCorresponde = GammaGlobulinaNoCorresponde;
				
			item.ToxoPlasmosisMenor20SemLGGNegativo = ToxoPlasmosisMenor20SemLGGNegativo;
				
			item.ToxoPlasmosisMenor20SemLGGPositivo = ToxoPlasmosisMenor20SemLGGPositivo;
				
			item.ToxoPlasmosisMenor20SemLGGNoSeHizo = ToxoPlasmosisMenor20SemLGGNoSeHizo;
				
			item.ToxoPlasmosisMayor20SemLGGNegativo = ToxoPlasmosisMayor20SemLGGNegativo;
				
			item.ToxoPlasmosisMayor20SemLGGPositivo = ToxoPlasmosisMayor20SemLGGPositivo;
				
			item.ToxoPlasmosisMayor20SemLGGNoSeHizo = ToxoPlasmosisMayor20SemLGGNoSeHizo;
				
			item.ToxoPlasmosis1ConsultaLGMNegativo = ToxoPlasmosis1ConsultaLGMNegativo;
				
			item.ToxoPlasmosis1ConsultaLGMPositivo = ToxoPlasmosis1ConsultaLGMPositivo;
				
			item.ToxoPlasmosis1ConsultaLGMNoSeHizo = ToxoPlasmosis1ConsultaLGMNoSeHizo;
				
			item.ChagasNegativo = ChagasNegativo;
				
			item.ChagasPositivo = ChagasPositivo;
				
			item.ChagasNoSeHizo = ChagasNoSeHizo;
				
			item.HepatitisBNegativo = HepatitisBNegativo;
				
			item.HepatitisBPositivo = HepatitisBPositivo;
				
			item.HepatitisBNoSeHizo = HepatitisBNoSeHizo;
				
			item.BacteriuraMenor20SemNormal = BacteriuraMenor20SemNormal;
				
			item.BacteriuraMenor20SemAnormal = BacteriuraMenor20SemAnormal;
				
			item.BacteriuraMenor20SemNoSeHizo = BacteriuraMenor20SemNoSeHizo;
				
			item.BacteriuraMayor20SemNormal = BacteriuraMayor20SemNormal;
				
			item.BacteriuraMayor20SemAnormal = BacteriuraMayor20SemAnormal;
				
			item.BacteriuraMayor20SemNoSeHizo = BacteriuraMayor20SemNoSeHizo;
				
			item.GlucemiaMenor20Sem = GlucemiaMenor20Sem;
				
			item.GlucemiaMenor20SemMayor105 = GlucemiaMenor20SemMayor105;
				
			item.GlucemiaMayor20Sem = GlucemiaMayor20Sem;
				
			item.GlucemiaMayor20SemMayor105 = GlucemiaMayor20SemMayor105;
				
			item.VIHCRSi = VIHCRSi;
				
			item.VIHCRNo = VIHCRNo;
				
			item.VIHPrimerMuestraSolicitadoSi = VIHPrimerMuestraSolicitadoSi;
				
			item.VIHPrimerMuestraSolicitadoNo = VIHPrimerMuestraSolicitadoNo;
				
			item.VIHPrimerMuestraRealizadoSi = VIHPrimerMuestraRealizadoSi;
				
			item.VIHPrimerMuestraRealizadoNo = VIHPrimerMuestraRealizadoNo;
				
			item.VIHPrimerMuestraFecha = VIHPrimerMuestraFecha;
				
			item.HBMenor20Sem = HBMenor20Sem;
				
			item.HBMenor20SemMenor11 = HBMenor20SemMenor11;
				
			item.HBMayor20Sem = HBMayor20Sem;
				
			item.HBMayor20SemMenor11 = HBMayor20SemMenor11;
				
			item.FeIndicadoSi = FeIndicadoSi;
				
			item.FeIndicadoNo = FeIndicadoNo;
				
			item.FolatosIndicadosSi = FolatosIndicadosSi;
				
			item.FolatosIndicadosNo = FolatosIndicadosNo;
				
			item.EstreptococoB3537SemanasNegativo = EstreptococoB3537SemanasNegativo;
				
			item.EstreptococoB3537SemanasPositivo = EstreptococoB3537SemanasPositivo;
				
			item.EstreptococoB3537SemanasNoSeHizo = EstreptococoB3537SemanasNoSeHizo;
				
			item.PreparacionPartoSi = PreparacionPartoSi;
				
			item.PreparacionPartoNo = PreparacionPartoNo;
				
			item.ConsejeriaLactanciaMaternaSi = ConsejeriaLactanciaMaternaSi;
				
			item.ConsejeriaLactanciaMaternaNo = ConsejeriaLactanciaMaternaNo;
				
			item.SifilisTratParejaMenor20SemNo = SifilisTratParejaMenor20SemNo;
				
			item.SifilisTratParejaMenor20SemSi = SifilisTratParejaMenor20SemSi;
				
			item.SifilisTratParejaMenor20SemSinDatos = SifilisTratParejaMenor20SemSinDatos;
				
			item.SifilisTratParejaMenor20SemNoCorresponde = SifilisTratParejaMenor20SemNoCorresponde;
				
			item.SifilisTratParejaMayor20SemNo = SifilisTratParejaMayor20SemNo;
				
			item.SifilisTratParejaMayor20SemSi = SifilisTratParejaMayor20SemSi;
				
			item.SifilisTratParejaMayor20SemSinDatos = SifilisTratParejaMayor20SemSinDatos;
				
			item.SifilisTratParejaMayor20SemNoCorresponde = SifilisTratParejaMayor20SemNoCorresponde;
				
			item.OAAntecedenteEclampsiaSi = OAAntecedenteEclampsiaSi;
				
			item.OAAntecedenteEclampsiaNo = OAAntecedenteEclampsiaNo;
				
			item.OAActualEclampsiaSi = OAActualEclampsiaSi;
				
			item.OAActualEclampsiaNo = OAActualEclampsiaNo;
				
			item.OAAntecedentePreeclampsiaSi = OAAntecedentePreeclampsiaSi;
				
			item.OAAntecedentePreeclampsiaNo = OAAntecedentePreeclampsiaNo;
				
			item.OAActualPreeclampsiaSi = OAActualPreeclampsiaSi;
				
			item.OAActualPreeclampsiaNo = OAActualPreeclampsiaNo;
				
			item.OAAntecedenteCirugiaGinUrinarSi = OAAntecedenteCirugiaGinUrinarSi;
				
			item.OAAntecedenteCirugiaGinUrinarNo = OAAntecedenteCirugiaGinUrinarNo;
				
			item.OAActualCirugiaGinUrinarSi = OAActualCirugiaGinUrinarSi;
				
			item.OAActualCirugiaGinUrinarNo = OAActualCirugiaGinUrinarNo;
				
			item.OAAntecedenteAPPrematuroSi = OAAntecedenteAPPrematuroSi;
				
			item.OAAntecedenteAPPrematuroNo = OAAntecedenteAPPrematuroNo;
				
			item.OAActualAPPrematuroSi = OAActualAPPrematuroSi;
				
			item.OAActualAPPrematuroNo = OAActualAPPrematuroNo;
				
			item.OAAntecedenteRCIUSi = OAAntecedenteRCIUSi;
				
			item.OAAntecedenteRCIUNo = OAAntecedenteRCIUNo;
				
			item.OAActualRCIUSi = OAActualRCIUSi;
				
			item.OAActualRCIUNo = OAActualRCIUNo;
				
			item.OAAntecedenteHemorragiaObstetricaSi = OAAntecedenteHemorragiaObstetricaSi;
				
			item.OAAntecedenteHemorragiaObstetricaNo = OAAntecedenteHemorragiaObstetricaNo;
				
			item.OAActualHemorragiaObstetricaSi = OAActualHemorragiaObstetricaSi;
				
			item.OAActualHemorragiaObstetricaNo = OAActualHemorragiaObstetricaNo;
				
			item.OAAntecedenteMacrosomiaFetalSi = OAAntecedenteMacrosomiaFetalSi;
				
			item.OAAntecedenteMacrosomiaFetalNo = OAAntecedenteMacrosomiaFetalNo;
				
			item.OAActualMacrosomiaFetalSi = OAActualMacrosomiaFetalSi;
				
			item.OAActualMacrosomiaFetalNo = OAActualMacrosomiaFetalNo;
				
			item.OAAntecedentePolihidramniosSi = OAAntecedentePolihidramniosSi;
				
			item.OAAntecedentePolihidramniosNo = OAAntecedentePolihidramniosNo;
				
			item.OAActualPolihidramniosSi = OAActualPolihidramniosSi;
				
			item.OAActualPolihidramniosNo = OAActualPolihidramniosNo;
				
			item.OAAntecedenteOligoanmiosSi = OAAntecedenteOligoanmiosSi;
				
			item.OAAntecedenteOligoanmiosNo = OAAntecedenteOligoanmiosNo;
				
			item.OAActualOligoanmiosSi = OAActualOligoanmiosSi;
				
			item.OAActualOligoanmiosNo = OAActualOligoanmiosNo;
				
			item.OAAntecedenteRotPremMembranasSi = OAAntecedenteRotPremMembranasSi;
				
			item.OAAntecedenteRotPremMembranasNo = OAAntecedenteRotPremMembranasNo;
				
			item.OAActualRotPremMembranasSi = OAActualRotPremMembranasSi;
				
			item.OAActualRotPremMembranasNo = OAActualRotPremMembranasNo;
				
			item.OAAntecedenteIsoinmunizacionesSi = OAAntecedenteIsoinmunizacionesSi;
				
			item.OAAntecedenteIsoinmunizacionesNo = OAAntecedenteIsoinmunizacionesNo;
				
			item.OAActualIsoinmunizacionesSi = OAActualIsoinmunizacionesSi;
				
			item.OAActualIsoinmunizacionesNo = OAActualIsoinmunizacionesNo;
				
			item.OAAntecedenteColestasisSi = OAAntecedenteColestasisSi;
				
			item.OAAntecedenteColestasisNo = OAAntecedenteColestasisNo;
				
			item.OAActualColestasisSi = OAActualColestasisSi;
				
			item.OAActualColestasisNo = OAActualColestasisNo;
				
			item.OAAntecedenteMortPerinatalRecurrenteSi = OAAntecedenteMortPerinatalRecurrenteSi;
				
			item.OAAntecedenteMortPerinatalRecurrenteNo = OAAntecedenteMortPerinatalRecurrenteNo;
				
			item.OAAntecedenteRetencionPlacentaSi = OAAntecedenteRetencionPlacentaSi;
				
			item.OAAntecedenteRetencionPlacentaNo = OAAntecedenteRetencionPlacentaNo;
				
			item.OAAntecedenteDistociaHombrosSi = OAAntecedenteDistociaHombrosSi;
				
			item.OAAntecedenteDistociaHombrosNo = OAAntecedenteDistociaHombrosNo;
				
			item.OAAntecedenteMalformCongenSi = OAAntecedenteMalformCongenSi;
				
			item.OAAntecedenteMalformCongenNo = OAAntecedenteMalformCongenNo;
				
			item.FactorRiesgoEmbarazoSinContSocialSi = FactorRiesgoEmbarazoSinContSocialSi;
				
			item.FactorRiesgoEmbarazoSinContSocialNo = FactorRiesgoEmbarazoSinContSocialNo;
				
			item.FactorRiesgoFamiliaSinIngresosFijosSi = FactorRiesgoFamiliaSinIngresosFijosSi;
				
			item.FactorRiesgoFamiliaSinIngresosFijosNo = FactorRiesgoFamiliaSinIngresosFijosNo;
				
			item.FactorRiesgoEmbarazoFuertRechazadoSi = FactorRiesgoEmbarazoFuertRechazadoSi;
				
			item.FactorRiesgoEmbarazoFuertRechazadoNo = FactorRiesgoEmbarazoFuertRechazadoNo;
				
			item.FactorRiesgoHijosDadosAdopcionSi = FactorRiesgoHijosDadosAdopcionSi;
				
			item.FactorRiesgoHijosDadosAdopcionNo = FactorRiesgoHijosDadosAdopcionNo;
				
			item.FactorRiesgoViviendaSinServiciosBasicosSi = FactorRiesgoViviendaSinServiciosBasicosSi;
				
			item.FactorRiesgoViviendaSinServiciosBasicosNo = FactorRiesgoViviendaSinServiciosBasicosNo;
				
			item.CaptacionOportunaAntes16sem = CaptacionOportunaAntes16sem;
				
			item.CaptacionOportunaDespues16sem = CaptacionOportunaDespues16sem;
				
			item.FechaMuestraPAP = FechaMuestraPAP;
				
			item.FechaTripleAcelular = FechaTripleAcelular;
				
			item.FechaAntigripal = FechaAntigripal;
				
			item.VIHSegundaMuestraSolicitadoSi = VIHSegundaMuestraSolicitadoSi;
				
			item.VIHSegundaMuestraSolicitadoNo = VIHSegundaMuestraSolicitadoNo;
				
			item.VIHSegundaMuestraRealizadoSi = VIHSegundaMuestraRealizadoSi;
				
			item.VIHSegundaMuestraRealizadoNo = VIHSegundaMuestraRealizadoNo;
				
			item.VIHSegundaMuestraFecha = VIHSegundaMuestraFecha;
				
			item.VIHTercerMuestraSolicitadoSi = VIHTercerMuestraSolicitadoSi;
				
			item.VIHTercerMuestraSolicitadoNo = VIHTercerMuestraSolicitadoNo;
				
			item.VIHTercerMuestraRealizadoSi = VIHTercerMuestraRealizadoSi;
				
			item.VIHTercerMuestraRealizadoNo = VIHTercerMuestraRealizadoNo;
				
			item.VIHTercerMuestraFecha = VIHTercerMuestraFecha;
				
			item.SifilisPruebaNoTrepoPrimerMuestra = SifilisPruebaNoTrepoPrimerMuestra;
				
			item.SifilisPruebaNoTrepoPrimerMuestraNegativo = SifilisPruebaNoTrepoPrimerMuestraNegativo;
				
			item.SifilisPruebaNoTrepoPrimerMuestraPositivo = SifilisPruebaNoTrepoPrimerMuestraPositivo;
				
			item.SifilisPruebaNoTrepoPrimerMuestraSinDatos = SifilisPruebaNoTrepoPrimerMuestraSinDatos;
				
			item.SifilisPruebaNoTrepoPrimerMuestraFecha = SifilisPruebaNoTrepoPrimerMuestraFecha;
				
			item.SifilisPruebaNoTrepoSegundaMuestra = SifilisPruebaNoTrepoSegundaMuestra;
				
			item.SifilisPruebaNoTrepoSegundaMuestraNegativo = SifilisPruebaNoTrepoSegundaMuestraNegativo;
				
			item.SifilisPruebaNoTrepoSegundaMuestraPositivo = SifilisPruebaNoTrepoSegundaMuestraPositivo;
				
			item.SifilisPruebaNoTrepoSegundaMuestraSinDatos = SifilisPruebaNoTrepoSegundaMuestraSinDatos;
				
			item.SifilisPruebaNoTrepoSegundaMuestraFecha = SifilisPruebaNoTrepoSegundaMuestraFecha;
				
			item.SifilisPruebaNoTrepoTercerMuestra = SifilisPruebaNoTrepoTercerMuestra;
				
			item.SifilisPruebaNoTrepoTercerMuestraNegativo = SifilisPruebaNoTrepoTercerMuestraNegativo;
				
			item.SifilisPruebaNoTrepoTercerMuestraPositivo = SifilisPruebaNoTrepoTercerMuestraPositivo;
				
			item.SifilisPruebaNoTrepoTercerMuestraSinDatos = SifilisPruebaNoTrepoTercerMuestraSinDatos;
				
			item.SifilisPruebaNoTrepoTercerMuestraFecha = SifilisPruebaNoTrepoTercerMuestraFecha;
				
			item.SifilisPruebaTrepoPrimerMuestra = SifilisPruebaTrepoPrimerMuestra;
				
			item.SifilisPruebaTrepoPrimerMuestraNegativo = SifilisPruebaTrepoPrimerMuestraNegativo;
				
			item.SifilisPruebaTrepoPrimerMuestraPositivo = SifilisPruebaTrepoPrimerMuestraPositivo;
				
			item.SifilisPruebaTrepoPrimerMuestraSinDatos = SifilisPruebaTrepoPrimerMuestraSinDatos;
				
			item.SifilisPruebaTrepoPrimerMuestraNoCorresponde = SifilisPruebaTrepoPrimerMuestraNoCorresponde;
				
			item.SifilisPruebaTrepoPrimerMuestraFecha = SifilisPruebaTrepoPrimerMuestraFecha;
				
			item.SifilisPruebaTrepoSegundaMuestra = SifilisPruebaTrepoSegundaMuestra;
				
			item.SifilisPruebaTrepoSegundaMuestraNegativo = SifilisPruebaTrepoSegundaMuestraNegativo;
				
			item.SifilisPruebaTrepoSegundaMuestraPositivo = SifilisPruebaTrepoSegundaMuestraPositivo;
				
			item.SifilisPruebaTrepoSegundaMuestraSinDatos = SifilisPruebaTrepoSegundaMuestraSinDatos;
				
			item.SifilisPruebaTrepoSegundaMuestraNoCorresponde = SifilisPruebaTrepoSegundaMuestraNoCorresponde;
				
			item.SifilisPruebaTrepoSegundaMuestraFecha = SifilisPruebaTrepoSegundaMuestraFecha;
				
			item.SifilisPruebaTrepoTercerMuestra = SifilisPruebaTrepoTercerMuestra;
				
			item.SifilisPruebaTrepoTercerMuestraNegativo = SifilisPruebaTrepoTercerMuestraNegativo;
				
			item.SifilisPruebaTrepoTercerMuestraPositivo = SifilisPruebaTrepoTercerMuestraPositivo;
				
			item.SifilisPruebaTrepoTercerMuestraSinDatos = SifilisPruebaTrepoTercerMuestraSinDatos;
				
			item.SifilisPruebaTrepoTercerMuestraNoCorresponde = SifilisPruebaTrepoTercerMuestraNoCorresponde;
				
			item.SifilisPruebaTrepoTercerMuestraFecha = SifilisPruebaTrepoTercerMuestraFecha;
				
			item.SifilisTratamientoPrimerMuestra = SifilisTratamientoPrimerMuestra;
				
			item.SifilisTratamientoPrimerMuestraNo = SifilisTratamientoPrimerMuestraNo;
				
			item.SifilisTratamientoPrimerMuestraSi = SifilisTratamientoPrimerMuestraSi;
				
			item.SifilisTratamientoPrimerMuestraSinDatos = SifilisTratamientoPrimerMuestraSinDatos;
				
			item.SifilisTratamientoPrimerMuestraNoCorresponde = SifilisTratamientoPrimerMuestraNoCorresponde;
				
			item.SifilisTratamientoPrimerMuestraFecha = SifilisTratamientoPrimerMuestraFecha;
				
			item.SifilisTratamientoSegundaMuestra = SifilisTratamientoSegundaMuestra;
				
			item.SifilisTratamientoSegundaMuestraNo = SifilisTratamientoSegundaMuestraNo;
				
			item.SifilisTratamientoSegundaMuestraSi = SifilisTratamientoSegundaMuestraSi;
				
			item.SifilisTratamientoSegundaMuestraSinDatos = SifilisTratamientoSegundaMuestraSinDatos;
				
			item.SifilisTratamientoSegundaMuestraNoCorresponde = SifilisTratamientoSegundaMuestraNoCorresponde;
				
			item.SifilisTratamientoSegundaMuestraFecha = SifilisTratamientoSegundaMuestraFecha;
				
			item.SifilisTratamientoTercerMuestra = SifilisTratamientoTercerMuestra;
				
			item.SifilisTratamientoTercerMuestraNo = SifilisTratamientoTercerMuestraNo;
				
			item.SifilisTratamientoTercerMuestraSi = SifilisTratamientoTercerMuestraSi;
				
			item.SifilisTratamientoTercerMuestraSinDatos = SifilisTratamientoTercerMuestraSinDatos;
				
			item.SifilisTratamientoTercerMuestraNoCorresponde = SifilisTratamientoTercerMuestraNoCorresponde;
				
			item.SifilisTratamientoTercerMuestraFecha = SifilisTratamientoTercerMuestraFecha;
				
			item.Activa = Activa;
				
			item.Observaciones = Observaciones;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdEfectorTrasladoUt = IdEfectorTrasladoUt;
				
			item.DiabetesActualSi = DiabetesActualSi;
				
			item.DiabetesActualNo = DiabetesActualNo;
				
			item.AnemiaSi = AnemiaSi;
				
			item.AnemiaNo = AnemiaNo;
				
			item.NumeroIdentidad = NumeroIdentidad;
				
	        item.Save(UserName);
	    }
    }
}
