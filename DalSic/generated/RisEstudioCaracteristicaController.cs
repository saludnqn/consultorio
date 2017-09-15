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
    /// Controller class for RIS_EstudioCaracteristica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioCaracteristicaController
    {
        // Preload our schema..
        RisEstudioCaracteristica thisSchemaLoad = new RisEstudioCaracteristica();
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
        public RisEstudioCaracteristicaCollection FetchAll()
        {
            RisEstudioCaracteristicaCollection coll = new RisEstudioCaracteristicaCollection();
            Query qry = new Query(RisEstudioCaracteristica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioCaracteristicaCollection FetchByID(object IdEstudioCaracteristica)
        {
            RisEstudioCaracteristicaCollection coll = new RisEstudioCaracteristicaCollection().Where("idEstudioCaracteristica", IdEstudioCaracteristica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioCaracteristicaCollection FetchByQuery(Query qry)
        {
            RisEstudioCaracteristicaCollection coll = new RisEstudioCaracteristicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioCaracteristica)
        {
            return (RisEstudioCaracteristica.Delete(IdEstudioCaracteristica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioCaracteristica)
        {
            return (RisEstudioCaracteristica.Destroy(IdEstudioCaracteristica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,int IdCaracteristica)
	    {
		    RisEstudioCaracteristica item = new RisEstudioCaracteristica();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdCaracteristica = IdCaracteristica;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioCaracteristica,int IdEstudio,int IdCaracteristica)
	    {
		    RisEstudioCaracteristica item = new RisEstudioCaracteristica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioCaracteristica = IdEstudioCaracteristica;
				
			item.IdEstudio = IdEstudio;
				
			item.IdCaracteristica = IdCaracteristica;
				
	        item.Save(UserName);
	    }
    }
}
