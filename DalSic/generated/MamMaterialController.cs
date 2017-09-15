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
    /// Controller class for MAM_Material
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamMaterialController
    {
        // Preload our schema..
        MamMaterial thisSchemaLoad = new MamMaterial();
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
        public MamMaterialCollection FetchAll()
        {
            MamMaterialCollection coll = new MamMaterialCollection();
            Query qry = new Query(MamMaterial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamMaterialCollection FetchByID(object IdMaterial)
        {
            MamMaterialCollection coll = new MamMaterialCollection().Where("idMaterial", IdMaterial).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamMaterialCollection FetchByQuery(Query qry)
        {
            MamMaterialCollection coll = new MamMaterialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMaterial)
        {
            return (MamMaterial.Delete(IdMaterial) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMaterial)
        {
            return (MamMaterial.Destroy(IdMaterial) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamMaterial item = new MamMaterial();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMaterial,string Descripcion)
	    {
		    MamMaterial item = new MamMaterial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMaterial = IdMaterial;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
