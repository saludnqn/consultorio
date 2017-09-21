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
    /// Controller class for PN_archivos_enviados
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnArchivosEnviadoController
    {
        // Preload our schema..
        PnArchivosEnviado thisSchemaLoad = new PnArchivosEnviado();
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
        public PnArchivosEnviadoCollection FetchAll()
        {
            PnArchivosEnviadoCollection coll = new PnArchivosEnviadoCollection();
            Query qry = new Query(PnArchivosEnviado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivosEnviadoCollection FetchByID(object IdArchivosEnviados)
        {
            PnArchivosEnviadoCollection coll = new PnArchivosEnviadoCollection().Where("id_archivos_enviados", IdArchivosEnviados).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnArchivosEnviadoCollection FetchByQuery(Query qry)
        {
            PnArchivosEnviadoCollection coll = new PnArchivosEnviadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdArchivosEnviados)
        {
            return (PnArchivosEnviado.Delete(IdArchivosEnviados) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdArchivosEnviados)
        {
            return (PnArchivosEnviado.Destroy(IdArchivosEnviados) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime? FechaGeneracion,string Estado,string Usuario,string NombreArchivoEnviado,int? CantidadRegistrosEnviados,string IdComienzoLote,DateTime? FechaRecepcionRespuesta)
	    {
		    PnArchivosEnviado item = new PnArchivosEnviado();
		    
            item.FechaGeneracion = FechaGeneracion;
            
            item.Estado = Estado;
            
            item.Usuario = Usuario;
            
            item.NombreArchivoEnviado = NombreArchivoEnviado;
            
            item.CantidadRegistrosEnviados = CantidadRegistrosEnviados;
            
            item.IdComienzoLote = IdComienzoLote;
            
            item.FechaRecepcionRespuesta = FechaRecepcionRespuesta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdArchivosEnviados,DateTime? FechaGeneracion,string Estado,string Usuario,string NombreArchivoEnviado,int? CantidadRegistrosEnviados,string IdComienzoLote,DateTime? FechaRecepcionRespuesta)
	    {
		    PnArchivosEnviado item = new PnArchivosEnviado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdArchivosEnviados = IdArchivosEnviados;
				
			item.FechaGeneracion = FechaGeneracion;
				
			item.Estado = Estado;
				
			item.Usuario = Usuario;
				
			item.NombreArchivoEnviado = NombreArchivoEnviado;
				
			item.CantidadRegistrosEnviados = CantidadRegistrosEnviados;
				
			item.IdComienzoLote = IdComienzoLote;
				
			item.FechaRecepcionRespuesta = FechaRecepcionRespuesta;
				
	        item.Save(UserName);
	    }
    }
}
