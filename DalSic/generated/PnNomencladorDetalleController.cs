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
    /// Controller class for PN_nomenclador_detalle
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnNomencladorDetalleController
    {
        // Preload our schema..
        PnNomencladorDetalle thisSchemaLoad = new PnNomencladorDetalle();
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
        public PnNomencladorDetalleCollection FetchAll()
        {
            PnNomencladorDetalleCollection coll = new PnNomencladorDetalleCollection();
            Query qry = new Query(PnNomencladorDetalle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNomencladorDetalleCollection FetchByID(object IdNomencladorDetalle)
        {
            PnNomencladorDetalleCollection coll = new PnNomencladorDetalleCollection().Where("id_nomenclador_detalle", IdNomencladorDetalle).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNomencladorDetalleCollection FetchByQuery(Query qry)
        {
            PnNomencladorDetalleCollection coll = new PnNomencladorDetalleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNomencladorDetalle)
        {
            return (PnNomencladorDetalle.Delete(IdNomencladorDetalle) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNomencladorDetalle)
        {
            return (PnNomencladorDetalle.Destroy(IdNomencladorDetalle) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,DateTime? FechaDesde,DateTime? FechaHasta,int ModoFacturacion)
	    {
		    PnNomencladorDetalle item = new PnNomencladorDetalle();
		    
            item.Descripcion = Descripcion;
            
            item.FechaDesde = FechaDesde;
            
            item.FechaHasta = FechaHasta;
            
            item.ModoFacturacion = ModoFacturacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNomencladorDetalle,string Descripcion,DateTime? FechaDesde,DateTime? FechaHasta,int ModoFacturacion)
	    {
		    PnNomencladorDetalle item = new PnNomencladorDetalle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNomencladorDetalle = IdNomencladorDetalle;
				
			item.Descripcion = Descripcion;
				
			item.FechaDesde = FechaDesde;
				
			item.FechaHasta = FechaHasta;
				
			item.ModoFacturacion = ModoFacturacion;
				
	        item.Save(UserName);
	    }
    }
}
