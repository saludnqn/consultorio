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
    /// Controller class for Guardia_Mensajes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaMensajeController
    {
        // Preload our schema..
        GuardiaMensaje thisSchemaLoad = new GuardiaMensaje();
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
        public GuardiaMensajeCollection FetchAll()
        {
            GuardiaMensajeCollection coll = new GuardiaMensajeCollection();
            Query qry = new Query(GuardiaMensaje.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaMensajeCollection FetchByID(object Id)
        {
            GuardiaMensajeCollection coll = new GuardiaMensajeCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaMensajeCollection FetchByQuery(Query qry)
        {
            GuardiaMensajeCollection coll = new GuardiaMensajeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaMensaje.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaMensaje.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdUserSend,int? IdUserReceive,int? IdVistaReceive,int IdTipo,string Data,bool? Readed,DateTime Fecha,int? IdUserReaded,DateTime? FechaReaded)
	    {
		    GuardiaMensaje item = new GuardiaMensaje();
		    
            item.IdUserSend = IdUserSend;
            
            item.IdUserReceive = IdUserReceive;
            
            item.IdVistaReceive = IdVistaReceive;
            
            item.IdTipo = IdTipo;
            
            item.Data = Data;
            
            item.Readed = Readed;
            
            item.Fecha = Fecha;
            
            item.IdUserReaded = IdUserReaded;
            
            item.FechaReaded = FechaReaded;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdUserSend,int? IdUserReceive,int? IdVistaReceive,int IdTipo,string Data,bool? Readed,DateTime Fecha,int? IdUserReaded,DateTime? FechaReaded)
	    {
		    GuardiaMensaje item = new GuardiaMensaje();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdUserSend = IdUserSend;
				
			item.IdUserReceive = IdUserReceive;
				
			item.IdVistaReceive = IdVistaReceive;
				
			item.IdTipo = IdTipo;
				
			item.Data = Data;
				
			item.Readed = Readed;
				
			item.Fecha = Fecha;
				
			item.IdUserReaded = IdUserReaded;
				
			item.FechaReaded = FechaReaded;
				
	        item.Save(UserName);
	    }
    }
}
