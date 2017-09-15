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
    /// Controller class for ICO_TiposUsuario
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IcoTiposUsuarioController
    {
        // Preload our schema..
        IcoTiposUsuario thisSchemaLoad = new IcoTiposUsuario();
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
        public IcoTiposUsuarioCollection FetchAll()
        {
            IcoTiposUsuarioCollection coll = new IcoTiposUsuarioCollection();
            Query qry = new Query(IcoTiposUsuario.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoTiposUsuarioCollection FetchByID(object IdTipoUsuario)
        {
            IcoTiposUsuarioCollection coll = new IcoTiposUsuarioCollection().Where("idTipoUsuario", IdTipoUsuario).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoTiposUsuarioCollection FetchByQuery(Query qry)
        {
            IcoTiposUsuarioCollection coll = new IcoTiposUsuarioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoUsuario)
        {
            return (IcoTiposUsuario.Delete(IdTipoUsuario) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoUsuario)
        {
            return (IcoTiposUsuario.Destroy(IdTipoUsuario) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUsuario,string TipoUsuario)
	    {
		    IcoTiposUsuario item = new IcoTiposUsuario();
		    
            item.IdUsuario = IdUsuario;
            
            item.TipoUsuario = TipoUsuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoUsuario,int IdUsuario,string TipoUsuario)
	    {
		    IcoTiposUsuario item = new IcoTiposUsuario();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoUsuario = IdTipoUsuario;
				
			item.IdUsuario = IdUsuario;
				
			item.TipoUsuario = TipoUsuario;
				
	        item.Save(UserName);
	    }
    }
}
