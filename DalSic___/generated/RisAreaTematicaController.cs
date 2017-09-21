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
    /// Controller class for RIS_AreaTematica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisAreaTematicaController
    {
        // Preload our schema..
        RisAreaTematica thisSchemaLoad = new RisAreaTematica();
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
        public RisAreaTematicaCollection FetchAll()
        {
            RisAreaTematicaCollection coll = new RisAreaTematicaCollection();
            Query qry = new Query(RisAreaTematica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisAreaTematicaCollection FetchByID(object IdAreaTematica)
        {
            RisAreaTematicaCollection coll = new RisAreaTematicaCollection().Where("idAreaTematica", IdAreaTematica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisAreaTematicaCollection FetchByQuery(Query qry)
        {
            RisAreaTematicaCollection coll = new RisAreaTematicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAreaTematica)
        {
            return (RisAreaTematica.Delete(IdAreaTematica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAreaTematica)
        {
            return (RisAreaTematica.Destroy(IdAreaTematica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisAreaTematica item = new RisAreaTematica();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAreaTematica,string Descripcion)
	    {
		    RisAreaTematica item = new RisAreaTematica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAreaTematica = IdAreaTematica;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
