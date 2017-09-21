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
    /// Controller class for CON_TurnoAsistencia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoAsistenciumController
    {
        // Preload our schema..
        ConTurnoAsistencium thisSchemaLoad = new ConTurnoAsistencium();
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
        public ConTurnoAsistenciumCollection FetchAll()
        {
            ConTurnoAsistenciumCollection coll = new ConTurnoAsistenciumCollection();
            Query qry = new Query(ConTurnoAsistencium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoAsistenciumCollection FetchByID(object IdAsistencia)
        {
            ConTurnoAsistenciumCollection coll = new ConTurnoAsistenciumCollection().Where("idAsistencia", IdAsistencia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoAsistenciumCollection FetchByQuery(Query qry)
        {
            ConTurnoAsistenciumCollection coll = new ConTurnoAsistenciumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAsistencia)
        {
            return (ConTurnoAsistencium.Delete(IdAsistencia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAsistencia)
        {
            return (ConTurnoAsistencium.Destroy(IdAsistencia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdTurno,int IdUsuario,DateTime FechaAsistencia)
	    {
		    ConTurnoAsistencium item = new ConTurnoAsistencium();
		    
            item.IdTurno = IdTurno;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaAsistencia = FechaAsistencia;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAsistencia,int IdTurno,int IdUsuario,DateTime FechaAsistencia)
	    {
		    ConTurnoAsistencium item = new ConTurnoAsistencium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAsistencia = IdAsistencia;
				
			item.IdTurno = IdTurno;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaAsistencia = FechaAsistencia;
				
	        item.Save(UserName);
	    }
    }
}
