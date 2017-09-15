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
    /// Controller class for PN_inciso_item_gasto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnIncisoItemGastoController
    {
        // Preload our schema..
        PnIncisoItemGasto thisSchemaLoad = new PnIncisoItemGasto();
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
        public PnIncisoItemGastoCollection FetchAll()
        {
            PnIncisoItemGastoCollection coll = new PnIncisoItemGastoCollection();
            Query qry = new Query(PnIncisoItemGasto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIncisoItemGastoCollection FetchByID(object IdIncisoItemGasto)
        {
            PnIncisoItemGastoCollection coll = new PnIncisoItemGastoCollection().Where("id_inciso_item_gasto", IdIncisoItemGasto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIncisoItemGastoCollection FetchByQuery(Query qry)
        {
            PnIncisoItemGastoCollection coll = new PnIncisoItemGastoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIncisoItemGasto)
        {
            return (PnIncisoItemGasto.Delete(IdIncisoItemGasto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIncisoItemGasto)
        {
            return (PnIncisoItemGasto.Destroy(IdIncisoItemGasto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdInciso,int IdItemGasto)
	    {
		    PnIncisoItemGasto item = new PnIncisoItemGasto();
		    
            item.IdInciso = IdInciso;
            
            item.IdItemGasto = IdItemGasto;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIncisoItemGasto,int IdInciso,int IdItemGasto)
	    {
		    PnIncisoItemGasto item = new PnIncisoItemGasto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIncisoItemGasto = IdIncisoItemGasto;
				
			item.IdInciso = IdInciso;
				
			item.IdItemGasto = IdItemGasto;
				
	        item.Save(UserName);
	    }
    }
}
