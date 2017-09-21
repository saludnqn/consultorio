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
    /// Controller class for APR_PercentilesPesoEstatura
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprPercentilesPesoEstaturaController
    {
        // Preload our schema..
        AprPercentilesPesoEstatura thisSchemaLoad = new AprPercentilesPesoEstatura();
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
        public AprPercentilesPesoEstaturaCollection FetchAll()
        {
            AprPercentilesPesoEstaturaCollection coll = new AprPercentilesPesoEstaturaCollection();
            Query qry = new Query(AprPercentilesPesoEstatura.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprPercentilesPesoEstaturaCollection FetchByID(object Id)
        {
            AprPercentilesPesoEstaturaCollection coll = new AprPercentilesPesoEstaturaCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprPercentilesPesoEstaturaCollection FetchByQuery(Query qry)
        {
            AprPercentilesPesoEstaturaCollection coll = new AprPercentilesPesoEstaturaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AprPercentilesPesoEstatura.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AprPercentilesPesoEstatura.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Sexo,decimal Estatura,decimal P1,decimal P3,decimal P15,decimal P50,decimal P85,decimal P97,decimal P99)
	    {
		    AprPercentilesPesoEstatura item = new AprPercentilesPesoEstatura();
		    
            item.Sexo = Sexo;
            
            item.Estatura = Estatura;
            
            item.P1 = P1;
            
            item.P3 = P3;
            
            item.P15 = P15;
            
            item.P50 = P50;
            
            item.P85 = P85;
            
            item.P97 = P97;
            
            item.P99 = P99;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int Sexo,decimal Estatura,decimal P1,decimal P3,decimal P15,decimal P50,decimal P85,decimal P97,decimal P99)
	    {
		    AprPercentilesPesoEstatura item = new AprPercentilesPesoEstatura();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Sexo = Sexo;
				
			item.Estatura = Estatura;
				
			item.P1 = P1;
				
			item.P3 = P3;
				
			item.P15 = P15;
				
			item.P50 = P50;
				
			item.P85 = P85;
				
			item.P97 = P97;
				
			item.P99 = P99;
				
	        item.Save(UserName);
	    }
    }
}
