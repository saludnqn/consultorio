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
    /// Controller class for PN_efe_conv
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEfeConvController
    {
        // Preload our schema..
        PnEfeConv thisSchemaLoad = new PnEfeConv();
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
        public PnEfeConvCollection FetchAll()
        {
            PnEfeConvCollection coll = new PnEfeConvCollection();
            Query qry = new Query(PnEfeConv.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEfeConvCollection FetchByID(object IdEfeConv)
        {
            PnEfeConvCollection coll = new PnEfeConvCollection().Where("id_efe_conv", IdEfeConv).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEfeConvCollection FetchByQuery(Query qry)
        {
            PnEfeConvCollection coll = new PnEfeConvCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEfeConv)
        {
            return (PnEfeConv.Delete(IdEfeConv) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEfeConv)
        {
            return (PnEfeConv.Destroy(IdEfeConv) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Domicilio,string Departamento,int? Localidad,int? CodPos,string Cuidad,string Referente,string Tel,string ComGestion,string ComGestionFirmante,DateTime? FechaCompGes,DateTime? FechaFinCompGes,string ComGestionPagoIndirecto,string TerceroAdmin,string TerceroAdminFirmante,DateTime? FechaTerceroAdmin,DateTime? FechaFinTerceroAdmin,string Cuie,string Usuario,DateTime? FechaModificacion,string DniFirmanteActual,string ComGestionFirmanteActual,string N2008,string N2009,int? IdNomencladorDetalle,int? IdZonaSani,string Mail,string Incentivo,string PerAltaCom,string AdendaPer,DateTime? FechaAdendaPer,string CategoriaPer)
	    {
		    PnEfeConv item = new PnEfeConv();
		    
            item.Nombre = Nombre;
            
            item.Domicilio = Domicilio;
            
            item.Departamento = Departamento;
            
            item.Localidad = Localidad;
            
            item.CodPos = CodPos;
            
            item.Cuidad = Cuidad;
            
            item.Referente = Referente;
            
            item.Tel = Tel;
            
            item.ComGestion = ComGestion;
            
            item.ComGestionFirmante = ComGestionFirmante;
            
            item.FechaCompGes = FechaCompGes;
            
            item.FechaFinCompGes = FechaFinCompGes;
            
            item.ComGestionPagoIndirecto = ComGestionPagoIndirecto;
            
            item.TerceroAdmin = TerceroAdmin;
            
            item.TerceroAdminFirmante = TerceroAdminFirmante;
            
            item.FechaTerceroAdmin = FechaTerceroAdmin;
            
            item.FechaFinTerceroAdmin = FechaFinTerceroAdmin;
            
            item.Cuie = Cuie;
            
            item.Usuario = Usuario;
            
            item.FechaModificacion = FechaModificacion;
            
            item.DniFirmanteActual = DniFirmanteActual;
            
            item.ComGestionFirmanteActual = ComGestionFirmanteActual;
            
            item.N2008 = N2008;
            
            item.N2009 = N2009;
            
            item.IdNomencladorDetalle = IdNomencladorDetalle;
            
            item.IdZonaSani = IdZonaSani;
            
            item.Mail = Mail;
            
            item.Incentivo = Incentivo;
            
            item.PerAltaCom = PerAltaCom;
            
            item.AdendaPer = AdendaPer;
            
            item.FechaAdendaPer = FechaAdendaPer;
            
            item.CategoriaPer = CategoriaPer;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEfeConv,string Nombre,string Domicilio,string Departamento,int? Localidad,int? CodPos,string Cuidad,string Referente,string Tel,string ComGestion,string ComGestionFirmante,DateTime? FechaCompGes,DateTime? FechaFinCompGes,string ComGestionPagoIndirecto,string TerceroAdmin,string TerceroAdminFirmante,DateTime? FechaTerceroAdmin,DateTime? FechaFinTerceroAdmin,string Cuie,string Usuario,DateTime? FechaModificacion,string DniFirmanteActual,string ComGestionFirmanteActual,string N2008,string N2009,int? IdNomencladorDetalle,int? IdZonaSani,string Mail,string Incentivo,string PerAltaCom,string AdendaPer,DateTime? FechaAdendaPer,string CategoriaPer)
	    {
		    PnEfeConv item = new PnEfeConv();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEfeConv = IdEfeConv;
				
			item.Nombre = Nombre;
				
			item.Domicilio = Domicilio;
				
			item.Departamento = Departamento;
				
			item.Localidad = Localidad;
				
			item.CodPos = CodPos;
				
			item.Cuidad = Cuidad;
				
			item.Referente = Referente;
				
			item.Tel = Tel;
				
			item.ComGestion = ComGestion;
				
			item.ComGestionFirmante = ComGestionFirmante;
				
			item.FechaCompGes = FechaCompGes;
				
			item.FechaFinCompGes = FechaFinCompGes;
				
			item.ComGestionPagoIndirecto = ComGestionPagoIndirecto;
				
			item.TerceroAdmin = TerceroAdmin;
				
			item.TerceroAdminFirmante = TerceroAdminFirmante;
				
			item.FechaTerceroAdmin = FechaTerceroAdmin;
				
			item.FechaFinTerceroAdmin = FechaFinTerceroAdmin;
				
			item.Cuie = Cuie;
				
			item.Usuario = Usuario;
				
			item.FechaModificacion = FechaModificacion;
				
			item.DniFirmanteActual = DniFirmanteActual;
				
			item.ComGestionFirmanteActual = ComGestionFirmanteActual;
				
			item.N2008 = N2008;
				
			item.N2009 = N2009;
				
			item.IdNomencladorDetalle = IdNomencladorDetalle;
				
			item.IdZonaSani = IdZonaSani;
				
			item.Mail = Mail;
				
			item.Incentivo = Incentivo;
				
			item.PerAltaCom = PerAltaCom;
				
			item.AdendaPer = AdendaPer;
				
			item.FechaAdendaPer = FechaAdendaPer;
				
			item.CategoriaPer = CategoriaPer;
				
	        item.Save(UserName);
	    }
    }
}
