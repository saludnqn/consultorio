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
    /// Controller class for APR_CalendarioVacuna
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprCalendarioVacunaController
    {
        // Preload our schema..
        AprCalendarioVacuna thisSchemaLoad = new AprCalendarioVacuna();
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
        public AprCalendarioVacunaCollection FetchAll()
        {
            AprCalendarioVacunaCollection coll = new AprCalendarioVacunaCollection();
            Query qry = new Query(AprCalendarioVacuna.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCalendarioVacunaCollection FetchByID(object IdCalendarioVacuna)
        {
            AprCalendarioVacunaCollection coll = new AprCalendarioVacunaCollection().Where("idCalendarioVacuna", IdCalendarioVacuna).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCalendarioVacunaCollection FetchByQuery(Query qry)
        {
            AprCalendarioVacunaCollection coll = new AprCalendarioVacunaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCalendarioVacuna)
        {
            return (AprCalendarioVacuna.Delete(IdCalendarioVacuna) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCalendarioVacuna)
        {
            return (AprCalendarioVacuna.Destroy(IdCalendarioVacuna) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdVacuna,string NombreVacuna,int IdNumeroDosis,int EdadSemanas,string NombreEdad,bool Obligatoria,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprCalendarioVacuna item = new AprCalendarioVacuna();
		    
            item.IdVacuna = IdVacuna;
            
            item.NombreVacuna = NombreVacuna;
            
            item.IdNumeroDosis = IdNumeroDosis;
            
            item.EdadSemanas = EdadSemanas;
            
            item.NombreEdad = NombreEdad;
            
            item.Obligatoria = Obligatoria;
            
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
	    public void Update(int IdCalendarioVacuna,int IdVacuna,string NombreVacuna,int IdNumeroDosis,int EdadSemanas,string NombreEdad,bool Obligatoria,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprCalendarioVacuna item = new AprCalendarioVacuna();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCalendarioVacuna = IdCalendarioVacuna;
				
			item.IdVacuna = IdVacuna;
				
			item.NombreVacuna = NombreVacuna;
				
			item.IdNumeroDosis = IdNumeroDosis;
				
			item.EdadSemanas = EdadSemanas;
				
			item.NombreEdad = NombreEdad;
				
			item.Obligatoria = Obligatoria;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
