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
    /// Controller class for PN_zona_sani
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnZonaSaniController
    {
        // Preload our schema..
        PnZonaSani thisSchemaLoad = new PnZonaSani();
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
        public PnZonaSaniCollection FetchAll()
        {
            PnZonaSaniCollection coll = new PnZonaSaniCollection();
            Query qry = new Query(PnZonaSani.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnZonaSaniCollection FetchByID(object IdZonaSani)
        {
            PnZonaSaniCollection coll = new PnZonaSaniCollection().Where("id_zona_sani", IdZonaSani).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnZonaSaniCollection FetchByQuery(Query qry)
        {
            PnZonaSaniCollection coll = new PnZonaSaniCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdZonaSani)
        {
            return (PnZonaSani.Delete(IdZonaSani) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdZonaSani)
        {
            return (PnZonaSani.Destroy(IdZonaSani) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string NombreZona)
	    {
		    PnZonaSani item = new PnZonaSani();
		    
            item.NombreZona = NombreZona;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdZonaSani,string NombreZona)
	    {
		    PnZonaSani item = new PnZonaSani();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdZonaSani = IdZonaSani;
				
			item.NombreZona = NombreZona;
				
	        item.Save(UserName);
	    }
    }
}
