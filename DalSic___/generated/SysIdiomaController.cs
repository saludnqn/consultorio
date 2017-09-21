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
    /// Controller class for Sys_Idioma
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysIdiomaController
    {
        // Preload our schema..
        SysIdioma thisSchemaLoad = new SysIdioma();
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
        public SysIdiomaCollection FetchAll()
        {
            SysIdiomaCollection coll = new SysIdiomaCollection();
            Query qry = new Query(SysIdioma.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysIdiomaCollection FetchByID(object IdIdioma)
        {
            SysIdiomaCollection coll = new SysIdiomaCollection().Where("idIdioma", IdIdioma).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysIdiomaCollection FetchByQuery(Query qry)
        {
            SysIdiomaCollection coll = new SysIdiomaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIdioma)
        {
            return (SysIdioma.Delete(IdIdioma) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIdioma)
        {
            return (SysIdioma.Destroy(IdIdioma) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysIdioma item = new SysIdioma();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIdioma,string Nombre)
	    {
		    SysIdioma item = new SysIdioma();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIdioma = IdIdioma;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
