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
    /// Controller class for PN_obras_sociales
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnObrasSocialeController
    {
        // Preload our schema..
        PnObrasSociale thisSchemaLoad = new PnObrasSociale();
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
        public PnObrasSocialeCollection FetchAll()
        {
            PnObrasSocialeCollection coll = new PnObrasSocialeCollection();
            Query qry = new Query(PnObrasSociale.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnObrasSocialeCollection FetchByID(object CodOs)
        {
            PnObrasSocialeCollection coll = new PnObrasSocialeCollection().Where("cod_os", CodOs).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnObrasSocialeCollection FetchByQuery(Query qry)
        {
            PnObrasSocialeCollection coll = new PnObrasSocialeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CodOs)
        {
            return (PnObrasSociale.Delete(CodOs) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CodOs)
        {
            return (PnObrasSociale.Destroy(CodOs) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CodOs,string Nombre)
	    {
		    PnObrasSociale item = new PnObrasSociale();
		    
            item.CodOs = CodOs;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CodOs,string Nombre)
	    {
		    PnObrasSociale item = new PnObrasSociale();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CodOs = CodOs;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
