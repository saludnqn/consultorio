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
    /// Controller class for PN_permisos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPermisoController
    {
        // Preload our schema..
        PnPermiso thisSchemaLoad = new PnPermiso();
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
        public PnPermisoCollection FetchAll()
        {
            PnPermisoCollection coll = new PnPermisoCollection();
            Query qry = new Query(PnPermiso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisoCollection FetchByID(object IdPermiso)
        {
            PnPermisoCollection coll = new PnPermisoCollection().Where("id_permiso", IdPermiso).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisoCollection FetchByQuery(Query qry)
        {
            PnPermisoCollection coll = new PnPermisoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPermiso)
        {
            return (PnPermiso.Delete(IdPermiso) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPermiso)
        {
            return (PnPermiso.Destroy(IdPermiso) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdTipo,string Uname,string Descripcion,string Dir,string CreateUser,string ModifUser,DateTime? CreateDate,DateTime? ModifDate)
	    {
		    PnPermiso item = new PnPermiso();
		    
            item.IdTipo = IdTipo;
            
            item.Uname = Uname;
            
            item.Descripcion = Descripcion;
            
            item.Dir = Dir;
            
            item.CreateUser = CreateUser;
            
            item.ModifUser = ModifUser;
            
            item.CreateDate = CreateDate;
            
            item.ModifDate = ModifDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPermiso,int IdTipo,string Uname,string Descripcion,string Dir,string CreateUser,string ModifUser,DateTime? CreateDate,DateTime? ModifDate)
	    {
		    PnPermiso item = new PnPermiso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPermiso = IdPermiso;
				
			item.IdTipo = IdTipo;
				
			item.Uname = Uname;
				
			item.Descripcion = Descripcion;
				
			item.Dir = Dir;
				
			item.CreateUser = CreateUser;
				
			item.ModifUser = ModifUser;
				
			item.CreateDate = CreateDate;
				
			item.ModifDate = ModifDate;
				
	        item.Save(UserName);
	    }
    }
}
