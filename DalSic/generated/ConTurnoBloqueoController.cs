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
    /// Controller class for CON_TurnoBloqueo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoBloqueoController
    {
        // Preload our schema..
        ConTurnoBloqueo thisSchemaLoad = new ConTurnoBloqueo();
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
        public ConTurnoBloqueoCollection FetchAll()
        {
            ConTurnoBloqueoCollection coll = new ConTurnoBloqueoCollection();
            Query qry = new Query(ConTurnoBloqueo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoBloqueoCollection FetchByID(object IdTurnoBloqueo)
        {
            ConTurnoBloqueoCollection coll = new ConTurnoBloqueoCollection().Where("idTurnoBloqueo", IdTurnoBloqueo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoBloqueoCollection FetchByQuery(Query qry)
        {
            ConTurnoBloqueoCollection coll = new ConTurnoBloqueoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTurnoBloqueo)
        {
            return (ConTurnoBloqueo.Delete(IdTurnoBloqueo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTurnoBloqueo)
        {
            return (ConTurnoBloqueo.Destroy(IdTurnoBloqueo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgenda,DateTime FechaTurno,string HoraTurno,int IdUsuarioBloqueo,DateTime FechaBloqueo,int IdUsuarioDesBloqueo,DateTime FechaDesBloqueo,int? IdMotivoBloqueo)
	    {
		    ConTurnoBloqueo item = new ConTurnoBloqueo();
		    
            item.IdAgenda = IdAgenda;
            
            item.FechaTurno = FechaTurno;
            
            item.HoraTurno = HoraTurno;
            
            item.IdUsuarioBloqueo = IdUsuarioBloqueo;
            
            item.FechaBloqueo = FechaBloqueo;
            
            item.IdUsuarioDesBloqueo = IdUsuarioDesBloqueo;
            
            item.FechaDesBloqueo = FechaDesBloqueo;
            
            item.IdMotivoBloqueo = IdMotivoBloqueo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTurnoBloqueo,int IdAgenda,DateTime FechaTurno,string HoraTurno,int IdUsuarioBloqueo,DateTime FechaBloqueo,int IdUsuarioDesBloqueo,DateTime FechaDesBloqueo,int? IdMotivoBloqueo)
	    {
		    ConTurnoBloqueo item = new ConTurnoBloqueo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTurnoBloqueo = IdTurnoBloqueo;
				
			item.IdAgenda = IdAgenda;
				
			item.FechaTurno = FechaTurno;
				
			item.HoraTurno = HoraTurno;
				
			item.IdUsuarioBloqueo = IdUsuarioBloqueo;
				
			item.FechaBloqueo = FechaBloqueo;
				
			item.IdUsuarioDesBloqueo = IdUsuarioDesBloqueo;
				
			item.FechaDesBloqueo = FechaDesBloqueo;
				
			item.IdMotivoBloqueo = IdMotivoBloqueo;
				
	        item.Save(UserName);
	    }
    }
}
