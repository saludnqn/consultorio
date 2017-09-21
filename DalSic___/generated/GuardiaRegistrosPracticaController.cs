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
    /// Controller class for Guardia_Registros_Practicas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistrosPracticaController
    {
        // Preload our schema..
        GuardiaRegistrosPractica thisSchemaLoad = new GuardiaRegistrosPractica();
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
        public GuardiaRegistrosPracticaCollection FetchAll()
        {
            GuardiaRegistrosPracticaCollection coll = new GuardiaRegistrosPracticaCollection();
            Query qry = new Query(GuardiaRegistrosPractica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosPracticaCollection FetchByID(object Id)
        {
            GuardiaRegistrosPracticaCollection coll = new GuardiaRegistrosPracticaCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosPracticaCollection FetchByQuery(Query qry)
        {
            GuardiaRegistrosPracticaCollection coll = new GuardiaRegistrosPracticaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaRegistrosPractica.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaRegistrosPractica.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdRegistroGuardia,int? IdEfector,DateTime Fecha,int IdTipoPractica,int IdPrioridad,int IdEstado,string Observaciones,string Url,int? AuditUser)
	    {
		    GuardiaRegistrosPractica item = new GuardiaRegistrosPractica();
		    
            item.IdRegistroGuardia = IdRegistroGuardia;
            
            item.IdEfector = IdEfector;
            
            item.Fecha = Fecha;
            
            item.IdTipoPractica = IdTipoPractica;
            
            item.IdPrioridad = IdPrioridad;
            
            item.IdEstado = IdEstado;
            
            item.Observaciones = Observaciones;
            
            item.Url = Url;
            
            item.AuditUser = AuditUser;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int IdRegistroGuardia,int? IdEfector,DateTime Fecha,int IdTipoPractica,int IdPrioridad,int IdEstado,string Observaciones,string Url,int? AuditUser)
	    {
		    GuardiaRegistrosPractica item = new GuardiaRegistrosPractica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdRegistroGuardia = IdRegistroGuardia;
				
			item.IdEfector = IdEfector;
				
			item.Fecha = Fecha;
				
			item.IdTipoPractica = IdTipoPractica;
				
			item.IdPrioridad = IdPrioridad;
				
			item.IdEstado = IdEstado;
				
			item.Observaciones = Observaciones;
				
			item.Url = Url;
				
			item.AuditUser = AuditUser;
				
	        item.Save(UserName);
	    }
    }
}
