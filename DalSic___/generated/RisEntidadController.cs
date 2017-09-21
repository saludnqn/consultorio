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
    /// Controller class for RIS_Entidad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEntidadController
    {
        // Preload our schema..
        RisEntidad thisSchemaLoad = new RisEntidad();
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
        public RisEntidadCollection FetchAll()
        {
            RisEntidadCollection coll = new RisEntidadCollection();
            Query qry = new Query(RisEntidad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEntidadCollection FetchByID(object IdEntidad)
        {
            RisEntidadCollection coll = new RisEntidadCollection().Where("idEntidad", IdEntidad).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEntidadCollection FetchByQuery(Query qry)
        {
            RisEntidadCollection coll = new RisEntidadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEntidad)
        {
            return (RisEntidad.Delete(IdEntidad) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEntidad)
        {
            return (RisEntidad.Destroy(IdEntidad) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Caracter,string Domicilio,string Email,string Tipo,string TipoEntidad,string Caracteristicas)
	    {
		    RisEntidad item = new RisEntidad();
		    
            item.Nombre = Nombre;
            
            item.Caracter = Caracter;
            
            item.Domicilio = Domicilio;
            
            item.Email = Email;
            
            item.Tipo = Tipo;
            
            item.TipoEntidad = TipoEntidad;
            
            item.Caracteristicas = Caracteristicas;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEntidad,string Nombre,string Caracter,string Domicilio,string Email,string Tipo,string TipoEntidad,string Caracteristicas)
	    {
		    RisEntidad item = new RisEntidad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEntidad = IdEntidad;
				
			item.Nombre = Nombre;
				
			item.Caracter = Caracter;
				
			item.Domicilio = Domicilio;
				
			item.Email = Email;
				
			item.Tipo = Tipo;
				
			item.TipoEntidad = TipoEntidad;
				
			item.Caracteristicas = Caracteristicas;
				
	        item.Save(UserName);
	    }
    }
}
