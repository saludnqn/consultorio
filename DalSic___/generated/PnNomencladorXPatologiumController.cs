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
    /// Controller class for PN_NomencladorXPatologia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnNomencladorXPatologiumController
    {
        // Preload our schema..
        PnNomencladorXPatologium thisSchemaLoad = new PnNomencladorXPatologium();
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
        public PnNomencladorXPatologiumCollection FetchAll()
        {
            PnNomencladorXPatologiumCollection coll = new PnNomencladorXPatologiumCollection();
            Query qry = new Query(PnNomencladorXPatologium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNomencladorXPatologiumCollection FetchByID(object IdNomencladorXPatologia)
        {
            PnNomencladorXPatologiumCollection coll = new PnNomencladorXPatologiumCollection().Where("idNomencladorXPatologia", IdNomencladorXPatologia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNomencladorXPatologiumCollection FetchByQuery(Query qry)
        {
            PnNomencladorXPatologiumCollection coll = new PnNomencladorXPatologiumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNomencladorXPatologia)
        {
            return (PnNomencladorXPatologium.Delete(IdNomencladorXPatologia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNomencladorXPatologia)
        {
            return (PnNomencladorXPatologium.Destroy(IdNomencladorXPatologia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdNomenclador,int? IdPatologia)
	    {
		    PnNomencladorXPatologium item = new PnNomencladorXPatologium();
		    
            item.IdNomenclador = IdNomenclador;
            
            item.IdPatologia = IdPatologia;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNomencladorXPatologia,int? IdNomenclador,int? IdPatologia)
	    {
		    PnNomencladorXPatologium item = new PnNomencladorXPatologium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNomencladorXPatologia = IdNomencladorXPatologia;
				
			item.IdNomenclador = IdNomenclador;
				
			item.IdPatologia = IdPatologia;
				
	        item.Save(UserName);
	    }
    }
}
