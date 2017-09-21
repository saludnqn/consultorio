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
    /// Controller class for PN_grupos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnGrupoController
    {
        // Preload our schema..
        PnGrupo thisSchemaLoad = new PnGrupo();
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
        public PnGrupoCollection FetchAll()
        {
            PnGrupoCollection coll = new PnGrupoCollection();
            Query qry = new Query(PnGrupo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnGrupoCollection FetchByID(object IdGrupo)
        {
            PnGrupoCollection coll = new PnGrupoCollection().Where("id_grupo", IdGrupo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnGrupoCollection FetchByQuery(Query qry)
        {
            PnGrupoCollection coll = new PnGrupoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdGrupo)
        {
            return (PnGrupo.Delete(IdGrupo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdGrupo)
        {
            return (PnGrupo.Destroy(IdGrupo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Uname)
	    {
		    PnGrupo item = new PnGrupo();
		    
            item.Uname = Uname;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdGrupo,string Uname)
	    {
		    PnGrupo item = new PnGrupo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdGrupo = IdGrupo;
				
			item.Uname = Uname;
				
	        item.Save(UserName);
	    }
    }
}
