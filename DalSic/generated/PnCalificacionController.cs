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
    /// Controller class for PN_calificacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCalificacionController
    {
        // Preload our schema..
        PnCalificacion thisSchemaLoad = new PnCalificacion();
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
        public PnCalificacionCollection FetchAll()
        {
            PnCalificacionCollection coll = new PnCalificacionCollection();
            Query qry = new Query(PnCalificacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCalificacionCollection FetchByID(object IdCalificacion)
        {
            PnCalificacionCollection coll = new PnCalificacionCollection().Where("id_calificacion", IdCalificacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCalificacionCollection FetchByQuery(Query qry)
        {
            PnCalificacionCollection coll = new PnCalificacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCalificacion)
        {
            return (PnCalificacion.Delete(IdCalificacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCalificacion)
        {
            return (PnCalificacion.Destroy(IdCalificacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string NombreCalificacion)
	    {
		    PnCalificacion item = new PnCalificacion();
		    
            item.NombreCalificacion = NombreCalificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCalificacion,string NombreCalificacion)
	    {
		    PnCalificacion item = new PnCalificacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCalificacion = IdCalificacion;
				
			item.NombreCalificacion = NombreCalificacion;
				
	        item.Save(UserName);
	    }
    }
}
