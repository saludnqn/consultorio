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
    /// Controller class for APR_ActividadEmbarazo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprActividadEmbarazoController
    {
        // Preload our schema..
        AprActividadEmbarazo thisSchemaLoad = new AprActividadEmbarazo();
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
        public AprActividadEmbarazoCollection FetchAll()
        {
            AprActividadEmbarazoCollection coll = new AprActividadEmbarazoCollection();
            Query qry = new Query(AprActividadEmbarazo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActividadEmbarazoCollection FetchByID(object IdActividadEmbarazo)
        {
            AprActividadEmbarazoCollection coll = new AprActividadEmbarazoCollection().Where("idActividadEmbarazo", IdActividadEmbarazo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActividadEmbarazoCollection FetchByQuery(Query qry)
        {
            AprActividadEmbarazoCollection coll = new AprActividadEmbarazoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdActividadEmbarazo)
        {
            return (AprActividadEmbarazo.Delete(IdActividadEmbarazo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdActividadEmbarazo)
        {
            return (AprActividadEmbarazo.Destroy(IdActividadEmbarazo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdTipoActividadEmbarazo,string Nombre)
	    {
		    AprActividadEmbarazo item = new AprActividadEmbarazo();
		    
            item.IdTipoActividadEmbarazo = IdTipoActividadEmbarazo;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdActividadEmbarazo,int IdTipoActividadEmbarazo,string Nombre)
	    {
		    AprActividadEmbarazo item = new AprActividadEmbarazo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdActividadEmbarazo = IdActividadEmbarazo;
				
			item.IdTipoActividadEmbarazo = IdTipoActividadEmbarazo;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
