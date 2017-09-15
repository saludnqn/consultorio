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
    /// Controller class for PN_evaluadores
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEvaluadoreController
    {
        // Preload our schema..
        PnEvaluadore thisSchemaLoad = new PnEvaluadore();
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
        public PnEvaluadoreCollection FetchAll()
        {
            PnEvaluadoreCollection coll = new PnEvaluadoreCollection();
            Query qry = new Query(PnEvaluadore.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEvaluadoreCollection FetchByID(object IdEvaluador)
        {
            PnEvaluadoreCollection coll = new PnEvaluadoreCollection().Where("id_evaluador", IdEvaluador).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEvaluadoreCollection FetchByQuery(Query qry)
        {
            PnEvaluadoreCollection coll = new PnEvaluadoreCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEvaluador)
        {
            return (PnEvaluadore.Delete(IdEvaluador) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEvaluador)
        {
            return (PnEvaluadore.Destroy(IdEvaluador) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdUsuario)
	    {
		    PnEvaluadore item = new PnEvaluadore();
		    
            item.IdUsuario = IdUsuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEvaluador,int? IdUsuario)
	    {
		    PnEvaluadore item = new PnEvaluadore();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEvaluador = IdEvaluador;
				
			item.IdUsuario = IdUsuario;
				
	        item.Save(UserName);
	    }
    }
}
