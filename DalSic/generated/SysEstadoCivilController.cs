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
    /// Controller class for Sys_EstadoCivil
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysEstadoCivilController
    {
        // Preload our schema..
        SysEstadoCivil thisSchemaLoad = new SysEstadoCivil();
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
        public SysEstadoCivilCollection FetchAll()
        {
            SysEstadoCivilCollection coll = new SysEstadoCivilCollection();
            Query qry = new Query(SysEstadoCivil.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEstadoCivilCollection FetchByID(object IdEstadoCivil)
        {
            SysEstadoCivilCollection coll = new SysEstadoCivilCollection().Where("idEstadoCivil", IdEstadoCivil).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEstadoCivilCollection FetchByQuery(Query qry)
        {
            SysEstadoCivilCollection coll = new SysEstadoCivilCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstadoCivil)
        {
            return (SysEstadoCivil.Delete(IdEstadoCivil) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstadoCivil)
        {
            return (SysEstadoCivil.Destroy(IdEstadoCivil) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysEstadoCivil item = new SysEstadoCivil();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstadoCivil,string Nombre)
	    {
		    SysEstadoCivil item = new SysEstadoCivil();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstadoCivil = IdEstadoCivil;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
