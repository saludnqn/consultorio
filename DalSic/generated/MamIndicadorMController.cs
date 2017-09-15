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
    /// Controller class for MAM_IndicadorM
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamIndicadorMController
    {
        // Preload our schema..
        MamIndicadorM thisSchemaLoad = new MamIndicadorM();
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
        public MamIndicadorMCollection FetchAll()
        {
            MamIndicadorMCollection coll = new MamIndicadorMCollection();
            Query qry = new Query(MamIndicadorM.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamIndicadorMCollection FetchByID(object IdIndicadorM)
        {
            MamIndicadorMCollection coll = new MamIndicadorMCollection().Where("idIndicadorM", IdIndicadorM).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamIndicadorMCollection FetchByQuery(Query qry)
        {
            MamIndicadorMCollection coll = new MamIndicadorMCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIndicadorM)
        {
            return (MamIndicadorM.Delete(IdIndicadorM) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIndicadorM)
        {
            return (MamIndicadorM.Destroy(IdIndicadorM) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamIndicadorM item = new MamIndicadorM();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIndicadorM,string Descripcion)
	    {
		    MamIndicadorM item = new MamIndicadorM();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIndicadorM = IdIndicadorM;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
