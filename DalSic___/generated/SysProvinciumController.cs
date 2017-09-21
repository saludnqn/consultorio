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
    /// Controller class for Sys_Provincia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysProvinciumController
    {
        // Preload our schema..
        SysProvincium thisSchemaLoad = new SysProvincium();
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
        public SysProvinciumCollection FetchAll()
        {
            SysProvinciumCollection coll = new SysProvinciumCollection();
            Query qry = new Query(SysProvincium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysProvinciumCollection FetchByID(object IdProvincia)
        {
            SysProvinciumCollection coll = new SysProvinciumCollection().Where("idProvincia", IdProvincia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysProvinciumCollection FetchByQuery(Query qry)
        {
            SysProvinciumCollection coll = new SysProvinciumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProvincia)
        {
            return (SysProvincium.Delete(IdProvincia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProvincia)
        {
            return (SysProvincium.Destroy(IdProvincia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdPais,string CodigoINDEC)
	    {
		    SysProvincium item = new SysProvincium();
		    
            item.Nombre = Nombre;
            
            item.IdPais = IdPais;
            
            item.CodigoINDEC = CodigoINDEC;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProvincia,string Nombre,int IdPais,string CodigoINDEC)
	    {
		    SysProvincium item = new SysProvincium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProvincia = IdProvincia;
				
			item.Nombre = Nombre;
				
			item.IdPais = IdPais;
				
			item.CodigoINDEC = CodigoINDEC;
				
	        item.Save(UserName);
	    }
    }
}
