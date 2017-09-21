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
    /// Controller class for PN_usuarios
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnUsuarioController
    {
        // Preload our schema..
        PnUsuario thisSchemaLoad = new PnUsuario();
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
        public PnUsuarioCollection FetchAll()
        {
            PnUsuarioCollection coll = new PnUsuarioCollection();
            Query qry = new Query(PnUsuario.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnUsuarioCollection FetchByID(object IdUsuario)
        {
            PnUsuarioCollection coll = new PnUsuarioCollection().Where("id_usuario", IdUsuario).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnUsuarioCollection FetchByQuery(Query qry)
        {
            PnUsuarioCollection coll = new PnUsuarioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdUsuario)
        {
            return (PnUsuario.Delete(IdUsuario) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdUsuario)
        {
            return (PnUsuario.Destroy(IdUsuario) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Login,string Passwd,string Nombre,string Apellido,string Direccion,string Telefono,string Celular,string Mail,DateTime? FechaAlta,string Comentarios,string PaginaInicio,string Firma1,string Firma2,string Firma3,string Acceso1,string Acceso2,string Acceso3,string Acceso4,string Acceso5,string Acceso6,short? AvisarOc,short? IdLugarPedidoComida,string Acceso7,string Acceso8,string Acceso9,string Acceso10,string Acceso11,string Acceso12,string TipoLic,string Iniciales,short? PciaUbicacion,string NroTarjeta,short? VersionTarjeta,short? Visible,short? AccesoRemoto,byte[] Foto,byte[] Huella,byte[] Huella1,byte[] Huella2,byte[] Huella3)
	    {
		    PnUsuario item = new PnUsuario();
		    
            item.Login = Login;
            
            item.Passwd = Passwd;
            
            item.Nombre = Nombre;
            
            item.Apellido = Apellido;
            
            item.Direccion = Direccion;
            
            item.Telefono = Telefono;
            
            item.Celular = Celular;
            
            item.Mail = Mail;
            
            item.FechaAlta = FechaAlta;
            
            item.Comentarios = Comentarios;
            
            item.PaginaInicio = PaginaInicio;
            
            item.Firma1 = Firma1;
            
            item.Firma2 = Firma2;
            
            item.Firma3 = Firma3;
            
            item.Acceso1 = Acceso1;
            
            item.Acceso2 = Acceso2;
            
            item.Acceso3 = Acceso3;
            
            item.Acceso4 = Acceso4;
            
            item.Acceso5 = Acceso5;
            
            item.Acceso6 = Acceso6;
            
            item.AvisarOc = AvisarOc;
            
            item.IdLugarPedidoComida = IdLugarPedidoComida;
            
            item.Acceso7 = Acceso7;
            
            item.Acceso8 = Acceso8;
            
            item.Acceso9 = Acceso9;
            
            item.Acceso10 = Acceso10;
            
            item.Acceso11 = Acceso11;
            
            item.Acceso12 = Acceso12;
            
            item.TipoLic = TipoLic;
            
            item.Iniciales = Iniciales;
            
            item.PciaUbicacion = PciaUbicacion;
            
            item.NroTarjeta = NroTarjeta;
            
            item.VersionTarjeta = VersionTarjeta;
            
            item.Visible = Visible;
            
            item.AccesoRemoto = AccesoRemoto;
            
            item.Foto = Foto;
            
            item.Huella = Huella;
            
            item.Huella1 = Huella1;
            
            item.Huella2 = Huella2;
            
            item.Huella3 = Huella3;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdUsuario,string Login,string Passwd,string Nombre,string Apellido,string Direccion,string Telefono,string Celular,string Mail,DateTime? FechaAlta,string Comentarios,string PaginaInicio,string Firma1,string Firma2,string Firma3,string Acceso1,string Acceso2,string Acceso3,string Acceso4,string Acceso5,string Acceso6,short? AvisarOc,short? IdLugarPedidoComida,string Acceso7,string Acceso8,string Acceso9,string Acceso10,string Acceso11,string Acceso12,string TipoLic,string Iniciales,short? PciaUbicacion,string NroTarjeta,short? VersionTarjeta,short? Visible,short? AccesoRemoto,byte[] Foto,byte[] Huella,byte[] Huella1,byte[] Huella2,byte[] Huella3)
	    {
		    PnUsuario item = new PnUsuario();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdUsuario = IdUsuario;
				
			item.Login = Login;
				
			item.Passwd = Passwd;
				
			item.Nombre = Nombre;
				
			item.Apellido = Apellido;
				
			item.Direccion = Direccion;
				
			item.Telefono = Telefono;
				
			item.Celular = Celular;
				
			item.Mail = Mail;
				
			item.FechaAlta = FechaAlta;
				
			item.Comentarios = Comentarios;
				
			item.PaginaInicio = PaginaInicio;
				
			item.Firma1 = Firma1;
				
			item.Firma2 = Firma2;
				
			item.Firma3 = Firma3;
				
			item.Acceso1 = Acceso1;
				
			item.Acceso2 = Acceso2;
				
			item.Acceso3 = Acceso3;
				
			item.Acceso4 = Acceso4;
				
			item.Acceso5 = Acceso5;
				
			item.Acceso6 = Acceso6;
				
			item.AvisarOc = AvisarOc;
				
			item.IdLugarPedidoComida = IdLugarPedidoComida;
				
			item.Acceso7 = Acceso7;
				
			item.Acceso8 = Acceso8;
				
			item.Acceso9 = Acceso9;
				
			item.Acceso10 = Acceso10;
				
			item.Acceso11 = Acceso11;
				
			item.Acceso12 = Acceso12;
				
			item.TipoLic = TipoLic;
				
			item.Iniciales = Iniciales;
				
			item.PciaUbicacion = PciaUbicacion;
				
			item.NroTarjeta = NroTarjeta;
				
			item.VersionTarjeta = VersionTarjeta;
				
			item.Visible = Visible;
				
			item.AccesoRemoto = AccesoRemoto;
				
			item.Foto = Foto;
				
			item.Huella = Huella;
				
			item.Huella1 = Huella1;
				
			item.Huella2 = Huella2;
				
			item.Huella3 = Huella3;
				
	        item.Save(UserName);
	    }
    }
}
