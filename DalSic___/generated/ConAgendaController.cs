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
    /// Controller class for CON_Agenda
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaController
    {
        // Preload our schema..
        ConAgenda thisSchemaLoad = new ConAgenda();
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
        public ConAgendaCollection FetchAll()
        {
            ConAgendaCollection coll = new ConAgendaCollection();
            Query qry = new Query(ConAgenda.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaCollection FetchByID(object IdAgenda)
        {
            ConAgendaCollection coll = new ConAgendaCollection().Where("idAgenda", IdAgenda).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaCollection FetchByQuery(Query qry)
        {
            ConAgendaCollection coll = new ConAgendaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgenda)
        {
            return (ConAgenda.Delete(IdAgenda) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgenda)
        {
            return (ConAgenda.Destroy(IdAgenda) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgendaEstado,int IdEfector,int IdServicio,int IdProfesional,int IdTipoPrestacion,int IdEspecialidad,int IdConsultorio,DateTime Fecha,int Duracion,string HoraInicio,string HoraFin,int MaximoSobreturnos,int PorcentajeTurnosDia,int PorcentajeTurnosAnticipados,bool CitarPorBloques,int CantidadInterconsulta,bool TurnosDisponibles,int? IdMotivoInactivacion,bool Multiprofesional)
	    {
		    ConAgenda item = new ConAgenda();
		    
            item.IdAgendaEstado = IdAgendaEstado;
            
            item.IdEfector = IdEfector;
            
            item.IdServicio = IdServicio;
            
            item.IdProfesional = IdProfesional;
            
            item.IdTipoPrestacion = IdTipoPrestacion;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdConsultorio = IdConsultorio;
            
            item.Fecha = Fecha;
            
            item.Duracion = Duracion;
            
            item.HoraInicio = HoraInicio;
            
            item.HoraFin = HoraFin;
            
            item.MaximoSobreturnos = MaximoSobreturnos;
            
            item.PorcentajeTurnosDia = PorcentajeTurnosDia;
            
            item.PorcentajeTurnosAnticipados = PorcentajeTurnosAnticipados;
            
            item.CitarPorBloques = CitarPorBloques;
            
            item.CantidadInterconsulta = CantidadInterconsulta;
            
            item.TurnosDisponibles = TurnosDisponibles;
            
            item.IdMotivoInactivacion = IdMotivoInactivacion;
            
            item.Multiprofesional = Multiprofesional;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgenda,int IdAgendaEstado,int IdEfector,int IdServicio,int IdProfesional,int IdTipoPrestacion,int IdEspecialidad,int IdConsultorio,DateTime Fecha,int Duracion,string HoraInicio,string HoraFin,int MaximoSobreturnos,int PorcentajeTurnosDia,int PorcentajeTurnosAnticipados,bool CitarPorBloques,int CantidadInterconsulta,bool TurnosDisponibles,int? IdMotivoInactivacion,bool Multiprofesional)
	    {
		    ConAgenda item = new ConAgenda();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgenda = IdAgenda;
				
			item.IdAgendaEstado = IdAgendaEstado;
				
			item.IdEfector = IdEfector;
				
			item.IdServicio = IdServicio;
				
			item.IdProfesional = IdProfesional;
				
			item.IdTipoPrestacion = IdTipoPrestacion;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdConsultorio = IdConsultorio;
				
			item.Fecha = Fecha;
				
			item.Duracion = Duracion;
				
			item.HoraInicio = HoraInicio;
				
			item.HoraFin = HoraFin;
				
			item.MaximoSobreturnos = MaximoSobreturnos;
				
			item.PorcentajeTurnosDia = PorcentajeTurnosDia;
				
			item.PorcentajeTurnosAnticipados = PorcentajeTurnosAnticipados;
				
			item.CitarPorBloques = CitarPorBloques;
				
			item.CantidadInterconsulta = CantidadInterconsulta;
				
			item.TurnosDisponibles = TurnosDisponibles;
				
			item.IdMotivoInactivacion = IdMotivoInactivacion;
				
			item.Multiprofesional = Multiprofesional;
				
	        item.Save(UserName);
	    }
    }
}
