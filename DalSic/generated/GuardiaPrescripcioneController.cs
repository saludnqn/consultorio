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
    /// Controller class for Guardia_Prescripciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaPrescripcioneController
    {
        // Preload our schema..
        GuardiaPrescripcione thisSchemaLoad = new GuardiaPrescripcione();
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
        public GuardiaPrescripcioneCollection FetchAll()
        {
            GuardiaPrescripcioneCollection coll = new GuardiaPrescripcioneCollection();
            Query qry = new Query(GuardiaPrescripcione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaPrescripcioneCollection FetchByID(object Id)
        {
            GuardiaPrescripcioneCollection coll = new GuardiaPrescripcioneCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaPrescripcioneCollection FetchByQuery(Query qry)
        {
            GuardiaPrescripcioneCollection coll = new GuardiaPrescripcioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaPrescripcione.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaPrescripcione.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdRegistro,int? IdEfector,bool? IsPrescMedica,string Prescripcion,string Observacion,bool? IsTerminada,DateTime? Fecha,DateTime? FechaRealizada,int? AuditUserMedico,int? AuditUserEnfermeria)
	    {
		    GuardiaPrescripcione item = new GuardiaPrescripcione();
		    
            item.IdRegistro = IdRegistro;
            
            item.IdEfector = IdEfector;
            
            item.IsPrescMedica = IsPrescMedica;
            
            item.Prescripcion = Prescripcion;
            
            item.Observacion = Observacion;
            
            item.IsTerminada = IsTerminada;
            
            item.Fecha = Fecha;
            
            item.FechaRealizada = FechaRealizada;
            
            item.AuditUserMedico = AuditUserMedico;
            
            item.AuditUserEnfermeria = AuditUserEnfermeria;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int IdRegistro,int? IdEfector,bool? IsPrescMedica,string Prescripcion,string Observacion,bool? IsTerminada,DateTime? Fecha,DateTime? FechaRealizada,int? AuditUserMedico,int? AuditUserEnfermeria)
	    {
		    GuardiaPrescripcione item = new GuardiaPrescripcione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdRegistro = IdRegistro;
				
			item.IdEfector = IdEfector;
				
			item.IsPrescMedica = IsPrescMedica;
				
			item.Prescripcion = Prescripcion;
				
			item.Observacion = Observacion;
				
			item.IsTerminada = IsTerminada;
				
			item.Fecha = Fecha;
				
			item.FechaRealizada = FechaRealizada;
				
			item.AuditUserMedico = AuditUserMedico;
				
			item.AuditUserEnfermeria = AuditUserEnfermeria;
				
	        item.Save(UserName);
	    }
    }
}
