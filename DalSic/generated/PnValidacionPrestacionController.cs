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
    /// Controller class for PN_validacion_prestacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnValidacionPrestacionController
    {
        // Preload our schema..
        PnValidacionPrestacion thisSchemaLoad = new PnValidacionPrestacion();
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
        public PnValidacionPrestacionCollection FetchAll()
        {
            PnValidacionPrestacionCollection coll = new PnValidacionPrestacionCollection();
            Query qry = new Query(PnValidacionPrestacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnValidacionPrestacionCollection FetchByID(object IdValPres)
        {
            PnValidacionPrestacionCollection coll = new PnValidacionPrestacionCollection().Where("id_val_pres", IdValPres).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnValidacionPrestacionCollection FetchByQuery(Query qry)
        {
            PnValidacionPrestacionCollection coll = new PnValidacionPrestacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdValPres)
        {
            return (PnValidacionPrestacion.Delete(IdValPres) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdValPres)
        {
            return (PnValidacionPrestacion.Destroy(IdValPres) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Codigo,int? CantPresLim,int? PerPresLimite,string MsgError)
	    {
		    PnValidacionPrestacion item = new PnValidacionPrestacion();
		    
            item.Codigo = Codigo;
            
            item.CantPresLim = CantPresLim;
            
            item.PerPresLimite = PerPresLimite;
            
            item.MsgError = MsgError;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdValPres,string Codigo,int? CantPresLim,int? PerPresLimite,string MsgError)
	    {
		    PnValidacionPrestacion item = new PnValidacionPrestacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdValPres = IdValPres;
				
			item.Codigo = Codigo;
				
			item.CantPresLim = CantPresLim;
				
			item.PerPresLimite = PerPresLimite;
				
			item.MsgError = MsgError;
				
	        item.Save(UserName);
	    }
    }
}
