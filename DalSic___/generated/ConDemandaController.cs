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
    /// Controller class for CON_Demanda
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConDemandaController
    {
        // Preload our schema..
        ConDemanda thisSchemaLoad = new ConDemanda();
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
        public ConDemandaCollection FetchAll()
        {
            ConDemandaCollection coll = new ConDemandaCollection();
            Query qry = new Query(ConDemanda.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConDemandaCollection FetchByID(object IdDemanda)
        {
            ConDemandaCollection coll = new ConDemandaCollection().Where("idDemanda", IdDemanda).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConDemandaCollection FetchByQuery(Query qry)
        {
            ConDemandaCollection coll = new ConDemandaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDemanda)
        {
            return (ConDemanda.Delete(IdDemanda) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDemanda)
        {
            return (ConDemanda.Destroy(IdDemanda) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConDemanda item = new ConDemanda();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDemanda,string Nombre)
	    {
		    ConDemanda item = new ConDemanda();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDemanda = IdDemanda;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
