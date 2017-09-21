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
    /// Controller class for PN_directorios_archivos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDirectoriosArchivoController
    {
        // Preload our schema..
        PnDirectoriosArchivo thisSchemaLoad = new PnDirectoriosArchivo();
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
        public PnDirectoriosArchivoCollection FetchAll()
        {
            PnDirectoriosArchivoCollection coll = new PnDirectoriosArchivoCollection();
            Query qry = new Query(PnDirectoriosArchivo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDirectoriosArchivoCollection FetchByID(object IdDirectoriosArchivosSerial)
        {
            PnDirectoriosArchivoCollection coll = new PnDirectoriosArchivoCollection().Where("id_directorios_archivos_serial", IdDirectoriosArchivosSerial).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDirectoriosArchivoCollection FetchByQuery(Query qry)
        {
            PnDirectoriosArchivoCollection coll = new PnDirectoriosArchivoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDirectoriosArchivosSerial)
        {
            return (PnDirectoriosArchivo.Delete(IdDirectoriosArchivosSerial) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDirectoriosArchivosSerial)
        {
            return (PnDirectoriosArchivo.Destroy(IdDirectoriosArchivosSerial) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string IdDirectoriosArchivos,string NombreNodo,string IdNodoPadre,string NombreNodoPadre,string Path)
	    {
		    PnDirectoriosArchivo item = new PnDirectoriosArchivo();
		    
            item.IdDirectoriosArchivos = IdDirectoriosArchivos;
            
            item.NombreNodo = NombreNodo;
            
            item.IdNodoPadre = IdNodoPadre;
            
            item.NombreNodoPadre = NombreNodoPadre;
            
            item.Path = Path;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDirectoriosArchivosSerial,string IdDirectoriosArchivos,string NombreNodo,string IdNodoPadre,string NombreNodoPadre,string Path)
	    {
		    PnDirectoriosArchivo item = new PnDirectoriosArchivo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDirectoriosArchivosSerial = IdDirectoriosArchivosSerial;
				
			item.IdDirectoriosArchivos = IdDirectoriosArchivos;
				
			item.NombreNodo = NombreNodo;
				
			item.IdNodoPadre = IdNodoPadre;
				
			item.NombreNodoPadre = NombreNodoPadre;
				
			item.Path = Path;
				
	        item.Save(UserName);
	    }
    }
}
