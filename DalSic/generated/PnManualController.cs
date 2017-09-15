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
    /// Controller class for PN_manual
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnManualController
    {
        // Preload our schema..
        PnManual thisSchemaLoad = new PnManual();
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
        public PnManualCollection FetchAll()
        {
            PnManualCollection coll = new PnManualCollection();
            Query qry = new Query(PnManual.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnManualCollection FetchByID(object IdManual)
        {
            PnManualCollection coll = new PnManualCollection().Where("id_manual", IdManual).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnManualCollection FetchByQuery(Query qry)
        {
            PnManualCollection coll = new PnManualCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdManual)
        {
            return (PnManual.Delete(IdManual) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdManual)
        {
            return (PnManual.Destroy(IdManual) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Titulo,string Descripcion,short? Estado,short? Historial,int? IdDistrito,int? IdClasificacion)
	    {
		    PnManual item = new PnManual();
		    
            item.Titulo = Titulo;
            
            item.Descripcion = Descripcion;
            
            item.Estado = Estado;
            
            item.Historial = Historial;
            
            item.IdDistrito = IdDistrito;
            
            item.IdClasificacion = IdClasificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdManual,string Titulo,string Descripcion,short? Estado,short? Historial,int? IdDistrito,int? IdClasificacion)
	    {
		    PnManual item = new PnManual();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdManual = IdManual;
				
			item.Titulo = Titulo;
				
			item.Descripcion = Descripcion;
				
			item.Estado = Estado;
				
			item.Historial = Historial;
				
			item.IdDistrito = IdDistrito;
				
			item.IdClasificacion = IdClasificacion;
				
	        item.Save(UserName);
	    }
    }
}
