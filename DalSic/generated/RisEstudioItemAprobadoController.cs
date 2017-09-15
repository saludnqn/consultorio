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
    /// Controller class for RIS_EstudioItemAprobado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioItemAprobadoController
    {
        // Preload our schema..
        RisEstudioItemAprobado thisSchemaLoad = new RisEstudioItemAprobado();
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
        public RisEstudioItemAprobadoCollection FetchAll()
        {
            RisEstudioItemAprobadoCollection coll = new RisEstudioItemAprobadoCollection();
            Query qry = new Query(RisEstudioItemAprobado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioItemAprobadoCollection FetchByID(object IdEstudioItemAprobado)
        {
            RisEstudioItemAprobadoCollection coll = new RisEstudioItemAprobadoCollection().Where("idEstudioItemAprobado", IdEstudioItemAprobado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioItemAprobadoCollection FetchByQuery(Query qry)
        {
            RisEstudioItemAprobadoCollection coll = new RisEstudioItemAprobadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioItemAprobado)
        {
            return (RisEstudioItemAprobado.Delete(IdEstudioItemAprobado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioItemAprobado)
        {
            return (RisEstudioItemAprobado.Destroy(IdEstudioItemAprobado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,int IdItemAprobado,DateTime Fecha,string NumeroDisposicion)
	    {
		    RisEstudioItemAprobado item = new RisEstudioItemAprobado();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdItemAprobado = IdItemAprobado;
            
            item.Fecha = Fecha;
            
            item.NumeroDisposicion = NumeroDisposicion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioItemAprobado,int IdEstudio,int IdItemAprobado,DateTime Fecha,string NumeroDisposicion)
	    {
		    RisEstudioItemAprobado item = new RisEstudioItemAprobado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioItemAprobado = IdEstudioItemAprobado;
				
			item.IdEstudio = IdEstudio;
				
			item.IdItemAprobado = IdItemAprobado;
				
			item.Fecha = Fecha;
				
			item.NumeroDisposicion = NumeroDisposicion;
				
	        item.Save(UserName);
	    }
    }
}
