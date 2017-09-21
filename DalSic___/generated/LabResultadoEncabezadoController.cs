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
    /// Controller class for LAB_ResultadoEncabezado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabResultadoEncabezadoController
    {
        // Preload our schema..
        LabResultadoEncabezado thisSchemaLoad = new LabResultadoEncabezado();
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
        public LabResultadoEncabezadoCollection FetchAll()
        {
            LabResultadoEncabezadoCollection coll = new LabResultadoEncabezadoCollection();
            Query qry = new Query(LabResultadoEncabezado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabResultadoEncabezadoCollection FetchByID(object IdProtocolo)
        {
            LabResultadoEncabezadoCollection coll = new LabResultadoEncabezadoCollection().Where("idProtocolo", IdProtocolo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabResultadoEncabezadoCollection FetchByQuery(Query qry)
        {
            LabResultadoEncabezadoCollection coll = new LabResultadoEncabezadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProtocolo)
        {
            return (LabResultadoEncabezado.Delete(IdProtocolo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProtocolo)
        {
            return (LabResultadoEncabezado.Destroy(IdProtocolo) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int IdProtocolo,int IdEfector)
        {
            Query qry = new Query(LabResultadoEncabezado.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("IdProtocolo", IdProtocolo).AND("IdEfector", IdEfector);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdProtocolo,int IdEfector,string Apellido,string Nombre,int Edad,string UnidadEdad,string FechaNacimiento,string Sexo,int NumeroDocumento,string Fecha,DateTime Fecha1,string Domicilio,int Hc,string Prioridad,string Origen,string Numero,bool? Hiv,string Solicitante,string Sector,string Sala,string Cama,string Embarazo,string EfectorSolicitante,int? IdSolicitudScreening,DateTime? FechaRecibeScreening,string ObservacionesResultados,string TipoMuestra)
	    {
		    LabResultadoEncabezado item = new LabResultadoEncabezado();
		    
            item.IdProtocolo = IdProtocolo;
            
            item.IdEfector = IdEfector;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.Edad = Edad;
            
            item.UnidadEdad = UnidadEdad;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.Sexo = Sexo;
            
            item.NumeroDocumento = NumeroDocumento;
            
            item.Fecha = Fecha;
            
            item.Fecha1 = Fecha1;
            
            item.Domicilio = Domicilio;
            
            item.Hc = Hc;
            
            item.Prioridad = Prioridad;
            
            item.Origen = Origen;
            
            item.Numero = Numero;
            
            item.Hiv = Hiv;
            
            item.Solicitante = Solicitante;
            
            item.Sector = Sector;
            
            item.Sala = Sala;
            
            item.Cama = Cama;
            
            item.Embarazo = Embarazo;
            
            item.EfectorSolicitante = EfectorSolicitante;
            
            item.IdSolicitudScreening = IdSolicitudScreening;
            
            item.FechaRecibeScreening = FechaRecibeScreening;
            
            item.ObservacionesResultados = ObservacionesResultados;
            
            item.TipoMuestra = TipoMuestra;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProtocolo,int IdEfector,string Apellido,string Nombre,int Edad,string UnidadEdad,string FechaNacimiento,string Sexo,int NumeroDocumento,string Fecha,DateTime Fecha1,string Domicilio,int Hc,string Prioridad,string Origen,string Numero,bool? Hiv,string Solicitante,string Sector,string Sala,string Cama,string Embarazo,string EfectorSolicitante,int? IdSolicitudScreening,DateTime? FechaRecibeScreening,string ObservacionesResultados,string TipoMuestra)
	    {
		    LabResultadoEncabezado item = new LabResultadoEncabezado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProtocolo = IdProtocolo;
				
			item.IdEfector = IdEfector;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.Edad = Edad;
				
			item.UnidadEdad = UnidadEdad;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.Sexo = Sexo;
				
			item.NumeroDocumento = NumeroDocumento;
				
			item.Fecha = Fecha;
				
			item.Fecha1 = Fecha1;
				
			item.Domicilio = Domicilio;
				
			item.Hc = Hc;
				
			item.Prioridad = Prioridad;
				
			item.Origen = Origen;
				
			item.Numero = Numero;
				
			item.Hiv = Hiv;
				
			item.Solicitante = Solicitante;
				
			item.Sector = Sector;
				
			item.Sala = Sala;
				
			item.Cama = Cama;
				
			item.Embarazo = Embarazo;
				
			item.EfectorSolicitante = EfectorSolicitante;
				
			item.IdSolicitudScreening = IdSolicitudScreening;
				
			item.FechaRecibeScreening = FechaRecibeScreening;
				
			item.ObservacionesResultados = ObservacionesResultados;
				
			item.TipoMuestra = TipoMuestra;
				
	        item.Save(UserName);
	    }
    }
}
