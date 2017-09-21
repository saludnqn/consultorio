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
    /// Controller class for APR_FactorRiesgo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprFactorRiesgoController
    {
        // Preload our schema..
        AprFactorRiesgo thisSchemaLoad = new AprFactorRiesgo();
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
        public AprFactorRiesgoCollection FetchAll()
        {
            AprFactorRiesgoCollection coll = new AprFactorRiesgoCollection();
            Query qry = new Query(AprFactorRiesgo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFactorRiesgoCollection FetchByID(object IdFactorRiesgo)
        {
            AprFactorRiesgoCollection coll = new AprFactorRiesgoCollection().Where("idFactorRiesgo", IdFactorRiesgo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFactorRiesgoCollection FetchByQuery(Query qry)
        {
            AprFactorRiesgoCollection coll = new AprFactorRiesgoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFactorRiesgo)
        {
            return (AprFactorRiesgo.Delete(IdFactorRiesgo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFactorRiesgo)
        {
            return (AprFactorRiesgo.Destroy(IdFactorRiesgo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,bool Estatico,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprFactorRiesgo item = new AprFactorRiesgo();
		    
            item.Nombre = Nombre;
            
            item.Estatico = Estatico;
            
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
	    public void Update(int IdFactorRiesgo,string Nombre,bool Estatico,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprFactorRiesgo item = new AprFactorRiesgo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFactorRiesgo = IdFactorRiesgo;
				
			item.Nombre = Nombre;
				
			item.Estatico = Estatico;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
