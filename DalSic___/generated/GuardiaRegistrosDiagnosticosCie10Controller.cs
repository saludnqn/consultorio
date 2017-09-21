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
    /// Controller class for Guardia_Registros_Diagnosticos_Cie10
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistrosDiagnosticosCie10Controller
    {
        // Preload our schema..
        GuardiaRegistrosDiagnosticosCie10 thisSchemaLoad = new GuardiaRegistrosDiagnosticosCie10();
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
        public GuardiaRegistrosDiagnosticosCie10Collection FetchAll()
        {
            GuardiaRegistrosDiagnosticosCie10Collection coll = new GuardiaRegistrosDiagnosticosCie10Collection();
            Query qry = new Query(GuardiaRegistrosDiagnosticosCie10.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosDiagnosticosCie10Collection FetchByID(object Id)
        {
            GuardiaRegistrosDiagnosticosCie10Collection coll = new GuardiaRegistrosDiagnosticosCie10Collection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosDiagnosticosCie10Collection FetchByQuery(Query qry)
        {
            GuardiaRegistrosDiagnosticosCie10Collection coll = new GuardiaRegistrosDiagnosticosCie10Collection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaRegistrosDiagnosticosCie10.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaRegistrosDiagnosticosCie10.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdRegistroGuardia,int? IdEfector,int? IdCie10,DateTime? Fecha,int AuditUser,int? PrimeraVez,int? TipoDiagnostico,string DiagnosticoManual)
	    {
		    GuardiaRegistrosDiagnosticosCie10 item = new GuardiaRegistrosDiagnosticosCie10();
		    
            item.IdRegistroGuardia = IdRegistroGuardia;
            
            item.IdEfector = IdEfector;
            
            item.IdCie10 = IdCie10;
            
            item.Fecha = Fecha;
            
            item.AuditUser = AuditUser;
            
            item.PrimeraVez = PrimeraVez;
            
            item.TipoDiagnostico = TipoDiagnostico;
            
            item.DiagnosticoManual = DiagnosticoManual;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdRegistroGuardia,int? IdEfector,int? IdCie10,DateTime? Fecha,int AuditUser,int? PrimeraVez,int? TipoDiagnostico,string DiagnosticoManual)
	    {
		    GuardiaRegistrosDiagnosticosCie10 item = new GuardiaRegistrosDiagnosticosCie10();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdRegistroGuardia = IdRegistroGuardia;
				
			item.IdEfector = IdEfector;
				
			item.IdCie10 = IdCie10;
				
			item.Fecha = Fecha;
				
			item.AuditUser = AuditUser;
				
			item.PrimeraVez = PrimeraVez;
				
			item.TipoDiagnostico = TipoDiagnostico;
				
			item.DiagnosticoManual = DiagnosticoManual;
				
	        item.Save(UserName);
	    }
    }
}
