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
    /// Controller class for RIS_ItemDesaprobado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisItemDesaprobadoController
    {
        // Preload our schema..
        RisItemDesaprobado thisSchemaLoad = new RisItemDesaprobado();
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
        public RisItemDesaprobadoCollection FetchAll()
        {
            RisItemDesaprobadoCollection coll = new RisItemDesaprobadoCollection();
            Query qry = new Query(RisItemDesaprobado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisItemDesaprobadoCollection FetchByID(object IdItemDesaprobado)
        {
            RisItemDesaprobadoCollection coll = new RisItemDesaprobadoCollection().Where("idItemDesaprobado", IdItemDesaprobado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisItemDesaprobadoCollection FetchByQuery(Query qry)
        {
            RisItemDesaprobadoCollection coll = new RisItemDesaprobadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdItemDesaprobado)
        {
            return (RisItemDesaprobado.Delete(IdItemDesaprobado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdItemDesaprobado)
        {
            return (RisItemDesaprobado.Destroy(IdItemDesaprobado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisItemDesaprobado item = new RisItemDesaprobado();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdItemDesaprobado,string Descripcion)
	    {
		    RisItemDesaprobado item = new RisItemDesaprobado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdItemDesaprobado = IdItemDesaprobado;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
