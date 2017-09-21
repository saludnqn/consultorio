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
    /// Controller class for PSM_EFisico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PsmEFisicoController
    {
        // Preload our schema..
        PsmEFisico thisSchemaLoad = new PsmEFisico();
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
        public PsmEFisicoCollection FetchAll()
        {
            PsmEFisicoCollection coll = new PsmEFisicoCollection();
            Query qry = new Query(PsmEFisico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PsmEFisicoCollection FetchByID(object IdPSMEFisico)
        {
            PsmEFisicoCollection coll = new PsmEFisicoCollection().Where("idPSMEFisico", IdPSMEFisico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PsmEFisicoCollection FetchByQuery(Query qry)
        {
            PsmEFisicoCollection coll = new PsmEFisicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPSMEFisico)
        {
            return (PsmEFisico.Delete(IdPSMEFisico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPSMEFisico)
        {
            return (PsmEFisico.Destroy(IdPSMEFisico) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(decimal IdPSMEFisico,decimal IdPSMEFisicoItems)
        {
            Query qry = new Query(PsmEFisico.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("IdPSMEFisico", IdPSMEFisico).AND("IdPSMEFisicoItems", IdPSMEFisicoItems);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(decimal IdPSMEFisico,decimal IdPSMEFisicoItems,string Nombre,string ExamenFisico,bool Activo)
	    {
		    PsmEFisico item = new PsmEFisico();
		    
            item.IdPSMEFisico = IdPSMEFisico;
            
            item.IdPSMEFisicoItems = IdPSMEFisicoItems;
            
            item.Nombre = Nombre;
            
            item.ExamenFisico = ExamenFisico;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(decimal IdPSMEFisico,decimal IdPSMEFisicoItems,string Nombre,string ExamenFisico,bool Activo)
	    {
		    PsmEFisico item = new PsmEFisico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPSMEFisico = IdPSMEFisico;
				
			item.IdPSMEFisicoItems = IdPSMEFisicoItems;
				
			item.Nombre = Nombre;
				
			item.ExamenFisico = ExamenFisico;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
