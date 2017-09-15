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
    /// Controller class for PN_factura
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnFacturaController
    {
        // Preload our schema..
        PnFactura thisSchemaLoad = new PnFactura();
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
        public PnFacturaCollection FetchAll()
        {
            PnFacturaCollection coll = new PnFacturaCollection();
            Query qry = new Query(PnFactura.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnFacturaCollection FetchByID(object IdFactura)
        {
            PnFacturaCollection coll = new PnFacturaCollection().Where("id_factura", IdFactura).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnFacturaCollection FetchByQuery(Query qry)
        {
            PnFacturaCollection coll = new PnFacturaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFactura)
        {
            return (PnFactura.Delete(IdFactura) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFactura)
        {
            return (PnFactura.Destroy(IdFactura) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Periodo,string Estado,string Observaciones,DateTime? FechaCarga,DateTime? FechaFactura,string MesFactDC,decimal? MontoPrefactura,DateTime? FechaControl,string NroExp,string Traba,string Online,string NroExpExt,DateTime? FechaExpExt,string PeriodoContable,string PeriodoActual,int EstadoExp,string AltaComp,int? IdTipoDePrestacion)
	    {
		    PnFactura item = new PnFactura();
		    
            item.Cuie = Cuie;
            
            item.Periodo = Periodo;
            
            item.Estado = Estado;
            
            item.Observaciones = Observaciones;
            
            item.FechaCarga = FechaCarga;
            
            item.FechaFactura = FechaFactura;
            
            item.MesFactDC = MesFactDC;
            
            item.MontoPrefactura = MontoPrefactura;
            
            item.FechaControl = FechaControl;
            
            item.NroExp = NroExp;
            
            item.Traba = Traba;
            
            item.Online = Online;
            
            item.NroExpExt = NroExpExt;
            
            item.FechaExpExt = FechaExpExt;
            
            item.PeriodoContable = PeriodoContable;
            
            item.PeriodoActual = PeriodoActual;
            
            item.EstadoExp = EstadoExp;
            
            item.AltaComp = AltaComp;
            
            item.IdTipoDePrestacion = IdTipoDePrestacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFactura,string Cuie,string Periodo,string Estado,string Observaciones,DateTime? FechaCarga,DateTime? FechaFactura,string MesFactDC,decimal? MontoPrefactura,DateTime? FechaControl,string NroExp,string Traba,string Online,string NroExpExt,DateTime? FechaExpExt,string PeriodoContable,string PeriodoActual,int EstadoExp,string AltaComp,int? IdTipoDePrestacion)
	    {
		    PnFactura item = new PnFactura();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFactura = IdFactura;
				
			item.Cuie = Cuie;
				
			item.Periodo = Periodo;
				
			item.Estado = Estado;
				
			item.Observaciones = Observaciones;
				
			item.FechaCarga = FechaCarga;
				
			item.FechaFactura = FechaFactura;
				
			item.MesFactDC = MesFactDC;
				
			item.MontoPrefactura = MontoPrefactura;
				
			item.FechaControl = FechaControl;
				
			item.NroExp = NroExp;
				
			item.Traba = Traba;
				
			item.Online = Online;
				
			item.NroExpExt = NroExpExt;
				
			item.FechaExpExt = FechaExpExt;
				
			item.PeriodoContable = PeriodoContable;
				
			item.PeriodoActual = PeriodoActual;
				
			item.EstadoExp = EstadoExp;
				
			item.AltaComp = AltaComp;
				
			item.IdTipoDePrestacion = IdTipoDePrestacion;
				
	        item.Save(UserName);
	    }
    }
}
