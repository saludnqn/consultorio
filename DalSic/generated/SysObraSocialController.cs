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
    /// Controller class for Sys_ObraSocial
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysObraSocialController
    {
        // Preload our schema..
        SysObraSocial thisSchemaLoad = new SysObraSocial();
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
        public SysObraSocialCollection FetchAll()
        {
            SysObraSocialCollection coll = new SysObraSocialCollection();
            Query qry = new Query(SysObraSocial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysObraSocialCollection FetchByID(object IdObraSocial)
        {
            SysObraSocialCollection coll = new SysObraSocialCollection().Where("idObraSocial", IdObraSocial).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysObraSocialCollection FetchByQuery(Query qry)
        {
            SysObraSocialCollection coll = new SysObraSocialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdObraSocial)
        {
            return (SysObraSocial.Delete(IdObraSocial) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdObraSocial)
        {
            return (SysObraSocial.Destroy(IdObraSocial) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Sigla,string CodigoNacion,string Cuenta,string Domicilio,int IdTipoIva,string Cuit,string Contacto,string Telefono,int IdTipoObraSocial,int IdObraSocialDepende,bool FacturaPerCapita,bool FacturaCarteraFija,bool FacturaAjuste,decimal FacturaPorcentajeAjuste,int NroOrden,bool PermiteFacturaFueraConvenio)
	    {
		    SysObraSocial item = new SysObraSocial();
		    
            item.Nombre = Nombre;
            
            item.Sigla = Sigla;
            
            item.CodigoNacion = CodigoNacion;
            
            item.Cuenta = Cuenta;
            
            item.Domicilio = Domicilio;
            
            item.IdTipoIva = IdTipoIva;
            
            item.Cuit = Cuit;
            
            item.Contacto = Contacto;
            
            item.Telefono = Telefono;
            
            item.IdTipoObraSocial = IdTipoObraSocial;
            
            item.IdObraSocialDepende = IdObraSocialDepende;
            
            item.FacturaPerCapita = FacturaPerCapita;
            
            item.FacturaCarteraFija = FacturaCarteraFija;
            
            item.FacturaAjuste = FacturaAjuste;
            
            item.FacturaPorcentajeAjuste = FacturaPorcentajeAjuste;
            
            item.NroOrden = NroOrden;
            
            item.PermiteFacturaFueraConvenio = PermiteFacturaFueraConvenio;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdObraSocial,string Nombre,string Sigla,string CodigoNacion,string Cuenta,string Domicilio,int IdTipoIva,string Cuit,string Contacto,string Telefono,int IdTipoObraSocial,int IdObraSocialDepende,bool FacturaPerCapita,bool FacturaCarteraFija,bool FacturaAjuste,decimal FacturaPorcentajeAjuste,int NroOrden,bool PermiteFacturaFueraConvenio)
	    {
		    SysObraSocial item = new SysObraSocial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdObraSocial = IdObraSocial;
				
			item.Nombre = Nombre;
				
			item.Sigla = Sigla;
				
			item.CodigoNacion = CodigoNacion;
				
			item.Cuenta = Cuenta;
				
			item.Domicilio = Domicilio;
				
			item.IdTipoIva = IdTipoIva;
				
			item.Cuit = Cuit;
				
			item.Contacto = Contacto;
				
			item.Telefono = Telefono;
				
			item.IdTipoObraSocial = IdTipoObraSocial;
				
			item.IdObraSocialDepende = IdObraSocialDepende;
				
			item.FacturaPerCapita = FacturaPerCapita;
				
			item.FacturaCarteraFija = FacturaCarteraFija;
				
			item.FacturaAjuste = FacturaAjuste;
				
			item.FacturaPorcentajeAjuste = FacturaPorcentajeAjuste;
				
			item.NroOrden = NroOrden;
				
			item.PermiteFacturaFueraConvenio = PermiteFacturaFueraConvenio;
				
	        item.Save(UserName);
	    }
    }
}
