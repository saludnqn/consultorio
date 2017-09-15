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
    /// Controller class for PN_credito
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCreditoController
    {
        // Preload our schema..
        PnCredito thisSchemaLoad = new PnCredito();
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
        public PnCreditoCollection FetchAll()
        {
            PnCreditoCollection coll = new PnCreditoCollection();
            Query qry = new Query(PnCredito.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCreditoCollection FetchByID(object IdCredito)
        {
            PnCreditoCollection coll = new PnCreditoCollection().Where("id_credito", IdCredito).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCreditoCollection FetchByQuery(Query qry)
        {
            PnCreditoCollection coll = new PnCreditoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCredito)
        {
            return (PnCredito.Delete(IdCredito) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCredito)
        {
            return (PnCredito.Destroy(IdCredito) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(decimal? Cantidad,int IdFactura,int IdNomenclador,int IdMotivoD,decimal? Monto,string CodigoCred,string ObservacionesCred)
	    {
		    PnCredito item = new PnCredito();
		    
            item.Cantidad = Cantidad;
            
            item.IdFactura = IdFactura;
            
            item.IdNomenclador = IdNomenclador;
            
            item.IdMotivoD = IdMotivoD;
            
            item.Monto = Monto;
            
            item.CodigoCred = CodigoCred;
            
            item.ObservacionesCred = ObservacionesCred;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCredito,decimal? Cantidad,int IdFactura,int IdNomenclador,int IdMotivoD,decimal? Monto,string CodigoCred,string ObservacionesCred)
	    {
		    PnCredito item = new PnCredito();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCredito = IdCredito;
				
			item.Cantidad = Cantidad;
				
			item.IdFactura = IdFactura;
				
			item.IdNomenclador = IdNomenclador;
				
			item.IdMotivoD = IdMotivoD;
				
			item.Monto = Monto;
				
			item.CodigoCred = CodigoCred;
				
			item.ObservacionesCred = ObservacionesCred;
				
	        item.Save(UserName);
	    }
    }
}
