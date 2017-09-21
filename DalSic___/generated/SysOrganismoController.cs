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
    /// Controller class for Sys_Organismo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysOrganismoController
    {
        // Preload our schema..
        SysOrganismo thisSchemaLoad = new SysOrganismo();
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
        public SysOrganismoCollection FetchAll()
        {
            SysOrganismoCollection coll = new SysOrganismoCollection();
            Query qry = new Query(SysOrganismo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysOrganismoCollection FetchByID(object IdOrganismo)
        {
            SysOrganismoCollection coll = new SysOrganismoCollection().Where("idOrganismo", IdOrganismo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysOrganismoCollection FetchByQuery(Query qry)
        {
            SysOrganismoCollection coll = new SysOrganismoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdOrganismo)
        {
            return (SysOrganismo.Delete(IdOrganismo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdOrganismo)
        {
            return (SysOrganismo.Destroy(IdOrganismo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysOrganismo item = new SysOrganismo();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdOrganismo,string Nombre)
	    {
		    SysOrganismo item = new SysOrganismo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdOrganismo = IdOrganismo;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
