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
    /// Controller class for Sys_Menu
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysMenuController
    {
        // Preload our schema..
        SysMenu thisSchemaLoad = new SysMenu();
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
        public SysMenuCollection FetchAll()
        {
            SysMenuCollection coll = new SysMenuCollection();
            Query qry = new Query(SysMenu.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMenuCollection FetchByID(object IdMenu)
        {
            SysMenuCollection coll = new SysMenuCollection().Where("idMenu", IdMenu).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMenuCollection FetchByQuery(Query qry)
        {
            SysMenuCollection coll = new SysMenuCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMenu)
        {
            return (SysMenu.Delete(IdMenu) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMenu)
        {
            return (SysMenu.Destroy(IdMenu) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Objeto,int IdMenuSuperior,int Posicion,string Icono,bool Habilitado,string Url,DateTime FechaCreacion,int IdUsuarioCreacion,DateTime FechaModificacion,int IdUsuarioModificacion,int IdModulo,bool? EsAccion)
	    {
		    SysMenu item = new SysMenu();
		    
            item.Objeto = Objeto;
            
            item.IdMenuSuperior = IdMenuSuperior;
            
            item.Posicion = Posicion;
            
            item.Icono = Icono;
            
            item.Habilitado = Habilitado;
            
            item.Url = Url;
            
            item.FechaCreacion = FechaCreacion;
            
            item.IdUsuarioCreacion = IdUsuarioCreacion;
            
            item.FechaModificacion = FechaModificacion;
            
            item.IdUsuarioModificacion = IdUsuarioModificacion;
            
            item.IdModulo = IdModulo;
            
            item.EsAccion = EsAccion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMenu,string Objeto,int IdMenuSuperior,int Posicion,string Icono,bool Habilitado,string Url,DateTime FechaCreacion,int IdUsuarioCreacion,DateTime FechaModificacion,int IdUsuarioModificacion,int IdModulo,bool? EsAccion)
	    {
		    SysMenu item = new SysMenu();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMenu = IdMenu;
				
			item.Objeto = Objeto;
				
			item.IdMenuSuperior = IdMenuSuperior;
				
			item.Posicion = Posicion;
				
			item.Icono = Icono;
				
			item.Habilitado = Habilitado;
				
			item.Url = Url;
				
			item.FechaCreacion = FechaCreacion;
				
			item.IdUsuarioCreacion = IdUsuarioCreacion;
				
			item.FechaModificacion = FechaModificacion;
				
			item.IdUsuarioModificacion = IdUsuarioModificacion;
				
			item.IdModulo = IdModulo;
				
			item.EsAccion = EsAccion;
				
	        item.Save(UserName);
	    }
    }
}
