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
    /// Controller class for CON_TiempoInsumido
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTiempoInsumidoController
    {
        // Preload our schema..
        ConTiempoInsumido thisSchemaLoad = new ConTiempoInsumido();
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
        public ConTiempoInsumidoCollection FetchAll()
        {
            ConTiempoInsumidoCollection coll = new ConTiempoInsumidoCollection();
            Query qry = new Query(ConTiempoInsumido.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTiempoInsumidoCollection FetchByID(object IdTiempoInsumido)
        {
            ConTiempoInsumidoCollection coll = new ConTiempoInsumidoCollection().Where("idTiempoInsumido", IdTiempoInsumido).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTiempoInsumidoCollection FetchByQuery(Query qry)
        {
            ConTiempoInsumidoCollection coll = new ConTiempoInsumidoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTiempoInsumido)
        {
            return (ConTiempoInsumido.Delete(IdTiempoInsumido) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTiempoInsumido)
        {
            return (ConTiempoInsumido.Destroy(IdTiempoInsumido) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConTiempoInsumido item = new ConTiempoInsumido();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTiempoInsumido,string Nombre)
	    {
		    ConTiempoInsumido item = new ConTiempoInsumido();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTiempoInsumido = IdTiempoInsumido;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
