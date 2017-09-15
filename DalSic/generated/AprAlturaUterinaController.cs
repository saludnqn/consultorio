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
    /// Controller class for APR_AlturaUterina
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAlturaUterinaController
    {
        // Preload our schema..
        AprAlturaUterina thisSchemaLoad = new AprAlturaUterina();
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
        public AprAlturaUterinaCollection FetchAll()
        {
            AprAlturaUterinaCollection coll = new AprAlturaUterinaCollection();
            Query qry = new Query(AprAlturaUterina.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAlturaUterinaCollection FetchByID(object Id)
        {
            AprAlturaUterinaCollection coll = new AprAlturaUterinaCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAlturaUterinaCollection FetchByQuery(Query qry)
        {
            AprAlturaUterinaCollection coll = new AprAlturaUterinaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AprAlturaUterina.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AprAlturaUterina.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(decimal SemanasGestacion,decimal C10,decimal C50,decimal C90)
	    {
		    AprAlturaUterina item = new AprAlturaUterina();
		    
            item.SemanasGestacion = SemanasGestacion;
            
            item.C10 = C10;
            
            item.C50 = C50;
            
            item.C90 = C90;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,decimal SemanasGestacion,decimal C10,decimal C50,decimal C90)
	    {
		    AprAlturaUterina item = new AprAlturaUterina();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SemanasGestacion = SemanasGestacion;
				
			item.C10 = C10;
				
			item.C50 = C50;
				
			item.C90 = C90;
				
	        item.Save(UserName);
	    }
    }
}
