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
    /// Controller class for CON_TurnoAuditoria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoAuditoriumController
    {
        // Preload our schema..
        ConTurnoAuditorium thisSchemaLoad = new ConTurnoAuditorium();
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
        public ConTurnoAuditoriumCollection FetchAll()
        {
            ConTurnoAuditoriumCollection coll = new ConTurnoAuditoriumCollection();
            Query qry = new Query(ConTurnoAuditorium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoAuditoriumCollection FetchByID(object IdTurnoAuditoria)
        {
            ConTurnoAuditoriumCollection coll = new ConTurnoAuditoriumCollection().Where("idTurnoAuditoria", IdTurnoAuditoria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoAuditoriumCollection FetchByQuery(Query qry)
        {
            ConTurnoAuditoriumCollection coll = new ConTurnoAuditoriumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTurnoAuditoria)
        {
            return (ConTurnoAuditorium.Delete(IdTurnoAuditoria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTurnoAuditoria)
        {
            return (ConTurnoAuditorium.Destroy(IdTurnoAuditoria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdTurno,int IdTurnoEstado,int IdUsuario,int IdServicio,int IdProfesional,int IdEspecialidad,int IdConsultorio,DateTime Fecha,string Hora,DateTime FechaModificacion,string HoraModificacion,int IdPaciente)
	    {
		    ConTurnoAuditorium item = new ConTurnoAuditorium();
		    
            item.IdTurno = IdTurno;
            
            item.IdTurnoEstado = IdTurnoEstado;
            
            item.IdUsuario = IdUsuario;
            
            item.IdServicio = IdServicio;
            
            item.IdProfesional = IdProfesional;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdConsultorio = IdConsultorio;
            
            item.Fecha = Fecha;
            
            item.Hora = Hora;
            
            item.FechaModificacion = FechaModificacion;
            
            item.HoraModificacion = HoraModificacion;
            
            item.IdPaciente = IdPaciente;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTurnoAuditoria,int IdTurno,int IdTurnoEstado,int IdUsuario,int IdServicio,int IdProfesional,int IdEspecialidad,int IdConsultorio,DateTime Fecha,string Hora,DateTime FechaModificacion,string HoraModificacion,int IdPaciente)
	    {
		    ConTurnoAuditorium item = new ConTurnoAuditorium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTurnoAuditoria = IdTurnoAuditoria;
				
			item.IdTurno = IdTurno;
				
			item.IdTurnoEstado = IdTurnoEstado;
				
			item.IdUsuario = IdUsuario;
				
			item.IdServicio = IdServicio;
				
			item.IdProfesional = IdProfesional;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdConsultorio = IdConsultorio;
				
			item.Fecha = Fecha;
				
			item.Hora = Hora;
				
			item.FechaModificacion = FechaModificacion;
				
			item.HoraModificacion = HoraModificacion;
				
			item.IdPaciente = IdPaciente;
				
	        item.Save(UserName);
	    }
    }
}
