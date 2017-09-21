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
    /// Controller class for PN_tribus
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTribuController
    {
        // Preload our schema..
        PnTribu thisSchemaLoad = new PnTribu();
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
        public PnTribuCollection FetchAll()
        {
            PnTribuCollection coll = new PnTribuCollection();
            Query qry = new Query(PnTribu.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTribuCollection FetchByID(object IdTribu)
        {
            PnTribuCollection coll = new PnTribuCollection().Where("id_tribu", IdTribu).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTribuCollection FetchByQuery(Query qry)
        {
            PnTribuCollection coll = new PnTribuCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTribu)
        {
            return (PnTribu.Delete(IdTribu) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTribu)
        {
            return (PnTribu.Destroy(IdTribu) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    PnTribu item = new PnTribu();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTribu,string Nombre)
	    {
		    PnTribu item = new PnTribu();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTribu = IdTribu;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
