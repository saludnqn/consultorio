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
    /// Controller class for PN_smitiposcategorias
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnSmitiposcategoriaController
    {
        // Preload our schema..
        PnSmitiposcategoria thisSchemaLoad = new PnSmitiposcategoria();
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
        public PnSmitiposcategoriaCollection FetchAll()
        {
            PnSmitiposcategoriaCollection coll = new PnSmitiposcategoriaCollection();
            Query qry = new Query(PnSmitiposcategoria.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmitiposcategoriaCollection FetchByID(object Codcategoria)
        {
            PnSmitiposcategoriaCollection coll = new PnSmitiposcategoriaCollection().Where("codcategoria", Codcategoria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmitiposcategoriaCollection FetchByQuery(Query qry)
        {
            PnSmitiposcategoriaCollection coll = new PnSmitiposcategoriaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Codcategoria)
        {
            return (PnSmitiposcategoria.Delete(Codcategoria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Codcategoria)
        {
            return (PnSmitiposcategoria.Destroy(Codcategoria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    PnSmitiposcategoria item = new PnSmitiposcategoria();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Codcategoria,string Descripcion)
	    {
		    PnSmitiposcategoria item = new PnSmitiposcategoria();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Codcategoria = Codcategoria;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
