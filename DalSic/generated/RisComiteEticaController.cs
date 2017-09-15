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
    /// Controller class for RIS_ComiteEtica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisComiteEticaController
    {
        // Preload our schema..
        RisComiteEtica thisSchemaLoad = new RisComiteEtica();
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
        public RisComiteEticaCollection FetchAll()
        {
            RisComiteEticaCollection coll = new RisComiteEticaCollection();
            Query qry = new Query(RisComiteEtica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisComiteEticaCollection FetchByID(object IdComiteEtica)
        {
            RisComiteEticaCollection coll = new RisComiteEticaCollection().Where("idComiteEtica", IdComiteEtica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisComiteEticaCollection FetchByQuery(Query qry)
        {
            RisComiteEticaCollection coll = new RisComiteEticaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdComiteEtica)
        {
            return (RisComiteEtica.Delete(IdComiteEtica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdComiteEtica)
        {
            return (RisComiteEtica.Destroy(IdComiteEtica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisComiteEtica item = new RisComiteEtica();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdComiteEtica,string Descripcion)
	    {
		    RisComiteEtica item = new RisComiteEtica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdComiteEtica = IdComiteEtica;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
