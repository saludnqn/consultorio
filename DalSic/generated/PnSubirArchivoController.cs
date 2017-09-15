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
    /// Controller class for PN_subir_archivos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnSubirArchivoController
    {
        // Preload our schema..
        PnSubirArchivo thisSchemaLoad = new PnSubirArchivo();
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
        public PnSubirArchivoCollection FetchAll()
        {
            PnSubirArchivoCollection coll = new PnSubirArchivoCollection();
            Query qry = new Query(PnSubirArchivo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSubirArchivoCollection FetchByID(object Id)
        {
            PnSubirArchivoCollection coll = new PnSubirArchivoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSubirArchivoCollection FetchByQuery(Query qry)
        {
            PnSubirArchivoCollection coll = new PnSubirArchivoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PnSubirArchivo.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PnSubirArchivo.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Categoria,string Comentario,string Creadopor,string Size,DateTime Fecha,string Acceso,string IdDirectoriosArchivos)
	    {
		    PnSubirArchivo item = new PnSubirArchivo();
		    
            item.Nombre = Nombre;
            
            item.Categoria = Categoria;
            
            item.Comentario = Comentario;
            
            item.Creadopor = Creadopor;
            
            item.Size = Size;
            
            item.Fecha = Fecha;
            
            item.Acceso = Acceso;
            
            item.IdDirectoriosArchivos = IdDirectoriosArchivos;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre,string Categoria,string Comentario,string Creadopor,string Size,DateTime Fecha,string Acceso,string IdDirectoriosArchivos)
	    {
		    PnSubirArchivo item = new PnSubirArchivo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
			item.Categoria = Categoria;
				
			item.Comentario = Comentario;
				
			item.Creadopor = Creadopor;
				
			item.Size = Size;
				
			item.Fecha = Fecha;
				
			item.Acceso = Acceso;
				
			item.IdDirectoriosArchivos = IdDirectoriosArchivos;
				
	        item.Save(UserName);
	    }
    }
}
