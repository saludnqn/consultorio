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
    /// Controller class for CON_MotivosRechazo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConMotivosRechazoController
    {
        // Preload our schema..
        ConMotivosRechazo thisSchemaLoad = new ConMotivosRechazo();
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
        public ConMotivosRechazoCollection FetchAll()
        {
            ConMotivosRechazoCollection coll = new ConMotivosRechazoCollection();
            Query qry = new Query(ConMotivosRechazo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConMotivosRechazoCollection FetchByID(object IdMotivoRechazo)
        {
            ConMotivosRechazoCollection coll = new ConMotivosRechazoCollection().Where("idMotivoRechazo", IdMotivoRechazo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConMotivosRechazoCollection FetchByQuery(Query qry)
        {
            ConMotivosRechazoCollection coll = new ConMotivosRechazoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivoRechazo)
        {
            return (ConMotivosRechazo.Delete(IdMotivoRechazo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivoRechazo)
        {
            return (ConMotivosRechazo.Destroy(IdMotivoRechazo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConMotivosRechazo item = new ConMotivosRechazo();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivoRechazo,string Nombre)
	    {
		    ConMotivosRechazo item = new ConMotivosRechazo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivoRechazo = IdMotivoRechazo;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
