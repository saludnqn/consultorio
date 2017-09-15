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
    /// Controller class for Sys_HistoriaClinica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysHistoriaClinicaController
    {
        // Preload our schema..
        SysHistoriaClinica thisSchemaLoad = new SysHistoriaClinica();
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
        public SysHistoriaClinicaCollection FetchAll()
        {
            SysHistoriaClinicaCollection coll = new SysHistoriaClinicaCollection();
            Query qry = new Query(SysHistoriaClinica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysHistoriaClinicaCollection FetchByID(object IdHistoriaClinica)
        {
            SysHistoriaClinicaCollection coll = new SysHistoriaClinicaCollection().Where("idHistoriaClinica", IdHistoriaClinica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysHistoriaClinicaCollection FetchByQuery(Query qry)
        {
            SysHistoriaClinicaCollection coll = new SysHistoriaClinicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdHistoriaClinica)
        {
            return (SysHistoriaClinica.Delete(IdHistoriaClinica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdHistoriaClinica)
        {
            return (SysHistoriaClinica.Destroy(IdHistoriaClinica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdPaciente,int? IdEstadoHistoriaClinica,DateTime? FechaAlta,int? Numero)
	    {
		    SysHistoriaClinica item = new SysHistoriaClinica();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdEstadoHistoriaClinica = IdEstadoHistoriaClinica;
            
            item.FechaAlta = FechaAlta;
            
            item.Numero = Numero;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdHistoriaClinica,int? IdPaciente,int? IdEstadoHistoriaClinica,DateTime? FechaAlta,int? Numero)
	    {
		    SysHistoriaClinica item = new SysHistoriaClinica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdHistoriaClinica = IdHistoriaClinica;
				
			item.IdPaciente = IdPaciente;
				
			item.IdEstadoHistoriaClinica = IdEstadoHistoriaClinica;
				
			item.FechaAlta = FechaAlta;
				
			item.Numero = Numero;
				
	        item.Save(UserName);
	    }
    }
}
