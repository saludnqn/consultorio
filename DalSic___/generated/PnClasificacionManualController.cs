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
    /// Controller class for PN_clasificacion_manual
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnClasificacionManualController
    {
        // Preload our schema..
        PnClasificacionManual thisSchemaLoad = new PnClasificacionManual();
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
        public PnClasificacionManualCollection FetchAll()
        {
            PnClasificacionManualCollection coll = new PnClasificacionManualCollection();
            Query qry = new Query(PnClasificacionManual.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnClasificacionManualCollection FetchByID(object IdClasificacion)
        {
            PnClasificacionManualCollection coll = new PnClasificacionManualCollection().Where("id_clasificacion", IdClasificacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnClasificacionManualCollection FetchByQuery(Query qry)
        {
            PnClasificacionManualCollection coll = new PnClasificacionManualCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdClasificacion)
        {
            return (PnClasificacionManual.Delete(IdClasificacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdClasificacion)
        {
            return (PnClasificacionManual.Destroy(IdClasificacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,string Activo)
	    {
		    PnClasificacionManual item = new PnClasificacionManual();
		    
            item.Descripcion = Descripcion;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdClasificacion,string Descripcion,string Activo)
	    {
		    PnClasificacionManual item = new PnClasificacionManual();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdClasificacion = IdClasificacion;
				
			item.Descripcion = Descripcion;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
