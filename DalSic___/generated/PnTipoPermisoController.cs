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
    /// Controller class for PN_tipo_permiso
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTipoPermisoController
    {
        // Preload our schema..
        PnTipoPermiso thisSchemaLoad = new PnTipoPermiso();
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
        public PnTipoPermisoCollection FetchAll()
        {
            PnTipoPermisoCollection coll = new PnTipoPermisoCollection();
            Query qry = new Query(PnTipoPermiso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTipoPermisoCollection FetchByID(object IdTipo)
        {
            PnTipoPermisoCollection coll = new PnTipoPermisoCollection().Where("id_tipo", IdTipo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTipoPermisoCollection FetchByQuery(Query qry)
        {
            PnTipoPermisoCollection coll = new PnTipoPermisoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipo)
        {
            return (PnTipoPermiso.Delete(IdTipo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipo)
        {
            return (PnTipoPermiso.Destroy(IdTipo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TipoNombre,string Img1Src,string Img2Src,string Img3Src)
	    {
		    PnTipoPermiso item = new PnTipoPermiso();
		    
            item.TipoNombre = TipoNombre;
            
            item.Img1Src = Img1Src;
            
            item.Img2Src = Img2Src;
            
            item.Img3Src = Img3Src;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipo,string TipoNombre,string Img1Src,string Img2Src,string Img3Src)
	    {
		    PnTipoPermiso item = new PnTipoPermiso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipo = IdTipo;
				
			item.TipoNombre = TipoNombre;
				
			item.Img1Src = Img1Src;
				
			item.Img2Src = Img2Src;
				
			item.Img3Src = Img3Src;
				
	        item.Save(UserName);
	    }
    }
}
