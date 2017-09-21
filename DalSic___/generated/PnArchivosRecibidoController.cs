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
    /// Controller class for PN_archivos_recibidos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnArchivosRecibidoController
    {
        // Preload our schema..
        PnArchivosRecibido thisSchemaLoad = new PnArchivosRecibido();
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
        public PnArchivosRecibidoCollection FetchAll()
        {
            PnArchivosRecibidoCollection coll = new PnArchivosRecibidoCollection();
            Query qry = new Query(PnArchivosRecibido.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivosRecibidoCollection FetchByID(object IdArchivosRecibidos)
        {
            PnArchivosRecibidoCollection coll = new PnArchivosRecibidoCollection().Where("id_archivos_recibidos", IdArchivosRecibidos).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivosRecibidoCollection FetchByQuery(Query qry)
        {
            PnArchivosRecibidoCollection coll = new PnArchivosRecibidoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdArchivosRecibidos)
        {
            return (PnArchivosRecibido.Delete(IdArchivosRecibidos) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdArchivosRecibidos)
        {
            return (PnArchivosRecibido.Destroy(IdArchivosRecibidos) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdArchivosEnviados,DateTime? FechaRecepcion,string Estado,string Usuario,string NombreArchivo)
	    {
		    PnArchivosRecibido item = new PnArchivosRecibido();
		    
            item.IdArchivosEnviados = IdArchivosEnviados;
            
            item.FechaRecepcion = FechaRecepcion;
            
            item.Estado = Estado;
            
            item.Usuario = Usuario;
            
            item.NombreArchivo = NombreArchivo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdArchivosRecibidos,int IdArchivosEnviados,DateTime? FechaRecepcion,string Estado,string Usuario,string NombreArchivo)
	    {
		    PnArchivosRecibido item = new PnArchivosRecibido();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdArchivosRecibidos = IdArchivosRecibidos;
				
			item.IdArchivosEnviados = IdArchivosEnviados;
				
			item.FechaRecepcion = FechaRecepcion;
				
			item.Estado = Estado;
				
			item.Usuario = Usuario;
				
			item.NombreArchivo = NombreArchivo;
				
	        item.Save(UserName);
	    }
    }
}
