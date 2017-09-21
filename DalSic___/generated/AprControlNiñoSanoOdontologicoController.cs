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
    /// Controller class for APR_ControlNiñoSanoOdontologico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprControlNiñoSanoOdontologicoController
    {
        // Preload our schema..
        AprControlNiñoSanoOdontologico thisSchemaLoad = new AprControlNiñoSanoOdontologico();
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
        public AprControlNiñoSanoOdontologicoCollection FetchAll()
        {
            AprControlNiñoSanoOdontologicoCollection coll = new AprControlNiñoSanoOdontologicoCollection();
            Query qry = new Query(AprControlNiñoSanoOdontologico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoOdontologicoCollection FetchByID(object IdControlOdontologico)
        {
            AprControlNiñoSanoOdontologicoCollection coll = new AprControlNiñoSanoOdontologicoCollection().Where("idControlOdontologico", IdControlOdontologico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoOdontologicoCollection FetchByQuery(Query qry)
        {
            AprControlNiñoSanoOdontologicoCollection coll = new AprControlNiñoSanoOdontologicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdControlOdontologico)
        {
            return (AprControlNiñoSanoOdontologico.Delete(IdControlOdontologico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdControlOdontologico)
        {
            return (AprControlNiñoSanoOdontologico.Destroy(IdControlOdontologico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdControlNiñoSano,string Profesional,int IdDiagnosticoControlOdontologico,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,string Observacion)
	    {
		    AprControlNiñoSanoOdontologico item = new AprControlNiñoSanoOdontologico();
		    
            item.IdControlNiñoSano = IdControlNiñoSano;
            
            item.Profesional = Profesional;
            
            item.IdDiagnosticoControlOdontologico = IdDiagnosticoControlOdontologico;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.Observacion = Observacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdControlOdontologico,int IdControlNiñoSano,string Profesional,int IdDiagnosticoControlOdontologico,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,string Observacion)
	    {
		    AprControlNiñoSanoOdontologico item = new AprControlNiñoSanoOdontologico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdControlOdontologico = IdControlOdontologico;
				
			item.IdControlNiñoSano = IdControlNiñoSano;
				
			item.Profesional = Profesional;
				
			item.IdDiagnosticoControlOdontologico = IdDiagnosticoControlOdontologico;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.Observacion = Observacion;
				
	        item.Save(UserName);
	    }
    }
}
