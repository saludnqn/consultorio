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
    /// Controller class for PN_log_comprobante
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLogComprobanteController
    {
        // Preload our schema..
        PnLogComprobante thisSchemaLoad = new PnLogComprobante();
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
        public PnLogComprobanteCollection FetchAll()
        {
            PnLogComprobanteCollection coll = new PnLogComprobanteCollection();
            Query qry = new Query(PnLogComprobante.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogComprobanteCollection FetchByID(object IdLogComprobante)
        {
            PnLogComprobanteCollection coll = new PnLogComprobanteCollection().Where("id_log_comprobante", IdLogComprobante).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogComprobanteCollection FetchByQuery(Query qry)
        {
            PnLogComprobanteCollection coll = new PnLogComprobanteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLogComprobante)
        {
            return (PnLogComprobante.Delete(IdLogComprobante) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLogComprobante)
        {
            return (PnLogComprobante.Destroy(IdLogComprobante) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdComprobante,DateTime? Fecha,string Tipo,string Descripcion,string Usuario)
	    {
		    PnLogComprobante item = new PnLogComprobante();
		    
            item.IdComprobante = IdComprobante;
            
            item.Fecha = Fecha;
            
            item.Tipo = Tipo;
            
            item.Descripcion = Descripcion;
            
            item.Usuario = Usuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLogComprobante,int IdComprobante,DateTime? Fecha,string Tipo,string Descripcion,string Usuario)
	    {
		    PnLogComprobante item = new PnLogComprobante();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLogComprobante = IdLogComprobante;
				
			item.IdComprobante = IdComprobante;
				
			item.Fecha = Fecha;
				
			item.Tipo = Tipo;
				
			item.Descripcion = Descripcion;
				
			item.Usuario = Usuario;
				
	        item.Save(UserName);
	    }
    }
}
