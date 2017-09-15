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
    /// Controller class for Guardia_Medicos_Funciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaMedicosFuncioneController
    {
        // Preload our schema..
        GuardiaMedicosFuncione thisSchemaLoad = new GuardiaMedicosFuncione();
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
        public GuardiaMedicosFuncioneCollection FetchAll()
        {
            GuardiaMedicosFuncioneCollection coll = new GuardiaMedicosFuncioneCollection();
            Query qry = new Query(GuardiaMedicosFuncione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaMedicosFuncioneCollection FetchByID(object IdMedico)
        {
            GuardiaMedicosFuncioneCollection coll = new GuardiaMedicosFuncioneCollection().Where("idMedico", IdMedico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaMedicosFuncioneCollection FetchByQuery(Query qry)
        {
            GuardiaMedicosFuncioneCollection coll = new GuardiaMedicosFuncioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMedico)
        {
            return (GuardiaMedicosFuncione.Delete(IdMedico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMedico)
        {
            return (GuardiaMedicosFuncione.Destroy(IdMedico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdMedico,string IdFuncion)
	    {
		    GuardiaMedicosFuncione item = new GuardiaMedicosFuncione();
		    
            item.IdMedico = IdMedico;
            
            item.IdFuncion = IdFuncion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMedico,string IdFuncion)
	    {
		    GuardiaMedicosFuncione item = new GuardiaMedicosFuncione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMedico = IdMedico;
				
			item.IdFuncion = IdFuncion;
				
	        item.Save(UserName);
	    }
    }
}
