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
    /// Controller class for FAC_OrdenLaboratorio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class FacOrdenLaboratorioController
    {
        // Preload our schema..
        FacOrdenLaboratorio thisSchemaLoad = new FacOrdenLaboratorio();
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
        public FacOrdenLaboratorioCollection FetchAll()
        {
            FacOrdenLaboratorioCollection coll = new FacOrdenLaboratorioCollection();
            Query qry = new Query(FacOrdenLaboratorio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacOrdenLaboratorioCollection FetchByID(object IdOrdenLaboratorio)
        {
            FacOrdenLaboratorioCollection coll = new FacOrdenLaboratorioCollection().Where("idOrdenLaboratorio", IdOrdenLaboratorio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacOrdenLaboratorioCollection FetchByQuery(Query qry)
        {
            FacOrdenLaboratorioCollection coll = new FacOrdenLaboratorioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdOrdenLaboratorio)
        {
            return (FacOrdenLaboratorio.Delete(IdOrdenLaboratorio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdOrdenLaboratorio)
        {
            return (FacOrdenLaboratorio.Destroy(IdOrdenLaboratorio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdOrden,int IdProtocolo,int IdEfector)
	    {
		    FacOrdenLaboratorio item = new FacOrdenLaboratorio();
		    
            item.IdOrden = IdOrden;
            
            item.IdProtocolo = IdProtocolo;
            
            item.IdEfector = IdEfector;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdOrdenLaboratorio,int IdOrden,int IdProtocolo,int IdEfector)
	    {
		    FacOrdenLaboratorio item = new FacOrdenLaboratorio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdOrdenLaboratorio = IdOrdenLaboratorio;
				
			item.IdOrden = IdOrden;
				
			item.IdProtocolo = IdProtocolo;
				
			item.IdEfector = IdEfector;
				
	        item.Save(UserName);
	    }
    }
}
