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
    /// Controller class for APR_ControlNiñoSanoConsultorio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprControlNiñoSanoConsultorioController
    {
        // Preload our schema..
        AprControlNiñoSanoConsultorio thisSchemaLoad = new AprControlNiñoSanoConsultorio();
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
        public AprControlNiñoSanoConsultorioCollection FetchAll()
        {
            AprControlNiñoSanoConsultorioCollection coll = new AprControlNiñoSanoConsultorioCollection();
            Query qry = new Query(AprControlNiñoSanoConsultorio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoConsultorioCollection FetchByID(object IdControlNiñoSanoConsultorio)
        {
            AprControlNiñoSanoConsultorioCollection coll = new AprControlNiñoSanoConsultorioCollection().Where("idControlNiñoSanoConsultorio", IdControlNiñoSanoConsultorio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoConsultorioCollection FetchByQuery(Query qry)
        {
            AprControlNiñoSanoConsultorioCollection coll = new AprControlNiñoSanoConsultorioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdControlNiñoSanoConsultorio)
        {
            return (AprControlNiñoSanoConsultorio.Delete(IdControlNiñoSanoConsultorio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdControlNiñoSanoConsultorio)
        {
            return (AprControlNiñoSanoConsultorio.Destroy(IdControlNiñoSanoConsultorio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdControlNiñoSano,int? IdTipoLactancia,int? IdIntervencion,DateTime? FechaProximoControl,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprControlNiñoSanoConsultorio item = new AprControlNiñoSanoConsultorio();
		    
            item.IdControlNiñoSano = IdControlNiñoSano;
            
            item.IdTipoLactancia = IdTipoLactancia;
            
            item.IdIntervencion = IdIntervencion;
            
            item.FechaProximoControl = FechaProximoControl;
            
            item.Observacion = Observacion;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdControlNiñoSanoConsultorio,int IdControlNiñoSano,int? IdTipoLactancia,int? IdIntervencion,DateTime? FechaProximoControl,string Observacion,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprControlNiñoSanoConsultorio item = new AprControlNiñoSanoConsultorio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdControlNiñoSanoConsultorio = IdControlNiñoSanoConsultorio;
				
			item.IdControlNiñoSano = IdControlNiñoSano;
				
			item.IdTipoLactancia = IdTipoLactancia;
				
			item.IdIntervencion = IdIntervencion;
				
			item.FechaProximoControl = FechaProximoControl;
				
			item.Observacion = Observacion;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
