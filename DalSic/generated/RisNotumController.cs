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
    /// Controller class for RIS_Nota
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisNotumController
    {
        // Preload our schema..
        RisNotum thisSchemaLoad = new RisNotum();
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
        public RisNotumCollection FetchAll()
        {
            RisNotumCollection coll = new RisNotumCollection();
            Query qry = new Query(RisNotum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisNotumCollection FetchByID(object IdNota)
        {
            RisNotumCollection coll = new RisNotumCollection().Where("idNota", IdNota).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisNotumCollection FetchByQuery(Query qry)
        {
            RisNotumCollection coll = new RisNotumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNota)
        {
            return (RisNotum.Delete(IdNota) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNota)
        {
            return (RisNotum.Destroy(IdNota) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,string Descripcion)
	    {
		    RisNotum item = new RisNotum();
		    
            item.IdEstudio = IdEstudio;
            
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNota,int IdEstudio,string Descripcion)
	    {
		    RisNotum item = new RisNotum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNota = IdNota;
				
			item.IdEstudio = IdEstudio;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
