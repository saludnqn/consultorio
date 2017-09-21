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
    /// Controller class for PN_comprobante
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnComprobanteController
    {
        // Preload our schema..
        PnComprobante thisSchemaLoad = new PnComprobante();
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
        public PnComprobanteCollection FetchAll()
        {
            PnComprobanteCollection coll = new PnComprobanteCollection();
            Query qry = new Query(PnComprobante.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnComprobanteCollection FetchByID(object IdComprobante)
        {
            PnComprobanteCollection coll = new PnComprobanteCollection().Where("id_comprobante", IdComprobante).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnComprobanteCollection FetchByQuery(Query qry)
        {
            PnComprobanteCollection coll = new PnComprobanteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdComprobante)
        {
            return (PnComprobante.Delete(IdComprobante) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdComprobante)
        {
            return (PnComprobante.Destroy(IdComprobante) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,int? IdFactura,string NombreMedico,DateTime? FechaComprobante,string Clavebeneficiario,int? IdSmiafiliados,DateTime? FechaCarga,string Comentario,int? Marca,string Periodo,int? IdServicio,string Activo,int? IdBeneficiarios,string AltaComp,int? IdTipoDePrestacion)
	    {
		    PnComprobante item = new PnComprobante();
		    
            item.Cuie = Cuie;
            
            item.IdFactura = IdFactura;
            
            item.NombreMedico = NombreMedico;
            
            item.FechaComprobante = FechaComprobante;
            
            item.Clavebeneficiario = Clavebeneficiario;
            
            item.IdSmiafiliados = IdSmiafiliados;
            
            item.FechaCarga = FechaCarga;
            
            item.Comentario = Comentario;
            
            item.Marca = Marca;
            
            item.Periodo = Periodo;
            
            item.IdServicio = IdServicio;
            
            item.Activo = Activo;
            
            item.IdBeneficiarios = IdBeneficiarios;
            
            item.AltaComp = AltaComp;
            
            item.IdTipoDePrestacion = IdTipoDePrestacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdComprobante,string Cuie,int? IdFactura,string NombreMedico,DateTime? FechaComprobante,string Clavebeneficiario,int? IdSmiafiliados,DateTime? FechaCarga,string Comentario,int? Marca,string Periodo,int? IdServicio,string Activo,int? IdBeneficiarios,string AltaComp,int? IdTipoDePrestacion)
	    {
		    PnComprobante item = new PnComprobante();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdComprobante = IdComprobante;
				
			item.Cuie = Cuie;
				
			item.IdFactura = IdFactura;
				
			item.NombreMedico = NombreMedico;
				
			item.FechaComprobante = FechaComprobante;
				
			item.Clavebeneficiario = Clavebeneficiario;
				
			item.IdSmiafiliados = IdSmiafiliados;
				
			item.FechaCarga = FechaCarga;
				
			item.Comentario = Comentario;
				
			item.Marca = Marca;
				
			item.Periodo = Periodo;
				
			item.IdServicio = IdServicio;
				
			item.Activo = Activo;
				
			item.IdBeneficiarios = IdBeneficiarios;
				
			item.AltaComp = AltaComp;
				
			item.IdTipoDePrestacion = IdTipoDePrestacion;
				
	        item.Save(UserName);
	    }
    }
}
