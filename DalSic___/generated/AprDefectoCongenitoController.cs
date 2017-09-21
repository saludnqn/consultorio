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
    /// Controller class for APR_DefectoCongenito
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprDefectoCongenitoController
    {
        // Preload our schema..
        AprDefectoCongenito thisSchemaLoad = new AprDefectoCongenito();
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
        public AprDefectoCongenitoCollection FetchAll()
        {
            AprDefectoCongenitoCollection coll = new AprDefectoCongenitoCollection();
            Query qry = new Query(AprDefectoCongenito.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprDefectoCongenitoCollection FetchByID(object IdDefectoCongenito)
        {
            AprDefectoCongenitoCollection coll = new AprDefectoCongenitoCollection().Where("idDefectoCongenito", IdDefectoCongenito).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprDefectoCongenitoCollection FetchByQuery(Query qry)
        {
            AprDefectoCongenitoCollection coll = new AprDefectoCongenitoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDefectoCongenito)
        {
            return (AprDefectoCongenito.Delete(IdDefectoCongenito) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDefectoCongenito)
        {
            return (AprDefectoCongenito.Destroy(IdDefectoCongenito) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprDefectoCongenito item = new AprDefectoCongenito();
		    
            item.Nombre = Nombre;
            
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
	    public void Update(int IdDefectoCongenito,string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprDefectoCongenito item = new AprDefectoCongenito();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDefectoCongenito = IdDefectoCongenito;
				
			item.Nombre = Nombre;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
