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
    /// Controller class for APR_FormaConcejeria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprFormaConcejeriumController
    {
        // Preload our schema..
        AprFormaConcejerium thisSchemaLoad = new AprFormaConcejerium();
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
        public AprFormaConcejeriumCollection FetchAll()
        {
            AprFormaConcejeriumCollection coll = new AprFormaConcejeriumCollection();
            Query qry = new Query(AprFormaConcejerium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFormaConcejeriumCollection FetchByID(object IdFormaConcejeria)
        {
            AprFormaConcejeriumCollection coll = new AprFormaConcejeriumCollection().Where("idFormaConcejeria", IdFormaConcejeria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFormaConcejeriumCollection FetchByQuery(Query qry)
        {
            AprFormaConcejeriumCollection coll = new AprFormaConcejeriumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFormaConcejeria)
        {
            return (AprFormaConcejerium.Delete(IdFormaConcejeria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFormaConcejeria)
        {
            return (AprFormaConcejerium.Destroy(IdFormaConcejeria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprFormaConcejerium item = new AprFormaConcejerium();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFormaConcejeria,string Nombre)
	    {
		    AprFormaConcejerium item = new AprFormaConcejerium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFormaConcejeria = IdFormaConcejeria;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
