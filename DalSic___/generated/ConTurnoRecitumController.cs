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
    /// Controller class for CON_TurnoRecita
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoRecitumController
    {
        // Preload our schema..
        ConTurnoRecitum thisSchemaLoad = new ConTurnoRecitum();
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
        public ConTurnoRecitumCollection FetchAll()
        {
            ConTurnoRecitumCollection coll = new ConTurnoRecitumCollection();
            Query qry = new Query(ConTurnoRecitum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoRecitumCollection FetchByID(object IdRecita)
        {
            ConTurnoRecitumCollection coll = new ConTurnoRecitumCollection().Where("idRecita", IdRecita).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoRecitumCollection FetchByQuery(Query qry)
        {
            ConTurnoRecitumCollection coll = new ConTurnoRecitumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRecita)
        {
            return (ConTurnoRecitum.Delete(IdRecita) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRecita)
        {
            return (ConTurnoRecitum.Destroy(IdRecita) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int IdTurnoAnterior,int IdAgendaAnterior,DateTime FechaAnterior,string HoraAnterior,int IdTurnoActual,int IdUsuario,DateTime FechaRecita)
	    {
		    ConTurnoRecitum item = new ConTurnoRecitum();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdTurnoAnterior = IdTurnoAnterior;
            
            item.IdAgendaAnterior = IdAgendaAnterior;
            
            item.FechaAnterior = FechaAnterior;
            
            item.HoraAnterior = HoraAnterior;
            
            item.IdTurnoActual = IdTurnoActual;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaRecita = FechaRecita;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRecita,int IdPaciente,int IdTurnoAnterior,int IdAgendaAnterior,DateTime FechaAnterior,string HoraAnterior,int IdTurnoActual,int IdUsuario,DateTime FechaRecita)
	    {
		    ConTurnoRecitum item = new ConTurnoRecitum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRecita = IdRecita;
				
			item.IdPaciente = IdPaciente;
				
			item.IdTurnoAnterior = IdTurnoAnterior;
				
			item.IdAgendaAnterior = IdAgendaAnterior;
				
			item.FechaAnterior = FechaAnterior;
				
			item.HoraAnterior = HoraAnterior;
				
			item.IdTurnoActual = IdTurnoActual;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaRecita = FechaRecita;
				
	        item.Save(UserName);
	    }
    }
}
