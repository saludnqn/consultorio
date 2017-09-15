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
    /// Controller class for APR_EstiloVida
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprEstiloVidaController
    {
        // Preload our schema..
        AprEstiloVida thisSchemaLoad = new AprEstiloVida();
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
        public AprEstiloVidaCollection FetchAll()
        {
            AprEstiloVidaCollection coll = new AprEstiloVidaCollection();
            Query qry = new Query(AprEstiloVida.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEstiloVidaCollection FetchByID(object IdEstiloVida)
        {
            AprEstiloVidaCollection coll = new AprEstiloVidaCollection().Where("idEstiloVida", IdEstiloVida).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEstiloVidaCollection FetchByQuery(Query qry)
        {
            AprEstiloVidaCollection coll = new AprEstiloVidaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstiloVida)
        {
            return (AprEstiloVida.Delete(IdEstiloVida) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstiloVida)
        {
            return (AprEstiloVida.Destroy(IdEstiloVida) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdEmbarazo,DateTime Fecha,int Trimestre,int IdFactorRiesgoEstiloVida)
	    {
		    AprEstiloVida item = new AprEstiloVida();
		    
            item.IdEfector = IdEfector;
            
            item.IdEmbarazo = IdEmbarazo;
            
            item.Fecha = Fecha;
            
            item.Trimestre = Trimestre;
            
            item.IdFactorRiesgoEstiloVida = IdFactorRiesgoEstiloVida;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstiloVida,int IdEfector,int IdEmbarazo,DateTime Fecha,int Trimestre,int IdFactorRiesgoEstiloVida)
	    {
		    AprEstiloVida item = new AprEstiloVida();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstiloVida = IdEstiloVida;
				
			item.IdEfector = IdEfector;
				
			item.IdEmbarazo = IdEmbarazo;
				
			item.Fecha = Fecha;
				
			item.Trimestre = Trimestre;
				
			item.IdFactorRiesgoEstiloVida = IdFactorRiesgoEstiloVida;
				
	        item.Save(UserName);
	    }
    }
}
