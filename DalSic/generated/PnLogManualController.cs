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
    /// Controller class for PN_log_manual
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLogManualController
    {
        // Preload our schema..
        PnLogManual thisSchemaLoad = new PnLogManual();
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
        public PnLogManualCollection FetchAll()
        {
            PnLogManualCollection coll = new PnLogManualCollection();
            Query qry = new Query(PnLogManual.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogManualCollection FetchByID(object IdLogManual)
        {
            PnLogManualCollection coll = new PnLogManualCollection().Where("id_log_manual", IdLogManual).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogManualCollection FetchByQuery(Query qry)
        {
            PnLogManualCollection coll = new PnLogManualCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLogManual)
        {
            return (PnLogManual.Delete(IdLogManual) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLogManual)
        {
            return (PnLogManual.Destroy(IdLogManual) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdManual,DateTime? Fecha,string Usuario,string Tipo)
	    {
		    PnLogManual item = new PnLogManual();
		    
            item.IdManual = IdManual;
            
            item.Fecha = Fecha;
            
            item.Usuario = Usuario;
            
            item.Tipo = Tipo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLogManual,int IdManual,DateTime? Fecha,string Usuario,string Tipo)
	    {
		    PnLogManual item = new PnLogManual();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLogManual = IdLogManual;
				
			item.IdManual = IdManual;
				
			item.Fecha = Fecha;
				
			item.Usuario = Usuario;
				
			item.Tipo = Tipo;
				
	        item.Save(UserName);
	    }
    }
}
