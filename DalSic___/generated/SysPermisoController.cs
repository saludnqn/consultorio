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
    /// Controller class for Sys_Permiso
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysPermisoController
    {
        // Preload our schema..
        SysPermiso thisSchemaLoad = new SysPermiso();
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
        public SysPermisoCollection FetchAll()
        {
            SysPermisoCollection coll = new SysPermisoCollection();
            Query qry = new Query(SysPermiso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPermisoCollection FetchByID(object IdPermiso)
        {
            SysPermisoCollection coll = new SysPermisoCollection().Where("idPermiso", IdPermiso).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPermisoCollection FetchByQuery(Query qry)
        {
            SysPermisoCollection coll = new SysPermisoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPermiso)
        {
            return (SysPermiso.Delete(IdPermiso) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPermiso)
        {
            return (SysPermiso.Destroy(IdPermiso) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPerfil,int IdMenu,string Permiso)
	    {
		    SysPermiso item = new SysPermiso();
		    
            item.IdEfector = IdEfector;
            
            item.IdPerfil = IdPerfil;
            
            item.IdMenu = IdMenu;
            
            item.Permiso = Permiso;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPermiso,int IdEfector,int IdPerfil,int IdMenu,string Permiso)
	    {
		    SysPermiso item = new SysPermiso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPermiso = IdPermiso;
				
			item.IdEfector = IdEfector;
				
			item.IdPerfil = IdPerfil;
				
			item.IdMenu = IdMenu;
				
			item.Permiso = Permiso;
				
	        item.Save(UserName);
	    }
    }
}
