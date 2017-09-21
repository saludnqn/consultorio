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
    /// Controller class for CON_Turno
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoController
    {
        // Preload our schema..
        ConTurno thisSchemaLoad = new ConTurno();
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
        public ConTurnoCollection FetchAll()
        {
            ConTurnoCollection coll = new ConTurnoCollection();
            Query qry = new Query(ConTurno.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoCollection FetchByID(object IdTurno)
        {
            ConTurnoCollection coll = new ConTurnoCollection().Where("idTurno", IdTurno).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoCollection FetchByQuery(Query qry)
        {
            ConTurnoCollection coll = new ConTurnoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTurno)
        {
            return (ConTurno.Delete(IdTurno) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTurno)
        {
            return (ConTurno.Destroy(IdTurno) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgenda,int IdTurnoEstado,int IdUsuario,int IdPaciente,DateTime Fecha,string Hora,bool Sobreturno,int IdTipoTurno,int IdObraSocial,int IdTurnoAcompaniante)
	    {
		    ConTurno item = new ConTurno();
		    
            item.IdAgenda = IdAgenda;
            
            item.IdTurnoEstado = IdTurnoEstado;
            
            item.IdUsuario = IdUsuario;
            
            item.IdPaciente = IdPaciente;
            
            item.Fecha = Fecha;
            
            item.Hora = Hora;
            
            item.Sobreturno = Sobreturno;
            
            item.IdTipoTurno = IdTipoTurno;
            
            item.IdObraSocial = IdObraSocial;
            
            item.IdTurnoAcompaniante = IdTurnoAcompaniante;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTurno,int IdAgenda,int IdTurnoEstado,int IdUsuario,int IdPaciente,DateTime Fecha,string Hora,bool Sobreturno,int IdTipoTurno,int IdObraSocial,int IdTurnoAcompaniante)
	    {
		    ConTurno item = new ConTurno();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTurno = IdTurno;
				
			item.IdAgenda = IdAgenda;
				
			item.IdTurnoEstado = IdTurnoEstado;
				
			item.IdUsuario = IdUsuario;
				
			item.IdPaciente = IdPaciente;
				
			item.Fecha = Fecha;
				
			item.Hora = Hora;
				
			item.Sobreturno = Sobreturno;
				
			item.IdTipoTurno = IdTipoTurno;
				
			item.IdObraSocial = IdObraSocial;
				
			item.IdTurnoAcompaniante = IdTurnoAcompaniante;
				
	        item.Save(UserName);
	    }
    }
}
