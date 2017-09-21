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
    /// Controller class for RIS_Profesion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisProfesionController
    {
        // Preload our schema..
        RisProfesion thisSchemaLoad = new RisProfesion();
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
        public RisProfesionCollection FetchAll()
        {
            RisProfesionCollection coll = new RisProfesionCollection();
            Query qry = new Query(RisProfesion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisProfesionCollection FetchByID(object IdProfesion)
        {
            RisProfesionCollection coll = new RisProfesionCollection().Where("idProfesion", IdProfesion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisProfesionCollection FetchByQuery(Query qry)
        {
            RisProfesionCollection coll = new RisProfesionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProfesion)
        {
            return (RisProfesion.Delete(IdProfesion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProfesion)
        {
            return (RisProfesion.Destroy(IdProfesion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisProfesion item = new RisProfesion();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProfesion,string Descripcion)
	    {
		    RisProfesion item = new RisProfesion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProfesion = IdProfesion;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
