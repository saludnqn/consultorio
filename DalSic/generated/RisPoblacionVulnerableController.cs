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
    /// Controller class for RIS_PoblacionVulnerable
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisPoblacionVulnerableController
    {
        // Preload our schema..
        RisPoblacionVulnerable thisSchemaLoad = new RisPoblacionVulnerable();
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
        public RisPoblacionVulnerableCollection FetchAll()
        {
            RisPoblacionVulnerableCollection coll = new RisPoblacionVulnerableCollection();
            Query qry = new Query(RisPoblacionVulnerable.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisPoblacionVulnerableCollection FetchByID(object IdPoblacionVulnerable)
        {
            RisPoblacionVulnerableCollection coll = new RisPoblacionVulnerableCollection().Where("idPoblacionVulnerable", IdPoblacionVulnerable).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisPoblacionVulnerableCollection FetchByQuery(Query qry)
        {
            RisPoblacionVulnerableCollection coll = new RisPoblacionVulnerableCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPoblacionVulnerable)
        {
            return (RisPoblacionVulnerable.Delete(IdPoblacionVulnerable) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPoblacionVulnerable)
        {
            return (RisPoblacionVulnerable.Destroy(IdPoblacionVulnerable) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisPoblacionVulnerable item = new RisPoblacionVulnerable();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPoblacionVulnerable,string Descripcion)
	    {
		    RisPoblacionVulnerable item = new RisPoblacionVulnerable();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPoblacionVulnerable = IdPoblacionVulnerable;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
