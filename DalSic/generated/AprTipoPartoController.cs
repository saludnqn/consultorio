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
    /// Controller class for APR_TipoParto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprTipoPartoController
    {
        // Preload our schema..
        AprTipoParto thisSchemaLoad = new AprTipoParto();
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
        public AprTipoPartoCollection FetchAll()
        {
            AprTipoPartoCollection coll = new AprTipoPartoCollection();
            Query qry = new Query(AprTipoParto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTipoPartoCollection FetchByID(object IdTipoParto)
        {
            AprTipoPartoCollection coll = new AprTipoPartoCollection().Where("idTipoParto", IdTipoParto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTipoPartoCollection FetchByQuery(Query qry)
        {
            AprTipoPartoCollection coll = new AprTipoPartoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoParto)
        {
            return (AprTipoParto.Delete(IdTipoParto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoParto)
        {
            return (AprTipoParto.Destroy(IdTipoParto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprTipoParto item = new AprTipoParto();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoParto,string Nombre)
	    {
		    AprTipoParto item = new AprTipoParto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoParto = IdTipoParto;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
