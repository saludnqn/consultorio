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
    /// Controller class for PN_beneficiarios
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnBeneficiarioController
    {
        // Preload our schema..
        PnBeneficiario thisSchemaLoad = new PnBeneficiario();
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
        public PnBeneficiarioCollection FetchAll()
        {
            PnBeneficiarioCollection coll = new PnBeneficiarioCollection();
            Query qry = new Query(PnBeneficiario.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnBeneficiarioCollection FetchByID(object IdBeneficiarios)
        {
            PnBeneficiarioCollection coll = new PnBeneficiarioCollection().Where("id_beneficiarios", IdBeneficiarios).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnBeneficiarioCollection FetchByQuery(Query qry)
        {
            PnBeneficiarioCollection coll = new PnBeneficiarioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdBeneficiarios)
        {
            return (PnBeneficiario.Delete(IdBeneficiarios) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdBeneficiarios)
        {
            return (PnBeneficiario.Destroy(IdBeneficiarios) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string EstadoEnvio,string ClaveBeneficiario,string TipoTransaccion,string ApellidoBenef,string NombreBenef,string ClaseDocumentoBenef,string TipoDocumento,string NumeroDoc,int IdCategoria,string Sexo,DateTime? FechaNacimientoBenef,string ProvinciaNac,string LocalidadNac,string PaisNac,string Indigena,int IdTribu,int IdLengua,string Alfabeta,string Estudios,int? AnioMayorNivel,string TipoDocMadre,string NroDocMadre,string ApellidoMadre,string NombreMadre,string AlfabetaMadre,string EstudiosMadre,int? AnioMayorNivelMadre,string TipoDocPadre,string NroDocPadre,string ApellidoPadre,string NombrePadre,string AlfabetaPadre,string EstudiosPadre,int? AnioMayorNivelPadre,string TipoDocTutor,string NroDocTutor,string ApellidoTutor,string NombreTutor,string AlfabetaTutor,string EstudiosTutor,int? AnioMayorNivelTutor,DateTime? FechaDiagnosticoEmbarazo,int? SemanasEmbarazo,DateTime? FechaProbableParto,DateTime? FechaEfectivaParto,string CuieEa,string CuieAh,string MenorConviveConAdulto,string Calle,string NumeroCalle,string Piso,string Dpto,string Manzana,string EntreCalle1,string EntreCalle2,string Telefono,string Departamento,string Localidad,string Municipio,string Barrio,string CodPos,string Observaciones,DateTime? FechaInscripcion,DateTime? FechaCarga,string UsuarioCarga,string Activo,int? TipoFicha,string Responsable,DateTime? Fum,string Rcv,string Discv,string Disca,string Discmo,string Discme,string Otradisc)
	    {
		    PnBeneficiario item = new PnBeneficiario();
		    
            item.EstadoEnvio = EstadoEnvio;
            
            item.ClaveBeneficiario = ClaveBeneficiario;
            
            item.TipoTransaccion = TipoTransaccion;
            
            item.ApellidoBenef = ApellidoBenef;
            
            item.NombreBenef = NombreBenef;
            
            item.ClaseDocumentoBenef = ClaseDocumentoBenef;
            
            item.TipoDocumento = TipoDocumento;
            
            item.NumeroDoc = NumeroDoc;
            
            item.IdCategoria = IdCategoria;
            
            item.Sexo = Sexo;
            
            item.FechaNacimientoBenef = FechaNacimientoBenef;
            
            item.ProvinciaNac = ProvinciaNac;
            
            item.LocalidadNac = LocalidadNac;
            
            item.PaisNac = PaisNac;
            
            item.Indigena = Indigena;
            
            item.IdTribu = IdTribu;
            
            item.IdLengua = IdLengua;
            
            item.Alfabeta = Alfabeta;
            
            item.Estudios = Estudios;
            
            item.AnioMayorNivel = AnioMayorNivel;
            
            item.TipoDocMadre = TipoDocMadre;
            
            item.NroDocMadre = NroDocMadre;
            
            item.ApellidoMadre = ApellidoMadre;
            
            item.NombreMadre = NombreMadre;
            
            item.AlfabetaMadre = AlfabetaMadre;
            
            item.EstudiosMadre = EstudiosMadre;
            
            item.AnioMayorNivelMadre = AnioMayorNivelMadre;
            
            item.TipoDocPadre = TipoDocPadre;
            
            item.NroDocPadre = NroDocPadre;
            
            item.ApellidoPadre = ApellidoPadre;
            
            item.NombrePadre = NombrePadre;
            
            item.AlfabetaPadre = AlfabetaPadre;
            
            item.EstudiosPadre = EstudiosPadre;
            
            item.AnioMayorNivelPadre = AnioMayorNivelPadre;
            
            item.TipoDocTutor = TipoDocTutor;
            
            item.NroDocTutor = NroDocTutor;
            
            item.ApellidoTutor = ApellidoTutor;
            
            item.NombreTutor = NombreTutor;
            
            item.AlfabetaTutor = AlfabetaTutor;
            
            item.EstudiosTutor = EstudiosTutor;
            
            item.AnioMayorNivelTutor = AnioMayorNivelTutor;
            
            item.FechaDiagnosticoEmbarazo = FechaDiagnosticoEmbarazo;
            
            item.SemanasEmbarazo = SemanasEmbarazo;
            
            item.FechaProbableParto = FechaProbableParto;
            
            item.FechaEfectivaParto = FechaEfectivaParto;
            
            item.CuieEa = CuieEa;
            
            item.CuieAh = CuieAh;
            
            item.MenorConviveConAdulto = MenorConviveConAdulto;
            
            item.Calle = Calle;
            
            item.NumeroCalle = NumeroCalle;
            
            item.Piso = Piso;
            
            item.Dpto = Dpto;
            
            item.Manzana = Manzana;
            
            item.EntreCalle1 = EntreCalle1;
            
            item.EntreCalle2 = EntreCalle2;
            
            item.Telefono = Telefono;
            
            item.Departamento = Departamento;
            
            item.Localidad = Localidad;
            
            item.Municipio = Municipio;
            
            item.Barrio = Barrio;
            
            item.CodPos = CodPos;
            
            item.Observaciones = Observaciones;
            
            item.FechaInscripcion = FechaInscripcion;
            
            item.FechaCarga = FechaCarga;
            
            item.UsuarioCarga = UsuarioCarga;
            
            item.Activo = Activo;
            
            item.TipoFicha = TipoFicha;
            
            item.Responsable = Responsable;
            
            item.Fum = Fum;
            
            item.Rcv = Rcv;
            
            item.Discv = Discv;
            
            item.Disca = Disca;
            
            item.Discmo = Discmo;
            
            item.Discme = Discme;
            
            item.Otradisc = Otradisc;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdBeneficiarios,string EstadoEnvio,string ClaveBeneficiario,string TipoTransaccion,string ApellidoBenef,string NombreBenef,string ClaseDocumentoBenef,string TipoDocumento,string NumeroDoc,int IdCategoria,string Sexo,DateTime? FechaNacimientoBenef,string ProvinciaNac,string LocalidadNac,string PaisNac,string Indigena,int IdTribu,int IdLengua,string Alfabeta,string Estudios,int? AnioMayorNivel,string TipoDocMadre,string NroDocMadre,string ApellidoMadre,string NombreMadre,string AlfabetaMadre,string EstudiosMadre,int? AnioMayorNivelMadre,string TipoDocPadre,string NroDocPadre,string ApellidoPadre,string NombrePadre,string AlfabetaPadre,string EstudiosPadre,int? AnioMayorNivelPadre,string TipoDocTutor,string NroDocTutor,string ApellidoTutor,string NombreTutor,string AlfabetaTutor,string EstudiosTutor,int? AnioMayorNivelTutor,DateTime? FechaDiagnosticoEmbarazo,int? SemanasEmbarazo,DateTime? FechaProbableParto,DateTime? FechaEfectivaParto,string CuieEa,string CuieAh,string MenorConviveConAdulto,string Calle,string NumeroCalle,string Piso,string Dpto,string Manzana,string EntreCalle1,string EntreCalle2,string Telefono,string Departamento,string Localidad,string Municipio,string Barrio,string CodPos,string Observaciones,DateTime? FechaInscripcion,DateTime? FechaCarga,string UsuarioCarga,string Activo,int? TipoFicha,string Responsable,DateTime? Fum,string Rcv,string Discv,string Disca,string Discmo,string Discme,string Otradisc)
	    {
		    PnBeneficiario item = new PnBeneficiario();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdBeneficiarios = IdBeneficiarios;
				
			item.EstadoEnvio = EstadoEnvio;
				
			item.ClaveBeneficiario = ClaveBeneficiario;
				
			item.TipoTransaccion = TipoTransaccion;
				
			item.ApellidoBenef = ApellidoBenef;
				
			item.NombreBenef = NombreBenef;
				
			item.ClaseDocumentoBenef = ClaseDocumentoBenef;
				
			item.TipoDocumento = TipoDocumento;
				
			item.NumeroDoc = NumeroDoc;
				
			item.IdCategoria = IdCategoria;
				
			item.Sexo = Sexo;
				
			item.FechaNacimientoBenef = FechaNacimientoBenef;
				
			item.ProvinciaNac = ProvinciaNac;
				
			item.LocalidadNac = LocalidadNac;
				
			item.PaisNac = PaisNac;
				
			item.Indigena = Indigena;
				
			item.IdTribu = IdTribu;
				
			item.IdLengua = IdLengua;
				
			item.Alfabeta = Alfabeta;
				
			item.Estudios = Estudios;
				
			item.AnioMayorNivel = AnioMayorNivel;
				
			item.TipoDocMadre = TipoDocMadre;
				
			item.NroDocMadre = NroDocMadre;
				
			item.ApellidoMadre = ApellidoMadre;
				
			item.NombreMadre = NombreMadre;
				
			item.AlfabetaMadre = AlfabetaMadre;
				
			item.EstudiosMadre = EstudiosMadre;
				
			item.AnioMayorNivelMadre = AnioMayorNivelMadre;
				
			item.TipoDocPadre = TipoDocPadre;
				
			item.NroDocPadre = NroDocPadre;
				
			item.ApellidoPadre = ApellidoPadre;
				
			item.NombrePadre = NombrePadre;
				
			item.AlfabetaPadre = AlfabetaPadre;
				
			item.EstudiosPadre = EstudiosPadre;
				
			item.AnioMayorNivelPadre = AnioMayorNivelPadre;
				
			item.TipoDocTutor = TipoDocTutor;
				
			item.NroDocTutor = NroDocTutor;
				
			item.ApellidoTutor = ApellidoTutor;
				
			item.NombreTutor = NombreTutor;
				
			item.AlfabetaTutor = AlfabetaTutor;
				
			item.EstudiosTutor = EstudiosTutor;
				
			item.AnioMayorNivelTutor = AnioMayorNivelTutor;
				
			item.FechaDiagnosticoEmbarazo = FechaDiagnosticoEmbarazo;
				
			item.SemanasEmbarazo = SemanasEmbarazo;
				
			item.FechaProbableParto = FechaProbableParto;
				
			item.FechaEfectivaParto = FechaEfectivaParto;
				
			item.CuieEa = CuieEa;
				
			item.CuieAh = CuieAh;
				
			item.MenorConviveConAdulto = MenorConviveConAdulto;
				
			item.Calle = Calle;
				
			item.NumeroCalle = NumeroCalle;
				
			item.Piso = Piso;
				
			item.Dpto = Dpto;
				
			item.Manzana = Manzana;
				
			item.EntreCalle1 = EntreCalle1;
				
			item.EntreCalle2 = EntreCalle2;
				
			item.Telefono = Telefono;
				
			item.Departamento = Departamento;
				
			item.Localidad = Localidad;
				
			item.Municipio = Municipio;
				
			item.Barrio = Barrio;
				
			item.CodPos = CodPos;
				
			item.Observaciones = Observaciones;
				
			item.FechaInscripcion = FechaInscripcion;
				
			item.FechaCarga = FechaCarga;
				
			item.UsuarioCarga = UsuarioCarga;
				
			item.Activo = Activo;
				
			item.TipoFicha = TipoFicha;
				
			item.Responsable = Responsable;
				
			item.Fum = Fum;
				
			item.Rcv = Rcv;
				
			item.Discv = Discv;
				
			item.Disca = Disca;
				
			item.Discmo = Discmo;
				
			item.Discme = Discme;
				
			item.Otradisc = Otradisc;
				
	        item.Save(UserName);
	    }
    }
}
