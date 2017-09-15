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
    /// Controller class for LAB_MotivoRechazoScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabMotivoRechazoScreeningController
    {
        // Preload our schema..
        LabMotivoRechazoScreening thisSchemaLoad = new LabMotivoRechazoScreening();
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
        public LabMotivoRechazoScreeningCollection FetchAll()
        {
            LabMotivoRechazoScreeningCollection coll = new LabMotivoRechazoScreeningCollection();
            Query qry = new Query(LabMotivoRechazoScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabMotivoRechazoScreeningCollection FetchByID(object IdMotivoRechazoScreening)
        {
            LabMotivoRechazoScreeningCollection coll = new LabMotivoRechazoScreeningCollection().Where("idMotivoRechazoScreening", IdMotivoRechazoScreening).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabMotivoRechazoScreeningCollection FetchByQuery(Query qry)
        {
            LabMotivoRechazoScreeningCollection coll = new LabMotivoRechazoScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivoRechazoScreening)
        {
            return (LabMotivoRechazoScreening.Delete(IdMotivoRechazoScreening) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivoRechazoScreening)
        {
            return (LabMotivoRechazoScreening.Destroy(IdMotivoRechazoScreening) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    LabMotivoRechazoScreening item = new LabMotivoRechazoScreening();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivoRechazoScreening,string Descripcion)
	    {
		    LabMotivoRechazoScreening item = new LabMotivoRechazoScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivoRechazoScreening = IdMotivoRechazoScreening;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
