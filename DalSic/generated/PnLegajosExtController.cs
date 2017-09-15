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
    /// Controller class for PN_legajos_ext
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLegajosExtController
    {
        // Preload our schema..
        PnLegajosExt thisSchemaLoad = new PnLegajosExt();
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
        public PnLegajosExtCollection FetchAll()
        {
            PnLegajosExtCollection coll = new PnLegajosExtCollection();
            Query qry = new Query(PnLegajosExt.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLegajosExtCollection FetchByID(object IdLegajo)
        {
            PnLegajosExtCollection coll = new PnLegajosExtCollection().Where("id_legajo", IdLegajo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLegajosExtCollection FetchByQuery(Query qry)
        {
            PnLegajosExtCollection coll = new PnLegajosExtCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLegajo)
        {
            return (PnLegajosExt.Delete(IdLegajo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLegajo)
        {
            return (PnLegajosExt.Destroy(IdLegajo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(short EstadoCivil,DateTime FechaEstadoCivil,string CedulaIdentidad,string Nacionalidad,short TipoNacionalidad,string BajaMotivo,string BajaObservaciones,string InPresentador,string InOcupacion,decimal? InSueldoInicial,string InExamenMedico,DateTime? InFecha,string InSector,string InObservaciones,string InCalificacion,string InSeguroVidaObligatorio,string InSeguroVida,string InArt,string InBeneficiario,short InCategoria,string Profesion,string Estudios,short? CodigoPostal,string OtrosConocimientos,string ExhibeTitulos)
	    {
		    PnLegajosExt item = new PnLegajosExt();
		    
            item.EstadoCivil = EstadoCivil;
            
            item.FechaEstadoCivil = FechaEstadoCivil;
            
            item.CedulaIdentidad = CedulaIdentidad;
            
            item.Nacionalidad = Nacionalidad;
            
            item.TipoNacionalidad = TipoNacionalidad;
            
            item.BajaMotivo = BajaMotivo;
            
            item.BajaObservaciones = BajaObservaciones;
            
            item.InPresentador = InPresentador;
            
            item.InOcupacion = InOcupacion;
            
            item.InSueldoInicial = InSueldoInicial;
            
            item.InExamenMedico = InExamenMedico;
            
            item.InFecha = InFecha;
            
            item.InSector = InSector;
            
            item.InObservaciones = InObservaciones;
            
            item.InCalificacion = InCalificacion;
            
            item.InSeguroVidaObligatorio = InSeguroVidaObligatorio;
            
            item.InSeguroVida = InSeguroVida;
            
            item.InArt = InArt;
            
            item.InBeneficiario = InBeneficiario;
            
            item.InCategoria = InCategoria;
            
            item.Profesion = Profesion;
            
            item.Estudios = Estudios;
            
            item.CodigoPostal = CodigoPostal;
            
            item.OtrosConocimientos = OtrosConocimientos;
            
            item.ExhibeTitulos = ExhibeTitulos;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLegajo,short EstadoCivil,DateTime FechaEstadoCivil,string CedulaIdentidad,string Nacionalidad,short TipoNacionalidad,string BajaMotivo,string BajaObservaciones,string InPresentador,string InOcupacion,decimal? InSueldoInicial,string InExamenMedico,DateTime? InFecha,string InSector,string InObservaciones,string InCalificacion,string InSeguroVidaObligatorio,string InSeguroVida,string InArt,string InBeneficiario,short InCategoria,string Profesion,string Estudios,short? CodigoPostal,string OtrosConocimientos,string ExhibeTitulos)
	    {
		    PnLegajosExt item = new PnLegajosExt();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLegajo = IdLegajo;
				
			item.EstadoCivil = EstadoCivil;
				
			item.FechaEstadoCivil = FechaEstadoCivil;
				
			item.CedulaIdentidad = CedulaIdentidad;
				
			item.Nacionalidad = Nacionalidad;
				
			item.TipoNacionalidad = TipoNacionalidad;
				
			item.BajaMotivo = BajaMotivo;
				
			item.BajaObservaciones = BajaObservaciones;
				
			item.InPresentador = InPresentador;
				
			item.InOcupacion = InOcupacion;
				
			item.InSueldoInicial = InSueldoInicial;
				
			item.InExamenMedico = InExamenMedico;
				
			item.InFecha = InFecha;
				
			item.InSector = InSector;
				
			item.InObservaciones = InObservaciones;
				
			item.InCalificacion = InCalificacion;
				
			item.InSeguroVidaObligatorio = InSeguroVidaObligatorio;
				
			item.InSeguroVida = InSeguroVida;
				
			item.InArt = InArt;
				
			item.InBeneficiario = InBeneficiario;
				
			item.InCategoria = InCategoria;
				
			item.Profesion = Profesion;
				
			item.Estudios = Estudios;
				
			item.CodigoPostal = CodigoPostal;
				
			item.OtrosConocimientos = OtrosConocimientos;
				
			item.ExhibeTitulos = ExhibeTitulos;
				
	        item.Save(UserName);
	    }
    }
}
