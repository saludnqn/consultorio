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
    /// Controller class for RIS_EstudioComiteEtica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioComiteEticaController
    {
        // Preload our schema..
        RisEstudioComiteEtica thisSchemaLoad = new RisEstudioComiteEtica();
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
        public RisEstudioComiteEticaCollection FetchAll()
        {
            RisEstudioComiteEticaCollection coll = new RisEstudioComiteEticaCollection();
            Query qry = new Query(RisEstudioComiteEtica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioComiteEticaCollection FetchByID(object IdEstudioComiteEtica)
        {
            RisEstudioComiteEticaCollection coll = new RisEstudioComiteEticaCollection().Where("idEstudioComiteEtica", IdEstudioComiteEtica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioComiteEticaCollection FetchByQuery(Query qry)
        {
            RisEstudioComiteEticaCollection coll = new RisEstudioComiteEticaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioComiteEtica)
        {
            return (RisEstudioComiteEtica.Delete(IdEstudioComiteEtica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioComiteEtica)
        {
            return (RisEstudioComiteEtica.Destroy(IdEstudioComiteEtica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,int IdComiteEtica,string Dictamen,DateTime FechaDictamen)
	    {
		    RisEstudioComiteEtica item = new RisEstudioComiteEtica();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdComiteEtica = IdComiteEtica;
            
            item.Dictamen = Dictamen;
            
            item.FechaDictamen = FechaDictamen;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioComiteEtica,int IdEstudio,int IdComiteEtica,string Dictamen,DateTime FechaDictamen)
	    {
		    RisEstudioComiteEtica item = new RisEstudioComiteEtica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioComiteEtica = IdEstudioComiteEtica;
				
			item.IdEstudio = IdEstudio;
				
			item.IdComiteEtica = IdComiteEtica;
				
			item.Dictamen = Dictamen;
				
			item.FechaDictamen = FechaDictamen;
				
	        item.Save(UserName);
	    }
    }
}
