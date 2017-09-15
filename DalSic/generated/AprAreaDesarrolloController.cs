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
    /// Controller class for APR_AreaDesarrollo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAreaDesarrolloController
    {
        // Preload our schema..
        AprAreaDesarrollo thisSchemaLoad = new AprAreaDesarrollo();
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
        public AprAreaDesarrolloCollection FetchAll()
        {
            AprAreaDesarrolloCollection coll = new AprAreaDesarrolloCollection();
            Query qry = new Query(AprAreaDesarrollo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAreaDesarrolloCollection FetchByID(object IdAreaDesarrollo)
        {
            AprAreaDesarrolloCollection coll = new AprAreaDesarrolloCollection().Where("idAreaDesarrollo", IdAreaDesarrollo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAreaDesarrolloCollection FetchByQuery(Query qry)
        {
            AprAreaDesarrolloCollection coll = new AprAreaDesarrolloCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAreaDesarrollo)
        {
            return (AprAreaDesarrollo.Delete(IdAreaDesarrollo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAreaDesarrollo)
        {
            return (AprAreaDesarrollo.Destroy(IdAreaDesarrollo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int? EdadLimite,int? Orden,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprAreaDesarrollo item = new AprAreaDesarrollo();
		    
            item.Nombre = Nombre;
            
            item.EdadLimite = EdadLimite;
            
            item.Orden = Orden;
            
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
	    public void Update(int IdAreaDesarrollo,string Nombre,int? EdadLimite,int? Orden,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprAreaDesarrollo item = new AprAreaDesarrollo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAreaDesarrollo = IdAreaDesarrollo;
				
			item.Nombre = Nombre;
				
			item.EdadLimite = EdadLimite;
				
			item.Orden = Orden;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
