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
    /// Controller class for CON_DemandaRechazada
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConDemandaRechazadaController
    {
        // Preload our schema..
        ConDemandaRechazada thisSchemaLoad = new ConDemandaRechazada();
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
        public ConDemandaRechazadaCollection FetchAll()
        {
            ConDemandaRechazadaCollection coll = new ConDemandaRechazadaCollection();
            Query qry = new Query(ConDemandaRechazada.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConDemandaRechazadaCollection FetchByID(object IdDemandaRechazada)
        {
            ConDemandaRechazadaCollection coll = new ConDemandaRechazadaCollection().Where("idDemandaRechazada", IdDemandaRechazada).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConDemandaRechazadaCollection FetchByQuery(Query qry)
        {
            ConDemandaRechazadaCollection coll = new ConDemandaRechazadaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDemandaRechazada)
        {
            return (ConDemandaRechazada.Delete(IdDemandaRechazada) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDemandaRechazada)
        {
            return (ConDemandaRechazada.Destroy(IdDemandaRechazada) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,int IdEspecialidad,int IdMotivoRechazo,string Observaciones,int IdTurnoResolucion,int IdUsuario,DateTime FechaRegistro,string ObservacionLLamada)
	    {
		    ConDemandaRechazada item = new ConDemandaRechazada();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdMotivoRechazo = IdMotivoRechazo;
            
            item.Observaciones = Observaciones;
            
            item.IdTurnoResolucion = IdTurnoResolucion;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaRegistro = FechaRegistro;
            
            item.ObservacionLLamada = ObservacionLLamada;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDemandaRechazada,int IdEfector,int IdPaciente,int IdEspecialidad,int IdMotivoRechazo,string Observaciones,int IdTurnoResolucion,int IdUsuario,DateTime FechaRegistro,string ObservacionLLamada)
	    {
		    ConDemandaRechazada item = new ConDemandaRechazada();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDemandaRechazada = IdDemandaRechazada;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdMotivoRechazo = IdMotivoRechazo;
				
			item.Observaciones = Observaciones;
				
			item.IdTurnoResolucion = IdTurnoResolucion;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaRegistro = FechaRegistro;
				
			item.ObservacionLLamada = ObservacionLLamada;
				
	        item.Save(UserName);
	    }
    }
}
