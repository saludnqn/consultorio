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
    /// Controller class for Sys_NivelInstruccion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysNivelInstruccionController
    {
        // Preload our schema..
        SysNivelInstruccion thisSchemaLoad = new SysNivelInstruccion();
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
        public SysNivelInstruccionCollection FetchAll()
        {
            SysNivelInstruccionCollection coll = new SysNivelInstruccionCollection();
            Query qry = new Query(SysNivelInstruccion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysNivelInstruccionCollection FetchByID(object IdNivelInstruccion)
        {
            SysNivelInstruccionCollection coll = new SysNivelInstruccionCollection().Where("idNivelInstruccion", IdNivelInstruccion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysNivelInstruccionCollection FetchByQuery(Query qry)
        {
            SysNivelInstruccionCollection coll = new SysNivelInstruccionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNivelInstruccion)
        {
            return (SysNivelInstruccion.Delete(IdNivelInstruccion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNivelInstruccion)
        {
            return (SysNivelInstruccion.Destroy(IdNivelInstruccion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysNivelInstruccion item = new SysNivelInstruccion();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNivelInstruccion,string Nombre)
	    {
		    SysNivelInstruccion item = new SysNivelInstruccion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNivelInstruccion = IdNivelInstruccion;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
