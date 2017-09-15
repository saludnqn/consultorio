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
    /// Controller class for MAM_TipoEstudio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamTipoEstudioController
    {
        // Preload our schema..
        MamTipoEstudio thisSchemaLoad = new MamTipoEstudio();
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
        public MamTipoEstudioCollection FetchAll()
        {
            MamTipoEstudioCollection coll = new MamTipoEstudioCollection();
            Query qry = new Query(MamTipoEstudio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTipoEstudioCollection FetchByID(object IdTipoEstudio)
        {
            MamTipoEstudioCollection coll = new MamTipoEstudioCollection().Where("idTipoEstudio", IdTipoEstudio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTipoEstudioCollection FetchByQuery(Query qry)
        {
            MamTipoEstudioCollection coll = new MamTipoEstudioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoEstudio)
        {
            return (MamTipoEstudio.Delete(IdTipoEstudio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoEstudio)
        {
            return (MamTipoEstudio.Destroy(IdTipoEstudio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int? IdSitam)
	    {
		    MamTipoEstudio item = new MamTipoEstudio();
		    
            item.Nombre = Nombre;
            
            item.IdSitam = IdSitam;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoEstudio,string Nombre,int? IdSitam)
	    {
		    MamTipoEstudio item = new MamTipoEstudio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoEstudio = IdTipoEstudio;
				
			item.Nombre = Nombre;
				
			item.IdSitam = IdSitam;
				
	        item.Save(UserName);
	    }
    }
}
