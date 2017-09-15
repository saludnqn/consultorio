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
    /// Controller class for APR_RelControlNiñoSanoFactorRiesgo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprRelControlNiñoSanoFactorRiesgoController
    {
        // Preload our schema..
        AprRelControlNiñoSanoFactorRiesgo thisSchemaLoad = new AprRelControlNiñoSanoFactorRiesgo();
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
        public AprRelControlNiñoSanoFactorRiesgoCollection FetchAll()
        {
            AprRelControlNiñoSanoFactorRiesgoCollection coll = new AprRelControlNiñoSanoFactorRiesgoCollection();
            Query qry = new Query(AprRelControlNiñoSanoFactorRiesgo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelControlNiñoSanoFactorRiesgoCollection FetchByID(object IdRelacion)
        {
            AprRelControlNiñoSanoFactorRiesgoCollection coll = new AprRelControlNiñoSanoFactorRiesgoCollection().Where("idRelacion", IdRelacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelControlNiñoSanoFactorRiesgoCollection FetchByQuery(Query qry)
        {
            AprRelControlNiñoSanoFactorRiesgoCollection coll = new AprRelControlNiñoSanoFactorRiesgoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelacion)
        {
            return (AprRelControlNiñoSanoFactorRiesgo.Delete(IdRelacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelacion)
        {
            return (AprRelControlNiñoSanoFactorRiesgo.Destroy(IdRelacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdControlNiñoSanoConsultorio,int IdFactorRiesgo,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelControlNiñoSanoFactorRiesgo item = new AprRelControlNiñoSanoFactorRiesgo();
		    
            item.IdControlNiñoSanoConsultorio = IdControlNiñoSanoConsultorio;
            
            item.IdFactorRiesgo = IdFactorRiesgo;
            
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
	    public void Update(int IdRelacion,int IdControlNiñoSanoConsultorio,int IdFactorRiesgo,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelControlNiñoSanoFactorRiesgo item = new AprRelControlNiñoSanoFactorRiesgo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelacion = IdRelacion;
				
			item.IdControlNiñoSanoConsultorio = IdControlNiñoSanoConsultorio;
				
			item.IdFactorRiesgo = IdFactorRiesgo;
				
			item.Observacion = Observacion;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
