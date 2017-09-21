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
    /// Controller class for Guardia_Registros_Clasificaciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistrosClasificacioneController
    {
        // Preload our schema..
        GuardiaRegistrosClasificacione thisSchemaLoad = new GuardiaRegistrosClasificacione();
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
        public GuardiaRegistrosClasificacioneCollection FetchAll()
        {
            GuardiaRegistrosClasificacioneCollection coll = new GuardiaRegistrosClasificacioneCollection();
            Query qry = new Query(GuardiaRegistrosClasificacione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosClasificacioneCollection FetchByID(object Id)
        {
            GuardiaRegistrosClasificacioneCollection coll = new GuardiaRegistrosClasificacioneCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosClasificacioneCollection FetchByQuery(Query qry)
        {
            GuardiaRegistrosClasificacioneCollection coll = new GuardiaRegistrosClasificacioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaRegistrosClasificacione.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaRegistrosClasificacione.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Id,string Nombre)
	    {
		    GuardiaRegistrosClasificacione item = new GuardiaRegistrosClasificacione();
		    
            item.Id = Id;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre)
	    {
		    GuardiaRegistrosClasificacione item = new GuardiaRegistrosClasificacione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
