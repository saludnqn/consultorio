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
    /// Controller class for CON_AgendaGrupal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaGrupalController
    {
        // Preload our schema..
        ConAgendaGrupal thisSchemaLoad = new ConAgendaGrupal();
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
        public ConAgendaGrupalCollection FetchAll()
        {
            ConAgendaGrupalCollection coll = new ConAgendaGrupalCollection();
            Query qry = new Query(ConAgendaGrupal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaGrupalCollection FetchByID(object IdAgendaGrupal)
        {
            ConAgendaGrupalCollection coll = new ConAgendaGrupalCollection().Where("idAgendaGrupal", IdAgendaGrupal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaGrupalCollection FetchByQuery(Query qry)
        {
            ConAgendaGrupalCollection coll = new ConAgendaGrupalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgendaGrupal)
        {
            return (ConAgendaGrupal.Delete(IdAgendaGrupal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgendaGrupal)
        {
            return (ConAgendaGrupal.Destroy(IdAgendaGrupal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgendaEstado,int? IdMotivoInactivacion,int IdEfector,int IdTematica,string TematicaOtra,int IdTipoActividadGrupal,string TipoActividadGrupalOtro,int IdLugarActividadGrupal,string LugarActividadGrupalOtro,DateTime Fecha,string HoraInicio,string HoraFin,int? CantidadAsistentes,string OtrosOrganismos,int? IdConsultorio,string ResumenActividad,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    ConAgendaGrupal item = new ConAgendaGrupal();
		    
            item.IdAgendaEstado = IdAgendaEstado;
            
            item.IdMotivoInactivacion = IdMotivoInactivacion;
            
            item.IdEfector = IdEfector;
            
            item.IdTematica = IdTematica;
            
            item.TematicaOtra = TematicaOtra;
            
            item.IdTipoActividadGrupal = IdTipoActividadGrupal;
            
            item.TipoActividadGrupalOtro = TipoActividadGrupalOtro;
            
            item.IdLugarActividadGrupal = IdLugarActividadGrupal;
            
            item.LugarActividadGrupalOtro = LugarActividadGrupalOtro;
            
            item.Fecha = Fecha;
            
            item.HoraInicio = HoraInicio;
            
            item.HoraFin = HoraFin;
            
            item.CantidadAsistentes = CantidadAsistentes;
            
            item.OtrosOrganismos = OtrosOrganismos;
            
            item.IdConsultorio = IdConsultorio;
            
            item.ResumenActividad = ResumenActividad;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgendaGrupal,int IdAgendaEstado,int? IdMotivoInactivacion,int IdEfector,int IdTematica,string TematicaOtra,int IdTipoActividadGrupal,string TipoActividadGrupalOtro,int IdLugarActividadGrupal,string LugarActividadGrupalOtro,DateTime Fecha,string HoraInicio,string HoraFin,int? CantidadAsistentes,string OtrosOrganismos,int? IdConsultorio,string ResumenActividad,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    ConAgendaGrupal item = new ConAgendaGrupal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgendaGrupal = IdAgendaGrupal;
				
			item.IdAgendaEstado = IdAgendaEstado;
				
			item.IdMotivoInactivacion = IdMotivoInactivacion;
				
			item.IdEfector = IdEfector;
				
			item.IdTematica = IdTematica;
				
			item.TematicaOtra = TematicaOtra;
				
			item.IdTipoActividadGrupal = IdTipoActividadGrupal;
				
			item.TipoActividadGrupalOtro = TipoActividadGrupalOtro;
				
			item.IdLugarActividadGrupal = IdLugarActividadGrupal;
				
			item.LugarActividadGrupalOtro = LugarActividadGrupalOtro;
				
			item.Fecha = Fecha;
				
			item.HoraInicio = HoraInicio;
				
			item.HoraFin = HoraFin;
				
			item.CantidadAsistentes = CantidadAsistentes;
				
			item.OtrosOrganismos = OtrosOrganismos;
				
			item.IdConsultorio = IdConsultorio;
				
			item.ResumenActividad = ResumenActividad;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
