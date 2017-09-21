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
    /// Controller class for Rem_MedicamentoCronico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemMedicamentoCronicoController
    {
        // Preload our schema..
        RemMedicamentoCronico thisSchemaLoad = new RemMedicamentoCronico();
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
        public RemMedicamentoCronicoCollection FetchAll()
        {
            RemMedicamentoCronicoCollection coll = new RemMedicamentoCronicoCollection();
            Query qry = new Query(RemMedicamentoCronico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemMedicamentoCronicoCollection FetchByID(object IdMedicamentoCronico)
        {
            RemMedicamentoCronicoCollection coll = new RemMedicamentoCronicoCollection().Where("idMedicamentoCronico", IdMedicamentoCronico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemMedicamentoCronicoCollection FetchByQuery(Query qry)
        {
            RemMedicamentoCronicoCollection coll = new RemMedicamentoCronicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMedicamentoCronico)
        {
            return (RemMedicamentoCronico.Delete(IdMedicamentoCronico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMedicamentoCronico)
        {
            return (RemMedicamentoCronico.Destroy(IdMedicamentoCronico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdMedicamento)
	    {
		    RemMedicamentoCronico item = new RemMedicamentoCronico();
		    
            item.IdMedicamento = IdMedicamento;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMedicamentoCronico,int IdMedicamento)
	    {
		    RemMedicamentoCronico item = new RemMedicamentoCronico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMedicamentoCronico = IdMedicamentoCronico;
				
			item.IdMedicamento = IdMedicamento;
				
	        item.Save(UserName);
	    }
    }
}
