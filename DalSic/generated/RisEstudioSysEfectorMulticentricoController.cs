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
    /// Controller class for RIS_EstudioSysEfectorMulticentrico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioSysEfectorMulticentricoController
    {
        // Preload our schema..
        RisEstudioSysEfectorMulticentrico thisSchemaLoad = new RisEstudioSysEfectorMulticentrico();
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
        public RisEstudioSysEfectorMulticentricoCollection FetchAll()
        {
            RisEstudioSysEfectorMulticentricoCollection coll = new RisEstudioSysEfectorMulticentricoCollection();
            Query qry = new Query(RisEstudioSysEfectorMulticentrico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioSysEfectorMulticentricoCollection FetchByID(object Id)
        {
            RisEstudioSysEfectorMulticentricoCollection coll = new RisEstudioSysEfectorMulticentricoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioSysEfectorMulticentricoCollection FetchByQuery(Query qry)
        {
            RisEstudioSysEfectorMulticentricoCollection coll = new RisEstudioSysEfectorMulticentricoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (RisEstudioSysEfectorMulticentrico.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (RisEstudioSysEfectorMulticentrico.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEstudio,int? IdEfector)
	    {
		    RisEstudioSysEfectorMulticentrico item = new RisEstudioSysEfectorMulticentrico();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdEfector = IdEfector;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdEstudio,int? IdEfector)
	    {
		    RisEstudioSysEfectorMulticentrico item = new RisEstudioSysEfectorMulticentrico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdEstudio = IdEstudio;
				
			item.IdEfector = IdEfector;
				
	        item.Save(UserName);
	    }
    }
}
