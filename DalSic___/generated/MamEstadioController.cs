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
    /// Controller class for MAM_Estadio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamEstadioController
    {
        // Preload our schema..
        MamEstadio thisSchemaLoad = new MamEstadio();
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
        public MamEstadioCollection FetchAll()
        {
            MamEstadioCollection coll = new MamEstadioCollection();
            Query qry = new Query(MamEstadio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstadioCollection FetchByID(object IdEstadio)
        {
            MamEstadioCollection coll = new MamEstadioCollection().Where("idEstadio", IdEstadio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstadioCollection FetchByQuery(Query qry)
        {
            MamEstadioCollection coll = new MamEstadioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstadio)
        {
            return (MamEstadio.Delete(IdEstadio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstadio)
        {
            return (MamEstadio.Destroy(IdEstadio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamEstadio item = new MamEstadio();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstadio,string Descripcion)
	    {
		    MamEstadio item = new MamEstadio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstadio = IdEstadio;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
