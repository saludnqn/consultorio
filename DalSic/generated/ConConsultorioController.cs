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
    /// Controller class for CON_Consultorio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConConsultorioController
    {
        // Preload our schema..
        ConConsultorio thisSchemaLoad = new ConConsultorio();
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
        public ConConsultorioCollection FetchAll()
        {
            ConConsultorioCollection coll = new ConConsultorioCollection();
            Query qry = new Query(ConConsultorio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultorioCollection FetchByID(object IdConsultorio)
        {
            ConConsultorioCollection coll = new ConConsultorioCollection().Where("idConsultorio", IdConsultorio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultorioCollection FetchByQuery(Query qry)
        {
            ConConsultorioCollection coll = new ConConsultorioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConsultorio)
        {
            return (ConConsultorio.Delete(IdConsultorio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConsultorio)
        {
            return (ConConsultorio.Destroy(IdConsultorio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdTipoConsultorio,string Nombre,bool Activo)
	    {
		    ConConsultorio item = new ConConsultorio();
		    
            item.IdEfector = IdEfector;
            
            item.IdTipoConsultorio = IdTipoConsultorio;
            
            item.Nombre = Nombre;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConsultorio,int IdEfector,int IdTipoConsultorio,string Nombre,bool Activo)
	    {
		    ConConsultorio item = new ConConsultorio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConsultorio = IdConsultorio;
				
			item.IdEfector = IdEfector;
				
			item.IdTipoConsultorio = IdTipoConsultorio;
				
			item.Nombre = Nombre;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
