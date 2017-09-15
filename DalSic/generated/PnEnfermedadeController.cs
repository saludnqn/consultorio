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
    /// Controller class for PN_enfermedades
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEnfermedadeController
    {
        // Preload our schema..
        PnEnfermedade thisSchemaLoad = new PnEnfermedade();
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
        public PnEnfermedadeCollection FetchAll()
        {
            PnEnfermedadeCollection coll = new PnEnfermedadeCollection();
            Query qry = new Query(PnEnfermedade.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEnfermedadeCollection FetchByID(object IdLegajo)
        {
            PnEnfermedadeCollection coll = new PnEnfermedadeCollection().Where("id_legajo", IdLegajo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEnfermedadeCollection FetchByQuery(Query qry)
        {
            PnEnfermedadeCollection coll = new PnEnfermedadeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLegajo)
        {
            return (PnEnfermedade.Delete(IdLegajo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLegajo)
        {
            return (PnEnfermedade.Destroy(IdLegajo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime Fecha,string Diagnostico)
	    {
		    PnEnfermedade item = new PnEnfermedade();
		    
            item.Fecha = Fecha;
            
            item.Diagnostico = Diagnostico;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLegajo,DateTime Fecha,string Diagnostico)
	    {
		    PnEnfermedade item = new PnEnfermedade();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLegajo = IdLegajo;
				
			item.Fecha = Fecha;
				
			item.Diagnostico = Diagnostico;
				
	        item.Save(UserName);
	    }
    }
}
