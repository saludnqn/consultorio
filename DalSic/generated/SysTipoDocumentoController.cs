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
    /// Controller class for Sys_TipoDocumento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysTipoDocumentoController
    {
        // Preload our schema..
        SysTipoDocumento thisSchemaLoad = new SysTipoDocumento();
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
        public SysTipoDocumentoCollection FetchAll()
        {
            SysTipoDocumentoCollection coll = new SysTipoDocumentoCollection();
            Query qry = new Query(SysTipoDocumento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysTipoDocumentoCollection FetchByID(object IdTipoDocumento)
        {
            SysTipoDocumentoCollection coll = new SysTipoDocumentoCollection().Where("idTipoDocumento", IdTipoDocumento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysTipoDocumentoCollection FetchByQuery(Query qry)
        {
            SysTipoDocumentoCollection coll = new SysTipoDocumentoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoDocumento)
        {
            return (SysTipoDocumento.Delete(IdTipoDocumento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoDocumento)
        {
            return (SysTipoDocumento.Destroy(IdTipoDocumento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysTipoDocumento item = new SysTipoDocumento();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoDocumento,string Nombre)
	    {
		    SysTipoDocumento item = new SysTipoDocumento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoDocumento = IdTipoDocumento;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
