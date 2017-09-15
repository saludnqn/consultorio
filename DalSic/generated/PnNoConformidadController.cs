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
    /// Controller class for PN_no_conformidad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnNoConformidadController
    {
        // Preload our schema..
        PnNoConformidad thisSchemaLoad = new PnNoConformidad();
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
        public PnNoConformidadCollection FetchAll()
        {
            PnNoConformidadCollection coll = new PnNoConformidadCollection();
            Query qry = new Query(PnNoConformidad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNoConformidadCollection FetchByID(object IdNoConformidad)
        {
            PnNoConformidadCollection coll = new PnNoConformidadCollection().Where("id_no_conformidad", IdNoConformidad).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNoConformidadCollection FetchByQuery(Query qry)
        {
            PnNoConformidadCollection coll = new PnNoConformidadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNoConformidad)
        {
            return (PnNoConformidad.Delete(IdNoConformidad) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNoConformidad)
        {
            return (PnNoConformidad.Destroy(IdNoConformidad) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,short? Tipo)
	    {
		    PnNoConformidad item = new PnNoConformidad();
		    
            item.Descripcion = Descripcion;
            
            item.Tipo = Tipo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNoConformidad,string Descripcion,short? Tipo)
	    {
		    PnNoConformidad item = new PnNoConformidad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNoConformidad = IdNoConformidad;
				
			item.Descripcion = Descripcion;
				
			item.Tipo = Tipo;
				
	        item.Save(UserName);
	    }
    }
}
