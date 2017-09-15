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
    /// Controller class for MAM_IndicadorT
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamIndicadorTController
    {
        // Preload our schema..
        MamIndicadorT thisSchemaLoad = new MamIndicadorT();
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
        public MamIndicadorTCollection FetchAll()
        {
            MamIndicadorTCollection coll = new MamIndicadorTCollection();
            Query qry = new Query(MamIndicadorT.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamIndicadorTCollection FetchByID(object IdIndicadorT)
        {
            MamIndicadorTCollection coll = new MamIndicadorTCollection().Where("idIndicadorT", IdIndicadorT).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamIndicadorTCollection FetchByQuery(Query qry)
        {
            MamIndicadorTCollection coll = new MamIndicadorTCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIndicadorT)
        {
            return (MamIndicadorT.Delete(IdIndicadorT) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIndicadorT)
        {
            return (MamIndicadorT.Destroy(IdIndicadorT) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamIndicadorT item = new MamIndicadorT();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIndicadorT,string Descripcion)
	    {
		    MamIndicadorT item = new MamIndicadorT();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIndicadorT = IdIndicadorT;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
