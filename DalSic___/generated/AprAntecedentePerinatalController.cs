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
    /// Controller class for APR_AntecedentePerinatal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAntecedentePerinatalController
    {
        // Preload our schema..
        AprAntecedentePerinatal thisSchemaLoad = new AprAntecedentePerinatal();
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
        public AprAntecedentePerinatalCollection FetchAll()
        {
            AprAntecedentePerinatalCollection coll = new AprAntecedentePerinatalCollection();
            Query qry = new Query(AprAntecedentePerinatal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAntecedentePerinatalCollection FetchByID(object IdAntecedentePerinatal)
        {
            AprAntecedentePerinatalCollection coll = new AprAntecedentePerinatalCollection().Where("idAntecedentePerinatal", IdAntecedentePerinatal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAntecedentePerinatalCollection FetchByQuery(Query qry)
        {
            AprAntecedentePerinatalCollection coll = new AprAntecedentePerinatalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAntecedentePerinatal)
        {
            return (AprAntecedentePerinatal.Delete(IdAntecedentePerinatal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAntecedentePerinatal)
        {
            return (AprAntecedentePerinatal.Destroy(IdAntecedentePerinatal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,DateTime FechaGestacion,DateTime FechaFinalizacion,int IdModoFinalizacionEmbarazo)
	    {
		    AprAntecedentePerinatal item = new AprAntecedentePerinatal();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.FechaGestacion = FechaGestacion;
            
            item.FechaFinalizacion = FechaFinalizacion;
            
            item.IdModoFinalizacionEmbarazo = IdModoFinalizacionEmbarazo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAntecedentePerinatal,int IdEfector,int IdPaciente,DateTime FechaGestacion,DateTime FechaFinalizacion,int IdModoFinalizacionEmbarazo)
	    {
		    AprAntecedentePerinatal item = new AprAntecedentePerinatal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAntecedentePerinatal = IdAntecedentePerinatal;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.FechaGestacion = FechaGestacion;
				
			item.FechaFinalizacion = FechaFinalizacion;
				
			item.IdModoFinalizacionEmbarazo = IdModoFinalizacionEmbarazo;
				
	        item.Save(UserName);
	    }
    }
}
