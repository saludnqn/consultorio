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
    /// Controller class for Rem_TipoCobertura
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemTipoCoberturaController
    {
        // Preload our schema..
        RemTipoCobertura thisSchemaLoad = new RemTipoCobertura();
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
        public RemTipoCoberturaCollection FetchAll()
        {
            RemTipoCoberturaCollection coll = new RemTipoCoberturaCollection();
            Query qry = new Query(RemTipoCobertura.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemTipoCoberturaCollection FetchByID(object IdTipoCobertura)
        {
            RemTipoCoberturaCollection coll = new RemTipoCoberturaCollection().Where("idTipoCobertura", IdTipoCobertura).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemTipoCoberturaCollection FetchByQuery(Query qry)
        {
            RemTipoCoberturaCollection coll = new RemTipoCoberturaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoCobertura)
        {
            return (RemTipoCobertura.Delete(IdTipoCobertura) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoCobertura)
        {
            return (RemTipoCobertura.Destroy(IdTipoCobertura) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    RemTipoCobertura item = new RemTipoCobertura();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoCobertura,string Nombre)
	    {
		    RemTipoCobertura item = new RemTipoCobertura();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoCobertura = IdTipoCobertura;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
