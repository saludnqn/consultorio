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
    /// Controller class for CON_ConsultorioTipo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConConsultorioTipoController
    {
        // Preload our schema..
        ConConsultorioTipo thisSchemaLoad = new ConConsultorioTipo();
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
        public ConConsultorioTipoCollection FetchAll()
        {
            ConConsultorioTipoCollection coll = new ConConsultorioTipoCollection();
            Query qry = new Query(ConConsultorioTipo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultorioTipoCollection FetchByID(object IdTipoConsultorio)
        {
            ConConsultorioTipoCollection coll = new ConConsultorioTipoCollection().Where("idTipoConsultorio", IdTipoConsultorio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultorioTipoCollection FetchByQuery(Query qry)
        {
            ConConsultorioTipoCollection coll = new ConConsultorioTipoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoConsultorio)
        {
            return (ConConsultorioTipo.Delete(IdTipoConsultorio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoConsultorio)
        {
            return (ConConsultorioTipo.Destroy(IdTipoConsultorio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,string Nombre)
	    {
		    ConConsultorioTipo item = new ConConsultorioTipo();
		    
            item.IdEfector = IdEfector;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoConsultorio,int IdEfector,string Nombre)
	    {
		    ConConsultorioTipo item = new ConConsultorioTipo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoConsultorio = IdTipoConsultorio;
				
			item.IdEfector = IdEfector;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
