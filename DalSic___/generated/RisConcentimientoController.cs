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
    /// Controller class for RIS_Concentimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisConcentimientoController
    {
        // Preload our schema..
        RisConcentimiento thisSchemaLoad = new RisConcentimiento();
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
        public RisConcentimientoCollection FetchAll()
        {
            RisConcentimientoCollection coll = new RisConcentimientoCollection();
            Query qry = new Query(RisConcentimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisConcentimientoCollection FetchByID(object IdConcentimiento)
        {
            RisConcentimientoCollection coll = new RisConcentimientoCollection().Where("idConcentimiento", IdConcentimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisConcentimientoCollection FetchByQuery(Query qry)
        {
            RisConcentimientoCollection coll = new RisConcentimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConcentimiento)
        {
            return (RisConcentimiento.Delete(IdConcentimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConcentimiento)
        {
            return (RisConcentimiento.Destroy(IdConcentimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,string Version,DateTime Fecha)
	    {
		    RisConcentimiento item = new RisConcentimiento();
		    
            item.IdEstudio = IdEstudio;
            
            item.Version = Version;
            
            item.Fecha = Fecha;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConcentimiento,int IdEstudio,string Version,DateTime Fecha)
	    {
		    RisConcentimiento item = new RisConcentimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConcentimiento = IdConcentimiento;
				
			item.IdEstudio = IdEstudio;
				
			item.Version = Version;
				
			item.Fecha = Fecha;
				
	        item.Save(UserName);
	    }
    }
}
