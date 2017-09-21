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
    /// Controller class for Lab_SolicitudScreeningEstados
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabSolicitudScreeningEstadoController
    {
        // Preload our schema..
        LabSolicitudScreeningEstado thisSchemaLoad = new LabSolicitudScreeningEstado();
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
        public LabSolicitudScreeningEstadoCollection FetchAll()
        {
            LabSolicitudScreeningEstadoCollection coll = new LabSolicitudScreeningEstadoCollection();
            Query qry = new Query(LabSolicitudScreeningEstado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSolicitudScreeningEstadoCollection FetchByID(object Id)
        {
            LabSolicitudScreeningEstadoCollection coll = new LabSolicitudScreeningEstadoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSolicitudScreeningEstadoCollection FetchByQuery(Query qry)
        {
            LabSolicitudScreeningEstadoCollection coll = new LabSolicitudScreeningEstadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (LabSolicitudScreeningEstado.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (LabSolicitudScreeningEstado.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Id,string Estado)
	    {
		    LabSolicitudScreeningEstado item = new LabSolicitudScreeningEstado();
		    
            item.Id = Id;
            
            item.Estado = Estado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Estado)
	    {
		    LabSolicitudScreeningEstado item = new LabSolicitudScreeningEstado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Estado = Estado;
				
	        item.Save(UserName);
	    }
    }
}
