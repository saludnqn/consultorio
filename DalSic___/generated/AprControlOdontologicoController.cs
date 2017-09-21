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
    /// Controller class for APR_ControlOdontologico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprControlOdontologicoController
    {
        // Preload our schema..
        AprControlOdontologico thisSchemaLoad = new AprControlOdontologico();
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
        public AprControlOdontologicoCollection FetchAll()
        {
            AprControlOdontologicoCollection coll = new AprControlOdontologicoCollection();
            Query qry = new Query(AprControlOdontologico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlOdontologicoCollection FetchByID(object IdControlOdontologico)
        {
            AprControlOdontologicoCollection coll = new AprControlOdontologicoCollection().Where("idControlOdontologico", IdControlOdontologico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlOdontologicoCollection FetchByQuery(Query qry)
        {
            AprControlOdontologicoCollection coll = new AprControlOdontologicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdControlOdontologico)
        {
            return (AprControlOdontologico.Delete(IdControlOdontologico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdControlOdontologico)
        {
            return (AprControlOdontologico.Destroy(IdControlOdontologico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdHistoriaClinicaPerinatal,int IdEfector,DateTime? Fecha,string Motivo,string Descripcion,int IdProfesional,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprControlOdontologico item = new AprControlOdontologico();
		    
            item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
            
            item.IdEfector = IdEfector;
            
            item.Fecha = Fecha;
            
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
	    public void Update(int IdControlOdontologico,int IdHistoriaClinicaPerinatal,int IdEfector,DateTime? Fecha,string Motivo,string Descripcion,int IdProfesional,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprControlOdontologico item = new AprControlOdontologico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdControlOdontologico = IdControlOdontologico;
				
			item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
				
			item.IdEfector = IdEfector;
				
			item.Fecha = Fecha;
				
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
