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
    /// Controller class for APR_AlertaControlMenor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAlertaControlMenorController
    {
        // Preload our schema..
        AprAlertaControlMenor thisSchemaLoad = new AprAlertaControlMenor();
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
        public AprAlertaControlMenorCollection FetchAll()
        {
            AprAlertaControlMenorCollection coll = new AprAlertaControlMenorCollection();
            Query qry = new Query(AprAlertaControlMenor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAlertaControlMenorCollection FetchByID(object IdAlerta)
        {
            AprAlertaControlMenorCollection coll = new AprAlertaControlMenorCollection().Where("idAlerta", IdAlerta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAlertaControlMenorCollection FetchByQuery(Query qry)
        {
            AprAlertaControlMenorCollection coll = new AprAlertaControlMenorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAlerta)
        {
            return (AprAlertaControlMenor.Delete(IdAlerta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAlerta)
        {
            return (AprAlertaControlMenor.Destroy(IdAlerta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdCalendarioVisitas,string Descripcion,string Comprobador,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprAlertaControlMenor item = new AprAlertaControlMenor();
		    
            item.IdCalendarioVisitas = IdCalendarioVisitas;
            
            item.Descripcion = Descripcion;
            
            item.Comprobador = Comprobador;
            
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
	    public void Update(int IdAlerta,int IdCalendarioVisitas,string Descripcion,string Comprobador,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprAlertaControlMenor item = new AprAlertaControlMenor();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAlerta = IdAlerta;
				
			item.IdCalendarioVisitas = IdCalendarioVisitas;
				
			item.Descripcion = Descripcion;
				
			item.Comprobador = Comprobador;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
