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
    /// Controller class for Sys_Zona
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysZonaController
    {
        // Preload our schema..
        SysZona thisSchemaLoad = new SysZona();
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
        public SysZonaCollection FetchAll()
        {
            SysZonaCollection coll = new SysZonaCollection();
            Query qry = new Query(SysZona.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysZonaCollection FetchByID(object IdZona)
        {
            SysZonaCollection coll = new SysZonaCollection().Where("idZona", IdZona).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysZonaCollection FetchByQuery(Query qry)
        {
            SysZonaCollection coll = new SysZonaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdZona)
        {
            return (SysZona.Delete(IdZona) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdZona)
        {
            return (SysZona.Destroy(IdZona) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdLocalidad,string Responsable,string Zona)
	    {
		    SysZona item = new SysZona();
		    
            item.Nombre = Nombre;
            
            item.IdLocalidad = IdLocalidad;
            
            item.Responsable = Responsable;
            
            item.Zona = Zona;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdZona,string Nombre,int IdLocalidad,string Responsable,string Zona)
	    {
		    SysZona item = new SysZona();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdZona = IdZona;
				
			item.Nombre = Nombre;
				
			item.IdLocalidad = IdLocalidad;
				
			item.Responsable = Responsable;
				
			item.Zona = Zona;
				
	        item.Save(UserName);
	    }
    }
}
