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
    /// Controller class for APR_AmbienteProcedimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAmbienteProcedimientoController
    {
        // Preload our schema..
        AprAmbienteProcedimiento thisSchemaLoad = new AprAmbienteProcedimiento();
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
        public AprAmbienteProcedimientoCollection FetchAll()
        {
            AprAmbienteProcedimientoCollection coll = new AprAmbienteProcedimientoCollection();
            Query qry = new Query(AprAmbienteProcedimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAmbienteProcedimientoCollection FetchByID(object IdAmbienteProcedimiento)
        {
            AprAmbienteProcedimientoCollection coll = new AprAmbienteProcedimientoCollection().Where("idAmbienteProcedimiento", IdAmbienteProcedimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAmbienteProcedimientoCollection FetchByQuery(Query qry)
        {
            AprAmbienteProcedimientoCollection coll = new AprAmbienteProcedimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAmbienteProcedimiento)
        {
            return (AprAmbienteProcedimiento.Delete(IdAmbienteProcedimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAmbienteProcedimiento)
        {
            return (AprAmbienteProcedimiento.Destroy(IdAmbienteProcedimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprAmbienteProcedimiento item = new AprAmbienteProcedimiento();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAmbienteProcedimiento,string Nombre)
	    {
		    AprAmbienteProcedimiento item = new AprAmbienteProcedimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAmbienteProcedimiento = IdAmbienteProcedimiento;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
