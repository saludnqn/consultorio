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
    /// Controller class for APR_AntecedentePatologiaEmbarazo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAntecedentePatologiaEmbarazoController
    {
        // Preload our schema..
        AprAntecedentePatologiaEmbarazo thisSchemaLoad = new AprAntecedentePatologiaEmbarazo();
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
        public AprAntecedentePatologiaEmbarazoCollection FetchAll()
        {
            AprAntecedentePatologiaEmbarazoCollection coll = new AprAntecedentePatologiaEmbarazoCollection();
            Query qry = new Query(AprAntecedentePatologiaEmbarazo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAntecedentePatologiaEmbarazoCollection FetchByID(object IdAntecedentePatologiaEmbarazo)
        {
            AprAntecedentePatologiaEmbarazoCollection coll = new AprAntecedentePatologiaEmbarazoCollection().Where("idAntecedentePatologiaEmbarazo", IdAntecedentePatologiaEmbarazo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAntecedentePatologiaEmbarazoCollection FetchByQuery(Query qry)
        {
            AprAntecedentePatologiaEmbarazoCollection coll = new AprAntecedentePatologiaEmbarazoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAntecedentePatologiaEmbarazo)
        {
            return (AprAntecedentePatologiaEmbarazo.Delete(IdAntecedentePatologiaEmbarazo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAntecedentePatologiaEmbarazo)
        {
            return (AprAntecedentePatologiaEmbarazo.Destroy(IdAntecedentePatologiaEmbarazo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdEmbarazo,int IdPatologiaEmbarazo)
	    {
		    AprAntecedentePatologiaEmbarazo item = new AprAntecedentePatologiaEmbarazo();
		    
            item.IdEfector = IdEfector;
            
            item.IdEmbarazo = IdEmbarazo;
            
            item.IdPatologiaEmbarazo = IdPatologiaEmbarazo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAntecedentePatologiaEmbarazo,int IdEfector,int IdEmbarazo,int IdPatologiaEmbarazo)
	    {
		    AprAntecedentePatologiaEmbarazo item = new AprAntecedentePatologiaEmbarazo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAntecedentePatologiaEmbarazo = IdAntecedentePatologiaEmbarazo;
				
			item.IdEfector = IdEfector;
				
			item.IdEmbarazo = IdEmbarazo;
				
			item.IdPatologiaEmbarazo = IdPatologiaEmbarazo;
				
	        item.Save(UserName);
	    }
    }
}
