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
    /// Controller class for Sys_Servicio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysServicioController
    {
        // Preload our schema..
        SysServicio thisSchemaLoad = new SysServicio();
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
        public SysServicioCollection FetchAll()
        {
            SysServicioCollection coll = new SysServicioCollection();
            Query qry = new Query(SysServicio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysServicioCollection FetchByID(object IdServicio)
        {
            SysServicioCollection coll = new SysServicioCollection().Where("idServicio", IdServicio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysServicioCollection FetchByQuery(Query qry)
        {
            SysServicioCollection coll = new SysServicioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdServicio)
        {
            return (SysServicio.Delete(IdServicio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdServicio)
        {
            return (SysServicio.Destroy(IdServicio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string UnidadOperativa,bool Activo)
	    {
		    SysServicio item = new SysServicio();
		    
            item.Nombre = Nombre;
            
            item.UnidadOperativa = UnidadOperativa;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdServicio,string Nombre,string UnidadOperativa,bool Activo)
	    {
		    SysServicio item = new SysServicio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdServicio = IdServicio;
				
			item.Nombre = Nombre;
				
			item.UnidadOperativa = UnidadOperativa;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
