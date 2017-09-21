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
    /// Controller class for MAM_IndicadorN
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamIndicadorNController
    {
        // Preload our schema..
        MamIndicadorN thisSchemaLoad = new MamIndicadorN();
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
        public MamIndicadorNCollection FetchAll()
        {
            MamIndicadorNCollection coll = new MamIndicadorNCollection();
            Query qry = new Query(MamIndicadorN.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamIndicadorNCollection FetchByID(object IdIndicadorN)
        {
            MamIndicadorNCollection coll = new MamIndicadorNCollection().Where("idIndicadorN", IdIndicadorN).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamIndicadorNCollection FetchByQuery(Query qry)
        {
            MamIndicadorNCollection coll = new MamIndicadorNCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIndicadorN)
        {
            return (MamIndicadorN.Delete(IdIndicadorN) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIndicadorN)
        {
            return (MamIndicadorN.Destroy(IdIndicadorN) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamIndicadorN item = new MamIndicadorN();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIndicadorN,string Descripcion)
	    {
		    MamIndicadorN item = new MamIndicadorN();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIndicadorN = IdIndicadorN;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
