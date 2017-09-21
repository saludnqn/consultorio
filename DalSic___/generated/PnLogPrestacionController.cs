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
    /// Controller class for PN_log_prestacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLogPrestacionController
    {
        // Preload our schema..
        PnLogPrestacion thisSchemaLoad = new PnLogPrestacion();
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
        public PnLogPrestacionCollection FetchAll()
        {
            PnLogPrestacionCollection coll = new PnLogPrestacionCollection();
            Query qry = new Query(PnLogPrestacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogPrestacionCollection FetchByID(object IdLogPrestacion)
        {
            PnLogPrestacionCollection coll = new PnLogPrestacionCollection().Where("id_log_prestacion", IdLogPrestacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogPrestacionCollection FetchByQuery(Query qry)
        {
            PnLogPrestacionCollection coll = new PnLogPrestacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLogPrestacion)
        {
            return (PnLogPrestacion.Delete(IdLogPrestacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLogPrestacion)
        {
            return (PnLogPrestacion.Destroy(IdLogPrestacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPrestacion,DateTime? Fecha,string Tipo,string Descripcion,string Usuario)
	    {
		    PnLogPrestacion item = new PnLogPrestacion();
		    
            item.IdPrestacion = IdPrestacion;
            
            item.Fecha = Fecha;
            
            item.Tipo = Tipo;
            
            item.Descripcion = Descripcion;
            
            item.Usuario = Usuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLogPrestacion,int IdPrestacion,DateTime? Fecha,string Tipo,string Descripcion,string Usuario)
	    {
		    PnLogPrestacion item = new PnLogPrestacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLogPrestacion = IdLogPrestacion;
				
			item.IdPrestacion = IdPrestacion;
				
			item.Fecha = Fecha;
				
			item.Tipo = Tipo;
				
			item.Descripcion = Descripcion;
				
			item.Usuario = Usuario;
				
	        item.Save(UserName);
	    }
    }
}
