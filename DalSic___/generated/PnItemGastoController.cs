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
    /// Controller class for PN_item_gasto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnItemGastoController
    {
        // Preload our schema..
        PnItemGasto thisSchemaLoad = new PnItemGasto();
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
        public PnItemGastoCollection FetchAll()
        {
            PnItemGastoCollection coll = new PnItemGastoCollection();
            Query qry = new Query(PnItemGasto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnItemGastoCollection FetchByID(object IdItemGasto)
        {
            PnItemGastoCollection coll = new PnItemGastoCollection().Where("id_item_gasto", IdItemGasto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnItemGastoCollection FetchByQuery(Query qry)
        {
            PnItemGastoCollection coll = new PnItemGastoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdItemGasto)
        {
            return (PnItemGasto.Delete(IdItemGasto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdItemGasto)
        {
            return (PnItemGasto.Destroy(IdItemGasto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ItemNombre)
	    {
		    PnItemGasto item = new PnItemGasto();
		    
            item.ItemNombre = ItemNombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdItemGasto,string ItemNombre)
	    {
		    PnItemGasto item = new PnItemGasto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdItemGasto = IdItemGasto;
				
			item.ItemNombre = ItemNombre;
				
	        item.Save(UserName);
	    }
    }
}
