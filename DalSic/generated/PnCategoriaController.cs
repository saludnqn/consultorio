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
    /// Controller class for PN_categorias
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCategoriaController
    {
        // Preload our schema..
        PnCategoria thisSchemaLoad = new PnCategoria();
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
        public PnCategoriaCollection FetchAll()
        {
            PnCategoriaCollection coll = new PnCategoriaCollection();
            Query qry = new Query(PnCategoria.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCategoriaCollection FetchByID(object IdCategoria)
        {
            PnCategoriaCollection coll = new PnCategoriaCollection().Where("id_categoria", IdCategoria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCategoriaCollection FetchByQuery(Query qry)
        {
            PnCategoriaCollection coll = new PnCategoriaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCategoria)
        {
            return (PnCategoria.Delete(IdCategoria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCategoria)
        {
            return (PnCategoria.Destroy(IdCategoria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Categoria,string TipoFicha)
	    {
		    PnCategoria item = new PnCategoria();
		    
            item.Categoria = Categoria;
            
            item.TipoFicha = TipoFicha;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCategoria,string Categoria,string TipoFicha)
	    {
		    PnCategoria item = new PnCategoria();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCategoria = IdCategoria;
				
			item.Categoria = Categoria;
				
			item.TipoFicha = TipoFicha;
				
	        item.Save(UserName);
	    }
    }
}
