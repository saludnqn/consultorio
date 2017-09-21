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
    /// Controller class for APR_ControlNiñoSano
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprControlNiñoSanoController
    {
        // Preload our schema..
        AprControlNiñoSano thisSchemaLoad = new AprControlNiñoSano();
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
        public AprControlNiñoSanoCollection FetchAll()
        {
            AprControlNiñoSanoCollection coll = new AprControlNiñoSanoCollection();
            Query qry = new Query(AprControlNiñoSano.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoCollection FetchByID(object IdControlNiñoSano)
        {
            AprControlNiñoSanoCollection coll = new AprControlNiñoSanoCollection().Where("idControlNiñoSano", IdControlNiñoSano).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoCollection FetchByQuery(Query qry)
        {
            AprControlNiñoSanoCollection coll = new AprControlNiñoSanoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdControlNiñoSano)
        {
            return (AprControlNiñoSano.Delete(IdControlNiñoSano) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdControlNiñoSano)
        {
            return (AprControlNiñoSano.Destroy(IdControlNiñoSano) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdConsulta,int? IdCalendarioVisitas,int? Edad,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprControlNiñoSano item = new AprControlNiñoSano();
		    
            item.IdConsulta = IdConsulta;
            
            item.IdCalendarioVisitas = IdCalendarioVisitas;
            
            item.Edad = Edad;
            
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
	    public void Update(int IdControlNiñoSano,int IdConsulta,int? IdCalendarioVisitas,int? Edad,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprControlNiñoSano item = new AprControlNiñoSano();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdControlNiñoSano = IdControlNiñoSano;
				
			item.IdConsulta = IdConsulta;
				
			item.IdCalendarioVisitas = IdCalendarioVisitas;
				
			item.Edad = Edad;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
