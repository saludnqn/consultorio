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
    /// Controller class for APR_ProblemasMenor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprProblemasMenorController
    {
        // Preload our schema..
        AprProblemasMenor thisSchemaLoad = new AprProblemasMenor();
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
        public AprProblemasMenorCollection FetchAll()
        {
            AprProblemasMenorCollection coll = new AprProblemasMenorCollection();
            Query qry = new Query(AprProblemasMenor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprProblemasMenorCollection FetchByID(object IdProblemaMenor)
        {
            AprProblemasMenorCollection coll = new AprProblemasMenorCollection().Where("idProblemaMenor", IdProblemaMenor).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprProblemasMenorCollection FetchByQuery(Query qry)
        {
            AprProblemasMenorCollection coll = new AprProblemasMenorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProblemaMenor)
        {
            return (AprProblemasMenor.Delete(IdProblemaMenor) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProblemaMenor)
        {
            return (AprProblemasMenor.Destroy(IdProblemaMenor) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,DateTime? Fecha,string Descripcion,string Intervencion,int? CODCIE10,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprProblemasMenor item = new AprProblemasMenor();
		    
            item.IdPaciente = IdPaciente;
            
            item.Fecha = Fecha;
            
            item.Descripcion = Descripcion;
            
            item.Intervencion = Intervencion;
            
            item.CODCIE10 = CODCIE10;
            
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
	    public void Update(int IdProblemaMenor,int IdPaciente,DateTime? Fecha,string Descripcion,string Intervencion,int? CODCIE10,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprProblemasMenor item = new AprProblemasMenor();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProblemaMenor = IdProblemaMenor;
				
			item.IdPaciente = IdPaciente;
				
			item.Fecha = Fecha;
				
			item.Descripcion = Descripcion;
				
			item.Intervencion = Intervencion;
				
			item.CODCIE10 = CODCIE10;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
