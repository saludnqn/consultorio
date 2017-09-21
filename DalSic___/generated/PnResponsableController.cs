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
    /// Controller class for PN_responsables
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnResponsableController
    {
        // Preload our schema..
        PnResponsable thisSchemaLoad = new PnResponsable();
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
        public PnResponsableCollection FetchAll()
        {
            PnResponsableCollection coll = new PnResponsableCollection();
            Query qry = new Query(PnResponsable.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnResponsableCollection FetchByID(object IdResponsables)
        {
            PnResponsableCollection coll = new PnResponsableCollection().Where("id_responsables", IdResponsables).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnResponsableCollection FetchByQuery(Query qry)
        {
            PnResponsableCollection coll = new PnResponsableCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdResponsables)
        {
            return (PnResponsable.Delete(IdResponsables) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdResponsables)
        {
            return (PnResponsable.Destroy(IdResponsables) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    PnResponsable item = new PnResponsable();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdResponsables,string Nombre)
	    {
		    PnResponsable item = new PnResponsable();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdResponsables = IdResponsables;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
