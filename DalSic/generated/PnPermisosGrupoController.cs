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
    /// Controller class for PN_permisos_grupos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPermisosGrupoController
    {
        // Preload our schema..
        PnPermisosGrupo thisSchemaLoad = new PnPermisosGrupo();
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
        public PnPermisosGrupoCollection FetchAll()
        {
            PnPermisosGrupoCollection coll = new PnPermisosGrupoCollection();
            Query qry = new Query(PnPermisosGrupo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosGrupoCollection FetchByID(object IdPg)
        {
            PnPermisosGrupoCollection coll = new PnPermisosGrupoCollection().Where("id_pg", IdPg).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosGrupoCollection FetchByQuery(Query qry)
        {
            PnPermisosGrupoCollection coll = new PnPermisosGrupoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPg)
        {
            return (PnPermisosGrupo.Delete(IdPg) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPg)
        {
            return (PnPermisosGrupo.Destroy(IdPg) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPermiso,int IdGrupo)
	    {
		    PnPermisosGrupo item = new PnPermisosGrupo();
		    
            item.IdPermiso = IdPermiso;
            
            item.IdGrupo = IdGrupo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPg,int IdPermiso,int IdGrupo)
	    {
		    PnPermisosGrupo item = new PnPermisosGrupo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPg = IdPg;
				
			item.IdPermiso = IdPermiso;
				
			item.IdGrupo = IdGrupo;
				
	        item.Save(UserName);
	    }
    }
}
