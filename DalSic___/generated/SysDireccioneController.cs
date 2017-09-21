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
    /// Controller class for Sys_Direcciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysDireccioneController
    {
        // Preload our schema..
        SysDireccione thisSchemaLoad = new SysDireccione();
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
        public SysDireccioneCollection FetchAll()
        {
            SysDireccioneCollection coll = new SysDireccioneCollection();
            Query qry = new Query(SysDireccione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysDireccioneCollection FetchByID(object IdDireccion)
        {
            SysDireccioneCollection coll = new SysDireccioneCollection().Where("idDireccion", IdDireccion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysDireccioneCollection FetchByQuery(Query qry)
        {
            SysDireccioneCollection coll = new SysDireccioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDireccion)
        {
            return (SysDireccione.Delete(IdDireccion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDireccion)
        {
            return (SysDireccione.Destroy(IdDireccion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Responsable,string Telefono,string Email)
	    {
		    SysDireccione item = new SysDireccione();
		    
            item.Nombre = Nombre;
            
            item.Responsable = Responsable;
            
            item.Telefono = Telefono;
            
            item.Email = Email;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(decimal IdDireccion,string Nombre,string Responsable,string Telefono,string Email)
	    {
		    SysDireccione item = new SysDireccione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDireccion = IdDireccion;
				
			item.Nombre = Nombre;
				
			item.Responsable = Responsable;
				
			item.Telefono = Telefono;
				
			item.Email = Email;
				
	        item.Save(UserName);
	    }
    }
}
