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
    /// Controller class for MAM_EstudiosAdicionales
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamEstudiosAdicionaleController
    {
        // Preload our schema..
        MamEstudiosAdicionale thisSchemaLoad = new MamEstudiosAdicionale();
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
        public MamEstudiosAdicionaleCollection FetchAll()
        {
            MamEstudiosAdicionaleCollection coll = new MamEstudiosAdicionaleCollection();
            Query qry = new Query(MamEstudiosAdicionale.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstudiosAdicionaleCollection FetchByID(object IdEstudioAdicional)
        {
            MamEstudiosAdicionaleCollection coll = new MamEstudiosAdicionaleCollection().Where("idEstudioAdicional", IdEstudioAdicional).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstudiosAdicionaleCollection FetchByQuery(Query qry)
        {
            MamEstudiosAdicionaleCollection coll = new MamEstudiosAdicionaleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioAdicional)
        {
            return (MamEstudiosAdicionale.Delete(IdEstudioAdicional) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioAdicional)
        {
            return (MamEstudiosAdicionale.Destroy(IdEstudioAdicional) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int Edad,int IdMotivoEstudio,DateTime FechaEstudio,int Magnificada,int IdBiradsI,int IdBiradsD,int IdBiradsDef,string Informe,int IdProfesionalResponsable,int IdCentroSalud,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int IdEfectorRealizaEstudio,int IdTipoEquipo,int IdProfesionalTecnico,DateTime FechaInforme,string Protocolo,int Tomosintesis)
	    {
		    MamEstudiosAdicionale item = new MamEstudiosAdicionale();
		    
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.IdMotivoEstudio = IdMotivoEstudio;
            
            item.FechaEstudio = FechaEstudio;
            
            item.Magnificada = Magnificada;
            
            item.IdBiradsI = IdBiradsI;
            
            item.IdBiradsD = IdBiradsD;
            
            item.IdBiradsDef = IdBiradsDef;
            
            item.Informe = Informe;
            
            item.IdProfesionalResponsable = IdProfesionalResponsable;
            
            item.IdCentroSalud = IdCentroSalud;
            
            item.Activo = Activo;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdEfectorRealizaEstudio = IdEfectorRealizaEstudio;
            
            item.IdTipoEquipo = IdTipoEquipo;
            
            item.IdProfesionalTecnico = IdProfesionalTecnico;
            
            item.FechaInforme = FechaInforme;
            
            item.Protocolo = Protocolo;
            
            item.Tomosintesis = Tomosintesis;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioAdicional,int IdPaciente,int Edad,int IdMotivoEstudio,DateTime FechaEstudio,int Magnificada,int IdBiradsI,int IdBiradsD,int IdBiradsDef,string Informe,int IdProfesionalResponsable,int IdCentroSalud,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int IdEfectorRealizaEstudio,int IdTipoEquipo,int IdProfesionalTecnico,DateTime FechaInforme,string Protocolo,int Tomosintesis)
	    {
		    MamEstudiosAdicionale item = new MamEstudiosAdicionale();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioAdicional = IdEstudioAdicional;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.IdMotivoEstudio = IdMotivoEstudio;
				
			item.FechaEstudio = FechaEstudio;
				
			item.Magnificada = Magnificada;
				
			item.IdBiradsI = IdBiradsI;
				
			item.IdBiradsD = IdBiradsD;
				
			item.IdBiradsDef = IdBiradsDef;
				
			item.Informe = Informe;
				
			item.IdProfesionalResponsable = IdProfesionalResponsable;
				
			item.IdCentroSalud = IdCentroSalud;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdEfectorRealizaEstudio = IdEfectorRealizaEstudio;
				
			item.IdTipoEquipo = IdTipoEquipo;
				
			item.IdProfesionalTecnico = IdProfesionalTecnico;
				
			item.FechaInforme = FechaInforme;
				
			item.Protocolo = Protocolo;
				
			item.Tomosintesis = Tomosintesis;
				
	        item.Save(UserName);
	    }
    }
}
