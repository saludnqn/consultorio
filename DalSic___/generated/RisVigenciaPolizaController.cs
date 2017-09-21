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
    /// Controller class for RIS_VigenciaPoliza
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisVigenciaPolizaController
    {
        // Preload our schema..
        RisVigenciaPoliza thisSchemaLoad = new RisVigenciaPoliza();
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
        public RisVigenciaPolizaCollection FetchAll()
        {
            RisVigenciaPolizaCollection coll = new RisVigenciaPolizaCollection();
            Query qry = new Query(RisVigenciaPoliza.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisVigenciaPolizaCollection FetchByID(object IdVigenciaPoliza)
        {
            RisVigenciaPolizaCollection coll = new RisVigenciaPolizaCollection().Where("idVigenciaPoliza", IdVigenciaPoliza).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisVigenciaPolizaCollection FetchByQuery(Query qry)
        {
            RisVigenciaPolizaCollection coll = new RisVigenciaPolizaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdVigenciaPoliza)
        {
            return (RisVigenciaPoliza.Delete(IdVigenciaPoliza) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdVigenciaPoliza)
        {
            return (RisVigenciaPoliza.Destroy(IdVigenciaPoliza) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudioAseguradora,DateTime FechaInicio,DateTime FechaFin)
	    {
		    RisVigenciaPoliza item = new RisVigenciaPoliza();
		    
            item.IdEstudioAseguradora = IdEstudioAseguradora;
            
            item.FechaInicio = FechaInicio;
            
            item.FechaFin = FechaFin;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdVigenciaPoliza,int IdEstudioAseguradora,DateTime FechaInicio,DateTime FechaFin)
	    {
		    RisVigenciaPoliza item = new RisVigenciaPoliza();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdVigenciaPoliza = IdVigenciaPoliza;
				
			item.IdEstudioAseguradora = IdEstudioAseguradora;
				
			item.FechaInicio = FechaInicio;
				
			item.FechaFin = FechaFin;
				
	        item.Save(UserName);
	    }
    }
}
