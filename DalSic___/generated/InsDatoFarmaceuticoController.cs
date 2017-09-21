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
    /// Controller class for INS_DatoFarmaceutico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsDatoFarmaceuticoController
    {
        // Preload our schema..
        InsDatoFarmaceutico thisSchemaLoad = new InsDatoFarmaceutico();
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
        public InsDatoFarmaceuticoCollection FetchAll()
        {
            InsDatoFarmaceuticoCollection coll = new InsDatoFarmaceuticoCollection();
            Query qry = new Query(InsDatoFarmaceutico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDatoFarmaceuticoCollection FetchByID(object IdDatoFarmaceutico)
        {
            InsDatoFarmaceuticoCollection coll = new InsDatoFarmaceuticoCollection().Where("idDatoFarmaceutico", IdDatoFarmaceutico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDatoFarmaceuticoCollection FetchByQuery(Query qry)
        {
            InsDatoFarmaceuticoCollection coll = new InsDatoFarmaceuticoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDatoFarmaceutico)
        {
            return (InsDatoFarmaceutico.Delete(IdDatoFarmaceutico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDatoFarmaceutico)
        {
            return (InsDatoFarmaceutico.Destroy(IdDatoFarmaceutico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdInsumo,string CodigoOMS,int NivelComplejidad,string Composicion,string Contraindicaciones,string AccionTerapeutica,bool NecesitaReceta,int IdEfector,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDatoFarmaceutico item = new InsDatoFarmaceutico();
		    
            item.IdInsumo = IdInsumo;
            
            item.CodigoOMS = CodigoOMS;
            
            item.NivelComplejidad = NivelComplejidad;
            
            item.Composicion = Composicion;
            
            item.Contraindicaciones = Contraindicaciones;
            
            item.AccionTerapeutica = AccionTerapeutica;
            
            item.NecesitaReceta = NecesitaReceta;
            
            item.IdEfector = IdEfector;
            
            item.Baja = Baja;
            
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
	    public void Update(int IdDatoFarmaceutico,int IdInsumo,string CodigoOMS,int NivelComplejidad,string Composicion,string Contraindicaciones,string AccionTerapeutica,bool NecesitaReceta,int IdEfector,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDatoFarmaceutico item = new InsDatoFarmaceutico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDatoFarmaceutico = IdDatoFarmaceutico;
				
			item.IdInsumo = IdInsumo;
				
			item.CodigoOMS = CodigoOMS;
				
			item.NivelComplejidad = NivelComplejidad;
				
			item.Composicion = Composicion;
				
			item.Contraindicaciones = Contraindicaciones;
				
			item.AccionTerapeutica = AccionTerapeutica;
				
			item.NecesitaReceta = NecesitaReceta;
				
			item.IdEfector = IdEfector;
				
			item.Baja = Baja;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
