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
    /// Controller class for RIS_EstudioItemDesaprobado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioItemDesaprobadoController
    {
        // Preload our schema..
        RisEstudioItemDesaprobado thisSchemaLoad = new RisEstudioItemDesaprobado();
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
        public RisEstudioItemDesaprobadoCollection FetchAll()
        {
            RisEstudioItemDesaprobadoCollection coll = new RisEstudioItemDesaprobadoCollection();
            Query qry = new Query(RisEstudioItemDesaprobado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioItemDesaprobadoCollection FetchByID(object IdEstudioItemDesarpobado)
        {
            RisEstudioItemDesaprobadoCollection coll = new RisEstudioItemDesaprobadoCollection().Where("idEstudioItemDesarpobado", IdEstudioItemDesarpobado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioItemDesaprobadoCollection FetchByQuery(Query qry)
        {
            RisEstudioItemDesaprobadoCollection coll = new RisEstudioItemDesaprobadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioItemDesarpobado)
        {
            return (RisEstudioItemDesaprobado.Delete(IdEstudioItemDesarpobado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioItemDesarpobado)
        {
            return (RisEstudioItemDesaprobado.Destroy(IdEstudioItemDesarpobado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,int IdItemDesaprobado)
	    {
		    RisEstudioItemDesaprobado item = new RisEstudioItemDesaprobado();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdItemDesaprobado = IdItemDesaprobado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioItemDesarpobado,int IdEstudio,int IdItemDesaprobado)
	    {
		    RisEstudioItemDesaprobado item = new RisEstudioItemDesaprobado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioItemDesarpobado = IdEstudioItemDesarpobado;
				
			item.IdEstudio = IdEstudio;
				
			item.IdItemDesaprobado = IdItemDesaprobado;
				
	        item.Save(UserName);
	    }
    }
}
