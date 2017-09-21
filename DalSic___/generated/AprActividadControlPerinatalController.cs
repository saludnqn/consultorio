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
    /// Controller class for APR_ActividadControlPerinatal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprActividadControlPerinatalController
    {
        // Preload our schema..
        AprActividadControlPerinatal thisSchemaLoad = new AprActividadControlPerinatal();
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
        public AprActividadControlPerinatalCollection FetchAll()
        {
            AprActividadControlPerinatalCollection coll = new AprActividadControlPerinatalCollection();
            Query qry = new Query(AprActividadControlPerinatal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActividadControlPerinatalCollection FetchByID(object IdActividadControlPerinatal)
        {
            AprActividadControlPerinatalCollection coll = new AprActividadControlPerinatalCollection().Where("idActividadControlPerinatal", IdActividadControlPerinatal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActividadControlPerinatalCollection FetchByQuery(Query qry)
        {
            AprActividadControlPerinatalCollection coll = new AprActividadControlPerinatalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdActividadControlPerinatal)
        {
            return (AprActividadControlPerinatal.Delete(IdActividadControlPerinatal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdActividadControlPerinatal)
        {
            return (AprActividadControlPerinatal.Destroy(IdActividadControlPerinatal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdHistoriaClinicaPerinatal,int IdEfector,DateTime? Fecha,int? IdActividadEmbarazo,string Motivo,string Descripcion,int? IdProfesional,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprActividadControlPerinatal item = new AprActividadControlPerinatal();
		    
            item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
            
            item.IdEfector = IdEfector;
            
            item.Fecha = Fecha;
            
            item.IdActividadEmbarazo = IdActividadEmbarazo;
            
            item.Motivo = Motivo;
            
            item.Descripcion = Descripcion;
            
            item.IdProfesional = IdProfesional;
            
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
	    public void Update(int IdActividadControlPerinatal,int IdHistoriaClinicaPerinatal,int IdEfector,DateTime? Fecha,int? IdActividadEmbarazo,string Motivo,string Descripcion,int? IdProfesional,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprActividadControlPerinatal item = new AprActividadControlPerinatal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdActividadControlPerinatal = IdActividadControlPerinatal;
				
			item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
				
			item.IdEfector = IdEfector;
				
			item.Fecha = Fecha;
				
			item.IdActividadEmbarazo = IdActividadEmbarazo;
				
			item.Motivo = Motivo;
				
			item.Descripcion = Descripcion;
				
			item.IdProfesional = IdProfesional;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
