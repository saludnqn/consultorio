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
    /// Controller class for BDS_TipoDonante
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BdsTipoDonanteController
    {
        // Preload our schema..
        BdsTipoDonante thisSchemaLoad = new BdsTipoDonante();
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
        public BdsTipoDonanteCollection FetchAll()
        {
            BdsTipoDonanteCollection coll = new BdsTipoDonanteCollection();
            Query qry = new Query(BdsTipoDonante.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BdsTipoDonanteCollection FetchByID(object IdTipoDonante)
        {
            BdsTipoDonanteCollection coll = new BdsTipoDonanteCollection().Where("idTipoDonante", IdTipoDonante).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BdsTipoDonanteCollection FetchByQuery(Query qry)
        {
            BdsTipoDonanteCollection coll = new BdsTipoDonanteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoDonante)
        {
            return (BdsTipoDonante.Delete(IdTipoDonante) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoDonante)
        {
            return (BdsTipoDonante.Destroy(IdTipoDonante) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    BdsTipoDonante item = new BdsTipoDonante();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoDonante,string Nombre)
	    {
		    BdsTipoDonante item = new BdsTipoDonante();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoDonante = IdTipoDonante;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
