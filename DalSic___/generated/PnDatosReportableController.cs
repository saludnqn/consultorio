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
    /// Controller class for PN_datos_reportables
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDatosReportableController
    {
        // Preload our schema..
        PnDatosReportable thisSchemaLoad = new PnDatosReportable();
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
        public PnDatosReportableCollection FetchAll()
        {
            PnDatosReportableCollection coll = new PnDatosReportableCollection();
            Query qry = new Query(PnDatosReportable.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDatosReportableCollection FetchByID(object IdDatoReportable)
        {
            PnDatosReportableCollection coll = new PnDatosReportableCollection().Where("idDatoReportable", IdDatoReportable).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDatosReportableCollection FetchByQuery(Query qry)
        {
            PnDatosReportableCollection coll = new PnDatosReportableCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDatoReportable)
        {
            return (PnDatosReportable.Delete(IdDatoReportable) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDatoReportable)
        {
            return (PnDatosReportable.Destroy(IdDatoReportable) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string UnidadMedida)
	    {
		    PnDatosReportable item = new PnDatosReportable();
		    
            item.Nombre = Nombre;
            
            item.UnidadMedida = UnidadMedida;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDatoReportable,string Nombre,string UnidadMedida)
	    {
		    PnDatosReportable item = new PnDatosReportable();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDatoReportable = IdDatoReportable;
				
			item.Nombre = Nombre;
				
			item.UnidadMedida = UnidadMedida;
				
	        item.Save(UserName);
	    }
    }
}
