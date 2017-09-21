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
    /// Controller class for CON_AgendaGrupalPaciente
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConAgendaGrupalPacienteController
    {
        // Preload our schema..
        ConAgendaGrupalPaciente thisSchemaLoad = new ConAgendaGrupalPaciente();
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
        public ConAgendaGrupalPacienteCollection FetchAll()
        {
            ConAgendaGrupalPacienteCollection coll = new ConAgendaGrupalPacienteCollection();
            Query qry = new Query(ConAgendaGrupalPaciente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaGrupalPacienteCollection FetchByID(object IdAgendaGrupalPaciente)
        {
            ConAgendaGrupalPacienteCollection coll = new ConAgendaGrupalPacienteCollection().Where("idAgendaGrupalPaciente", IdAgendaGrupalPaciente).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConAgendaGrupalPacienteCollection FetchByQuery(Query qry)
        {
            ConAgendaGrupalPacienteCollection coll = new ConAgendaGrupalPacienteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgendaGrupalPaciente)
        {
            return (ConAgendaGrupalPaciente.Delete(IdAgendaGrupalPaciente) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgendaGrupalPaciente)
        {
            return (ConAgendaGrupalPaciente.Destroy(IdAgendaGrupalPaciente) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgendaGrupal,int IdPaciente,bool Asistio,string CreatedBy,string ModifiedBy,DateTime? CreatedOn,DateTime? ModifiedOn)
	    {
		    ConAgendaGrupalPaciente item = new ConAgendaGrupalPaciente();
		    
            item.IdAgendaGrupal = IdAgendaGrupal;
            
            item.IdPaciente = IdPaciente;
            
            item.Asistio = Asistio;
            
            item.CreatedBy = CreatedBy;
            
            item.ModifiedBy = ModifiedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgendaGrupalPaciente,int IdAgendaGrupal,int IdPaciente,bool Asistio,string CreatedBy,string ModifiedBy,DateTime? CreatedOn,DateTime? ModifiedOn)
	    {
		    ConAgendaGrupalPaciente item = new ConAgendaGrupalPaciente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgendaGrupalPaciente = IdAgendaGrupalPaciente;
				
			item.IdAgendaGrupal = IdAgendaGrupal;
				
			item.IdPaciente = IdPaciente;
				
			item.Asistio = Asistio;
				
			item.CreatedBy = CreatedBy;
				
			item.ModifiedBy = ModifiedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
