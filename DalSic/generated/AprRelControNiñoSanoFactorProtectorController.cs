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
    /// Controller class for APR_RelControNiñoSanoFactorProtector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprRelControNiñoSanoFactorProtectorController
    {
        // Preload our schema..
        AprRelControNiñoSanoFactorProtector thisSchemaLoad = new AprRelControNiñoSanoFactorProtector();
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
        public AprRelControNiñoSanoFactorProtectorCollection FetchAll()
        {
            AprRelControNiñoSanoFactorProtectorCollection coll = new AprRelControNiñoSanoFactorProtectorCollection();
            Query qry = new Query(AprRelControNiñoSanoFactorProtector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelControNiñoSanoFactorProtectorCollection FetchByID(object IdRelacion)
        {
            AprRelControNiñoSanoFactorProtectorCollection coll = new AprRelControNiñoSanoFactorProtectorCollection().Where("idRelacion", IdRelacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelControNiñoSanoFactorProtectorCollection FetchByQuery(Query qry)
        {
            AprRelControNiñoSanoFactorProtectorCollection coll = new AprRelControNiñoSanoFactorProtectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelacion)
        {
            return (AprRelControNiñoSanoFactorProtector.Delete(IdRelacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelacion)
        {
            return (AprRelControNiñoSanoFactorProtector.Destroy(IdRelacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdControlNiñoSanoConsultorio,int IdFactorProtector,string Observaciones,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelControNiñoSanoFactorProtector item = new AprRelControNiñoSanoFactorProtector();
		    
            item.IdControlNiñoSanoConsultorio = IdControlNiñoSanoConsultorio;
            
            item.IdFactorProtector = IdFactorProtector;
            
            item.Observaciones = Observaciones;
            
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
	    public void Update(int IdRelacion,int IdControlNiñoSanoConsultorio,int IdFactorProtector,string Observaciones,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelControNiñoSanoFactorProtector item = new AprRelControNiñoSanoFactorProtector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelacion = IdRelacion;
				
			item.IdControlNiñoSanoConsultorio = IdControlNiñoSanoConsultorio;
				
			item.IdFactorProtector = IdFactorProtector;
				
			item.Observaciones = Observaciones;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
