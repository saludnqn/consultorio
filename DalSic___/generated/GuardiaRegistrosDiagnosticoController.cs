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
    /// Controller class for Guardia_Registros_Diagnosticos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistrosDiagnosticoController
    {
        // Preload our schema..
        GuardiaRegistrosDiagnostico thisSchemaLoad = new GuardiaRegistrosDiagnostico();
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
        public GuardiaRegistrosDiagnosticoCollection FetchAll()
        {
            GuardiaRegistrosDiagnosticoCollection coll = new GuardiaRegistrosDiagnosticoCollection();
            Query qry = new Query(GuardiaRegistrosDiagnostico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosDiagnosticoCollection FetchByID(object Id)
        {
            GuardiaRegistrosDiagnosticoCollection coll = new GuardiaRegistrosDiagnosticoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosDiagnosticoCollection FetchByQuery(Query qry)
        {
            GuardiaRegistrosDiagnosticoCollection coll = new GuardiaRegistrosDiagnosticoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaRegistrosDiagnostico.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaRegistrosDiagnostico.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdRegistroGuardia,int? IdEfector,int AuditUser,int TipoAnotacion,string Observacion,DateTime? Fecha)
	    {
		    GuardiaRegistrosDiagnostico item = new GuardiaRegistrosDiagnostico();
		    
            item.IdRegistroGuardia = IdRegistroGuardia;
            
            item.IdEfector = IdEfector;
            
            item.AuditUser = AuditUser;
            
            item.TipoAnotacion = TipoAnotacion;
            
            item.Observacion = Observacion;
            
            item.Fecha = Fecha;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdRegistroGuardia,int? IdEfector,int AuditUser,int TipoAnotacion,string Observacion,DateTime? Fecha)
	    {
		    GuardiaRegistrosDiagnostico item = new GuardiaRegistrosDiagnostico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdRegistroGuardia = IdRegistroGuardia;
				
			item.IdEfector = IdEfector;
				
			item.AuditUser = AuditUser;
				
			item.TipoAnotacion = TipoAnotacion;
				
			item.Observacion = Observacion;
				
			item.Fecha = Fecha;
				
	        item.Save(UserName);
	    }
    }
}
