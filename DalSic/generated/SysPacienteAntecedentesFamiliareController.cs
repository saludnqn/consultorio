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
    /// Controller class for Sys_PacienteAntecedentesFamiliares
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysPacienteAntecedentesFamiliareController
    {
        // Preload our schema..
        SysPacienteAntecedentesFamiliare thisSchemaLoad = new SysPacienteAntecedentesFamiliare();
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
        public SysPacienteAntecedentesFamiliareCollection FetchAll()
        {
            SysPacienteAntecedentesFamiliareCollection coll = new SysPacienteAntecedentesFamiliareCollection();
            Query qry = new Query(SysPacienteAntecedentesFamiliare.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPacienteAntecedentesFamiliareCollection FetchByID(object Id)
        {
            SysPacienteAntecedentesFamiliareCollection coll = new SysPacienteAntecedentesFamiliareCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPacienteAntecedentesFamiliareCollection FetchByQuery(Query qry)
        {
            SysPacienteAntecedentesFamiliareCollection coll = new SysPacienteAntecedentesFamiliareCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (SysPacienteAntecedentesFamiliare.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (SysPacienteAntecedentesFamiliare.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdPaciente,int? IdParentesco,int? IdCie10,DateTime? FechaCarga,int? IdUsuarioCarga)
	    {
		    SysPacienteAntecedentesFamiliare item = new SysPacienteAntecedentesFamiliare();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdParentesco = IdParentesco;
            
            item.IdCie10 = IdCie10;
            
            item.FechaCarga = FechaCarga;
            
            item.IdUsuarioCarga = IdUsuarioCarga;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? IdPaciente,int? IdParentesco,int? IdCie10,DateTime? FechaCarga,int? IdUsuarioCarga)
	    {
		    SysPacienteAntecedentesFamiliare item = new SysPacienteAntecedentesFamiliare();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IdPaciente = IdPaciente;
				
			item.IdParentesco = IdParentesco;
				
			item.IdCie10 = IdCie10;
				
			item.FechaCarga = FechaCarga;
				
			item.IdUsuarioCarga = IdUsuarioCarga;
				
	        item.Save(UserName);
	    }
    }
}
