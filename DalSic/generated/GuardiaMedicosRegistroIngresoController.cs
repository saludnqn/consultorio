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
    /// Controller class for Guardia_Medicos_registroIngreso
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaMedicosRegistroIngresoController
    {
        // Preload our schema..
        GuardiaMedicosRegistroIngreso thisSchemaLoad = new GuardiaMedicosRegistroIngreso();
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
        public GuardiaMedicosRegistroIngresoCollection FetchAll()
        {
            GuardiaMedicosRegistroIngresoCollection coll = new GuardiaMedicosRegistroIngresoCollection();
            Query qry = new Query(GuardiaMedicosRegistroIngreso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaMedicosRegistroIngresoCollection FetchByID(object Id)
        {
            GuardiaMedicosRegistroIngresoCollection coll = new GuardiaMedicosRegistroIngresoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaMedicosRegistroIngresoCollection FetchByQuery(Query qry)
        {
            GuardiaMedicosRegistroIngresoCollection coll = new GuardiaMedicosRegistroIngresoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaMedicosRegistroIngreso.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaMedicosRegistroIngreso.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUser,int IdMedico,DateTime FechaCreacion,DateTime FechaDesde,DateTime FechaHasta,DateTime FechaRecordatorio,bool FueImpresa,bool JobCreateMessage,int? IdVistaReceive)
	    {
		    GuardiaMedicosRegistroIngreso item = new GuardiaMedicosRegistroIngreso();
		    
            item.IdUser = IdUser;
            
            item.IdMedico = IdMedico;
            
            item.FechaCreacion = FechaCreacion;
            
            item.FechaDesde = FechaDesde;
            
            item.FechaHasta = FechaHasta;
            
            item.FechaRecordatorio = FechaRecordatorio;
            
            item.FueImpresa = FueImpresa;
            
            item.JobCreateMessage = JobCreateMessage;
            
            item.IdVistaReceive = IdVistaReceive;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int IdUser,int IdMedico,DateTime FechaCreacion,DateTime FechaDesde,DateTime FechaHasta,DateTime FechaRecordatorio,bool FueImpresa,bool JobCreateMessage,int? IdVistaReceive)
	    {
		    GuardiaMedicosRegistroIngreso item = new GuardiaMedicosRegistroIngreso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdUser = IdUser;
				
			item.IdMedico = IdMedico;
				
			item.FechaCreacion = FechaCreacion;
				
			item.FechaDesde = FechaDesde;
				
			item.FechaHasta = FechaHasta;
				
			item.FechaRecordatorio = FechaRecordatorio;
				
			item.FueImpresa = FueImpresa;
				
			item.JobCreateMessage = JobCreateMessage;
				
			item.IdVistaReceive = IdVistaReceive;
				
	        item.Save(UserName);
	    }
    }
}
