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
    /// Controller class for APR_EgresoMaterno
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprEgresoMaternoController
    {
        // Preload our schema..
        AprEgresoMaterno thisSchemaLoad = new AprEgresoMaterno();
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
        public AprEgresoMaternoCollection FetchAll()
        {
            AprEgresoMaternoCollection coll = new AprEgresoMaternoCollection();
            Query qry = new Query(AprEgresoMaterno.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEgresoMaternoCollection FetchByID(object IdEgresoMaterno)
        {
            AprEgresoMaternoCollection coll = new AprEgresoMaternoCollection().Where("idEgresoMaterno", IdEgresoMaterno).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEgresoMaternoCollection FetchByQuery(Query qry)
        {
            AprEgresoMaternoCollection coll = new AprEgresoMaternoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEgresoMaterno)
        {
            return (AprEgresoMaterno.Delete(IdEgresoMaterno) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEgresoMaterno)
        {
            return (AprEgresoMaterno.Destroy(IdEgresoMaterno) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int? IdEmbarazo,DateTime? FechaHora,int? IdTraslado,int? IdEstadoEgreso,string Responsable,bool? ConsejeriaAntiConcepcion,int? IdMetodoAnticonceptivoElegido)
	    {
		    AprEgresoMaterno item = new AprEgresoMaterno();
		    
            item.IdEfector = IdEfector;
            
            item.IdEmbarazo = IdEmbarazo;
            
            item.FechaHora = FechaHora;
            
            item.IdTraslado = IdTraslado;
            
            item.IdEstadoEgreso = IdEstadoEgreso;
            
            item.Responsable = Responsable;
            
            item.ConsejeriaAntiConcepcion = ConsejeriaAntiConcepcion;
            
            item.IdMetodoAnticonceptivoElegido = IdMetodoAnticonceptivoElegido;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEgresoMaterno,int IdEfector,int? IdEmbarazo,DateTime? FechaHora,int? IdTraslado,int? IdEstadoEgreso,string Responsable,bool? ConsejeriaAntiConcepcion,int? IdMetodoAnticonceptivoElegido)
	    {
		    AprEgresoMaterno item = new AprEgresoMaterno();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEgresoMaterno = IdEgresoMaterno;
				
			item.IdEfector = IdEfector;
				
			item.IdEmbarazo = IdEmbarazo;
				
			item.FechaHora = FechaHora;
				
			item.IdTraslado = IdTraslado;
				
			item.IdEstadoEgreso = IdEstadoEgreso;
				
			item.Responsable = Responsable;
				
			item.ConsejeriaAntiConcepcion = ConsejeriaAntiConcepcion;
				
			item.IdMetodoAnticonceptivoElegido = IdMetodoAnticonceptivoElegido;
				
	        item.Save(UserName);
	    }
    }
}
