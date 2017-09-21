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
    /// Controller class for PN_tipo_evento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTipoEventoController
    {
        // Preload our schema..
        PnTipoEvento thisSchemaLoad = new PnTipoEvento();
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
        public PnTipoEventoCollection FetchAll()
        {
            PnTipoEventoCollection coll = new PnTipoEventoCollection();
            Query qry = new Query(PnTipoEvento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTipoEventoCollection FetchByID(object IdTipoEvento)
        {
            PnTipoEventoCollection coll = new PnTipoEventoCollection().Where("id_tipo_evento", IdTipoEvento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTipoEventoCollection FetchByQuery(Query qry)
        {
            PnTipoEventoCollection coll = new PnTipoEventoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoEvento)
        {
            return (PnTipoEvento.Delete(IdTipoEvento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoEvento)
        {
            return (PnTipoEvento.Destroy(IdTipoEvento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TipoEvento)
	    {
		    PnTipoEvento item = new PnTipoEvento();
		    
            item.TipoEvento = TipoEvento;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoEvento,string TipoEvento)
	    {
		    PnTipoEvento item = new PnTipoEvento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoEvento = IdTipoEvento;
				
			item.TipoEvento = TipoEvento;
				
	        item.Save(UserName);
	    }
    }
}
