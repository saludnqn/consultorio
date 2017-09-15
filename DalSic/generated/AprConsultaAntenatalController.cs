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
    /// Controller class for APR_ConsultaAntenatal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprConsultaAntenatalController
    {
        // Preload our schema..
        AprConsultaAntenatal thisSchemaLoad = new AprConsultaAntenatal();
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
        public AprConsultaAntenatalCollection FetchAll()
        {
            AprConsultaAntenatalCollection coll = new AprConsultaAntenatalCollection();
            Query qry = new Query(AprConsultaAntenatal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprConsultaAntenatalCollection FetchByID(object IdConsultaAntenatal)
        {
            AprConsultaAntenatalCollection coll = new AprConsultaAntenatalCollection().Where("idConsultaAntenatal", IdConsultaAntenatal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprConsultaAntenatalCollection FetchByQuery(Query qry)
        {
            AprConsultaAntenatalCollection coll = new AprConsultaAntenatalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConsultaAntenatal)
        {
            return (AprConsultaAntenatal.Delete(IdConsultaAntenatal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConsultaAntenatal)
        {
            return (AprConsultaAntenatal.Destroy(IdConsultaAntenatal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdConsulta,int IdEmbarazo,DateTime Fecha,double? Peso,int? PresionArterialBaja,int? PresionArterialAlta,int? AlturaUterina,int? IdPresentacionSituacional,int? FrecuenciaCardiacaFetal,bool? MovimientosFetales,bool? Proteinuria,string ObservacionesGenerales,string InicialesTecnico,DateTime FechaProximaConsulta)
	    {
		    AprConsultaAntenatal item = new AprConsultaAntenatal();
		    
            item.IdEfector = IdEfector;
            
            item.IdConsulta = IdConsulta;
            
            item.IdEmbarazo = IdEmbarazo;
            
            item.Fecha = Fecha;
            
            item.Peso = Peso;
            
            item.PresionArterialBaja = PresionArterialBaja;
            
            item.PresionArterialAlta = PresionArterialAlta;
            
            item.AlturaUterina = AlturaUterina;
            
            item.IdPresentacionSituacional = IdPresentacionSituacional;
            
            item.FrecuenciaCardiacaFetal = FrecuenciaCardiacaFetal;
            
            item.MovimientosFetales = MovimientosFetales;
            
            item.Proteinuria = Proteinuria;
            
            item.ObservacionesGenerales = ObservacionesGenerales;
            
            item.InicialesTecnico = InicialesTecnico;
            
            item.FechaProximaConsulta = FechaProximaConsulta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConsultaAntenatal,int IdEfector,int IdConsulta,int IdEmbarazo,DateTime Fecha,double? Peso,int? PresionArterialBaja,int? PresionArterialAlta,int? AlturaUterina,int? IdPresentacionSituacional,int? FrecuenciaCardiacaFetal,bool? MovimientosFetales,bool? Proteinuria,string ObservacionesGenerales,string InicialesTecnico,DateTime FechaProximaConsulta)
	    {
		    AprConsultaAntenatal item = new AprConsultaAntenatal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConsultaAntenatal = IdConsultaAntenatal;
				
			item.IdEfector = IdEfector;
				
			item.IdConsulta = IdConsulta;
				
			item.IdEmbarazo = IdEmbarazo;
				
			item.Fecha = Fecha;
				
			item.Peso = Peso;
				
			item.PresionArterialBaja = PresionArterialBaja;
				
			item.PresionArterialAlta = PresionArterialAlta;
				
			item.AlturaUterina = AlturaUterina;
				
			item.IdPresentacionSituacional = IdPresentacionSituacional;
				
			item.FrecuenciaCardiacaFetal = FrecuenciaCardiacaFetal;
				
			item.MovimientosFetales = MovimientosFetales;
				
			item.Proteinuria = Proteinuria;
				
			item.ObservacionesGenerales = ObservacionesGenerales;
				
			item.InicialesTecnico = InicialesTecnico;
				
			item.FechaProximaConsulta = FechaProximaConsulta;
				
	        item.Save(UserName);
	    }
    }
}
