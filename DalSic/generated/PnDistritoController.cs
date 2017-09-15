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
    /// Controller class for PN_distrito
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDistritoController
    {
        // Preload our schema..
        PnDistrito thisSchemaLoad = new PnDistrito();
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
        public PnDistritoCollection FetchAll()
        {
            PnDistritoCollection coll = new PnDistritoCollection();
            Query qry = new Query(PnDistrito.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDistritoCollection FetchByID(object IdDistrito)
        {
            PnDistritoCollection coll = new PnDistritoCollection().Where("id_distrito", IdDistrito).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDistritoCollection FetchByQuery(Query qry)
        {
            PnDistritoCollection coll = new PnDistritoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDistrito)
        {
            return (PnDistrito.Delete(IdDistrito) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDistrito)
        {
            return (PnDistrito.Destroy(IdDistrito) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Observaciones)
	    {
		    PnDistrito item = new PnDistrito();
		    
            item.Nombre = Nombre;
            
            item.Observaciones = Observaciones;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDistrito,string Nombre,string Observaciones)
	    {
		    PnDistrito item = new PnDistrito();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDistrito = IdDistrito;
				
			item.Nombre = Nombre;
				
			item.Observaciones = Observaciones;
				
	        item.Save(UserName);
	    }
    }
}
