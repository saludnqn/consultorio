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
    /// Controller class for APR_RelRecienNacidoEnfermedad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprRelRecienNacidoEnfermedadController
    {
        // Preload our schema..
        AprRelRecienNacidoEnfermedad thisSchemaLoad = new AprRelRecienNacidoEnfermedad();
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
        public AprRelRecienNacidoEnfermedadCollection FetchAll()
        {
            AprRelRecienNacidoEnfermedadCollection coll = new AprRelRecienNacidoEnfermedadCollection();
            Query qry = new Query(AprRelRecienNacidoEnfermedad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelRecienNacidoEnfermedadCollection FetchByID(object IdRelacion)
        {
            AprRelRecienNacidoEnfermedadCollection coll = new AprRelRecienNacidoEnfermedadCollection().Where("idRelacion", IdRelacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRelRecienNacidoEnfermedadCollection FetchByQuery(Query qry)
        {
            AprRelRecienNacidoEnfermedadCollection coll = new AprRelRecienNacidoEnfermedadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelacion)
        {
            return (AprRelRecienNacidoEnfermedad.Delete(IdRelacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelacion)
        {
            return (AprRelRecienNacidoEnfermedad.Destroy(IdRelacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdRecienNacido,int CODCIE10,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelRecienNacidoEnfermedad item = new AprRelRecienNacidoEnfermedad();
		    
            item.IdEfector = IdEfector;
            
            item.IdRecienNacido = IdRecienNacido;
            
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
	    public void Update(int IdRelacion,int IdEfector,int IdRecienNacido,int CODCIE10,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRelRecienNacidoEnfermedad item = new AprRelRecienNacidoEnfermedad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelacion = IdRelacion;
				
			item.IdEfector = IdEfector;
				
			item.IdRecienNacido = IdRecienNacido;
				
			item.CODCIE10 = CODCIE10;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
