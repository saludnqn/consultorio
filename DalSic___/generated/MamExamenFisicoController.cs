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
    /// Controller class for MAM_ExamenFisico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamExamenFisicoController
    {
        // Preload our schema..
        MamExamenFisico thisSchemaLoad = new MamExamenFisico();
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
        public MamExamenFisicoCollection FetchAll()
        {
            MamExamenFisicoCollection coll = new MamExamenFisicoCollection();
            Query qry = new Query(MamExamenFisico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamExamenFisicoCollection FetchByID(object IdExamenFisico)
        {
            MamExamenFisicoCollection coll = new MamExamenFisicoCollection().Where("idExamenFisico", IdExamenFisico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamExamenFisicoCollection FetchByQuery(Query qry)
        {
            MamExamenFisicoCollection coll = new MamExamenFisicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdExamenFisico)
        {
            return (MamExamenFisico.Delete(IdExamenFisico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdExamenFisico)
        {
            return (MamExamenFisico.Destroy(IdExamenFisico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,DateTime Fecha,int EdadActual,int IdMotivoConsulta,int IdResultadoExFisico,int IdResponsableExamen,int IdCentroSalud,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamExamenFisico item = new MamExamenFisico();
		    
            item.IdPaciente = IdPaciente;
            
            item.Fecha = Fecha;
            
            item.EdadActual = EdadActual;
            
            item.IdMotivoConsulta = IdMotivoConsulta;
            
            item.IdResultadoExFisico = IdResultadoExFisico;
            
            item.IdResponsableExamen = IdResponsableExamen;
            
            item.IdCentroSalud = IdCentroSalud;
            
            item.Activo = Activo;
            
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
	    public void Update(int IdExamenFisico,int IdPaciente,DateTime Fecha,int EdadActual,int IdMotivoConsulta,int IdResultadoExFisico,int IdResponsableExamen,int IdCentroSalud,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamExamenFisico item = new MamExamenFisico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdExamenFisico = IdExamenFisico;
				
			item.IdPaciente = IdPaciente;
				
			item.Fecha = Fecha;
				
			item.EdadActual = EdadActual;
				
			item.IdMotivoConsulta = IdMotivoConsulta;
				
			item.IdResultadoExFisico = IdResultadoExFisico;
				
			item.IdResponsableExamen = IdResponsableExamen;
				
			item.IdCentroSalud = IdCentroSalud;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
