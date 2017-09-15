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
    /// Controller class for PN_permisos_actuales
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPermisosActualeController
    {
        // Preload our schema..
        PnPermisosActuale thisSchemaLoad = new PnPermisosActuale();
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
        public PnPermisosActualeCollection FetchAll()
        {
            PnPermisosActualeCollection coll = new PnPermisosActualeCollection();
            Query qry = new Query(PnPermisosActuale.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosActualeCollection FetchByID(object IdPermisosActuales)
        {
            PnPermisosActualeCollection coll = new PnPermisosActualeCollection().Where("id_permisos_actuales", IdPermisosActuales).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPermisosActualeCollection FetchByQuery(Query qry)
        {
            PnPermisosActualeCollection coll = new PnPermisosActualeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPermisosActuales)
        {
            return (PnPermisosActuale.Delete(IdPermisosActuales) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPermisosActuales)
        {
            return (PnPermisosActuale.Destroy(IdPermisosActuales) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUsuario,string Data)
	    {
		    PnPermisosActuale item = new PnPermisosActuale();
		    
            item.IdUsuario = IdUsuario;
            
            item.Data = Data;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPermisosActuales,int IdUsuario,string Data)
	    {
		    PnPermisosActuale item = new PnPermisosActuale();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPermisosActuales = IdPermisosActuales;
				
			item.IdUsuario = IdUsuario;
				
			item.Data = Data;
				
	        item.Save(UserName);
	    }
    }
}
