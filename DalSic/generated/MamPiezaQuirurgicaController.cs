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
    /// Controller class for MAM_PiezaQuirurgica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamPiezaQuirurgicaController
    {
        // Preload our schema..
        MamPiezaQuirurgica thisSchemaLoad = new MamPiezaQuirurgica();
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
        public MamPiezaQuirurgicaCollection FetchAll()
        {
            MamPiezaQuirurgicaCollection coll = new MamPiezaQuirurgicaCollection();
            Query qry = new Query(MamPiezaQuirurgica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamPiezaQuirurgicaCollection FetchByID(object IdPiezaQuirurgica)
        {
            MamPiezaQuirurgicaCollection coll = new MamPiezaQuirurgicaCollection().Where("idPiezaQuirurgica", IdPiezaQuirurgica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamPiezaQuirurgicaCollection FetchByQuery(Query qry)
        {
            MamPiezaQuirurgicaCollection coll = new MamPiezaQuirurgicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPiezaQuirurgica)
        {
            return (MamPiezaQuirurgica.Delete(IdPiezaQuirurgica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPiezaQuirurgica)
        {
            return (MamPiezaQuirurgica.Destroy(IdPiezaQuirurgica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int Edad,DateTime FechaTomaMuestra,DateTime FechaRecepcion,string NumeroIngreso,string MaterialIngresado,string CentinelaDerecho,string CentinelaIzquierdo,DateTime FechaInforme,int IdDiagnosticoHistologico,decimal TamanioTumor,int GangliosResecados,int GangliosPositivos,int ReceptorHormonalRE,int ReceptorHormonalRP,int CerbHerb,int IdResponsableInforme,int IdCentroSaludInforme,string Observaciones,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamPiezaQuirurgica item = new MamPiezaQuirurgica();
		    
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.FechaTomaMuestra = FechaTomaMuestra;
            
            item.FechaRecepcion = FechaRecepcion;
            
            item.NumeroIngreso = NumeroIngreso;
            
            item.MaterialIngresado = MaterialIngresado;
            
            item.CentinelaDerecho = CentinelaDerecho;
            
            item.CentinelaIzquierdo = CentinelaIzquierdo;
            
            item.FechaInforme = FechaInforme;
            
            item.IdDiagnosticoHistologico = IdDiagnosticoHistologico;
            
            item.TamanioTumor = TamanioTumor;
            
            item.GangliosResecados = GangliosResecados;
            
            item.GangliosPositivos = GangliosPositivos;
            
            item.ReceptorHormonalRE = ReceptorHormonalRE;
            
            item.ReceptorHormonalRP = ReceptorHormonalRP;
            
            item.CerbHerb = CerbHerb;
            
            item.IdResponsableInforme = IdResponsableInforme;
            
            item.IdCentroSaludInforme = IdCentroSaludInforme;
            
            item.Observaciones = Observaciones;
            
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
	    public void Update(int IdPiezaQuirurgica,int IdPaciente,int Edad,DateTime FechaTomaMuestra,DateTime FechaRecepcion,string NumeroIngreso,string MaterialIngresado,string CentinelaDerecho,string CentinelaIzquierdo,DateTime FechaInforme,int IdDiagnosticoHistologico,decimal TamanioTumor,int GangliosResecados,int GangliosPositivos,int ReceptorHormonalRE,int ReceptorHormonalRP,int CerbHerb,int IdResponsableInforme,int IdCentroSaludInforme,string Observaciones,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamPiezaQuirurgica item = new MamPiezaQuirurgica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPiezaQuirurgica = IdPiezaQuirurgica;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.FechaTomaMuestra = FechaTomaMuestra;
				
			item.FechaRecepcion = FechaRecepcion;
				
			item.NumeroIngreso = NumeroIngreso;
				
			item.MaterialIngresado = MaterialIngresado;
				
			item.CentinelaDerecho = CentinelaDerecho;
				
			item.CentinelaIzquierdo = CentinelaIzquierdo;
				
			item.FechaInforme = FechaInforme;
				
			item.IdDiagnosticoHistologico = IdDiagnosticoHistologico;
				
			item.TamanioTumor = TamanioTumor;
				
			item.GangliosResecados = GangliosResecados;
				
			item.GangliosPositivos = GangliosPositivos;
				
			item.ReceptorHormonalRE = ReceptorHormonalRE;
				
			item.ReceptorHormonalRP = ReceptorHormonalRP;
				
			item.CerbHerb = CerbHerb;
				
			item.IdResponsableInforme = IdResponsableInforme;
				
			item.IdCentroSaludInforme = IdCentroSaludInforme;
				
			item.Observaciones = Observaciones;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
