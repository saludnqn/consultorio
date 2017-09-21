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
    /// Controller class for Sys_RelHistoriaClinicaEfector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelHistoriaClinicaEfectorController
    {
        // Preload our schema..
        SysRelHistoriaClinicaEfector thisSchemaLoad = new SysRelHistoriaClinicaEfector();
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
        public SysRelHistoriaClinicaEfectorCollection FetchAll()
        {
            SysRelHistoriaClinicaEfectorCollection coll = new SysRelHistoriaClinicaEfectorCollection();
            Query qry = new Query(SysRelHistoriaClinicaEfector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelHistoriaClinicaEfectorCollection FetchByID(object IdRelHistoriaClinicaEfector)
        {
            SysRelHistoriaClinicaEfectorCollection coll = new SysRelHistoriaClinicaEfectorCollection().Where("idRelHistoriaClinicaEfector", IdRelHistoriaClinicaEfector).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelHistoriaClinicaEfectorCollection FetchByQuery(Query qry)
        {
            SysRelHistoriaClinicaEfectorCollection coll = new SysRelHistoriaClinicaEfectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelHistoriaClinicaEfector)
        {
            return (SysRelHistoriaClinicaEfector.Delete(IdRelHistoriaClinicaEfector) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelHistoriaClinicaEfector)
        {
            return (SysRelHistoriaClinicaEfector.Destroy(IdRelHistoriaClinicaEfector) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,int HistoriaClinica,string IdUsuarioRegistro,DateTime FechaRegistro)
	    {
		    SysRelHistoriaClinicaEfector item = new SysRelHistoriaClinicaEfector();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.HistoriaClinica = HistoriaClinica;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelHistoriaClinicaEfector,int IdEfector,int IdPaciente,int HistoriaClinica,string IdUsuarioRegistro,DateTime FechaRegistro)
	    {
		    SysRelHistoriaClinicaEfector item = new SysRelHistoriaClinicaEfector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelHistoriaClinicaEfector = IdRelHistoriaClinicaEfector;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.HistoriaClinica = HistoriaClinica;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
	        item.Save(UserName);
	    }
    }
}
