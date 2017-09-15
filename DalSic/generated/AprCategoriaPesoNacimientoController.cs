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
    /// Controller class for APR_CategoriaPesoNacimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprCategoriaPesoNacimientoController
    {
        // Preload our schema..
        AprCategoriaPesoNacimiento thisSchemaLoad = new AprCategoriaPesoNacimiento();
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
        public AprCategoriaPesoNacimientoCollection FetchAll()
        {
            AprCategoriaPesoNacimientoCollection coll = new AprCategoriaPesoNacimientoCollection();
            Query qry = new Query(AprCategoriaPesoNacimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCategoriaPesoNacimientoCollection FetchByID(object IdCategoriaPesoNacimiento)
        {
            AprCategoriaPesoNacimientoCollection coll = new AprCategoriaPesoNacimientoCollection().Where("idCategoriaPesoNacimiento", IdCategoriaPesoNacimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCategoriaPesoNacimientoCollection FetchByQuery(Query qry)
        {
            AprCategoriaPesoNacimientoCollection coll = new AprCategoriaPesoNacimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCategoriaPesoNacimiento)
        {
            return (AprCategoriaPesoNacimiento.Delete(IdCategoriaPesoNacimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCategoriaPesoNacimiento)
        {
            return (AprCategoriaPesoNacimiento.Destroy(IdCategoriaPesoNacimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprCategoriaPesoNacimiento item = new AprCategoriaPesoNacimiento();
		    
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
	    public void Update(int IdCategoriaPesoNacimiento,string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprCategoriaPesoNacimiento item = new AprCategoriaPesoNacimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCategoriaPesoNacimiento = IdCategoriaPesoNacimiento;
				
			item.Nombre = Nombre;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
