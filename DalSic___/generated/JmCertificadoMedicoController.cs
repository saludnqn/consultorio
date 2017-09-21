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
    /// Controller class for JM_CertificadoMedico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class JmCertificadoMedicoController
    {
        // Preload our schema..
        JmCertificadoMedico thisSchemaLoad = new JmCertificadoMedico();
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
        public JmCertificadoMedicoCollection FetchAll()
        {
            JmCertificadoMedicoCollection coll = new JmCertificadoMedicoCollection();
            Query qry = new Query(JmCertificadoMedico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public JmCertificadoMedicoCollection FetchByID(object IdCertificadoMedico)
        {
            JmCertificadoMedicoCollection coll = new JmCertificadoMedicoCollection().Where("idCertificadoMedico", IdCertificadoMedico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public JmCertificadoMedicoCollection FetchByQuery(Query qry)
        {
            JmCertificadoMedicoCollection coll = new JmCertificadoMedicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCertificadoMedico)
        {
            return (JmCertificadoMedico.Delete(IdCertificadoMedico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCertificadoMedico)
        {
            return (JmCertificadoMedico.Destroy(IdCertificadoMedico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string IdPersonal,DateTime? FechaCertificado,DateTime? FechaEntrega,DateTime? FechaDesde,DateTime? FechaHasta,string Diagnostico,string Observaciones,string MedicoCertificado,int? IdUsuarioCarga,DateTime? FechaCarga,int? IdMedicoAuditor,DateTime? FechaAuditoria,string Omologado,string IdLPago)
	    {
		    JmCertificadoMedico item = new JmCertificadoMedico();
		    
            item.IdPersonal = IdPersonal;
            
            item.FechaCertificado = FechaCertificado;
            
            item.FechaEntrega = FechaEntrega;
            
            item.FechaDesde = FechaDesde;
            
            item.FechaHasta = FechaHasta;
            
            item.Diagnostico = Diagnostico;
            
            item.Observaciones = Observaciones;
            
            item.MedicoCertificado = MedicoCertificado;
            
            item.IdUsuarioCarga = IdUsuarioCarga;
            
            item.FechaCarga = FechaCarga;
            
            item.IdMedicoAuditor = IdMedicoAuditor;
            
            item.FechaAuditoria = FechaAuditoria;
            
            item.Omologado = Omologado;
            
            item.IdLPago = IdLPago;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCertificadoMedico,string IdPersonal,DateTime? FechaCertificado,DateTime? FechaEntrega,DateTime? FechaDesde,DateTime? FechaHasta,string Diagnostico,string Observaciones,string MedicoCertificado,int? IdUsuarioCarga,DateTime? FechaCarga,int? IdMedicoAuditor,DateTime? FechaAuditoria,string Omologado,string IdLPago)
	    {
		    JmCertificadoMedico item = new JmCertificadoMedico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCertificadoMedico = IdCertificadoMedico;
				
			item.IdPersonal = IdPersonal;
				
			item.FechaCertificado = FechaCertificado;
				
			item.FechaEntrega = FechaEntrega;
				
			item.FechaDesde = FechaDesde;
				
			item.FechaHasta = FechaHasta;
				
			item.Diagnostico = Diagnostico;
				
			item.Observaciones = Observaciones;
				
			item.MedicoCertificado = MedicoCertificado;
				
			item.IdUsuarioCarga = IdUsuarioCarga;
				
			item.FechaCarga = FechaCarga;
				
			item.IdMedicoAuditor = IdMedicoAuditor;
				
			item.FechaAuditoria = FechaAuditoria;
				
			item.Omologado = Omologado;
				
			item.IdLPago = IdLPago;
				
	        item.Save(UserName);
	    }
    }
}
