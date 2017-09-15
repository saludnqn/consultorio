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
    /// Controller class for PN_historicotemp
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnHistoricotempController
    {
        // Preload our schema..
        PnHistoricotemp thisSchemaLoad = new PnHistoricotemp();
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
        public PnHistoricotempCollection FetchAll()
        {
            PnHistoricotempCollection coll = new PnHistoricotempCollection();
            Query qry = new Query(PnHistoricotemp.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnHistoricotempCollection FetchByID(object IdSmiafiliados)
        {
            PnHistoricotempCollection coll = new PnHistoricotempCollection().Where("id_smiafiliados", IdSmiafiliados).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnHistoricotempCollection FetchByQuery(Query qry)
        {
            PnHistoricotempCollection coll = new PnHistoricotempCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSmiafiliados)
        {
            return (PnHistoricotemp.Delete(IdSmiafiliados) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSmiafiliados)
        {
            return (PnHistoricotemp.Destroy(IdSmiafiliados) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string IdSmiafiliados,string Clavebeneficiario,string Afiapellido,string Afinombre,string Afitipodoc,string Aficlasedoc,string Afidni,string Afisexo,string Afiprovincia,string Afilocalidad,short? Afitipocategoria,DateTime? Afifechanac,string Afideclaraindigena,int? AfiidLengua,int? AfiidTribu,string Matipodocumento,string Manrodocumento,string Maapellido,string Manombre,string Patipodocumento,string Panrodocumento,string Paapellido,string Panombre,string Otrotipodocumento,string Otronrodocumento,string Otroapellido,string Otronombre,int? Otrotiporelacion,DateTime? Fechainscripcion,DateTime? Fechaaltaefectiva,DateTime? Fechadiagnosticoembarazo,int? Semanasembarazo,DateTime? Fechaprobableparto,DateTime? Fechaefectivaparto,string Activo,string Accionpendienteconfirmar,string Afidomcalle,string Afidomnro,string Afidommanzana,string Afidompiso,string Afidomdepto,string Afidomentrecalle1,string Afidomentrecalle2,string Afidombarrioparaje,string Afidommunicipio,string Afidomdepartamento,string Afidomlocalidad,string Afidomprovincia,string Afidomcp,string Afitelefono,string Lugaratencionhabitual,DateTime? Datosfechaenvio,DateTime? Fechaalta,short? Pendienteenviar,string Codigoprovinciaaltadatos,string Codigouadaltadatos,string Codigocialtadatos,short? Motivobaja,string Mensajebaja,int? IdProcesobajaautomatica,short? Pendienteenviaranacion,DateTime? Fechacarga,string Usuariocarga,string Menorconvivecontutor,string Field1,string Field2,string Field3,string Cuieefectorasignado,string Cuielugaratencionhabitual,string Usuario,string Field5,string Clavebenefprovocobaja,string Usuariocreacion,string Field4,DateTime Periodo)
	    {
		    PnHistoricotemp item = new PnHistoricotemp();
		    
            item.IdSmiafiliados = IdSmiafiliados;
            
            item.Clavebeneficiario = Clavebeneficiario;
            
            item.Afiapellido = Afiapellido;
            
            item.Afinombre = Afinombre;
            
            item.Afitipodoc = Afitipodoc;
            
            item.Aficlasedoc = Aficlasedoc;
            
            item.Afidni = Afidni;
            
            item.Afisexo = Afisexo;
            
            item.Afiprovincia = Afiprovincia;
            
            item.Afilocalidad = Afilocalidad;
            
            item.Afitipocategoria = Afitipocategoria;
            
            item.Afifechanac = Afifechanac;
            
            item.Afideclaraindigena = Afideclaraindigena;
            
            item.AfiidLengua = AfiidLengua;
            
            item.AfiidTribu = AfiidTribu;
            
            item.Matipodocumento = Matipodocumento;
            
            item.Manrodocumento = Manrodocumento;
            
            item.Maapellido = Maapellido;
            
            item.Manombre = Manombre;
            
            item.Patipodocumento = Patipodocumento;
            
            item.Panrodocumento = Panrodocumento;
            
            item.Paapellido = Paapellido;
            
            item.Panombre = Panombre;
            
            item.Otrotipodocumento = Otrotipodocumento;
            
            item.Otronrodocumento = Otronrodocumento;
            
            item.Otroapellido = Otroapellido;
            
            item.Otronombre = Otronombre;
            
            item.Otrotiporelacion = Otrotiporelacion;
            
            item.Fechainscripcion = Fechainscripcion;
            
            item.Fechaaltaefectiva = Fechaaltaefectiva;
            
            item.Fechadiagnosticoembarazo = Fechadiagnosticoembarazo;
            
            item.Semanasembarazo = Semanasembarazo;
            
            item.Fechaprobableparto = Fechaprobableparto;
            
            item.Fechaefectivaparto = Fechaefectivaparto;
            
            item.Activo = Activo;
            
            item.Accionpendienteconfirmar = Accionpendienteconfirmar;
            
            item.Afidomcalle = Afidomcalle;
            
            item.Afidomnro = Afidomnro;
            
            item.Afidommanzana = Afidommanzana;
            
            item.Afidompiso = Afidompiso;
            
            item.Afidomdepto = Afidomdepto;
            
            item.Afidomentrecalle1 = Afidomentrecalle1;
            
            item.Afidomentrecalle2 = Afidomentrecalle2;
            
            item.Afidombarrioparaje = Afidombarrioparaje;
            
            item.Afidommunicipio = Afidommunicipio;
            
            item.Afidomdepartamento = Afidomdepartamento;
            
            item.Afidomlocalidad = Afidomlocalidad;
            
            item.Afidomprovincia = Afidomprovincia;
            
            item.Afidomcp = Afidomcp;
            
            item.Afitelefono = Afitelefono;
            
            item.Lugaratencionhabitual = Lugaratencionhabitual;
            
            item.Datosfechaenvio = Datosfechaenvio;
            
            item.Fechaalta = Fechaalta;
            
            item.Pendienteenviar = Pendienteenviar;
            
            item.Codigoprovinciaaltadatos = Codigoprovinciaaltadatos;
            
            item.Codigouadaltadatos = Codigouadaltadatos;
            
            item.Codigocialtadatos = Codigocialtadatos;
            
            item.Motivobaja = Motivobaja;
            
            item.Mensajebaja = Mensajebaja;
            
            item.IdProcesobajaautomatica = IdProcesobajaautomatica;
            
            item.Pendienteenviaranacion = Pendienteenviaranacion;
            
            item.Fechacarga = Fechacarga;
            
            item.Usuariocarga = Usuariocarga;
            
            item.Menorconvivecontutor = Menorconvivecontutor;
            
            item.Field1 = Field1;
            
            item.Field2 = Field2;
            
            item.Field3 = Field3;
            
            item.Cuieefectorasignado = Cuieefectorasignado;
            
            item.Cuielugaratencionhabitual = Cuielugaratencionhabitual;
            
            item.Usuario = Usuario;
            
            item.Field5 = Field5;
            
            item.Clavebenefprovocobaja = Clavebenefprovocobaja;
            
            item.Usuariocreacion = Usuariocreacion;
            
            item.Field4 = Field4;
            
            item.Periodo = Periodo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string IdSmiafiliados,string Clavebeneficiario,string Afiapellido,string Afinombre,string Afitipodoc,string Aficlasedoc,string Afidni,string Afisexo,string Afiprovincia,string Afilocalidad,short? Afitipocategoria,DateTime? Afifechanac,string Afideclaraindigena,int? AfiidLengua,int? AfiidTribu,string Matipodocumento,string Manrodocumento,string Maapellido,string Manombre,string Patipodocumento,string Panrodocumento,string Paapellido,string Panombre,string Otrotipodocumento,string Otronrodocumento,string Otroapellido,string Otronombre,int? Otrotiporelacion,DateTime? Fechainscripcion,DateTime? Fechaaltaefectiva,DateTime? Fechadiagnosticoembarazo,int? Semanasembarazo,DateTime? Fechaprobableparto,DateTime? Fechaefectivaparto,string Activo,string Accionpendienteconfirmar,string Afidomcalle,string Afidomnro,string Afidommanzana,string Afidompiso,string Afidomdepto,string Afidomentrecalle1,string Afidomentrecalle2,string Afidombarrioparaje,string Afidommunicipio,string Afidomdepartamento,string Afidomlocalidad,string Afidomprovincia,string Afidomcp,string Afitelefono,string Lugaratencionhabitual,DateTime? Datosfechaenvio,DateTime? Fechaalta,short? Pendienteenviar,string Codigoprovinciaaltadatos,string Codigouadaltadatos,string Codigocialtadatos,short? Motivobaja,string Mensajebaja,int? IdProcesobajaautomatica,short? Pendienteenviaranacion,DateTime? Fechacarga,string Usuariocarga,string Menorconvivecontutor,string Field1,string Field2,string Field3,string Cuieefectorasignado,string Cuielugaratencionhabitual,string Usuario,string Field5,string Clavebenefprovocobaja,string Usuariocreacion,string Field4,DateTime Periodo)
	    {
		    PnHistoricotemp item = new PnHistoricotemp();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSmiafiliados = IdSmiafiliados;
				
			item.Clavebeneficiario = Clavebeneficiario;
				
			item.Afiapellido = Afiapellido;
				
			item.Afinombre = Afinombre;
				
			item.Afitipodoc = Afitipodoc;
				
			item.Aficlasedoc = Aficlasedoc;
				
			item.Afidni = Afidni;
				
			item.Afisexo = Afisexo;
				
			item.Afiprovincia = Afiprovincia;
				
			item.Afilocalidad = Afilocalidad;
				
			item.Afitipocategoria = Afitipocategoria;
				
			item.Afifechanac = Afifechanac;
				
			item.Afideclaraindigena = Afideclaraindigena;
				
			item.AfiidLengua = AfiidLengua;
				
			item.AfiidTribu = AfiidTribu;
				
			item.Matipodocumento = Matipodocumento;
				
			item.Manrodocumento = Manrodocumento;
				
			item.Maapellido = Maapellido;
				
			item.Manombre = Manombre;
				
			item.Patipodocumento = Patipodocumento;
				
			item.Panrodocumento = Panrodocumento;
				
			item.Paapellido = Paapellido;
				
			item.Panombre = Panombre;
				
			item.Otrotipodocumento = Otrotipodocumento;
				
			item.Otronrodocumento = Otronrodocumento;
				
			item.Otroapellido = Otroapellido;
				
			item.Otronombre = Otronombre;
				
			item.Otrotiporelacion = Otrotiporelacion;
				
			item.Fechainscripcion = Fechainscripcion;
				
			item.Fechaaltaefectiva = Fechaaltaefectiva;
				
			item.Fechadiagnosticoembarazo = Fechadiagnosticoembarazo;
				
			item.Semanasembarazo = Semanasembarazo;
				
			item.Fechaprobableparto = Fechaprobableparto;
				
			item.Fechaefectivaparto = Fechaefectivaparto;
				
			item.Activo = Activo;
				
			item.Accionpendienteconfirmar = Accionpendienteconfirmar;
				
			item.Afidomcalle = Afidomcalle;
				
			item.Afidomnro = Afidomnro;
				
			item.Afidommanzana = Afidommanzana;
				
			item.Afidompiso = Afidompiso;
				
			item.Afidomdepto = Afidomdepto;
				
			item.Afidomentrecalle1 = Afidomentrecalle1;
				
			item.Afidomentrecalle2 = Afidomentrecalle2;
				
			item.Afidombarrioparaje = Afidombarrioparaje;
				
			item.Afidommunicipio = Afidommunicipio;
				
			item.Afidomdepartamento = Afidomdepartamento;
				
			item.Afidomlocalidad = Afidomlocalidad;
				
			item.Afidomprovincia = Afidomprovincia;
				
			item.Afidomcp = Afidomcp;
				
			item.Afitelefono = Afitelefono;
				
			item.Lugaratencionhabitual = Lugaratencionhabitual;
				
			item.Datosfechaenvio = Datosfechaenvio;
				
			item.Fechaalta = Fechaalta;
				
			item.Pendienteenviar = Pendienteenviar;
				
			item.Codigoprovinciaaltadatos = Codigoprovinciaaltadatos;
				
			item.Codigouadaltadatos = Codigouadaltadatos;
				
			item.Codigocialtadatos = Codigocialtadatos;
				
			item.Motivobaja = Motivobaja;
				
			item.Mensajebaja = Mensajebaja;
				
			item.IdProcesobajaautomatica = IdProcesobajaautomatica;
				
			item.Pendienteenviaranacion = Pendienteenviaranacion;
				
			item.Fechacarga = Fechacarga;
				
			item.Usuariocarga = Usuariocarga;
				
			item.Menorconvivecontutor = Menorconvivecontutor;
				
			item.Field1 = Field1;
				
			item.Field2 = Field2;
				
			item.Field3 = Field3;
				
			item.Cuieefectorasignado = Cuieefectorasignado;
				
			item.Cuielugaratencionhabitual = Cuielugaratencionhabitual;
				
			item.Usuario = Usuario;
				
			item.Field5 = Field5;
				
			item.Clavebenefprovocobaja = Clavebenefprovocobaja;
				
			item.Usuariocreacion = Usuariocreacion;
				
			item.Field4 = Field4;
				
			item.Periodo = Periodo;
				
	        item.Save(UserName);
	    }
    }
}
