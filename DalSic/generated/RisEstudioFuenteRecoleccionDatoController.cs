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
    /// Controller class for RIS_EstudioFuenteRecoleccionDatos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioFuenteRecoleccionDatoController
    {
        // Preload our schema..
        RisEstudioFuenteRecoleccionDato thisSchemaLoad = new RisEstudioFuenteRecoleccionDato();
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
        public RisEstudioFuenteRecoleccionDatoCollection FetchAll()
        {
            RisEstudioFuenteRecoleccionDatoCollection coll = new RisEstudioFuenteRecoleccionDatoCollection();
            Query qry = new Query(RisEstudioFuenteRecoleccionDato.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioFuenteRecoleccionDatoCollection FetchByID(object IdEstudioFuenteRecoleccionDatos)
        {
            RisEstudioFuenteRecoleccionDatoCollection coll = new RisEstudioFuenteRecoleccionDatoCollection().Where("idEstudioFuenteRecoleccionDatos", IdEstudioFuenteRecoleccionDatos).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioFuenteRecoleccionDatoCollection FetchByQuery(Query qry)
        {
            RisEstudioFuenteRecoleccionDatoCollection coll = new RisEstudioFuenteRecoleccionDatoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioFuenteRecoleccionDatos)
        {
            return (RisEstudioFuenteRecoleccionDato.Delete(IdEstudioFuenteRecoleccionDatos) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioFuenteRecoleccionDatos)
        {
            return (RisEstudioFuenteRecoleccionDato.Destroy(IdEstudioFuenteRecoleccionDatos) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,int IdFuenteRecoleccionDatos)
	    {
		    RisEstudioFuenteRecoleccionDato item = new RisEstudioFuenteRecoleccionDato();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdFuenteRecoleccionDatos = IdFuenteRecoleccionDatos;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioFuenteRecoleccionDatos,int IdEstudio,int IdFuenteRecoleccionDatos)
	    {
		    RisEstudioFuenteRecoleccionDato item = new RisEstudioFuenteRecoleccionDato();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioFuenteRecoleccionDatos = IdEstudioFuenteRecoleccionDatos;
				
			item.IdEstudio = IdEstudio;
				
			item.IdFuenteRecoleccionDatos = IdFuenteRecoleccionDatos;
				
	        item.Save(UserName);
	    }
    }
}
