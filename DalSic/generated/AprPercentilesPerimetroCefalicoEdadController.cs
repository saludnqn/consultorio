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
    /// Controller class for APR_PercentilesPerimetroCefalicoEdad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprPercentilesPerimetroCefalicoEdadController
    {
        // Preload our schema..
        AprPercentilesPerimetroCefalicoEdad thisSchemaLoad = new AprPercentilesPerimetroCefalicoEdad();
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
        public AprPercentilesPerimetroCefalicoEdadCollection FetchAll()
        {
            AprPercentilesPerimetroCefalicoEdadCollection coll = new AprPercentilesPerimetroCefalicoEdadCollection();
            Query qry = new Query(AprPercentilesPerimetroCefalicoEdad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprPercentilesPerimetroCefalicoEdadCollection FetchByID(object Id)
        {
            AprPercentilesPerimetroCefalicoEdadCollection coll = new AprPercentilesPerimetroCefalicoEdadCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprPercentilesPerimetroCefalicoEdadCollection FetchByQuery(Query qry)
        {
            AprPercentilesPerimetroCefalicoEdadCollection coll = new AprPercentilesPerimetroCefalicoEdadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AprPercentilesPerimetroCefalicoEdad.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AprPercentilesPerimetroCefalicoEdad.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Sexo,int Edad,decimal L,decimal M,decimal S,decimal P01,decimal P1,decimal P3,decimal P5,decimal P10,decimal P15,decimal P25,decimal P50,decimal P75,decimal P85,decimal P90,decimal P95,decimal P97,decimal P99,decimal P999)
	    {
		    AprPercentilesPerimetroCefalicoEdad item = new AprPercentilesPerimetroCefalicoEdad();
		    
            item.Sexo = Sexo;
            
            item.Edad = Edad;
            
            item.L = L;
            
            item.M = M;
            
            item.S = S;
            
            item.P01 = P01;
            
            item.P1 = P1;
            
            item.P3 = P3;
            
            item.P5 = P5;
            
            item.P10 = P10;
            
            item.P15 = P15;
            
            item.P25 = P25;
            
            item.P50 = P50;
            
            item.P75 = P75;
            
            item.P85 = P85;
            
            item.P90 = P90;
            
            item.P95 = P95;
            
            item.P97 = P97;
            
            item.P99 = P99;
            
            item.P999 = P999;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int Sexo,int Edad,decimal L,decimal M,decimal S,decimal P01,decimal P1,decimal P3,decimal P5,decimal P10,decimal P15,decimal P25,decimal P50,decimal P75,decimal P85,decimal P90,decimal P95,decimal P97,decimal P99,decimal P999)
	    {
		    AprPercentilesPerimetroCefalicoEdad item = new AprPercentilesPerimetroCefalicoEdad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Sexo = Sexo;
				
			item.Edad = Edad;
				
			item.L = L;
				
			item.M = M;
				
			item.S = S;
				
			item.P01 = P01;
				
			item.P1 = P1;
				
			item.P3 = P3;
				
			item.P5 = P5;
				
			item.P10 = P10;
				
			item.P15 = P15;
				
			item.P25 = P25;
				
			item.P50 = P50;
				
			item.P75 = P75;
				
			item.P85 = P85;
				
			item.P90 = P90;
				
			item.P95 = P95;
				
			item.P97 = P97;
				
			item.P99 = P99;
				
			item.P999 = P999;
				
	        item.Save(UserName);
	    }
    }
}
