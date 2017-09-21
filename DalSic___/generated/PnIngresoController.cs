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
    /// Controller class for PN_ingreso
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnIngresoController
    {
        // Preload our schema..
        PnIngreso thisSchemaLoad = new PnIngreso();
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
        public PnIngresoCollection FetchAll()
        {
            PnIngresoCollection coll = new PnIngresoCollection();
            Query qry = new Query(PnIngreso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIngresoCollection FetchByID(object IdIngreso)
        {
            PnIngresoCollection coll = new PnIngresoCollection().Where("id_ingreso", IdIngreso).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIngresoCollection FetchByQuery(Query qry)
        {
            PnIngresoCollection coll = new PnIngresoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIngreso)
        {
            return (PnIngreso.Delete(IdIngreso) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIngreso)
        {
            return (PnIngreso.Destroy(IdIngreso) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,decimal? MontoPrefactura,DateTime? FechaPrefactura,decimal? MontoFactura,DateTime? FechaFactura,string Comentario,string Usuario,DateTime? Fecha,int? NumeroFactura,DateTime? FechaDeposito,decimal? MontoDeposito,int? IdServicio,DateTime? FechaNotificacion)
	    {
		    PnIngreso item = new PnIngreso();
		    
            item.Cuie = Cuie;
            
            item.MontoPrefactura = MontoPrefactura;
            
            item.FechaPrefactura = FechaPrefactura;
            
            item.MontoFactura = MontoFactura;
            
            item.FechaFactura = FechaFactura;
            
            item.Comentario = Comentario;
            
            item.Usuario = Usuario;
            
            item.Fecha = Fecha;
            
            item.NumeroFactura = NumeroFactura;
            
            item.FechaDeposito = FechaDeposito;
            
            item.MontoDeposito = MontoDeposito;
            
            item.IdServicio = IdServicio;
            
            item.FechaNotificacion = FechaNotificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIngreso,string Cuie,decimal? MontoPrefactura,DateTime? FechaPrefactura,decimal? MontoFactura,DateTime? FechaFactura,string Comentario,string Usuario,DateTime? Fecha,int? NumeroFactura,DateTime? FechaDeposito,decimal? MontoDeposito,int? IdServicio,DateTime? FechaNotificacion)
	    {
		    PnIngreso item = new PnIngreso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIngreso = IdIngreso;
				
			item.Cuie = Cuie;
				
			item.MontoPrefactura = MontoPrefactura;
				
			item.FechaPrefactura = FechaPrefactura;
				
			item.MontoFactura = MontoFactura;
				
			item.FechaFactura = FechaFactura;
				
			item.Comentario = Comentario;
				
			item.Usuario = Usuario;
				
			item.Fecha = Fecha;
				
			item.NumeroFactura = NumeroFactura;
				
			item.FechaDeposito = FechaDeposito;
				
			item.MontoDeposito = MontoDeposito;
				
			item.IdServicio = IdServicio;
				
			item.FechaNotificacion = FechaNotificacion;
				
	        item.Save(UserName);
	    }
    }
}
