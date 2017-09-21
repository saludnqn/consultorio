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
    /// Controller class for Rem_Clasificacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemClasificacionController
    {
        // Preload our schema..
        RemClasificacion thisSchemaLoad = new RemClasificacion();
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
        public RemClasificacionCollection FetchAll()
        {
            RemClasificacionCollection coll = new RemClasificacionCollection();
            Query qry = new Query(RemClasificacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemClasificacionCollection FetchByID(object IdClasificacion)
        {
            RemClasificacionCollection coll = new RemClasificacionCollection().Where("idClasificacion", IdClasificacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemClasificacionCollection FetchByQuery(Query qry)
        {
            RemClasificacionCollection coll = new RemClasificacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdClasificacion)
        {
            return (RemClasificacion.Delete(IdClasificacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdClasificacion)
        {
            return (RemClasificacion.Destroy(IdClasificacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdFormulario,int IdEfector,int IdPaciente,int Edad,int NroClasificacion,DateTime FechaControl,decimal Peso,decimal Talla,decimal Imc,int TAS,int TAD,int ExamenPies,int PlanAlimentario,int ActividadFisica,bool AFAdecuada,decimal CircunferenciaAbdominal,DateTime FechaLab,decimal Glucemia,string UnidadGlucemia,decimal HbAc1,decimal Hematocrito,decimal ColesterolTotal,string UnidadColTotal,decimal Hdl,string UnidadHDL,decimal Ldl,string UnidadLDL,decimal Tgl,string UnidadTGL,decimal Creatininemia,string UnidadCreatininemia,decimal Ptog,string UnidadPTOG,decimal Microalbuminuria,decimal Claerence,decimal RelacionAlbuminaOrina,string OtrosLab,string NombreInsulina,int PresentacionInsulina,bool InsulinaNPH,int UnidadesDiaINPH,bool InsulinaRap,int UnidadesDiaIRap,bool InsulinaAnalog,int UnidadesDiaIAnalog,decimal Alcoholismo,decimal IUProteinaCreatinina,decimal IUAlbuminaCreatinina,decimal FiltradoGlomerular,string Hematities,int EstadiEnfermedadRenal,int NroAutomonitoreo,bool TirasReactivas,string OtrasDrogas1,decimal DosisODrogas1,string OtrasDrogras2,decimal DosisODrogas2,int IdProfesional,string MedicoCabecera,bool Automonitoreo1,bool Automonitoreo2,int IdObraSocial,string OtrosMedicam,int RiesgoCardiovascular,bool Cerrar,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    RemClasificacion item = new RemClasificacion();
		    
            item.IdFormulario = IdFormulario;
            
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.NroClasificacion = NroClasificacion;
            
            item.FechaControl = FechaControl;
            
            item.Peso = Peso;
            
            item.Talla = Talla;
            
            item.Imc = Imc;
            
            item.TAS = TAS;
            
            item.TAD = TAD;
            
            item.ExamenPies = ExamenPies;
            
            item.PlanAlimentario = PlanAlimentario;
            
            item.ActividadFisica = ActividadFisica;
            
            item.AFAdecuada = AFAdecuada;
            
            item.CircunferenciaAbdominal = CircunferenciaAbdominal;
            
            item.FechaLab = FechaLab;
            
            item.Glucemia = Glucemia;
            
            item.UnidadGlucemia = UnidadGlucemia;
            
            item.HbAc1 = HbAc1;
            
            item.Hematocrito = Hematocrito;
            
            item.ColesterolTotal = ColesterolTotal;
            
            item.UnidadColTotal = UnidadColTotal;
            
            item.Hdl = Hdl;
            
            item.UnidadHDL = UnidadHDL;
            
            item.Ldl = Ldl;
            
            item.UnidadLDL = UnidadLDL;
            
            item.Tgl = Tgl;
            
            item.UnidadTGL = UnidadTGL;
            
            item.Creatininemia = Creatininemia;
            
            item.UnidadCreatininemia = UnidadCreatininemia;
            
            item.Ptog = Ptog;
            
            item.UnidadPTOG = UnidadPTOG;
            
            item.Microalbuminuria = Microalbuminuria;
            
            item.Claerence = Claerence;
            
            item.RelacionAlbuminaOrina = RelacionAlbuminaOrina;
            
            item.OtrosLab = OtrosLab;
            
            item.NombreInsulina = NombreInsulina;
            
            item.PresentacionInsulina = PresentacionInsulina;
            
            item.InsulinaNPH = InsulinaNPH;
            
            item.UnidadesDiaINPH = UnidadesDiaINPH;
            
            item.InsulinaRap = InsulinaRap;
            
            item.UnidadesDiaIRap = UnidadesDiaIRap;
            
            item.InsulinaAnalog = InsulinaAnalog;
            
            item.UnidadesDiaIAnalog = UnidadesDiaIAnalog;
            
            item.Alcoholismo = Alcoholismo;
            
            item.IUProteinaCreatinina = IUProteinaCreatinina;
            
            item.IUAlbuminaCreatinina = IUAlbuminaCreatinina;
            
            item.FiltradoGlomerular = FiltradoGlomerular;
            
            item.Hematities = Hematities;
            
            item.EstadiEnfermedadRenal = EstadiEnfermedadRenal;
            
            item.NroAutomonitoreo = NroAutomonitoreo;
            
            item.TirasReactivas = TirasReactivas;
            
            item.OtrasDrogas1 = OtrasDrogas1;
            
            item.DosisODrogas1 = DosisODrogas1;
            
            item.OtrasDrogras2 = OtrasDrogras2;
            
            item.DosisODrogas2 = DosisODrogas2;
            
            item.IdProfesional = IdProfesional;
            
            item.MedicoCabecera = MedicoCabecera;
            
            item.Automonitoreo1 = Automonitoreo1;
            
            item.Automonitoreo2 = Automonitoreo2;
            
            item.IdObraSocial = IdObraSocial;
            
            item.OtrosMedicam = OtrosMedicam;
            
            item.RiesgoCardiovascular = RiesgoCardiovascular;
            
            item.Cerrar = Cerrar;
            
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
	    public void Update(int IdClasificacion,int IdFormulario,int IdEfector,int IdPaciente,int Edad,int NroClasificacion,DateTime FechaControl,decimal Peso,decimal Talla,decimal Imc,int TAS,int TAD,int ExamenPies,int PlanAlimentario,int ActividadFisica,bool AFAdecuada,decimal CircunferenciaAbdominal,DateTime FechaLab,decimal Glucemia,string UnidadGlucemia,decimal HbAc1,decimal Hematocrito,decimal ColesterolTotal,string UnidadColTotal,decimal Hdl,string UnidadHDL,decimal Ldl,string UnidadLDL,decimal Tgl,string UnidadTGL,decimal Creatininemia,string UnidadCreatininemia,decimal Ptog,string UnidadPTOG,decimal Microalbuminuria,decimal Claerence,decimal RelacionAlbuminaOrina,string OtrosLab,string NombreInsulina,int PresentacionInsulina,bool InsulinaNPH,int UnidadesDiaINPH,bool InsulinaRap,int UnidadesDiaIRap,bool InsulinaAnalog,int UnidadesDiaIAnalog,decimal Alcoholismo,decimal IUProteinaCreatinina,decimal IUAlbuminaCreatinina,decimal FiltradoGlomerular,string Hematities,int EstadiEnfermedadRenal,int NroAutomonitoreo,bool TirasReactivas,string OtrasDrogas1,decimal DosisODrogas1,string OtrasDrogras2,decimal DosisODrogas2,int IdProfesional,string MedicoCabecera,bool Automonitoreo1,bool Automonitoreo2,int IdObraSocial,string OtrosMedicam,int RiesgoCardiovascular,bool Cerrar,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    RemClasificacion item = new RemClasificacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdClasificacion = IdClasificacion;
				
			item.IdFormulario = IdFormulario;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.NroClasificacion = NroClasificacion;
				
			item.FechaControl = FechaControl;
				
			item.Peso = Peso;
				
			item.Talla = Talla;
				
			item.Imc = Imc;
				
			item.TAS = TAS;
				
			item.TAD = TAD;
				
			item.ExamenPies = ExamenPies;
				
			item.PlanAlimentario = PlanAlimentario;
				
			item.ActividadFisica = ActividadFisica;
				
			item.AFAdecuada = AFAdecuada;
				
			item.CircunferenciaAbdominal = CircunferenciaAbdominal;
				
			item.FechaLab = FechaLab;
				
			item.Glucemia = Glucemia;
				
			item.UnidadGlucemia = UnidadGlucemia;
				
			item.HbAc1 = HbAc1;
				
			item.Hematocrito = Hematocrito;
				
			item.ColesterolTotal = ColesterolTotal;
				
			item.UnidadColTotal = UnidadColTotal;
				
			item.Hdl = Hdl;
				
			item.UnidadHDL = UnidadHDL;
				
			item.Ldl = Ldl;
				
			item.UnidadLDL = UnidadLDL;
				
			item.Tgl = Tgl;
				
			item.UnidadTGL = UnidadTGL;
				
			item.Creatininemia = Creatininemia;
				
			item.UnidadCreatininemia = UnidadCreatininemia;
				
			item.Ptog = Ptog;
				
			item.UnidadPTOG = UnidadPTOG;
				
			item.Microalbuminuria = Microalbuminuria;
				
			item.Claerence = Claerence;
				
			item.RelacionAlbuminaOrina = RelacionAlbuminaOrina;
				
			item.OtrosLab = OtrosLab;
				
			item.NombreInsulina = NombreInsulina;
				
			item.PresentacionInsulina = PresentacionInsulina;
				
			item.InsulinaNPH = InsulinaNPH;
				
			item.UnidadesDiaINPH = UnidadesDiaINPH;
				
			item.InsulinaRap = InsulinaRap;
				
			item.UnidadesDiaIRap = UnidadesDiaIRap;
				
			item.InsulinaAnalog = InsulinaAnalog;
				
			item.UnidadesDiaIAnalog = UnidadesDiaIAnalog;
				
			item.Alcoholismo = Alcoholismo;
				
			item.IUProteinaCreatinina = IUProteinaCreatinina;
				
			item.IUAlbuminaCreatinina = IUAlbuminaCreatinina;
				
			item.FiltradoGlomerular = FiltradoGlomerular;
				
			item.Hematities = Hematities;
				
			item.EstadiEnfermedadRenal = EstadiEnfermedadRenal;
				
			item.NroAutomonitoreo = NroAutomonitoreo;
				
			item.TirasReactivas = TirasReactivas;
				
			item.OtrasDrogas1 = OtrasDrogas1;
				
			item.DosisODrogas1 = DosisODrogas1;
				
			item.OtrasDrogras2 = OtrasDrogras2;
				
			item.DosisODrogas2 = DosisODrogas2;
				
			item.IdProfesional = IdProfesional;
				
			item.MedicoCabecera = MedicoCabecera;
				
			item.Automonitoreo1 = Automonitoreo1;
				
			item.Automonitoreo2 = Automonitoreo2;
				
			item.IdObraSocial = IdObraSocial;
				
			item.OtrosMedicam = OtrosMedicam;
				
			item.RiesgoCardiovascular = RiesgoCardiovascular;
				
			item.Cerrar = Cerrar;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
