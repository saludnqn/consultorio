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
    /// Controller class for Sys_RelEstadoMotivoNI
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelEstadoMotivoNIController
    {
        // Preload our schema..
        SysRelEstadoMotivoNI thisSchemaLoad = new SysRelEstadoMotivoNI();
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
        public SysRelEstadoMotivoNICollection FetchAll()
        {
            SysRelEstadoMotivoNICollection coll = new SysRelEstadoMotivoNICollection();
            Query qry = new Query(SysRelEstadoMotivoNI.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelEstadoMotivoNICollection FetchByID(object IdRelEstadoMotivoNI)
        {
            SysRelEstadoMotivoNICollection coll = new SysRelEstadoMotivoNICollection().Where("idRelEstadoMotivoNI", IdRelEstadoMotivoNI).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelEstadoMotivoNICollection FetchByQuery(Query qry)
        {
            SysRelEstadoMotivoNICollection coll = new SysRelEstadoMotivoNICollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelEstadoMotivoNI)
        {
            return (SysRelEstadoMotivoNI.Delete(IdRelEstadoMotivoNI) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelEstadoMotivoNI)
        {
            return (SysRelEstadoMotivoNI.Destroy(IdRelEstadoMotivoNI) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstado,int IdMotivoNI)
	    {
		    SysRelEstadoMotivoNI item = new SysRelEstadoMotivoNI();
		    
            item.IdEstado = IdEstado;
            
            item.IdMotivoNI = IdMotivoNI;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelEstadoMotivoNI,int IdEstado,int IdMotivoNI)
	    {
		    SysRelEstadoMotivoNI item = new SysRelEstadoMotivoNI();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelEstadoMotivoNI = IdRelEstadoMotivoNI;
				
			item.IdEstado = IdEstado;
				
			item.IdMotivoNI = IdMotivoNI;
				
	        item.Save(UserName);
	    }
    }
}
