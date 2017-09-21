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
    /// Controller class for CON_AgendaEstado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaEstadoController
    {
        // Preload our schema..
        ConAgendaEstado thisSchemaLoad = new ConAgendaEstado();
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
        public ConAgendaEstadoCollection FetchAll()
        {
            ConAgendaEstadoCollection coll = new ConAgendaEstadoCollection();
            Query qry = new Query(ConAgendaEstado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaEstadoCollection FetchByID(object IdAgendaEstado)
        {
            ConAgendaEstadoCollection coll = new ConAgendaEstadoCollection().Where("idAgendaEstado", IdAgendaEstado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaEstadoCollection FetchByQuery(Query qry)
        {
            ConAgendaEstadoCollection coll = new ConAgendaEstadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgendaEstado)
        {
            return (ConAgendaEstado.Delete(IdAgendaEstado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgendaEstado)
        {
            return (ConAgendaEstado.Destroy(IdAgendaEstado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConAgendaEstado item = new ConAgendaEstado();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgendaEstado,string Nombre)
	    {
		    ConAgendaEstado item = new ConAgendaEstado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgendaEstado = IdAgendaEstado;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
