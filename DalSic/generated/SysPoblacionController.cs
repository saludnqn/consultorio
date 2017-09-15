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
    /// Controller class for Sys_Poblacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysPoblacionController
    {
        // Preload our schema..
        SysPoblacion thisSchemaLoad = new SysPoblacion();
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
        public SysPoblacionCollection FetchAll()
        {
            SysPoblacionCollection coll = new SysPoblacionCollection();
            Query qry = new Query(SysPoblacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPoblacionCollection FetchByID(object IdPoblacion)
        {
            SysPoblacionCollection coll = new SysPoblacionCollection().Where("idPoblacion", IdPoblacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPoblacionCollection FetchByQuery(Query qry)
        {
            SysPoblacionCollection coll = new SysPoblacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPoblacion)
        {
            return (SysPoblacion.Delete(IdPoblacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPoblacion)
        {
            return (SysPoblacion.Destroy(IdPoblacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysPoblacion item = new SysPoblacion();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPoblacion,string Nombre)
	    {
		    SysPoblacion item = new SysPoblacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPoblacion = IdPoblacion;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
