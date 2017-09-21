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
    /// Controller class for MAM_EstudiosHospitalProvincial
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamEstudiosHospitalProvincialController
    {
        // Preload our schema..
        MamEstudiosHospitalProvincial thisSchemaLoad = new MamEstudiosHospitalProvincial();
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
        public MamEstudiosHospitalProvincialCollection FetchAll()
        {
            MamEstudiosHospitalProvincialCollection coll = new MamEstudiosHospitalProvincialCollection();
            Query qry = new Query(MamEstudiosHospitalProvincial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstudiosHospitalProvincialCollection FetchByID(object IdMamografiaHP)
        {
            MamEstudiosHospitalProvincialCollection coll = new MamEstudiosHospitalProvincialCollection().Where("idMamografiaHP", IdMamografiaHP).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstudiosHospitalProvincialCollection FetchByQuery(Query qry)
        {
            MamEstudiosHospitalProvincialCollection coll = new MamEstudiosHospitalProvincialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMamografiaHP)
        {
            return (MamEstudiosHospitalProvincial.Delete(IdMamografiaHP) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMamografiaHP)
        {
            return (MamEstudiosHospitalProvincial.Destroy(IdMamografiaHP) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdHistoria,string TipoDocumento,int? Documento,string Apellido,string Nombre,DateTime? FechaNacimiento,string ObraSocial,string InformacionContacto,string Direccion,int? SolicitudProfesional,int? SolicitudCentroSalud,int? BiradIzquierdo,int? BiradDerecho,int? BiradDefinitivo,DateTime? FechaPlaca,DateTime? FechaInforme,string Informe,int? IdMotivo,string Motivo,int? IdMotivoSitam,int? IdTipoEstudio,int? IdTipoEstudioSitam,string Observaciones,bool PasadoSips,bool Activo,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? InformeProfesional,string Localidad,string InformacionCelular,int? SolicitudProfesionalSSS,int? SolicitudProfesionalDNI,int? InformeProfesionalSSS,int? InformeProfesionalDNI,string Equipo,string MotivoConsulta,int? Protocolo,string ProtocoloPrefijo)
	    {
		    MamEstudiosHospitalProvincial item = new MamEstudiosHospitalProvincial();
		    
            item.IdHistoria = IdHistoria;
            
            item.TipoDocumento = TipoDocumento;
            
            item.Documento = Documento;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.ObraSocial = ObraSocial;
            
            item.InformacionContacto = InformacionContacto;
            
            item.Direccion = Direccion;
            
            item.SolicitudProfesional = SolicitudProfesional;
            
            item.SolicitudCentroSalud = SolicitudCentroSalud;
            
            item.BiradIzquierdo = BiradIzquierdo;
            
            item.BiradDerecho = BiradDerecho;
            
            item.BiradDefinitivo = BiradDefinitivo;
            
            item.FechaPlaca = FechaPlaca;
            
            item.FechaInforme = FechaInforme;
            
            item.Informe = Informe;
            
            item.IdMotivo = IdMotivo;
            
            item.Motivo = Motivo;
            
            item.IdMotivoSitam = IdMotivoSitam;
            
            item.IdTipoEstudio = IdTipoEstudio;
            
            item.IdTipoEstudioSitam = IdTipoEstudioSitam;
            
            item.Observaciones = Observaciones;
            
            item.PasadoSips = PasadoSips;
            
            item.Activo = Activo;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.InformeProfesional = InformeProfesional;
            
            item.Localidad = Localidad;
            
            item.InformacionCelular = InformacionCelular;
            
            item.SolicitudProfesionalSSS = SolicitudProfesionalSSS;
            
            item.SolicitudProfesionalDNI = SolicitudProfesionalDNI;
            
            item.InformeProfesionalSSS = InformeProfesionalSSS;
            
            item.InformeProfesionalDNI = InformeProfesionalDNI;
            
            item.Equipo = Equipo;
            
            item.MotivoConsulta = MotivoConsulta;
            
            item.Protocolo = Protocolo;
            
            item.ProtocoloPrefijo = ProtocoloPrefijo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMamografiaHP,int? IdHistoria,string TipoDocumento,int? Documento,string Apellido,string Nombre,DateTime? FechaNacimiento,string ObraSocial,string InformacionContacto,string Direccion,int? SolicitudProfesional,int? SolicitudCentroSalud,int? BiradIzquierdo,int? BiradDerecho,int? BiradDefinitivo,DateTime? FechaPlaca,DateTime? FechaInforme,string Informe,int? IdMotivo,string Motivo,int? IdMotivoSitam,int? IdTipoEstudio,int? IdTipoEstudioSitam,string Observaciones,bool PasadoSips,bool Activo,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? InformeProfesional,string Localidad,string InformacionCelular,int? SolicitudProfesionalSSS,int? SolicitudProfesionalDNI,int? InformeProfesionalSSS,int? InformeProfesionalDNI,string Equipo,string MotivoConsulta,int? Protocolo,string ProtocoloPrefijo)
	    {
		    MamEstudiosHospitalProvincial item = new MamEstudiosHospitalProvincial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMamografiaHP = IdMamografiaHP;
				
			item.IdHistoria = IdHistoria;
				
			item.TipoDocumento = TipoDocumento;
				
			item.Documento = Documento;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.ObraSocial = ObraSocial;
				
			item.InformacionContacto = InformacionContacto;
				
			item.Direccion = Direccion;
				
			item.SolicitudProfesional = SolicitudProfesional;
				
			item.SolicitudCentroSalud = SolicitudCentroSalud;
				
			item.BiradIzquierdo = BiradIzquierdo;
				
			item.BiradDerecho = BiradDerecho;
				
			item.BiradDefinitivo = BiradDefinitivo;
				
			item.FechaPlaca = FechaPlaca;
				
			item.FechaInforme = FechaInforme;
				
			item.Informe = Informe;
				
			item.IdMotivo = IdMotivo;
				
			item.Motivo = Motivo;
				
			item.IdMotivoSitam = IdMotivoSitam;
				
			item.IdTipoEstudio = IdTipoEstudio;
				
			item.IdTipoEstudioSitam = IdTipoEstudioSitam;
				
			item.Observaciones = Observaciones;
				
			item.PasadoSips = PasadoSips;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.InformeProfesional = InformeProfesional;
				
			item.Localidad = Localidad;
				
			item.InformacionCelular = InformacionCelular;
				
			item.SolicitudProfesionalSSS = SolicitudProfesionalSSS;
				
			item.SolicitudProfesionalDNI = SolicitudProfesionalDNI;
				
			item.InformeProfesionalSSS = InformeProfesionalSSS;
				
			item.InformeProfesionalDNI = InformeProfesionalDNI;
				
			item.Equipo = Equipo;
				
			item.MotivoConsulta = MotivoConsulta;
				
			item.Protocolo = Protocolo;
				
			item.ProtocoloPrefijo = ProtocoloPrefijo;
				
	        item.Save(UserName);
	    }
    }
}
