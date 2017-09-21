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
    /// Controller class for APR_ActualPatologiaEmbarazo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprActualPatologiaEmbarazoController
    {
        // Preload our schema..
        AprActualPatologiaEmbarazo thisSchemaLoad = new AprActualPatologiaEmbarazo();
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
        public AprActualPatologiaEmbarazoCollection FetchAll()
        {
            AprActualPatologiaEmbarazoCollection coll = new AprActualPatologiaEmbarazoCollection();
            Query qry = new Query(AprActualPatologiaEmbarazo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActualPatologiaEmbarazoCollection FetchByID(object IdActualPatologiaEmbarazo)
        {
            AprActualPatologiaEmbarazoCollection coll = new AprActualPatologiaEmbarazoCollection().Where("idActualPatologiaEmbarazo", IdActualPatologiaEmbarazo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActualPatologiaEmbarazoCollection FetchByQuery(Query qry)
        {
            AprActualPatologiaEmbarazoCollection coll = new AprActualPatologiaEmbarazoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdActualPatologiaEmbarazo)
        {
            return (AprActualPatologiaEmbarazo.Delete(IdActualPatologiaEmbarazo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdActualPatologiaEmbarazo)
        {
            return (AprActualPatologiaEmbarazo.Destroy(IdActualPatologiaEmbarazo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdEmbarazo,int IdPatologiaEmbarazo)
	    {
		    AprActualPatologiaEmbarazo item = new AprActualPatologiaEmbarazo();
		    
            item.IdEfector = IdEfector;
            
            item.IdEmbarazo = IdEmbarazo;
            
            item.IdPatologiaEmbarazo = IdPatologiaEmbarazo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdActualPatologiaEmbarazo,int IdEfector,int IdEmbarazo,int IdPatologiaEmbarazo)
	    {
		    AprActualPatologiaEmbarazo item = new AprActualPatologiaEmbarazo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdActualPatologiaEmbarazo = IdActualPatologiaEmbarazo;
				
			item.IdEfector = IdEfector;
				
			item.IdEmbarazo = IdEmbarazo;
				
			item.IdPatologiaEmbarazo = IdPatologiaEmbarazo;
				
	        item.Save(UserName);
	    }
    }
}
