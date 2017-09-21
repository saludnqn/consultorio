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
    /// Controller class for APR_VisitaDomiciliaria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprVisitaDomiciliariumController
    {
        // Preload our schema..
        AprVisitaDomiciliarium thisSchemaLoad = new AprVisitaDomiciliarium();
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
        public AprVisitaDomiciliariumCollection FetchAll()
        {
            AprVisitaDomiciliariumCollection coll = new AprVisitaDomiciliariumCollection();
            Query qry = new Query(AprVisitaDomiciliarium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprVisitaDomiciliariumCollection FetchByID(object IdVisitaDomiciliaria)
        {
            AprVisitaDomiciliariumCollection coll = new AprVisitaDomiciliariumCollection().Where("idVisitaDomiciliaria", IdVisitaDomiciliaria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprVisitaDomiciliariumCollection FetchByQuery(Query qry)
        {
            AprVisitaDomiciliariumCollection coll = new AprVisitaDomiciliariumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdVisitaDomiciliaria)
        {
            return (AprVisitaDomiciliarium.Delete(IdVisitaDomiciliaria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdVisitaDomiciliaria)
        {
            return (AprVisitaDomiciliarium.Destroy(IdVisitaDomiciliaria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int IdMotivoVisitaDomiciliaria,DateTime Fecha,string OtroMotivo,string Personal,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprVisitaDomiciliarium item = new AprVisitaDomiciliarium();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdMotivoVisitaDomiciliaria = IdMotivoVisitaDomiciliaria;
            
            item.Fecha = Fecha;
            
            item.OtroMotivo = OtroMotivo;
            
            item.Personal = Personal;
            
            item.Observacion = Observacion;
            
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
	    public void Update(int IdVisitaDomiciliaria,int IdPaciente,int IdMotivoVisitaDomiciliaria,DateTime Fecha,string OtroMotivo,string Personal,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprVisitaDomiciliarium item = new AprVisitaDomiciliarium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdVisitaDomiciliaria = IdVisitaDomiciliaria;
				
			item.IdPaciente = IdPaciente;
				
			item.IdMotivoVisitaDomiciliaria = IdMotivoVisitaDomiciliaria;
				
			item.Fecha = Fecha;
				
			item.OtroMotivo = OtroMotivo;
				
			item.Personal = Personal;
				
			item.Observacion = Observacion;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
