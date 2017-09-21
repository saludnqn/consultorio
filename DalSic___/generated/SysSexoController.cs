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
    /// Controller class for Sys_Sexo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysSexoController
    {
        // Preload our schema..
        SysSexo thisSchemaLoad = new SysSexo();
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
        public SysSexoCollection FetchAll()
        {
            SysSexoCollection coll = new SysSexoCollection();
            Query qry = new Query(SysSexo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysSexoCollection FetchByID(object IdSexo)
        {
            SysSexoCollection coll = new SysSexoCollection().Where("idSexo", IdSexo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysSexoCollection FetchByQuery(Query qry)
        {
            SysSexoCollection coll = new SysSexoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSexo)
        {
            return (SysSexo.Delete(IdSexo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSexo)
        {
            return (SysSexo.Destroy(IdSexo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysSexo item = new SysSexo();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSexo,string Nombre)
	    {
		    SysSexo item = new SysSexo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSexo = IdSexo;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
