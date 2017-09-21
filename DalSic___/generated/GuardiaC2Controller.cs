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
    /// Controller class for Guardia_C2
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaC2Controller
    {
        // Preload our schema..
        GuardiaC2 thisSchemaLoad = new GuardiaC2();
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
        public GuardiaC2Collection FetchAll()
        {
            GuardiaC2Collection coll = new GuardiaC2Collection();
            Query qry = new Query(GuardiaC2.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaC2Collection FetchByID(object Id)
        {
            GuardiaC2Collection coll = new GuardiaC2Collection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaC2Collection FetchByQuery(Query qry)
        {
            GuardiaC2Collection coll = new GuardiaC2Collection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaC2.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaC2.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdRegistroGuardia,int? IdEfector,int IdC2,bool Sospecha,DateTime? Fecha,int AuditUser)
	    {
		    GuardiaC2 item = new GuardiaC2();
		    
            item.IdRegistroGuardia = IdRegistroGuardia;
            
            item.IdEfector = IdEfector;
            
            item.IdC2 = IdC2;
            
            item.Sospecha = Sospecha;
            
            item.Fecha = Fecha;
            
            item.AuditUser = AuditUser;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int IdRegistroGuardia,int? IdEfector,int IdC2,bool Sospecha,DateTime? Fecha,int AuditUser)
	    {
		    GuardiaC2 item = new GuardiaC2();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdRegistroGuardia = IdRegistroGuardia;
				
			item.IdEfector = IdEfector;
				
			item.IdC2 = IdC2;
				
			item.Sospecha = Sospecha;
				
			item.Fecha = Fecha;
				
			item.AuditUser = AuditUser;
				
	        item.Save(UserName);
	    }
    }
}
