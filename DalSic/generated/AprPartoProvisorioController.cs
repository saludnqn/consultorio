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
    /// Controller class for APR_PartoProvisorio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprPartoProvisorioController
    {
        // Preload our schema..
        AprPartoProvisorio thisSchemaLoad = new AprPartoProvisorio();
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
        public AprPartoProvisorioCollection FetchAll()
        {
            AprPartoProvisorioCollection coll = new AprPartoProvisorioCollection();
            Query qry = new Query(AprPartoProvisorio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprPartoProvisorioCollection FetchByID(object IdParto)
        {
            AprPartoProvisorioCollection coll = new AprPartoProvisorioCollection().Where("idParto", IdParto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprPartoProvisorioCollection FetchByQuery(Query qry)
        {
            AprPartoProvisorioCollection coll = new AprPartoProvisorioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdParto)
        {
            return (AprPartoProvisorio.Delete(IdParto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdParto)
        {
            return (AprPartoProvisorio.Destroy(IdParto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEfectorParto,int IdPaciente,int? IdHistoriaClinicaPerinatal,bool? Parto,DateTime? FechaNacimiento,int? IdTerminacionParto,decimal? EdadGestacional,int? Peso,int? APGAR1,int? APGAR5,bool? ManejoActivoAlumbramiento,DateTime? FechaPrimerControlPuerperio,string NotaPrimerControlPuerperio,DateTime? FechaSegundoControlPuerperio,string NotaSegundoControlPuerperio,string Observaciones,bool Activa,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdProfesional)
	    {
		    AprPartoProvisorio item = new AprPartoProvisorio();
		    
            item.IdEfectorParto = IdEfectorParto;
            
            item.IdPaciente = IdPaciente;
            
            item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
            
            item.Parto = Parto;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.IdTerminacionParto = IdTerminacionParto;
            
            item.EdadGestacional = EdadGestacional;
            
            item.Peso = Peso;
            
            item.APGAR1 = APGAR1;
            
            item.APGAR5 = APGAR5;
            
            item.ManejoActivoAlumbramiento = ManejoActivoAlumbramiento;
            
            item.FechaPrimerControlPuerperio = FechaPrimerControlPuerperio;
            
            item.NotaPrimerControlPuerperio = NotaPrimerControlPuerperio;
            
            item.FechaSegundoControlPuerperio = FechaSegundoControlPuerperio;
            
            item.NotaSegundoControlPuerperio = NotaSegundoControlPuerperio;
            
            item.Observaciones = Observaciones;
            
            item.Activa = Activa;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdProfesional = IdProfesional;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdParto,int? IdEfectorParto,int IdPaciente,int? IdHistoriaClinicaPerinatal,bool? Parto,DateTime? FechaNacimiento,int? IdTerminacionParto,decimal? EdadGestacional,int? Peso,int? APGAR1,int? APGAR5,bool? ManejoActivoAlumbramiento,DateTime? FechaPrimerControlPuerperio,string NotaPrimerControlPuerperio,DateTime? FechaSegundoControlPuerperio,string NotaSegundoControlPuerperio,string Observaciones,bool Activa,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdProfesional)
	    {
		    AprPartoProvisorio item = new AprPartoProvisorio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdParto = IdParto;
				
			item.IdEfectorParto = IdEfectorParto;
				
			item.IdPaciente = IdPaciente;
				
			item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
				
			item.Parto = Parto;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.IdTerminacionParto = IdTerminacionParto;
				
			item.EdadGestacional = EdadGestacional;
				
			item.Peso = Peso;
				
			item.APGAR1 = APGAR1;
				
			item.APGAR5 = APGAR5;
				
			item.ManejoActivoAlumbramiento = ManejoActivoAlumbramiento;
				
			item.FechaPrimerControlPuerperio = FechaPrimerControlPuerperio;
				
			item.NotaPrimerControlPuerperio = NotaPrimerControlPuerperio;
				
			item.FechaSegundoControlPuerperio = FechaSegundoControlPuerperio;
				
			item.NotaSegundoControlPuerperio = NotaSegundoControlPuerperio;
				
			item.Observaciones = Observaciones;
				
			item.Activa = Activa;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdProfesional = IdProfesional;
				
	        item.Save(UserName);
	    }
    }
}
