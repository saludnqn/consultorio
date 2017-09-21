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
    /// Controller class for APR_ZScorePesoEdad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprZScorePesoEdadController
    {
        // Preload our schema..
        AprZScorePesoEdad thisSchemaLoad = new AprZScorePesoEdad();
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
        public AprZScorePesoEdadCollection FetchAll()
        {
            AprZScorePesoEdadCollection coll = new AprZScorePesoEdadCollection();
            Query qry = new Query(AprZScorePesoEdad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprZScorePesoEdadCollection FetchByID(object Id)
        {
            AprZScorePesoEdadCollection coll = new AprZScorePesoEdadCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprZScorePesoEdadCollection FetchByQuery(Query qry)
        {
            AprZScorePesoEdadCollection coll = new AprZScorePesoEdadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AprZScorePesoEdad.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AprZScorePesoEdad.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? Sexo,int? Edad,decimal? SD4neg,decimal? SD3neg,decimal? SD2neg,decimal? SD1neg,decimal? SD0,decimal? SD1,decimal? SD2,decimal? SD3,decimal? SD4)
	    {
		    AprZScorePesoEdad item = new AprZScorePesoEdad();
		    
            item.Sexo = Sexo;
            
            item.Edad = Edad;
            
            item.SD4neg = SD4neg;
            
            item.SD3neg = SD3neg;
            
            item.SD2neg = SD2neg;
            
            item.SD1neg = SD1neg;
            
            item.SD0 = SD0;
            
            item.SD1 = SD1;
            
            item.SD2 = SD2;
            
            item.SD3 = SD3;
            
            item.SD4 = SD4;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? Sexo,int? Edad,decimal? SD4neg,decimal? SD3neg,decimal? SD2neg,decimal? SD1neg,decimal? SD0,decimal? SD1,decimal? SD2,decimal? SD3,decimal? SD4)
	    {
		    AprZScorePesoEdad item = new AprZScorePesoEdad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Sexo = Sexo;
				
			item.Edad = Edad;
				
			item.SD4neg = SD4neg;
				
			item.SD3neg = SD3neg;
				
			item.SD2neg = SD2neg;
				
			item.SD1neg = SD1neg;
				
			item.SD0 = SD0;
				
			item.SD1 = SD1;
				
			item.SD2 = SD2;
				
			item.SD3 = SD3;
				
			item.SD4 = SD4;
				
	        item.Save(UserName);
	    }
    }
}
