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
    /// Controller class for APR_AlimentacionRecienNacido
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAlimentacionRecienNacidoController
    {
        // Preload our schema..
        AprAlimentacionRecienNacido thisSchemaLoad = new AprAlimentacionRecienNacido();
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
        public AprAlimentacionRecienNacidoCollection FetchAll()
        {
            AprAlimentacionRecienNacidoCollection coll = new AprAlimentacionRecienNacidoCollection();
            Query qry = new Query(AprAlimentacionRecienNacido.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAlimentacionRecienNacidoCollection FetchByID(object IdAlimentacionRecienNacido)
        {
            AprAlimentacionRecienNacidoCollection coll = new AprAlimentacionRecienNacidoCollection().Where("idAlimentacionRecienNacido", IdAlimentacionRecienNacido).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAlimentacionRecienNacidoCollection FetchByQuery(Query qry)
        {
            AprAlimentacionRecienNacidoCollection coll = new AprAlimentacionRecienNacidoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAlimentacionRecienNacido)
        {
            return (AprAlimentacionRecienNacido.Delete(IdAlimentacionRecienNacido) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAlimentacionRecienNacido)
        {
            return (AprAlimentacionRecienNacido.Destroy(IdAlimentacionRecienNacido) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprAlimentacionRecienNacido item = new AprAlimentacionRecienNacido();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAlimentacionRecienNacido,string Nombre)
	    {
		    AprAlimentacionRecienNacido item = new AprAlimentacionRecienNacido();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAlimentacionRecienNacido = IdAlimentacionRecienNacido;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
