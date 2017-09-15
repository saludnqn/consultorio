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
    /// Controller class for CON_TurnoReserva
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoReservaController
    {
        // Preload our schema..
        ConTurnoReserva thisSchemaLoad = new ConTurnoReserva();
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
        public ConTurnoReservaCollection FetchAll()
        {
            ConTurnoReservaCollection coll = new ConTurnoReservaCollection();
            Query qry = new Query(ConTurnoReserva.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoReservaCollection FetchByID(object IdReserva)
        {
            ConTurnoReservaCollection coll = new ConTurnoReservaCollection().Where("idReserva", IdReserva).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoReservaCollection FetchByQuery(Query qry)
        {
            ConTurnoReservaCollection coll = new ConTurnoReservaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdReserva)
        {
            return (ConTurnoReserva.Delete(IdReserva) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdReserva)
        {
            return (ConTurnoReserva.Destroy(IdReserva) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUsuario,int IdPaciente,int IdTurno,DateTime ReservaHasta,bool CofirmoTurno)
	    {
		    ConTurnoReserva item = new ConTurnoReserva();
		    
            item.IdUsuario = IdUsuario;
            
            item.IdPaciente = IdPaciente;
            
            item.IdTurno = IdTurno;
            
            item.ReservaHasta = ReservaHasta;
            
            item.CofirmoTurno = CofirmoTurno;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdReserva,int IdUsuario,int IdPaciente,int IdTurno,DateTime ReservaHasta,bool CofirmoTurno)
	    {
		    ConTurnoReserva item = new ConTurnoReserva();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdReserva = IdReserva;
				
			item.IdUsuario = IdUsuario;
				
			item.IdPaciente = IdPaciente;
				
			item.IdTurno = IdTurno;
				
			item.ReservaHasta = ReservaHasta;
				
			item.CofirmoTurno = CofirmoTurno;
				
	        item.Save(UserName);
	    }
    }
}
