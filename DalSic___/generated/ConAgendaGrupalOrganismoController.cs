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
    /// Controller class for CON_AgendaGrupalOrganismo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaGrupalOrganismoController
    {
        // Preload our schema..
        ConAgendaGrupalOrganismo thisSchemaLoad = new ConAgendaGrupalOrganismo();
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
        public ConAgendaGrupalOrganismoCollection FetchAll()
        {
            ConAgendaGrupalOrganismoCollection coll = new ConAgendaGrupalOrganismoCollection();
            Query qry = new Query(ConAgendaGrupalOrganismo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaGrupalOrganismoCollection FetchByID(object IdAgendaGrupalOrganismo)
        {
            ConAgendaGrupalOrganismoCollection coll = new ConAgendaGrupalOrganismoCollection().Where("idAgendaGrupalOrganismo", IdAgendaGrupalOrganismo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaGrupalOrganismoCollection FetchByQuery(Query qry)
        {
            ConAgendaGrupalOrganismoCollection coll = new ConAgendaGrupalOrganismoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgendaGrupalOrganismo)
        {
            return (ConAgendaGrupalOrganismo.Delete(IdAgendaGrupalOrganismo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgendaGrupalOrganismo)
        {
            return (ConAgendaGrupalOrganismo.Destroy(IdAgendaGrupalOrganismo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgendaGrupal,int IdOrganismo)
	    {
		    ConAgendaGrupalOrganismo item = new ConAgendaGrupalOrganismo();
		    
            item.IdAgendaGrupal = IdAgendaGrupal;
            
            item.IdOrganismo = IdOrganismo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgendaGrupalOrganismo,int IdAgendaGrupal,int IdOrganismo)
	    {
		    ConAgendaGrupalOrganismo item = new ConAgendaGrupalOrganismo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgendaGrupalOrganismo = IdAgendaGrupalOrganismo;
				
			item.IdAgendaGrupal = IdAgendaGrupal;
				
			item.IdOrganismo = IdOrganismo;
				
	        item.Save(UserName);
	    }
    }
}
