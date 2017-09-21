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
    /// Controller class for CON_AgendaProfesional
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaProfesionalController
    {
        // Preload our schema..
        ConAgendaProfesional thisSchemaLoad = new ConAgendaProfesional();
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
        public ConAgendaProfesionalCollection FetchAll()
        {
            ConAgendaProfesionalCollection coll = new ConAgendaProfesionalCollection();
            Query qry = new Query(ConAgendaProfesional.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaProfesionalCollection FetchByID(object IdAgendaProfesional)
        {
            ConAgendaProfesionalCollection coll = new ConAgendaProfesionalCollection().Where("idAgendaProfesional", IdAgendaProfesional).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaProfesionalCollection FetchByQuery(Query qry)
        {
            ConAgendaProfesionalCollection coll = new ConAgendaProfesionalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgendaProfesional)
        {
            return (ConAgendaProfesional.Delete(IdAgendaProfesional) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgendaProfesional)
        {
            return (ConAgendaProfesional.Destroy(IdAgendaProfesional) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgenda,int IdProfesional,bool Baja,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdEspecialidad)
	    {
		    ConAgendaProfesional item = new ConAgendaProfesional();
		    
            item.IdAgenda = IdAgenda;
            
            item.IdProfesional = IdProfesional;
            
            item.Baja = Baja;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdEspecialidad = IdEspecialidad;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgendaProfesional,int IdAgenda,int IdProfesional,bool Baja,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdEspecialidad)
	    {
		    ConAgendaProfesional item = new ConAgendaProfesional();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgendaProfesional = IdAgendaProfesional;
				
			item.IdAgenda = IdAgenda;
				
			item.IdProfesional = IdProfesional;
				
			item.Baja = Baja;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdEspecialidad = IdEspecialidad;
				
	        item.Save(UserName);
	    }
    }
}
