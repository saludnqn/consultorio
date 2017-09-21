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
    /// Controller class for Guardia_Registros_Estados
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistrosEstadoController
    {
        // Preload our schema..
        GuardiaRegistrosEstado thisSchemaLoad = new GuardiaRegistrosEstado();
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
        public GuardiaRegistrosEstadoCollection FetchAll()
        {
            GuardiaRegistrosEstadoCollection coll = new GuardiaRegistrosEstadoCollection();
            Query qry = new Query(GuardiaRegistrosEstado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosEstadoCollection FetchByID(object Id)
        {
            GuardiaRegistrosEstadoCollection coll = new GuardiaRegistrosEstadoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosEstadoCollection FetchByQuery(Query qry)
        {
            GuardiaRegistrosEstadoCollection coll = new GuardiaRegistrosEstadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaRegistrosEstado.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaRegistrosEstado.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    GuardiaRegistrosEstado item = new GuardiaRegistrosEstado();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre)
	    {
		    GuardiaRegistrosEstado item = new GuardiaRegistrosEstado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
