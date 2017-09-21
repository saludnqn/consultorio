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
    /// Controller class for Guardia_Triage
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaTriageController
    {
        // Preload our schema..
        GuardiaTriage thisSchemaLoad = new GuardiaTriage();
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
        public GuardiaTriageCollection FetchAll()
        {
            GuardiaTriageCollection coll = new GuardiaTriageCollection();
            Query qry = new Query(GuardiaTriage.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTriageCollection FetchByID(object Id)
        {
            GuardiaTriageCollection coll = new GuardiaTriageCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTriageCollection FetchByQuery(Query qry)
        {
            GuardiaTriageCollection coll = new GuardiaTriageCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaTriage.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaTriage.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int RegistroGuardia,int? IdEfector,DateTime FechaHora,string TensionArterial,int? FrecuenciaCardiaca,int? FrecuenciaRespiratoria,double? Temperatura,int? SaturacionOxigeno,int? GlasgowOcular,int? GlasgowVerbal,int? GlasgowMotor,double? Peso,string PupilasTamano,string PupilasReactividad,string PupilasSimetria,string Sensorio,string Sibilancia,string MuscAccesorio,string IngresoAlimentacionCant,string IngresoAlimentacionTipo,string IngresoSolucion,string IngresoOtros,string EgresoDepos,string EgresoOrina,string EgresoVomito,string EgresoSng,string EgresoOtros,string Observaciones,int? AuditUser,int? EscalaDelDolor,int? IdClasificacion,bool? Triage)
	    {
		    GuardiaTriage item = new GuardiaTriage();
		    
            item.RegistroGuardia = RegistroGuardia;
            
            item.IdEfector = IdEfector;
            
            item.FechaHora = FechaHora;
            
            item.TensionArterial = TensionArterial;
            
            item.FrecuenciaCardiaca = FrecuenciaCardiaca;
            
            item.FrecuenciaRespiratoria = FrecuenciaRespiratoria;
            
            item.Temperatura = Temperatura;
            
            item.SaturacionOxigeno = SaturacionOxigeno;
            
            item.GlasgowOcular = GlasgowOcular;
            
            item.GlasgowVerbal = GlasgowVerbal;
            
            item.GlasgowMotor = GlasgowMotor;
            
            item.Peso = Peso;
            
            item.PupilasTamano = PupilasTamano;
            
            item.PupilasReactividad = PupilasReactividad;
            
            item.PupilasSimetria = PupilasSimetria;
            
            item.Sensorio = Sensorio;
            
            item.Sibilancia = Sibilancia;
            
            item.MuscAccesorio = MuscAccesorio;
            
            item.IngresoAlimentacionCant = IngresoAlimentacionCant;
            
            item.IngresoAlimentacionTipo = IngresoAlimentacionTipo;
            
            item.IngresoSolucion = IngresoSolucion;
            
            item.IngresoOtros = IngresoOtros;
            
            item.EgresoDepos = EgresoDepos;
            
            item.EgresoOrina = EgresoOrina;
            
            item.EgresoVomito = EgresoVomito;
            
            item.EgresoSng = EgresoSng;
            
            item.EgresoOtros = EgresoOtros;
            
            item.Observaciones = Observaciones;
            
            item.AuditUser = AuditUser;
            
            item.EscalaDelDolor = EscalaDelDolor;
            
            item.IdClasificacion = IdClasificacion;
            
            item.Triage = Triage;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int RegistroGuardia,int? IdEfector,DateTime FechaHora,string TensionArterial,int? FrecuenciaCardiaca,int? FrecuenciaRespiratoria,double? Temperatura,int? SaturacionOxigeno,int? GlasgowOcular,int? GlasgowVerbal,int? GlasgowMotor,double? Peso,string PupilasTamano,string PupilasReactividad,string PupilasSimetria,string Sensorio,string Sibilancia,string MuscAccesorio,string IngresoAlimentacionCant,string IngresoAlimentacionTipo,string IngresoSolucion,string IngresoOtros,string EgresoDepos,string EgresoOrina,string EgresoVomito,string EgresoSng,string EgresoOtros,string Observaciones,int? AuditUser,int? EscalaDelDolor,int? IdClasificacion,bool? Triage)
	    {
		    GuardiaTriage item = new GuardiaTriage();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.RegistroGuardia = RegistroGuardia;
				
			item.IdEfector = IdEfector;
				
			item.FechaHora = FechaHora;
				
			item.TensionArterial = TensionArterial;
				
			item.FrecuenciaCardiaca = FrecuenciaCardiaca;
				
			item.FrecuenciaRespiratoria = FrecuenciaRespiratoria;
				
			item.Temperatura = Temperatura;
				
			item.SaturacionOxigeno = SaturacionOxigeno;
				
			item.GlasgowOcular = GlasgowOcular;
				
			item.GlasgowVerbal = GlasgowVerbal;
				
			item.GlasgowMotor = GlasgowMotor;
				
			item.Peso = Peso;
				
			item.PupilasTamano = PupilasTamano;
				
			item.PupilasReactividad = PupilasReactividad;
				
			item.PupilasSimetria = PupilasSimetria;
				
			item.Sensorio = Sensorio;
				
			item.Sibilancia = Sibilancia;
				
			item.MuscAccesorio = MuscAccesorio;
				
			item.IngresoAlimentacionCant = IngresoAlimentacionCant;
				
			item.IngresoAlimentacionTipo = IngresoAlimentacionTipo;
				
			item.IngresoSolucion = IngresoSolucion;
				
			item.IngresoOtros = IngresoOtros;
				
			item.EgresoDepos = EgresoDepos;
				
			item.EgresoOrina = EgresoOrina;
				
			item.EgresoVomito = EgresoVomito;
				
			item.EgresoSng = EgresoSng;
				
			item.EgresoOtros = EgresoOtros;
				
			item.Observaciones = Observaciones;
				
			item.AuditUser = AuditUser;
				
			item.EscalaDelDolor = EscalaDelDolor;
				
			item.IdClasificacion = IdClasificacion;
				
			item.Triage = Triage;
				
	        item.Save(UserName);
	    }
    }
}
