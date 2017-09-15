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
    /// Controller class for CON_TurnoReservaInterconsulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoReservaInterconsultumController
    {
        // Preload our schema..
        ConTurnoReservaInterconsultum thisSchemaLoad = new ConTurnoReservaInterconsultum();
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
        public ConTurnoReservaInterconsultumCollection FetchAll()
        {
            ConTurnoReservaInterconsultumCollection coll = new ConTurnoReservaInterconsultumCollection();
            Query qry = new Query(ConTurnoReservaInterconsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoReservaInterconsultumCollection FetchByID(object IdInterconsulta)
        {
            ConTurnoReservaInterconsultumCollection coll = new ConTurnoReservaInterconsultumCollection().Where("idInterconsulta", IdInterconsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoReservaInterconsultumCollection FetchByQuery(Query qry)
        {
            ConTurnoReservaInterconsultumCollection coll = new ConTurnoReservaInterconsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInterconsulta)
        {
            return (ConTurnoReservaInterconsultum.Delete(IdInterconsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInterconsulta)
        {
            return (ConTurnoReservaInterconsultum.Destroy(IdInterconsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgenda,int IdEfector,string HoraTurno,DateTime ReservaHasta)
	    {
		    ConTurnoReservaInterconsultum item = new ConTurnoReservaInterconsultum();
		    
            item.IdAgenda = IdAgenda;
            
            item.IdEfector = IdEfector;
            
            item.HoraTurno = HoraTurno;
            
            item.ReservaHasta = ReservaHasta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInterconsulta,int IdAgenda,int IdEfector,string HoraTurno,DateTime ReservaHasta)
	    {
		    ConTurnoReservaInterconsultum item = new ConTurnoReservaInterconsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInterconsulta = IdInterconsulta;
				
			item.IdAgenda = IdAgenda;
				
			item.IdEfector = IdEfector;
				
			item.HoraTurno = HoraTurno;
				
			item.ReservaHasta = ReservaHasta;
				
	        item.Save(UserName);
	    }
    }
}
