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
    /// Controller class for CON_ConsultaOdontologia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConConsultaOdontologiumController
    {
        // Preload our schema..
        ConConsultaOdontologium thisSchemaLoad = new ConConsultaOdontologium();
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
        public ConConsultaOdontologiumCollection FetchAll()
        {
            ConConsultaOdontologiumCollection coll = new ConConsultaOdontologiumCollection();
            Query qry = new Query(ConConsultaOdontologium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultaOdontologiumCollection FetchByID(object IdConsultaOdontologia)
        {
            ConConsultaOdontologiumCollection coll = new ConConsultaOdontologiumCollection().Where("idConsultaOdontologia", IdConsultaOdontologia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultaOdontologiumCollection FetchByQuery(Query qry)
        {
            ConConsultaOdontologiumCollection coll = new ConConsultaOdontologiumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConsultaOdontologia)
        {
            return (ConConsultaOdontologium.Delete(IdConsultaOdontologia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConsultaOdontologia)
        {
            return (ConConsultaOdontologium.Destroy(IdConsultaOdontologia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdConsulta,int IdNomenclador,int Diente,bool CaraM,bool CaraP,bool CaraD,bool CaraO,bool CaraV,bool CaraL,int Cantidad)
	    {
		    ConConsultaOdontologium item = new ConConsultaOdontologium();
		    
            item.IdConsulta = IdConsulta;
            
            item.IdNomenclador = IdNomenclador;
            
            item.Diente = Diente;
            
            item.CaraM = CaraM;
            
            item.CaraP = CaraP;
            
            item.CaraD = CaraD;
            
            item.CaraO = CaraO;
            
            item.CaraV = CaraV;
            
            item.CaraL = CaraL;
            
            item.Cantidad = Cantidad;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConsultaOdontologia,int IdConsulta,int IdNomenclador,int Diente,bool CaraM,bool CaraP,bool CaraD,bool CaraO,bool CaraV,bool CaraL,int Cantidad)
	    {
		    ConConsultaOdontologium item = new ConConsultaOdontologium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConsultaOdontologia = IdConsultaOdontologia;
				
			item.IdConsulta = IdConsulta;
				
			item.IdNomenclador = IdNomenclador;
				
			item.Diente = Diente;
				
			item.CaraM = CaraM;
				
			item.CaraP = CaraP;
				
			item.CaraD = CaraD;
				
			item.CaraO = CaraO;
				
			item.CaraV = CaraV;
				
			item.CaraL = CaraL;
				
			item.Cantidad = Cantidad;
				
	        item.Save(UserName);
	    }
    }
}
