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
    /// Controller class for CON_Consulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConConsultumController
    {
        // Preload our schema..
        ConConsultum thisSchemaLoad = new ConConsultum();
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
        public ConConsultumCollection FetchAll()
        {
            ConConsultumCollection coll = new ConConsultumCollection();
            Query qry = new Query(ConConsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultumCollection FetchByID(object IdConsulta)
        {
            ConConsultumCollection coll = new ConConsultumCollection().Where("idConsulta", IdConsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultumCollection FetchByQuery(Query qry)
        {
            ConConsultumCollection coll = new ConConsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConsulta)
        {
            return (ConConsultum.Delete(IdConsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConsulta)
        {
            return (ConConsultum.Destroy(IdConsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEfector,DateTime? Fecha,string Hora,int? IdPaciente,int? IdEspecialidad,int? IdProfesional,string MotivoConsulta,string InformeConsulta,int? IdDerivadoPor,int? IdDerivadoHacia,int? IdTipoPrestacion,int? IdObraSocial,int? IdUsuarioRegistro,DateTime? FechaRegistro,int IdTurno,decimal? Peso,decimal? Talla,int? TAS,decimal? TAD,decimal? Imc,decimal? PerimetroCefalico,int? RiesgoCardiovascular,int IdProgramaOdontologia,int PrimerConsultaOdontologia,int? IdEquipo)
	    {
		    ConConsultum item = new ConConsultum();
		    
            item.IdEfector = IdEfector;
            
            item.Fecha = Fecha;
            
            item.Hora = Hora;
            
            item.IdPaciente = IdPaciente;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdProfesional = IdProfesional;
            
            item.MotivoConsulta = MotivoConsulta;
            
            item.InformeConsulta = InformeConsulta;
            
            item.IdDerivadoPor = IdDerivadoPor;
            
            item.IdDerivadoHacia = IdDerivadoHacia;
            
            item.IdTipoPrestacion = IdTipoPrestacion;
            
            item.IdObraSocial = IdObraSocial;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
            item.IdTurno = IdTurno;
            
            item.Peso = Peso;
            
            item.Talla = Talla;
            
            item.TAS = TAS;
            
            item.TAD = TAD;
            
            item.Imc = Imc;
            
            item.PerimetroCefalico = PerimetroCefalico;
            
            item.RiesgoCardiovascular = RiesgoCardiovascular;
            
            item.IdProgramaOdontologia = IdProgramaOdontologia;
            
            item.PrimerConsultaOdontologia = PrimerConsultaOdontologia;
            
            item.IdEquipo = IdEquipo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConsulta,int? IdEfector,DateTime? Fecha,string Hora,int? IdPaciente,int? IdEspecialidad,int? IdProfesional,string MotivoConsulta,string InformeConsulta,int? IdDerivadoPor,int? IdDerivadoHacia,int? IdTipoPrestacion,int? IdObraSocial,int? IdUsuarioRegistro,DateTime? FechaRegistro,int IdTurno,decimal? Peso,decimal? Talla,int? TAS,decimal? TAD,decimal? Imc,decimal? PerimetroCefalico,int? RiesgoCardiovascular,int IdProgramaOdontologia,int PrimerConsultaOdontologia,int? IdEquipo)
	    {
		    ConConsultum item = new ConConsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConsulta = IdConsulta;
				
			item.IdEfector = IdEfector;
				
			item.Fecha = Fecha;
				
			item.Hora = Hora;
				
			item.IdPaciente = IdPaciente;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdProfesional = IdProfesional;
				
			item.MotivoConsulta = MotivoConsulta;
				
			item.InformeConsulta = InformeConsulta;
				
			item.IdDerivadoPor = IdDerivadoPor;
				
			item.IdDerivadoHacia = IdDerivadoHacia;
				
			item.IdTipoPrestacion = IdTipoPrestacion;
				
			item.IdObraSocial = IdObraSocial;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
			item.IdTurno = IdTurno;
				
			item.Peso = Peso;
				
			item.Talla = Talla;
				
			item.TAS = TAS;
				
			item.TAD = TAD;
				
			item.Imc = Imc;
				
			item.PerimetroCefalico = PerimetroCefalico;
				
			item.RiesgoCardiovascular = RiesgoCardiovascular;
				
			item.IdProgramaOdontologia = IdProgramaOdontologia;
				
			item.PrimerConsultaOdontologia = PrimerConsultaOdontologia;
				
			item.IdEquipo = IdEquipo;
				
	        item.Save(UserName);
	    }
    }
}
