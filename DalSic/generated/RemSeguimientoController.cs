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
    /// Controller class for Rem_Seguimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemSeguimientoController
    {
        // Preload our schema..
        RemSeguimiento thisSchemaLoad = new RemSeguimiento();
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
        public RemSeguimientoCollection FetchAll()
        {
            RemSeguimientoCollection coll = new RemSeguimientoCollection();
            Query qry = new Query(RemSeguimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemSeguimientoCollection FetchByID(object IdSeguimiento)
        {
            RemSeguimientoCollection coll = new RemSeguimientoCollection().Where("idSeguimiento", IdSeguimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemSeguimientoCollection FetchByQuery(Query qry)
        {
            RemSeguimientoCollection coll = new RemSeguimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSeguimiento)
        {
            return (RemSeguimiento.Delete(IdSeguimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSeguimiento)
        {
            return (RemSeguimiento.Destroy(IdSeguimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdClasificacion,int IdEfector,int IdPaciente,int Edad,DateTime FechaControl,decimal Peso,decimal Talla,decimal Imc,int TAS,int TAD,int ExamenPiesCompleto,int PlanAlimentario,int ActividadFisicaAdecuada,decimal CircunferenciaAbdominal,DateTime FechaLab,decimal Glucemia,string UnidadGlucemia,bool GlucemiaSolicitada,decimal HbAc1,bool HbAc1solicitado,decimal Hematocrito,bool HemtocritoSolicitado,decimal ColesterolTotal,bool ColeterolSolicitado,string UnidadColTotal,decimal Hdl,string UnidadHDL,bool HdlSolicitado,decimal Ldl,string UnidadLDL,bool LdlSolicitado,decimal Tgl,string UnidadTGL,bool TglSolicitado,decimal Creatininemia,string UnidadCreatininemia,bool CreatininemiSolicitada,decimal Ptog,string UnidadPTOG,bool PtogSolicitado,decimal Microalbuminuria,bool MicroalbuminuriaSolicitada,decimal Claerence,bool ClearenceSolicitado,decimal RelacionCOrina,string OtrosLab,bool InsulinaNPH,bool InsulinaRap,bool InsulinaAnalog,int PresentacionInsulina,string OtrasDrogas1,decimal DosisODrogas1,string OtrasDrogras2,decimal DosisODrogas2,string OtrosMedicam,int AutomonitoreoGLucemico,int NroTirasSemana,bool EducacionGrupalS,bool EducacionGrupalR,bool ConsultorioNutricionalS,bool ConsultorioNutricionalR,bool ConsultorioPodologicoS,bool ConsultorioPodologicoR,bool CardiologiaS,bool CardiologiaR,bool NefrologiaS,bool NefrologiaR,bool ClinicaMedicaS,bool ClinicaMedicaR,bool OftalmologiaS,bool OftalmologiaR,int IdProfesional,bool Cerrar,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,string UnidadCOrina,bool RelacionCOrinaSolicitado,string NombreInsulina,int UnidadesDiaINPH,int UnidadesDiaIRap,int UnidadesDiaIAnalog,string Hematities,bool HematitiesSolicitado,decimal FiltradoGlomerular,bool FiltradoGlomSolicitado,decimal IUProteinaCreatinina,bool IUProtCreatininaSolicitado,decimal IUAlbuminaCreatinina,bool IUAlbumCreatinSolicitado)
	    {
		    RemSeguimiento item = new RemSeguimiento();
		    
            item.IdClasificacion = IdClasificacion;
            
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.FechaControl = FechaControl;
            
            item.Peso = Peso;
            
            item.Talla = Talla;
            
            item.Imc = Imc;
            
            item.TAS = TAS;
            
            item.TAD = TAD;
            
            item.ExamenPiesCompleto = ExamenPiesCompleto;
            
            item.PlanAlimentario = PlanAlimentario;
            
            item.ActividadFisicaAdecuada = ActividadFisicaAdecuada;
            
            item.CircunferenciaAbdominal = CircunferenciaAbdominal;
            
            item.FechaLab = FechaLab;
            
            item.Glucemia = Glucemia;
            
            item.UnidadGlucemia = UnidadGlucemia;
            
            item.GlucemiaSolicitada = GlucemiaSolicitada;
            
            item.HbAc1 = HbAc1;
            
            item.HbAc1solicitado = HbAc1solicitado;
            
            item.Hematocrito = Hematocrito;
            
            item.HemtocritoSolicitado = HemtocritoSolicitado;
            
            item.ColesterolTotal = ColesterolTotal;
            
            item.ColeterolSolicitado = ColeterolSolicitado;
            
            item.UnidadColTotal = UnidadColTotal;
            
            item.Hdl = Hdl;
            
            item.UnidadHDL = UnidadHDL;
            
            item.HdlSolicitado = HdlSolicitado;
            
            item.Ldl = Ldl;
            
            item.UnidadLDL = UnidadLDL;
            
            item.LdlSolicitado = LdlSolicitado;
            
            item.Tgl = Tgl;
            
            item.UnidadTGL = UnidadTGL;
            
            item.TglSolicitado = TglSolicitado;
            
            item.Creatininemia = Creatininemia;
            
            item.UnidadCreatininemia = UnidadCreatininemia;
            
            item.CreatininemiSolicitada = CreatininemiSolicitada;
            
            item.Ptog = Ptog;
            
            item.UnidadPTOG = UnidadPTOG;
            
            item.PtogSolicitado = PtogSolicitado;
            
            item.Microalbuminuria = Microalbuminuria;
            
            item.MicroalbuminuriaSolicitada = MicroalbuminuriaSolicitada;
            
            item.Claerence = Claerence;
            
            item.ClearenceSolicitado = ClearenceSolicitado;
            
            item.RelacionCOrina = RelacionCOrina;
            
            item.OtrosLab = OtrosLab;
            
            item.InsulinaNPH = InsulinaNPH;
            
            item.InsulinaRap = InsulinaRap;
            
            item.InsulinaAnalog = InsulinaAnalog;
            
            item.PresentacionInsulina = PresentacionInsulina;
            
            item.OtrasDrogas1 = OtrasDrogas1;
            
            item.DosisODrogas1 = DosisODrogas1;
            
            item.OtrasDrogras2 = OtrasDrogras2;
            
            item.DosisODrogas2 = DosisODrogas2;
            
            item.OtrosMedicam = OtrosMedicam;
            
            item.AutomonitoreoGLucemico = AutomonitoreoGLucemico;
            
            item.NroTirasSemana = NroTirasSemana;
            
            item.EducacionGrupalS = EducacionGrupalS;
            
            item.EducacionGrupalR = EducacionGrupalR;
            
            item.ConsultorioNutricionalS = ConsultorioNutricionalS;
            
            item.ConsultorioNutricionalR = ConsultorioNutricionalR;
            
            item.ConsultorioPodologicoS = ConsultorioPodologicoS;
            
            item.ConsultorioPodologicoR = ConsultorioPodologicoR;
            
            item.CardiologiaS = CardiologiaS;
            
            item.CardiologiaR = CardiologiaR;
            
            item.NefrologiaS = NefrologiaS;
            
            item.NefrologiaR = NefrologiaR;
            
            item.ClinicaMedicaS = ClinicaMedicaS;
            
            item.ClinicaMedicaR = ClinicaMedicaR;
            
            item.OftalmologiaS = OftalmologiaS;
            
            item.OftalmologiaR = OftalmologiaR;
            
            item.IdProfesional = IdProfesional;
            
            item.Cerrar = Cerrar;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.UnidadCOrina = UnidadCOrina;
            
            item.RelacionCOrinaSolicitado = RelacionCOrinaSolicitado;
            
            item.NombreInsulina = NombreInsulina;
            
            item.UnidadesDiaINPH = UnidadesDiaINPH;
            
            item.UnidadesDiaIRap = UnidadesDiaIRap;
            
            item.UnidadesDiaIAnalog = UnidadesDiaIAnalog;
            
            item.Hematities = Hematities;
            
            item.HematitiesSolicitado = HematitiesSolicitado;
            
            item.FiltradoGlomerular = FiltradoGlomerular;
            
            item.FiltradoGlomSolicitado = FiltradoGlomSolicitado;
            
            item.IUProteinaCreatinina = IUProteinaCreatinina;
            
            item.IUProtCreatininaSolicitado = IUProtCreatininaSolicitado;
            
            item.IUAlbuminaCreatinina = IUAlbuminaCreatinina;
            
            item.IUAlbumCreatinSolicitado = IUAlbumCreatinSolicitado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSeguimiento,int IdClasificacion,int IdEfector,int IdPaciente,int Edad,DateTime FechaControl,decimal Peso,decimal Talla,decimal Imc,int TAS,int TAD,int ExamenPiesCompleto,int PlanAlimentario,int ActividadFisicaAdecuada,decimal CircunferenciaAbdominal,DateTime FechaLab,decimal Glucemia,string UnidadGlucemia,bool GlucemiaSolicitada,decimal HbAc1,bool HbAc1solicitado,decimal Hematocrito,bool HemtocritoSolicitado,decimal ColesterolTotal,bool ColeterolSolicitado,string UnidadColTotal,decimal Hdl,string UnidadHDL,bool HdlSolicitado,decimal Ldl,string UnidadLDL,bool LdlSolicitado,decimal Tgl,string UnidadTGL,bool TglSolicitado,decimal Creatininemia,string UnidadCreatininemia,bool CreatininemiSolicitada,decimal Ptog,string UnidadPTOG,bool PtogSolicitado,decimal Microalbuminuria,bool MicroalbuminuriaSolicitada,decimal Claerence,bool ClearenceSolicitado,decimal RelacionCOrina,string OtrosLab,bool InsulinaNPH,bool InsulinaRap,bool InsulinaAnalog,int PresentacionInsulina,string OtrasDrogas1,decimal DosisODrogas1,string OtrasDrogras2,decimal DosisODrogas2,string OtrosMedicam,int AutomonitoreoGLucemico,int NroTirasSemana,bool EducacionGrupalS,bool EducacionGrupalR,bool ConsultorioNutricionalS,bool ConsultorioNutricionalR,bool ConsultorioPodologicoS,bool ConsultorioPodologicoR,bool CardiologiaS,bool CardiologiaR,bool NefrologiaS,bool NefrologiaR,bool ClinicaMedicaS,bool ClinicaMedicaR,bool OftalmologiaS,bool OftalmologiaR,int IdProfesional,bool Cerrar,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,string UnidadCOrina,bool RelacionCOrinaSolicitado,string NombreInsulina,int UnidadesDiaINPH,int UnidadesDiaIRap,int UnidadesDiaIAnalog,string Hematities,bool HematitiesSolicitado,decimal FiltradoGlomerular,bool FiltradoGlomSolicitado,decimal IUProteinaCreatinina,bool IUProtCreatininaSolicitado,decimal IUAlbuminaCreatinina,bool IUAlbumCreatinSolicitado)
	    {
		    RemSeguimiento item = new RemSeguimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSeguimiento = IdSeguimiento;
				
			item.IdClasificacion = IdClasificacion;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.FechaControl = FechaControl;
				
			item.Peso = Peso;
				
			item.Talla = Talla;
				
			item.Imc = Imc;
				
			item.TAS = TAS;
				
			item.TAD = TAD;
				
			item.ExamenPiesCompleto = ExamenPiesCompleto;
				
			item.PlanAlimentario = PlanAlimentario;
				
			item.ActividadFisicaAdecuada = ActividadFisicaAdecuada;
				
			item.CircunferenciaAbdominal = CircunferenciaAbdominal;
				
			item.FechaLab = FechaLab;
				
			item.Glucemia = Glucemia;
				
			item.UnidadGlucemia = UnidadGlucemia;
				
			item.GlucemiaSolicitada = GlucemiaSolicitada;
				
			item.HbAc1 = HbAc1;
				
			item.HbAc1solicitado = HbAc1solicitado;
				
			item.Hematocrito = Hematocrito;
				
			item.HemtocritoSolicitado = HemtocritoSolicitado;
				
			item.ColesterolTotal = ColesterolTotal;
				
			item.ColeterolSolicitado = ColeterolSolicitado;
				
			item.UnidadColTotal = UnidadColTotal;
				
			item.Hdl = Hdl;
				
			item.UnidadHDL = UnidadHDL;
				
			item.HdlSolicitado = HdlSolicitado;
				
			item.Ldl = Ldl;
				
			item.UnidadLDL = UnidadLDL;
				
			item.LdlSolicitado = LdlSolicitado;
				
			item.Tgl = Tgl;
				
			item.UnidadTGL = UnidadTGL;
				
			item.TglSolicitado = TglSolicitado;
				
			item.Creatininemia = Creatininemia;
				
			item.UnidadCreatininemia = UnidadCreatininemia;
				
			item.CreatininemiSolicitada = CreatininemiSolicitada;
				
			item.Ptog = Ptog;
				
			item.UnidadPTOG = UnidadPTOG;
				
			item.PtogSolicitado = PtogSolicitado;
				
			item.Microalbuminuria = Microalbuminuria;
				
			item.MicroalbuminuriaSolicitada = MicroalbuminuriaSolicitada;
				
			item.Claerence = Claerence;
				
			item.ClearenceSolicitado = ClearenceSolicitado;
				
			item.RelacionCOrina = RelacionCOrina;
				
			item.OtrosLab = OtrosLab;
				
			item.InsulinaNPH = InsulinaNPH;
				
			item.InsulinaRap = InsulinaRap;
				
			item.InsulinaAnalog = InsulinaAnalog;
				
			item.PresentacionInsulina = PresentacionInsulina;
				
			item.OtrasDrogas1 = OtrasDrogas1;
				
			item.DosisODrogas1 = DosisODrogas1;
				
			item.OtrasDrogras2 = OtrasDrogras2;
				
			item.DosisODrogas2 = DosisODrogas2;
				
			item.OtrosMedicam = OtrosMedicam;
				
			item.AutomonitoreoGLucemico = AutomonitoreoGLucemico;
				
			item.NroTirasSemana = NroTirasSemana;
				
			item.EducacionGrupalS = EducacionGrupalS;
				
			item.EducacionGrupalR = EducacionGrupalR;
				
			item.ConsultorioNutricionalS = ConsultorioNutricionalS;
				
			item.ConsultorioNutricionalR = ConsultorioNutricionalR;
				
			item.ConsultorioPodologicoS = ConsultorioPodologicoS;
				
			item.ConsultorioPodologicoR = ConsultorioPodologicoR;
				
			item.CardiologiaS = CardiologiaS;
				
			item.CardiologiaR = CardiologiaR;
				
			item.NefrologiaS = NefrologiaS;
				
			item.NefrologiaR = NefrologiaR;
				
			item.ClinicaMedicaS = ClinicaMedicaS;
				
			item.ClinicaMedicaR = ClinicaMedicaR;
				
			item.OftalmologiaS = OftalmologiaS;
				
			item.OftalmologiaR = OftalmologiaR;
				
			item.IdProfesional = IdProfesional;
				
			item.Cerrar = Cerrar;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.UnidadCOrina = UnidadCOrina;
				
			item.RelacionCOrinaSolicitado = RelacionCOrinaSolicitado;
				
			item.NombreInsulina = NombreInsulina;
				
			item.UnidadesDiaINPH = UnidadesDiaINPH;
				
			item.UnidadesDiaIRap = UnidadesDiaIRap;
				
			item.UnidadesDiaIAnalog = UnidadesDiaIAnalog;
				
			item.Hematities = Hematities;
				
			item.HematitiesSolicitado = HematitiesSolicitado;
				
			item.FiltradoGlomerular = FiltradoGlomerular;
				
			item.FiltradoGlomSolicitado = FiltradoGlomSolicitado;
				
			item.IUProteinaCreatinina = IUProteinaCreatinina;
				
			item.IUProtCreatininaSolicitado = IUProtCreatininaSolicitado;
				
			item.IUAlbuminaCreatinina = IUAlbuminaCreatinina;
				
			item.IUAlbumCreatinSolicitado = IUAlbumCreatinSolicitado;
				
	        item.Save(UserName);
	    }
    }
}
