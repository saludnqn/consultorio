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
    /// Controller class for PN_anexo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAnexoController
    {
        // Preload our schema..
        PnAnexo thisSchemaLoad = new PnAnexo();
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
        public PnAnexoCollection FetchAll()
        {
            PnAnexoCollection coll = new PnAnexoCollection();
            Query qry = new Query(PnAnexo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAnexoCollection FetchByID(object IdAnexo)
        {
            PnAnexoCollection coll = new PnAnexoCollection().Where("id_anexo", IdAnexo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAnexoCollection FetchByQuery(Query qry)
        {
            PnAnexoCollection coll = new PnAnexoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAnexo)
        {
            return (PnAnexo.Delete(IdAnexo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAnexo)
        {
            return (PnAnexo.Destroy(IdAnexo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? Numero,string Prueba,int? Categoria,decimal? Precio,int? IdNomenclador,int? IdNomencladorDetalle)
	    {
		    PnAnexo item = new PnAnexo();
		    
            item.Numero = Numero;
            
            item.Prueba = Prueba;
            
            item.Categoria = Categoria;
            
            item.Precio = Precio;
            
            item.IdNomenclador = IdNomenclador;
            
            item.IdNomencladorDetalle = IdNomencladorDetalle;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAnexo,int? Numero,string Prueba,int? Categoria,decimal? Precio,int? IdNomenclador,int? IdNomencladorDetalle)
	    {
		    PnAnexo item = new PnAnexo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAnexo = IdAnexo;
				
			item.Numero = Numero;
				
			item.Prueba = Prueba;
				
			item.Categoria = Categoria;
				
			item.Precio = Precio;
				
			item.IdNomenclador = IdNomenclador;
				
			item.IdNomencladorDetalle = IdNomencladorDetalle;
				
	        item.Save(UserName);
	    }
    }
}
