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
    /// Controller class for PN_vac_apli
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnVacApliController
    {
        // Preload our schema..
        PnVacApli thisSchemaLoad = new PnVacApli();
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
        public PnVacApliCollection FetchAll()
        {
            PnVacApliCollection coll = new PnVacApliCollection();
            Query qry = new Query(PnVacApli.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnVacApliCollection FetchByID(object IdVacApli)
        {
            PnVacApliCollection coll = new PnVacApliCollection().Where("id_vac_apli", IdVacApli).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnVacApliCollection FetchByQuery(Query qry)
        {
            PnVacApliCollection coll = new PnVacApliCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdVacApli)
        {
            return (PnVacApli.Delete(IdVacApli) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdVacApli)
        {
            return (PnVacApli.Destroy(IdVacApli) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    PnVacApli item = new PnVacApli();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdVacApli,string Nombre)
	    {
		    PnVacApli item = new PnVacApli();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdVacApli = IdVacApli;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
