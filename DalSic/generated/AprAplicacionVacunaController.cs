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
    /// Controller class for APR_AplicacionVacuna
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAplicacionVacunaController
    {
        // Preload our schema..
        AprAplicacionVacuna thisSchemaLoad = new AprAplicacionVacuna();
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
        public AprAplicacionVacunaCollection FetchAll()
        {
            AprAplicacionVacunaCollection coll = new AprAplicacionVacunaCollection();
            Query qry = new Query(AprAplicacionVacuna.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAplicacionVacunaCollection FetchByID(object IdAplicacionVacuna)
        {
            AprAplicacionVacunaCollection coll = new AprAplicacionVacunaCollection().Where("idAplicacionVacuna", IdAplicacionVacuna).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAplicacionVacunaCollection FetchByQuery(Query qry)
        {
            AprAplicacionVacunaCollection coll = new AprAplicacionVacunaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAplicacionVacuna)
        {
            return (AprAplicacionVacuna.Delete(IdAplicacionVacuna) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAplicacionVacuna)
        {
            return (AprAplicacionVacuna.Destroy(IdAplicacionVacuna) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int IdVacuna,DateTime FechaAplicacion,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdNumeroDosis,bool? Baja)
	    {
		    AprAplicacionVacuna item = new AprAplicacionVacuna();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdVacuna = IdVacuna;
            
            item.FechaAplicacion = FechaAplicacion;
            
            item.Observacion = Observacion;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdNumeroDosis = IdNumeroDosis;
            
            item.Baja = Baja;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAplicacionVacuna,int IdPaciente,int IdVacuna,DateTime FechaAplicacion,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdNumeroDosis,bool? Baja)
	    {
		    AprAplicacionVacuna item = new AprAplicacionVacuna();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAplicacionVacuna = IdAplicacionVacuna;
				
			item.IdPaciente = IdPaciente;
				
			item.IdVacuna = IdVacuna;
				
			item.FechaAplicacion = FechaAplicacion;
				
			item.Observacion = Observacion;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdNumeroDosis = IdNumeroDosis;
				
			item.Baja = Baja;
				
	        item.Save(UserName);
	    }
    }
}
