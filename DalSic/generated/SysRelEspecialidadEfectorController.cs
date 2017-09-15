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
    /// Controller class for Sys_RelEspecialidadEfector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelEspecialidadEfectorController
    {
        // Preload our schema..
        SysRelEspecialidadEfector thisSchemaLoad = new SysRelEspecialidadEfector();
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
        public SysRelEspecialidadEfectorCollection FetchAll()
        {
            SysRelEspecialidadEfectorCollection coll = new SysRelEspecialidadEfectorCollection();
            Query qry = new Query(SysRelEspecialidadEfector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelEspecialidadEfectorCollection FetchByID(object IdRelEspecialidadEfector)
        {
            SysRelEspecialidadEfectorCollection coll = new SysRelEspecialidadEfectorCollection().Where("idRelEspecialidadEfector", IdRelEspecialidadEfector).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelEspecialidadEfectorCollection FetchByQuery(Query qry)
        {
            SysRelEspecialidadEfectorCollection coll = new SysRelEspecialidadEfectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelEspecialidadEfector)
        {
            return (SysRelEspecialidadEfector.Delete(IdRelEspecialidadEfector) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelEspecialidadEfector)
        {
            return (SysRelEspecialidadEfector.Destroy(IdRelEspecialidadEfector) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEspecialidad,int IdEfector,int DuracionTurno,int PorcentajeTurnosDia,int PorcentajeTurnosAnticipado,int MaximoSobreturnos,int IdUsuarioRegistro,DateTime FechaRegistro)
	    {
		    SysRelEspecialidadEfector item = new SysRelEspecialidadEfector();
		    
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdEfector = IdEfector;
            
            item.DuracionTurno = DuracionTurno;
            
            item.PorcentajeTurnosDia = PorcentajeTurnosDia;
            
            item.PorcentajeTurnosAnticipado = PorcentajeTurnosAnticipado;
            
            item.MaximoSobreturnos = MaximoSobreturnos;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelEspecialidadEfector,int IdEspecialidad,int IdEfector,int DuracionTurno,int PorcentajeTurnosDia,int PorcentajeTurnosAnticipado,int MaximoSobreturnos,int IdUsuarioRegistro,DateTime FechaRegistro)
	    {
		    SysRelEspecialidadEfector item = new SysRelEspecialidadEfector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelEspecialidadEfector = IdRelEspecialidadEfector;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdEfector = IdEfector;
				
			item.DuracionTurno = DuracionTurno;
				
			item.PorcentajeTurnosDia = PorcentajeTurnosDia;
				
			item.PorcentajeTurnosAnticipado = PorcentajeTurnosAnticipado;
				
			item.MaximoSobreturnos = MaximoSobreturnos;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
	        item.Save(UserName);
	    }
    }
}
