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
    /// Controller class for APR_TipoActividadEmbarazo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprTipoActividadEmbarazoController
    {
        // Preload our schema..
        AprTipoActividadEmbarazo thisSchemaLoad = new AprTipoActividadEmbarazo();
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
        public AprTipoActividadEmbarazoCollection FetchAll()
        {
            AprTipoActividadEmbarazoCollection coll = new AprTipoActividadEmbarazoCollection();
            Query qry = new Query(AprTipoActividadEmbarazo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTipoActividadEmbarazoCollection FetchByID(object IdTipoActividadEmbarazo)
        {
            AprTipoActividadEmbarazoCollection coll = new AprTipoActividadEmbarazoCollection().Where("idTipoActividadEmbarazo", IdTipoActividadEmbarazo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTipoActividadEmbarazoCollection FetchByQuery(Query qry)
        {
            AprTipoActividadEmbarazoCollection coll = new AprTipoActividadEmbarazoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoActividadEmbarazo)
        {
            return (AprTipoActividadEmbarazo.Delete(IdTipoActividadEmbarazo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoActividadEmbarazo)
        {
            return (AprTipoActividadEmbarazo.Destroy(IdTipoActividadEmbarazo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprTipoActividadEmbarazo item = new AprTipoActividadEmbarazo();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoActividadEmbarazo,string Nombre)
	    {
		    AprTipoActividadEmbarazo item = new AprTipoActividadEmbarazo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoActividadEmbarazo = IdTipoActividadEmbarazo;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
