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
    /// Controller class for PN_afjp
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAfjpController
    {
        // Preload our schema..
        PnAfjp thisSchemaLoad = new PnAfjp();
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
        public PnAfjpCollection FetchAll()
        {
            PnAfjpCollection coll = new PnAfjpCollection();
            Query qry = new Query(PnAfjp.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAfjpCollection FetchByID(object IdAfjp)
        {
            PnAfjpCollection coll = new PnAfjpCollection().Where("id_afjp", IdAfjp).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAfjpCollection FetchByQuery(Query qry)
        {
            PnAfjpCollection coll = new PnAfjpCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAfjp)
        {
            return (PnAfjp.Delete(IdAfjp) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAfjp)
        {
            return (PnAfjp.Destroy(IdAfjp) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string NombreAfjp)
	    {
		    PnAfjp item = new PnAfjp();
		    
            item.NombreAfjp = NombreAfjp;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAfjp,string NombreAfjp)
	    {
		    PnAfjp item = new PnAfjp();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAfjp = IdAfjp;
				
			item.NombreAfjp = NombreAfjp;
				
	        item.Save(UserName);
	    }
    }
}
