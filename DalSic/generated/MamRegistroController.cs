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
    /// Controller class for MAM_Registro
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamRegistroController
    {
        // Preload our schema..
        MamRegistro thisSchemaLoad = new MamRegistro();
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
        public MamRegistroCollection FetchAll()
        {
            MamRegistroCollection coll = new MamRegistroCollection();
            Query qry = new Query(MamRegistro.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamRegistroCollection FetchByID(object IdMamas)
        {
            MamRegistroCollection coll = new MamRegistroCollection().Where("idMamas", IdMamas).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamRegistroCollection FetchByQuery(Query qry)
        {
            MamRegistroCollection coll = new MamRegistroCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMamas)
        {
            return (MamRegistro.Delete(IdMamas) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMamas)
        {
            return (MamRegistro.Destroy(IdMamas) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfectorProcedencia,int IdPaciente,int Edad,DateTime FechaIngreso,string Observacion,int IdProfesionalSolicita,DateTime FechaPlaca,DateTime FechaInforme,string Informe,string Protocolo,int IdEfectorControl,string Procedimiento,int IdBiradsI,int IdBiradsD,int IdBiradsDef,int IdMotivo,int IdProfesionalInforma,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int IdEfectorRealizaEstudio,int IdTipoEquipo,int IdProfesionalTecnico)
	    {
		    MamRegistro item = new MamRegistro();
		    
            item.IdEfectorProcedencia = IdEfectorProcedencia;
            
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.FechaIngreso = FechaIngreso;
            
            item.Observacion = Observacion;
            
            item.IdProfesionalSolicita = IdProfesionalSolicita;
            
            item.FechaPlaca = FechaPlaca;
            
            item.FechaInforme = FechaInforme;
            
            item.Informe = Informe;
            
            item.Protocolo = Protocolo;
            
            item.IdEfectorControl = IdEfectorControl;
            
            item.Procedimiento = Procedimiento;
            
            item.IdBiradsI = IdBiradsI;
            
            item.IdBiradsD = IdBiradsD;
            
            item.IdBiradsDef = IdBiradsDef;
            
            item.IdMotivo = IdMotivo;
            
            item.IdProfesionalInforma = IdProfesionalInforma;
            
            item.Activo = Activo;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdEfectorRealizaEstudio = IdEfectorRealizaEstudio;
            
            item.IdTipoEquipo = IdTipoEquipo;
            
            item.IdProfesionalTecnico = IdProfesionalTecnico;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMamas,int IdEfectorProcedencia,int IdPaciente,int Edad,DateTime FechaIngreso,string Observacion,int IdProfesionalSolicita,DateTime FechaPlaca,DateTime FechaInforme,string Informe,string Protocolo,int IdEfectorControl,string Procedimiento,int IdBiradsI,int IdBiradsD,int IdBiradsDef,int IdMotivo,int IdProfesionalInforma,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int IdEfectorRealizaEstudio,int IdTipoEquipo,int IdProfesionalTecnico)
	    {
		    MamRegistro item = new MamRegistro();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMamas = IdMamas;
				
			item.IdEfectorProcedencia = IdEfectorProcedencia;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.FechaIngreso = FechaIngreso;
				
			item.Observacion = Observacion;
				
			item.IdProfesionalSolicita = IdProfesionalSolicita;
				
			item.FechaPlaca = FechaPlaca;
				
			item.FechaInforme = FechaInforme;
				
			item.Informe = Informe;
				
			item.Protocolo = Protocolo;
				
			item.IdEfectorControl = IdEfectorControl;
				
			item.Procedimiento = Procedimiento;
				
			item.IdBiradsI = IdBiradsI;
				
			item.IdBiradsD = IdBiradsD;
				
			item.IdBiradsDef = IdBiradsDef;
				
			item.IdMotivo = IdMotivo;
				
			item.IdProfesionalInforma = IdProfesionalInforma;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdEfectorRealizaEstudio = IdEfectorRealizaEstudio;
				
			item.IdTipoEquipo = IdTipoEquipo;
				
			item.IdProfesionalTecnico = IdProfesionalTecnico;
				
	        item.Save(UserName);
	    }
    }
}
