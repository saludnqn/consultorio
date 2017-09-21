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
    /// Controller class for APR_EstadoNutricional
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprEstadoNutricionalController
    {
        // Preload our schema..
        AprEstadoNutricional thisSchemaLoad = new AprEstadoNutricional();
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
        public AprEstadoNutricionalCollection FetchAll()
        {
            AprEstadoNutricionalCollection coll = new AprEstadoNutricionalCollection();
            Query qry = new Query(AprEstadoNutricional.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEstadoNutricionalCollection FetchByID(object IdEstadoNutricional)
        {
            AprEstadoNutricionalCollection coll = new AprEstadoNutricionalCollection().Where("idEstadoNutricional", IdEstadoNutricional).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEstadoNutricionalCollection FetchByQuery(Query qry)
        {
            AprEstadoNutricionalCollection coll = new AprEstadoNutricionalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstadoNutricional)
        {
            return (AprEstadoNutricional.Delete(IdEstadoNutricional) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstadoNutricional)
        {
            return (AprEstadoNutricional.Destroy(IdEstadoNutricional) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int MinSemanas,int MaxSemanas,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprEstadoNutricional item = new AprEstadoNutricional();
		    
            item.Nombre = Nombre;
            
            item.MinSemanas = MinSemanas;
            
            item.MaxSemanas = MaxSemanas;
            
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
	    public void Update(int IdEstadoNutricional,string Nombre,int MinSemanas,int MaxSemanas,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprEstadoNutricional item = new AprEstadoNutricional();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstadoNutricional = IdEstadoNutricional;
				
			item.Nombre = Nombre;
				
			item.MinSemanas = MinSemanas;
				
			item.MaxSemanas = MaxSemanas;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
