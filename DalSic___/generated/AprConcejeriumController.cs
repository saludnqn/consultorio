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
    /// Controller class for APR_Concejeria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprConcejeriumController
    {
        // Preload our schema..
        AprConcejerium thisSchemaLoad = new AprConcejerium();
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
        public AprConcejeriumCollection FetchAll()
        {
            AprConcejeriumCollection coll = new AprConcejeriumCollection();
            Query qry = new Query(AprConcejerium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprConcejeriumCollection FetchByID(object IdConcejeria)
        {
            AprConcejeriumCollection coll = new AprConcejeriumCollection().Where("idConcejeria", IdConcejeria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprConcejeriumCollection FetchByQuery(Query qry)
        {
            AprConcejeriumCollection coll = new AprConcejeriumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConcejeria)
        {
            return (AprConcejerium.Delete(IdConcejeria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConcejeria)
        {
            return (AprConcejerium.Destroy(IdConcejeria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprConcejerium item = new AprConcejerium();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConcejeria,string Nombre)
	    {
		    AprConcejerium item = new AprConcejerium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConcejeria = IdConcejeria;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
