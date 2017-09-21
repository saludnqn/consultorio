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
    /// Controller class for CON_TipoActividadGrupal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTipoActividadGrupalController
    {
        // Preload our schema..
        ConTipoActividadGrupal thisSchemaLoad = new ConTipoActividadGrupal();
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
        public ConTipoActividadGrupalCollection FetchAll()
        {
            ConTipoActividadGrupalCollection coll = new ConTipoActividadGrupalCollection();
            Query qry = new Query(ConTipoActividadGrupal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTipoActividadGrupalCollection FetchByID(object IdTipoActividadGrupal)
        {
            ConTipoActividadGrupalCollection coll = new ConTipoActividadGrupalCollection().Where("idTipoActividadGrupal", IdTipoActividadGrupal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTipoActividadGrupalCollection FetchByQuery(Query qry)
        {
            ConTipoActividadGrupalCollection coll = new ConTipoActividadGrupalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoActividadGrupal)
        {
            return (ConTipoActividadGrupal.Delete(IdTipoActividadGrupal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoActividadGrupal)
        {
            return (ConTipoActividadGrupal.Destroy(IdTipoActividadGrupal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConTipoActividadGrupal item = new ConTipoActividadGrupal();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoActividadGrupal,string Nombre)
	    {
		    ConTipoActividadGrupal item = new ConTipoActividadGrupal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoActividadGrupal = IdTipoActividadGrupal;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
