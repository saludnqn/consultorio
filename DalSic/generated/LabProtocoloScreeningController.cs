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
    /// Controller class for LAB_ProtocoloScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabProtocoloScreeningController
    {
        // Preload our schema..
        LabProtocoloScreening thisSchemaLoad = new LabProtocoloScreening();
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
        public LabProtocoloScreeningCollection FetchAll()
        {
            LabProtocoloScreeningCollection coll = new LabProtocoloScreeningCollection();
            Query qry = new Query(LabProtocoloScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabProtocoloScreeningCollection FetchByID(object IdProtocoloHead)
        {
            LabProtocoloScreeningCollection coll = new LabProtocoloScreeningCollection().Where("idProtocoloHead", IdProtocoloHead).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabProtocoloScreeningCollection FetchByQuery(Query qry)
        {
            LabProtocoloScreeningCollection coll = new LabProtocoloScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProtocoloHead)
        {
            return (LabProtocoloScreening.Delete(IdProtocoloHead) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProtocoloHead)
        {
            return (LabProtocoloScreening.Destroy(IdProtocoloHead) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(bool Baja,DateTime Fecha)
	    {
		    LabProtocoloScreening item = new LabProtocoloScreening();
		    
            item.Baja = Baja;
            
            item.Fecha = Fecha;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(decimal IdProtocoloHead,bool Baja,DateTime Fecha)
	    {
		    LabProtocoloScreening item = new LabProtocoloScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProtocoloHead = IdProtocoloHead;
				
			item.Baja = Baja;
				
			item.Fecha = Fecha;
				
	        item.Save(UserName);
	    }
    }
}
