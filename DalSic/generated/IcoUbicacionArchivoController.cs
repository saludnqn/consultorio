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
    /// Controller class for ICO_UbicacionArchivos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IcoUbicacionArchivoController
    {
        // Preload our schema..
        IcoUbicacionArchivo thisSchemaLoad = new IcoUbicacionArchivo();
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
        public IcoUbicacionArchivoCollection FetchAll()
        {
            IcoUbicacionArchivoCollection coll = new IcoUbicacionArchivoCollection();
            Query qry = new Query(IcoUbicacionArchivo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoUbicacionArchivoCollection FetchByID(object IdUbicacionArchivo)
        {
            IcoUbicacionArchivoCollection coll = new IcoUbicacionArchivoCollection().Where("idUbicacionArchivo", IdUbicacionArchivo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoUbicacionArchivoCollection FetchByQuery(Query qry)
        {
            IcoUbicacionArchivoCollection coll = new IcoUbicacionArchivoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdUbicacionArchivo)
        {
            return (IcoUbicacionArchivo.Delete(IdUbicacionArchivo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdUbicacionArchivo)
        {
            return (IcoUbicacionArchivo.Destroy(IdUbicacionArchivo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdInterconsulta,string Nombre,string Ubicacion,string Detalle)
	    {
		    IcoUbicacionArchivo item = new IcoUbicacionArchivo();
		    
            item.IdInterconsulta = IdInterconsulta;
            
            item.Nombre = Nombre;
            
            item.Ubicacion = Ubicacion;
            
            item.Detalle = Detalle;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdUbicacionArchivo,int IdInterconsulta,string Nombre,string Ubicacion,string Detalle)
	    {
		    IcoUbicacionArchivo item = new IcoUbicacionArchivo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdUbicacionArchivo = IdUbicacionArchivo;
				
			item.IdInterconsulta = IdInterconsulta;
				
			item.Nombre = Nombre;
				
			item.Ubicacion = Ubicacion;
				
			item.Detalle = Detalle;
				
	        item.Save(UserName);
	    }
    }
}
