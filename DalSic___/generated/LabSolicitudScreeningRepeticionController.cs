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
    /// Controller class for LAB_SolicitudScreeningRepeticion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabSolicitudScreeningRepeticionController
    {
        // Preload our schema..
        LabSolicitudScreeningRepeticion thisSchemaLoad = new LabSolicitudScreeningRepeticion();
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
        public LabSolicitudScreeningRepeticionCollection FetchAll()
        {
            LabSolicitudScreeningRepeticionCollection coll = new LabSolicitudScreeningRepeticionCollection();
            Query qry = new Query(LabSolicitudScreeningRepeticion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSolicitudScreeningRepeticionCollection FetchByID(object IdSolicitudScreeningRepeticion)
        {
            LabSolicitudScreeningRepeticionCollection coll = new LabSolicitudScreeningRepeticionCollection().Where("idSolicitudScreeningRepeticion", IdSolicitudScreeningRepeticion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSolicitudScreeningRepeticionCollection FetchByQuery(Query qry)
        {
            LabSolicitudScreeningRepeticionCollection coll = new LabSolicitudScreeningRepeticionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSolicitudScreeningRepeticion)
        {
            return (LabSolicitudScreeningRepeticion.Delete(IdSolicitudScreeningRepeticion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSolicitudScreeningRepeticion)
        {
            return (LabSolicitudScreeningRepeticion.Destroy(IdSolicitudScreeningRepeticion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdSolicitudScreening,int IdMotivoRepeticion,DateTime FechaAlta,int? IdUsuarioRegistro)
	    {
		    LabSolicitudScreeningRepeticion item = new LabSolicitudScreeningRepeticion();
		    
            item.IdSolicitudScreening = IdSolicitudScreening;
            
            item.IdMotivoRepeticion = IdMotivoRepeticion;
            
            item.FechaAlta = FechaAlta;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSolicitudScreeningRepeticion,int IdSolicitudScreening,int IdMotivoRepeticion,DateTime FechaAlta,int? IdUsuarioRegistro)
	    {
		    LabSolicitudScreeningRepeticion item = new LabSolicitudScreeningRepeticion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSolicitudScreeningRepeticion = IdSolicitudScreeningRepeticion;
				
			item.IdSolicitudScreening = IdSolicitudScreening;
				
			item.IdMotivoRepeticion = IdMotivoRepeticion;
				
			item.FechaAlta = FechaAlta;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
	        item.Save(UserName);
	    }
    }
}
