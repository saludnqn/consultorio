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
    /// Controller class for PN_provincias
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnProvinciaController
    {
        // Preload our schema..
        PnProvincia thisSchemaLoad = new PnProvincia();
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
        public PnProvinciaCollection FetchAll()
        {
            PnProvinciaCollection coll = new PnProvinciaCollection();
            Query qry = new Query(PnProvincia.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnProvinciaCollection FetchByID(object IdProvincia)
        {
            PnProvinciaCollection coll = new PnProvinciaCollection().Where("id_provincia", IdProvincia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnProvinciaCollection FetchByQuery(Query qry)
        {
            PnProvinciaCollection coll = new PnProvinciaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProvincia)
        {
            return (PnProvincia.Delete(IdProvincia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProvincia)
        {
            return (PnProvincia.Destroy(IdProvincia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CodProvincia,string Nombre,int IdPais)
	    {
		    PnProvincia item = new PnProvincia();
		    
            item.CodProvincia = CodProvincia;
            
            item.Nombre = Nombre;
            
            item.IdPais = IdPais;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProvincia,string CodProvincia,string Nombre,int IdPais)
	    {
		    PnProvincia item = new PnProvincia();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProvincia = IdProvincia;
				
			item.CodProvincia = CodProvincia;
				
			item.Nombre = Nombre;
				
			item.IdPais = IdPais;
				
	        item.Save(UserName);
	    }
    }
}
