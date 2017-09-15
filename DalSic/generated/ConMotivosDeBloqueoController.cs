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
    /// Controller class for CON_MotivosDeBloqueo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConMotivosDeBloqueoController
    {
        // Preload our schema..
        ConMotivosDeBloqueo thisSchemaLoad = new ConMotivosDeBloqueo();
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
        public ConMotivosDeBloqueoCollection FetchAll()
        {
            ConMotivosDeBloqueoCollection coll = new ConMotivosDeBloqueoCollection();
            Query qry = new Query(ConMotivosDeBloqueo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConMotivosDeBloqueoCollection FetchByID(object IdMotivoBloqueo)
        {
            ConMotivosDeBloqueoCollection coll = new ConMotivosDeBloqueoCollection().Where("idMotivoBloqueo", IdMotivoBloqueo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConMotivosDeBloqueoCollection FetchByQuery(Query qry)
        {
            ConMotivosDeBloqueoCollection coll = new ConMotivosDeBloqueoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivoBloqueo)
        {
            return (ConMotivosDeBloqueo.Delete(IdMotivoBloqueo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivoBloqueo)
        {
            return (ConMotivosDeBloqueo.Destroy(IdMotivoBloqueo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    ConMotivosDeBloqueo item = new ConMotivosDeBloqueo();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivoBloqueo,string Descripcion)
	    {
		    ConMotivosDeBloqueo item = new ConMotivosDeBloqueo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivoBloqueo = IdMotivoBloqueo;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
