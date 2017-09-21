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
    /// Controller class for Rem_Internacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemInternacionController
    {
        // Preload our schema..
        RemInternacion thisSchemaLoad = new RemInternacion();
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
        public RemInternacionCollection FetchAll()
        {
            RemInternacionCollection coll = new RemInternacionCollection();
            Query qry = new Query(RemInternacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemInternacionCollection FetchByID(object IdInternacion)
        {
            RemInternacionCollection coll = new RemInternacionCollection().Where("idInternacion", IdInternacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemInternacionCollection FetchByQuery(Query qry)
        {
            RemInternacionCollection coll = new RemInternacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInternacion)
        {
            return (RemInternacion.Delete(IdInternacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInternacion)
        {
            return (RemInternacion.Destroy(IdInternacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdClasificacion,string Descripcion,DateTime FechaIngreso,DateTime FechaEgreso,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    RemInternacion item = new RemInternacion();
		    
            item.IdClasificacion = IdClasificacion;
            
            item.Descripcion = Descripcion;
            
            item.FechaIngreso = FechaIngreso;
            
            item.FechaEgreso = FechaEgreso;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInternacion,int IdClasificacion,string Descripcion,DateTime FechaIngreso,DateTime FechaEgreso,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    RemInternacion item = new RemInternacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInternacion = IdInternacion;
				
			item.IdClasificacion = IdClasificacion;
				
			item.Descripcion = Descripcion;
				
			item.FechaIngreso = FechaIngreso;
				
			item.FechaEgreso = FechaEgreso;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
