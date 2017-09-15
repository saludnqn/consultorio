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
    /// Controller class for PN_capacitados
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCapacitadoController
    {
        // Preload our schema..
        PnCapacitado thisSchemaLoad = new PnCapacitado();
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
        public PnCapacitadoCollection FetchAll()
        {
            PnCapacitadoCollection coll = new PnCapacitadoCollection();
            Query qry = new Query(PnCapacitado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCapacitadoCollection FetchByID(object IdLegajo)
        {
            PnCapacitadoCollection coll = new PnCapacitadoCollection().Where("id_legajo", IdLegajo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCapacitadoCollection FetchByQuery(Query qry)
        {
            PnCapacitadoCollection coll = new PnCapacitadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLegajo)
        {
            return (PnCapacitado.Delete(IdLegajo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLegajo)
        {
            return (PnCapacitado.Destroy(IdLegajo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdCapacitacion,short? Calificacion,string Calificador,DateTime? FechaCalificacion)
	    {
		    PnCapacitado item = new PnCapacitado();
		    
            item.IdCapacitacion = IdCapacitacion;
            
            item.Calificacion = Calificacion;
            
            item.Calificador = Calificador;
            
            item.FechaCalificacion = FechaCalificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLegajo,int IdCapacitacion,short? Calificacion,string Calificador,DateTime? FechaCalificacion)
	    {
		    PnCapacitado item = new PnCapacitado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLegajo = IdLegajo;
				
			item.IdCapacitacion = IdCapacitacion;
				
			item.Calificacion = Calificacion;
				
			item.Calificador = Calificador;
				
			item.FechaCalificacion = FechaCalificacion;
				
	        item.Save(UserName);
	    }
    }
}
