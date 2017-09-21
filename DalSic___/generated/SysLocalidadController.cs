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
    /// Controller class for Sys_Localidad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysLocalidadController
    {
        // Preload our schema..
        SysLocalidad thisSchemaLoad = new SysLocalidad();
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
        public SysLocalidadCollection FetchAll()
        {
            SysLocalidadCollection coll = new SysLocalidadCollection();
            Query qry = new Query(SysLocalidad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysLocalidadCollection FetchByID(object IdLocalidad)
        {
            SysLocalidadCollection coll = new SysLocalidadCollection().Where("idLocalidad", IdLocalidad).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysLocalidadCollection FetchByQuery(Query qry)
        {
            SysLocalidadCollection coll = new SysLocalidadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLocalidad)
        {
            return (SysLocalidad.Delete(IdLocalidad) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLocalidad)
        {
            return (SysLocalidad.Destroy(IdLocalidad) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string CodigoPostal,int? IdDepartamento,string CodigoINDEC)
	    {
		    SysLocalidad item = new SysLocalidad();
		    
            item.Nombre = Nombre;
            
            item.CodigoPostal = CodigoPostal;
            
            item.IdDepartamento = IdDepartamento;
            
            item.CodigoINDEC = CodigoINDEC;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLocalidad,string Nombre,string CodigoPostal,int? IdDepartamento,string CodigoINDEC)
	    {
		    SysLocalidad item = new SysLocalidad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLocalidad = IdLocalidad;
				
			item.Nombre = Nombre;
				
			item.CodigoPostal = CodigoPostal;
				
			item.IdDepartamento = IdDepartamento;
				
			item.CodigoINDEC = CodigoINDEC;
				
	        item.Save(UserName);
	    }
    }
}
