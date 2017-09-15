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
    /// Controller class for PN_suspensiones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnSuspensioneController
    {
        // Preload our schema..
        PnSuspensione thisSchemaLoad = new PnSuspensione();
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
        public PnSuspensioneCollection FetchAll()
        {
            PnSuspensioneCollection coll = new PnSuspensioneCollection();
            Query qry = new Query(PnSuspensione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSuspensioneCollection FetchByID(object IdSuspension)
        {
            PnSuspensioneCollection coll = new PnSuspensioneCollection().Where("id_suspension", IdSuspension).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSuspensioneCollection FetchByQuery(Query qry)
        {
            PnSuspensioneCollection coll = new PnSuspensioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSuspension)
        {
            return (PnSuspensione.Delete(IdSuspension) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSuspension)
        {
            return (PnSuspensione.Destroy(IdSuspension) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdLegajo,DateTime Fecha,string Motivo,short Dias)
	    {
		    PnSuspensione item = new PnSuspensione();
		    
            item.IdLegajo = IdLegajo;
            
            item.Fecha = Fecha;
            
            item.Motivo = Motivo;
            
            item.Dias = Dias;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSuspension,int IdLegajo,DateTime Fecha,string Motivo,short Dias)
	    {
		    PnSuspensione item = new PnSuspensione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSuspension = IdSuspension;
				
			item.IdLegajo = IdLegajo;
				
			item.Fecha = Fecha;
				
			item.Motivo = Motivo;
				
			item.Dias = Dias;
				
	        item.Save(UserName);
	    }
    }
}
