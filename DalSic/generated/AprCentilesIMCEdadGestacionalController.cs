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
    /// Controller class for APR_CentilesIMCEdadGestacional
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprCentilesIMCEdadGestacionalController
    {
        // Preload our schema..
        AprCentilesIMCEdadGestacional thisSchemaLoad = new AprCentilesIMCEdadGestacional();
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
        public AprCentilesIMCEdadGestacionalCollection FetchAll()
        {
            AprCentilesIMCEdadGestacionalCollection coll = new AprCentilesIMCEdadGestacionalCollection();
            Query qry = new Query(AprCentilesIMCEdadGestacional.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCentilesIMCEdadGestacionalCollection FetchByID(object Id)
        {
            AprCentilesIMCEdadGestacionalCollection coll = new AprCentilesIMCEdadGestacionalCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCentilesIMCEdadGestacionalCollection FetchByQuery(Query qry)
        {
            AprCentilesIMCEdadGestacionalCollection coll = new AprCentilesIMCEdadGestacionalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AprCentilesIMCEdadGestacional.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AprCentilesIMCEdadGestacional.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(decimal SemanasGestacion,decimal L,decimal M,decimal S,decimal C3,decimal C10,decimal C50,decimal C90,decimal C97)
	    {
		    AprCentilesIMCEdadGestacional item = new AprCentilesIMCEdadGestacional();
		    
            item.SemanasGestacion = SemanasGestacion;
            
            item.L = L;
            
            item.M = M;
            
            item.S = S;
            
            item.C3 = C3;
            
            item.C10 = C10;
            
            item.C50 = C50;
            
            item.C90 = C90;
            
            item.C97 = C97;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,decimal SemanasGestacion,decimal L,decimal M,decimal S,decimal C3,decimal C10,decimal C50,decimal C90,decimal C97)
	    {
		    AprCentilesIMCEdadGestacional item = new AprCentilesIMCEdadGestacional();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SemanasGestacion = SemanasGestacion;
				
			item.L = L;
				
			item.M = M;
				
			item.S = S;
				
			item.C3 = C3;
				
			item.C10 = C10;
				
			item.C50 = C50;
				
			item.C90 = C90;
				
			item.C97 = C97;
				
	        item.Save(UserName);
	    }
    }
}
