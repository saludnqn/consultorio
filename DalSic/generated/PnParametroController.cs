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
    /// Controller class for PN_parametros
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnParametroController
    {
        // Preload our schema..
        PnParametro thisSchemaLoad = new PnParametro();
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
        public PnParametroCollection FetchAll()
        {
            PnParametroCollection coll = new PnParametroCollection();
            Query qry = new Query(PnParametro.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnParametroCollection FetchByID(object IdParametro)
        {
            PnParametroCollection coll = new PnParametroCollection().Where("id_parametro", IdParametro).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnParametroCollection FetchByQuery(Query qry)
        {
            PnParametroCollection coll = new PnParametroCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdParametro)
        {
            return (PnParametro.Delete(IdParametro) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdParametro)
        {
            return (PnParametro.Destroy(IdParametro) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Parametro,string Valor,string Comentario)
	    {
		    PnParametro item = new PnParametro();
		    
            item.Parametro = Parametro;
            
            item.Valor = Valor;
            
            item.Comentario = Comentario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Parametro,string Valor,string Comentario,int IdParametro)
	    {
		    PnParametro item = new PnParametro();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Parametro = Parametro;
				
			item.Valor = Valor;
				
			item.Comentario = Comentario;
				
			item.IdParametro = IdParametro;
				
	        item.Save(UserName);
	    }
    }
}
