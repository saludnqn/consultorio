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
    /// Controller class for APR_RelRecienNacidoDefectoCongenito
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprRelRecienNacidoDefectoCongenitoController
    {
        // Preload our schema..
        AprRelRecienNacidoDefectoCongenito thisSchemaLoad = new AprRelRecienNacidoDefectoCongenito();
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
        public AprRelRecienNacidoDefectoCongenitoCollection FetchAll()
        {
            AprRelRecienNacidoDefectoCongenitoCollection coll = new AprRelRecienNacidoDefectoCongenitoCollection();
            Query qry = new Query(AprRelRecienNacidoDefectoCongenito.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelRecienNacidoDefectoCongenitoCollection FetchByID(object IdRelacion)
        {
            AprRelRecienNacidoDefectoCongenitoCollection coll = new AprRelRecienNacidoDefectoCongenitoCollection().Where("idRelacion", IdRelacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelRecienNacidoDefectoCongenitoCollection FetchByQuery(Query qry)
        {
            AprRelRecienNacidoDefectoCongenitoCollection coll = new AprRelRecienNacidoDefectoCongenitoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelacion)
        {
            return (AprRelRecienNacidoDefectoCongenito.Delete(IdRelacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelacion)
        {
            return (AprRelRecienNacidoDefectoCongenito.Destroy(IdRelacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdRecienNacido,int IdDefectoCongenito,bool? DefectoMayor,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelRecienNacidoDefectoCongenito item = new AprRelRecienNacidoDefectoCongenito();
		    
            item.IdEfector = IdEfector;
            
            item.IdRecienNacido = IdRecienNacido;
            
            item.IdDefectoCongenito = IdDefectoCongenito;
            
            item.DefectoMayor = DefectoMayor;
            
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
	    public void Update(int IdRelacion,int IdEfector,int IdRecienNacido,int IdDefectoCongenito,bool? DefectoMayor,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelRecienNacidoDefectoCongenito item = new AprRelRecienNacidoDefectoCongenito();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelacion = IdRelacion;
				
			item.IdEfector = IdEfector;
				
			item.IdRecienNacido = IdRecienNacido;
				
			item.IdDefectoCongenito = IdDefectoCongenito;
				
			item.DefectoMayor = DefectoMayor;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
