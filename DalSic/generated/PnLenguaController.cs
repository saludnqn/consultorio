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
    /// Controller class for PN_lenguas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLenguaController
    {
        // Preload our schema..
        PnLengua thisSchemaLoad = new PnLengua();
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
        public PnLenguaCollection FetchAll()
        {
            PnLenguaCollection coll = new PnLenguaCollection();
            Query qry = new Query(PnLengua.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLenguaCollection FetchByID(object IdLengua)
        {
            PnLenguaCollection coll = new PnLenguaCollection().Where("id_lengua", IdLengua).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLenguaCollection FetchByQuery(Query qry)
        {
            PnLenguaCollection coll = new PnLenguaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLengua)
        {
            return (PnLengua.Delete(IdLengua) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLengua)
        {
            return (PnLengua.Destroy(IdLengua) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    PnLengua item = new PnLengua();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLengua,string Nombre)
	    {
		    PnLengua item = new PnLengua();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLengua = IdLengua;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
