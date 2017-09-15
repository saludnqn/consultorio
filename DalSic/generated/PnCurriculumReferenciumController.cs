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
    /// Controller class for PN_curriculum_referencia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCurriculumReferenciumController
    {
        // Preload our schema..
        PnCurriculumReferencium thisSchemaLoad = new PnCurriculumReferencium();
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
        public PnCurriculumReferenciumCollection FetchAll()
        {
            PnCurriculumReferenciumCollection coll = new PnCurriculumReferenciumCollection();
            Query qry = new Query(PnCurriculumReferencium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCurriculumReferenciumCollection FetchByID(object IdCurriculumReferencia)
        {
            PnCurriculumReferenciumCollection coll = new PnCurriculumReferenciumCollection().Where("id_curriculum_referencia", IdCurriculumReferencia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCurriculumReferenciumCollection FetchByQuery(Query qry)
        {
            PnCurriculumReferenciumCollection coll = new PnCurriculumReferenciumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCurriculumReferencia)
        {
            return (PnCurriculumReferencium.Delete(IdCurriculumReferencia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCurriculumReferencia)
        {
            return (PnCurriculumReferencium.Destroy(IdCurriculumReferencia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdLegajo,string Empleador,string DomicilioEmpresa,DateTime? Desde,DateTime? Hasta,string Tareas,string Certificado,string Referencias,string Domicilio,string Telefono)
	    {
		    PnCurriculumReferencium item = new PnCurriculumReferencium();
		    
            item.IdLegajo = IdLegajo;
            
            item.Empleador = Empleador;
            
            item.DomicilioEmpresa = DomicilioEmpresa;
            
            item.Desde = Desde;
            
            item.Hasta = Hasta;
            
            item.Tareas = Tareas;
            
            item.Certificado = Certificado;
            
            item.Referencias = Referencias;
            
            item.Domicilio = Domicilio;
            
            item.Telefono = Telefono;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCurriculumReferencia,int IdLegajo,string Empleador,string DomicilioEmpresa,DateTime? Desde,DateTime? Hasta,string Tareas,string Certificado,string Referencias,string Domicilio,string Telefono)
	    {
		    PnCurriculumReferencium item = new PnCurriculumReferencium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCurriculumReferencia = IdCurriculumReferencia;
				
			item.IdLegajo = IdLegajo;
				
			item.Empleador = Empleador;
				
			item.DomicilioEmpresa = DomicilioEmpresa;
				
			item.Desde = Desde;
				
			item.Hasta = Hasta;
				
			item.Tareas = Tareas;
				
			item.Certificado = Certificado;
				
			item.Referencias = Referencias;
				
			item.Domicilio = Domicilio;
				
			item.Telefono = Telefono;
				
	        item.Save(UserName);
	    }
    }
}
