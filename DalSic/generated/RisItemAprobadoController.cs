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
    /// Controller class for RIS_ItemAprobado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisItemAprobadoController
    {
        // Preload our schema..
        RisItemAprobado thisSchemaLoad = new RisItemAprobado();
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
        public RisItemAprobadoCollection FetchAll()
        {
            RisItemAprobadoCollection coll = new RisItemAprobadoCollection();
            Query qry = new Query(RisItemAprobado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisItemAprobadoCollection FetchByID(object IdItemAprobado)
        {
            RisItemAprobadoCollection coll = new RisItemAprobadoCollection().Where("idItemAprobado", IdItemAprobado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisItemAprobadoCollection FetchByQuery(Query qry)
        {
            RisItemAprobadoCollection coll = new RisItemAprobadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdItemAprobado)
        {
            return (RisItemAprobado.Delete(IdItemAprobado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdItemAprobado)
        {
            return (RisItemAprobado.Destroy(IdItemAprobado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisItemAprobado item = new RisItemAprobado();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdItemAprobado,string Descripcion)
	    {
		    RisItemAprobado item = new RisItemAprobado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdItemAprobado = IdItemAprobado;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
