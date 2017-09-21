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
    /// Controller class for APR_FactorRiesgoEstiloVida
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprFactorRiesgoEstiloVidaController
    {
        // Preload our schema..
        AprFactorRiesgoEstiloVida thisSchemaLoad = new AprFactorRiesgoEstiloVida();
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
        public AprFactorRiesgoEstiloVidaCollection FetchAll()
        {
            AprFactorRiesgoEstiloVidaCollection coll = new AprFactorRiesgoEstiloVidaCollection();
            Query qry = new Query(AprFactorRiesgoEstiloVida.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFactorRiesgoEstiloVidaCollection FetchByID(object IdFactorRiesgoEstiloVida)
        {
            AprFactorRiesgoEstiloVidaCollection coll = new AprFactorRiesgoEstiloVidaCollection().Where("idFactorRiesgoEstiloVida", IdFactorRiesgoEstiloVida).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFactorRiesgoEstiloVidaCollection FetchByQuery(Query qry)
        {
            AprFactorRiesgoEstiloVidaCollection coll = new AprFactorRiesgoEstiloVidaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFactorRiesgoEstiloVida)
        {
            return (AprFactorRiesgoEstiloVida.Delete(IdFactorRiesgoEstiloVida) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFactorRiesgoEstiloVida)
        {
            return (AprFactorRiesgoEstiloVida.Destroy(IdFactorRiesgoEstiloVida) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprFactorRiesgoEstiloVida item = new AprFactorRiesgoEstiloVida();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFactorRiesgoEstiloVida,string Nombre)
	    {
		    AprFactorRiesgoEstiloVida item = new AprFactorRiesgoEstiloVida();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFactorRiesgoEstiloVida = IdFactorRiesgoEstiloVida;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
