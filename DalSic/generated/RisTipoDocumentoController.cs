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
    /// Controller class for RIS_TipoDocumento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisTipoDocumentoController
    {
        // Preload our schema..
        RisTipoDocumento thisSchemaLoad = new RisTipoDocumento();
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
        public RisTipoDocumentoCollection FetchAll()
        {
            RisTipoDocumentoCollection coll = new RisTipoDocumentoCollection();
            Query qry = new Query(RisTipoDocumento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisTipoDocumentoCollection FetchByID(object IdTipoDocumento)
        {
            RisTipoDocumentoCollection coll = new RisTipoDocumentoCollection().Where("idTipoDocumento", IdTipoDocumento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisTipoDocumentoCollection FetchByQuery(Query qry)
        {
            RisTipoDocumentoCollection coll = new RisTipoDocumentoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoDocumento)
        {
            return (RisTipoDocumento.Delete(IdTipoDocumento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoDocumento)
        {
            return (RisTipoDocumento.Destroy(IdTipoDocumento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisTipoDocumento item = new RisTipoDocumento();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoDocumento,string Descripcion)
	    {
		    RisTipoDocumento item = new RisTipoDocumento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoDocumento = IdTipoDocumento;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
