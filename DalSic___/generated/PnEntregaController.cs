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
    /// Controller class for PN_entrega
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEntregaController
    {
        // Preload our schema..
        PnEntrega thisSchemaLoad = new PnEntrega();
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
        public PnEntregaCollection FetchAll()
        {
            PnEntregaCollection coll = new PnEntregaCollection();
            Query qry = new Query(PnEntrega.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEntregaCollection FetchByID(object IdEntrega)
        {
            PnEntregaCollection coll = new PnEntregaCollection().Where("id_entrega", IdEntrega).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEntregaCollection FetchByQuery(Query qry)
        {
            PnEntregaCollection coll = new PnEntregaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEntrega)
        {
            return (PnEntrega.Delete(IdEntrega) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEntrega)
        {
            return (PnEntrega.Destroy(IdEntrega) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string DescripcionEntrega)
	    {
		    PnEntrega item = new PnEntrega();
		    
            item.DescripcionEntrega = DescripcionEntrega;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEntrega,string DescripcionEntrega)
	    {
		    PnEntrega item = new PnEntrega();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEntrega = IdEntrega;
				
			item.DescripcionEntrega = DescripcionEntrega;
				
	        item.Save(UserName);
	    }
    }
}
