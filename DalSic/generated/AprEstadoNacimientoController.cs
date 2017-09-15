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
    /// Controller class for APR_EstadoNacimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprEstadoNacimientoController
    {
        // Preload our schema..
        AprEstadoNacimiento thisSchemaLoad = new AprEstadoNacimiento();
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
        public AprEstadoNacimientoCollection FetchAll()
        {
            AprEstadoNacimientoCollection coll = new AprEstadoNacimientoCollection();
            Query qry = new Query(AprEstadoNacimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEstadoNacimientoCollection FetchByID(object IdEstadoNacimiento)
        {
            AprEstadoNacimientoCollection coll = new AprEstadoNacimientoCollection().Where("idEstadoNacimiento", IdEstadoNacimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEstadoNacimientoCollection FetchByQuery(Query qry)
        {
            AprEstadoNacimientoCollection coll = new AprEstadoNacimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstadoNacimiento)
        {
            return (AprEstadoNacimiento.Delete(IdEstadoNacimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstadoNacimiento)
        {
            return (AprEstadoNacimiento.Destroy(IdEstadoNacimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprEstadoNacimiento item = new AprEstadoNacimiento();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstadoNacimiento,string Nombre)
	    {
		    AprEstadoNacimiento item = new AprEstadoNacimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstadoNacimiento = IdEstadoNacimiento;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
