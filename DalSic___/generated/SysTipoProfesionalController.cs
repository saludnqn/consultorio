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
    /// Controller class for Sys_TipoProfesional
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysTipoProfesionalController
    {
        // Preload our schema..
        SysTipoProfesional thisSchemaLoad = new SysTipoProfesional();
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
        public SysTipoProfesionalCollection FetchAll()
        {
            SysTipoProfesionalCollection coll = new SysTipoProfesionalCollection();
            Query qry = new Query(SysTipoProfesional.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysTipoProfesionalCollection FetchByID(object IdTipoProfesional)
        {
            SysTipoProfesionalCollection coll = new SysTipoProfesionalCollection().Where("idTipoProfesional", IdTipoProfesional).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysTipoProfesionalCollection FetchByQuery(Query qry)
        {
            SysTipoProfesionalCollection coll = new SysTipoProfesionalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoProfesional)
        {
            return (SysTipoProfesional.Delete(IdTipoProfesional) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoProfesional)
        {
            return (SysTipoProfesional.Destroy(IdTipoProfesional) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysTipoProfesional item = new SysTipoProfesional();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoProfesional,string Nombre)
	    {
		    SysTipoProfesional item = new SysTipoProfesional();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoProfesional = IdTipoProfesional;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
