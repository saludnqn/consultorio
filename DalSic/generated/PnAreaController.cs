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
    /// Controller class for PN_areas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAreaController
    {
        // Preload our schema..
        PnArea thisSchemaLoad = new PnArea();
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
        public PnAreaCollection FetchAll()
        {
            PnAreaCollection coll = new PnAreaCollection();
            Query qry = new Query(PnArea.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAreaCollection FetchByID(object IdArea)
        {
            PnAreaCollection coll = new PnAreaCollection().Where("id_area", IdArea).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAreaCollection FetchByQuery(Query qry)
        {
            PnAreaCollection coll = new PnAreaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdArea)
        {
            return (PnArea.Delete(IdArea) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdArea)
        {
            return (PnArea.Destroy(IdArea) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Responsable)
	    {
		    PnArea item = new PnArea();
		    
            item.Nombre = Nombre;
            
            item.Responsable = Responsable;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdArea,string Nombre,string Responsable)
	    {
		    PnArea item = new PnArea();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdArea = IdArea;
				
			item.Nombre = Nombre;
				
			item.Responsable = Responsable;
				
	        item.Save(UserName);
	    }
    }
}
