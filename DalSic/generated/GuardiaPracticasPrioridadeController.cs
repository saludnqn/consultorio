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
    /// Controller class for Guardia_Practicas_Prioridades
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaPracticasPrioridadeController
    {
        // Preload our schema..
        GuardiaPracticasPrioridade thisSchemaLoad = new GuardiaPracticasPrioridade();
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
        public GuardiaPracticasPrioridadeCollection FetchAll()
        {
            GuardiaPracticasPrioridadeCollection coll = new GuardiaPracticasPrioridadeCollection();
            Query qry = new Query(GuardiaPracticasPrioridade.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaPracticasPrioridadeCollection FetchByID(object Id)
        {
            GuardiaPracticasPrioridadeCollection coll = new GuardiaPracticasPrioridadeCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaPracticasPrioridadeCollection FetchByQuery(Query qry)
        {
            GuardiaPracticasPrioridadeCollection coll = new GuardiaPracticasPrioridadeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaPracticasPrioridade.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaPracticasPrioridade.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Id,string Nombre)
	    {
		    GuardiaPracticasPrioridade item = new GuardiaPracticasPrioridade();
		    
            item.Id = Id;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre)
	    {
		    GuardiaPracticasPrioridade item = new GuardiaPracticasPrioridade();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
