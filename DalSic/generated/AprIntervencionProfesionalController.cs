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
    /// Controller class for APR_IntervencionProfesional
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprIntervencionProfesionalController
    {
        // Preload our schema..
        AprIntervencionProfesional thisSchemaLoad = new AprIntervencionProfesional();
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
        public AprIntervencionProfesionalCollection FetchAll()
        {
            AprIntervencionProfesionalCollection coll = new AprIntervencionProfesionalCollection();
            Query qry = new Query(AprIntervencionProfesional.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprIntervencionProfesionalCollection FetchByID(object IdIntervencionProfesional)
        {
            AprIntervencionProfesionalCollection coll = new AprIntervencionProfesionalCollection().Where("idIntervencionProfesional", IdIntervencionProfesional).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprIntervencionProfesionalCollection FetchByQuery(Query qry)
        {
            AprIntervencionProfesionalCollection coll = new AprIntervencionProfesionalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIntervencionProfesional)
        {
            return (AprIntervencionProfesional.Delete(IdIntervencionProfesional) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIntervencionProfesional)
        {
            return (AprIntervencionProfesional.Destroy(IdIntervencionProfesional) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,string Profesional,int? IdEspecialidad,int? IdActividad,string Observacion,DateTime? Fecha,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprIntervencionProfesional item = new AprIntervencionProfesional();
		    
            item.IdPaciente = IdPaciente;
            
            item.Profesional = Profesional;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdActividad = IdActividad;
            
            item.Observacion = Observacion;
            
            item.Fecha = Fecha;
            
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
	    public void Update(int IdIntervencionProfesional,int IdPaciente,string Profesional,int? IdEspecialidad,int? IdActividad,string Observacion,DateTime? Fecha,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprIntervencionProfesional item = new AprIntervencionProfesional();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIntervencionProfesional = IdIntervencionProfesional;
				
			item.IdPaciente = IdPaciente;
				
			item.Profesional = Profesional;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdActividad = IdActividad;
				
			item.Observacion = Observacion;
				
			item.Fecha = Fecha;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
