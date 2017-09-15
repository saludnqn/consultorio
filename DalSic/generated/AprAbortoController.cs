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
    /// Controller class for APR_Aborto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAbortoController
    {
        // Preload our schema..
        AprAborto thisSchemaLoad = new AprAborto();
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
        public AprAbortoCollection FetchAll()
        {
            AprAbortoCollection coll = new AprAbortoCollection();
            Query qry = new Query(AprAborto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAbortoCollection FetchByID(object IdAborto)
        {
            AprAbortoCollection coll = new AprAbortoCollection().Where("idAborto", IdAborto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAbortoCollection FetchByQuery(Query qry)
        {
            AprAbortoCollection coll = new AprAbortoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAborto)
        {
            return (AprAborto.Delete(IdAborto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAborto)
        {
            return (AprAborto.Destroy(IdAborto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int? IdEmbarazo,DateTime FechaHora,int? HospitalizacionDias,int? IdAcompañante,string Procedencia,int? IdTransporte,int? TiempoTrasladoDias,int? TiempoTrasladoHoras,int? TiempoTrasladoMinutos,int? Pulso,int? PresionArterialMinima,int? PresionArterialMaxima,int? FrecuenciaRespiratoria,int? Temperatura,int? DiasDesdePrimerSintoma,int? HorasDesdePrimerSintoma,int? IdSangrado,int? Dolor,int? IdCondicionAlIngreso,int? IdEstadoAbortoPresuntivo,int? IdTipoAbortoPresuntivo,int? DIAGCIE10,string Responsable,int? IdExamenConciencia,int? IdExamenPielMucosa,int? IdExamenAbdomen,int? TamañoUteroExamenBimanual,int? IdPosicionUtero,bool? CuelloCerrado,bool? Restos,bool? VaginaNormal,int? TamañoUteroPorECO,bool? DiametroLongitudinal,bool? AnalgesiaSolicitada,bool? AnalgesiaRealizada)
	    {
		    AprAborto item = new AprAborto();
		    
            item.IdEfector = IdEfector;
            
            item.IdEmbarazo = IdEmbarazo;
            
            item.FechaHora = FechaHora;
            
            item.HospitalizacionDias = HospitalizacionDias;
            
            item.IdAcompañante = IdAcompañante;
            
            item.Procedencia = Procedencia;
            
            item.IdTransporte = IdTransporte;
            
            item.TiempoTrasladoDias = TiempoTrasladoDias;
            
            item.TiempoTrasladoHoras = TiempoTrasladoHoras;
            
            item.TiempoTrasladoMinutos = TiempoTrasladoMinutos;
            
            item.Pulso = Pulso;
            
            item.PresionArterialMinima = PresionArterialMinima;
            
            item.PresionArterialMaxima = PresionArterialMaxima;
            
            item.FrecuenciaRespiratoria = FrecuenciaRespiratoria;
            
            item.Temperatura = Temperatura;
            
            item.DiasDesdePrimerSintoma = DiasDesdePrimerSintoma;
            
            item.HorasDesdePrimerSintoma = HorasDesdePrimerSintoma;
            
            item.IdSangrado = IdSangrado;
            
            item.Dolor = Dolor;
            
            item.IdCondicionAlIngreso = IdCondicionAlIngreso;
            
            item.IdEstadoAbortoPresuntivo = IdEstadoAbortoPresuntivo;
            
            item.IdTipoAbortoPresuntivo = IdTipoAbortoPresuntivo;
            
            item.DIAGCIE10 = DIAGCIE10;
            
            item.Responsable = Responsable;
            
            item.IdExamenConciencia = IdExamenConciencia;
            
            item.IdExamenPielMucosa = IdExamenPielMucosa;
            
            item.IdExamenAbdomen = IdExamenAbdomen;
            
            item.TamañoUteroExamenBimanual = TamañoUteroExamenBimanual;
            
            item.IdPosicionUtero = IdPosicionUtero;
            
            item.CuelloCerrado = CuelloCerrado;
            
            item.Restos = Restos;
            
            item.VaginaNormal = VaginaNormal;
            
            item.TamañoUteroPorECO = TamañoUteroPorECO;
            
            item.DiametroLongitudinal = DiametroLongitudinal;
            
            item.AnalgesiaSolicitada = AnalgesiaSolicitada;
            
            item.AnalgesiaRealizada = AnalgesiaRealizada;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAborto,int IdEfector,int? IdEmbarazo,DateTime FechaHora,int? HospitalizacionDias,int? IdAcompañante,string Procedencia,int? IdTransporte,int? TiempoTrasladoDias,int? TiempoTrasladoHoras,int? TiempoTrasladoMinutos,int? Pulso,int? PresionArterialMinima,int? PresionArterialMaxima,int? FrecuenciaRespiratoria,int? Temperatura,int? DiasDesdePrimerSintoma,int? HorasDesdePrimerSintoma,int? IdSangrado,int? Dolor,int? IdCondicionAlIngreso,int? IdEstadoAbortoPresuntivo,int? IdTipoAbortoPresuntivo,int? DIAGCIE10,string Responsable,int? IdExamenConciencia,int? IdExamenPielMucosa,int? IdExamenAbdomen,int? TamañoUteroExamenBimanual,int? IdPosicionUtero,bool? CuelloCerrado,bool? Restos,bool? VaginaNormal,int? TamañoUteroPorECO,bool? DiametroLongitudinal,bool? AnalgesiaSolicitada,bool? AnalgesiaRealizada)
	    {
		    AprAborto item = new AprAborto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAborto = IdAborto;
				
			item.IdEfector = IdEfector;
				
			item.IdEmbarazo = IdEmbarazo;
				
			item.FechaHora = FechaHora;
				
			item.HospitalizacionDias = HospitalizacionDias;
				
			item.IdAcompañante = IdAcompañante;
				
			item.Procedencia = Procedencia;
				
			item.IdTransporte = IdTransporte;
				
			item.TiempoTrasladoDias = TiempoTrasladoDias;
				
			item.TiempoTrasladoHoras = TiempoTrasladoHoras;
				
			item.TiempoTrasladoMinutos = TiempoTrasladoMinutos;
				
			item.Pulso = Pulso;
				
			item.PresionArterialMinima = PresionArterialMinima;
				
			item.PresionArterialMaxima = PresionArterialMaxima;
				
			item.FrecuenciaRespiratoria = FrecuenciaRespiratoria;
				
			item.Temperatura = Temperatura;
				
			item.DiasDesdePrimerSintoma = DiasDesdePrimerSintoma;
				
			item.HorasDesdePrimerSintoma = HorasDesdePrimerSintoma;
				
			item.IdSangrado = IdSangrado;
				
			item.Dolor = Dolor;
				
			item.IdCondicionAlIngreso = IdCondicionAlIngreso;
				
			item.IdEstadoAbortoPresuntivo = IdEstadoAbortoPresuntivo;
				
			item.IdTipoAbortoPresuntivo = IdTipoAbortoPresuntivo;
				
			item.DIAGCIE10 = DIAGCIE10;
				
			item.Responsable = Responsable;
				
			item.IdExamenConciencia = IdExamenConciencia;
				
			item.IdExamenPielMucosa = IdExamenPielMucosa;
				
			item.IdExamenAbdomen = IdExamenAbdomen;
				
			item.TamañoUteroExamenBimanual = TamañoUteroExamenBimanual;
				
			item.IdPosicionUtero = IdPosicionUtero;
				
			item.CuelloCerrado = CuelloCerrado;
				
			item.Restos = Restos;
				
			item.VaginaNormal = VaginaNormal;
				
			item.TamañoUteroPorECO = TamañoUteroPorECO;
				
			item.DiametroLongitudinal = DiametroLongitudinal;
				
			item.AnalgesiaSolicitada = AnalgesiaSolicitada;
				
			item.AnalgesiaRealizada = AnalgesiaRealizada;
				
	        item.Save(UserName);
	    }
    }
}
