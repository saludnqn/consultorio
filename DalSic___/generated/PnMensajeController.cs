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
    /// Controller class for PN_mensajes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnMensajeController
    {
        // Preload our schema..
        PnMensaje thisSchemaLoad = new PnMensaje();
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
        public PnMensajeCollection FetchAll()
        {
            PnMensajeCollection coll = new PnMensajeCollection();
            Query qry = new Query(PnMensaje.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMensajeCollection FetchByID(object IdMensaje)
        {
            PnMensajeCollection coll = new PnMensajeCollection().Where("id_mensaje", IdMensaje).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMensajeCollection FetchByQuery(Query qry)
        {
            PnMensajeCollection coll = new PnMensajeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMensaje)
        {
            return (PnMensaje.Delete(IdMensaje) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMensaje)
        {
            return (PnMensaje.Destroy(IdMensaje) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Tipo1,string Tipo2,int? Numero,string UsuarioOrigen,string Comentario,string UsuarioDestino,DateTime? FechaEntrega,DateTime? FechaRecibo,DateTime? FechaVencimiento,DateTime? FechaTerminado,int? NroOrden,string Recibido,string Terminado,string Desestimado,string Titulo,string EstadoFinal,string UsuarioFinaliza)
	    {
		    PnMensaje item = new PnMensaje();
		    
            item.Tipo1 = Tipo1;
            
            item.Tipo2 = Tipo2;
            
            item.Numero = Numero;
            
            item.UsuarioOrigen = UsuarioOrigen;
            
            item.Comentario = Comentario;
            
            item.UsuarioDestino = UsuarioDestino;
            
            item.FechaEntrega = FechaEntrega;
            
            item.FechaRecibo = FechaRecibo;
            
            item.FechaVencimiento = FechaVencimiento;
            
            item.FechaTerminado = FechaTerminado;
            
            item.NroOrden = NroOrden;
            
            item.Recibido = Recibido;
            
            item.Terminado = Terminado;
            
            item.Desestimado = Desestimado;
            
            item.Titulo = Titulo;
            
            item.EstadoFinal = EstadoFinal;
            
            item.UsuarioFinaliza = UsuarioFinaliza;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMensaje,string Tipo1,string Tipo2,int? Numero,string UsuarioOrigen,string Comentario,string UsuarioDestino,DateTime? FechaEntrega,DateTime? FechaRecibo,DateTime? FechaVencimiento,DateTime? FechaTerminado,int? NroOrden,string Recibido,string Terminado,string Desestimado,string Titulo,string EstadoFinal,string UsuarioFinaliza)
	    {
		    PnMensaje item = new PnMensaje();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMensaje = IdMensaje;
				
			item.Tipo1 = Tipo1;
				
			item.Tipo2 = Tipo2;
				
			item.Numero = Numero;
				
			item.UsuarioOrigen = UsuarioOrigen;
				
			item.Comentario = Comentario;
				
			item.UsuarioDestino = UsuarioDestino;
				
			item.FechaEntrega = FechaEntrega;
				
			item.FechaRecibo = FechaRecibo;
				
			item.FechaVencimiento = FechaVencimiento;
				
			item.FechaTerminado = FechaTerminado;
				
			item.NroOrden = NroOrden;
				
			item.Recibido = Recibido;
				
			item.Terminado = Terminado;
				
			item.Desestimado = Desestimado;
				
			item.Titulo = Titulo;
				
			item.EstadoFinal = EstadoFinal;
				
			item.UsuarioFinaliza = UsuarioFinaliza;
				
	        item.Save(UserName);
	    }
    }
}
