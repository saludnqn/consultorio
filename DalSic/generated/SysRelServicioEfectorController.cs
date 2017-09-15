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
    /// Controller class for Sys_RelServicioEfector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelServicioEfectorController
    {
        // Preload our schema..
        SysRelServicioEfector thisSchemaLoad = new SysRelServicioEfector();
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
        public SysRelServicioEfectorCollection FetchAll()
        {
            SysRelServicioEfectorCollection coll = new SysRelServicioEfectorCollection();
            Query qry = new Query(SysRelServicioEfector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelServicioEfectorCollection FetchByID(object IdRelServicioEfector)
        {
            SysRelServicioEfectorCollection coll = new SysRelServicioEfectorCollection().Where("idRelServicioEfector", IdRelServicioEfector).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelServicioEfectorCollection FetchByQuery(Query qry)
        {
            SysRelServicioEfectorCollection coll = new SysRelServicioEfectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelServicioEfector)
        {
            return (SysRelServicioEfector.Delete(IdRelServicioEfector) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelServicioEfector)
        {
            return (SysRelServicioEfector.Destroy(IdRelServicioEfector) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdServicio,int IdEfector)
	    {
		    SysRelServicioEfector item = new SysRelServicioEfector();
		    
            item.IdServicio = IdServicio;
            
            item.IdEfector = IdEfector;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelServicioEfector,int IdServicio,int IdEfector)
	    {
		    SysRelServicioEfector item = new SysRelServicioEfector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelServicioEfector = IdRelServicioEfector;
				
			item.IdServicio = IdServicio;
				
			item.IdEfector = IdEfector;
				
	        item.Save(UserName);
	    }
    }
}
