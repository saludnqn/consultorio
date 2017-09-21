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
    /// Controller class for PN_archivos_casos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnArchivosCasoController
    {
        // Preload our schema..
        PnArchivosCaso thisSchemaLoad = new PnArchivosCaso();
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
        public PnArchivosCasoCollection FetchAll()
        {
            PnArchivosCasoCollection coll = new PnArchivosCasoCollection();
            Query qry = new Query(PnArchivosCaso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivosCasoCollection FetchByID(object Id)
        {
            PnArchivosCasoCollection coll = new PnArchivosCasoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivosCasoCollection FetchByQuery(Query qry)
        {
            PnArchivosCasoCollection coll = new PnArchivosCasoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PnArchivosCaso.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PnArchivosCaso.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Idcaso)
	    {
		    PnArchivosCaso item = new PnArchivosCaso();
		    
            item.Idcaso = Idcaso;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int Idcaso)
	    {
		    PnArchivosCaso item = new PnArchivosCaso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Idcaso = Idcaso;
				
	        item.Save(UserName);
	    }
    }
}
