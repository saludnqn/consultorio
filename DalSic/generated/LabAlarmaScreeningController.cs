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
    /// Controller class for LAB_AlarmaScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabAlarmaScreeningController
    {
        // Preload our schema..
        LabAlarmaScreening thisSchemaLoad = new LabAlarmaScreening();
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
        public LabAlarmaScreeningCollection FetchAll()
        {
            LabAlarmaScreeningCollection coll = new LabAlarmaScreeningCollection();
            Query qry = new Query(LabAlarmaScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabAlarmaScreeningCollection FetchByID(object IdAlarmaScreening)
        {
            LabAlarmaScreeningCollection coll = new LabAlarmaScreeningCollection().Where("idAlarmaScreening", IdAlarmaScreening).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabAlarmaScreeningCollection FetchByQuery(Query qry)
        {
            LabAlarmaScreeningCollection coll = new LabAlarmaScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAlarmaScreening)
        {
            return (LabAlarmaScreening.Delete(IdAlarmaScreening) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAlarmaScreening)
        {
            return (LabAlarmaScreening.Destroy(IdAlarmaScreening) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdSolicitudScreening,string Descripcion,int IdUsuarioRegistro,DateTime FechaRegistro)
	    {
		    LabAlarmaScreening item = new LabAlarmaScreening();
		    
            item.IdSolicitudScreening = IdSolicitudScreening;
            
            item.Descripcion = Descripcion;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAlarmaScreening,int IdSolicitudScreening,string Descripcion,int IdUsuarioRegistro,DateTime FechaRegistro)
	    {
		    LabAlarmaScreening item = new LabAlarmaScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAlarmaScreening = IdAlarmaScreening;
				
			item.IdSolicitudScreening = IdSolicitudScreening;
				
			item.Descripcion = Descripcion;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
	        item.Save(UserName);
	    }
    }
}
