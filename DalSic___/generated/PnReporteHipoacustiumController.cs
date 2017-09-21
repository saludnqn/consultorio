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
    /// Controller class for PN_reporte_hipoacustia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnReporteHipoacustiumController
    {
        // Preload our schema..
        PnReporteHipoacustium thisSchemaLoad = new PnReporteHipoacustium();
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
        public PnReporteHipoacustiumCollection FetchAll()
        {
            PnReporteHipoacustiumCollection coll = new PnReporteHipoacustiumCollection();
            Query qry = new Query(PnReporteHipoacustium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnReporteHipoacustiumCollection FetchByID(object IdReporteHipoacustia)
        {
            PnReporteHipoacustiumCollection coll = new PnReporteHipoacustiumCollection().Where("id_reporte_hipoacustia", IdReporteHipoacustia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnReporteHipoacustiumCollection FetchByQuery(Query qry)
        {
            PnReporteHipoacustiumCollection coll = new PnReporteHipoacustiumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdReporteHipoacustia)
        {
            return (PnReporteHipoacustium.Delete(IdReporteHipoacustia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdReporteHipoacustia)
        {
            return (PnReporteHipoacustium.Destroy(IdReporteHipoacustia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPrestacion,string OidoD,string OidoI,string GradoHipo)
	    {
		    PnReporteHipoacustium item = new PnReporteHipoacustium();
		    
            item.IdPrestacion = IdPrestacion;
            
            item.OidoD = OidoD;
            
            item.OidoI = OidoI;
            
            item.GradoHipo = GradoHipo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdReporteHipoacustia,int IdPrestacion,string OidoD,string OidoI,string GradoHipo)
	    {
		    PnReporteHipoacustium item = new PnReporteHipoacustium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdReporteHipoacustia = IdReporteHipoacustia;
				
			item.IdPrestacion = IdPrestacion;
				
			item.OidoD = OidoD;
				
			item.OidoI = OidoI;
				
			item.GradoHipo = GradoHipo;
				
	        item.Save(UserName);
	    }
    }
}
