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
    /// Controller class for PN_periodo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPeriodoController
    {
        // Preload our schema..
        PnPeriodo thisSchemaLoad = new PnPeriodo();
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
        public PnPeriodoCollection FetchAll()
        {
            PnPeriodoCollection coll = new PnPeriodoCollection();
            Query qry = new Query(PnPeriodo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPeriodoCollection FetchByID(object IdPeriodo)
        {
            PnPeriodoCollection coll = new PnPeriodoCollection().Where("id_periodo", IdPeriodo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPeriodoCollection FetchByQuery(Query qry)
        {
            PnPeriodoCollection coll = new PnPeriodoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPeriodo)
        {
            return (PnPeriodo.Delete(IdPeriodo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPeriodo)
        {
            return (PnPeriodo.Destroy(IdPeriodo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Periodo)
	    {
		    PnPeriodo item = new PnPeriodo();
		    
            item.Periodo = Periodo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPeriodo,string Periodo)
	    {
		    PnPeriodo item = new PnPeriodo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPeriodo = IdPeriodo;
				
			item.Periodo = Periodo;
				
	        item.Save(UserName);
	    }
    }
}
