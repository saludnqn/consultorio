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
namespace DalSic{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the ActualizaHCNueva Procedure
        /// </summary>
        public static StoredProcedure ActualizaHCNueva()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ActualizaHCNueva", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AltaPacientes Procedure
        /// </summary>
        public static StoredProcedure AltaPacientes(int? idPaciente, int? idEfector, string apellido, string nombre, int? idTipoDocumento, int? numeroDocumento, string sexo, DateTime? fechaNacimiento, int? idPais, int? idNivelInstrucccion, int? idSituacionLaboral, int? idProfesion, string calle, int? numero, string piso, string departamento, int? idProvincia, int? idLocalidad, int? idBarrio, string referencia, string telefono1, string telefono2, int? idParentesco, int? idObraSocial, int? idEstadoPaciente, string createdBy, DateTime? createdOn, string modifiedBy, DateTime? modifiedOn)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AltaPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.String, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.String, null, null);
        	
            sp.Command.AddParameter("@idTipoDocumento", idTipoDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@sexo", sexo, DbType.String, null, null);
        	
            sp.Command.AddParameter("@fechaNacimiento", fechaNacimiento, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idPais", idPais, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idNivelInstrucccion", idNivelInstrucccion, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idSituacionLaboral", idSituacionLaboral, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesion", idProfesion, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@calle", calle, DbType.String, null, null);
        	
            sp.Command.AddParameter("@numero", numero, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@piso", piso, DbType.String, null, null);
        	
            sp.Command.AddParameter("@departamento", departamento, DbType.String, null, null);
        	
            sp.Command.AddParameter("@idProvincia", idProvincia, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idLocalidad", idLocalidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idBarrio", idBarrio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@referencia", referencia, DbType.String, null, null);
        	
            sp.Command.AddParameter("@telefono1", telefono1, DbType.String, null, null);
        	
            sp.Command.AddParameter("@telefono2", telefono2, DbType.String, null, null);
        	
            sp.Command.AddParameter("@idParentesco", idParentesco, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idObraSocial", idObraSocial, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstadoPaciente", idEstadoPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@createdBy", createdBy, DbType.String, null, null);
        	
            sp.Command.AddParameter("@createdOn", createdOn, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@modifiedBy", modifiedBy, DbType.String, null, null);
        	
            sp.Command.AddParameter("@modifiedOn", modifiedOn, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_AlertaCtrolPerinatal Procedure
        /// </summary>
        public static StoredProcedure AprAlertaCtrolPerinatal(int? idHistoriaClinicaPerinatal)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_AlertaCtrolPerinatal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHistoriaClinicaPerinatal", idHistoriaClinicaPerinatal, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_CalendarioVacunacion Procedure
        /// </summary>
        public static StoredProcedure AprCalendarioVacunacion()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_CalendarioVacunacion", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_CPFechas Procedure
        /// </summary>
        public static StoredProcedure AprCPFechas(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_CPFechas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetActividadFisica Procedure
        /// </summary>
        public static StoredProcedure AprGetActividadFisica(int? efector, DateTime? finicio, DateTime? ffin, int? dni, int? riesgo, string apto)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetActividadFisica", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@riesgo", riesgo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@apto", apto, DbType.AnsiStringFixedLength, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetAlertaCM Procedure
        /// </summary>
        public static StoredProcedure AprGetAlertaCM()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetAlertaCM", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetAlertaCP Procedure
        /// </summary>
        public static StoredProcedure AprGetAlertaCP(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetAlertaCP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetConsolidado Procedure
        /// </summary>
        public static StoredProcedure AprGetConsolidado(string fechaD, string fechaH, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetConsolidado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fechaD", fechaD, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaH", fechaH, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetControlEnfermeria Procedure
        /// </summary>
        public static StoredProcedure AprGetControlEnfermeria(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetControlEnfermeria", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetEvaluacionControlPerinatal Procedure
        /// </summary>
        public static StoredProcedure AprGetEvaluacionControlPerinatal(DateTime? finicio, DateTime? ffin, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetEvaluacionControlPerinatal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetEvaluacionControlPerinatal_old Procedure
        /// </summary>
        public static StoredProcedure AprGetEvaluacionControlPerinatalOld(DateTime? finicio, DateTime? ffin, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetEvaluacionControlPerinatal_old", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetEvaluacionIndividual Procedure
        /// </summary>
        public static StoredProcedure AprGetEvaluacionIndividual(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetEvaluacionIndividual", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetHCP_Detalle Procedure
        /// </summary>
        public static StoredProcedure AprGetHCPDetalle(int? idHCP)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetHCP_Detalle", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHCP", idHCP, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetMaxPerimetroCefalico Procedure
        /// </summary>
        public static StoredProcedure AprGetMaxPerimetroCefalico(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetMaxPerimetroCefalico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetMenorControl Procedure
        /// </summary>
        public static StoredProcedure AprGetMenorControl(int? numerodoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetMenorControl", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numerodoc", numerodoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPaciente Procedure
        /// </summary>
        public static StoredProcedure AprGetPaciente(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPacientesConHCP Procedure
        /// </summary>
        public static StoredProcedure AprGetPacientesConHCP(int? numeroIdPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPacientesConHCP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroIdPaciente", numeroIdPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPacientesConHCP_2 Procedure
        /// </summary>
        public static StoredProcedure AprGetPacientesConHCP2(int? numerodoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPacientesConHCP_2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numerodoc", numerodoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPacientesMenores Procedure
        /// </summary>
        public static StoredProcedure AprGetPacientesMenores(int? numerodoc, string nombre, string apellido, DateTime? fnacimiento, string parentNombre, string parentApellido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPacientesMenores", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numerodoc", numerodoc, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fnacimiento", fnacimiento, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@parentNombre", parentNombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@parentApellido", parentApellido, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPacientesPorNombres Procedure
        /// </summary>
        public static StoredProcedure AprGetPacientesPorNombres(DateTime? fnacimiento, string nombre, string apellido, int? dni, string parentNombre, string parentApellido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPacientesPorNombres", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fnacimiento", fnacimiento, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@parentNombre", parentNombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@parentApellido", parentApellido, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPercentilesEstaturaEdadMas24meses Procedure
        /// </summary>
        public static StoredProcedure AprGetPercentilesEstaturaEdadMas24meses(int? idSexo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPercentilesEstaturaEdadMas24meses", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPercentilesIMCEdadMas24meses Procedure
        /// </summary>
        public static StoredProcedure AprGetPercentilesIMCEdadMas24meses(int? idSexo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPercentilesIMCEdadMas24meses", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPercentilesLongitudEdadHasta24meses Procedure
        /// </summary>
        public static StoredProcedure AprGetPercentilesLongitudEdadHasta24meses(int? idSexo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPercentilesLongitudEdadHasta24meses", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPercentilesPerimetroCefalicoEdadHasta24meses Procedure
        /// </summary>
        public static StoredProcedure AprGetPercentilesPerimetroCefalicoEdadHasta24meses(int? idSexo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPercentilesPerimetroCefalicoEdadHasta24meses", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPercentilesPerimetroCefalicoEdadMas24meses Procedure
        /// </summary>
        public static StoredProcedure AprGetPercentilesPerimetroCefalicoEdadMas24meses(int? idSexo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPercentilesPerimetroCefalicoEdadMas24meses", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPercentilesPesoEdadHasta24meses Procedure
        /// </summary>
        public static StoredProcedure AprGetPercentilesPesoEdadHasta24meses(int? idSexo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPercentilesPesoEdadHasta24meses", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPercentilesPesoEdadMas24meses Procedure
        /// </summary>
        public static StoredProcedure AprGetPercentilesPesoEdadMas24meses(int? idSexo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPercentilesPesoEdadMas24meses", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetPlotData Procedure
        /// </summary>
        public static StoredProcedure AprGetPlotData(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetPlotData", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_GetVacunas Procedure
        /// </summary>
        public static StoredProcedure AprGetVacunas(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_GetVacunas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_PacientesConHCP Procedure
        /// </summary>
        public static StoredProcedure AprPacientesConHCP(int? efector, int? dni, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_PacientesConHCP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_PC_EdadPromedioPrimeraVisita Procedure
        /// </summary>
        public static StoredProcedure AprPcEdadPromedioPrimeraVisita(int? edadDesde, int? edadHasta, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_PC_EdadPromedioPrimeraVisita", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@edadDesde", edadDesde, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@edadHasta", edadHasta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_PC_NiñosBajoPrograma Procedure
        /// </summary>
        public static StoredProcedure AprPcNiñosBajoPrograma(int? edadDesde, int? edadHasta, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_PC_NiñosBajoPrograma", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@edadDesde", edadDesde, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@edadHasta", edadHasta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_PC_PorcentajePrimerVisitaAntes15Dias Procedure
        /// </summary>
        public static StoredProcedure AprPcPorcentajePrimerVisitaAntes15Dias(int? edadDesde, int? edadHasta, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_PC_PorcentajePrimerVisitaAntes15Dias", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@edadDesde", edadDesde, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@edadHasta", edadHasta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_PC_PromedioVisitasPorNiño Procedure
        /// </summary>
        public static StoredProcedure AprPcPromedioVisitasPorNiño(int? edadDesde, int? edadHasta, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_PC_PromedioVisitasPorNiño", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@edadDesde", edadDesde, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@edadHasta", edadHasta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the APR_ScoreBPN Procedure
        /// </summary>
        public static StoredProcedure AprScoreBPN(int? idHistoriaClinicaPerinatal, DateTime? fechacontrol)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("APR_ScoreBPN", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHistoriaClinicaPerinatal", idHistoriaClinicaPerinatal, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechacontrol", fechacontrol, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_AnyDataInTables Procedure
        /// </summary>
        public static StoredProcedure AspnetAnyDataInTables(int? TablesToCheck)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_AnyDataInTables", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@TablesToCheck", TablesToCheck, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Applications_CreateApplication Procedure
        /// </summary>
        public static StoredProcedure AspnetApplicationsCreateApplication(string ApplicationName, Guid? ApplicationId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Applications_CreateApplication", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddOutputParameter("@ApplicationId", DbType.Guid, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_CheckSchemaVersion Procedure
        /// </summary>
        public static StoredProcedure AspnetCheckSchemaVersion(string Feature, string CompatibleSchemaVersion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_CheckSchemaVersion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Feature", Feature, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CompatibleSchemaVersion", CompatibleSchemaVersion, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_ChangePasswordQuestionAndAnswer Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipChangePasswordQuestionAndAnswer(string ApplicationName, string UserName, string NewPasswordQuestion, string NewPasswordAnswer)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_ChangePasswordQuestionAndAnswer", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@NewPasswordQuestion", NewPasswordQuestion, DbType.String, null, null);
        	
            sp.Command.AddParameter("@NewPasswordAnswer", NewPasswordAnswer, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_CreateUser Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipCreateUser(string ApplicationName, string UserName, string Password, string PasswordSalt, string Email, string PasswordQuestion, string PasswordAnswer, bool? IsApproved, DateTime? CurrentTimeUtc, DateTime? CreateDate, int? UniqueEmail, int? PasswordFormat, Guid? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_CreateUser", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Password", Password, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PasswordSalt", PasswordSalt, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Email", Email, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PasswordQuestion", PasswordQuestion, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PasswordAnswer", PasswordAnswer, DbType.String, null, null);
        	
            sp.Command.AddParameter("@IsApproved", IsApproved, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@CreateDate", CreateDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@UniqueEmail", UniqueEmail, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PasswordFormat", PasswordFormat, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@UserId", DbType.Guid, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_FindUsersByEmail Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipFindUsersByEmail(string ApplicationName, string EmailToMatch, int? PageIndex, int? PageSize)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_FindUsersByEmail", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@EmailToMatch", EmailToMatch, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PageIndex", PageIndex, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PageSize", PageSize, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_FindUsersByName Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipFindUsersByName(string ApplicationName, string UserNameToMatch, int? PageIndex, int? PageSize)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_FindUsersByName", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserNameToMatch", UserNameToMatch, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PageIndex", PageIndex, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PageSize", PageSize, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetAllUsers Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetAllUsers(string ApplicationName, int? PageIndex, int? PageSize)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetAllUsers", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PageIndex", PageIndex, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PageSize", PageSize, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetNumberOfUsersOnline Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetNumberOfUsersOnline(string ApplicationName, int? MinutesSinceLastInActive, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetNumberOfUsersOnline", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@MinutesSinceLastInActive", MinutesSinceLastInActive, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetPassword Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetPassword(string ApplicationName, string UserName, int? MaxInvalidPasswordAttempts, int? PasswordAttemptWindow, DateTime? CurrentTimeUtc, string PasswordAnswer)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetPassword", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@MaxInvalidPasswordAttempts", MaxInvalidPasswordAttempts, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PasswordAttemptWindow", PasswordAttemptWindow, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@PasswordAnswer", PasswordAnswer, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetPasswordWithFormat Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetPasswordWithFormat(string ApplicationName, string UserName, bool? UpdateLastLoginActivityDate, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetPasswordWithFormat", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UpdateLastLoginActivityDate", UpdateLastLoginActivityDate, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetUserByEmail Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetUserByEmail(string ApplicationName, string Email)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetUserByEmail", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Email", Email, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetUserByName Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetUserByName(string ApplicationName, string UserName, DateTime? CurrentTimeUtc, bool? UpdateLastActivity)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetUserByName", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@UpdateLastActivity", UpdateLastActivity, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetUserByUserId Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetUserByUserId(Guid? UserId, DateTime? CurrentTimeUtc, bool? UpdateLastActivity)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetUserByUserId", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@UserId", UserId, DbType.Guid, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@UpdateLastActivity", UpdateLastActivity, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_ResetPassword Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipResetPassword(string ApplicationName, string UserName, string NewPassword, int? MaxInvalidPasswordAttempts, int? PasswordAttemptWindow, string PasswordSalt, DateTime? CurrentTimeUtc, int? PasswordFormat, string PasswordAnswer)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_ResetPassword", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@NewPassword", NewPassword, DbType.String, null, null);
        	
            sp.Command.AddParameter("@MaxInvalidPasswordAttempts", MaxInvalidPasswordAttempts, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PasswordAttemptWindow", PasswordAttemptWindow, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PasswordSalt", PasswordSalt, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@PasswordFormat", PasswordFormat, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PasswordAnswer", PasswordAnswer, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_SetPassword Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipSetPassword(string ApplicationName, string UserName, string NewPassword, string PasswordSalt, DateTime? CurrentTimeUtc, int? PasswordFormat)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_SetPassword", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@NewPassword", NewPassword, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PasswordSalt", PasswordSalt, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@PasswordFormat", PasswordFormat, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_UnlockUser Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipUnlockUser(string ApplicationName, string UserName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_UnlockUser", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_UpdateUser Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipUpdateUser(string ApplicationName, string UserName, string Email, string Comment, bool? IsApproved, DateTime? LastLoginDate, DateTime? LastActivityDate, int? UniqueEmail, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_UpdateUser", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Email", Email, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Comment", Comment, DbType.String, null, null);
        	
            sp.Command.AddParameter("@IsApproved", IsApproved, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@LastLoginDate", LastLoginDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@LastActivityDate", LastActivityDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@UniqueEmail", UniqueEmail, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_UpdateUserInfo Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipUpdateUserInfo(string ApplicationName, string UserName, bool? IsPasswordCorrect, bool? UpdateLastLoginActivityDate, int? MaxInvalidPasswordAttempts, int? PasswordAttemptWindow, DateTime? CurrentTimeUtc, DateTime? LastLoginDate, DateTime? LastActivityDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_UpdateUserInfo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@IsPasswordCorrect", IsPasswordCorrect, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@UpdateLastLoginActivityDate", UpdateLastLoginActivityDate, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@MaxInvalidPasswordAttempts", MaxInvalidPasswordAttempts, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PasswordAttemptWindow", PasswordAttemptWindow, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@LastLoginDate", LastLoginDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@LastActivityDate", LastActivityDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Paths_CreatePath Procedure
        /// </summary>
        public static StoredProcedure AspnetPathsCreatePath(Guid? ApplicationId, string Path, Guid? PathId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Paths_CreatePath", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationId", ApplicationId, DbType.Guid, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            sp.Command.AddOutputParameter("@PathId", DbType.Guid, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Personalization_GetApplicationId Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationGetApplicationId(string ApplicationName, Guid? ApplicationId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Personalization_GetApplicationId", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddOutputParameter("@ApplicationId", DbType.Guid, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_DeleteAllState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationDeleteAllState(bool? AllUsersScope, string ApplicationName, int? Count)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_DeleteAllState", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@AllUsersScope", AllUsersScope, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddOutputParameter("@Count", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_FindState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationFindState(bool? AllUsersScope, string ApplicationName, int? PageIndex, int? PageSize, string Path, string UserName, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_FindState", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@AllUsersScope", AllUsersScope, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PageIndex", PageIndex, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PageSize", PageSize, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_GetCountOfState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationGetCountOfState(int? Count, bool? AllUsersScope, string ApplicationName, string Path, string UserName, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_GetCountOfState", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddOutputParameter("@Count", DbType.Int32, 0, 10);
            
            sp.Command.AddParameter("@AllUsersScope", AllUsersScope, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_ResetSharedState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationResetSharedState(int? Count, string ApplicationName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_ResetSharedState", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddOutputParameter("@Count", DbType.Int32, 0, 10);
            
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_ResetUserState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationResetUserState(int? Count, string ApplicationName, DateTime? InactiveSinceDate, string UserName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_ResetUserState", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddOutputParameter("@Count", DbType.Int32, 0, 10);
            
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAllUsers_GetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAllUsersGetPageSettings(string ApplicationName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAllUsers_GetPageSettings", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAllUsers_ResetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAllUsersResetPageSettings(string ApplicationName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAllUsers_ResetPageSettings", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAllUsers_SetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAllUsersSetPageSettings(string ApplicationName, string Path, byte[] PageSettings, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAllUsers_SetPageSettings", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PageSettings", PageSettings, DbType.Binary, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationPerUser_GetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationPerUserGetPageSettings(string ApplicationName, string UserName, string Path, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationPerUser_GetPageSettings", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationPerUser_ResetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationPerUserResetPageSettings(string ApplicationName, string UserName, string Path, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationPerUser_ResetPageSettings", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationPerUser_SetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationPerUserSetPageSettings(string ApplicationName, string UserName, string Path, byte[] PageSettings, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationPerUser_SetPageSettings", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Path", Path, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PageSettings", PageSettings, DbType.Binary, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_DeleteInactiveProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileDeleteInactiveProfiles(string ApplicationName, int? ProfileAuthOptions, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_DeleteInactiveProfiles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@ProfileAuthOptions", ProfileAuthOptions, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_DeleteProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileDeleteProfiles(string ApplicationName, string UserNames)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_DeleteProfiles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserNames", UserNames, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_GetNumberOfInactiveProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileGetNumberOfInactiveProfiles(string ApplicationName, int? ProfileAuthOptions, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_GetNumberOfInactiveProfiles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@ProfileAuthOptions", ProfileAuthOptions, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_GetProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileGetProfiles(string ApplicationName, int? ProfileAuthOptions, int? PageIndex, int? PageSize, string UserNameToMatch, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_GetProfiles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@ProfileAuthOptions", ProfileAuthOptions, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PageIndex", PageIndex, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PageSize", PageSize, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@UserNameToMatch", UserNameToMatch, DbType.String, null, null);
        	
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_GetProperties Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileGetProperties(string ApplicationName, string UserName, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_GetProperties", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_SetProperties Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileSetProperties(string ApplicationName, string PropertyNames, string PropertyValuesString, byte[] PropertyValuesBinary, string UserName, bool? IsUserAnonymous, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_SetProperties", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PropertyNames", PropertyNames, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PropertyValuesString", PropertyValuesString, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PropertyValuesBinary", PropertyValuesBinary, DbType.Binary, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@IsUserAnonymous", IsUserAnonymous, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_RegisterSchemaVersion Procedure
        /// </summary>
        public static StoredProcedure AspnetRegisterSchemaVersion(string Feature, string CompatibleSchemaVersion, bool? IsCurrentVersion, bool? RemoveIncompatibleSchema)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_RegisterSchemaVersion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Feature", Feature, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CompatibleSchemaVersion", CompatibleSchemaVersion, DbType.String, null, null);
        	
            sp.Command.AddParameter("@IsCurrentVersion", IsCurrentVersion, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@RemoveIncompatibleSchema", RemoveIncompatibleSchema, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_CreateRole Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesCreateRole(string ApplicationName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_CreateRole", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleName", RoleName, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_DeleteRole Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesDeleteRole(string ApplicationName, string RoleName, bool? DeleteOnlyIfRoleIsEmpty)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_DeleteRole", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleName", RoleName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@DeleteOnlyIfRoleIsEmpty", DeleteOnlyIfRoleIsEmpty, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_GetAllRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesGetAllRoles(string ApplicationName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_GetAllRoles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_RoleExists Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesRoleExists(string ApplicationName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_RoleExists", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleName", RoleName, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Setup_RemoveAllRoleMembers Procedure
        /// </summary>
        public static StoredProcedure AspnetSetupRemoveAllRoleMembers(string name)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Setup_RemoveAllRoleMembers", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@name", name, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Setup_RestorePermissions Procedure
        /// </summary>
        public static StoredProcedure AspnetSetupRestorePermissions(string name)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Setup_RestorePermissions", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@name", name, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UnRegisterSchemaVersion Procedure
        /// </summary>
        public static StoredProcedure AspnetUnRegisterSchemaVersion(string Feature, string CompatibleSchemaVersion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UnRegisterSchemaVersion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Feature", Feature, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CompatibleSchemaVersion", CompatibleSchemaVersion, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Users_CreateUser Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersCreateUser(Guid? ApplicationId, string UserName, bool? IsUserAnonymous, DateTime? LastActivityDate, Guid? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Users_CreateUser", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationId", ApplicationId, DbType.Guid, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@IsUserAnonymous", IsUserAnonymous, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@LastActivityDate", LastActivityDate, DbType.DateTime, null, null);
        	
            sp.Command.AddOutputParameter("@UserId", DbType.Guid, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Users_DeleteUser Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersDeleteUser(string ApplicationName, string UserName, int? TablesToDeleteFrom, int? NumTablesDeletedFrom)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Users_DeleteUser", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@TablesToDeleteFrom", TablesToDeleteFrom, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@NumTablesDeletedFrom", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_AddUsersToRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesAddUsersToRoles(string ApplicationName, string UserNames, string RoleNames, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_AddUsersToRoles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserNames", UserNames, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleNames", RoleNames, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_FindUsersInRole Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesFindUsersInRole(string ApplicationName, string RoleName, string UserNameToMatch)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_FindUsersInRole", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleName", RoleName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserNameToMatch", UserNameToMatch, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_GetRolesForUser Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesGetRolesForUser(string ApplicationName, string UserName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_GetRolesForUser", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_GetUsersInRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesGetUsersInRoles(string ApplicationName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_GetUsersInRoles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleName", RoleName, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_IsUserInRole Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesIsUserInRole(string ApplicationName, string UserName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_IsUserInRole", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleName", RoleName, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_RemoveUsersFromRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesRemoveUsersFromRoles(string ApplicationName, string UserNames, string RoleNames)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_RemoveUsersFromRoles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@UserNames", UserNames, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RoleNames", RoleNames, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_WebEvent_LogEvent Procedure
        /// </summary>
        public static StoredProcedure AspnetWebEventLogEvent(string EventId, DateTime? EventTimeUtc, DateTime? EventTime, string EventType, decimal? EventSequence, decimal? EventOccurrence, int? EventCode, int? EventDetailCode, string Message, string ApplicationPath, string ApplicationVirtualPath, string MachineName, string RequestUrl, string ExceptionType, string Details)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_WebEvent_LogEvent", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@EventId", EventId, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@EventTimeUtc", EventTimeUtc, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@EventTime", EventTime, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@EventType", EventType, DbType.String, null, null);
        	
            sp.Command.AddParameter("@EventSequence", EventSequence, DbType.Decimal, 0, 19);
        	
            sp.Command.AddParameter("@EventOccurrence", EventOccurrence, DbType.Decimal, 0, 19);
        	
            sp.Command.AddParameter("@EventCode", EventCode, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@EventDetailCode", EventDetailCode, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Message", Message, DbType.String, null, null);
        	
            sp.Command.AddParameter("@ApplicationPath", ApplicationPath, DbType.String, null, null);
        	
            sp.Command.AddParameter("@ApplicationVirtualPath", ApplicationVirtualPath, DbType.String, null, null);
        	
            sp.Command.AddParameter("@MachineName", MachineName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@RequestUrl", RequestUrl, DbType.String, null, null);
        	
            sp.Command.AddParameter("@ExceptionType", ExceptionType, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Details", Details, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_BuscaVehiculo Procedure
        /// </summary>
        public static StoredProcedure AutBuscaVehiculo(string idVehiculo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_BuscaVehiculo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Chofer_Ordenado Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboChoferOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Chofer_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Destino Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboDestino()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Destino", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Entidades_Ordenado_Para_Hospital Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboEntidadesOrdenadoParaHospital(int? idEntidad)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Entidades_Ordenado_Para_Hospital", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Entidades_Ordenado_Para_Subsecretaria Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboEntidadesOrdenadoParaSubsecretaria()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Entidades_Ordenado_Para_Subsecretaria", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Entidades_Ordenado_Para_Zona Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboEntidadesOrdenadoParaZona(int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Entidades_Ordenado_Para_Zona", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Establecimientos Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboEstablecimientos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Establecimientos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_ItemMovimiento_Ordenado Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboItemMovimientoOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_ItemMovimiento_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_ItemsMovimientos_Desde_Movimientos Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboItemsMovimientosDesdeMovimientos(string idMovimiento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_ItemsMovimientos_Desde_Movimientos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idMovimiento", idMovimiento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_ItemsMovimientos_Desde_PMP Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboItemsMovimientosDesdePmp(string idPMP)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_ItemsMovimientos_Desde_PMP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPMP", idPMP, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Marcas_Ordenado Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboMarcasOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Marcas_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Modelos_Ordenado Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboModelosOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Modelos_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Modelos_Ordenado2 Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboModelosOrdenado2()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Modelos_Ordenado2", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_OrigenDestino_Ordenado Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboOrigenDestinoOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_OrigenDestino_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_PMP_Desde_Vehiculo Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboPmpDesdeVehiculo(int? idVehiculo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_PMP_Desde_Vehiculo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Proveedores_Ordenado Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboProveedoresOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Proveedores_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Tipo_Movimiento_Ordenado Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboTipoMovimientoOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Tipo_Movimiento_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Cargar_Combo_Zona Procedure
        /// </summary>
        public static StoredProcedure AutCargarComboZona()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Cargar_Combo_Zona", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_ComboNotaPedido Procedure
        /// </summary>
        public static StoredProcedure AutComboNotaPedido()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_ComboNotaPedido", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_ComboVehiculoORep Procedure
        /// </summary>
        public static StoredProcedure AutComboVehiculoORep()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_ComboVehiculoORep", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_delete_VehiculoPMP Procedure
        /// </summary>
        public static StoredProcedure AutDeleteVehiculoPMP(int? idVehiculo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_delete_VehiculoPMP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Accidentes Procedure
        /// </summary>
        public static StoredProcedure AutListAccidentes(int? idVehiculo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Accidentes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Choferes Procedure
        /// </summary>
        public static StoredProcedure AutListChoferes(string apellido, string nombre, string documento, string legajo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Choferes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@documento", documento, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@legajo", legajo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Direcciones Procedure
        /// </summary>
        public static StoredProcedure AutListDirecciones(string Direccion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Direcciones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Direccion", Direccion, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Entidades Procedure
        /// </summary>
        public static StoredProcedure AutListEntidades(string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Entidades", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_ItemDeMovimientos Procedure
        /// </summary>
        public static StoredProcedure AutListItemDeMovimientos(string itemdemovimiento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_ItemDeMovimientos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@itemdemovimiento", itemdemovimiento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Marcas Procedure
        /// </summary>
        public static StoredProcedure AutListMarcas(string marca)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Marcas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@marca", marca, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_ModelosMarcas Procedure
        /// </summary>
        public static StoredProcedure AutListModelosMarcas(string modelo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_ModelosMarcas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@modelo", modelo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_MovimientosVehiculo Procedure
        /// </summary>
        public static StoredProcedure AutListMovimientosVehiculo(string idVehiculo, string fechaDesde, string fechaHasta, string idTipoMovimiento, string idProveedor)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_MovimientosVehiculo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaDesde", fechaDesde, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaHasta", fechaHasta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idTipoMovimiento", idTipoMovimiento, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idProveedor", idProveedor, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_OrigenDestino Procedure
        /// </summary>
        public static StoredProcedure AutListOrigenDestino(string origenDestino)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_OrigenDestino", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@origenDestino", origenDestino, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_PMP Procedure
        /// </summary>
        public static StoredProcedure AutListPmp(string pmp)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_PMP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pmp", pmp, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Proveedores Procedure
        /// </summary>
        public static StoredProcedure AutListProveedores(string nombre, string cuit)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Proveedores", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@cuit", cuit, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_TiposDeMovimiento Procedure
        /// </summary>
        public static StoredProcedure AutListTiposDeMovimiento(string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_TiposDeMovimiento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_TiposDeVehiculo Procedure
        /// </summary>
        public static StoredProcedure AutListTiposDeVehiculo(string tipoDeVehiculo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_TiposDeVehiculo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@tipoDeVehiculo", tipoDeVehiculo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_UnMovimientoConSusItems Procedure
        /// </summary>
        public static StoredProcedure AutListUnMovimientoConSusItems(int? idMovimiento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_UnMovimientoConSusItems", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idMovimiento", idMovimiento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_UnPMPConSusItems Procedure
        /// </summary>
        public static StoredProcedure AutListUnPMPConSusItems(int? idPMP)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_UnPMPConSusItems", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPMP", idPMP, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_UnVehiculoConSusHistoricosDePMP Procedure
        /// </summary>
        public static StoredProcedure AutListUnVehiculoConSusHistoricosDePMP(int? idVehiculoPMP, int? idVehiculo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_UnVehiculoConSusHistoricosDePMP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculoPMP", idVehiculoPMP, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_UnVehiculoConSusPMP Procedure
        /// </summary>
        public static StoredProcedure AutListUnVehiculoConSusPMP(int? idVehiculo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_UnVehiculoConSusPMP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Vehiculos Procedure
        /// </summary>
        public static StoredProcedure AutListVehiculos(string dominio, string comienzaCon, string tipoVehiculo, string efector, string zona, string marca, string modelo, string estado, int? idEntidad, int? idTipoEntidad, int? idZonaDeLaEntidad)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Vehiculos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dominio", dominio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@comienzaCon", comienzaCon, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@tipoVehiculo", tipoVehiculo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@zona", zona, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@marca", marca, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@modelo", modelo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@estado", estado, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoEntidad", idTipoEntidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZonaDeLaEntidad", idZonaDeLaEntidad, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Vehiculos_dani Procedure
        /// </summary>
        public static StoredProcedure AutListVehiculosDani(string dominio, string idEntidad, string idzona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Vehiculos_dani", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dominio", dominio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idzona", idzona, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Vehiculos_Radio Procedure
        /// </summary>
        public static StoredProcedure AutListVehiculosRadio(string dominio, string idEntidad, string idzona, string idMarca, string idModelo, string idTipoVehiculo, string tieneRadio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Vehiculos_Radio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dominio", dominio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idzona", idzona, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idMarca", idMarca, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idModelo", idModelo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idTipoVehiculo", idTipoVehiculo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@tieneRadio", tieneRadio, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_List_Viajes Procedure
        /// </summary>
        public static StoredProcedure AutListViajes(int? idVehiculo, string fechaInicio, string fechaFin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_List_Viajes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechaInicio", fechaInicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaFin", fechaFin, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_ListOrdenRep Procedure
        /// </summary>
        public static StoredProcedure AutListOrdenRep(int? idZona, int? idEntidad, DateTime? DesdeFecha, DateTime? HastaFecha, int? idVehiculo, int? idProveedor, string Estado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_ListOrdenRep", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@DesdeFecha", DesdeFecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@HastaFecha", HastaFecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProveedor", idProveedor, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Estado", Estado, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Obtener_Fecha_Maxima_Historico_PMP Procedure
        /// </summary>
        public static StoredProcedure AutObtenerFechaMaximaHistoricoPmp(string dominio, string tipoVehiculo, string efector, string zona, string marca, string modelo, int? idEntidad, int? idTipoEntidad, int? idZonaDeLaEntidad)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Obtener_Fecha_Maxima_Historico_PMP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dominio", dominio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@tipoVehiculo", tipoVehiculo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@zona", zona, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@marca", marca, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@modelo", modelo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoEntidad", idTipoEntidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZonaDeLaEntidad", idZonaDeLaEntidad, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUT_Obtener_Permisos_Usuario Procedure
        /// </summary>
        public static StoredProcedure AutObtenerPermisosUsuario(int? idperfil, int? idefector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUT_Obtener_Permisos_Usuario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUTCargarComboTipoTraslado Procedure
        /// </summary>
        public static StoredProcedure AUTCargarComboTipoTraslado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUTCargarComboTipoTraslado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AutListadoVehiculo Procedure
        /// </summary>
        public static StoredProcedure AutListadoVehiculo(int? wZona, int? wEntidad, string wCondicion, string wEstado, string Orden)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AutListadoVehiculo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@wZona", wZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@wEntidad", wEntidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@wCondicion", wCondicion, DbType.String, null, null);
        	
            sp.Command.AddParameter("@wEstado", wEstado, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Orden", Orden, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUTP_BuscaNotaPedido Procedure
        /// </summary>
        public static StoredProcedure AutpBuscaNotaPedido(string idNotaPedido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUTP_BuscaNotaPedido", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idNotaPedido", idNotaPedido, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUTP_BuscaNotaPedidoORep Procedure
        /// </summary>
        public static StoredProcedure AutpBuscaNotaPedidoORep(string idNotaPedido, string idOrdenReparacion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUTP_BuscaNotaPedidoORep", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idNotaPedido", idNotaPedido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idOrdenReparacion", idOrdenReparacion, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUTP_ListOrdenReparacion Procedure
        /// </summary>
        public static StoredProcedure AutpListOrdenReparacion(string idOrdenReparacion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUTP_ListOrdenReparacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idOrdenReparacion", idOrdenReparacion, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUTP_NotaPedido Procedure
        /// </summary>
        public static StoredProcedure AutpNotaPedido(string dominio, string idEntidad, string idzona, string TipoSolicitud, string Expediente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUTP_NotaPedido", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dominio", dominio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idzona", idzona, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@TipoSolicitud", TipoSolicitud, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Expediente", Expediente, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUTp_OrdenReparacion Procedure
        /// </summary>
        public static StoredProcedure AUTpOrdenReparacion(string dominio, string idEntidad, string idNotaPedido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUTp_OrdenReparacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dominio", dominio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idNotaPedido", idNotaPedido, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the AUTp_OrdenReparacionItem Procedure
        /// </summary>
        public static StoredProcedure AUTpOrdenReparacionItem(int? idZona, int? idEntidad, DateTime? DesdeFecha, DateTime? HastaFecha, int? idVehiculo, int? idProveedor, int? idItems, string Estado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AUTp_OrdenReparacionItem", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEntidad", idEntidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@DesdeFecha", DesdeFecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@HastaFecha", HastaFecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idVehiculo", idVehiculo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProveedor", idProveedor, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idItems", idItems, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Estado", Estado, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the BorrarDetalleAgenda Procedure
        /// </summary>
        public static StoredProcedure BorrarDetalleAgenda(int? IdAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("BorrarDetalleAgenda", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@IdAgenda", IdAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the BorrarPermisos Procedure
        /// </summary>
        public static StoredProcedure BorrarPermisos(int? modulo, int? perfil, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("BorrarPermisos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@modulo", modulo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the BorrarServiciosEfector Procedure
        /// </summary>
        public static StoredProcedure BorrarServiciosEfector(int? idEfector, string letra)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("BorrarServiciosEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@letra", letra, DbType.AnsiStringFixedLength, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_ActivarAgendasBloqueadas Procedure
        /// </summary>
        public static StoredProcedure ConActivarAgendasBloqueadas()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_ActivarAgendasBloqueadas", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Con_AgendaAuditoriaBuscar Procedure
        /// </summary>
        public static StoredProcedure ConAgendaAuditoriaBuscar(string fechaInicio, string fechaFin, int? consultorio, int? especialidad, int? profesional, int? idTipoAgenda, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Con_AgendaAuditoriaBuscar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fechaInicio", fechaInicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaFin", fechaFin, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@consultorio", consultorio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@especialidad", especialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@profesional", profesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoAgenda", idTipoAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_AgendaRangoOcupado Procedure
        /// </summary>
        public static StoredProcedure ConAgendaRangoOcupado(int? idEfector, int? idConsultorio, int? idProfesional, string fecha, string hIni, string hFin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_AgendaRangoOcupado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idConsultorio", idConsultorio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@hIni", hIni, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@hFin", hFin, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Con_AgendaSinProfesional Procedure
        /// </summary>
        public static StoredProcedure ConAgendaSinProfesional(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Con_AgendaSinProfesional", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Equipos Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboEquipos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Equipos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Estado_Agenda Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboEstadoAgenda()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Estado_Agenda", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Lugar_Realizacion Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboLugarRealizacion()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Lugar_Realizacion", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Profesionales Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboProfesionales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Profesionales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Profesionales_Del_Efector Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboProfesionalesDelEfector(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Profesionales_Del_Efector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Profesionales_No_Asignados_En_Agenda_Grupal Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboProfesionalesNoAsignadosEnAgendaGrupal(int? idAgendaGrupal, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Profesionales_No_Asignados_En_Agenda_Grupal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgendaGrupal", idAgendaGrupal, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Tematica Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboTematica()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Tematica", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Combo_Tipo_Actividad Procedure
        /// </summary>
        public static StoredProcedure ConCargarComboTipoActividad()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Combo_Tipo_Actividad", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Lista_Agendas_Grupales Procedure
        /// </summary>
        public static StoredProcedure ConCargarListaAgendasGrupales(DateTime? fechaInicio, DateTime? fechaFin, int? idTematica, int? idTipoActividadGrupal, int? idProfesional, int? idAgendaEstado, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Lista_Agendas_Grupales", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fechaInicio", fechaInicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@fechaFin", fechaFin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idTematica", idTematica, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoActividadGrupal", idTipoActividadGrupal, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idAgendaEstado", idAgendaEstado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Lista_Pacientes_Agendas_Grupales Procedure
        /// </summary>
        public static StoredProcedure ConCargarListaPacientesAgendasGrupales(int? idAgendaGrupal)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Lista_Pacientes_Agendas_Grupales", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgendaGrupal", idAgendaGrupal, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Cargar_Lista_Profesionales_Intervinientes Procedure
        /// </summary>
        public static StoredProcedure ConCargarListaProfesionalesIntervinientes(int? idAgendaGrupal)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Cargar_Lista_Profesionales_Intervinientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgendaGrupal", idAgendaGrupal, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_DesbloqueoTurnoProtegido Procedure
        /// </summary>
        public static StoredProcedure ConDesbloqueoTurnoProtegido(int? idAgenda, DateTime? fechaTurno, string horaTurno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_DesbloqueoTurnoProtegido", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechaTurno", fechaTurno, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@horaTurno", horaTurno, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Eliminar_Profesional_En_Agenda_Grupal Procedure
        /// </summary>
        public static StoredProcedure ConEliminarProfesionalEnAgendaGrupal(int? idAgendaGrupal, int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Eliminar_Profesional_En_Agenda_Grupal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgendaGrupal", idAgendaGrupal, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_EliminarReservaCaduca Procedure
        /// </summary>
        public static StoredProcedure ConEliminarReservaCaduca()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_EliminarReservaCaduca", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_EstadisticaConsultas Procedure
        /// </summary>
        public static StoredProcedure ConEstadisticaConsultas(int? idZona, int? idEfector, int? idServicio, int? idEspecialidad, int? idProfesional, string fechainicio, string fechafin, int? idTipoAgenda, int? idTipoReporte)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_EstadisticaConsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idTipoAgenda", idTipoAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoReporte", idTipoReporte, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_EstadisticaDiagnosticos Procedure
        /// </summary>
        public static StoredProcedure ConEstadisticaDiagnosticos(int? idZona, int? idEfector, int? idServicio, int? idEspecialidad, int? idProfesional, string fechainicio, string fechafin, string capitulo, int? tipoDiagnostico, int? idTipoAgenda, int? tipoReporte)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_EstadisticaDiagnosticos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@capitulo", capitulo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@tipoDiagnostico", tipoDiagnostico, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoAgenda", idTipoAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoReporte", tipoReporte, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAgendaActividadesGrupalesOrganismos Procedure
        /// </summary>
        public static StoredProcedure ConGetAgendaActividadesGrupalesOrganismos(int? idAgendaGrupal)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAgendaActividadesGrupalesOrganismos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgendaGrupal", idAgendaGrupal, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAgendas Procedure
        /// </summary>
        public static StoredProcedure ConGetAgendas(int? idZona, int? idEfector, int? idServicio, int? idEspecialidad, int? idProfesional, int? idTipoConsultorio, string fechainicio, string fechafin, int? idTipoAgenda, int? idEstadoAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAgendas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoConsultorio", idTipoConsultorio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idTipoAgenda", idTipoAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstadoAgenda", idEstadoAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAgendasById Procedure
        /// </summary>
        public static StoredProcedure ConGetAgendasById(int? idAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAgendasById", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAgendasByParam Procedure
        /// </summary>
        public static StoredProcedure ConGetAgendasByParam(int? idServicio, int? idEspecialidad, int? idProfesional, int? idConsultorioTipo, DateTime? fechainicio, DateTime? fechafin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAgendasByParam", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idConsultorioTipo", idConsultorioTipo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@fechafin", fechafin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAgendasFechas Procedure
        /// </summary>
        public static StoredProcedure ConGetAgendasFechas(int? idEfector, int? idServicio, int? idEspecialidad, int? IdProfesional, int? idTipoConsultorio, string fechaIni, string fechaFin, string disponibles, int? tipoAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAgendasFechas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@IdProfesional", IdProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoConsultorio", idTipoConsultorio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechaIni", fechaIni, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@fechaFin", fechaFin, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@disponibles", disponibles, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@tipoAgenda", tipoAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAgendasTurnos Procedure
        /// </summary>
        public static StoredProcedure ConGetAgendasTurnos(int? idEfector, int? idServicio, int? idEspecialidad, int? IdProfesional, int? idTipoConsultorio, string fecha, string disponibles, int? tipoAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAgendasTurnos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@IdProfesional", IdProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoConsultorio", idTipoConsultorio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@disponibles", disponibles, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@tipoAgenda", tipoAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAgendasTurnosProtegidos Procedure
        /// </summary>
        public static StoredProcedure ConGetAgendasTurnosProtegidos(int? idEspecialidad, int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAgendasTurnosProtegidos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetAtencionPacientes Procedure
        /// </summary>
        public static StoredProcedure ConGetAtencionPacientes(string filtro)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetAtencionPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@filtro", filtro, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetConsultas Procedure
        /// </summary>
        public static StoredProcedure ConGetConsultas(int? idEfector, DateTime? finicio, DateTime? ffin, int? tipoProf)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetConsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@tipoProf", tipoProf, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetConsultasByEfector Procedure
        /// </summary>
        public static StoredProcedure ConGetConsultasByEfector(int? idefector, DateTime? fechainicio, DateTime? fechafin, int? especialidad, int? tipoprof)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetConsultasByEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@fechafin", fechafin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@especialidad", especialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoprof", tipoprof, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetConsultasEcografia Procedure
        /// </summary>
        public static StoredProcedure ConGetConsultasEcografia(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetConsultasEcografia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetConsultasPaciente Procedure
        /// </summary>
        public static StoredProcedure ConGetConsultasPaciente(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetConsultasPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetDemandaRechazada Procedure
        /// </summary>
        public static StoredProcedure ConGetDemandaRechazada(int? idEfector, int? idEspecialidad, string fechaDesde, string fechaHasta, int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetDemandaRechazada", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechaDesde", fechaDesde, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaHasta", fechaHasta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetEspecialidadesTurnosProtegidos Procedure
        /// </summary>
        public static StoredProcedure ConGetEspecialidadesTurnosProtegidos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetEspecialidadesTurnosProtegidos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetHistorialDatosControl Procedure
        /// </summary>
        public static StoredProcedure ConGetHistorialDatosControl(int? idPaciente, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetHistorialDatosControl", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetHistorialOdontologia Procedure
        /// </summary>
        public static StoredProcedure ConGetHistorialOdontologia(string fecha, int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetHistorialOdontologia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetHistorialOdontologiaPrestacion Procedure
        /// </summary>
        public static StoredProcedure ConGetHistorialOdontologiaPrestacion(int? idTurno, int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetHistorialOdontologiaPrestacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idTurno", idTurno, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetMenuPrincipal Procedure
        /// </summary>
        public static StoredProcedure ConGetMenuPrincipal(int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetMenuPrincipal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetMenuSecundario Procedure
        /// </summary>
        public static StoredProcedure ConGetMenuSecundario(int? idMenu, int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetMenuSecundario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idMenu", idMenu, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetMotivoInactivacionAgenda Procedure
        /// </summary>
        public static StoredProcedure ConGetMotivoInactivacionAgenda()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetMotivoInactivacionAgenda", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetOcupacion Procedure
        /// </summary>
        public static StoredProcedure ConGetOcupacion(DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetOcupacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetPacientesByApyNom Procedure
        /// </summary>
        public static StoredProcedure ConGetPacientesByApyNom(string nombre, string apellido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetPacientesByApyNom", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetPacientesPorDocumento Procedure
        /// </summary>
        public static StoredProcedure ConGetPacientesPorDocumento(int? numerodoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetPacientesPorDocumento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numerodoc", numerodoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetPacientesPorHistoriaClinica Procedure
        /// </summary>
        public static StoredProcedure ConGetPacientesPorHistoriaClinica(int? hc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetPacientesPorHistoriaClinica", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@hc", hc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetProfesionalesAgenda Procedure
        /// </summary>
        public static StoredProcedure ConGetProfesionalesAgenda(int? idAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetProfesionalesAgenda", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetProfesionalesTurnosProtegidos Procedure
        /// </summary>
        public static StoredProcedure ConGetProfesionalesTurnosProtegidos(int? idEspecialidad)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetProfesionalesTurnosProtegidos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetTurnosPacientes Procedure
        /// </summary>
        public static StoredProcedure ConGetTurnosPacientes(string fecha, int? idPaciente, int? tipoBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetTurnosPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoBusqueda", tipoBusqueda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetTurnosPacientes_Prueba Procedure
        /// </summary>
        public static StoredProcedure ConGetTurnosPacientesPrueba(string fecha, int? idPaciente, int? tipoBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetTurnosPacientes_Prueba", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoBusqueda", tipoBusqueda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetTurnosPacientesSMS Procedure
        /// </summary>
        public static StoredProcedure ConGetTurnosPacientesSMS()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetTurnosPacientesSMS", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetTurnosPorDia Procedure
        /// </summary>
        public static StoredProcedure ConGetTurnosPorDia(string fecha, int? idEfector, int? idTipoAgenda, int? idEspecialidad, int? idProfesional, int? tipoPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetTurnosPorDia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoAgenda", idTipoAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoPaciente", tipoPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_GetTurnosProtegidos Procedure
        /// </summary>
        public static StoredProcedure ConGetTurnosProtegidos(int? idAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_GetTurnosProtegidos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Con_GuardarAgenda Procedure
        /// </summary>
        public static StoredProcedure ConGuardarAgenda(int? idEfector, int? idServicio, int? idEspecialidad, int? idTipoPrestacion, int? idProfesional, DateTime? fecha, string horaInicio, string horaFin, int? duracion, int? idConsultorio, bool? citarPorBloques, int? maximoSobreTurnos, int? cantidadInterconsulta, int? idAgendaEstado, bool? turnosDisponibles, string errorX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Con_GuardarAgenda", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoPrestacion", idTipoPrestacion, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@horaInicio", horaInicio, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@horaFin", horaFin, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@duracion", duracion, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idConsultorio", idConsultorio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@citarPorBloques", citarPorBloques, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@maximoSobreTurnos", maximoSobreTurnos, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@cantidadInterconsulta", cantidadInterconsulta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idAgendaEstado", idAgendaEstado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@turnosDisponibles", turnosDisponibles, DbType.Boolean, null, null);
        	
            sp.Command.AddOutputParameter("@error", DbType.AnsiString, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Con_GuardarTurno Procedure
        /// </summary>
        public static StoredProcedure ConGuardarTurno(int? idPaciente, int? idAgenda, int? idObraSocial, int? idTurnoEstado, int? idUsuario, DateTime? fecha, string hora, bool? sobreturno, int? idTipoTurno, string errorX, int? idTurno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Con_GuardarTurno", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idObraSocial", idObraSocial, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTurnoEstado", idTurnoEstado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idUsuario", idUsuario, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@hora", hora, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@sobreturno", sobreturno, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@idTipoTurno", idTipoTurno, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@error", DbType.String, null, null);
            
            sp.Command.AddOutputParameter("@idTurno", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the con_inicializarAgendasMultiprofesionales Procedure
        /// </summary>
        public static StoredProcedure ConInicializarAgendasMultiprofesionales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("con_inicializarAgendasMultiprofesionales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_MotivoDeBloqueo Procedure
        /// </summary>
        public static StoredProcedure ConMotivoDeBloqueo()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_MotivoDeBloqueo", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Obtener_Nombre_profesional Procedure
        /// </summary>
        public static StoredProcedure ConObtenerNombreProfesional(int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Obtener_Nombre_profesional", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_PlanillaPorAgenda Procedure
        /// </summary>
        public static StoredProcedure ConPlanillaPorAgenda(int? idAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_PlanillaPorAgenda", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Con_TurnoAuditoriaBuscar Procedure
        /// </summary>
        public static StoredProcedure ConTurnoAuditoriaBuscar(string fechaInicio, string fechaFin, int? Agenda, int? Estado, int? consultorio, int? especialidad, int? profesional, int? idTipoAgenda, int? efector, int? documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Con_TurnoAuditoriaBuscar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fechaInicio", fechaInicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaFin", fechaFin, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Agenda", Agenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Estado", Estado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@consultorio", consultorio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@especialidad", especialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@profesional", profesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoAgenda", idTipoAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_TurnosAcompaniante Procedure
        /// </summary>
        public static StoredProcedure ConTurnosAcompaniante(int? idTurno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_TurnosAcompaniante", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idTurno", idTurno, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Con_TurnosEspecialidad Procedure
        /// </summary>
        public static StoredProcedure ConTurnosEspecialidad(int? idServicio, int? idTipoAgenda, int? idEspecialidad, string fechainicio, string fechafin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Con_TurnosEspecialidad", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idServicio", idServicio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTipoAgenda", idTipoAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_TurnosPorAgenda Procedure
        /// </summary>
        public static StoredProcedure ConTurnosPorAgenda(int? idAgenda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_TurnosPorAgenda", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_UpdateLLamadaDemandaRechazada Procedure
        /// </summary>
        public static StoredProcedure ConUpdateLLamadaDemandaRechazada(int? idDemandaRechazada, string observacionLLamada, int? idUsuario)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_UpdateLLamadaDemandaRechazada", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idDemandaRechazada", idDemandaRechazada, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@observacionLLamada", observacionLLamada, DbType.String, null, null);
        	
            sp.Command.AddParameter("@idUsuario", idUsuario, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Verificar_Existencia_Pacientes_Agenda_Grupal Procedure
        /// </summary>
        public static StoredProcedure ConVerificarExistenciaPacientesAgendaGrupal(int? idAgendaGrupal)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Verificar_Existencia_Pacientes_Agenda_Grupal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgendaGrupal", idAgendaGrupal, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the CON_Verificar_Paciente_Cargado_En_Agenda_Grupal Procedure
        /// </summary>
        public static StoredProcedure ConVerificarPacienteCargadoEnAgendaGrupal(int? idAgendaGrupal, int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CON_Verificar_Paciente_Cargado_En_Agenda_Grupal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgendaGrupal", idAgendaGrupal, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Diccionario Procedure
        /// </summary>
        public static StoredProcedure Diccionario()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Diccionario", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the EMR_GetAntecedentes Procedure
        /// </summary>
        public static StoredProcedure EmrGetAntecedentes(int? idHC)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("EMR_GetAntecedentes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHC", idHC, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Emr_GetEmergencias Procedure
        /// </summary>
        public static StoredProcedure EmrGetEmergencias(int? baseX, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Emr_GetEmergencias", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@base", baseX, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the EMR_GetHCPrehospitalaria Procedure
        /// </summary>
        public static StoredProcedure EmrGetHCPrehospitalaria(int? baseX, int? idHCP, DateTime? finicio, DateTime? ffin, int? doc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("EMR_GetHCPrehospitalaria", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@base", baseX, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idHCP", idHCP, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@doc", doc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the EMR_GetIncidentes Procedure
        /// </summary>
        public static StoredProcedure EmrGetIncidentes(int? idHC)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("EMR_GetIncidentes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHC", idHC, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Emr_GetInforme Procedure
        /// </summary>
        public static StoredProcedure EmrGetInforme()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Emr_GetInforme", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Emr_GetMenu Procedure
        /// </summary>
        public static StoredProcedure EmrGetMenu(int? perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Emr_GetMenu", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the EMR_GetOtrasCausas Procedure
        /// </summary>
        public static StoredProcedure EmrGetOtrasCausas(int? idHC)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("EMR_GetOtrasCausas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHC", idHC, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the EMR_GetOtrosIncidentes Procedure
        /// </summary>
        public static StoredProcedure EmrGetOtrosIncidentes(int? idHC)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("EMR_GetOtrosIncidentes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHC", idHC, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the EMR_GetPaciente Procedure
        /// </summary>
        public static StoredProcedure EmrGetPaciente(int? doc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("EMR_GetPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@doc", doc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ExportPacientes Procedure
        /// </summary>
        public static StoredProcedure ExportPacientes()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ExportPacientes", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Fac_AsientoOrden Procedure
        /// </summary>
        public static StoredProcedure FacAsientoOrden(int? AsientoContable, int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Fac_AsientoOrden", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@AsientoContable", AsientoContable, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_AUDIT_FacturasSinOrdenes Procedure
        /// </summary>
        public static StoredProcedure FacAuditFacturasSinOrdenes()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_AUDIT_FacturasSinOrdenes", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_AUDIT_OrdenesDetallesDuplicados Procedure
        /// </summary>
        public static StoredProcedure FacAuditOrdenesDetallesDuplicados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_AUDIT_OrdenesDetallesDuplicados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_AUDIT_OrdenesMontosDiferentes Procedure
        /// </summary>
        public static StoredProcedure FacAuditOrdenesMontosDiferentes()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_AUDIT_OrdenesMontosDiferentes", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_AUDIT_PacientesFinanciadorRepetido Procedure
        /// </summary>
        public static StoredProcedure FacAuditPacientesFinanciadorRepetido()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_AUDIT_PacientesFinanciadorRepetido", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_BuscaDatosFactura Procedure
        /// </summary>
        public static StoredProcedure FacBuscaDatosFactura(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_BuscaDatosFactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_CalcularTotalFactura Procedure
        /// </summary>
        public static StoredProcedure FacCalcularTotalFactura(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_CalcularTotalFactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_CalcularTotalPreFactura Procedure
        /// </summary>
        public static StoredProcedure FacCalcularTotalPreFactura(int? idPrefactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_CalcularTotalPreFactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPrefactura", idPrefactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_CantidadOrdenesPorEfector Procedure
        /// </summary>
        public static StoredProcedure FacCantidadOrdenesPorEfector()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_CantidadOrdenesPorEfector", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_FacturaLiberarOrdenes Procedure
        /// </summary>
        public static StoredProcedure FacFacturaLiberarOrdenes(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_FacturaLiberarOrdenes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GenerarFacturaDePrefactura Procedure
        /// </summary>
        public static StoredProcedure FacGenerarFacturaDePrefactura(int? idPreFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GenerarFacturaDePrefactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPreFactura", idPreFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GenerarFacturasDePrefacturas Procedure
        /// </summary>
        public static StoredProcedure FacGenerarFacturasDePrefacturas(int? idEfector, string per)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GenerarFacturasDePrefacturas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@per", per, DbType.AnsiStringFixedLength, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GenerarOrdenesTurno Procedure
        /// </summary>
        public static StoredProcedure FacGenerarOrdenesTurno(string ids, int? idEfector, int? idUsuarioRegistro, string codigoNomenclador)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GenerarOrdenesTurno", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ids", ids, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idUsuarioRegistro", idUsuarioRegistro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@codigoNomenclador", codigoNomenclador, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetDetallesOrden Procedure
        /// </summary>
        public static StoredProcedure FacGetDetallesOrden(int? idOrden)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetDetallesOrden", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idOrden", idOrden, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetFacturacionPeriodo Procedure
        /// </summary>
        public static StoredProcedure FacGetFacturacionPeriodo(string FiltroBusqueda, string tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetFacturacionPeriodo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            sp.Command.AddParameter("@tipo", tipo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetFacturacionPeriodoServicio Procedure
        /// </summary>
        public static StoredProcedure FacGetFacturacionPeriodoServicio(string FiltroBusqueda, string tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetFacturacionPeriodoServicio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            sp.Command.AddParameter("@tipo", tipo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetFacturacionServicio Procedure
        /// </summary>
        public static StoredProcedure FacGetFacturacionServicio(string FiltroBusqueda, string tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetFacturacionServicio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            sp.Command.AddParameter("@tipo", tipo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetFacturaDetalle Procedure
        /// </summary>
        public static StoredProcedure FacGetFacturaDetalle(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetFacturaDetalle", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaFacturas Procedure
        /// </summary>
        public static StoredProcedure FacGetListaFacturas(string FiltroBusqueda, string tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaFacturas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            sp.Command.AddParameter("@tipo", tipo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaNomenclador Procedure
        /// </summary>
        public static StoredProcedure FacGetListaNomenclador(string FiltroBusqueda, string Tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaNomenclador", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Tipo", Tipo, DbType.AnsiStringFixedLength, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaObraSocial Procedure
        /// </summary>
        public static StoredProcedure FacGetListaObraSocial(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaObraSocial", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaOrdenes Procedure
        /// </summary>
        public static StoredProcedure FacGetListaOrdenes(string FiltroBusqueda, string tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaOrdenes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            sp.Command.AddParameter("@tipo", tipo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaOrdenesSinPrefacturar Procedure
        /// </summary>
        public static StoredProcedure FacGetListaOrdenesSinPrefacturar(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaOrdenesSinPrefacturar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientes Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientes(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesGuardia Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesGuardia(int? idEfector, DateTime? fecha, int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesGuardia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesGuardiaDetalles Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesGuardiaDetalles(int? idOrden)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesGuardiaDetalles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idOrden", idOrden, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesLaboratorio Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesLaboratorio(int? idEfector, DateTime? fecha, int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesLaboratorio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesLaboratorio2 Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesLaboratorio2(int? idEfector, DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesLaboratorio2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesLaboratorioDetalles Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesLaboratorioDetalles(int? idEfector, int? idProtocolo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesLaboratorioDetalles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProtocolo", idProtocolo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesTurnos Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesTurnos(int? idEfector, int? idEspecialidad, int? idProfesional, DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesTurnos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesTurnos2 Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesTurnos2(int? idEfector, int? idEspecialidad, int? idProfesional, DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesTurnos2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesTurnosProfe Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesTurnosProfe(int? idEfector, int? idEspecialidad, int? idProfesional, DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesTurnosProfe", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPacientesTurnosProfe2 Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPacientesTurnosProfe2(int? idEfector, DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPacientesTurnosProfe2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPracticas Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPracticas(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPracticas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetListaPreFacturas Procedure
        /// </summary>
        public static StoredProcedure FacGetListaPreFacturas(string FiltroBusqueda, string tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetListaPreFacturas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            sp.Command.AddParameter("@tipo", tipo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetNomenclador Procedure
        /// </summary>
        public static StoredProcedure FacGetNomenclador(int? idTipoNomenclador)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetNomenclador", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idTipoNomenclador", idTipoNomenclador, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetNomencladorPorGuardia Procedure
        /// </summary>
        public static StoredProcedure FacGetNomencladorPorGuardia(int? idObraSocial, string fecha, int? idOrden)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetNomencladorPorGuardia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idObraSocial", idObraSocial, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idOrden", idOrden, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetNomencladorPorLaboratorio Procedure
        /// </summary>
        public static StoredProcedure FacGetNomencladorPorLaboratorio(int? idObraSocial, string fecha, int? idEfector, int? idProtocolo, bool? incluirActoBioquimico)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetNomencladorPorLaboratorio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idObraSocial", idObraSocial, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProtocolo", idProtocolo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@incluirActoBioquimico", incluirActoBioquimico, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetNomencladorPorTurno Procedure
        /// </summary>
        public static StoredProcedure FacGetNomencladorPorTurno(int? idEspecialidad, int? idObraSocial, string fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetNomencladorPorTurno", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEspecialidad", idEspecialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idObraSocial", idObraSocial, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetObrasSocialesConContrato Procedure
        /// </summary>
        public static StoredProcedure FacGetObrasSocialesConContrato()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetObrasSocialesConContrato", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetObrasSocialesDelPaciente Procedure
        /// </summary>
        public static StoredProcedure FacGetObrasSocialesDelPaciente(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetObrasSocialesDelPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetObrasSocialesParaCerrarPreFactura Procedure
        /// </summary>
        public static StoredProcedure FacGetObrasSocialesParaCerrarPreFactura(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetObrasSocialesParaCerrarPreFactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetObrasSocialesParaFacturar Procedure
        /// </summary>
        public static StoredProcedure FacGetObrasSocialesParaFacturar(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetObrasSocialesParaFacturar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetObrasSocialesParaPreFacturar Procedure
        /// </summary>
        public static StoredProcedure FacGetObrasSocialesParaPreFacturar(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetObrasSocialesParaPreFacturar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetOrdenesDelPaciente Procedure
        /// </summary>
        public static StoredProcedure FacGetOrdenesDelPaciente(int? idPaciente, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetOrdenesDelPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetPadrones Procedure
        /// </summary>
        public static StoredProcedure FacGetPadrones(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetPadrones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetPrestaciones_ByIdFactura Procedure
        /// </summary>
        public static StoredProcedure FacGetPrestacionesByIdFactura(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetPrestaciones_ByIdFactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetPrestaciones_ByIdFactura_Total Procedure
        /// </summary>
        public static StoredProcedure FacGetPrestacionesByIdFacturaTotal(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetPrestaciones_ByIdFactura_Total", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetTipoNomenclador Procedure
        /// </summary>
        public static StoredProcedure FacGetTipoNomenclador(int? idObraSocial, string fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetTipoNomenclador", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idObraSocial", idObraSocial, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_GetTotalCapitulo Procedure
        /// </summary>
        public static StoredProcedure FacGetTotalCapitulo(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_GetTotalCapitulo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_ListPrefaturasPosiblesDeAbrir Procedure
        /// </summary>
        public static StoredProcedure FacListPrefaturasPosiblesDeAbrir(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_ListPrefaturasPosiblesDeAbrir", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_OrdenesMontosDiferentes Procedure
        /// </summary>
        public static StoredProcedure FacOrdenesMontosDiferentes()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_OrdenesMontosDiferentes", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_PrefacturaDesvincularOrden Procedure
        /// </summary>
        public static StoredProcedure FacPrefacturaDesvincularOrden(int? idOrden)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_PrefacturaDesvincularOrden", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idOrden", idOrden, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_PrefacturaLiberarOrdenes Procedure
        /// </summary>
        public static StoredProcedure FacPrefacturaLiberarOrdenes(int? idPrefactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_PrefacturaLiberarOrdenes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPrefactura", idPrefactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_PrefaturaPosibleDeAbrir Procedure
        /// </summary>
        public static StoredProcedure FacPrefaturaPosibleDeAbrir(int? idPreFactura, int? result)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_PrefaturaPosibleDeAbrir", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPreFactura", idPreFactura, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@result", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_UpdateMontoFactura Procedure
        /// </summary>
        public static StoredProcedure FacUpdateMontoFactura(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_UpdateMontoFactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_UpdateMontoOrden Procedure
        /// </summary>
        public static StoredProcedure FacUpdateMontoOrden(int? idOrden)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_UpdateMontoOrden", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idOrden", idOrden, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_UpdateMontoPrefactura Procedure
        /// </summary>
        public static StoredProcedure FacUpdateMontoPrefactura(int? idPrefactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_UpdateMontoPrefactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPrefactura", idPrefactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_WS_GetNomenclador Procedure
        /// </summary>
        public static StoredProcedure FacWsGetNomenclador(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_WS_GetNomenclador", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the FAC_WS_GetObrasSociales Procedure
        /// </summary>
        public static StoredProcedure FacWsGetObrasSociales(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FAC_WS_GetObrasSociales", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Get_Nomivac Procedure
        /// </summary>
        public static StoredProcedure GetNomivac(int? documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Get_Nomivac", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetMaximoNumeroSD Procedure
        /// </summary>
        public static StoredProcedure GetMaximoNumeroSD()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetMaximoNumeroSD", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetMenu Procedure
        /// </summary>
        public static StoredProcedure GetMenu(int? idusuario)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetMenu", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idusuario", idusuario, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetMenu2 Procedure
        /// </summary>
        public static StoredProcedure GetMenu2(int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetMenu2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetMenuPrincipal Procedure
        /// </summary>
        public static StoredProcedure GetMenuPrincipal(int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetMenuPrincipal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetMenuSecundario Procedure
        /// </summary>
        public static StoredProcedure GetMenuSecundario(int? idMenu, int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetMenuSecundario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idMenu", idMenu, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetModuloObjetos Procedure
        /// </summary>
        public static StoredProcedure GetModuloObjetos(int? idModulo, int? idPerfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetModuloObjetos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idModulo", idModulo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idPerfil", idPerfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetModulos Procedure
        /// </summary>
        public static StoredProcedure GetModulos(int? idPerfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetModulos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPerfil", idPerfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetModulosPermitidos Procedure
        /// </summary>
        public static StoredProcedure GetModulosPermitidos(int? idPerfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetModulosPermitidos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPerfil", idPerfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetObjetos Procedure
        /// </summary>
        public static StoredProcedure GetObjetos(int? modulo, int? perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetObjetos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@modulo", modulo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientes Procedure
        /// </summary>
        public static StoredProcedure GetPacientes(string filtro)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@filtro", filtro, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientesPorDocumento Procedure
        /// </summary>
        public static StoredProcedure GetPacientesPorDocumento(int? numerodoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientesPorDocumento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numerodoc", numerodoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientesPorDocumentoSinOSIdentificado Procedure
        /// </summary>
        public static StoredProcedure GetPacientesPorDocumentoSinOSIdentificado(int? numerodoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientesPorDocumentoSinOSIdentificado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numerodoc", numerodoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientesPorHistoriaClinica Procedure
        /// </summary>
        public static StoredProcedure GetPacientesPorHistoriaClinica(int? hc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientesPorHistoriaClinica", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@hc", hc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientesPorNombres Procedure
        /// </summary>
        public static StoredProcedure GetPacientesPorNombres(DateTime? fnacimiento, string nombre, string apellido, int? dni, string parentNombre, string parentApellido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientesPorNombres", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fnacimiento", fnacimiento, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@parentNombre", parentNombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@parentApellido", parentApellido, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientesReporte Procedure
        /// </summary>
        public static StoredProcedure GetPacientesReporte(int? efector, string apellido, int? sexo, int? estado, DateTime? finicioturno, DateTime? ffinturno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientesReporte", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@sexo", sexo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@estado", estado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicioturno", finicioturno, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffinturno", ffinturno, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPermisos Procedure
        /// </summary>
        public static StoredProcedure GetPermisos(int? idperfil, int? idefector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPermisos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Hid_AltaHidatidosis Procedure
        /// </summary>
        public static StoredProcedure HidAltaHidatidosis(int? idHidatidosis)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Hid_AltaHidatidosis", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHidatidosis", idHidatidosis, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Hid_BuscarResultados Procedure
        /// </summary>
        public static StoredProcedure HidBuscarResultados(int? idEstablecimiento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Hid_BuscarResultados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Hid_BuscarResultadosParciales Procedure
        /// </summary>
        public static StoredProcedure HidBuscarResultadosParciales(int? idEstablecimiento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Hid_BuscarResultadosParciales", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Hid_GetMenuPrincipal Procedure
        /// </summary>
        public static StoredProcedure HidGetMenuPrincipal(int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Hid_GetMenuPrincipal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Hid_GetPaciente Procedure
        /// </summary>
        public static StoredProcedure HidGetPaciente(string documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Hid_GetPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_ActualizarTurnoActual Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaActualizarTurnoActual(bool? tipoguardia, bool? avanzarTurno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_ActualizarTurnoActual", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@tipo_guardia", tipoguardia, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@avanzarTurno", avanzarTurno, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_ActualizarTurnoActualPac Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaActualizarTurnoActualPac(bool? tipoguardia, int? idReg, int? idPac, string NomPac)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_ActualizarTurnoActualPac", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@tipo_guardia", tipoguardia, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@idReg", idReg, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idPac", idPac, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@NomPac", NomPac, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_AsignarTurno Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaAsignarTurno(int? registro, bool? sobreescribir)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_AsignarTurno", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@registro", registro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@sobreescribir", sobreescribir, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_FiltrarRegistros Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaFiltrarRegistros(int? registroID, string historiaID, string dni, string apellido, string nombre, string idObraSocial, int? edadDesde, int? edadHasta, DateTime? fechaIngresoDesde, DateTime? fechaIngresoHasta, int? tipoIngreso, DateTime? fechaEgresoDesde, DateTime? fechaEgresoHasta, int? tipoEgreso, int? idMedicoResponsable, string tipoGuardia, string DiagnosticoCie10Asignado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_FiltrarRegistros", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@registroID", registroID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@historiaID", historiaID, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idObraSocial", idObraSocial, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@edadDesde", edadDesde, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@edadHasta", edadHasta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechaIngresoDesde", fechaIngresoDesde, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@fechaIngresoHasta", fechaIngresoHasta, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@tipoIngreso", tipoIngreso, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechaEgresoDesde", fechaEgresoDesde, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@fechaEgresoHasta", fechaEgresoHasta, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@tipoEgreso", tipoEgreso, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idMedicoResponsable", idMedicoResponsable, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoGuardia", tipoGuardia, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@DiagnosticoCie10Asignado", DiagnosticoCie10Asignado, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_PacienteIngresado Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaPacienteIngresado(int? paciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_PacienteIngresado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@paciente", paciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_Registro_Proximo_Turno Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaRegistroProximoTurno(int? idMedico, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_Registro_Proximo_Turno", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idMedico", idMedico, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_Registros_Reporte Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaRegistrosReporte(int? registroID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_Registros_Reporte", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@registroID", registroID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the hsp_Guardia_SetTriage Procedure
        /// </summary>
        public static StoredProcedure HspGuardiaSetTriage(int? idRegistro, int? idEfector, int? idUser)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("hsp_Guardia_SetTriage", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idRegistro", idRegistro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idUser", idUser, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Combo_Efectores_Ordenado Procedure
        /// </summary>
        public static StoredProcedure IcoCargarComboEfectoresOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Combo_Efectores_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Combo_Efectores_Ordenado2 Procedure
        /// </summary>
        public static StoredProcedure IcoCargarComboEfectoresOrdenado2(int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Combo_Efectores_Ordenado2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Combo_Especialidades_Ordenado Procedure
        /// </summary>
        public static StoredProcedure IcoCargarComboEspecialidadesOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Combo_Especialidades_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Combo_Profesionales_Ordenado Procedure
        /// </summary>
        public static StoredProcedure IcoCargarComboProfesionalesOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Combo_Profesionales_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Combo_Zona_Ordenado Procedure
        /// </summary>
        public static StoredProcedure IcoCargarComboZonaOrdenado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Combo_Zona_Ordenado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Agendas_Grupales Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaAgendasGrupales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Agendas_Grupales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Archivos_Adjuntos Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaArchivosAdjuntos(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Archivos_Adjuntos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Destiantarios Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaDestiantarios(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Destiantarios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Dialogos Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaDialogos(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Dialogos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Interconsultas Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaInterconsultas(string usuarioOCADU, string fechaInicio, string fechaFin, string numeroDocumento, string efectorSolicita, string idProfesional, string estadoInterconsulta, string efectorDestinatario, string especialidadDestinatario, string sortOrder)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Interconsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@usuarioOCADU", usuarioOCADU, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaInicio", fechaInicio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaFin", fechaFin, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@efectorSolicita", efectorSolicita, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@estadoInterconsulta", estadoInterconsulta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@efectorDestinatario", efectorDestinatario, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@especialidadDestinatario", especialidadDestinatario, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@sortOrder", sortOrder, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Interconsultas_Dado_un_paciente Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaInterconsultasDadoUnPaciente(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Interconsultas_Dado_un_paciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Interconsultas_De_un_Paciente Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaInterconsultasDeUnPaciente(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Interconsultas_De_un_Paciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Cargar_Lista_Pacientes Procedure
        /// </summary>
        public static StoredProcedure IcoCargarListaPacientes(string numeroDocumento, string apellido, string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Cargar_Lista_Pacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Datos_Adicionales_Profesional Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerDatosAdicionalesProfesional(int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Datos_Adicionales_Profesional", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Efector_Zona_Del_Profesional Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerEfectorZonaDelProfesional(int? idUsuario)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Efector_Zona_Del_Profesional", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idUsuario", idUsuario, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_IdDestinatarioInterconsulta_Segun_Profesional Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerIdDestinatarioInterconsultaSegunProfesional(int? idInterconsulta, int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_IdDestinatarioInterconsulta_Segun_Profesional", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_IDProfesional_Segun_Documento Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerIDProfesionalSegunDocumento(int? numeroDocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_IDProfesional_Segun_Documento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Interconsultas_Aptas_Asignacion_Turnos Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerInterconsultasAptasAsignacionTurnos(string idInterconsulta, int? idPerfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Interconsultas_Aptas_Asignacion_Turnos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idPerfil", idPerfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Mail_Medico_Destinatario Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerMailMedicoDestinatario(int? idInterconsulta, int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Mail_Medico_Destinatario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Mails_Medico_Solicitante Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerMailsMedicoSolicitante(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Mails_Medico_Solicitante", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Mails_Medicos_Destiantarios Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerMailsMedicosDestiantarios(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Mails_Medicos_Destiantarios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Medicos_Destinatarios Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerMedicosDestinatarios(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Medicos_Destinatarios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Nombre_Del_Efector Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerNombreDelEfector(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Nombre_Del_Efector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Tipo_Usuario Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerTipoUsuario(int? idUsuario)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Tipo_Usuario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idUsuario", idUsuario, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Obtener_Zona_Del_Efector Procedure
        /// </summary>
        public static StoredProcedure IcoObtenerZonaDelEfector(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Obtener_Zona_Del_Efector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Reporte_Interconsulta_Destinatarios Procedure
        /// </summary>
        public static StoredProcedure IcoReporteInterconsultaDestinatarios(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Reporte_Interconsulta_Destinatarios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Reporte_Interconsulta_Dialogos Procedure
        /// </summary>
        public static StoredProcedure IcoReporteInterconsultaDialogos(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Reporte_Interconsulta_Dialogos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Reporte_Interconsulta_Encabezado Procedure
        /// </summary>
        public static StoredProcedure IcoReporteInterconsultaEncabezado(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Reporte_Interconsulta_Encabezado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Verificar_Si_Es_Meidco_Destinatario Procedure
        /// </summary>
        public static StoredProcedure IcoVerificarSiEsMeidcoDestinatario(int? idInterconsulta, string idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Verificar_Si_Es_Meidco_Destinatario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Verificar_Si_Existe_Documento Procedure
        /// </summary>
        public static StoredProcedure IcoVerificarSiExisteDocumento(int? numeroDocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Verificar_Si_Existe_Documento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Verificar_Si_Tiene_Interconsultas Procedure
        /// </summary>
        public static StoredProcedure IcoVerificarSiTieneInterconsultas(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Verificar_Si_Tiene_Interconsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ICO_Verificar_Si_Tiene_Laboratorio Procedure
        /// </summary>
        public static StoredProcedure IcoVerificarSiTieneLaboratorio(int? numeroDocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ICO_Verificar_Si_Tiene_Laboratorio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_BorrarInsumosEfector Procedure
        /// </summary>
        public static StoredProcedure InsBorrarInsumosEfector(int? idEfector, string letra)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_BorrarInsumosEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@letra", letra, DbType.AnsiStringFixedLength, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_ConsumoMedxPaciente Procedure
        /// </summary>
        public static StoredProcedure InsConsumoMedxPaciente(int? insumo, int? efector, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_ConsumoMedxPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_EliminaInsumosEfector Procedure
        /// </summary>
        public static StoredProcedure InsEliminaInsumosEfector(int? idEfector, int? idInsumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_EliminaInsumosEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idInsumo", idInsumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_EntregasMedicamentos Procedure
        /// </summary>
        public static StoredProcedure InsEntregasMedicamentos(int? insumo, int? efector, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_EntregasMedicamentos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_EntregasMedicamentosDetalle Procedure
        /// </summary>
        public static StoredProcedure InsEntregasMedicamentosDetalle(int? insumo, int? efector, int? deposito)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_EntregasMedicamentosDetalle", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetBotiquinServicios Procedure
        /// </summary>
        public static StoredProcedure InsGetBotiquinServicios(DateTime? fecha, int? efector, int? deposito)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetBotiquinServicios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetBotiquinServiciosDetalle Procedure
        /// </summary>
        public static StoredProcedure InsGetBotiquinServiciosDetalle(DateTime? fecha, int? efector, int? deposito, int? servicio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetBotiquinServiciosDetalle", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@servicio", servicio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetConsultaPedidos Procedure
        /// </summary>
        public static StoredProcedure InsGetConsultaPedidos(DateTime? finicio, DateTime? ffin, int? efector, int? deposito, int? rubro, int? estado, int? nropedido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetConsultaPedidos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@estado", estado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@nropedido", nropedido, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetConsultasProvisionesH Procedure
        /// </summary>
        public static StoredProcedure InsGetConsultasProvisionesH(DateTime? finicio, DateTime? ffin, int? tipoPedido, int? proveedor, int? efector, int? tipoMov, int? deposito)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetConsultasProvisionesH", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@tipoPedido", tipoPedido, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@proveedor", proveedor, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoMov", tipoMov, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetConsultasProvisionesH_Detalle Procedure
        /// </summary>
        public static StoredProcedure InsGetConsultasProvisionesHDetalle(DateTime? finicio, DateTime? ffin, int? tipoPedido, int? proveedor, int? efector, int? tipoMov, int? deposito, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetConsultasProvisionesH_Detalle", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@tipoPedido", tipoPedido, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@proveedor", proveedor, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoMov", tipoMov, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetDepositoZona Procedure
        /// </summary>
        public static StoredProcedure InsGetDepositoZona(int? Efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetDepositoZona", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Efector", Efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetDispensacion Procedure
        /// </summary>
        public static StoredProcedure InsGetDispensacion(int? dispensacion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetDispensacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dispensacion", dispensacion, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetDispensacionReceta Procedure
        /// </summary>
        public static StoredProcedure InsGetDispensacionReceta(int? efector, int? prescripcion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetDispensacionReceta", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@prescripcion", prescripcion, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetEnviosBotiquin Procedure
        /// </summary>
        public static StoredProcedure InsGetEnviosBotiquin(int? pedido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetEnviosBotiquin", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pedido", pedido, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetHistorialRecetas Procedure
        /// </summary>
        public static StoredProcedure InsGetHistorialRecetas(int? efector, int? deposito)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetHistorialRecetas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetInsumosDisponibles Procedure
        /// </summary>
        public static StoredProcedure InsGetInsumosDisponibles(int? efector, int? deposito)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetInsumosDisponibles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetInsumosDisponiblesGrilla Procedure
        /// </summary>
        public static StoredProcedure InsGetInsumosDisponiblesGrilla(int? efector, int? deposito, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetInsumosDisponiblesGrilla", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetInsumosDisponiblesStock Procedure
        /// </summary>
        public static StoredProcedure InsGetInsumosDisponiblesStock(int? efector, int? deposito, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetInsumosDisponiblesStock", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetInsumosEfectorDeposito Procedure
        /// </summary>
        public static StoredProcedure InsGetInsumosEfectorDeposito(int? efector, int? deposito, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetInsumosEfectorDeposito", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetInsumosEfectorxRubro Procedure
        /// </summary>
        public static StoredProcedure InsGetInsumosEfectorxRubro(int? efector, int? codigo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetInsumosEfectorxRubro", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@codigo", codigo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetInsumosxEfector Procedure
        /// </summary>
        public static StoredProcedure InsGetInsumosxEfector(int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetInsumosxEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetInsumosxRubros Procedure
        /// </summary>
        public static StoredProcedure InsGetInsumosxRubros(int? idrubro)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetInsumosxRubros", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idrubro", idrubro, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetListadoAmbulatorias Procedure
        /// </summary>
        public static StoredProcedure InsGetListadoAmbulatorias(DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetListadoAmbulatorias", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetListadoInternacion Procedure
        /// </summary>
        public static StoredProcedure InsGetListadoInternacion(DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetListadoInternacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMaxCodigoInsumo Procedure
        /// </summary>
        public static StoredProcedure InsGetMaxCodigoInsumo()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMaxCodigoInsumo", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMaxCodigoRubro Procedure
        /// </summary>
        public static StoredProcedure InsGetMaxCodigoRubro()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMaxCodigoRubro", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMedicacionAnterior Procedure
        /// </summary>
        public static StoredProcedure InsGetMedicacionAnterior(int? idPaciente, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMedicacionAnterior", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMedicamentos Procedure
        /// </summary>
        public static StoredProcedure InsGetMedicamentos(int? insumo, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMedicamentos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMenu Procedure
        /// </summary>
        public static StoredProcedure InsGetMenu(int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMenu", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMenuPrincipal Procedure
        /// </summary>
        public static StoredProcedure InsGetMenuPrincipal(int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMenuPrincipal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMenuSecundario Procedure
        /// </summary>
        public static StoredProcedure InsGetMenuSecundario(int? idMenu, int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMenuSecundario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idMenu", idMenu, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetMovimientos_DepositoEfector Procedure
        /// </summary>
        public static StoredProcedure InsGetMovimientosDepositoEfector(DateTime? finicio, DateTime? ffin, int? tipoMov, int? deposito, int? efector, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetMovimientos_DepositoEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@tipoMov", tipoMov, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPacientes Procedure
        /// </summary>
        public static StoredProcedure InsGetPacientes(int? numerodoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numerodoc", numerodoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidoDetalle Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidoDetalle(int? pedido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidoDetalle", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pedido", pedido, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidoEncabezado Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidoEncabezado(int? pedido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidoEncabezado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pedido", pedido, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidoInternacion Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidoInternacion(int? receta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidoInternacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@receta", receta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidoProvisionExterna Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidoProvisionExterna(int? efector, int? pedido, string IpServidor)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidoProvisionExterna", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pedido", pedido, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@IpServidor", IpServidor, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidos Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidos(DateTime? finicio, DateTime? ffin, int? efector, int? deposito)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidosH Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidosH(DateTime? finicio, DateTime? ffin, int? depositoProveedor, int? deposito, int? rubro, int? estado, int? autorizado, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidosH", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@depositoProveedor", depositoProveedor, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@estado", estado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@autorizado", autorizado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidosHGenerados Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidosHGenerados(DateTime? finicio, DateTime? ffin, int? depositoSolicitante, int? depositoProveedor, int? rubro, int? estado, int? autorizado, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidosHGenerados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@depositoSolicitante", depositoSolicitante, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@depositoProveedor", depositoProveedor, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@estado", estado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@autorizado", autorizado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPedidosInternos Procedure
        /// </summary>
        public static StoredProcedure InsGetPedidosInternos(DateTime? finicio, DateTime? ffin, int? depositop, int? rubro, int? autorizado, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPedidosInternos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@depositop", depositop, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@autorizado", autorizado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GEtPedidosRealizados Procedure
        /// </summary>
        public static StoredProcedure InsGEtPedidosRealizados(DateTime? finicio, DateTime? ffin, int? depositop, int? rubro, int? autorizado, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GEtPedidosRealizados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@depositop", depositop, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@autorizado", autorizado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPrescripcion Procedure
        /// </summary>
        public static StoredProcedure InsGetPrescripcion(int? receta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPrescripcion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@receta", receta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetPrescripciones Procedure
        /// </summary>
        public static StoredProcedure InsGetPrescripciones(int? efector, int? tipoPresc, int? tipoTratamiento, DateTime? fInicio, DateTime? fFin, int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetPrescripciones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoPresc", tipoPresc, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoTratamiento", tipoTratamiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fInicio", fInicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@fFin", fFin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetProvision Procedure
        /// </summary>
        public static StoredProcedure InsGetProvision(int? pedido)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetProvision", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pedido", pedido, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetProvisionExterna Procedure
        /// </summary>
        public static StoredProcedure InsGetProvisionExterna(DateTime? finicio, DateTime? ffin, int? efector, string IpServidor)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetProvisionExterna", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@IpServidor", IpServidor, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetProvisionInterna Procedure
        /// </summary>
        public static StoredProcedure InsGetProvisionInterna(int? pedido, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetProvisionInterna", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pedido", pedido, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetRubroInsumo Procedure
        /// </summary>
        public static StoredProcedure InsGetRubroInsumo(int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetRubroInsumo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetRubroPrimerNivel Procedure
        /// </summary>
        public static StoredProcedure InsGetRubroPrimerNivel(int? rubroprimernivel)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetRubroPrimerNivel", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@rubroprimernivel", rubroprimernivel, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetStock Procedure
        /// </summary>
        public static StoredProcedure InsGetStock(int? efector, int? deposito, DateTime? finicio, DateTime? ffin, int? proveedor)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetStock", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@proveedor", proveedor, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetStockInsumo Procedure
        /// </summary>
        public static StoredProcedure InsGetStockInsumo(int? idInsumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetStockInsumo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInsumo", idInsumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetStockInterno Procedure
        /// </summary>
        public static StoredProcedure InsGetStockInterno(int? deposito, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetStockInterno", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetStockMedicamentos Procedure
        /// </summary>
        public static StoredProcedure InsGetStockMedicamentos(int? deposito, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetStockMedicamentos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetStockPrescripcion Procedure
        /// </summary>
        public static StoredProcedure InsGetStockPrescripcion(int? deposito, int? insumo, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetStockPrescripcion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetStockxEfector Procedure
        /// </summary>
        public static StoredProcedure InsGetStockxEfector(int? efector, int? rubro, int? deposito, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetStockxEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetTrazabilidadxRubro Procedure
        /// </summary>
        public static StoredProcedure InsGetTrazabilidadxRubro(DateTime? finicio, DateTime? ffin, int? rubro, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetTrazabilidadxRubro", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetUInsumos Procedure
        /// </summary>
        public static StoredProcedure InsGetUInsumos(int? efector, int? insumo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetUInsumos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@insumo", insumo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_GetVencimiento Procedure
        /// </summary>
        public static StoredProcedure InsGetVencimiento(int? efector, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_GetVencimiento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_InsumosEntregados Procedure
        /// </summary>
        public static StoredProcedure InsInsumosEntregados(int? efector, int? deposito, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_InsumosEntregados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_PacientesInternados Procedure
        /// </summary>
        public static StoredProcedure InsPacientesInternados(int? idEfector, int? documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_PacientesInternados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_RecepcionInsumosH Procedure
        /// </summary>
        public static StoredProcedure InsRecepcionInsumosH(DateTime? finicio, DateTime? ffin, int? deposito, int? rubro, int? estado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_RecepcionInsumosH", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@estado", estado, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_RecepcionInternaInsumos Procedure
        /// </summary>
        public static StoredProcedure InsRecepcionInternaInsumos(DateTime? finicio, DateTime? ffin, int? deposito, int? depositoproveedor, int? rubro, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_RecepcionInternaInsumos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@depositoproveedor", depositoproveedor, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_RecuperaMedicamentos Procedure
        /// </summary>
        public static StoredProcedure InsRecuperaMedicamentos(int? rubro, string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_RecuperaMedicamentos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@rubro", rubro, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_TopPedidos Procedure
        /// </summary>
        public static StoredProcedure InsTopPedidos(int? efector, int? deposito, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_TopPedidos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the INS_TopProvisiones Procedure
        /// </summary>
        public static StoredProcedure InsTopProvisiones(int? efector, int? deposito, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("INS_TopProvisiones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@deposito", deposito, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_AgregaArticuloRegPartes Procedure
        /// </summary>
        public static StoredProcedure JmAgregaArticuloRegPartes(string Agente, string FechaP, string Articulo, string PInterno, string LTrabajo, string Usuario, int? idCertificado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_AgregaArticuloRegPartes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Agente", Agente, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@FechaP", FechaP, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Articulo", Articulo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@PInterno", PInterno, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@LTrabajo", LTrabajo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Usuario", Usuario, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idCertificado", idCertificado, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_AntecedentesArticulos Procedure
        /// </summary>
        public static StoredProcedure JmAntecedentesArticulos(string Agente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_AntecedentesArticulos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Agente", Agente, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_BuscaCIE10 Procedure
        /// </summary>
        public static StoredProcedure JmBuscaCIE10(string Codigo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_BuscaCIE10", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Codigo", Codigo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_BuscaPaciente Procedure
        /// </summary>
        public static StoredProcedure JmBuscaPaciente(string idPersonal)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_BuscaPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPersonal", idPersonal, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_BuscaPacienteDNI Procedure
        /// </summary>
        public static StoredProcedure JmBuscaPacienteDNI(string NDocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_BuscaPacienteDNI", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@NDocumento", NDocumento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_BuscaPacienteID Procedure
        /// </summary>
        public static StoredProcedure JmBuscaPacienteID(string Codigo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_BuscaPacienteID", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Codigo", Codigo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_BuscaProfesionalPorMatricula Procedure
        /// </summary>
        public static StoredProcedure JmBuscaProfesionalPorMatricula(string Matricula)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_BuscaProfesionalPorMatricula", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Matricula", Matricula, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_Cargar_Lista_Profesionales Procedure
        /// </summary>
        public static StoredProcedure JmCargarListaProfesionales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_Cargar_Lista_Profesionales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_Cargar_Lista_Profesionales_Responsable Procedure
        /// </summary>
        public static StoredProcedure JmCargarListaProfesionalesResponsable()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_Cargar_Lista_Profesionales_Responsable", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_EfectoresPorNombre Procedure
        /// </summary>
        public static StoredProcedure JmEfectoresPorNombre()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_EfectoresPorNombre", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_EliminaArticuloRegPartes Procedure
        /// </summary>
        public static StoredProcedure JmEliminaArticuloRegPartes(string Agente, string FechaDesde, string FechaHasta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_EliminaArticuloRegPartes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Agente", Agente, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@FechaDesde", FechaDesde, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@FechaHasta", FechaHasta, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_ImprimeFicha Procedure
        /// </summary>
        public static StoredProcedure JmImprimeFicha(int? idJMDato)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_ImprimeFicha", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idJMDato", idJMDato, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_ListaCertificadoMedico Procedure
        /// </summary>
        public static StoredProcedure JmListaCertificadoMedico(string Codigo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_ListaCertificadoMedico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Codigo", Codigo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_MedicoTratanteElimina Procedure
        /// </summary>
        public static StoredProcedure JmMedicoTratanteElimina(int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_MedicoTratanteElimina", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_ProfesionalTratante Procedure
        /// </summary>
        public static StoredProcedure JmProfesionalTratante(int? idJMDato)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_ProfesionalTratante", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idJMDato", idJMDato, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_ProfesionalTratanteFicha Procedure
        /// </summary>
        public static StoredProcedure JmProfesionalTratanteFicha(int? idJMDato)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_ProfesionalTratanteFicha", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idJMDato", idJMDato, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_ProfesionalTratanteSuma Procedure
        /// </summary>
        public static StoredProcedure JmProfesionalTratanteSuma(int? idJMDato)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_ProfesionalTratanteSuma", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idJMDato", idJMDato, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the JM_Responsable Procedure
        /// </summary>
        public static StoredProcedure JmResponsable()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("JM_Responsable", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_ExportacionResultados Procedure
        /// </summary>
        public static StoredProcedure LabExportacionResultados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_ExportacionResultados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_GeneraHTScreening Procedure
        /// </summary>
        public static StoredProcedure LabGeneraHTScreening(string fechaDesde, string fechaHasta, int? idEfectorSolicitante, int? idZona, string numeroDesde, string numeroHasta, int? estado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_GeneraHTScreening", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fechaDesde", fechaDesde, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaHasta", fechaHasta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEfectorSolicitante", idEfectorSolicitante, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@numeroDesde", numeroDesde, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@numeroHasta", numeroHasta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@estado", estado, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_GeneraResultadoEncabezado Procedure
        /// </summary>
        public static StoredProcedure LabGeneraResultadoEncabezado(int? idSolicitudScreening)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_GeneraResultadoEncabezado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSolicitudScreening", idSolicitudScreening, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_GetMenuPrincipal Procedure
        /// </summary>
        public static StoredProcedure LabGetMenuPrincipal(int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_GetMenuPrincipal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_GetMenuSecundario Procedure
        /// </summary>
        public static StoredProcedure LabGetMenuSecundario(int? idMenu, int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_GetMenuSecundario", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idMenu", idMenu, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_GetReactivo Procedure
        /// </summary>
        public static StoredProcedure LabGetReactivo(int? idArea)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_GetReactivo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idArea", idArea, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_ImprimeResultado_pdf Procedure
        /// </summary>
        public static StoredProcedure LabImprimeResultadoPdf(int? idEfector, int? idProtocolo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_ImprimeResultado_pdf", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProtocolo", idProtocolo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_ImprimeResultado2 Procedure
        /// </summary>
        public static StoredProcedure LabImprimeResultado2(int? idEfector, int? idProtocolo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_ImprimeResultado2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idProtocolo", idProtocolo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ItemScreeningList Procedure
        /// </summary>
        public static StoredProcedure LabItemScreeningList()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ItemScreeningList", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_ItemScreeningResultadoList Procedure
        /// </summary>
        public static StoredProcedure LabItemScreeningResultadoList(int? idItemScreening)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_ItemScreeningResultadoList", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idItemScreening", idItemScreening, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ProtocoloScreeningAlta Procedure
        /// </summary>
        public static StoredProcedure LabProtocoloScreeningAlta(string pESolicitudes)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ProtocoloScreeningAlta", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pE_Solicitudes", pESolicitudes, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ScreeningBuscarDerivaciones Procedure
        /// </summary>
        public static StoredProcedure LabScreeningBuscarDerivaciones(string pEfechaRegistroDesde, string pEfechaRegistroHasta, int? pEidEfectorSolicitante, int? pEestado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ScreeningBuscarDerivaciones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pE_fechaRegistroDesde", pEfechaRegistroDesde, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@pE_fechaRegistroHasta", pEfechaRegistroHasta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@pE_idEfectorSolicitante", pEidEfectorSolicitante, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pE_estado", pEestado, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ScreeningComprobante Procedure
        /// </summary>
        public static StoredProcedure LabScreeningComprobante(int? pEidSolicitudScreening)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ScreeningComprobante", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pE_idSolicitudScreening", pEidSolicitudScreening, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ScreeningDerivacionComprobante Procedure
        /// </summary>
        public static StoredProcedure LabScreeningDerivacionComprobante(string pESolicitudes)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ScreeningDerivacionComprobante", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pE_Solicitudes", pESolicitudes, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_ScreeningHojaTrabajo_Nueva Procedure
        /// </summary>
        public static StoredProcedure LabScreeningHojaTrabajoNueva(string pESolicitudes)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_ScreeningHojaTrabajo_Nueva", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pE_Solicitudes", pESolicitudes, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_ScreeningRecepcionSolicitudes Procedure
        /// </summary>
        public static StoredProcedure LabScreeningRecepcionSolicitudes(string fechaInicioRegistro, string fechaFinRegistro, int? idZona, int? idEfectorSolicitante, int? idEstado, int? idEfectorUsuario)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_ScreeningRecepcionSolicitudes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@fechaInicioRegistro", fechaInicioRegistro, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@fechaFinRegistro", fechaFinRegistro, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfectorSolicitante", idEfectorSolicitante, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstado", idEstado, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfectorUsuario", idEfectorUsuario, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the LAB_ScreeningRecuperaDatos Procedure
        /// </summary>
        public static StoredProcedure LabScreeningRecuperaDatos(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("LAB_ScreeningRecuperaDatos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ScreeningReporteResultado Procedure
        /// </summary>
        public static StoredProcedure LabScreeningReporteResultado(int? idSolicitudScreening)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ScreeningReporteResultado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSolicitudScreening", idSolicitudScreening, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ScreeningResultado Procedure
        /// </summary>
        public static StoredProcedure LabScreeningResultado(int? idSolicitudScreening)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ScreeningResultado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idSolicitudScreening", idSolicitudScreening, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Lab_ScreeningSolicitudesGeneradas Procedure
        /// </summary>
        public static StoredProcedure LabScreeningSolicitudesGeneradas(string pEfechaRegistroDesde, string pEfechaRegistroHasta, int? pEidSolicitudScreening, int? pEnumeroTarjeta, int? pEpacNumeroDocumento, int? pEparNumeroDocumento, int? pEidZona, int? pEidEfectorSolicitante)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Lab_ScreeningSolicitudesGeneradas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pE_fechaRegistroDesde", pEfechaRegistroDesde, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@pE_fechaRegistroHasta", pEfechaRegistroHasta, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@pE_idSolicitudScreening", pEidSolicitudScreening, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pE_numeroTarjeta", pEnumeroTarjeta, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pE_pacNumeroDocumento", pEpacNumeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pE_parNumeroDocumento", pEparNumeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pE_idZona", pEidZona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pE_idEfectorSolicitante", pEidEfectorSolicitante, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_EliminarDuplicados Procedure
        /// </summary>
        public static StoredProcedure MamEliminarDuplicados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_EliminarDuplicados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetAnatomiaPatologica Procedure
        /// </summary>
        public static StoredProcedure MamGetAnatomiaPatologica(DateTime? finicio, DateTime? ffin, int? dni, int? idAnatomia)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetAnatomiaPatologica", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idAnatomia", idAnatomia, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetAntecedentesMamas Procedure
        /// </summary>
        public static StoredProcedure MamGetAntecedentesMamas(DateTime? finicio, DateTime? ffin, int? dni, int? idAntecedente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetAntecedentesMamas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idAntecedente", idAntecedente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetCirugia Procedure
        /// </summary>
        public static StoredProcedure MamGetCirugia(DateTime? finicio, DateTime? ffin, int? dni, int? idCirugia)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetCirugia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idCirugia", idCirugia, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetConsultas Procedure
        /// </summary>
        public static StoredProcedure MamGetConsultas(int? efector, DateTime? finicio, DateTime? ffin, int? efectorProcedencia, int? biraddef, DateTime? minicio, DateTime? mfin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetConsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efectorProcedencia", efectorProcedencia, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@biraddef", biraddef, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@minicio", minicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@mfin", mfin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetEcografia Procedure
        /// </summary>
        public static StoredProcedure MamGetEcografia(DateTime? finicio, DateTime? ffin, int? dni, int? idEco)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetEcografia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEco", idEco, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetEfectorInforma Procedure
        /// </summary>
        public static StoredProcedure MamGetEfectorInforma()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetEfectorInforma", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetEInforma Procedure
        /// </summary>
        public static StoredProcedure MamGetEInforma()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetEInforma", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetEstadioClinico Procedure
        /// </summary>
        public static StoredProcedure MamGetEstadioClinico(DateTime? finicio, DateTime? ffin, int? dni, int? idEstadio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetEstadioClinico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstadio", idEstadio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetEstudios Procedure
        /// </summary>
        public static StoredProcedure MamGetEstudios(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetEstudios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetEstudiosAdicionales Procedure
        /// </summary>
        public static StoredProcedure MamGetEstudiosAdicionales(DateTime? finicio, DateTime? ffin, int? dni, int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetEstudiosAdicionales", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetEstudiosHC Procedure
        /// </summary>
        public static StoredProcedure MamGetEstudiosHC(int? dni, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetEstudiosHC", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetExamenesClinicos Procedure
        /// </summary>
        public static StoredProcedure MamGetExamenesClinicos(DateTime? finicio, DateTime? ffin, int? dni, int? idExamen)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetExamenesClinicos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idExamen", idExamen, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetExportacion Procedure
        /// </summary>
        public static StoredProcedure MamGetExportacion(DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetExportacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Mam_GetFichasUsuarios Procedure
        /// </summary>
        public static StoredProcedure MamGetFichasUsuarios(DateTime? finicio, DateTime? ffin, string usuario1, string usuario2)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Mam_GetFichasUsuarios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@usuario1", usuario1, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@usuario2", usuario2, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetMamosHP Procedure
        /// </summary>
        public static StoredProcedure MamGetMamosHP()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetMamosHP", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetMenu Procedure
        /// </summary>
        public static StoredProcedure MamGetMenu(int? perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetMenu", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetPaciente Procedure
        /// </summary>
        public static StoredProcedure MamGetPaciente(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetPiezasQuirurgicas Procedure
        /// </summary>
        public static StoredProcedure MamGetPiezasQuirurgicas(DateTime? finicio, DateTime? ffin, int? dni, int? idPieza)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetPiezasQuirurgicas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idPieza", idPieza, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetProfesionales Procedure
        /// </summary>
        public static StoredProcedure MamGetProfesionales(DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetProfesionales", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetRegistro Procedure
        /// </summary>
        public static StoredProcedure MamGetRegistro(int? id)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetRegistro", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the MAM_GetTratamientos Procedure
        /// </summary>
        public static StoredProcedure MamGetTratamientos(DateTime? finicio, DateTime? ffin, int? dni, int? idTratamiento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("MAM_GetTratamientos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTratamiento", idTratamiento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ODO_Buscar_IDConsulta Procedure
        /// </summary>
        public static StoredProcedure OdoBuscarIDConsulta(int? idTurno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ODO_Buscar_IDConsulta", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idTurno", idTurno, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ODO_Cargar_Combo_CodigosPrestacion Procedure
        /// </summary>
        public static StoredProcedure OdoCargarComboCodigosPrestacion()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ODO_Cargar_Combo_CodigosPrestacion", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ODO_Cargar_Lista_CodigosPrestacion Procedure
        /// </summary>
        public static StoredProcedure OdoCargarListaCodigosPrestacion(int? idAgenda, int? idTurno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ODO_Cargar_Lista_CodigosPrestacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTurno", idTurno, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ODO_Es_Una_Agenda_De_Odontologia Procedure
        /// </summary>
        public static StoredProcedure OdoEsUnaAgendaDeOdontologia(int? idTurno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ODO_Es_Una_Agenda_De_Odontologia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idTurno", idTurno, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ODO_Verificar_Existe_Codigo Procedure
        /// </summary>
        public static StoredProcedure OdoVerificarExisteCodigo(int? idAgenda, int? idTurno, string codigoPrestacion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ODO_Verificar_Existe_Codigo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAgenda", idAgenda, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idTurno", idTurno, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@codigoPrestacion", codigoPrestacion, DbType.AnsiStringFixedLength, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PacientesCeliacosXLS Procedure
        /// </summary>
        public static StoredProcedure PacientesCeliacosXLS()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PacientesCeliacosXLS", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PECAS_SUMAR_insc Procedure
        /// </summary>
        public static StoredProcedure PecasSumarInsc()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PECAS_SUMAR_insc", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PECAS_SUMAR_inscencabezado Procedure
        /// </summary>
        public static StoredProcedure PecasSumarInscencabezado()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PECAS_SUMAR_inscencabezado", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PECAS_SUMAR_inscennomarch Procedure
        /// </summary>
        public static StoredProcedure PecasSumarInscennomarch()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PECAS_SUMAR_inscennomarch", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetAfiliados Procedure
        /// </summary>
        public static StoredProcedure PnGetAfiliados(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetAfiliados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetBeneficiarios Procedure
        /// </summary>
        public static StoredProcedure PnGetBeneficiarios(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetBeneficiarios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetCertificadoSumar Procedure
        /// </summary>
        public static StoredProcedure PnGetCertificadoSumar(string documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetCertificadoSumar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetComporbantesByIdComprobante Procedure
        /// </summary>
        public static StoredProcedure PnGetComporbantesByIdComprobante(int? idComprobante)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetComporbantesByIdComprobante", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idComprobante", idComprobante, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetComprobantesByIdAfiliado Procedure
        /// </summary>
        public static StoredProcedure PnGetComprobantesByIdAfiliado(int? idAfiliado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetComprobantesByIdAfiliado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idAfiliado", idAfiliado, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetComprobantesByIdFactura Procedure
        /// </summary>
        public static StoredProcedure PnGetComprobantesByIdFactura(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetComprobantesByIdFactura", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetComprobantesParaFacturar Procedure
        /// </summary>
        public static StoredProcedure PnGetComprobantesParaFacturar(string cuie, string periodo, int? tipoDePrestacion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetComprobantesParaFacturar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@cuie", cuie, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@periodo", periodo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@tipoDePrestacion", tipoDePrestacion, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetEfectores Procedure
        /// </summary>
        public static StoredProcedure PnGetEfectores(string convenio, string cuie, string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetEfectores", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@convenio", convenio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@cuie", cuie, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetFacturaById Procedure
        /// </summary>
        public static StoredProcedure PnGetFacturaById(int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetFacturaById", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetFacturasByEfector Procedure
        /// </summary>
        public static StoredProcedure PnGetFacturasByEfector(string cuie, int? idFactura)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetFacturasByEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@cuie", cuie, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idFactura", idFactura, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetIngresosByCuie Procedure
        /// </summary>
        public static StoredProcedure PnGetIngresosByCuie(string cuie)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetIngresosByCuie", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@cuie", cuie, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetIngresosEgresosByEfector Procedure
        /// </summary>
        public static StoredProcedure PnGetIngresosEgresosByEfector(string convenio, int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetIngresosEgresosByEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@convenio", convenio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetListadoFacturas Procedure
        /// </summary>
        public static StoredProcedure PnGetListadoFacturas(string FiltroBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetListadoFacturas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FiltroBusqueda", FiltroBusqueda, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetPacienteByID Procedure
        /// </summary>
        public static StoredProcedure PnGetPacienteByID(int? ID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetPacienteByID", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@ID", ID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetPacientes Procedure
        /// </summary>
        public static StoredProcedure PnGetPacientes(string buscar)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@buscar", buscar, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_GetPrestacionesByIdComprobante Procedure
        /// </summary>
        public static StoredProcedure PnGetPrestacionesByIdComprobante(int? idComprobante)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_GetPrestacionesByIdComprobante", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idComprobante", idComprobante, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PN_InsertarPacienteEnPlanSumar Procedure
        /// </summary>
        public static StoredProcedure PnInsertarPacienteEnPlanSumar(int? idpaciente, int? resultado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PN_InsertarPacienteEnPlanSumar", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idpaciente", idpaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@resultado", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ProfesionalList Procedure
        /// </summary>
        public static StoredProcedure ProfesionalList(int? idTipoDoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ProfesionalList", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idTipoDoc", idTipoDoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Prosame_Paciente Procedure
        /// </summary>
        public static StoredProcedure ProsamePaciente(string apellido, string nombre, string Efector, string numerodocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Prosame_Paciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Efector", Efector, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@numerodocumento", numerodocumento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_AgudezaVisual Procedure
        /// </summary>
        public static StoredProcedure PsmAgudezaVisual(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_AgudezaVisual", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_AgudezaVisual_Count Procedure
        /// </summary>
        public static StoredProcedure PsmAgudezaVisualCount(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_AgudezaVisual_Count", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_BuscaPaciente Procedure
        /// </summary>
        public static StoredProcedure PsmBuscaPaciente(string apellido, string nombre, string Efector, string numerodocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_BuscaPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Efector", Efector, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@numerodocumento", numerodocumento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_BuscarDatosPadre Procedure
        /// </summary>
        public static StoredProcedure PsmBuscarDatosPadre(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_BuscarDatosPadre", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_BuscarPac Procedure
        /// </summary>
        public static StoredProcedure PsmBuscarPac(int? NumeroDocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_BuscarPac", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@NumeroDocumento", NumeroDocumento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_BuscarPacExistente Procedure
        /// </summary>
        public static StoredProcedure PsmBuscarPacExistente(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_BuscarPacExistente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_BuscarPacExistenteSipsDNI Procedure
        /// </summary>
        public static StoredProcedure PsmBuscarPacExistenteSipsDNI(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_BuscarPacExistenteSipsDNI", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the psm_Cargar_Combo_Entidades_Ordenado_Para_Subsecretaria Procedure
        /// </summary>
        public static StoredProcedure PsmCargarComboEntidadesOrdenadoParaSubsecretaria()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("psm_Cargar_Combo_Entidades_Ordenado_Para_Subsecretaria", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the psm_Cargar_Combo_Entidades_Ordenado_Para_Zona Procedure
        /// </summary>
        public static StoredProcedure PsmCargarComboEntidadesOrdenadoParaZona(int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("psm_Cargar_Combo_Entidades_Ordenado_Para_Zona", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Cargar_Lista_Departamentos Procedure
        /// </summary>
        public static StoredProcedure PsmCargarListaDepartamentos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Cargar_Lista_Departamentos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Cargar_Lista_Efectores Procedure
        /// </summary>
        public static StoredProcedure PsmCargarListaEfectores()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Cargar_Lista_Efectores", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Cargar_Lista_Establecimientos Procedure
        /// </summary>
        public static StoredProcedure PsmCargarListaEstablecimientos(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Cargar_Lista_Establecimientos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Cargar_Lista_Localidades Procedure
        /// </summary>
        public static StoredProcedure PsmCargarListaLocalidades()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Cargar_Lista_Localidades", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Cargar_Lista_Obras_Sociales Procedure
        /// </summary>
        public static StoredProcedure PsmCargarListaObrasSociales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Cargar_Lista_Obras_Sociales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Cargar_Lista_Profesionales Procedure
        /// </summary>
        public static StoredProcedure PsmCargarListaProfesionales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Cargar_Lista_Profesionales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Cargar_Lista_Zona Procedure
        /// </summary>
        public static StoredProcedure PsmCargarListaZona()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Cargar_Lista_Zona", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_DeleteDerivaciones Procedure
        /// </summary>
        public static StoredProcedure PsmDeleteDerivaciones(int? idProsane)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_DeleteDerivaciones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idProsane", idProsane, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_EFisicoPielFanera Procedure
        /// </summary>
        public static StoredProcedure PsmEFisicoPielFanera(int? idPSMEFisico)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_EFisicoPielFanera", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPSMEFisico", idPSMEFisico, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_ExamenFisico Procedure
        /// </summary>
        public static StoredProcedure PsmExamenFisico(string idPSMEFisico)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_ExamenFisico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPSMEFisico", idPSMEFisico, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Exportar Procedure
        /// </summary>
        public static StoredProcedure PsmExportar()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Exportar", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_ExportarTrasadoraSumar Procedure
        /// </summary>
        public static StoredProcedure PsmExportarTrasadoraSumar()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_ExportarTrasadoraSumar", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Fono Procedure
        /// </summary>
        public static StoredProcedure PsmFono(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Fono", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Fono_Count Procedure
        /// </summary>
        public static StoredProcedure PsmFonoCount(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Fono_Count", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Generar_Reporte Procedure
        /// </summary>
        public static StoredProcedure PsmGenerarReporte(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Generar_Reporte", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Generar_Reporte_Count Procedure
        /// </summary>
        public static StoredProcedure PsmGenerarReporteCount(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Generar_Reporte_Count", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Obesidad Procedure
        /// </summary>
        public static StoredProcedure PsmObesidad(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Obesidad", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Obesidad_Count Procedure
        /// </summary>
        public static StoredProcedure PsmObesidadCount(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Obesidad_Count", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Psm_Paciente Procedure
        /// </summary>
        public static StoredProcedure PsmPaciente()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Psm_Paciente", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_Sobrepeso Procedure
        /// </summary>
        public static StoredProcedure PsmSobrepeso(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_Sobrepeso", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSM_SobrepesoCount Procedure
        /// </summary>
        public static StoredProcedure PsmSobrepesoCount(int? numeroDocumento, int? idEstablecimiento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSM_SobrepesoCount", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEstablecimiento", idEstablecimiento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSMCargar_Combo_Efectores Procedure
        /// </summary>
        public static StoredProcedure PSMCargarComboEfectores()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSMCargar_Combo_Efectores", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the PSMCargar_Combo_Provincia Procedure
        /// </summary>
        public static StoredProcedure PSMCargarComboProvincia()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("PSMCargar_Combo_Provincia", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_AlertaClasificacion Procedure
        /// </summary>
        public static StoredProcedure RemAlertaClasificacion(int? idefector, int? idclasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_AlertaClasificacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idclasif", idclasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_ConsultaClasificados Procedure
        /// </summary>
        public static StoredProcedure RemConsultaClasificados(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_ConsultaClasificados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_DeleteAntecedentes Procedure
        /// </summary>
        public static StoredProcedure RemDeleteAntecedentes(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_DeleteAntecedentes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_DeleteComplicaciones Procedure
        /// </summary>
        public static StoredProcedure RemDeleteComplicaciones(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_DeleteComplicaciones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_DeleteEstudiosOculares Procedure
        /// </summary>
        public static StoredProcedure RemDeleteEstudiosOculares(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_DeleteEstudiosOculares", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_DeleteInternaciones Procedure
        /// </summary>
        public static StoredProcedure RemDeleteInternaciones(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_DeleteInternaciones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_DeleteMedicamentos Procedure
        /// </summary>
        public static StoredProcedure RemDeleteMedicamentos(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_DeleteMedicamentos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_DeleteMedicamentosSeguimiento Procedure
        /// </summary>
        public static StoredProcedure RemDeleteMedicamentosSeguimiento(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_DeleteMedicamentosSeguimiento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_ExportarClasificados Procedure
        /// </summary>
        public static StoredProcedure RemExportarClasificados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_ExportarClasificados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_ExportarPreclasificados Procedure
        /// </summary>
        public static StoredProcedure RemExportarPreclasificados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_ExportarPreclasificados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_ExportarSeguimientos Procedure
        /// </summary>
        public static StoredProcedure RemExportarSeguimientos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_ExportarSeguimientos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_FormularioByNroDoc Procedure
        /// </summary>
        public static StoredProcedure RemFormularioByNroDoc(int? nroDoc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_FormularioByNroDoc", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@nroDoc", nroDoc, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetAntecedentesClasificacion Procedure
        /// </summary>
        public static StoredProcedure RemGetAntecedentesClasificacion(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetAntecedentesClasificacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetAntecedentesFClasificacion Procedure
        /// </summary>
        public static StoredProcedure RemGetAntecedentesFClasificacion(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetAntecedentesFClasificacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetCharts Procedure
        /// </summary>
        public static StoredProcedure RemGetCharts(int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetCharts", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetClasificados Procedure
        /// </summary>
        public static StoredProcedure RemGetClasificados(int? idClasificacion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetClasificados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasificacion", idClasificacion, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetClasificadosConsultas Procedure
        /// </summary>
        public static StoredProcedure RemGetClasificadosConsultas(int? idEfector, int? dni, DateTime? finicio, DateTime? ffin, int? idAntecedente, int? riesgo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetClasificadosConsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idAntecedente", idAntecedente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@riesgo", riesgo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetClasificadosConsultasAntecedentes Procedure
        /// </summary>
        public static StoredProcedure RemGetClasificadosConsultasAntecedentes(int? idEfector, int? dni, DateTime? finicio, DateTime? ffin, int? idAntecedente, int? riesgo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetClasificadosConsultasAntecedentes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idAntecedente", idAntecedente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@riesgo", riesgo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetComplicaciones Procedure
        /// </summary>
        public static StoredProcedure RemGetComplicaciones(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetComplicaciones", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetDosisClasificacion Procedure
        /// </summary>
        public static StoredProcedure RemGetDosisClasificacion(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetDosisClasificacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetDosisSeguimiento Procedure
        /// </summary>
        public static StoredProcedure RemGetDosisSeguimiento(int? idClasif)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetDosisSeguimiento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idClasif", idClasif, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetExaminados Procedure
        /// </summary>
        public static StoredProcedure RemGetExaminados(int? clasificacion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetExaminados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@clasificacion", clasificacion, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetGrafico Procedure
        /// </summary>
        public static StoredProcedure RemGetGrafico(int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetGrafico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetLaboratorios Procedure
        /// </summary>
        public static StoredProcedure RemGetLaboratorios(int? documento, DateTime? fecha)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetLaboratorios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fecha", fecha, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetMenu Procedure
        /// </summary>
        public static StoredProcedure RemGetMenu(int? perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetMenu", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetPacientes Procedure
        /// </summary>
        public static StoredProcedure RemGetPacientes(string buscar)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetPacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@buscar", buscar, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetPreclasificados Procedure
        /// </summary>
        public static StoredProcedure RemGetPreclasificados(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetPreclasificados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetRCVG Procedure
        /// </summary>
        public static StoredProcedure RemGetRCVG(int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetRCVG", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetScore Procedure
        /// </summary>
        public static StoredProcedure RemGetScore(int? FactorRiesgo, int? usuario, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetScore", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@FactorRiesgo", FactorRiesgo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@usuario", usuario, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetScoreEfectores Procedure
        /// </summary>
        public static StoredProcedure RemGetScoreEfectores(int? zona, int? FactorRiesgo, int? idEfector, DateTime? finicio, DateTime? ffin, int? idOsocial, int? firma, int? agente, int? dni, string cs, int? vac, int? pap)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetScoreEfectores", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@zona", zona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@FactorRiesgo", FactorRiesgo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idOsocial", idOsocial, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@firma", firma, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@agente", agente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@cs", cs, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vac", vac, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@pap", pap, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetScoreEmpadronadosNacion Procedure
        /// </summary>
        public static StoredProcedure RemGetScoreEmpadronadosNacion(int? anio, int? periodo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetScoreEmpadronadosNacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@anio", anio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@periodo", periodo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_GetSeguimientos Procedure
        /// </summary>
        public static StoredProcedure RemGetSeguimientos(int? idEfector, int? dni, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_GetSeguimientos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Rem_WSGetClasificados Procedure
        /// </summary>
        public static StoredProcedure RemWSGetClasificados(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Rem_WSGetClasificados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Buscador_En_Entidades Procedure
        /// </summary>
        public static StoredProcedure RisBuscadorEnEntidades()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Buscador_En_Entidades", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Buscador_En_Estudios Procedure
        /// </summary>
        public static StoredProcedure RisBuscadorEnEstudios()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Buscador_En_Estudios", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Buscador_En_Investigadores Procedure
        /// </summary>
        public static StoredProcedure RisBuscadorEnInvestigadores()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Buscador_En_Investigadores", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Buscador_En_LugarRealizacion Procedure
        /// </summary>
        public static StoredProcedure RisBuscadorEnLugarRealizacion()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Buscador_En_LugarRealizacion", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Estudio_Fuente_Recoleccion_Datos Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxEstudioFuenteRecoleccionDatos(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Estudio_Fuente_Recoleccion_Datos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Estudio_Items_Desaprobados Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxEstudioItemsDesaprobados(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Estudio_Items_Desaprobados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Estudio_Poblacion_Vulnerable Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxEstudioPoblacionVulnerable(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Estudio_Poblacion_Vulnerable", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Items_Caracteristicas_Estudio Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxItemsCaracteristicasEstudio(string tipoEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Items_Caracteristicas_Estudio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@tipoEstudio", tipoEstudio, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Items_Caracteristicas_Estudio_Chequeados Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxItemsCaracteristicasEstudioChequeados(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Items_Caracteristicas_Estudio_Chequeados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Items_Desaprobados Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxItemsDesaprobados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Items_Desaprobados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Items_Fuente_Recoleccion_Datos Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxItemsFuenteRecoleccionDatos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Items_Fuente_Recoleccion_Datos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_CheckBox_Items_Participacion_Poblacion_Vulnerable Procedure
        /// </summary>
        public static StoredProcedure RisCargarCheckBoxItemsParticipacionPoblacionVulnerable()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_CheckBox_Items_Participacion_Poblacion_Vulnerable", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Combo_Efectores Procedure
        /// </summary>
        public static StoredProcedure RisCargarComboEfectores()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Combo_Efectores", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Combo_Entidades Procedure
        /// </summary>
        public static StoredProcedure RisCargarComboEntidades(string tipoEntidad)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Combo_Entidades", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@tipoEntidad", tipoEntidad, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Combo_Items_Caracteristicas_Estudio Procedure
        /// </summary>
        public static StoredProcedure RisCargarComboItemsCaracteristicasEstudio(string tipoEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Combo_Items_Caracteristicas_Estudio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@tipoEstudio", tipoEstudio, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Combo_Paises Procedure
        /// </summary>
        public static StoredProcedure RisCargarComboPaises()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Combo_Paises", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Combo_Provincias Procedure
        /// </summary>
        public static StoredProcedure RisCargarComboProvincias()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Combo_Provincias", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Aseguradoras Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaAseguradoras(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Aseguradoras", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Caracteristicas Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaCaracteristicas(int? idEstudio, string tipoEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Caracteristicas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoEstudio", tipoEstudio, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Comite_Etica Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaComiteEtica(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Comite_Etica", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Concentimientos Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaConcentimientos(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Concentimientos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Efectores_Estudio_Multicentrico Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaEfectoresEstudioMulticentrico(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Efectores_Estudio_Multicentrico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Enmiendas Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaEnmiendas(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Enmiendas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Entidades Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaEntidades(int? idEstudio, string tipoEntidad)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Entidades", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoEntidad", tipoEntidad, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Estudios Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaEstudios()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Estudios", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Evaluaciones_Rechazadas Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaEvaluacionesRechazadas(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Evaluaciones_Rechazadas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Fechas_Presentacion_Informe_Avances Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaFechasPresentacionInformeAvances(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Fechas_Presentacion_Informe_Avances", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Informe_Aprobado Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaInformeAprobado(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Informe_Aprobado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Investigadores Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaInvestigadores(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Investigadores", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Items_Desaprobados_Enmiendas Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaItemsDesaprobadosEnmiendas(int? idEnmienda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Items_Desaprobados_Enmiendas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEnmienda", idEnmienda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Lugares_Realizacion Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaLugaresRealizacion(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Lugares_Realizacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Paises_Estudio_Multicentrico Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaPaisesEstudioMulticentrico(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Paises_Estudio_Multicentrico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Provincias_Estudio_Multicentrico Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaProvinciasEstudioMulticentrico(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Provincias_Estudio_Multicentrico", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Cargar_Lista_Vigencias_Polizas Procedure
        /// </summary>
        public static StoredProcedure RisCargarListaVigenciasPolizas(int? idEstudioAeseguradora)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Cargar_Lista_Vigencias_Polizas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudioAeseguradora", idEstudioAeseguradora, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Eliminar_Registros_EnmiendaItemsDesaprobado_NO_UTILIZADO Procedure
        /// </summary>
        public static StoredProcedure RisEliminarRegistrosEnmiendaItemsDesaprobadoNoUtilizado(int? idEnmienda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Eliminar_Registros_EnmiendaItemsDesaprobado_NO_UTILIZADO", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEnmienda", idEnmienda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Eliminar_Registros_EstudioCaracteristicas_NO_UTILIZADO Procedure
        /// </summary>
        public static StoredProcedure RisEliminarRegistrosEstudioCaracteristicasNoUtilizado(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Eliminar_Registros_EstudioCaracteristicas_NO_UTILIZADO", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Eliminar_Registros_EstudioItemsDesaprobado_NO_UTILIZADO Procedure
        /// </summary>
        public static StoredProcedure RisEliminarRegistrosEstudioItemsDesaprobadoNoUtilizado(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Eliminar_Registros_EstudioItemsDesaprobado_NO_UTILIZADO", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Eliminar_Registros_EstudioPoblacionVulnerable Procedure
        /// </summary>
        public static StoredProcedure RisEliminarRegistrosEstudioPoblacionVulnerable(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Eliminar_Registros_EstudioPoblacionVulnerable", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Modificar_Funcion_En_El_Equipo Procedure
        /// </summary>
        public static StoredProcedure RisModificarFuncionEnElEquipo(int? idEstudio, int? idInvestigador, int? idFuncionEnElEquipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Modificar_Funcion_En_El_Equipo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idInvestigador", idInvestigador, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idFuncionEnElEquipo", idFuncionEnElEquipo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Entidad_Investigador Procedure
        /// </summary>
        public static StoredProcedure RisObtenerEntidadInvestigador(int? idInvestigador)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Entidad_Investigador", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInvestigador", idInvestigador, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Funcion_En_El_Equipo Procedure
        /// </summary>
        public static StoredProcedure RisObtenerFuncionEnElEquipo(int? idEstudio, int? idInvestigador)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Funcion_En_El_Equipo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idInvestigador", idInvestigador, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Investigador_Principal Procedure
        /// </summary>
        public static StoredProcedure RisObtenerInvestigadorPrincipal(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Investigador_Principal", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Registros_EnmiendaItemsDesaprobado Procedure
        /// </summary>
        public static StoredProcedure RisObtenerRegistrosEnmiendaItemsDesaprobado(int? idEnmienda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Registros_EnmiendaItemsDesaprobado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEnmienda", idEnmienda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Registros_EstudioCaracteristicas Procedure
        /// </summary>
        public static StoredProcedure RisObtenerRegistrosEstudioCaracteristicas(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Registros_EstudioCaracteristicas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Registros_EstudioFuenteRecoleccionDatos Procedure
        /// </summary>
        public static StoredProcedure RisObtenerRegistrosEstudioFuenteRecoleccionDatos(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Registros_EstudioFuenteRecoleccionDatos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Registros_EstudioItemsDesaprobado Procedure
        /// </summary>
        public static StoredProcedure RisObtenerRegistrosEstudioItemsDesaprobado(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Registros_EstudioItemsDesaprobado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Obtener_Registros_EstudioPoblacionVulnerable Procedure
        /// </summary>
        public static StoredProcedure RisObtenerRegistrosEstudioPoblacionVulnerable(int? idEstudio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Obtener_Registros_EstudioPoblacionVulnerable", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Verificar_Si_Documento_Investigador_Es_Cero Procedure
        /// </summary>
        public static StoredProcedure RisVerificarSiDocumentoInvestigadorEsCero(int? idInvestigador)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Verificar_Si_Documento_Investigador_Es_Cero", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInvestigador", idInvestigador, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Verificar_Si_Existe_Estudio_Investigador Procedure
        /// </summary>
        public static StoredProcedure RisVerificarSiExisteEstudioInvestigador(int? idEstudio, int? idInvestigador)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Verificar_Si_Existe_Estudio_Investigador", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstudio", idEstudio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idInvestigador", idInvestigador, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the RIS_Verificar_Si_Existe_Investigador Procedure
        /// </summary>
        public static StoredProcedure RisVerificarSiExisteInvestigador(int? numeroDocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("RIS_Verificar_Si_Existe_Investigador", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_SSO_AuditDB_SetUser Procedure
        /// </summary>
        public static StoredProcedure SpSsoAuditDBSetUser(string username)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_SSO_AuditDB_SetUser", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@username", username, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_AgendasEspecialidades Procedure
        /// </summary>
        public static StoredProcedure SsAgendasEspecialidades(DateTime? finicio, DateTime? ffin, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_AgendasEspecialidades", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_CantidadPacientes Procedure
        /// </summary>
        public static StoredProcedure SsCantidadPacientes()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_CantidadPacientes", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_EfectoresRecupero Procedure
        /// </summary>
        public static StoredProcedure SsEfectoresRecupero(int? anio, int? mes)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_EfectoresRecupero", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@anio", anio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@mes", mes, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_EfectoresSips Procedure
        /// </summary>
        public static StoredProcedure SsEfectoresSips()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_EfectoresSips", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_EfectoresxZona Procedure
        /// </summary>
        public static StoredProcedure SsEfectoresxZona(int? zona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_EfectoresxZona", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@zona", zona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_EstadoAgendas Procedure
        /// </summary>
        public static StoredProcedure SsEstadoAgendas(DateTime? finicio, DateTime? ffin, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_EstadoAgendas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_EstadoTurnos Procedure
        /// </summary>
        public static StoredProcedure SsEstadoTurnos(DateTime? finicio, DateTime? ffin, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_EstadoTurnos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_GetIndicador1 Procedure
        /// </summary>
        public static StoredProcedure SsGetIndicador1(int? especialidad, int? efector, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_GetIndicador1", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@especialidad", especialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_GetIndicador2 Procedure
        /// </summary>
        public static StoredProcedure SsGetIndicador2(int? especialidad, int? efector, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_GetIndicador2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@especialidad", especialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_GetIndicadorC1 Procedure
        /// </summary>
        public static StoredProcedure SsGetIndicadorC1(int? especialidad, int? efector, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_GetIndicadorC1", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@especialidad", especialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_GetIndicadorC2 Procedure
        /// </summary>
        public static StoredProcedure SsGetIndicadorC2(int? especialidad, int? efector, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_GetIndicadorC2", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@especialidad", especialidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_Medicamentos Procedure
        /// </summary>
        public static StoredProcedure SsMedicamentos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_Medicamentos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_MontosOSocial Procedure
        /// </summary>
        public static StoredProcedure SsMontosOSocial(int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_MontosOSocial", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_MontosRecupero Procedure
        /// </summary>
        public static StoredProcedure SsMontosRecupero(int? anio, int? mes)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_MontosRecupero", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@anio", anio, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@mes", mes, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_MontosxZona Procedure
        /// </summary>
        public static StoredProcedure SsMontosxZona()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_MontosxZona", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_PacientesxZona Procedure
        /// </summary>
        public static StoredProcedure SsPacientesxZona(int? zona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_PacientesxZona", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@zona", zona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_Poblacion Procedure
        /// </summary>
        public static StoredProcedure SsPoblacion(string dpto, int? localidad, string sexo, string anio, int? edad1, int? edad2)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_Poblacion", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dpto", dpto, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@localidad", localidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@sexo", sexo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@anio", anio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@edad1", edad1, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@edad2", edad2, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_Poblacion1 Procedure
        /// </summary>
        public static StoredProcedure SsPoblacion1(string dpto, int? localidad, string sexo, string anio, int? edad1, int? edad2)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_Poblacion1", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dpto", dpto, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@localidad", localidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@sexo", sexo, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@anio", anio, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@edad1", edad1, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@edad2", edad2, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_PoblacionxSexo Procedure
        /// </summary>
        public static StoredProcedure SsPoblacionxSexo(string dpto, int? localidad, int? anio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_PoblacionxSexo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dpto", dpto, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@localidad", localidad, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@anio", anio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_PoblacionxZona Procedure
        /// </summary>
        public static StoredProcedure SsPoblacionxZona(int? anio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_PoblacionxZona", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@anio", anio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_Preclasificados Procedure
        /// </summary>
        public static StoredProcedure SsPreclasificados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_Preclasificados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_RF_CantidadOrdenesPorEfector Procedure
        /// </summary>
        public static StoredProcedure SsRfCantidadOrdenesPorEfector()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_RF_CantidadOrdenesPorEfector", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_TurnosSolicitados Procedure
        /// </summary>
        public static StoredProcedure SsTurnosSolicitados(int? anio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_TurnosSolicitados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@anio", anio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_TurnosxEspecialidad Procedure
        /// </summary>
        public static StoredProcedure SsTurnosxEspecialidad(DateTime? finicio, DateTime? ffin, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_TurnosxEspecialidad", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_TurnosxServicio Procedure
        /// </summary>
        public static StoredProcedure SsTurnosxServicio(DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_TurnosxServicio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_WSCancelarTurnos Procedure
        /// </summary>
        public static StoredProcedure SsWSCancelarTurnos(int? turno)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_WSCancelarTurnos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@turno", turno, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SS_WSTurnos Procedure
        /// </summary>
        public static StoredProcedure SsWSTurnos(int? dni, string codigo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SS_WSTurnos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@codigo", codigo, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SYS_Cargar_Combo_Entidades_Ordenado_Para_Hospital Procedure
        /// </summary>
        public static StoredProcedure SysCargarComboEntidadesOrdenadoParaHospital()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SYS_Cargar_Combo_Entidades_Ordenado_Para_Hospital", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetEspecialidadByEfector Procedure
        /// </summary>
        public static StoredProcedure SysGetEspecialidadByEfector(int? idefector, int? tipo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetEspecialidadByEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipo", tipo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetEspecialidadEfectorList Procedure
        /// </summary>
        public static StoredProcedure SysGetEspecialidadEfectorList(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetEspecialidadEfectorList", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetHistoriasClinicas Procedure
        /// </summary>
        public static StoredProcedure SysGetHistoriasClinicas(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetHistoriasClinicas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetMotivoNI Procedure
        /// </summary>
        public static StoredProcedure SysGetMotivoNI(int? idEstado)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetMotivoNI", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEstado", idEstado, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetPaciente Procedure
        /// </summary>
        public static StoredProcedure SysGetPaciente(int? idEfector, int? numerodocumento, string apellido, string nombre, int? idSexo, DateTime? fechaNacimiento, int? idUsuario, string errorX, int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@numerodocumento", numerodocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.String, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.String, null, null);
        	
            sp.Command.AddParameter("@idSexo", idSexo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@fechaNacimiento", fechaNacimiento, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@idUsuario", idUsuario, DbType.Int32, 0, 10);
        	
            sp.Command.AddOutputParameter("@error", DbType.String, null, null);
            
            sp.Command.AddOutputParameter("@idPaciente", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetProfesionalesByEfector Procedure
        /// </summary>
        public static StoredProcedure SysGetProfesionalesByEfector(int? idefector, int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetProfesionalesByEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetProfesionalesByEfectorList Procedure
        /// </summary>
        public static StoredProcedure SysGetProfesionalesByEfectorList(int? idefector, int? dni, string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetProfesionalesByEfectorList", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetServicioByEfector Procedure
        /// </summary>
        public static StoredProcedure SysGetServicioByEfector(int? idefector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetServicioByEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idefector", idefector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_GetUltimaHC Procedure
        /// </summary>
        public static StoredProcedure SysGetUltimaHC(int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_GetUltimaHC", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_PacAntecedentesFamiliares Procedure
        /// </summary>
        public static StoredProcedure SysPacAntecedentesFamiliares(int? idPaciente, int? idParentesco)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_PacAntecedentesFamiliares", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idParentesco", idParentesco, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_PacAntecedentesFamiliaresElimina Procedure
        /// </summary>
        public static StoredProcedure SysPacAntecedentesFamiliaresElimina(int? idPaciente, int? idParentesco, int? idCie10)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_PacAntecedentesFamiliaresElimina", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idParentesco", idParentesco, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idCie10", idCie10, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sys_ParentescoT Procedure
        /// </summary>
        public static StoredProcedure SysParentescoT(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sys_ParentescoT", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sys_ParentescoTb Procedure
        /// </summary>
        public static StoredProcedure SysParentescoTb()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sys_ParentescoTb", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Sys_UnificaPaciente Procedure
        /// </summary>
        public static StoredProcedure SysUnificaPaciente(int? idPacientePrincipal, int? idPacienteSecundario, bool? inactivarPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sys_UnificaPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPacientePrincipal", idPacientePrincipal, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idPacienteSecundario", idPacienteSecundario, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@inactivarPaciente", inactivarPaciente, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SysGetNroHClinicaxEfector Procedure
        /// </summary>
        public static StoredProcedure SysGetNroHClinicaxEfector(int? efector, int? dni, int? hc, string apellido, string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SysGetNroHClinicaxEfector", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@hc", hc, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SysGetPacientesHC Procedure
        /// </summary>
        public static StoredProcedure SysGetPacientesHC(int? dni, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SysGetPacientesHC", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Tab_DeleteMedicamentos Procedure
        /// </summary>
        public static StoredProcedure TabDeleteMedicamentos(int? idCtrl)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Tab_DeleteMedicamentos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idCtrl", idCtrl, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Tab_GetControles Procedure
        /// </summary>
        public static StoredProcedure TabGetControles(int? dni, int? efector, int? profesional, DateTime? finicio, DateTime? ffin, int? med)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Tab_GetControles", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@profesional", profesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@med", med, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Tab_GetControlMedicamentos Procedure
        /// </summary>
        public static StoredProcedure TabGetControlMedicamentos(int? paciente, int? efector, int? profesional, DateTime? finicio, DateTime? ffin, int? med)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Tab_GetControlMedicamentos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@paciente", paciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@profesional", profesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@med", med, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Tab_GetControlPaciente Procedure
        /// </summary>
        public static StoredProcedure TabGetControlPaciente(int? idPac)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Tab_GetControlPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPac", idPac, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Tab_GetDosisTabaquismo Procedure
        /// </summary>
        public static StoredProcedure TabGetDosisTabaquismo(int? idControl)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Tab_GetDosisTabaquismo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idControl", idControl, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Tab_GetMedicamentos Procedure
        /// </summary>
        public static StoredProcedure TabGetMedicamentos()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Tab_GetMedicamentos", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Tab_GetPaciente Procedure
        /// </summary>
        public static StoredProcedure TabGetPaciente(int? dni, int? zona, int? efector, int? profesional, DateTime? finicio, DateTime? ffin)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Tab_GetPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@zona", zona, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@profesional", profesional, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_EliminoDuplicados Procedure
        /// </summary>
        public static StoredProcedure TamEliminoDuplicados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_EliminoDuplicados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_EliminoDuplicadosHpv Procedure
        /// </summary>
        public static StoredProcedure TamEliminoDuplicadosHpv()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_EliminoDuplicadosHpv", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetBiopsia Procedure
        /// </summary>
        public static StoredProcedure TamGetBiopsia(int? idBiopsia, DateTime? finicio, DateTime? ffin, int? dni, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetBiopsia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idBiopsia", idBiopsia, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetColposcopia Procedure
        /// </summary>
        public static StoredProcedure TamGetColposcopia(int? idColpos, DateTime? finicio, DateTime? ffin, int? dni, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetColposcopia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idColpos", idColpos, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetConsultas Procedure
        /// </summary>
        public static StoredProcedure TamGetConsultas(int? efector, DateTime? finicio, DateTime? ffin, int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetConsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetEstudios Procedure
        /// </summary>
        public static StoredProcedure TamGetEstudios(DateTime? finicio, DateTime? ffin, int? dni, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetEstudios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetEstudiosHP Procedure
        /// </summary>
        public static StoredProcedure TamGetEstudiosHP(DateTime? finicio, DateTime? ffin, int? dni, int? efectorMuestra, int? resultadoHpv)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetEstudiosHP", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efectorMuestra", efectorMuestra, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@resultadoHpv", resultadoHpv, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetHpv Procedure
        /// </summary>
        public static StoredProcedure TamGetHpv(int? idHpv, DateTime? finicio, DateTime? ffin, int? dni, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetHpv", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idHpv", idHpv, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetImprimeResultados Procedure
        /// </summary>
        public static StoredProcedure TamGetImprimeResultados(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetImprimeResultados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetMenu Procedure
        /// </summary>
        public static StoredProcedure TamGetMenu(int? perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetMenu", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetPaciente Procedure
        /// </summary>
        public static StoredProcedure TamGetPaciente(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetPaciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetPap Procedure
        /// </summary>
        public static StoredProcedure TamGetPap(int? idPap, DateTime? finicio, DateTime? ffin, int? dni, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetPap", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPap", idPap, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetResultados Procedure
        /// </summary>
        public static StoredProcedure TamGetResultados(int? idPap, int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetResultados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPap", idPap, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetTipoMaterialBiopsia Procedure
        /// </summary>
        public static StoredProcedure TamGetTipoMaterialBiopsia(int? idBiopsia)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetTipoMaterialBiopsia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idBiopsia", idBiopsia, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TAM_GetTratamiento Procedure
        /// </summary>
        public static StoredProcedure TamGetTratamiento(int? idTrat, DateTime? finicio, DateTime? ffin, int? dni, int? efector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TAM_GetTratamiento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idTrat", idTrat, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@finicio", finicio, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@ffin", ffin, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@efector", efector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Cargar_Efectores_Habilitados Procedure
        /// </summary>
        public static StoredProcedure TupCargarEfectoresHabilitados()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Cargar_Efectores_Habilitados", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Cargar_Lista_De_Interconsultas Procedure
        /// </summary>
        public static StoredProcedure TupCargarListaDeInterconsultas(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Cargar_Lista_De_Interconsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Cargar_Lista_Pacientes Procedure
        /// </summary>
        public static StoredProcedure TupCargarListaPacientes(string numeroDocumento, string apellido, string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Cargar_Lista_Pacientes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@apellido", apellido, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Mostrar_Datos_Interconsultas Procedure
        /// </summary>
        public static StoredProcedure TupMostrarDatosInterconsultas(int? idInterconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Mostrar_Datos_Interconsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idInterconsulta", idInterconsulta, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Obtener_Datos_Paciente Procedure
        /// </summary>
        public static StoredProcedure TupObtenerDatosPaciente(string numeroDocumento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Obtener_Datos_Paciente", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Obtener_id_Efector_Superior Procedure
        /// </summary>
        public static StoredProcedure TupObtenerIdEfectorSuperior(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Obtener_id_Efector_Superior", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Update_Telefono_Celular Procedure
        /// </summary>
        public static StoredProcedure TupUpdateTelefonoCelular(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Update_Telefono_Celular", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Update_Telefono_Fijo Procedure
        /// </summary>
        public static StoredProcedure TupUpdateTelefonoFijo(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Update_Telefono_Fijo", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Verificar_Si_Efector_Esta_Habilitado Procedure
        /// </summary>
        public static StoredProcedure TupVerificarSiEfectorEstaHabilitado(int? idEfector)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Verificar_Si_Efector_Esta_Habilitado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the TUP_Verificar_Si_Existe_Interconsulta_Abierta Procedure
        /// </summary>
        public static StoredProcedure TupVerificarSiExisteInterconsultaAbierta(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("TUP_Verificar_Si_Existe_Interconsulta_Abierta", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the usr_IsPerfilActionEnabled Procedure
        /// </summary>
        public static StoredProcedure UsrIsPerfilActionEnabled(string pagename, string perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("usr_IsPerfilActionEnabled", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pagename", pagename, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the usr_IsPerfilModuleEnabled Procedure
        /// </summary>
        public static StoredProcedure UsrIsPerfilModuleEnabled(string modulename, string perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("usr_IsPerfilModuleEnabled", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@modulename", modulename, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the usr_IsPerfilPageEnabled Procedure
        /// </summary>
        public static StoredProcedure UsrIsPerfilPageEnabled(string pagename, string perfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("usr_IsPerfilPageEnabled", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pagename", pagename, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@perfil", perfil, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the usr_IsPerfilPermisoEnabled Procedure
        /// </summary>
        public static StoredProcedure UsrIsPerfilPermisoEnabled(string pagename, int? idperfil)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("usr_IsPerfilPermisoEnabled", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pagename", pagename, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idperfil", idperfil, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the usr_IsUserIdPageEnabled Procedure
        /// </summary>
        public static StoredProcedure UsrIsUserIdPageEnabled(string pagename, int? idUsuario)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("usr_IsUserIdPageEnabled", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pagename", pagename, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@idUsuario", idUsuario, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the usr_IsUserPageEnabled Procedure
        /// </summary>
        public static StoredProcedure UsrIsUserPageEnabled(string pagename, string usuario)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("usr_IsUserPageEnabled", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@pagename", pagename, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@usuario", usuario, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_Busca_Datos Procedure
        /// </summary>
        public static StoredProcedure VgiBuscaDatos(int? numeroDocumento, int? idEfector, int? idZona)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_Busca_Datos", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@numeroDocumento", numeroDocumento, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idEfector", idEfector, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idZona", idZona, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_Busca_Interconsulta Procedure
        /// </summary>
        public static StoredProcedure VgiBuscaInterconsulta(string CInterconsulta, string CInterconsultaItems)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_Busca_Interconsulta", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@CInterconsulta", CInterconsulta, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CInterconsultaItems", CInterconsultaItems, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the vgi_BuscarPacExistenteSipsDNI Procedure
        /// </summary>
        public static StoredProcedure VgiBuscarPacExistenteSipsDNI(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("vgi_BuscarPacExistenteSipsDNI", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_Cargar_Lista_Obras_Sociales Procedure
        /// </summary>
        public static StoredProcedure VgiCargarListaObrasSociales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_Cargar_Lista_Obras_Sociales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the vgi_Cargar_Lista_Profesionales Procedure
        /// </summary>
        public static StoredProcedure VgiCargarListaProfesionales()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("vgi_Cargar_Lista_Profesionales", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_CInterconsulta Procedure
        /// </summary>
        public static StoredProcedure VgiCInterconsulta(string Interconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_CInterconsulta", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Interconsulta", Interconsulta, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_CriteriosABYD Procedure
        /// </summary>
        public static StoredProcedure VgiCriteriosABYD(int? idVGIDato, int? idVGICriterio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_CriteriosABYD", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVGIDato", idVGIDato, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@idVGICriterio", idVGICriterio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_CriteriosEstado Procedure
        /// </summary>
        public static StoredProcedure VgiCriteriosEstado(int? idVGIDato)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_CriteriosEstado", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idVGIDato", idVGIDato, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_ExisteVGI Procedure
        /// </summary>
        public static StoredProcedure VgiExisteVGI(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_ExisteVGI", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_Interconsulta Procedure
        /// </summary>
        public static StoredProcedure VgiInterconsulta(string Interconsulta)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_Interconsulta", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@Interconsulta", Interconsulta, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_ListaVGI Procedure
        /// </summary>
        public static StoredProcedure VgiListaVGI(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_ListaVGI", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the VGI_MedicamentosC Procedure
        /// </summary>
        public static StoredProcedure VgiMedicamentosC()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("VGI_MedicamentosC", DataService.GetInstance("sicProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSGetAntecedentes Procedure
        /// </summary>
        public static StoredProcedure WSGetAntecedentes(int? documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSGetAntecedentes", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSGetConsultasHPN Procedure
        /// </summary>
        public static StoredProcedure WSGetConsultasHPN(string dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSGetConsultasHPN", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSHCAtencionPrimaria Procedure
        /// </summary>
        public static StoredProcedure WSHCAtencionPrimaria(int? idPaciente, int? tipoBusqueda)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSHCAtencionPrimaria", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@tipoBusqueda", tipoBusqueda, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSHCconsultorios Procedure
        /// </summary>
        public static StoredProcedure WSHCconsultorios(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSHCconsultorios", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSHEventosCentralizados Procedure
        /// </summary>
        public static StoredProcedure WSHEventosCentralizados(int? documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSHEventosCentralizados", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSHistoriaCLinica Procedure
        /// </summary>
        public static StoredProcedure WSHistoriaCLinica(int? idPaciente)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSHistoriaCLinica", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPaciente", idPaciente, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSHistoriaCLinicaLab Procedure
        /// </summary>
        public static StoredProcedure WSHistoriaCLinicaLab(int? dni)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSHistoriaCLinicaLab", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSHistoriaCLinicaLabDetalle Procedure
        /// </summary>
        public static StoredProcedure WSHistoriaCLinicaLabDetalle(int? documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSHistoriaCLinicaLabDetalle", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSInterconsultas Procedure
        /// </summary>
        public static StoredProcedure WSInterconsultas(int? idProfesional)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSInterconsultas", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idProfesional", idProfesional, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSP_Obtener_CodigoINDEC_Barrio Procedure
        /// </summary>
        public static StoredProcedure WspObtenerCodigoINDECBarrio(int? idBarrio)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSP_Obtener_CodigoINDEC_Barrio", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idBarrio", idBarrio, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSP_Obtener_CodigoINDEC_Departamento Procedure
        /// </summary>
        public static StoredProcedure WspObtenerCodigoINDECDepartamento(int? idDepartamento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSP_Obtener_CodigoINDEC_Departamento", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idDepartamento", idDepartamento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSP_Obtener_CodigoINDEC_Localidad Procedure
        /// </summary>
        public static StoredProcedure WspObtenerCodigoINDECLocalidad(int? idLocalidad)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSP_Obtener_CodigoINDEC_Localidad", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idLocalidad", idLocalidad, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSP_Obtener_CodigoINDEC_Pais Procedure
        /// </summary>
        public static StoredProcedure WspObtenerCodigoINDECPais(int? idPais)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSP_Obtener_CodigoINDEC_Pais", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idPais", idPais, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSP_Obtener_CodigoINDEC_Provincia Procedure
        /// </summary>
        public static StoredProcedure WspObtenerCodigoINDECProvincia(int? idProvincia)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSP_Obtener_CodigoINDEC_Provincia", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@idProvincia", idProvincia, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the WSProfesionales Procedure
        /// </summary>
        public static StoredProcedure WSProfesionales(int? dni, string nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WSProfesionales", DataService.GetInstance("sicProvider"), "dbo");
        	
            sp.Command.AddParameter("@dni", dni, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@nombre", nombre, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
    }
    
}
