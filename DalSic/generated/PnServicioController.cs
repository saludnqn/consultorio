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
    /// Controller class for PN_servicio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnServicioController
    {
        // Preload our schema..
        PnServicio thisSchemaLoad = new PnServicio();
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
        public PnServicioCollection FetchAll()
        {
            PnServicioCollection coll = new PnServicioCollection();
            Query qry = new Query(PnServicio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnServicioCollection FetchByID(object IdServicio)
        {
            PnServicioCollection coll = new PnServicioCollection().Where("id_servicio", IdServicio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnServicioCollection FetchByQuery(Query qry)
        {
            PnServicioCollection coll = new PnServicioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdServicio)
        {
            return (PnServicio.Delete(IdServicio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdServicio)
        {
            return (PnServicio.Destroy(IdServicio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    PnServicio item = new PnServicio();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdServicio,string Descripcion)
	    {
		    PnServicio item = new PnServicio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdServicio = IdServicio;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
