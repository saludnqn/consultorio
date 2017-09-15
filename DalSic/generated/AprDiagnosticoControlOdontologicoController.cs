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
    /// Controller class for APR_DiagnosticoControlOdontologico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprDiagnosticoControlOdontologicoController
    {
        // Preload our schema..
        AprDiagnosticoControlOdontologico thisSchemaLoad = new AprDiagnosticoControlOdontologico();
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
        public AprDiagnosticoControlOdontologicoCollection FetchAll()
        {
            AprDiagnosticoControlOdontologicoCollection coll = new AprDiagnosticoControlOdontologicoCollection();
            Query qry = new Query(AprDiagnosticoControlOdontologico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprDiagnosticoControlOdontologicoCollection FetchByID(object IdDiagnosticoControlOdontologico)
        {
            AprDiagnosticoControlOdontologicoCollection coll = new AprDiagnosticoControlOdontologicoCollection().Where("idDiagnosticoControlOdontologico", IdDiagnosticoControlOdontologico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprDiagnosticoControlOdontologicoCollection FetchByQuery(Query qry)
        {
            AprDiagnosticoControlOdontologicoCollection coll = new AprDiagnosticoControlOdontologicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDiagnosticoControlOdontologico)
        {
            return (AprDiagnosticoControlOdontologico.Delete(IdDiagnosticoControlOdontologico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDiagnosticoControlOdontologico)
        {
            return (AprDiagnosticoControlOdontologico.Destroy(IdDiagnosticoControlOdontologico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprDiagnosticoControlOdontologico item = new AprDiagnosticoControlOdontologico();
		    
            item.Nombre = Nombre;
            
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
	    public void Update(int IdDiagnosticoControlOdontologico,string Nombre,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprDiagnosticoControlOdontologico item = new AprDiagnosticoControlOdontologico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDiagnosticoControlOdontologico = IdDiagnosticoControlOdontologico;
				
			item.Nombre = Nombre;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
