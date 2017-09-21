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
    /// Controller class for Sys_CIE10Capitulo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysCIE10CapituloController
    {
        // Preload our schema..
        SysCIE10Capitulo thisSchemaLoad = new SysCIE10Capitulo();
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
        public SysCIE10CapituloCollection FetchAll()
        {
            SysCIE10CapituloCollection coll = new SysCIE10CapituloCollection();
            Query qry = new Query(SysCIE10Capitulo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysCIE10CapituloCollection FetchByID(object IdCie10Capitulo)
        {
            SysCIE10CapituloCollection coll = new SysCIE10CapituloCollection().Where("idCie10Capitulo", IdCie10Capitulo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysCIE10CapituloCollection FetchByQuery(Query qry)
        {
            SysCIE10CapituloCollection coll = new SysCIE10CapituloCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCie10Capitulo)
        {
            return (SysCIE10Capitulo.Delete(IdCie10Capitulo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCie10Capitulo)
        {
            return (SysCIE10Capitulo.Destroy(IdCie10Capitulo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Capitulo,string Descrip,string Rango,string Capirom)
	    {
		    SysCIE10Capitulo item = new SysCIE10Capitulo();
		    
            item.Capitulo = Capitulo;
            
            item.Descrip = Descrip;
            
            item.Rango = Rango;
            
            item.Capirom = Capirom;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCie10Capitulo,string Capitulo,string Descrip,string Rango,string Capirom)
	    {
		    SysCIE10Capitulo item = new SysCIE10Capitulo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCie10Capitulo = IdCie10Capitulo;
				
			item.Capitulo = Capitulo;
				
			item.Descrip = Descrip;
				
			item.Rango = Rango;
				
			item.Capirom = Capirom;
				
	        item.Save(UserName);
	    }
    }
}
