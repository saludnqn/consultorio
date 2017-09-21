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
    /// Controller class for LAB_ProtocoloScreeningDetalle
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabProtocoloScreeningDetalleController
    {
        // Preload our schema..
        LabProtocoloScreeningDetalle thisSchemaLoad = new LabProtocoloScreeningDetalle();
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
        public LabProtocoloScreeningDetalleCollection FetchAll()
        {
            LabProtocoloScreeningDetalleCollection coll = new LabProtocoloScreeningDetalleCollection();
            Query qry = new Query(LabProtocoloScreeningDetalle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabProtocoloScreeningDetalleCollection FetchByID(object IdProtocolo)
        {
            LabProtocoloScreeningDetalleCollection coll = new LabProtocoloScreeningDetalleCollection().Where("idProtocolo", IdProtocolo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabProtocoloScreeningDetalleCollection FetchByQuery(Query qry)
        {
            LabProtocoloScreeningDetalleCollection coll = new LabProtocoloScreeningDetalleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProtocolo)
        {
            return (LabProtocoloScreeningDetalle.Delete(IdProtocolo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProtocolo)
        {
            return (LabProtocoloScreeningDetalle.Destroy(IdProtocolo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdSolicitudScreening,DateTime? Fecha,decimal IdProtocoloHead)
	    {
		    LabProtocoloScreeningDetalle item = new LabProtocoloScreeningDetalle();
		    
            item.IdSolicitudScreening = IdSolicitudScreening;
            
            item.Fecha = Fecha;
            
            item.IdProtocoloHead = IdProtocoloHead;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(decimal IdProtocolo,int IdSolicitudScreening,DateTime? Fecha,decimal IdProtocoloHead)
	    {
		    LabProtocoloScreeningDetalle item = new LabProtocoloScreeningDetalle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProtocolo = IdProtocolo;
				
			item.IdSolicitudScreening = IdSolicitudScreening;
				
			item.Fecha = Fecha;
				
			item.IdProtocoloHead = IdProtocoloHead;
				
	        item.Save(UserName);
	    }
    }
}
