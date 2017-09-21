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
    /// Controller class for Sys_Usuario
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysUsuarioController
    {
        // Preload our schema..
        SysUsuario thisSchemaLoad = new SysUsuario();
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
        public SysUsuarioCollection FetchAll()
        {
            SysUsuarioCollection coll = new SysUsuarioCollection();
            Query qry = new Query(SysUsuario.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysUsuarioCollection FetchByID(object IdUsuario)
        {
            SysUsuarioCollection coll = new SysUsuarioCollection().Where("idUsuario", IdUsuario).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysUsuarioCollection FetchByQuery(Query qry)
        {
            SysUsuarioCollection coll = new SysUsuarioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdUsuario)
        {
            return (SysUsuario.Delete(IdUsuario) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdUsuario)
        {
            return (SysUsuario.Destroy(IdUsuario) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPerfil,int Documento,string Apellido,string Nombre,string Legajo,string Email,string Telefono,string Observacion,string Username,string Password,bool Activo,int IdUsuarioActualizacion,DateTime FechaActualizacion)
	    {
		    SysUsuario item = new SysUsuario();
		    
            item.IdEfector = IdEfector;
            
            item.IdPerfil = IdPerfil;
            
            item.Documento = Documento;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.Legajo = Legajo;
            
            item.Email = Email;
            
            item.Telefono = Telefono;
            
            item.Observacion = Observacion;
            
            item.Username = Username;
            
            item.Password = Password;
            
            item.Activo = Activo;
            
            item.IdUsuarioActualizacion = IdUsuarioActualizacion;
            
            item.FechaActualizacion = FechaActualizacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdUsuario,int IdEfector,int IdPerfil,int Documento,string Apellido,string Nombre,string Legajo,string Email,string Telefono,string Observacion,string Username,string Password,bool Activo,int IdUsuarioActualizacion,DateTime FechaActualizacion)
	    {
		    SysUsuario item = new SysUsuario();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdUsuario = IdUsuario;
				
			item.IdEfector = IdEfector;
				
			item.IdPerfil = IdPerfil;
				
			item.Documento = Documento;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.Legajo = Legajo;
				
			item.Email = Email;
				
			item.Telefono = Telefono;
				
			item.Observacion = Observacion;
				
			item.Username = Username;
				
			item.Password = Password;
				
			item.Activo = Activo;
				
			item.IdUsuarioActualizacion = IdUsuarioActualizacion;
				
			item.FechaActualizacion = FechaActualizacion;
				
	        item.Save(UserName);
	    }
    }
}
