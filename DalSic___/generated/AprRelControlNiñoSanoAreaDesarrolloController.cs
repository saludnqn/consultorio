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
    /// Controller class for APR_RelControlNiñoSanoAreaDesarrollo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprRelControlNiñoSanoAreaDesarrolloController
    {
        // Preload our schema..
        AprRelControlNiñoSanoAreaDesarrollo thisSchemaLoad = new AprRelControlNiñoSanoAreaDesarrollo();
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
        public AprRelControlNiñoSanoAreaDesarrolloCollection FetchAll()
        {
            AprRelControlNiñoSanoAreaDesarrolloCollection coll = new AprRelControlNiñoSanoAreaDesarrolloCollection();
            Query qry = new Query(AprRelControlNiñoSanoAreaDesarrollo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelControlNiñoSanoAreaDesarrolloCollection FetchByID(object IdRelacion)
        {
            AprRelControlNiñoSanoAreaDesarrolloCollection coll = new AprRelControlNiñoSanoAreaDesarrolloCollection().Where("idRelacion", IdRelacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelControlNiñoSanoAreaDesarrolloCollection FetchByQuery(Query qry)
        {
            AprRelControlNiñoSanoAreaDesarrolloCollection coll = new AprRelControlNiñoSanoAreaDesarrolloCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelacion)
        {
            return (AprRelControlNiñoSanoAreaDesarrollo.Delete(IdRelacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelacion)
        {
            return (AprRelControlNiñoSanoAreaDesarrollo.Destroy(IdRelacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdControlNiñoSanoConsultorio,int IdAreaDesarrollo,bool Adecuado,int? Item,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelControlNiñoSanoAreaDesarrollo item = new AprRelControlNiñoSanoAreaDesarrollo();
		    
            item.IdControlNiñoSanoConsultorio = IdControlNiñoSanoConsultorio;
            
            item.IdAreaDesarrollo = IdAreaDesarrollo;
            
            item.Adecuado = Adecuado;
            
            item.Item = Item;
            
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
	    public void Update(int IdRelacion,int IdControlNiñoSanoConsultorio,int IdAreaDesarrollo,bool Adecuado,int? Item,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelControlNiñoSanoAreaDesarrollo item = new AprRelControlNiñoSanoAreaDesarrollo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelacion = IdRelacion;
				
			item.IdControlNiñoSanoConsultorio = IdControlNiñoSanoConsultorio;
				
			item.IdAreaDesarrollo = IdAreaDesarrollo;
				
			item.Adecuado = Adecuado;
				
			item.Item = Item;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
