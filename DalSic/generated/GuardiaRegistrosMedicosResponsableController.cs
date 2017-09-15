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
    /// Controller class for Guardia_Registros_MedicosResponsables
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistrosMedicosResponsableController
    {
        // Preload our schema..
        GuardiaRegistrosMedicosResponsable thisSchemaLoad = new GuardiaRegistrosMedicosResponsable();
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
        public GuardiaRegistrosMedicosResponsableCollection FetchAll()
        {
            GuardiaRegistrosMedicosResponsableCollection coll = new GuardiaRegistrosMedicosResponsableCollection();
            Query qry = new Query(GuardiaRegistrosMedicosResponsable.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosMedicosResponsableCollection FetchByID(object Id)
        {
            GuardiaRegistrosMedicosResponsableCollection coll = new GuardiaRegistrosMedicosResponsableCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosMedicosResponsableCollection FetchByQuery(Query qry)
        {
            GuardiaRegistrosMedicosResponsableCollection coll = new GuardiaRegistrosMedicosResponsableCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaRegistrosMedicosResponsable.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaRegistrosMedicosResponsable.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdRegistroGuardia,int IdMedico,DateTime Fecha,int AuditUser)
	    {
		    GuardiaRegistrosMedicosResponsable item = new GuardiaRegistrosMedicosResponsable();
		    
            item.IdRegistroGuardia = IdRegistroGuardia;
            
            item.IdMedico = IdMedico;
            
            item.Fecha = Fecha;
            
            item.AuditUser = AuditUser;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int IdRegistroGuardia,int IdMedico,DateTime Fecha,int AuditUser)
	    {
		    GuardiaRegistrosMedicosResponsable item = new GuardiaRegistrosMedicosResponsable();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdRegistroGuardia = IdRegistroGuardia;
				
			item.IdMedico = IdMedico;
				
			item.Fecha = Fecha;
				
			item.AuditUser = AuditUser;
				
	        item.Save(UserName);
	    }
    }
}
