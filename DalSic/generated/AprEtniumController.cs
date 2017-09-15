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
    /// Controller class for APR_Etnia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprEtniumController
    {
        // Preload our schema..
        AprEtnium thisSchemaLoad = new AprEtnium();
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
        public AprEtniumCollection FetchAll()
        {
            AprEtniumCollection coll = new AprEtniumCollection();
            Query qry = new Query(AprEtnium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEtniumCollection FetchByID(object IdEtnia)
        {
            AprEtniumCollection coll = new AprEtniumCollection().Where("idEtnia", IdEtnia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEtniumCollection FetchByQuery(Query qry)
        {
            AprEtniumCollection coll = new AprEtniumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEtnia)
        {
            return (AprEtnium.Delete(IdEtnia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEtnia)
        {
            return (AprEtnium.Destroy(IdEtnia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprEtnium item = new AprEtnium();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEtnia,string Nombre)
	    {
		    AprEtnium item = new AprEtnium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEtnia = IdEtnia;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
