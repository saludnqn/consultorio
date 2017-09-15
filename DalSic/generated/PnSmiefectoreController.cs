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
    /// Controller class for PN_smiefectores
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnSmiefectoreController
    {
        // Preload our schema..
        PnSmiefectore thisSchemaLoad = new PnSmiefectore();
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
        public PnSmiefectoreCollection FetchAll()
        {
            PnSmiefectoreCollection coll = new PnSmiefectoreCollection();
            Query qry = new Query(PnSmiefectore.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmiefectoreCollection FetchByID(object Cuie)
        {
            PnSmiefectoreCollection coll = new PnSmiefectoreCollection().Where("cuie", Cuie).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmiefectoreCollection FetchByQuery(Query qry)
        {
            PnSmiefectoreCollection coll = new PnSmiefectoreCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Cuie)
        {
            return (PnSmiefectore.Delete(Cuie) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Cuie)
        {
            return (PnSmiefectore.Destroy(Cuie) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Nombreefector,string Tipoefector,string Direccion,string Localidadmunicipiopartido)
	    {
		    PnSmiefectore item = new PnSmiefectore();
		    
            item.Cuie = Cuie;
            
            item.Nombreefector = Nombreefector;
            
            item.Tipoefector = Tipoefector;
            
            item.Direccion = Direccion;
            
            item.Localidadmunicipiopartido = Localidadmunicipiopartido;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Cuie,string Nombreefector,string Tipoefector,string Direccion,string Localidadmunicipiopartido)
	    {
		    PnSmiefectore item = new PnSmiefectore();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Cuie = Cuie;
				
			item.Nombreefector = Nombreefector;
				
			item.Tipoefector = Tipoefector;
				
			item.Direccion = Direccion;
				
			item.Localidadmunicipiopartido = Localidadmunicipiopartido;
				
	        item.Save(UserName);
	    }
    }
}
