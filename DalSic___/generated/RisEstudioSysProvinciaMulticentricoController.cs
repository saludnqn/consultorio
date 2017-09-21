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
    /// Controller class for RIS_EstudioSysProvinciaMulticentrico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioSysProvinciaMulticentricoController
    {
        // Preload our schema..
        RisEstudioSysProvinciaMulticentrico thisSchemaLoad = new RisEstudioSysProvinciaMulticentrico();
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
        public RisEstudioSysProvinciaMulticentricoCollection FetchAll()
        {
            RisEstudioSysProvinciaMulticentricoCollection coll = new RisEstudioSysProvinciaMulticentricoCollection();
            Query qry = new Query(RisEstudioSysProvinciaMulticentrico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioSysProvinciaMulticentricoCollection FetchByID(object Id)
        {
            RisEstudioSysProvinciaMulticentricoCollection coll = new RisEstudioSysProvinciaMulticentricoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioSysProvinciaMulticentricoCollection FetchByQuery(Query qry)
        {
            RisEstudioSysProvinciaMulticentricoCollection coll = new RisEstudioSysProvinciaMulticentricoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (RisEstudioSysProvinciaMulticentrico.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (RisEstudioSysProvinciaMulticentrico.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEstudio,int? IdProvincia)
	    {
		    RisEstudioSysProvinciaMulticentrico item = new RisEstudioSysProvinciaMulticentrico();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdProvincia = IdProvincia;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdEstudio,int? IdProvincia)
	    {
		    RisEstudioSysProvinciaMulticentrico item = new RisEstudioSysProvinciaMulticentrico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdEstudio = IdEstudio;
				
			item.IdProvincia = IdProvincia;
				
	        item.Save(UserName);
	    }
    }
}
