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
    /// Controller class for PN_tareas_desemp
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTareasDesempController
    {
        // Preload our schema..
        PnTareasDesemp thisSchemaLoad = new PnTareasDesemp();
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
        public PnTareasDesempCollection FetchAll()
        {
            PnTareasDesempCollection coll = new PnTareasDesempCollection();
            Query qry = new Query(PnTareasDesemp.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTareasDesempCollection FetchByID(object IdTarea)
        {
            PnTareasDesempCollection coll = new PnTareasDesempCollection().Where("id_tarea", IdTarea).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTareasDesempCollection FetchByQuery(Query qry)
        {
            PnTareasDesempCollection coll = new PnTareasDesempCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTarea)
        {
            return (PnTareasDesemp.Delete(IdTarea) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTarea)
        {
            return (PnTareasDesemp.Destroy(IdTarea) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string NombreTarea)
	    {
		    PnTareasDesemp item = new PnTareasDesemp();
		    
            item.NombreTarea = NombreTarea;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTarea,string NombreTarea)
	    {
		    PnTareasDesemp item = new PnTareasDesemp();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTarea = IdTarea;
				
			item.NombreTarea = NombreTarea;
				
	        item.Save(UserName);
	    }
    }
}
