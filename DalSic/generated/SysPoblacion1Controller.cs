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
    /// Controller class for Sys_Poblacion1
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysPoblacion1Controller
    {
        // Preload our schema..
        SysPoblacion1 thisSchemaLoad = new SysPoblacion1();
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
        public SysPoblacion1Collection FetchAll()
        {
            SysPoblacion1Collection coll = new SysPoblacion1Collection();
            Query qry = new Query(SysPoblacion1.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPoblacion1Collection FetchByID(object IdPoblacion)
        {
            SysPoblacion1Collection coll = new SysPoblacion1Collection().Where("idPoblacion", IdPoblacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPoblacion1Collection FetchByQuery(Query qry)
        {
            SysPoblacion1Collection coll = new SysPoblacion1Collection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPoblacion)
        {
            return (SysPoblacion1.Delete(IdPoblacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPoblacion)
        {
            return (SysPoblacion1.Destroy(IdPoblacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdLocalidad,string Localidad,string Sexo,int? Edad,int? Año,int? Habitantes,int? Zona,string Departamentos)
	    {
		    SysPoblacion1 item = new SysPoblacion1();
		    
            item.IdLocalidad = IdLocalidad;
            
            item.Localidad = Localidad;
            
            item.Sexo = Sexo;
            
            item.Edad = Edad;
            
            item.Año = Año;
            
            item.Habitantes = Habitantes;
            
            item.Zona = Zona;
            
            item.Departamentos = Departamentos;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPoblacion,int? IdLocalidad,string Localidad,string Sexo,int? Edad,int? Año,int? Habitantes,int? Zona,string Departamentos)
	    {
		    SysPoblacion1 item = new SysPoblacion1();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPoblacion = IdPoblacion;
				
			item.IdLocalidad = IdLocalidad;
				
			item.Localidad = Localidad;
				
			item.Sexo = Sexo;
				
			item.Edad = Edad;
				
			item.Año = Año;
				
			item.Habitantes = Habitantes;
				
			item.Zona = Zona;
				
			item.Departamentos = Departamentos;
				
	        item.Save(UserName);
	    }
    }
}
