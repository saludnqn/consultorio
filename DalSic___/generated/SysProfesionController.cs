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
    /// Controller class for Sys_Profesion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysProfesionController
    {
        // Preload our schema..
        SysProfesion thisSchemaLoad = new SysProfesion();
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
        public SysProfesionCollection FetchAll()
        {
            SysProfesionCollection coll = new SysProfesionCollection();
            Query qry = new Query(SysProfesion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysProfesionCollection FetchByID(object IdProfesion)
        {
            SysProfesionCollection coll = new SysProfesionCollection().Where("idProfesion", IdProfesion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysProfesionCollection FetchByQuery(Query qry)
        {
            SysProfesionCollection coll = new SysProfesionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProfesion)
        {
            return (SysProfesion.Delete(IdProfesion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProfesion)
        {
            return (SysProfesion.Destroy(IdProfesion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysProfesion item = new SysProfesion();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProfesion,string Nombre)
	    {
		    SysProfesion item = new SysProfesion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProfesion = IdProfesion;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
