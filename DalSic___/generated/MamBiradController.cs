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
    /// Controller class for MAM_Birads
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamBiradController
    {
        // Preload our schema..
        MamBirad thisSchemaLoad = new MamBirad();
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
        public MamBiradCollection FetchAll()
        {
            MamBiradCollection coll = new MamBiradCollection();
            Query qry = new Query(MamBirad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamBiradCollection FetchByID(object IdBirads)
        {
            MamBiradCollection coll = new MamBiradCollection().Where("idBirads", IdBirads).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamBiradCollection FetchByQuery(Query qry)
        {
            MamBiradCollection coll = new MamBiradCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdBirads)
        {
            return (MamBirad.Delete(IdBirads) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdBirads)
        {
            return (MamBirad.Destroy(IdBirads) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Descripcion,string Observacion)
	    {
		    MamBirad item = new MamBirad();
		    
            item.Nombre = Nombre;
            
            item.Descripcion = Descripcion;
            
            item.Observacion = Observacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdBirads,string Nombre,string Descripcion,string Observacion)
	    {
		    MamBirad item = new MamBirad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdBirads = IdBirads;
				
			item.Nombre = Nombre;
				
			item.Descripcion = Descripcion;
				
			item.Observacion = Observacion;
				
	        item.Save(UserName);
	    }
    }
}
