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
    /// Controller class for CON_AgendaAuditoria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaAuditoriumController
    {
        // Preload our schema..
        ConAgendaAuditorium thisSchemaLoad = new ConAgendaAuditorium();
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
        public ConAgendaAuditoriumCollection FetchAll()
        {
            ConAgendaAuditoriumCollection coll = new ConAgendaAuditoriumCollection();
            Query qry = new Query(ConAgendaAuditorium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaAuditoriumCollection FetchByID(object IdAuditoria)
        {
            ConAgendaAuditoriumCollection coll = new ConAgendaAuditoriumCollection().Where("idAuditoria", IdAuditoria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaAuditoriumCollection FetchByQuery(Query qry)
        {
            ConAgendaAuditoriumCollection coll = new ConAgendaAuditoriumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAuditoria)
        {
            return (ConAgendaAuditorium.Delete(IdAuditoria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAuditoria)
        {
            return (ConAgendaAuditorium.Destroy(IdAuditoria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgenda,int IdAgendaEstado,int IdEfector,int IdServicio,int IdProfesional,int IdEspecialidad,int IdConsultorio,int IdUsuario,DateTime Fecha,string HoraInicio,string HoraFin,int Duracion,int Reservados,int MaxSobreturnos,int CitarPorBloques,DateTime FechaModificacion,string HoraModificacion)
	    {
		    ConAgendaAuditorium item = new ConAgendaAuditorium();
		    
            item.IdAgenda = IdAgenda;
            
            item.IdAgendaEstado = IdAgendaEstado;
            
            item.IdEfector = IdEfector;
            
            item.IdServicio = IdServicio;
            
            item.IdProfesional = IdProfesional;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdConsultorio = IdConsultorio;
            
            item.IdUsuario = IdUsuario;
            
            item.Fecha = Fecha;
            
            item.HoraInicio = HoraInicio;
            
            item.HoraFin = HoraFin;
            
            item.Duracion = Duracion;
            
            item.Reservados = Reservados;
            
            item.MaxSobreturnos = MaxSobreturnos;
            
            item.CitarPorBloques = CitarPorBloques;
            
            item.FechaModificacion = FechaModificacion;
            
            item.HoraModificacion = HoraModificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAuditoria,int IdAgenda,int IdAgendaEstado,int IdEfector,int IdServicio,int IdProfesional,int IdEspecialidad,int IdConsultorio,int IdUsuario,DateTime Fecha,string HoraInicio,string HoraFin,int Duracion,int Reservados,int MaxSobreturnos,int CitarPorBloques,DateTime FechaModificacion,string HoraModificacion)
	    {
		    ConAgendaAuditorium item = new ConAgendaAuditorium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAuditoria = IdAuditoria;
				
			item.IdAgenda = IdAgenda;
				
			item.IdAgendaEstado = IdAgendaEstado;
				
			item.IdEfector = IdEfector;
				
			item.IdServicio = IdServicio;
				
			item.IdProfesional = IdProfesional;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdConsultorio = IdConsultorio;
				
			item.IdUsuario = IdUsuario;
				
			item.Fecha = Fecha;
				
			item.HoraInicio = HoraInicio;
				
			item.HoraFin = HoraFin;
				
			item.Duracion = Duracion;
				
			item.Reservados = Reservados;
				
			item.MaxSobreturnos = MaxSobreturnos;
				
			item.CitarPorBloques = CitarPorBloques;
				
			item.FechaModificacion = FechaModificacion;
				
			item.HoraModificacion = HoraModificacion;
				
	        item.Save(UserName);
	    }
    }
}
