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
    /// Controller class for PN_feriados
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnFeriadoController
    {
        // Preload our schema..
        PnFeriado thisSchemaLoad = new PnFeriado();
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
        public PnFeriadoCollection FetchAll()
        {
            PnFeriadoCollection coll = new PnFeriadoCollection();
            Query qry = new Query(PnFeriado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnFeriadoCollection FetchByID(object IdFecha)
        {
            PnFeriadoCollection coll = new PnFeriadoCollection().Where("id_fecha", IdFecha).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnFeriadoCollection FetchByQuery(Query qry)
        {
            PnFeriadoCollection coll = new PnFeriadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFecha)
        {
            return (PnFeriado.Delete(IdFecha) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFecha)
        {
            return (PnFeriado.Destroy(IdFecha) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? Dia,int? Mes,int? Anio,string Descripcion)
	    {
		    PnFeriado item = new PnFeriado();
		    
            item.Dia = Dia;
            
            item.Mes = Mes;
            
            item.Anio = Anio;
            
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFecha,int? Dia,int? Mes,int? Anio,string Descripcion)
	    {
		    PnFeriado item = new PnFeriado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFecha = IdFecha;
				
			item.Dia = Dia;
				
			item.Mes = Mes;
				
			item.Anio = Anio;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
