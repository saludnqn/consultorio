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
    /// Controller class for LAB_MetodoScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabMetodoScreeningController
    {
        // Preload our schema..
        LabMetodoScreening thisSchemaLoad = new LabMetodoScreening();
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
        public LabMetodoScreeningCollection FetchAll()
        {
            LabMetodoScreeningCollection coll = new LabMetodoScreeningCollection();
            Query qry = new Query(LabMetodoScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabMetodoScreeningCollection FetchByID(object IdMetodoScreening)
        {
            LabMetodoScreeningCollection coll = new LabMetodoScreeningCollection().Where("idMetodoScreening", IdMetodoScreening).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabMetodoScreeningCollection FetchByQuery(Query qry)
        {
            LabMetodoScreeningCollection coll = new LabMetodoScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMetodoScreening)
        {
            return (LabMetodoScreening.Delete(IdMetodoScreening) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMetodoScreening)
        {
            return (LabMetodoScreening.Destroy(IdMetodoScreening) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,bool Baja)
	    {
		    LabMetodoScreening item = new LabMetodoScreening();
		    
            item.Descripcion = Descripcion;
            
            item.Baja = Baja;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMetodoScreening,string Descripcion,bool Baja)
	    {
		    LabMetodoScreening item = new LabMetodoScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMetodoScreening = IdMetodoScreening;
				
			item.Descripcion = Descripcion;
				
			item.Baja = Baja;
				
	        item.Save(UserName);
	    }
    }
}
