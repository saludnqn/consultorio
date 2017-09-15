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
    /// Controller class for Guardia_Registros
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistroController
    {
        // Preload our schema..
        GuardiaRegistro thisSchemaLoad = new GuardiaRegistro();
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
        public GuardiaRegistroCollection FetchAll()
        {
            GuardiaRegistroCollection coll = new GuardiaRegistroCollection();
            Query qry = new Query(GuardiaRegistro.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistroCollection FetchByID(object Id)
        {
            GuardiaRegistroCollection coll = new GuardiaRegistroCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistroCollection FetchByQuery(Query qry)
        {
            GuardiaRegistroCollection coll = new GuardiaRegistroCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaRegistro.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaRegistro.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEfector,bool TipoGuardia,int Historia,DateTime? IngresoFechaHora,int? IngresoTipo,DateTime? AtencionFechaHora,DateTime? EgresoFechaHora,int? EgresoTipo,int? EgresoUbicacion,int Clasificacion,string MedicoCabecera,string MotivoConsulta,string DatosEnfermeria,string Interrogatorio,string EvolucionEnfermeria,int? MedicoResponsable,string EvolucionMedica,string DiagnosticoPresuntivo,string DiagnosticoDefinitivo,int? DiagnosticoDefinitivoCIE10,string Observaciones,int EstadoActual,int? EstadoUbicacion,int? EstadoTurno,bool? EstadoTurnoLlamado,DateTime? TurnoLlamadoFechaHora,bool? RecuperoFinancieroPrinted,bool? C2,bool? PresentaCarnetVacunacion,bool? VacunacionCompleta,bool? PlanNacer,bool? PlanNacerPosta,bool? PlanNacerInternacion,DateTime? AuditIngresoFechaHora,DateTime? AuditAtencionFechaHora,DateTime? AuditEgresoFechaHora)
	    {
		    GuardiaRegistro item = new GuardiaRegistro();
		    
            item.IdEfector = IdEfector;
            
            item.TipoGuardia = TipoGuardia;
            
            item.Historia = Historia;
            
            item.IngresoFechaHora = IngresoFechaHora;
            
            item.IngresoTipo = IngresoTipo;
            
            item.AtencionFechaHora = AtencionFechaHora;
            
            item.EgresoFechaHora = EgresoFechaHora;
            
            item.EgresoTipo = EgresoTipo;
            
            item.EgresoUbicacion = EgresoUbicacion;
            
            item.Clasificacion = Clasificacion;
            
            item.MedicoCabecera = MedicoCabecera;
            
            item.MotivoConsulta = MotivoConsulta;
            
            item.DatosEnfermeria = DatosEnfermeria;
            
            item.Interrogatorio = Interrogatorio;
            
            item.EvolucionEnfermeria = EvolucionEnfermeria;
            
            item.MedicoResponsable = MedicoResponsable;
            
            item.EvolucionMedica = EvolucionMedica;
            
            item.DiagnosticoPresuntivo = DiagnosticoPresuntivo;
            
            item.DiagnosticoDefinitivo = DiagnosticoDefinitivo;
            
            item.DiagnosticoDefinitivoCIE10 = DiagnosticoDefinitivoCIE10;
            
            item.Observaciones = Observaciones;
            
            item.EstadoActual = EstadoActual;
            
            item.EstadoUbicacion = EstadoUbicacion;
            
            item.EstadoTurno = EstadoTurno;
            
            item.EstadoTurnoLlamado = EstadoTurnoLlamado;
            
            item.TurnoLlamadoFechaHora = TurnoLlamadoFechaHora;
            
            item.RecuperoFinancieroPrinted = RecuperoFinancieroPrinted;
            
            item.C2 = C2;
            
            item.PresentaCarnetVacunacion = PresentaCarnetVacunacion;
            
            item.VacunacionCompleta = VacunacionCompleta;
            
            item.PlanNacer = PlanNacer;
            
            item.PlanNacerPosta = PlanNacerPosta;
            
            item.PlanNacerInternacion = PlanNacerInternacion;
            
            item.AuditIngresoFechaHora = AuditIngresoFechaHora;
            
            item.AuditAtencionFechaHora = AuditAtencionFechaHora;
            
            item.AuditEgresoFechaHora = AuditEgresoFechaHora;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdEfector,bool TipoGuardia,int Historia,DateTime? IngresoFechaHora,int? IngresoTipo,DateTime? AtencionFechaHora,DateTime? EgresoFechaHora,int? EgresoTipo,int? EgresoUbicacion,int Clasificacion,string MedicoCabecera,string MotivoConsulta,string DatosEnfermeria,string Interrogatorio,string EvolucionEnfermeria,int? MedicoResponsable,string EvolucionMedica,string DiagnosticoPresuntivo,string DiagnosticoDefinitivo,int? DiagnosticoDefinitivoCIE10,string Observaciones,int EstadoActual,int? EstadoUbicacion,int? EstadoTurno,bool? EstadoTurnoLlamado,DateTime? TurnoLlamadoFechaHora,bool? RecuperoFinancieroPrinted,bool? C2,bool? PresentaCarnetVacunacion,bool? VacunacionCompleta,bool? PlanNacer,bool? PlanNacerPosta,bool? PlanNacerInternacion,DateTime? AuditIngresoFechaHora,DateTime? AuditAtencionFechaHora,DateTime? AuditEgresoFechaHora)
	    {
		    GuardiaRegistro item = new GuardiaRegistro();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdEfector = IdEfector;
				
			item.TipoGuardia = TipoGuardia;
				
			item.Historia = Historia;
				
			item.IngresoFechaHora = IngresoFechaHora;
				
			item.IngresoTipo = IngresoTipo;
				
			item.AtencionFechaHora = AtencionFechaHora;
				
			item.EgresoFechaHora = EgresoFechaHora;
				
			item.EgresoTipo = EgresoTipo;
				
			item.EgresoUbicacion = EgresoUbicacion;
				
			item.Clasificacion = Clasificacion;
				
			item.MedicoCabecera = MedicoCabecera;
				
			item.MotivoConsulta = MotivoConsulta;
				
			item.DatosEnfermeria = DatosEnfermeria;
				
			item.Interrogatorio = Interrogatorio;
				
			item.EvolucionEnfermeria = EvolucionEnfermeria;
				
			item.MedicoResponsable = MedicoResponsable;
				
			item.EvolucionMedica = EvolucionMedica;
				
			item.DiagnosticoPresuntivo = DiagnosticoPresuntivo;
				
			item.DiagnosticoDefinitivo = DiagnosticoDefinitivo;
				
			item.DiagnosticoDefinitivoCIE10 = DiagnosticoDefinitivoCIE10;
				
			item.Observaciones = Observaciones;
				
			item.EstadoActual = EstadoActual;
				
			item.EstadoUbicacion = EstadoUbicacion;
				
			item.EstadoTurno = EstadoTurno;
				
			item.EstadoTurnoLlamado = EstadoTurnoLlamado;
				
			item.TurnoLlamadoFechaHora = TurnoLlamadoFechaHora;
				
			item.RecuperoFinancieroPrinted = RecuperoFinancieroPrinted;
				
			item.C2 = C2;
				
			item.PresentaCarnetVacunacion = PresentaCarnetVacunacion;
				
			item.VacunacionCompleta = VacunacionCompleta;
				
			item.PlanNacer = PlanNacer;
				
			item.PlanNacerPosta = PlanNacerPosta;
				
			item.PlanNacerInternacion = PlanNacerInternacion;
				
			item.AuditIngresoFechaHora = AuditIngresoFechaHora;
				
			item.AuditAtencionFechaHora = AuditAtencionFechaHora;
				
			item.AuditEgresoFechaHora = AuditEgresoFechaHora;
				
	        item.Save(UserName);
	    }
    }
}
