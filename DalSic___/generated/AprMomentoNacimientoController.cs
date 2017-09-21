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
    /// Controller class for APR_MomentoNacimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprMomentoNacimientoController
    {
        // Preload our schema..
        AprMomentoNacimiento thisSchemaLoad = new AprMomentoNacimiento();
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
        public AprMomentoNacimientoCollection FetchAll()
        {
            AprMomentoNacimientoCollection coll = new AprMomentoNacimientoCollection();
            Query qry = new Query(AprMomentoNacimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprMomentoNacimientoCollection FetchByID(object IdMomentoNacimiento)
        {
            AprMomentoNacimientoCollection coll = new AprMomentoNacimientoCollection().Where("idMomentoNacimiento", IdMomentoNacimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprMomentoNacimientoCollection FetchByQuery(Query qry)
        {
            AprMomentoNacimientoCollection coll = new AprMomentoNacimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMomentoNacimiento)
        {
            return (AprMomentoNacimiento.Delete(IdMomentoNacimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMomentoNacimiento)
        {
            return (AprMomentoNacimiento.Destroy(IdMomentoNacimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprMomentoNacimiento item = new AprMomentoNacimiento();
		    
            item.Nombre = Nombre;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMomentoNacimiento,string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprMomentoNacimiento item = new AprMomentoNacimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMomentoNacimiento = IdMomentoNacimiento;
				
			item.Nombre = Nombre;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
