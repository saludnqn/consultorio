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
    /// Controller class for Sys_Ocupacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysOcupacionController
    {
        // Preload our schema..
        SysOcupacion thisSchemaLoad = new SysOcupacion();
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
        public SysOcupacionCollection FetchAll()
        {
            SysOcupacionCollection coll = new SysOcupacionCollection();
            Query qry = new Query(SysOcupacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysOcupacionCollection FetchByID(object IdOcupacion)
        {
            SysOcupacionCollection coll = new SysOcupacionCollection().Where("idOcupacion", IdOcupacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysOcupacionCollection FetchByQuery(Query qry)
        {
            SysOcupacionCollection coll = new SysOcupacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdOcupacion)
        {
            return (SysOcupacion.Delete(IdOcupacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdOcupacion)
        {
            return (SysOcupacion.Destroy(IdOcupacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Codigo,bool Activo)
	    {
		    SysOcupacion item = new SysOcupacion();
		    
            item.Nombre = Nombre;
            
            item.Codigo = Codigo;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdOcupacion,string Nombre,string Codigo,bool Activo)
	    {
		    SysOcupacion item = new SysOcupacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdOcupacion = IdOcupacion;
				
			item.Nombre = Nombre;
				
			item.Codigo = Codigo;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
