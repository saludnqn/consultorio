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
    /// Controller class for PN_pais
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPaiController
    {
        // Preload our schema..
        PnPai thisSchemaLoad = new PnPai();
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
        public PnPaiCollection FetchAll()
        {
            PnPaiCollection coll = new PnPaiCollection();
            Query qry = new Query(PnPai.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPaiCollection FetchByID(object IdPais)
        {
            PnPaiCollection coll = new PnPaiCollection().Where("id_pais", IdPais).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPaiCollection FetchByQuery(Query qry)
        {
            PnPaiCollection coll = new PnPaiCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPais)
        {
            return (PnPai.Delete(IdPais) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPais)
        {
            return (PnPai.Destroy(IdPais) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    PnPai item = new PnPai();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPais,string Nombre)
	    {
		    PnPai item = new PnPai();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPais = IdPais;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
