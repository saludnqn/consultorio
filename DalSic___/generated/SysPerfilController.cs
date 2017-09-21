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
    /// Controller class for Sys_Perfil
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysPerfilController
    {
        // Preload our schema..
        SysPerfil thisSchemaLoad = new SysPerfil();
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
        public SysPerfilCollection FetchAll()
        {
            SysPerfilCollection coll = new SysPerfilCollection();
            Query qry = new Query(SysPerfil.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPerfilCollection FetchByID(object IdPerfil)
        {
            SysPerfilCollection coll = new SysPerfilCollection().Where("idPerfil", IdPerfil).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPerfilCollection FetchByQuery(Query qry)
        {
            SysPerfilCollection coll = new SysPerfilCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPerfil)
        {
            return (SysPerfil.Delete(IdPerfil) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPerfil)
        {
            return (SysPerfil.Destroy(IdPerfil) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,string Nombre,bool Activo,int IdUsuario,DateTime FechaActualizacion)
	    {
		    SysPerfil item = new SysPerfil();
		    
            item.IdEfector = IdEfector;
            
            item.Nombre = Nombre;
            
            item.Activo = Activo;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaActualizacion = FechaActualizacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPerfil,int IdEfector,string Nombre,bool Activo,int IdUsuario,DateTime FechaActualizacion)
	    {
		    SysPerfil item = new SysPerfil();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPerfil = IdPerfil;
				
			item.IdEfector = IdEfector;
				
			item.Nombre = Nombre;
				
			item.Activo = Activo;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaActualizacion = FechaActualizacion;
				
	        item.Save(UserName);
	    }
    }
}
