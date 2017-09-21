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
    /// Controller class for Guardia_TiposEgresos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaTiposEgresoController
    {
        // Preload our schema..
        GuardiaTiposEgreso thisSchemaLoad = new GuardiaTiposEgreso();
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
        public GuardiaTiposEgresoCollection FetchAll()
        {
            GuardiaTiposEgresoCollection coll = new GuardiaTiposEgresoCollection();
            Query qry = new Query(GuardiaTiposEgreso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTiposEgresoCollection FetchByID(object Id)
        {
            GuardiaTiposEgresoCollection coll = new GuardiaTiposEgresoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTiposEgresoCollection FetchByQuery(Query qry)
        {
            GuardiaTiposEgresoCollection coll = new GuardiaTiposEgresoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaTiposEgreso.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaTiposEgreso.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int? TipoUbicacionRequerida,int? SubTipoUbicacionRequerida)
	    {
		    GuardiaTiposEgreso item = new GuardiaTiposEgreso();
		    
            item.Nombre = Nombre;
            
            item.TipoUbicacionRequerida = TipoUbicacionRequerida;
            
            item.SubTipoUbicacionRequerida = SubTipoUbicacionRequerida;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre,int? TipoUbicacionRequerida,int? SubTipoUbicacionRequerida)
	    {
		    GuardiaTiposEgreso item = new GuardiaTiposEgreso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
			item.TipoUbicacionRequerida = TipoUbicacionRequerida;
				
			item.SubTipoUbicacionRequerida = SubTipoUbicacionRequerida;
				
	        item.Save(UserName);
	    }
    }
}
