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
    /// Controller class for PN_debito
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDebitoController
    {
        // Preload our schema..
        PnDebito thisSchemaLoad = new PnDebito();
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
        public PnDebitoCollection FetchAll()
        {
            PnDebitoCollection coll = new PnDebitoCollection();
            Query qry = new Query(PnDebito.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDebitoCollection FetchByID(object IdDebito)
        {
            PnDebitoCollection coll = new PnDebitoCollection().Where("id_debito", IdDebito).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDebitoCollection FetchByQuery(Query qry)
        {
            PnDebitoCollection coll = new PnDebitoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDebito)
        {
            return (PnDebito.Delete(IdDebito) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDebito)
        {
            return (PnDebito.Destroy(IdDebito) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdFactura,int IdNomenclador,decimal? Cantidad,int IdMotivoD,decimal? Monto,string DocumentoDeb,string ApellidoDeb,string NombreDeb,string CodigoDeb,string ObservacionesDeb)
	    {
		    PnDebito item = new PnDebito();
		    
            item.IdFactura = IdFactura;
            
            item.IdNomenclador = IdNomenclador;
            
            item.Cantidad = Cantidad;
            
            item.IdMotivoD = IdMotivoD;
            
            item.Monto = Monto;
            
            item.DocumentoDeb = DocumentoDeb;
            
            item.ApellidoDeb = ApellidoDeb;
            
            item.NombreDeb = NombreDeb;
            
            item.CodigoDeb = CodigoDeb;
            
            item.ObservacionesDeb = ObservacionesDeb;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDebito,int IdFactura,int IdNomenclador,decimal? Cantidad,int IdMotivoD,decimal? Monto,string DocumentoDeb,string ApellidoDeb,string NombreDeb,string CodigoDeb,string ObservacionesDeb)
	    {
		    PnDebito item = new PnDebito();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDebito = IdDebito;
				
			item.IdFactura = IdFactura;
				
			item.IdNomenclador = IdNomenclador;
				
			item.Cantidad = Cantidad;
				
			item.IdMotivoD = IdMotivoD;
				
			item.Monto = Monto;
				
			item.DocumentoDeb = DocumentoDeb;
				
			item.ApellidoDeb = ApellidoDeb;
				
			item.NombreDeb = NombreDeb;
				
			item.CodigoDeb = CodigoDeb;
				
			item.ObservacionesDeb = ObservacionesDeb;
				
	        item.Save(UserName);
	    }
    }
}
