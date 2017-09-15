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
    /// Controller class for PN_permisos_usuarios
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPermisosUsuarioController
    {
        // Preload our schema..
        PnPermisosUsuario thisSchemaLoad = new PnPermisosUsuario();
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
        public PnPermisosUsuarioCollection FetchAll()
        {
            PnPermisosUsuarioCollection coll = new PnPermisosUsuarioCollection();
            Query qry = new Query(PnPermisosUsuario.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosUsuarioCollection FetchByID(object IdPu)
        {
            PnPermisosUsuarioCollection coll = new PnPermisosUsuarioCollection().Where("id_pu", IdPu).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosUsuarioCollection FetchByQuery(Query qry)
        {
            PnPermisosUsuarioCollection coll = new PnPermisosUsuarioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPu)
        {
            return (PnPermisosUsuario.Delete(IdPu) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPu)
        {
            return (PnPermisosUsuario.Destroy(IdPu) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPermiso,int IdUsuario)
	    {
		    PnPermisosUsuario item = new PnPermisosUsuario();
		    
            item.IdPermiso = IdPermiso;
            
            item.IdUsuario = IdUsuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPu,int IdPermiso,int IdUsuario)
	    {
		    PnPermisosUsuario item = new PnPermisosUsuario();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPu = IdPu;
				
			item.IdPermiso = IdPermiso;
				
			item.IdUsuario = IdUsuario;
				
	        item.Save(UserName);
	    }
    }
}
