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
    /// Controller class for PN_motivo_d
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnMotivoDController
    {
        // Preload our schema..
        PnMotivoD thisSchemaLoad = new PnMotivoD();
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
        public PnMotivoDCollection FetchAll()
        {
            PnMotivoDCollection coll = new PnMotivoDCollection();
            Query qry = new Query(PnMotivoD.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMotivoDCollection FetchByID(object IdMotivoD)
        {
            PnMotivoDCollection coll = new PnMotivoDCollection().Where("id_motivo_d", IdMotivoD).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMotivoDCollection FetchByQuery(Query qry)
        {
            PnMotivoDCollection coll = new PnMotivoDCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivoD)
        {
            return (PnMotivoD.Delete(IdMotivoD) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivoD)
        {
            return (PnMotivoD.Destroy(IdMotivoD) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    PnMotivoD item = new PnMotivoD();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivoD,string Descripcion)
	    {
		    PnMotivoD item = new PnMotivoD();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivoD = IdMotivoD;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
