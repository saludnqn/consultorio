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
    /// Controller class for APR_TallaEdad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprTallaEdadController
    {
        // Preload our schema..
        AprTallaEdad thisSchemaLoad = new AprTallaEdad();
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
        public AprTallaEdadCollection FetchAll()
        {
            AprTallaEdadCollection coll = new AprTallaEdadCollection();
            Query qry = new Query(AprTallaEdad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTallaEdadCollection FetchByID(object IdTallaEdad)
        {
            AprTallaEdadCollection coll = new AprTallaEdadCollection().Where("idTallaEdad", IdTallaEdad).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTallaEdadCollection FetchByQuery(Query qry)
        {
            AprTallaEdadCollection coll = new AprTallaEdadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTallaEdad)
        {
            return (AprTallaEdad.Delete(IdTallaEdad) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTallaEdad)
        {
            return (AprTallaEdad.Destroy(IdTallaEdad) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprTallaEdad item = new AprTallaEdad();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTallaEdad,string Nombre)
	    {
		    AprTallaEdad item = new AprTallaEdad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTallaEdad = IdTallaEdad;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
