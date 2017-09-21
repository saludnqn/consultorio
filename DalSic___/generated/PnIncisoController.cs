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
    /// Controller class for PN_inciso
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnIncisoController
    {
        // Preload our schema..
        PnInciso thisSchemaLoad = new PnInciso();
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
        public PnIncisoCollection FetchAll()
        {
            PnIncisoCollection coll = new PnIncisoCollection();
            Query qry = new Query(PnInciso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIncisoCollection FetchByID(object IdInciso)
        {
            PnIncisoCollection coll = new PnIncisoCollection().Where("id_inciso", IdInciso).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIncisoCollection FetchByQuery(Query qry)
        {
            PnIncisoCollection coll = new PnIncisoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInciso)
        {
            return (PnInciso.Delete(IdInciso) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInciso)
        {
            return (PnInciso.Destroy(IdInciso) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string InsNombre,string Codigo)
	    {
		    PnInciso item = new PnInciso();
		    
            item.InsNombre = InsNombre;
            
            item.Codigo = Codigo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInciso,string InsNombre,string Codigo)
	    {
		    PnInciso item = new PnInciso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInciso = IdInciso;
				
			item.InsNombre = InsNombre;
				
			item.Codigo = Codigo;
				
	        item.Save(UserName);
	    }
    }
}
