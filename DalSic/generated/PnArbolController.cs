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
    /// Controller class for PN_arbol
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnArbolController
    {
        // Preload our schema..
        PnArbol thisSchemaLoad = new PnArbol();
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
        public PnArbolCollection FetchAll()
        {
            PnArbolCollection coll = new PnArbolCollection();
            Query qry = new Query(PnArbol.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArbolCollection FetchByID(object IdNodo)
        {
            PnArbolCollection coll = new PnArbolCollection().Where("id_nodo", IdNodo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArbolCollection FetchByQuery(Query qry)
        {
            PnArbolCollection coll = new PnArbolCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNodo)
        {
            return (PnArbol.Delete(IdNodo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNodo)
        {
            return (PnArbol.Destroy(IdNodo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdPermisoPadre,int? IdPermisoHijo)
	    {
		    PnArbol item = new PnArbol();
		    
            item.IdPermisoPadre = IdPermisoPadre;
            
            item.IdPermisoHijo = IdPermisoHijo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNodo,int? IdPermisoPadre,int? IdPermisoHijo)
	    {
		    PnArbol item = new PnArbol();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNodo = IdNodo;
				
			item.IdPermisoPadre = IdPermisoPadre;
				
			item.IdPermisoHijo = IdPermisoHijo;
				
	        item.Save(UserName);
	    }
    }
}
