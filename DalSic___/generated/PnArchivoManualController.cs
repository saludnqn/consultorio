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
    /// Controller class for PN_archivo_manual
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnArchivoManualController
    {
        // Preload our schema..
        PnArchivoManual thisSchemaLoad = new PnArchivoManual();
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
        public PnArchivoManualCollection FetchAll()
        {
            PnArchivoManualCollection coll = new PnArchivoManualCollection();
            Query qry = new Query(PnArchivoManual.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivoManualCollection FetchByID(object IdArchivoManual)
        {
            PnArchivoManualCollection coll = new PnArchivoManualCollection().Where("id_archivo_manual", IdArchivoManual).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivoManualCollection FetchByQuery(Query qry)
        {
            PnArchivoManualCollection coll = new PnArchivoManualCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdArchivoManual)
        {
            return (PnArchivoManual.Delete(IdArchivoManual) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdArchivoManual)
        {
            return (PnArchivoManual.Destroy(IdArchivoManual) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdManual,string Nombre,string Tipo,int? Tamaño)
	    {
		    PnArchivoManual item = new PnArchivoManual();
		    
            item.IdManual = IdManual;
            
            item.Nombre = Nombre;
            
            item.Tipo = Tipo;
            
            item.Tamaño = Tamaño;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdArchivoManual,int IdManual,string Nombre,string Tipo,int? Tamaño)
	    {
		    PnArchivoManual item = new PnArchivoManual();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdArchivoManual = IdArchivoManual;
				
			item.IdManual = IdManual;
				
			item.Nombre = Nombre;
				
			item.Tipo = Tipo;
				
			item.Tamaño = Tamaño;
				
	        item.Save(UserName);
	    }
    }
}
