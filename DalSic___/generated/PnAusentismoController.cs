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
    /// Controller class for PN_ausentismo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAusentismoController
    {
        // Preload our schema..
        PnAusentismo thisSchemaLoad = new PnAusentismo();
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
        public PnAusentismoCollection FetchAll()
        {
            PnAusentismoCollection coll = new PnAusentismoCollection();
            Query qry = new Query(PnAusentismo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAusentismoCollection FetchByID(object IdLegajo)
        {
            PnAusentismoCollection coll = new PnAusentismoCollection().Where("id_legajo", IdLegajo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAusentismoCollection FetchByQuery(Query qry)
        {
            PnAusentismoCollection coll = new PnAusentismoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLegajo)
        {
            return (PnAusentismo.Delete(IdLegajo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLegajo)
        {
            return (PnAusentismo.Destroy(IdLegajo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(short Agno,short Inpuntualidad,short Inasistencia,short Enfermedad,short Accidente,short Licencias)
	    {
		    PnAusentismo item = new PnAusentismo();
		    
            item.Agno = Agno;
            
            item.Inpuntualidad = Inpuntualidad;
            
            item.Inasistencia = Inasistencia;
            
            item.Enfermedad = Enfermedad;
            
            item.Accidente = Accidente;
            
            item.Licencias = Licencias;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLegajo,short Agno,short Inpuntualidad,short Inasistencia,short Enfermedad,short Accidente,short Licencias)
	    {
		    PnAusentismo item = new PnAusentismo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLegajo = IdLegajo;
				
			item.Agno = Agno;
				
			item.Inpuntualidad = Inpuntualidad;
				
			item.Inasistencia = Inasistencia;
				
			item.Enfermedad = Enfermedad;
				
			item.Accidente = Accidente;
				
			item.Licencias = Licencias;
				
	        item.Save(UserName);
	    }
    }
}
