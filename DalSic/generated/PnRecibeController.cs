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
    /// Controller class for PN_recibe
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnRecibeController
    {
        // Preload our schema..
        PnRecibe thisSchemaLoad = new PnRecibe();
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
        public PnRecibeCollection FetchAll()
        {
            PnRecibeCollection coll = new PnRecibeCollection();
            Query qry = new Query(PnRecibe.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnRecibeCollection FetchByID(object IdRecibe)
        {
            PnRecibeCollection coll = new PnRecibeCollection().Where("id_recibe", IdRecibe).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnRecibeCollection FetchByQuery(Query qry)
        {
            PnRecibeCollection coll = new PnRecibeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRecibe)
        {
            return (PnRecibe.Delete(IdRecibe) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRecibe)
        {
            return (PnRecibe.Destroy(IdRecibe) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string DescripcionRecibe)
	    {
		    PnRecibe item = new PnRecibe();
		    
            item.DescripcionRecibe = DescripcionRecibe;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRecibe,string DescripcionRecibe)
	    {
		    PnRecibe item = new PnRecibe();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRecibe = IdRecibe;
				
			item.DescripcionRecibe = DescripcionRecibe;
				
	        item.Save(UserName);
	    }
    }
}
