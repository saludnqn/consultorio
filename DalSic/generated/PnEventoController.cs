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
    /// Controller class for PN_evento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEventoController
    {
        // Preload our schema..
        PnEvento thisSchemaLoad = new PnEvento();
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
        public PnEventoCollection FetchAll()
        {
            PnEventoCollection coll = new PnEventoCollection();
            Query qry = new Query(PnEvento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEventoCollection FetchByID(object IdEvento)
        {
            PnEventoCollection coll = new PnEventoCollection().Where("id_evento", IdEvento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEventoCollection FetchByQuery(Query qry)
        {
            PnEventoCollection coll = new PnEventoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEvento)
        {
            return (PnEvento.Delete(IdEvento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEvento)
        {
            return (PnEvento.Destroy(IdEvento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdTipoEvento,string Area,string Suseso,short? Estado,string Medida)
	    {
		    PnEvento item = new PnEvento();
		    
            item.IdTipoEvento = IdTipoEvento;
            
            item.Area = Area;
            
            item.Suseso = Suseso;
            
            item.Estado = Estado;
            
            item.Medida = Medida;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEvento,int IdTipoEvento,string Area,string Suseso,short? Estado,string Medida)
	    {
		    PnEvento item = new PnEvento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEvento = IdEvento;
				
			item.IdTipoEvento = IdTipoEvento;
				
			item.Area = Area;
				
			item.Suseso = Suseso;
				
			item.Estado = Estado;
				
			item.Medida = Medida;
				
	        item.Save(UserName);
	    }
    }
}
