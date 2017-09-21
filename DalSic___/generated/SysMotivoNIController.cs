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
    /// Controller class for Sys_MotivoNI
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysMotivoNIController
    {
        // Preload our schema..
        SysMotivoNI thisSchemaLoad = new SysMotivoNI();
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
        public SysMotivoNICollection FetchAll()
        {
            SysMotivoNICollection coll = new SysMotivoNICollection();
            Query qry = new Query(SysMotivoNI.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMotivoNICollection FetchByID(object IdMotivoNI)
        {
            SysMotivoNICollection coll = new SysMotivoNICollection().Where("idMotivoNI", IdMotivoNI).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMotivoNICollection FetchByQuery(Query qry)
        {
            SysMotivoNICollection coll = new SysMotivoNICollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivoNI)
        {
            return (SysMotivoNI.Delete(IdMotivoNI) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivoNI)
        {
            return (SysMotivoNI.Destroy(IdMotivoNI) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysMotivoNI item = new SysMotivoNI();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivoNI,string Nombre)
	    {
		    SysMotivoNI item = new SysMotivoNI();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivoNI = IdMotivoNI;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
