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
    /// Controller class for Guardia_TipoPracticas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaTipoPracticaController
    {
        // Preload our schema..
        GuardiaTipoPractica thisSchemaLoad = new GuardiaTipoPractica();
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
        public GuardiaTipoPracticaCollection FetchAll()
        {
            GuardiaTipoPracticaCollection coll = new GuardiaTipoPracticaCollection();
            Query qry = new Query(GuardiaTipoPractica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTipoPracticaCollection FetchByID(object Id)
        {
            GuardiaTipoPracticaCollection coll = new GuardiaTipoPracticaCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTipoPracticaCollection FetchByQuery(Query qry)
        {
            GuardiaTipoPracticaCollection coll = new GuardiaTipoPracticaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaTipoPractica.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaTipoPractica.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Id,int? IdPadre,int? Clase,string Nombre,string UrlIcono,bool? VinculadoPrestaciones,string Advertencia)
	    {
		    GuardiaTipoPractica item = new GuardiaTipoPractica();
		    
            item.Id = Id;
            
            item.IdPadre = IdPadre;
            
            item.Clase = Clase;
            
            item.Nombre = Nombre;
            
            item.UrlIcono = UrlIcono;
            
            item.VinculadoPrestaciones = VinculadoPrestaciones;
            
            item.Advertencia = Advertencia;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdPadre,int? Clase,string Nombre,string UrlIcono,bool? VinculadoPrestaciones,string Advertencia)
	    {
		    GuardiaTipoPractica item = new GuardiaTipoPractica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdPadre = IdPadre;
				
			item.Clase = Clase;
				
			item.Nombre = Nombre;
				
			item.UrlIcono = UrlIcono;
				
			item.VinculadoPrestaciones = VinculadoPrestaciones;
				
			item.Advertencia = Advertencia;
				
	        item.Save(UserName);
	    }
    }
}
