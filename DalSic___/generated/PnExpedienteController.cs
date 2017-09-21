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
    /// Controller class for PN_expediente
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnExpedienteController
    {
        // Preload our schema..
        PnExpediente thisSchemaLoad = new PnExpediente();
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
        public PnExpedienteCollection FetchAll()
        {
            PnExpedienteCollection coll = new PnExpedienteCollection();
            Query qry = new Query(PnExpediente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnExpedienteCollection FetchByID(object IdExpediente)
        {
            PnExpedienteCollection coll = new PnExpedienteCollection().Where("id_expediente", IdExpediente).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnExpedienteCollection FetchByQuery(Query qry)
        {
            PnExpedienteCollection coll = new PnExpedienteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdExpediente)
        {
            return (PnExpediente.Delete(IdExpediente) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdExpediente)
        {
            return (PnExpediente.Destroy(IdExpediente) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfeConv,string NroExp,DateTime? FechaIng,int? Monto)
	    {
		    PnExpediente item = new PnExpediente();
		    
            item.IdEfeConv = IdEfeConv;
            
            item.NroExp = NroExp;
            
            item.FechaIng = FechaIng;
            
            item.Monto = Monto;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdExpediente,int IdEfeConv,string NroExp,DateTime? FechaIng,int? Monto)
	    {
		    PnExpediente item = new PnExpediente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdExpediente = IdExpediente;
				
			item.IdEfeConv = IdEfeConv;
				
			item.NroExp = NroExp;
				
			item.FechaIng = FechaIng;
				
			item.Monto = Monto;
				
	        item.Save(UserName);
	    }
    }
}
