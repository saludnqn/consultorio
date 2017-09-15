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
    /// Controller class for MAM_Ecografia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamEcografiumController
    {
        // Preload our schema..
        MamEcografium thisSchemaLoad = new MamEcografium();
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
        public MamEcografiumCollection FetchAll()
        {
            MamEcografiumCollection coll = new MamEcografiumCollection();
            Query qry = new Query(MamEcografium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEcografiumCollection FetchByID(object IdEcografiaMamaria)
        {
            MamEcografiumCollection coll = new MamEcografiumCollection().Where("idEcografiaMamaria", IdEcografiaMamaria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEcografiumCollection FetchByQuery(Query qry)
        {
            MamEcografiumCollection coll = new MamEcografiumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEcografiaMamaria)
        {
            return (MamEcografium.Delete(IdEcografiaMamaria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEcografiaMamaria)
        {
            return (MamEcografium.Destroy(IdEcografiaMamaria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int Edad,int IdMotivoEstudio,DateTime FechaEcografia,int IdEfectorSolicita,int IdEfectorInforma,int IdProfesionalSolicita,DateTime FechaInforme,int IdBiradsI,int IdBiradsD,int IdBiradsDef,string Informe,string MaterialRemitido,int IdProfesionalResponsable,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int IdEfectorRealizaEstudio,int IdTipoEquipo,int IdProfesionalTecnico,string Protocolo)
	    {
		    MamEcografium item = new MamEcografium();
		    
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.IdMotivoEstudio = IdMotivoEstudio;
            
            item.FechaEcografia = FechaEcografia;
            
            item.IdEfectorSolicita = IdEfectorSolicita;
            
            item.IdEfectorInforma = IdEfectorInforma;
            
            item.IdProfesionalSolicita = IdProfesionalSolicita;
            
            item.FechaInforme = FechaInforme;
            
            item.IdBiradsI = IdBiradsI;
            
            item.IdBiradsD = IdBiradsD;
            
            item.IdBiradsDef = IdBiradsDef;
            
            item.Informe = Informe;
            
            item.MaterialRemitido = MaterialRemitido;
            
            item.IdProfesionalResponsable = IdProfesionalResponsable;
            
            item.Activo = Activo;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdEfectorRealizaEstudio = IdEfectorRealizaEstudio;
            
            item.IdTipoEquipo = IdTipoEquipo;
            
            item.IdProfesionalTecnico = IdProfesionalTecnico;
            
            item.Protocolo = Protocolo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEcografiaMamaria,int IdPaciente,int Edad,int IdMotivoEstudio,DateTime FechaEcografia,int IdEfectorSolicita,int IdEfectorInforma,int IdProfesionalSolicita,DateTime FechaInforme,int IdBiradsI,int IdBiradsD,int IdBiradsDef,string Informe,string MaterialRemitido,int IdProfesionalResponsable,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int IdEfectorRealizaEstudio,int IdTipoEquipo,int IdProfesionalTecnico,string Protocolo)
	    {
		    MamEcografium item = new MamEcografium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEcografiaMamaria = IdEcografiaMamaria;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.IdMotivoEstudio = IdMotivoEstudio;
				
			item.FechaEcografia = FechaEcografia;
				
			item.IdEfectorSolicita = IdEfectorSolicita;
				
			item.IdEfectorInforma = IdEfectorInforma;
				
			item.IdProfesionalSolicita = IdProfesionalSolicita;
				
			item.FechaInforme = FechaInforme;
				
			item.IdBiradsI = IdBiradsI;
				
			item.IdBiradsD = IdBiradsD;
				
			item.IdBiradsDef = IdBiradsDef;
				
			item.Informe = Informe;
				
			item.MaterialRemitido = MaterialRemitido;
				
			item.IdProfesionalResponsable = IdProfesionalResponsable;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdEfectorRealizaEstudio = IdEfectorRealizaEstudio;
				
			item.IdTipoEquipo = IdTipoEquipo;
				
			item.IdProfesionalTecnico = IdProfesionalTecnico;
				
			item.Protocolo = Protocolo;
				
	        item.Save(UserName);
	    }
    }
}
