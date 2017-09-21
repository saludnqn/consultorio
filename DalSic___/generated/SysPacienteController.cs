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
    /// Controller class for Sys_Paciente
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysPacienteController
    {
        // Preload our schema..
        SysPaciente thisSchemaLoad = new SysPaciente();
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
        public SysPacienteCollection FetchAll()
        {
            SysPacienteCollection coll = new SysPacienteCollection();
            Query qry = new Query(SysPaciente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPacienteCollection FetchByID(object IdPaciente)
        {
            SysPacienteCollection coll = new SysPacienteCollection().Where("idPaciente", IdPaciente).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPacienteCollection FetchByQuery(Query qry)
        {
            SysPacienteCollection coll = new SysPacienteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPaciente)
        {
            return (SysPaciente.Delete(IdPaciente) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPaciente)
        {
            return (SysPaciente.Destroy(IdPaciente) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,string Apellido,string Nombre,int NumeroDocumento,int IdSexo,DateTime FechaNacimiento,int IdEstado,int IdMotivoNI,int IdPais,int IdProvincia,int IdNivelInstruccion,int IdSituacionLaboral,int IdProfesion,int IdOcupacion,string Calle,int Numero,string Piso,string Departamento,string Manzana,int IdBarrio,int IdLocalidad,int IdDepartamento,int IdProvinciaDomicilio,string Referencia,string InformacionContacto,bool Cronico,int IdObraSocial,int IdUsuario,DateTime FechaAlta,DateTime FechaDefuncion,DateTime FechaUltimaActualizacion,int IdEstadoCivil,int IdEtnia,int IdPoblacion,int IdIdioma,string OtroBarrio,string Camino,string Campo,bool EsUrbano,string Lote,string Parcela,string Edificio,bool Activo,DateTime? FechaAltaObraSocial,string NumeroAfiliado,string NumeroExtranjero,string TelefonoFijo,string TelefonoCelular,string Email,string Latitud,string Longitud)
	    {
		    SysPaciente item = new SysPaciente();
		    
            item.IdEfector = IdEfector;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.NumeroDocumento = NumeroDocumento;
            
            item.IdSexo = IdSexo;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.IdEstado = IdEstado;
            
            item.IdMotivoNI = IdMotivoNI;
            
            item.IdPais = IdPais;
            
            item.IdProvincia = IdProvincia;
            
            item.IdNivelInstruccion = IdNivelInstruccion;
            
            item.IdSituacionLaboral = IdSituacionLaboral;
            
            item.IdProfesion = IdProfesion;
            
            item.IdOcupacion = IdOcupacion;
            
            item.Calle = Calle;
            
            item.Numero = Numero;
            
            item.Piso = Piso;
            
            item.Departamento = Departamento;
            
            item.Manzana = Manzana;
            
            item.IdBarrio = IdBarrio;
            
            item.IdLocalidad = IdLocalidad;
            
            item.IdDepartamento = IdDepartamento;
            
            item.IdProvinciaDomicilio = IdProvinciaDomicilio;
            
            item.Referencia = Referencia;
            
            item.InformacionContacto = InformacionContacto;
            
            item.Cronico = Cronico;
            
            item.IdObraSocial = IdObraSocial;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaAlta = FechaAlta;
            
            item.FechaDefuncion = FechaDefuncion;
            
            item.FechaUltimaActualizacion = FechaUltimaActualizacion;
            
            item.IdEstadoCivil = IdEstadoCivil;
            
            item.IdEtnia = IdEtnia;
            
            item.IdPoblacion = IdPoblacion;
            
            item.IdIdioma = IdIdioma;
            
            item.OtroBarrio = OtroBarrio;
            
            item.Camino = Camino;
            
            item.Campo = Campo;
            
            item.EsUrbano = EsUrbano;
            
            item.Lote = Lote;
            
            item.Parcela = Parcela;
            
            item.Edificio = Edificio;
            
            item.Activo = Activo;
            
            item.FechaAltaObraSocial = FechaAltaObraSocial;
            
            item.NumeroAfiliado = NumeroAfiliado;
            
            item.NumeroExtranjero = NumeroExtranjero;
            
            item.TelefonoFijo = TelefonoFijo;
            
            item.TelefonoCelular = TelefonoCelular;
            
            item.Email = Email;
            
            item.Latitud = Latitud;
            
            item.Longitud = Longitud;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPaciente,int IdEfector,string Apellido,string Nombre,int NumeroDocumento,int IdSexo,DateTime FechaNacimiento,int IdEstado,int IdMotivoNI,int IdPais,int IdProvincia,int IdNivelInstruccion,int IdSituacionLaboral,int IdProfesion,int IdOcupacion,string Calle,int Numero,string Piso,string Departamento,string Manzana,int IdBarrio,int IdLocalidad,int IdDepartamento,int IdProvinciaDomicilio,string Referencia,string InformacionContacto,bool Cronico,int IdObraSocial,int IdUsuario,DateTime FechaAlta,DateTime FechaDefuncion,DateTime FechaUltimaActualizacion,int IdEstadoCivil,int IdEtnia,int IdPoblacion,int IdIdioma,string OtroBarrio,string Camino,string Campo,bool EsUrbano,string Lote,string Parcela,string Edificio,bool Activo,DateTime? FechaAltaObraSocial,string NumeroAfiliado,string NumeroExtranjero,string TelefonoFijo,string TelefonoCelular,string Email,string Latitud,string Longitud)
	    {
		    SysPaciente item = new SysPaciente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPaciente = IdPaciente;
				
			item.IdEfector = IdEfector;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.NumeroDocumento = NumeroDocumento;
				
			item.IdSexo = IdSexo;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.IdEstado = IdEstado;
				
			item.IdMotivoNI = IdMotivoNI;
				
			item.IdPais = IdPais;
				
			item.IdProvincia = IdProvincia;
				
			item.IdNivelInstruccion = IdNivelInstruccion;
				
			item.IdSituacionLaboral = IdSituacionLaboral;
				
			item.IdProfesion = IdProfesion;
				
			item.IdOcupacion = IdOcupacion;
				
			item.Calle = Calle;
				
			item.Numero = Numero;
				
			item.Piso = Piso;
				
			item.Departamento = Departamento;
				
			item.Manzana = Manzana;
				
			item.IdBarrio = IdBarrio;
				
			item.IdLocalidad = IdLocalidad;
				
			item.IdDepartamento = IdDepartamento;
				
			item.IdProvinciaDomicilio = IdProvinciaDomicilio;
				
			item.Referencia = Referencia;
				
			item.InformacionContacto = InformacionContacto;
				
			item.Cronico = Cronico;
				
			item.IdObraSocial = IdObraSocial;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaAlta = FechaAlta;
				
			item.FechaDefuncion = FechaDefuncion;
				
			item.FechaUltimaActualizacion = FechaUltimaActualizacion;
				
			item.IdEstadoCivil = IdEstadoCivil;
				
			item.IdEtnia = IdEtnia;
				
			item.IdPoblacion = IdPoblacion;
				
			item.IdIdioma = IdIdioma;
				
			item.OtroBarrio = OtroBarrio;
				
			item.Camino = Camino;
				
			item.Campo = Campo;
				
			item.EsUrbano = EsUrbano;
				
			item.Lote = Lote;
				
			item.Parcela = Parcela;
				
			item.Edificio = Edificio;
				
			item.Activo = Activo;
				
			item.FechaAltaObraSocial = FechaAltaObraSocial;
				
			item.NumeroAfiliado = NumeroAfiliado;
				
			item.NumeroExtranjero = NumeroExtranjero;
				
			item.TelefonoFijo = TelefonoFijo;
				
			item.TelefonoCelular = TelefonoCelular;
				
			item.Email = Email;
				
			item.Latitud = Latitud;
				
			item.Longitud = Longitud;
				
	        item.Save(UserName);
	    }
    }
}
