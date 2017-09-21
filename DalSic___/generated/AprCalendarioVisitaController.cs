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
    /// Controller class for APR_CalendarioVisitas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprCalendarioVisitaController
    {
        // Preload our schema..
        AprCalendarioVisita thisSchemaLoad = new AprCalendarioVisita();
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
        public AprCalendarioVisitaCollection FetchAll()
        {
            AprCalendarioVisitaCollection coll = new AprCalendarioVisitaCollection();
            Query qry = new Query(AprCalendarioVisita.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCalendarioVisitaCollection FetchByID(object IdCalendarioVisitas)
        {
            AprCalendarioVisitaCollection coll = new AprCalendarioVisitaCollection().Where("idCalendarioVisitas", IdCalendarioVisitas).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCalendarioVisitaCollection FetchByQuery(Query qry)
        {
            AprCalendarioVisitaCollection coll = new AprCalendarioVisitaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCalendarioVisitas)
        {
            return (AprCalendarioVisita.Delete(IdCalendarioVisitas) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCalendarioVisitas)
        {
            return (AprCalendarioVisita.Destroy(IdCalendarioVisitas) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int EdadSemanas,string NombreEdad,bool Enfermeria,bool Odontologia,bool Medico,bool Hemoglobina,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprCalendarioVisita item = new AprCalendarioVisita();
		    
            item.EdadSemanas = EdadSemanas;
            
            item.NombreEdad = NombreEdad;
            
            item.Enfermeria = Enfermeria;
            
            item.Odontologia = Odontologia;
            
            item.Medico = Medico;
            
            item.Hemoglobina = Hemoglobina;
            
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
	    public void Update(int IdCalendarioVisitas,int EdadSemanas,string NombreEdad,bool Enfermeria,bool Odontologia,bool Medico,bool Hemoglobina,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprCalendarioVisita item = new AprCalendarioVisita();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCalendarioVisitas = IdCalendarioVisitas;
				
			item.EdadSemanas = EdadSemanas;
				
			item.NombreEdad = NombreEdad;
				
			item.Enfermeria = Enfermeria;
				
			item.Odontologia = Odontologia;
				
			item.Medico = Medico;
				
			item.Hemoglobina = Hemoglobina;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
