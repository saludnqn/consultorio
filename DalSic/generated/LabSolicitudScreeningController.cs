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
    /// Controller class for LAB_SolicitudScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabSolicitudScreeningController
    {
        // Preload our schema..
        LabSolicitudScreening thisSchemaLoad = new LabSolicitudScreening();
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
        public LabSolicitudScreeningCollection FetchAll()
        {
            LabSolicitudScreeningCollection coll = new LabSolicitudScreeningCollection();
            Query qry = new Query(LabSolicitudScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSolicitudScreeningCollection FetchByID(object IdSolicitudScreening)
        {
            LabSolicitudScreeningCollection coll = new LabSolicitudScreeningCollection().Where("idSolicitudScreening", IdSolicitudScreening).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSolicitudScreeningCollection FetchByQuery(Query qry)
        {
            LabSolicitudScreeningCollection coll = new LabSolicitudScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSolicitudScreening)
        {
            return (LabSolicitudScreening.Delete(IdSolicitudScreening) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSolicitudScreening)
        {
            return (LabSolicitudScreening.Destroy(IdSolicitudScreening) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int IdEfectorSolicitante,int NumeroTarjeta,string MedicoSolicitante,string ApellidoMaterno,string ApellidoPaterno,string HoraNacimiento,int EdadGestacional,decimal Peso,bool PrimeraMuestra,int IdMotivoRepeticion,DateTime FechaExtraccion,string HoraExtraccion,bool IngestaLeche24Horas,int TipoAlimentacion,bool Antibiotico,bool Transfusion,bool Corticoides,bool Dopamina,bool EnfermedadTiroideaMaterna,string AntecedentesMaternos,bool CorticoidesMaterno,string Observaciones,string ObservacionesResultados,int Estado,int IdUsuarioRegistro,DateTime FechaRegistro,string IdUsuarioEnvio,DateTime FechaEnvio,string IdUsuarioRecibe,DateTime FechaRecibe,string IdUsuarioValida,DateTime FechaValida,int IdLugarControl,int? IdEfectorModifica,string Comentario,string Motivo)
	    {
		    LabSolicitudScreening item = new LabSolicitudScreening();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdEfectorSolicitante = IdEfectorSolicitante;
            
            item.NumeroTarjeta = NumeroTarjeta;
            
            item.MedicoSolicitante = MedicoSolicitante;
            
            item.ApellidoMaterno = ApellidoMaterno;
            
            item.ApellidoPaterno = ApellidoPaterno;
            
            item.HoraNacimiento = HoraNacimiento;
            
            item.EdadGestacional = EdadGestacional;
            
            item.Peso = Peso;
            
            item.PrimeraMuestra = PrimeraMuestra;
            
            item.IdMotivoRepeticion = IdMotivoRepeticion;
            
            item.FechaExtraccion = FechaExtraccion;
            
            item.HoraExtraccion = HoraExtraccion;
            
            item.IngestaLeche24Horas = IngestaLeche24Horas;
            
            item.TipoAlimentacion = TipoAlimentacion;
            
            item.Antibiotico = Antibiotico;
            
            item.Transfusion = Transfusion;
            
            item.Corticoides = Corticoides;
            
            item.Dopamina = Dopamina;
            
            item.EnfermedadTiroideaMaterna = EnfermedadTiroideaMaterna;
            
            item.AntecedentesMaternos = AntecedentesMaternos;
            
            item.CorticoidesMaterno = CorticoidesMaterno;
            
            item.Observaciones = Observaciones;
            
            item.ObservacionesResultados = ObservacionesResultados;
            
            item.Estado = Estado;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
            item.IdUsuarioEnvio = IdUsuarioEnvio;
            
            item.FechaEnvio = FechaEnvio;
            
            item.IdUsuarioRecibe = IdUsuarioRecibe;
            
            item.FechaRecibe = FechaRecibe;
            
            item.IdUsuarioValida = IdUsuarioValida;
            
            item.FechaValida = FechaValida;
            
            item.IdLugarControl = IdLugarControl;
            
            item.IdEfectorModifica = IdEfectorModifica;
            
            item.Comentario = Comentario;
            
            item.Motivo = Motivo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSolicitudScreening,int IdPaciente,int IdEfectorSolicitante,int NumeroTarjeta,string MedicoSolicitante,string ApellidoMaterno,string ApellidoPaterno,string HoraNacimiento,int EdadGestacional,decimal Peso,bool PrimeraMuestra,int IdMotivoRepeticion,DateTime FechaExtraccion,string HoraExtraccion,bool IngestaLeche24Horas,int TipoAlimentacion,bool Antibiotico,bool Transfusion,bool Corticoides,bool Dopamina,bool EnfermedadTiroideaMaterna,string AntecedentesMaternos,bool CorticoidesMaterno,string Observaciones,string ObservacionesResultados,int Estado,int IdUsuarioRegistro,DateTime FechaRegistro,string IdUsuarioEnvio,DateTime FechaEnvio,string IdUsuarioRecibe,DateTime FechaRecibe,string IdUsuarioValida,DateTime FechaValida,int IdLugarControl,int? IdEfectorModifica,string Comentario,string Motivo)
	    {
		    LabSolicitudScreening item = new LabSolicitudScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSolicitudScreening = IdSolicitudScreening;
				
			item.IdPaciente = IdPaciente;
				
			item.IdEfectorSolicitante = IdEfectorSolicitante;
				
			item.NumeroTarjeta = NumeroTarjeta;
				
			item.MedicoSolicitante = MedicoSolicitante;
				
			item.ApellidoMaterno = ApellidoMaterno;
				
			item.ApellidoPaterno = ApellidoPaterno;
				
			item.HoraNacimiento = HoraNacimiento;
				
			item.EdadGestacional = EdadGestacional;
				
			item.Peso = Peso;
				
			item.PrimeraMuestra = PrimeraMuestra;
				
			item.IdMotivoRepeticion = IdMotivoRepeticion;
				
			item.FechaExtraccion = FechaExtraccion;
				
			item.HoraExtraccion = HoraExtraccion;
				
			item.IngestaLeche24Horas = IngestaLeche24Horas;
				
			item.TipoAlimentacion = TipoAlimentacion;
				
			item.Antibiotico = Antibiotico;
				
			item.Transfusion = Transfusion;
				
			item.Corticoides = Corticoides;
				
			item.Dopamina = Dopamina;
				
			item.EnfermedadTiroideaMaterna = EnfermedadTiroideaMaterna;
				
			item.AntecedentesMaternos = AntecedentesMaternos;
				
			item.CorticoidesMaterno = CorticoidesMaterno;
				
			item.Observaciones = Observaciones;
				
			item.ObservacionesResultados = ObservacionesResultados;
				
			item.Estado = Estado;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
			item.IdUsuarioEnvio = IdUsuarioEnvio;
				
			item.FechaEnvio = FechaEnvio;
				
			item.IdUsuarioRecibe = IdUsuarioRecibe;
				
			item.FechaRecibe = FechaRecibe;
				
			item.IdUsuarioValida = IdUsuarioValida;
				
			item.FechaValida = FechaValida;
				
			item.IdLugarControl = IdLugarControl;
				
			item.IdEfectorModifica = IdEfectorModifica;
				
			item.Comentario = Comentario;
				
			item.Motivo = Motivo;
				
	        item.Save(UserName);
	    }
    }
}
