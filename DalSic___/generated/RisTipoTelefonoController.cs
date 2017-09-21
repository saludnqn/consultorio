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
    /// Controller class for RIS_TipoTelefono
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisTipoTelefonoController
    {
        // Preload our schema..
        RisTipoTelefono thisSchemaLoad = new RisTipoTelefono();
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
        public RisTipoTelefonoCollection FetchAll()
        {
            RisTipoTelefonoCollection coll = new RisTipoTelefonoCollection();
            Query qry = new Query(RisTipoTelefono.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisTipoTelefonoCollection FetchByID(object IdTipoTelefono)
        {
            RisTipoTelefonoCollection coll = new RisTipoTelefonoCollection().Where("idTipoTelefono", IdTipoTelefono).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisTipoTelefonoCollection FetchByQuery(Query qry)
        {
            RisTipoTelefonoCollection coll = new RisTipoTelefonoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoTelefono)
        {
            return (RisTipoTelefono.Delete(IdTipoTelefono) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoTelefono)
        {
            return (RisTipoTelefono.Destroy(IdTipoTelefono) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisTipoTelefono item = new RisTipoTelefono();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoTelefono,string Descripcion)
	    {
		    RisTipoTelefono item = new RisTipoTelefono();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoTelefono = IdTipoTelefono;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
