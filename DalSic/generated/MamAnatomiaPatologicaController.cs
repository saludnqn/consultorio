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
    /// Controller class for MAM_AnatomiaPatologica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamAnatomiaPatologicaController
    {
        // Preload our schema..
        MamAnatomiaPatologica thisSchemaLoad = new MamAnatomiaPatologica();
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
        public MamAnatomiaPatologicaCollection FetchAll()
        {
            MamAnatomiaPatologicaCollection coll = new MamAnatomiaPatologicaCollection();
            Query qry = new Query(MamAnatomiaPatologica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamAnatomiaPatologicaCollection FetchByID(object IdAnatomiaPatologica)
        {
            MamAnatomiaPatologicaCollection coll = new MamAnatomiaPatologicaCollection().Where("idAnatomiaPatologica", IdAnatomiaPatologica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamAnatomiaPatologicaCollection FetchByQuery(Query qry)
        {
            MamAnatomiaPatologicaCollection coll = new MamAnatomiaPatologicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAnatomiaPatologica)
        {
            return (MamAnatomiaPatologica.Delete(IdAnatomiaPatologica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAnatomiaPatologica)
        {
            return (MamAnatomiaPatologica.Destroy(IdAnatomiaPatologica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int Edad,int GanglioAxilar,int NoduloMama,int Microcalcificaciones,int Piel,int Derrame,DateTime FechaTomaMuestra,DateTime FechaRecepcionMuestra,DateTime FechaInformeMuestra,string NumeroIngreso,int IdResponsableMuestra,int IdCentroSaludMuestra,int IdDiagnosticoCitologico,int IdDiagnosticoHistologico,DateTime FechaInforme,int IdResponsableInforme,int IdCentroSaludInforme,string Observaciones,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,string Guia,string Metodo)
	    {
		    MamAnatomiaPatologica item = new MamAnatomiaPatologica();
		    
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.GanglioAxilar = GanglioAxilar;
            
            item.NoduloMama = NoduloMama;
            
            item.Microcalcificaciones = Microcalcificaciones;
            
            item.Piel = Piel;
            
            item.Derrame = Derrame;
            
            item.FechaTomaMuestra = FechaTomaMuestra;
            
            item.FechaRecepcionMuestra = FechaRecepcionMuestra;
            
            item.FechaInformeMuestra = FechaInformeMuestra;
            
            item.NumeroIngreso = NumeroIngreso;
            
            item.IdResponsableMuestra = IdResponsableMuestra;
            
            item.IdCentroSaludMuestra = IdCentroSaludMuestra;
            
            item.IdDiagnosticoCitologico = IdDiagnosticoCitologico;
            
            item.IdDiagnosticoHistologico = IdDiagnosticoHistologico;
            
            item.FechaInforme = FechaInforme;
            
            item.IdResponsableInforme = IdResponsableInforme;
            
            item.IdCentroSaludInforme = IdCentroSaludInforme;
            
            item.Observaciones = Observaciones;
            
            item.Activo = Activo;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.Guia = Guia;
            
            item.Metodo = Metodo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAnatomiaPatologica,int IdPaciente,int Edad,int GanglioAxilar,int NoduloMama,int Microcalcificaciones,int Piel,int Derrame,DateTime FechaTomaMuestra,DateTime FechaRecepcionMuestra,DateTime FechaInformeMuestra,string NumeroIngreso,int IdResponsableMuestra,int IdCentroSaludMuestra,int IdDiagnosticoCitologico,int IdDiagnosticoHistologico,DateTime FechaInforme,int IdResponsableInforme,int IdCentroSaludInforme,string Observaciones,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,string Guia,string Metodo)
	    {
		    MamAnatomiaPatologica item = new MamAnatomiaPatologica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAnatomiaPatologica = IdAnatomiaPatologica;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.GanglioAxilar = GanglioAxilar;
				
			item.NoduloMama = NoduloMama;
				
			item.Microcalcificaciones = Microcalcificaciones;
				
			item.Piel = Piel;
				
			item.Derrame = Derrame;
				
			item.FechaTomaMuestra = FechaTomaMuestra;
				
			item.FechaRecepcionMuestra = FechaRecepcionMuestra;
				
			item.FechaInformeMuestra = FechaInformeMuestra;
				
			item.NumeroIngreso = NumeroIngreso;
				
			item.IdResponsableMuestra = IdResponsableMuestra;
				
			item.IdCentroSaludMuestra = IdCentroSaludMuestra;
				
			item.IdDiagnosticoCitologico = IdDiagnosticoCitologico;
				
			item.IdDiagnosticoHistologico = IdDiagnosticoHistologico;
				
			item.FechaInforme = FechaInforme;
				
			item.IdResponsableInforme = IdResponsableInforme;
				
			item.IdCentroSaludInforme = IdCentroSaludInforme;
				
			item.Observaciones = Observaciones;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.Guia = Guia;
				
			item.Metodo = Metodo;
				
	        item.Save(UserName);
	    }
    }
}
