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
    /// Controller class for PN_log_planilla
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLogPlanillaController
    {
        // Preload our schema..
        PnLogPlanilla thisSchemaLoad = new PnLogPlanilla();
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
        public PnLogPlanillaCollection FetchAll()
        {
            PnLogPlanillaCollection coll = new PnLogPlanillaCollection();
            Query qry = new Query(PnLogPlanilla.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogPlanillaCollection FetchByID(object IdLogPlanilla)
        {
            PnLogPlanillaCollection coll = new PnLogPlanillaCollection().Where("id_log_planilla", IdLogPlanilla).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogPlanillaCollection FetchByQuery(Query qry)
        {
            PnLogPlanillaCollection coll = new PnLogPlanillaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLogPlanilla)
        {
            return (PnLogPlanilla.Delete(IdLogPlanilla) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLogPlanilla)
        {
            return (PnLogPlanilla.Destroy(IdLogPlanilla) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPlanillas,string Descripcion,string Usuario,DateTime? Fecha)
	    {
		    PnLogPlanilla item = new PnLogPlanilla();
		    
            item.IdPlanillas = IdPlanillas;
            
            item.Descripcion = Descripcion;
            
            item.Usuario = Usuario;
            
            item.Fecha = Fecha;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLogPlanilla,int IdPlanillas,string Descripcion,string Usuario,DateTime? Fecha)
	    {
		    PnLogPlanilla item = new PnLogPlanilla();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLogPlanilla = IdLogPlanilla;
				
			item.IdPlanillas = IdPlanillas;
				
			item.Descripcion = Descripcion;
				
			item.Usuario = Usuario;
				
			item.Fecha = Fecha;
				
	        item.Save(UserName);
	    }
    }
}
