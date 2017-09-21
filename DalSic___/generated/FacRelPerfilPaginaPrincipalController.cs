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
    /// Controller class for FAC_RelPerfilPaginaPrincipal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class FacRelPerfilPaginaPrincipalController
    {
        // Preload our schema..
        FacRelPerfilPaginaPrincipal thisSchemaLoad = new FacRelPerfilPaginaPrincipal();
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
        public FacRelPerfilPaginaPrincipalCollection FetchAll()
        {
            FacRelPerfilPaginaPrincipalCollection coll = new FacRelPerfilPaginaPrincipalCollection();
            Query qry = new Query(FacRelPerfilPaginaPrincipal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacRelPerfilPaginaPrincipalCollection FetchByID(object IdRelPerfilPaginaPrincipal)
        {
            FacRelPerfilPaginaPrincipalCollection coll = new FacRelPerfilPaginaPrincipalCollection().Where("idRelPerfilPaginaPrincipal", IdRelPerfilPaginaPrincipal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacRelPerfilPaginaPrincipalCollection FetchByQuery(Query qry)
        {
            FacRelPerfilPaginaPrincipalCollection coll = new FacRelPerfilPaginaPrincipalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelPerfilPaginaPrincipal)
        {
            return (FacRelPerfilPaginaPrincipal.Delete(IdRelPerfilPaginaPrincipal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelPerfilPaginaPrincipal)
        {
            return (FacRelPerfilPaginaPrincipal.Destroy(IdRelPerfilPaginaPrincipal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPerfil,int IdMenu,string Url)
	    {
		    FacRelPerfilPaginaPrincipal item = new FacRelPerfilPaginaPrincipal();
		    
            item.IdPerfil = IdPerfil;
            
            item.IdMenu = IdMenu;
            
            item.Url = Url;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelPerfilPaginaPrincipal,int IdPerfil,int IdMenu,string Url)
	    {
		    FacRelPerfilPaginaPrincipal item = new FacRelPerfilPaginaPrincipal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelPerfilPaginaPrincipal = IdRelPerfilPaginaPrincipal;
				
			item.IdPerfil = IdPerfil;
				
			item.IdMenu = IdMenu;
				
			item.Url = Url;
				
	        item.Save(UserName);
	    }
    }
}
