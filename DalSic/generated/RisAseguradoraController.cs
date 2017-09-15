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
    /// Controller class for RIS_Aseguradora
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisAseguradoraController
    {
        // Preload our schema..
        RisAseguradora thisSchemaLoad = new RisAseguradora();
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
        public RisAseguradoraCollection FetchAll()
        {
            RisAseguradoraCollection coll = new RisAseguradoraCollection();
            Query qry = new Query(RisAseguradora.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisAseguradoraCollection FetchByID(object IdAseguradora)
        {
            RisAseguradoraCollection coll = new RisAseguradoraCollection().Where("idAseguradora", IdAseguradora).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisAseguradoraCollection FetchByQuery(Query qry)
        {
            RisAseguradoraCollection coll = new RisAseguradoraCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAseguradora)
        {
            return (RisAseguradora.Delete(IdAseguradora) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAseguradora)
        {
            return (RisAseguradora.Destroy(IdAseguradora) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisAseguradora item = new RisAseguradora();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAseguradora,string Descripcion)
	    {
		    RisAseguradora item = new RisAseguradora();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAseguradora = IdAseguradora;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
