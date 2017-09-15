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
    /// Controller class for APR_HistoriaClinicaPerinatalDetalle
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprHistoriaClinicaPerinatalDetalleController
    {
        // Preload our schema..
        AprHistoriaClinicaPerinatalDetalle thisSchemaLoad = new AprHistoriaClinicaPerinatalDetalle();
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
        public AprHistoriaClinicaPerinatalDetalleCollection FetchAll()
        {
            AprHistoriaClinicaPerinatalDetalleCollection coll = new AprHistoriaClinicaPerinatalDetalleCollection();
            Query qry = new Query(AprHistoriaClinicaPerinatalDetalle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprHistoriaClinicaPerinatalDetalleCollection FetchByID(object IdHistoriaClinicaPerinatalDetalle)
        {
            AprHistoriaClinicaPerinatalDetalleCollection coll = new AprHistoriaClinicaPerinatalDetalleCollection().Where("idHistoriaClinicaPerinatalDetalle", IdHistoriaClinicaPerinatalDetalle).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprHistoriaClinicaPerinatalDetalleCollection FetchByQuery(Query qry)
        {
            AprHistoriaClinicaPerinatalDetalleCollection coll = new AprHistoriaClinicaPerinatalDetalleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdHistoriaClinicaPerinatalDetalle)
        {
            return (AprHistoriaClinicaPerinatalDetalle.Delete(IdHistoriaClinicaPerinatalDetalle) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdHistoriaClinicaPerinatalDetalle)
        {
            return (AprHistoriaClinicaPerinatalDetalle.Destroy(IdHistoriaClinicaPerinatalDetalle) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdHistoriaClinicaPerinatal,int? IdConsulta,DateTime? Fecha,decimal? EdadGestacional,decimal? Peso,decimal? Imc,string Pa,decimal? AlturaUterina,string Presentacion,int? Fcf,string MovimientosFetales,string Proteinuria,string AlarmaExamenesTratamientos,string Observaciones,string InicialesTecnico,DateTime? ProximaCita,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,bool Activa)
	    {
		    AprHistoriaClinicaPerinatalDetalle item = new AprHistoriaClinicaPerinatalDetalle();
		    
            item.IdEfector = IdEfector;
            
            item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
            
            item.IdConsulta = IdConsulta;
            
            item.Fecha = Fecha;
            
            item.EdadGestacional = EdadGestacional;
            
            item.Peso = Peso;
            
            item.Imc = Imc;
            
            item.Pa = Pa;
            
            item.AlturaUterina = AlturaUterina;
            
            item.Presentacion = Presentacion;
            
            item.Fcf = Fcf;
            
            item.MovimientosFetales = MovimientosFetales;
            
            item.Proteinuria = Proteinuria;
            
            item.AlarmaExamenesTratamientos = AlarmaExamenesTratamientos;
            
            item.Observaciones = Observaciones;
            
            item.InicialesTecnico = InicialesTecnico;
            
            item.ProximaCita = ProximaCita;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.Activa = Activa;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdHistoriaClinicaPerinatalDetalle,int IdEfector,int IdHistoriaClinicaPerinatal,int? IdConsulta,DateTime? Fecha,decimal? EdadGestacional,decimal? Peso,decimal? Imc,string Pa,decimal? AlturaUterina,string Presentacion,int? Fcf,string MovimientosFetales,string Proteinuria,string AlarmaExamenesTratamientos,string Observaciones,string InicialesTecnico,DateTime? ProximaCita,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,bool Activa)
	    {
		    AprHistoriaClinicaPerinatalDetalle item = new AprHistoriaClinicaPerinatalDetalle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdHistoriaClinicaPerinatalDetalle = IdHistoriaClinicaPerinatalDetalle;
				
			item.IdEfector = IdEfector;
				
			item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
				
			item.IdConsulta = IdConsulta;
				
			item.Fecha = Fecha;
				
			item.EdadGestacional = EdadGestacional;
				
			item.Peso = Peso;
				
			item.Imc = Imc;
				
			item.Pa = Pa;
				
			item.AlturaUterina = AlturaUterina;
				
			item.Presentacion = Presentacion;
				
			item.Fcf = Fcf;
				
			item.MovimientosFetales = MovimientosFetales;
				
			item.Proteinuria = Proteinuria;
				
			item.AlarmaExamenesTratamientos = AlarmaExamenesTratamientos;
				
			item.Observaciones = Observaciones;
				
			item.InicialesTecnico = InicialesTecnico;
				
			item.ProximaCita = ProximaCita;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.Activa = Activa;
				
	        item.Save(UserName);
	    }
    }
}
