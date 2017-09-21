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
    /// Controller class for RIS_EstudioAseguradora
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioAseguradoraController
    {
        // Preload our schema..
        RisEstudioAseguradora thisSchemaLoad = new RisEstudioAseguradora();
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
        public RisEstudioAseguradoraCollection FetchAll()
        {
            RisEstudioAseguradoraCollection coll = new RisEstudioAseguradoraCollection();
            Query qry = new Query(RisEstudioAseguradora.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioAseguradoraCollection FetchByID(object IdEstudioAseguradora)
        {
            RisEstudioAseguradoraCollection coll = new RisEstudioAseguradoraCollection().Where("idEstudioAseguradora", IdEstudioAseguradora).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioAseguradoraCollection FetchByQuery(Query qry)
        {
            RisEstudioAseguradoraCollection coll = new RisEstudioAseguradoraCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioAseguradora)
        {
            return (RisEstudioAseguradora.Delete(IdEstudioAseguradora) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioAseguradora)
        {
            return (RisEstudioAseguradora.Destroy(IdEstudioAseguradora) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,int IdAseguradora,string NumeroPoliza)
	    {
		    RisEstudioAseguradora item = new RisEstudioAseguradora();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdAseguradora = IdAseguradora;
            
            item.NumeroPoliza = NumeroPoliza;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioAseguradora,int IdEstudio,int IdAseguradora,string NumeroPoliza)
	    {
		    RisEstudioAseguradora item = new RisEstudioAseguradora();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioAseguradora = IdEstudioAseguradora;
				
			item.IdEstudio = IdEstudio;
				
			item.IdAseguradora = IdAseguradora;
				
			item.NumeroPoliza = NumeroPoliza;
				
	        item.Save(UserName);
	    }
    }
}
