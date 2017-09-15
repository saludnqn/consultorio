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
    /// Controller class for Sys_RelProfesionalEfector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelProfesionalEfectorController
    {
        // Preload our schema..
        SysRelProfesionalEfector thisSchemaLoad = new SysRelProfesionalEfector();
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
        public SysRelProfesionalEfectorCollection FetchAll()
        {
            SysRelProfesionalEfectorCollection coll = new SysRelProfesionalEfectorCollection();
            Query qry = new Query(SysRelProfesionalEfector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelProfesionalEfectorCollection FetchByID(object IdRelProfesionalEfector)
        {
            SysRelProfesionalEfectorCollection coll = new SysRelProfesionalEfectorCollection().Where("idRelProfesionalEfector", IdRelProfesionalEfector).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelProfesionalEfectorCollection FetchByQuery(Query qry)
        {
            SysRelProfesionalEfectorCollection coll = new SysRelProfesionalEfectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelProfesionalEfector)
        {
            return (SysRelProfesionalEfector.Delete(IdRelProfesionalEfector) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelProfesionalEfector)
        {
            return (SysRelProfesionalEfector.Destroy(IdRelProfesionalEfector) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdProfesional,int IdEfector,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SysRelProfesionalEfector item = new SysRelProfesionalEfector();
		    
            item.IdProfesional = IdProfesional;
            
            item.IdEfector = IdEfector;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelProfesionalEfector,int IdProfesional,int IdEfector,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SysRelProfesionalEfector item = new SysRelProfesionalEfector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelProfesionalEfector = IdRelProfesionalEfector;
				
			item.IdProfesional = IdProfesional;
				
			item.IdEfector = IdEfector;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
