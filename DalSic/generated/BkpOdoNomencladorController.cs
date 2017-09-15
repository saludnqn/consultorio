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
    /// Controller class for bkp_ODO_Nomenclador
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BkpOdoNomencladorController
    {
        // Preload our schema..
        BkpOdoNomenclador thisSchemaLoad = new BkpOdoNomenclador();
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
        public BkpOdoNomencladorCollection FetchAll()
        {
            BkpOdoNomencladorCollection coll = new BkpOdoNomencladorCollection();
            Query qry = new Query(BkpOdoNomenclador.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BkpOdoNomencladorCollection FetchByID(object NomencladorID)
        {
            BkpOdoNomencladorCollection coll = new BkpOdoNomencladorCollection().Where("NomencladorID", NomencladorID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BkpOdoNomencladorCollection FetchByQuery(Query qry)
        {
            BkpOdoNomencladorCollection coll = new BkpOdoNomencladorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object NomencladorID)
        {
            return (BkpOdoNomenclador.Delete(NomencladorID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object NomencladorID)
        {
            return (BkpOdoNomenclador.Destroy(NomencladorID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string NomencladorID,string NomencladorDescripcion,string NomencladorClasificacion)
	    {
		    BkpOdoNomenclador item = new BkpOdoNomenclador();
		    
            item.NomencladorID = NomencladorID;
            
            item.NomencladorDescripcion = NomencladorDescripcion;
            
            item.NomencladorClasificacion = NomencladorClasificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string NomencladorID,string NomencladorDescripcion,string NomencladorClasificacion)
	    {
		    BkpOdoNomenclador item = new BkpOdoNomenclador();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.NomencladorID = NomencladorID;
				
			item.NomencladorDescripcion = NomencladorDescripcion;
				
			item.NomencladorClasificacion = NomencladorClasificacion;
				
	        item.Save(UserName);
	    }
    }
}
