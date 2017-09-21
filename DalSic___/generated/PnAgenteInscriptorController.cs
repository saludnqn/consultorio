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
    /// Controller class for PN_agente_inscriptor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAgenteInscriptorController
    {
        // Preload our schema..
        PnAgenteInscriptor thisSchemaLoad = new PnAgenteInscriptor();
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
        public PnAgenteInscriptorCollection FetchAll()
        {
            PnAgenteInscriptorCollection coll = new PnAgenteInscriptorCollection();
            Query qry = new Query(PnAgenteInscriptor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAgenteInscriptorCollection FetchByID(object IdAgenteInscriptor)
        {
            PnAgenteInscriptorCollection coll = new PnAgenteInscriptorCollection().Where("id_agente_inscriptor", IdAgenteInscriptor).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAgenteInscriptorCollection FetchByQuery(Query qry)
        {
            PnAgenteInscriptorCollection coll = new PnAgenteInscriptorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgenteInscriptor)
        {
            return (PnAgenteInscriptor.Delete(IdAgenteInscriptor) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgenteInscriptor)
        {
            return (PnAgenteInscriptor.Destroy(IdAgenteInscriptor) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string DescripcionAgente)
	    {
		    PnAgenteInscriptor item = new PnAgenteInscriptor();
		    
            item.DescripcionAgente = DescripcionAgente;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgenteInscriptor,string DescripcionAgente)
	    {
		    PnAgenteInscriptor item = new PnAgenteInscriptor();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgenteInscriptor = IdAgenteInscriptor;
				
			item.DescripcionAgente = DescripcionAgente;
				
	        item.Save(UserName);
	    }
    }
}
