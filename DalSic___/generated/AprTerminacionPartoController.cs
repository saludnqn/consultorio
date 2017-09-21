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
    /// Controller class for APR_TerminacionParto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprTerminacionPartoController
    {
        // Preload our schema..
        AprTerminacionParto thisSchemaLoad = new AprTerminacionParto();
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
        public AprTerminacionPartoCollection FetchAll()
        {
            AprTerminacionPartoCollection coll = new AprTerminacionPartoCollection();
            Query qry = new Query(AprTerminacionParto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTerminacionPartoCollection FetchByID(object IdTerminacionParto)
        {
            AprTerminacionPartoCollection coll = new AprTerminacionPartoCollection().Where("idTerminacionParto", IdTerminacionParto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTerminacionPartoCollection FetchByQuery(Query qry)
        {
            AprTerminacionPartoCollection coll = new AprTerminacionPartoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTerminacionParto)
        {
            return (AprTerminacionParto.Delete(IdTerminacionParto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTerminacionParto)
        {
            return (AprTerminacionParto.Destroy(IdTerminacionParto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,bool Local)
	    {
		    AprTerminacionParto item = new AprTerminacionParto();
		    
            item.Nombre = Nombre;
            
            item.Local = Local;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTerminacionParto,string Nombre,bool Local)
	    {
		    AprTerminacionParto item = new AprTerminacionParto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTerminacionParto = IdTerminacionParto;
				
			item.Nombre = Nombre;
				
			item.Local = Local;
				
	        item.Save(UserName);
	    }
    }
}
