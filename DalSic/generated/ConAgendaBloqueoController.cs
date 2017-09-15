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
    /// Controller class for CON_AgendaBloqueo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaBloqueoController
    {
        // Preload our schema..
        ConAgendaBloqueo thisSchemaLoad = new ConAgendaBloqueo();
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
        public ConAgendaBloqueoCollection FetchAll()
        {
            ConAgendaBloqueoCollection coll = new ConAgendaBloqueoCollection();
            Query qry = new Query(ConAgendaBloqueo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaBloqueoCollection FetchByID(object IdBloqueo)
        {
            ConAgendaBloqueoCollection coll = new ConAgendaBloqueoCollection().Where("idBloqueo", IdBloqueo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaBloqueoCollection FetchByQuery(Query qry)
        {
            ConAgendaBloqueoCollection coll = new ConAgendaBloqueoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdBloqueo)
        {
            return (ConAgendaBloqueo.Delete(IdBloqueo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdBloqueo)
        {
            return (ConAgendaBloqueo.Destroy(IdBloqueo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgenda,int IdUsuario,DateTime FechaActivacion,bool AgendaActivada)
	    {
		    ConAgendaBloqueo item = new ConAgendaBloqueo();
		    
            item.IdAgenda = IdAgenda;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaActivacion = FechaActivacion;
            
            item.AgendaActivada = AgendaActivada;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdBloqueo,int IdAgenda,int IdUsuario,DateTime FechaActivacion,bool AgendaActivada)
	    {
		    ConAgendaBloqueo item = new ConAgendaBloqueo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdBloqueo = IdBloqueo;
				
			item.IdAgenda = IdAgenda;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaActivacion = FechaActivacion;
				
			item.AgendaActivada = AgendaActivada;
				
	        item.Save(UserName);
	    }
    }
}
