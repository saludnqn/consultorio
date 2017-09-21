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
    /// Controller class for RIS_Estudio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioController
    {
        // Preload our schema..
        RisEstudio thisSchemaLoad = new RisEstudio();
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
        public RisEstudioCollection FetchAll()
        {
            RisEstudioCollection coll = new RisEstudioCollection();
            Query qry = new Query(RisEstudio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioCollection FetchByID(object IdEstudio)
        {
            RisEstudioCollection coll = new RisEstudioCollection().Where("idEstudio", IdEstudio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioCollection FetchByQuery(Query qry)
        {
            RisEstudioCollection coll = new RisEstudioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudio)
        {
            return (RisEstudio.Delete(IdEstudio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudio)
        {
            return (RisEstudio.Destroy(IdEstudio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TipoEstudio,string NroOrden,string Enmienda,string Anio,string TituloInvestigacion,string NroRegistroNacional,string NroExpediente,string NombreAbreviado,string Drogas,string PalabrasClave,string NombreIntitucionAfiliacion,string ReferenteInstitucionAfiliacion,string TelefonoInstitucionAfiliacion,string DomicilioInstitucionAfiliacion,string CpDomicilioInstitucionAfiliacion,string EmailInstitucionAfiliacion,int IdAreaTematica,int? IdFuenteRecoleccionDatos,string TienePoblacionVulnerable,int? TamanioMuestra,string Multicentrico,int? TiempoEstimadoAnios,int? TiempoEstimadoMeses,DateTime? FechaIncorporacionPrimerParticipante,DateTime? FechaCierreIncorporacionParticipantes,int? IdCaractaristica,DateTime? FechaCierreSitio,string OtrosCaractEstudios,DateTime? FechaAprobadoCAIBSH,DateTime? FechaRechazadoCAIBSH,string ObservacionesCAIBSH,DateTime? FechaInicio,DateTime? FechaFinalizacion,DateTime? FechaPresentacionInformeFinal,DateTime? FechaVencimientoPlazoCAIBSH,DateTime? FechaRetiroEvaluacionCAIBSH,string OtroMotivoDictamenCAIBSH)
	    {
		    RisEstudio item = new RisEstudio();
		    
            item.TipoEstudio = TipoEstudio;
            
            item.NroOrden = NroOrden;
            
            item.Enmienda = Enmienda;
            
            item.Anio = Anio;
            
            item.TituloInvestigacion = TituloInvestigacion;
            
            item.NroRegistroNacional = NroRegistroNacional;
            
            item.NroExpediente = NroExpediente;
            
            item.NombreAbreviado = NombreAbreviado;
            
            item.Drogas = Drogas;
            
            item.PalabrasClave = PalabrasClave;
            
            item.NombreIntitucionAfiliacion = NombreIntitucionAfiliacion;
            
            item.ReferenteInstitucionAfiliacion = ReferenteInstitucionAfiliacion;
            
            item.TelefonoInstitucionAfiliacion = TelefonoInstitucionAfiliacion;
            
            item.DomicilioInstitucionAfiliacion = DomicilioInstitucionAfiliacion;
            
            item.CpDomicilioInstitucionAfiliacion = CpDomicilioInstitucionAfiliacion;
            
            item.EmailInstitucionAfiliacion = EmailInstitucionAfiliacion;
            
            item.IdAreaTematica = IdAreaTematica;
            
            item.IdFuenteRecoleccionDatos = IdFuenteRecoleccionDatos;
            
            item.TienePoblacionVulnerable = TienePoblacionVulnerable;
            
            item.TamanioMuestra = TamanioMuestra;
            
            item.Multicentrico = Multicentrico;
            
            item.TiempoEstimadoAnios = TiempoEstimadoAnios;
            
            item.TiempoEstimadoMeses = TiempoEstimadoMeses;
            
            item.FechaIncorporacionPrimerParticipante = FechaIncorporacionPrimerParticipante;
            
            item.FechaCierreIncorporacionParticipantes = FechaCierreIncorporacionParticipantes;
            
            item.IdCaractaristica = IdCaractaristica;
            
            item.FechaCierreSitio = FechaCierreSitio;
            
            item.OtrosCaractEstudios = OtrosCaractEstudios;
            
            item.FechaAprobadoCAIBSH = FechaAprobadoCAIBSH;
            
            item.FechaRechazadoCAIBSH = FechaRechazadoCAIBSH;
            
            item.ObservacionesCAIBSH = ObservacionesCAIBSH;
            
            item.FechaInicio = FechaInicio;
            
            item.FechaFinalizacion = FechaFinalizacion;
            
            item.FechaPresentacionInformeFinal = FechaPresentacionInformeFinal;
            
            item.FechaVencimientoPlazoCAIBSH = FechaVencimientoPlazoCAIBSH;
            
            item.FechaRetiroEvaluacionCAIBSH = FechaRetiroEvaluacionCAIBSH;
            
            item.OtroMotivoDictamenCAIBSH = OtroMotivoDictamenCAIBSH;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudio,string TipoEstudio,string NroOrden,string Enmienda,string Anio,string TituloInvestigacion,string NroRegistroNacional,string NroExpediente,string NombreAbreviado,string Drogas,string PalabrasClave,string NombreIntitucionAfiliacion,string ReferenteInstitucionAfiliacion,string TelefonoInstitucionAfiliacion,string DomicilioInstitucionAfiliacion,string CpDomicilioInstitucionAfiliacion,string EmailInstitucionAfiliacion,int IdAreaTematica,int? IdFuenteRecoleccionDatos,string TienePoblacionVulnerable,int? TamanioMuestra,string Multicentrico,int? TiempoEstimadoAnios,int? TiempoEstimadoMeses,DateTime? FechaIncorporacionPrimerParticipante,DateTime? FechaCierreIncorporacionParticipantes,int? IdCaractaristica,DateTime? FechaCierreSitio,string OtrosCaractEstudios,DateTime? FechaAprobadoCAIBSH,DateTime? FechaRechazadoCAIBSH,string ObservacionesCAIBSH,DateTime? FechaInicio,DateTime? FechaFinalizacion,DateTime? FechaPresentacionInformeFinal,DateTime? FechaVencimientoPlazoCAIBSH,DateTime? FechaRetiroEvaluacionCAIBSH,string OtroMotivoDictamenCAIBSH)
	    {
		    RisEstudio item = new RisEstudio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudio = IdEstudio;
				
			item.TipoEstudio = TipoEstudio;
				
			item.NroOrden = NroOrden;
				
			item.Enmienda = Enmienda;
				
			item.Anio = Anio;
				
			item.TituloInvestigacion = TituloInvestigacion;
				
			item.NroRegistroNacional = NroRegistroNacional;
				
			item.NroExpediente = NroExpediente;
				
			item.NombreAbreviado = NombreAbreviado;
				
			item.Drogas = Drogas;
				
			item.PalabrasClave = PalabrasClave;
				
			item.NombreIntitucionAfiliacion = NombreIntitucionAfiliacion;
				
			item.ReferenteInstitucionAfiliacion = ReferenteInstitucionAfiliacion;
				
			item.TelefonoInstitucionAfiliacion = TelefonoInstitucionAfiliacion;
				
			item.DomicilioInstitucionAfiliacion = DomicilioInstitucionAfiliacion;
				
			item.CpDomicilioInstitucionAfiliacion = CpDomicilioInstitucionAfiliacion;
				
			item.EmailInstitucionAfiliacion = EmailInstitucionAfiliacion;
				
			item.IdAreaTematica = IdAreaTematica;
				
			item.IdFuenteRecoleccionDatos = IdFuenteRecoleccionDatos;
				
			item.TienePoblacionVulnerable = TienePoblacionVulnerable;
				
			item.TamanioMuestra = TamanioMuestra;
				
			item.Multicentrico = Multicentrico;
				
			item.TiempoEstimadoAnios = TiempoEstimadoAnios;
				
			item.TiempoEstimadoMeses = TiempoEstimadoMeses;
				
			item.FechaIncorporacionPrimerParticipante = FechaIncorporacionPrimerParticipante;
				
			item.FechaCierreIncorporacionParticipantes = FechaCierreIncorporacionParticipantes;
				
			item.IdCaractaristica = IdCaractaristica;
				
			item.FechaCierreSitio = FechaCierreSitio;
				
			item.OtrosCaractEstudios = OtrosCaractEstudios;
				
			item.FechaAprobadoCAIBSH = FechaAprobadoCAIBSH;
				
			item.FechaRechazadoCAIBSH = FechaRechazadoCAIBSH;
				
			item.ObservacionesCAIBSH = ObservacionesCAIBSH;
				
			item.FechaInicio = FechaInicio;
				
			item.FechaFinalizacion = FechaFinalizacion;
				
			item.FechaPresentacionInformeFinal = FechaPresentacionInformeFinal;
				
			item.FechaVencimientoPlazoCAIBSH = FechaVencimientoPlazoCAIBSH;
				
			item.FechaRetiroEvaluacionCAIBSH = FechaRetiroEvaluacionCAIBSH;
				
			item.OtroMotivoDictamenCAIBSH = OtroMotivoDictamenCAIBSH;
				
	        item.Save(UserName);
	    }
    }
}
