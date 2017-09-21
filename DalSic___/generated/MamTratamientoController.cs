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
    /// Controller class for MAM_Tratamientos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamTratamientoController
    {
        // Preload our schema..
        MamTratamiento thisSchemaLoad = new MamTratamiento();
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
        public MamTratamientoCollection FetchAll()
        {
            MamTratamientoCollection coll = new MamTratamientoCollection();
            Query qry = new Query(MamTratamiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTratamientoCollection FetchByID(object IdTratamiento)
        {
            MamTratamientoCollection coll = new MamTratamientoCollection().Where("idTratamiento", IdTratamiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTratamientoCollection FetchByQuery(Query qry)
        {
            MamTratamientoCollection coll = new MamTratamientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTratamiento)
        {
            return (MamTratamiento.Delete(IdTratamiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTratamiento)
        {
            return (MamTratamiento.Destroy(IdTratamiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,DateTime Fecha,int Edad,int Neoadyuvancia,DateTime FechaInicioNeoadyuvancia,int Quimioterapia,DateTime FechaInicioQuimio,int Radioterapia,DateTime FechaInicioRadioterapia,int Trastuzumab,DateTime FechaInicioTrastuzumab,string Hormonoterapia,DateTime FechaHormonoterapiaInicial,DateTime FechaHormonoterapia,string Observacion,int IdResponsableExamen,int IdCentroSalud,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamTratamiento item = new MamTratamiento();
		    
            item.IdPaciente = IdPaciente;
            
            item.Fecha = Fecha;
            
            item.Edad = Edad;
            
            item.Neoadyuvancia = Neoadyuvancia;
            
            item.FechaInicioNeoadyuvancia = FechaInicioNeoadyuvancia;
            
            item.Quimioterapia = Quimioterapia;
            
            item.FechaInicioQuimio = FechaInicioQuimio;
            
            item.Radioterapia = Radioterapia;
            
            item.FechaInicioRadioterapia = FechaInicioRadioterapia;
            
            item.Trastuzumab = Trastuzumab;
            
            item.FechaInicioTrastuzumab = FechaInicioTrastuzumab;
            
            item.Hormonoterapia = Hormonoterapia;
            
            item.FechaHormonoterapiaInicial = FechaHormonoterapiaInicial;
            
            item.FechaHormonoterapia = FechaHormonoterapia;
            
            item.Observacion = Observacion;
            
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
	    public void Update(int IdTratamiento,int IdPaciente,DateTime Fecha,int Edad,int Neoadyuvancia,DateTime FechaInicioNeoadyuvancia,int Quimioterapia,DateTime FechaInicioQuimio,int Radioterapia,DateTime FechaInicioRadioterapia,int Trastuzumab,DateTime FechaInicioTrastuzumab,string Hormonoterapia,DateTime FechaHormonoterapiaInicial,DateTime FechaHormonoterapia,string Observacion,int IdResponsableExamen,int IdCentroSalud,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamTratamiento item = new MamTratamiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTratamiento = IdTratamiento;
				
			item.IdPaciente = IdPaciente;
				
			item.Fecha = Fecha;
				
			item.Edad = Edad;
				
			item.Neoadyuvancia = Neoadyuvancia;
				
			item.FechaInicioNeoadyuvancia = FechaInicioNeoadyuvancia;
				
			item.Quimioterapia = Quimioterapia;
				
			item.FechaInicioQuimio = FechaInicioQuimio;
				
			item.Radioterapia = Radioterapia;
				
			item.FechaInicioRadioterapia = FechaInicioRadioterapia;
				
			item.Trastuzumab = Trastuzumab;
				
			item.FechaInicioTrastuzumab = FechaInicioTrastuzumab;
				
			item.Hormonoterapia = Hormonoterapia;
				
			item.FechaHormonoterapiaInicial = FechaHormonoterapiaInicial;
				
			item.FechaHormonoterapia = FechaHormonoterapia;
				
			item.Observacion = Observacion;
				
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
