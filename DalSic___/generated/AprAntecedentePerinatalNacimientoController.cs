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
    /// Controller class for APR_AntecedentePerinatalNacimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAntecedentePerinatalNacimientoController
    {
        // Preload our schema..
        AprAntecedentePerinatalNacimiento thisSchemaLoad = new AprAntecedentePerinatalNacimiento();
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
        public AprAntecedentePerinatalNacimientoCollection FetchAll()
        {
            AprAntecedentePerinatalNacimientoCollection coll = new AprAntecedentePerinatalNacimientoCollection();
            Query qry = new Query(AprAntecedentePerinatalNacimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAntecedentePerinatalNacimientoCollection FetchByID(object IdAntecedentePerinatalNacimiento)
        {
            AprAntecedentePerinatalNacimientoCollection coll = new AprAntecedentePerinatalNacimientoCollection().Where("idAntecedentePerinatalNacimiento", IdAntecedentePerinatalNacimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAntecedentePerinatalNacimientoCollection FetchByQuery(Query qry)
        {
            AprAntecedentePerinatalNacimientoCollection coll = new AprAntecedentePerinatalNacimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAntecedentePerinatalNacimiento)
        {
            return (AprAntecedentePerinatalNacimiento.Delete(IdAntecedentePerinatalNacimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAntecedentePerinatalNacimiento)
        {
            return (AprAntecedentePerinatalNacimiento.Destroy(IdAntecedentePerinatalNacimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdAntecedentePerinatal,double Peso,bool NacidoVivo,DateTime? FechaFallecimiento)
	    {
		    AprAntecedentePerinatalNacimiento item = new AprAntecedentePerinatalNacimiento();
		    
            item.IdEfector = IdEfector;
            
            item.IdAntecedentePerinatal = IdAntecedentePerinatal;
            
            item.Peso = Peso;
            
            item.NacidoVivo = NacidoVivo;
            
            item.FechaFallecimiento = FechaFallecimiento;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAntecedentePerinatalNacimiento,int IdEfector,int IdAntecedentePerinatal,double Peso,bool NacidoVivo,DateTime? FechaFallecimiento)
	    {
		    AprAntecedentePerinatalNacimiento item = new AprAntecedentePerinatalNacimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAntecedentePerinatalNacimiento = IdAntecedentePerinatalNacimiento;
				
			item.IdEfector = IdEfector;
				
			item.IdAntecedentePerinatal = IdAntecedentePerinatal;
				
			item.Peso = Peso;
				
			item.NacidoVivo = NacidoVivo;
				
			item.FechaFallecimiento = FechaFallecimiento;
				
	        item.Save(UserName);
	    }
    }
}
