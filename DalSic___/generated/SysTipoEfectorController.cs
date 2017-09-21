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
    /// Controller class for Sys_TipoEfector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysTipoEfectorController
    {
        // Preload our schema..
        SysTipoEfector thisSchemaLoad = new SysTipoEfector();
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
        public SysTipoEfectorCollection FetchAll()
        {
            SysTipoEfectorCollection coll = new SysTipoEfectorCollection();
            Query qry = new Query(SysTipoEfector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysTipoEfectorCollection FetchByID(object IdTipoEfector)
        {
            SysTipoEfectorCollection coll = new SysTipoEfectorCollection().Where("idTipoEfector", IdTipoEfector).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysTipoEfectorCollection FetchByQuery(Query qry)
        {
            SysTipoEfectorCollection coll = new SysTipoEfectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoEfector)
        {
            return (SysTipoEfector.Delete(IdTipoEfector) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoEfector)
        {
            return (SysTipoEfector.Destroy(IdTipoEfector) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysTipoEfector item = new SysTipoEfector();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoEfector,string Nombre)
	    {
		    SysTipoEfector item = new SysTipoEfector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoEfector = IdTipoEfector;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
