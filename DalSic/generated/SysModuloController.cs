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
    /// Controller class for Sys_Modulo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysModuloController
    {
        // Preload our schema..
        SysModulo thisSchemaLoad = new SysModulo();
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
        public SysModuloCollection FetchAll()
        {
            SysModuloCollection coll = new SysModuloCollection();
            Query qry = new Query(SysModulo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysModuloCollection FetchByID(object IdModulo)
        {
            SysModuloCollection coll = new SysModuloCollection().Where("idModulo", IdModulo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysModuloCollection FetchByQuery(Query qry)
        {
            SysModuloCollection coll = new SysModuloCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdModulo)
        {
            return (SysModulo.Delete(IdModulo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdModulo)
        {
            return (SysModulo.Destroy(IdModulo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Url,string Icono,string Descripcion,int Orden)
	    {
		    SysModulo item = new SysModulo();
		    
            item.Nombre = Nombre;
            
            item.Url = Url;
            
            item.Icono = Icono;
            
            item.Descripcion = Descripcion;
            
            item.Orden = Orden;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdModulo,string Nombre,string Url,string Icono,string Descripcion,int Orden)
	    {
		    SysModulo item = new SysModulo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdModulo = IdModulo;
				
			item.Nombre = Nombre;
				
			item.Url = Url;
				
			item.Icono = Icono;
				
			item.Descripcion = Descripcion;
				
			item.Orden = Orden;
				
	        item.Save(UserName);
	    }
    }
}
