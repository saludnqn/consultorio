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
    /// Controller class for Sys_RelPacienteObraSocial
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelPacienteObraSocialController
    {
        // Preload our schema..
        SysRelPacienteObraSocial thisSchemaLoad = new SysRelPacienteObraSocial();
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
        public SysRelPacienteObraSocialCollection FetchAll()
        {
            SysRelPacienteObraSocialCollection coll = new SysRelPacienteObraSocialCollection();
            Query qry = new Query(SysRelPacienteObraSocial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelPacienteObraSocialCollection FetchByID(object IdRelPacienteObraSocial)
        {
            SysRelPacienteObraSocialCollection coll = new SysRelPacienteObraSocialCollection().Where("idRelPacienteObraSocial", IdRelPacienteObraSocial).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelPacienteObraSocialCollection FetchByQuery(Query qry)
        {
            SysRelPacienteObraSocialCollection coll = new SysRelPacienteObraSocialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelPacienteObraSocial)
        {
            return (SysRelPacienteObraSocial.Delete(IdRelPacienteObraSocial) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelPacienteObraSocial)
        {
            return (SysRelPacienteObraSocial.Destroy(IdRelPacienteObraSocial) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int IdObraSocial,string NumeroAfiliado,DateTime FechaAlta)
	    {
		    SysRelPacienteObraSocial item = new SysRelPacienteObraSocial();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdObraSocial = IdObraSocial;
            
            item.NumeroAfiliado = NumeroAfiliado;
            
            item.FechaAlta = FechaAlta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelPacienteObraSocial,int IdPaciente,int IdObraSocial,string NumeroAfiliado,DateTime FechaAlta)
	    {
		    SysRelPacienteObraSocial item = new SysRelPacienteObraSocial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelPacienteObraSocial = IdRelPacienteObraSocial;
				
			item.IdPaciente = IdPaciente;
				
			item.IdObraSocial = IdObraSocial;
				
			item.NumeroAfiliado = NumeroAfiliado;
				
			item.FechaAlta = FechaAlta;
				
	        item.Save(UserName);
	    }
    }
}
