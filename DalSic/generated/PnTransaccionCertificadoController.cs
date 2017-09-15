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
    /// Controller class for PN_transaccion_certificado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTransaccionCertificadoController
    {
        // Preload our schema..
        PnTransaccionCertificado thisSchemaLoad = new PnTransaccionCertificado();
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
        public PnTransaccionCertificadoCollection FetchAll()
        {
            PnTransaccionCertificadoCollection coll = new PnTransaccionCertificadoCollection();
            Query qry = new Query(PnTransaccionCertificado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTransaccionCertificadoCollection FetchByID(object IdTransaccionCertificado)
        {
            PnTransaccionCertificadoCollection coll = new PnTransaccionCertificadoCollection().Where("id_transaccion_certificado", IdTransaccionCertificado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTransaccionCertificadoCollection FetchByQuery(Query qry)
        {
            PnTransaccionCertificadoCollection coll = new PnTransaccionCertificadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTransaccionCertificado)
        {
            return (PnTransaccionCertificado.Delete(IdTransaccionCertificado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTransaccionCertificado)
        {
            return (PnTransaccionCertificado.Destroy(IdTransaccionCertificado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdSmiafiliados,string Usuario,DateTime? Fecha,string Ipmaquina,int? IdBeneficiarios)
	    {
		    PnTransaccionCertificado item = new PnTransaccionCertificado();
		    
            item.IdSmiafiliados = IdSmiafiliados;
            
            item.Usuario = Usuario;
            
            item.Fecha = Fecha;
            
            item.Ipmaquina = Ipmaquina;
            
            item.IdBeneficiarios = IdBeneficiarios;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTransaccionCertificado,int? IdSmiafiliados,string Usuario,DateTime? Fecha,string Ipmaquina,int? IdBeneficiarios)
	    {
		    PnTransaccionCertificado item = new PnTransaccionCertificado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTransaccionCertificado = IdTransaccionCertificado;
				
			item.IdSmiafiliados = IdSmiafiliados;
				
			item.Usuario = Usuario;
				
			item.Fecha = Fecha;
				
			item.Ipmaquina = Ipmaquina;
				
			item.IdBeneficiarios = IdBeneficiarios;
				
	        item.Save(UserName);
	    }
    }
}
