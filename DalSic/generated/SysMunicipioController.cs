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
    /// Controller class for Sys_Municipio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysMunicipioController
    {
        // Preload our schema..
        SysMunicipio thisSchemaLoad = new SysMunicipio();
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
        public SysMunicipioCollection FetchAll()
        {
            SysMunicipioCollection coll = new SysMunicipioCollection();
            Query qry = new Query(SysMunicipio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMunicipioCollection FetchByID(object IdMunicipio)
        {
            SysMunicipioCollection coll = new SysMunicipioCollection().Where("idMunicipio", IdMunicipio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMunicipioCollection FetchByQuery(Query qry)
        {
            SysMunicipioCollection coll = new SysMunicipioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMunicipio)
        {
            return (SysMunicipio.Delete(IdMunicipio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMunicipio)
        {
            return (SysMunicipio.Destroy(IdMunicipio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    SysMunicipio item = new SysMunicipio();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMunicipio,string Nombre)
	    {
		    SysMunicipio item = new SysMunicipio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMunicipio = IdMunicipio;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
