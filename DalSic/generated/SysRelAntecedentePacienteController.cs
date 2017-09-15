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
    /// Controller class for Sys_RelAntecedentePaciente
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelAntecedentePacienteController
    {
        // Preload our schema..
        SysRelAntecedentePaciente thisSchemaLoad = new SysRelAntecedentePaciente();
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
        public SysRelAntecedentePacienteCollection FetchAll()
        {
            SysRelAntecedentePacienteCollection coll = new SysRelAntecedentePacienteCollection();
            Query qry = new Query(SysRelAntecedentePaciente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelAntecedentePacienteCollection FetchByID(object IdRelAntecedentePaciente)
        {
            SysRelAntecedentePacienteCollection coll = new SysRelAntecedentePacienteCollection().Where("idRelAntecedentePaciente", IdRelAntecedentePaciente).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelAntecedentePacienteCollection FetchByQuery(Query qry)
        {
            SysRelAntecedentePacienteCollection coll = new SysRelAntecedentePacienteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelAntecedentePaciente)
        {
            return (SysRelAntecedentePaciente.Delete(IdRelAntecedentePaciente) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelAntecedentePaciente)
        {
            return (SysRelAntecedentePaciente.Destroy(IdRelAntecedentePaciente) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdAntecedente,int? IdPaciente,int? IdClasificacion)
	    {
		    SysRelAntecedentePaciente item = new SysRelAntecedentePaciente();
		    
            item.IdAntecedente = IdAntecedente;
            
            item.IdPaciente = IdPaciente;
            
            item.IdClasificacion = IdClasificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelAntecedentePaciente,int? IdAntecedente,int? IdPaciente,int? IdClasificacion)
	    {
		    SysRelAntecedentePaciente item = new SysRelAntecedentePaciente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelAntecedentePaciente = IdRelAntecedentePaciente;
				
			item.IdAntecedente = IdAntecedente;
				
			item.IdPaciente = IdPaciente;
				
			item.IdClasificacion = IdClasificacion;
				
	        item.Save(UserName);
	    }
    }
}
