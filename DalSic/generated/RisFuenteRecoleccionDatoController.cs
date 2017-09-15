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
    /// Controller class for RIS_FuenteRecoleccionDatos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisFuenteRecoleccionDatoController
    {
        // Preload our schema..
        RisFuenteRecoleccionDato thisSchemaLoad = new RisFuenteRecoleccionDato();
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
        public RisFuenteRecoleccionDatoCollection FetchAll()
        {
            RisFuenteRecoleccionDatoCollection coll = new RisFuenteRecoleccionDatoCollection();
            Query qry = new Query(RisFuenteRecoleccionDato.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisFuenteRecoleccionDatoCollection FetchByID(object IdFuenteRecoleccionDatos)
        {
            RisFuenteRecoleccionDatoCollection coll = new RisFuenteRecoleccionDatoCollection().Where("idFuenteRecoleccionDatos", IdFuenteRecoleccionDatos).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisFuenteRecoleccionDatoCollection FetchByQuery(Query qry)
        {
            RisFuenteRecoleccionDatoCollection coll = new RisFuenteRecoleccionDatoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFuenteRecoleccionDatos)
        {
            return (RisFuenteRecoleccionDato.Delete(IdFuenteRecoleccionDatos) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFuenteRecoleccionDatos)
        {
            return (RisFuenteRecoleccionDato.Destroy(IdFuenteRecoleccionDatos) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisFuenteRecoleccionDato item = new RisFuenteRecoleccionDato();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFuenteRecoleccionDatos,string Descripcion)
	    {
		    RisFuenteRecoleccionDato item = new RisFuenteRecoleccionDato();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFuenteRecoleccionDatos = IdFuenteRecoleccionDatos;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
