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
    /// Controller class for PN_Rel_PrestacionXDatoReportable
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnRelPrestacionXDatoReportableController
    {
        // Preload our schema..
        PnRelPrestacionXDatoReportable thisSchemaLoad = new PnRelPrestacionXDatoReportable();
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
        public PnRelPrestacionXDatoReportableCollection FetchAll()
        {
            PnRelPrestacionXDatoReportableCollection coll = new PnRelPrestacionXDatoReportableCollection();
            Query qry = new Query(PnRelPrestacionXDatoReportable.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnRelPrestacionXDatoReportableCollection FetchByID(object IdPrestacionXDatoReportable)
        {
            PnRelPrestacionXDatoReportableCollection coll = new PnRelPrestacionXDatoReportableCollection().Where("idPrestacionXDatoReportable", IdPrestacionXDatoReportable).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnRelPrestacionXDatoReportableCollection FetchByQuery(Query qry)
        {
            PnRelPrestacionXDatoReportableCollection coll = new PnRelPrestacionXDatoReportableCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPrestacionXDatoReportable)
        {
            return (PnRelPrestacionXDatoReportable.Delete(IdPrestacionXDatoReportable) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPrestacionXDatoReportable)
        {
            return (PnRelPrestacionXDatoReportable.Destroy(IdPrestacionXDatoReportable) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdPrestacion,int? IdDatoReportable,string Valor)
	    {
		    PnRelPrestacionXDatoReportable item = new PnRelPrestacionXDatoReportable();
		    
            item.IdPrestacion = IdPrestacion;
            
            item.IdDatoReportable = IdDatoReportable;
            
            item.Valor = Valor;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPrestacionXDatoReportable,int? IdPrestacion,int? IdDatoReportable,string Valor)
	    {
		    PnRelPrestacionXDatoReportable item = new PnRelPrestacionXDatoReportable();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPrestacionXDatoReportable = IdPrestacionXDatoReportable;
				
			item.IdPrestacion = IdPrestacion;
				
			item.IdDatoReportable = IdDatoReportable;
				
			item.Valor = Valor;
				
	        item.Save(UserName);
	    }
    }
}
