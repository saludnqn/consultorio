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
    /// Controller class for APR_Interconsulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprInterconsultumController
    {
        // Preload our schema..
        AprInterconsultum thisSchemaLoad = new AprInterconsultum();
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
        public AprInterconsultumCollection FetchAll()
        {
            AprInterconsultumCollection coll = new AprInterconsultumCollection();
            Query qry = new Query(AprInterconsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprInterconsultumCollection FetchByID(object IdInterconsulta)
        {
            AprInterconsultumCollection coll = new AprInterconsultumCollection().Where("idInterconsulta", IdInterconsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprInterconsultumCollection FetchByQuery(Query qry)
        {
            AprInterconsultumCollection coll = new AprInterconsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInterconsulta)
        {
            return (AprInterconsultum.Delete(IdInterconsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInterconsulta)
        {
            return (AprInterconsultum.Destroy(IdInterconsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdHistoriaClinicaPerinatal,int IdEfector,DateTime? Fecha,string Motivo,string Observaciones,int IdProfesional,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprInterconsultum item = new AprInterconsultum();
		    
            item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
            
            item.IdEfector = IdEfector;
            
            item.Fecha = Fecha;
            
            item.Motivo = Motivo;
            
            item.Observaciones = Observaciones;
            
            item.IdProfesional = IdProfesional;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInterconsulta,int IdHistoriaClinicaPerinatal,int IdEfector,DateTime? Fecha,string Motivo,string Observaciones,int IdProfesional,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprInterconsultum item = new AprInterconsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInterconsulta = IdInterconsulta;
				
			item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
				
			item.IdEfector = IdEfector;
				
			item.Fecha = Fecha;
				
			item.Motivo = Motivo;
				
			item.Observaciones = Observaciones;
				
			item.IdProfesional = IdProfesional;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
