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
    /// Controller class for PN_transaccion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTransaccionController
    {
        // Preload our schema..
        PnTransaccion thisSchemaLoad = new PnTransaccion();
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
        public PnTransaccionCollection FetchAll()
        {
            PnTransaccionCollection coll = new PnTransaccionCollection();
            Query qry = new Query(PnTransaccion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTransaccionCollection FetchByID(object IdTransac)
        {
            PnTransaccionCollection coll = new PnTransaccionCollection().Where("id_transac", IdTransac).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTransaccionCollection FetchByQuery(Query qry)
        {
            PnTransaccionCollection coll = new PnTransaccionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTransac)
        {
            return (PnTransaccion.Delete(IdTransac) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTransac)
        {
            return (PnTransaccion.Destroy(IdTransac) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(long IdExpediente,int IdArea,DateTime? FechaMov,string Estado,string Comentario,int? DebCred,long? NumTranf,DateTime? FechaInf)
	    {
		    PnTransaccion item = new PnTransaccion();
		    
            item.IdExpediente = IdExpediente;
            
            item.IdArea = IdArea;
            
            item.FechaMov = FechaMov;
            
            item.Estado = Estado;
            
            item.Comentario = Comentario;
            
            item.DebCred = DebCred;
            
            item.NumTranf = NumTranf;
            
            item.FechaInf = FechaInf;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTransac,long IdExpediente,int IdArea,DateTime? FechaMov,string Estado,string Comentario,int? DebCred,long? NumTranf,DateTime? FechaInf)
	    {
		    PnTransaccion item = new PnTransaccion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTransac = IdTransac;
				
			item.IdExpediente = IdExpediente;
				
			item.IdArea = IdArea;
				
			item.FechaMov = FechaMov;
				
			item.Estado = Estado;
				
			item.Comentario = Comentario;
				
			item.DebCred = DebCred;
				
			item.NumTranf = NumTranf;
				
			item.FechaInf = FechaInf;
				
	        item.Save(UserName);
	    }
    }
}
