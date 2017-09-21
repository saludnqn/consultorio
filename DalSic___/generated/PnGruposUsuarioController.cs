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
    /// Controller class for PN_grupos_usuarios
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnGruposUsuarioController
    {
        // Preload our schema..
        PnGruposUsuario thisSchemaLoad = new PnGruposUsuario();
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
        public PnGruposUsuarioCollection FetchAll()
        {
            PnGruposUsuarioCollection coll = new PnGruposUsuarioCollection();
            Query qry = new Query(PnGruposUsuario.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnGruposUsuarioCollection FetchByID(object IdGu)
        {
            PnGruposUsuarioCollection coll = new PnGruposUsuarioCollection().Where("id_gu", IdGu).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnGruposUsuarioCollection FetchByQuery(Query qry)
        {
            PnGruposUsuarioCollection coll = new PnGruposUsuarioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdGu)
        {
            return (PnGruposUsuario.Delete(IdGu) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdGu)
        {
            return (PnGruposUsuario.Destroy(IdGu) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdGrupo,int IdUsuario)
	    {
		    PnGruposUsuario item = new PnGruposUsuario();
		    
            item.IdGrupo = IdGrupo;
            
            item.IdUsuario = IdUsuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdGu,int IdGrupo,int IdUsuario)
	    {
		    PnGruposUsuario item = new PnGruposUsuario();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdGu = IdGu;
				
			item.IdGrupo = IdGrupo;
				
			item.IdUsuario = IdUsuario;
				
	        item.Save(UserName);
	    }
    }
}
