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
    /// Controller class for PN_permisos_sesion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPermisosSesionController
    {
        // Preload our schema..
        PnPermisosSesion thisSchemaLoad = new PnPermisosSesion();
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
        public PnPermisosSesionCollection FetchAll()
        {
            PnPermisosSesionCollection coll = new PnPermisosSesionCollection();
            Query qry = new Query(PnPermisosSesion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosSesionCollection FetchByID(object IdPermisosSesion)
        {
            PnPermisosSesionCollection coll = new PnPermisosSesionCollection().Where("id_permisos_sesion", IdPermisosSesion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosSesionCollection FetchByQuery(Query qry)
        {
            PnPermisosSesionCollection coll = new PnPermisosSesionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPermisosSesion)
        {
            return (PnPermisosSesion.Delete(IdPermisosSesion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPermisosSesion)
        {
            return (PnPermisosSesion.Destroy(IdPermisosSesion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUsuario,string Data)
	    {
		    PnPermisosSesion item = new PnPermisosSesion();
		    
            item.IdUsuario = IdUsuario;
            
            item.Data = Data;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPermisosSesion,int IdUsuario,string Data)
	    {
		    PnPermisosSesion item = new PnPermisosSesion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPermisosSesion = IdPermisosSesion;
				
			item.IdUsuario = IdUsuario;
				
			item.Data = Data;
				
	        item.Save(UserName);
	    }
    }
}
