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
    /// Controller class for Sys_SituacionLaboral
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysSituacionLaboralController
    {
        // Preload our schema..
        SysSituacionLaboral thisSchemaLoad = new SysSituacionLaboral();
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
        public SysSituacionLaboralCollection FetchAll()
        {
            SysSituacionLaboralCollection coll = new SysSituacionLaboralCollection();
            Query qry = new Query(SysSituacionLaboral.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysSituacionLaboralCollection FetchByID(object IdSituacionLaboral)
        {
            SysSituacionLaboralCollection coll = new SysSituacionLaboralCollection().Where("idSituacionLaboral", IdSituacionLaboral).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysSituacionLaboralCollection FetchByQuery(Query qry)
        {
            SysSituacionLaboralCollection coll = new SysSituacionLaboralCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSituacionLaboral)
        {
            return (SysSituacionLaboral.Delete(IdSituacionLaboral) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSituacionLaboral)
        {
            return (SysSituacionLaboral.Destroy(IdSituacionLaboral) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysSituacionLaboral item = new SysSituacionLaboral();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSituacionLaboral,string Nombre)
	    {
		    SysSituacionLaboral item = new SysSituacionLaboral();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSituacionLaboral = IdSituacionLaboral;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
