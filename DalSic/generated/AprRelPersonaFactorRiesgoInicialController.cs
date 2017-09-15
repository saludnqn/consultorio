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
    /// Controller class for APR_RelPersonaFactorRiesgoInicial
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprRelPersonaFactorRiesgoInicialController
    {
        // Preload our schema..
        AprRelPersonaFactorRiesgoInicial thisSchemaLoad = new AprRelPersonaFactorRiesgoInicial();
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
        public AprRelPersonaFactorRiesgoInicialCollection FetchAll()
        {
            AprRelPersonaFactorRiesgoInicialCollection coll = new AprRelPersonaFactorRiesgoInicialCollection();
            Query qry = new Query(AprRelPersonaFactorRiesgoInicial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelPersonaFactorRiesgoInicialCollection FetchByID(object IdRelacion)
        {
            AprRelPersonaFactorRiesgoInicialCollection coll = new AprRelPersonaFactorRiesgoInicialCollection().Where("idRelacion", IdRelacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelPersonaFactorRiesgoInicialCollection FetchByQuery(Query qry)
        {
            AprRelPersonaFactorRiesgoInicialCollection coll = new AprRelPersonaFactorRiesgoInicialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelacion)
        {
            return (AprRelPersonaFactorRiesgoInicial.Delete(IdRelacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelacion)
        {
            return (AprRelPersonaFactorRiesgoInicial.Destroy(IdRelacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPersona,int IdFactorRiesgo,DateTime? FechaHora,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelPersonaFactorRiesgoInicial item = new AprRelPersonaFactorRiesgoInicial();
		    
            item.IdPersona = IdPersona;
            
            item.IdFactorRiesgo = IdFactorRiesgo;
            
            item.FechaHora = FechaHora;
            
            item.Observacion = Observacion;
            
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
	    public void Update(int IdRelacion,int IdPersona,int IdFactorRiesgo,DateTime? FechaHora,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelPersonaFactorRiesgoInicial item = new AprRelPersonaFactorRiesgoInicial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelacion = IdRelacion;
				
			item.IdPersona = IdPersona;
				
			item.IdFactorRiesgo = IdFactorRiesgo;
				
			item.FechaHora = FechaHora;
				
			item.Observacion = Observacion;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
