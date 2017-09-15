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
    /// Controller class for PN_promociones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPromocioneController
    {
        // Preload our schema..
        PnPromocione thisSchemaLoad = new PnPromocione();
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
        public PnPromocioneCollection FetchAll()
        {
            PnPromocioneCollection coll = new PnPromocioneCollection();
            Query qry = new Query(PnPromocione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPromocioneCollection FetchByID(object IdLegajo)
        {
            PnPromocioneCollection coll = new PnPromocioneCollection().Where("id_legajo", IdLegajo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPromocioneCollection FetchByQuery(Query qry)
        {
            PnPromocioneCollection coll = new PnPromocioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLegajo)
        {
            return (PnPromocione.Delete(IdLegajo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLegajo)
        {
            return (PnPromocione.Destroy(IdLegajo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime Fecha,short IdCategoria,string Comentario)
	    {
		    PnPromocione item = new PnPromocione();
		    
            item.Fecha = Fecha;
            
            item.IdCategoria = IdCategoria;
            
            item.Comentario = Comentario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLegajo,DateTime Fecha,short IdCategoria,string Comentario)
	    {
		    PnPromocione item = new PnPromocione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLegajo = IdLegajo;
				
			item.Fecha = Fecha;
				
			item.IdCategoria = IdCategoria;
				
			item.Comentario = Comentario;
				
	        item.Save(UserName);
	    }
    }
}
