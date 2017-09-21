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
    /// Controller class for PN_log_evento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLogEventoController
    {
        // Preload our schema..
        PnLogEvento thisSchemaLoad = new PnLogEvento();
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
        public PnLogEventoCollection FetchAll()
        {
            PnLogEventoCollection coll = new PnLogEventoCollection();
            Query qry = new Query(PnLogEvento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogEventoCollection FetchByID(object IdLog)
        {
            PnLogEventoCollection coll = new PnLogEventoCollection().Where("id_log", IdLog).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogEventoCollection FetchByQuery(Query qry)
        {
            PnLogEventoCollection coll = new PnLogEventoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLog)
        {
            return (PnLogEvento.Delete(IdLog) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLog)
        {
            return (PnLogEvento.Destroy(IdLog) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEvento,string Usuario,DateTime? Fecha,string Comentario)
	    {
		    PnLogEvento item = new PnLogEvento();
		    
            item.IdEvento = IdEvento;
            
            item.Usuario = Usuario;
            
            item.Fecha = Fecha;
            
            item.Comentario = Comentario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLog,int IdEvento,string Usuario,DateTime? Fecha,string Comentario)
	    {
		    PnLogEvento item = new PnLogEvento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLog = IdLog;
				
			item.IdEvento = IdEvento;
				
			item.Usuario = Usuario;
				
			item.Fecha = Fecha;
				
			item.Comentario = Comentario;
				
	        item.Save(UserName);
	    }
    }
}
