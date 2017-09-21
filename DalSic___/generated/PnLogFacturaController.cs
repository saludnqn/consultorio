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
    /// Controller class for PN_log_factura
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLogFacturaController
    {
        // Preload our schema..
        PnLogFactura thisSchemaLoad = new PnLogFactura();
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
        public PnLogFacturaCollection FetchAll()
        {
            PnLogFacturaCollection coll = new PnLogFacturaCollection();
            Query qry = new Query(PnLogFactura.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogFacturaCollection FetchByID(object IdLogFactura)
        {
            PnLogFacturaCollection coll = new PnLogFacturaCollection().Where("id_log_factura", IdLogFactura).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogFacturaCollection FetchByQuery(Query qry)
        {
            PnLogFacturaCollection coll = new PnLogFacturaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLogFactura)
        {
            return (PnLogFactura.Delete(IdLogFactura) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLogFactura)
        {
            return (PnLogFactura.Destroy(IdLogFactura) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdFactura,DateTime? Fecha,string Tipo,string Descripcion,string Usuario)
	    {
		    PnLogFactura item = new PnLogFactura();
		    
            item.IdFactura = IdFactura;
            
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
	    public void Update(int IdLogFactura,int IdFactura,DateTime? Fecha,string Tipo,string Descripcion,string Usuario)
	    {
		    PnLogFactura item = new PnLogFactura();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLogFactura = IdLogFactura;
				
			item.IdFactura = IdFactura;
				
			item.Fecha = Fecha;
				
			item.Tipo = Tipo;
				
			item.Descripcion = Descripcion;
				
			item.Usuario = Usuario;
				
	        item.Save(UserName);
	    }
    }
}
