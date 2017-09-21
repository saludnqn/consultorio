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
    /// Controller class for RIS_Caracteristica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisCaracteristicaController
    {
        // Preload our schema..
        RisCaracteristica thisSchemaLoad = new RisCaracteristica();
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
        public RisCaracteristicaCollection FetchAll()
        {
            RisCaracteristicaCollection coll = new RisCaracteristicaCollection();
            Query qry = new Query(RisCaracteristica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisCaracteristicaCollection FetchByID(object IdCaracteristica)
        {
            RisCaracteristicaCollection coll = new RisCaracteristicaCollection().Where("idCaracteristica", IdCaracteristica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisCaracteristicaCollection FetchByQuery(Query qry)
        {
            RisCaracteristicaCollection coll = new RisCaracteristicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCaracteristica)
        {
            return (RisCaracteristica.Delete(IdCaracteristica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCaracteristica)
        {
            return (RisCaracteristica.Destroy(IdCaracteristica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,string TipoEstudio)
	    {
		    RisCaracteristica item = new RisCaracteristica();
		    
            item.Descripcion = Descripcion;
            
            item.TipoEstudio = TipoEstudio;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCaracteristica,string Descripcion,string TipoEstudio)
	    {
		    RisCaracteristica item = new RisCaracteristica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCaracteristica = IdCaracteristica;
				
			item.Descripcion = Descripcion;
				
			item.TipoEstudio = TipoEstudio;
				
	        item.Save(UserName);
	    }
    }
}
