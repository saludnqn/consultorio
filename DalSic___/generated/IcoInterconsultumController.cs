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
    /// Controller class for ICO_Interconsulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IcoInterconsultumController
    {
        // Preload our schema..
        IcoInterconsultum thisSchemaLoad = new IcoInterconsultum();
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
        public IcoInterconsultumCollection FetchAll()
        {
            IcoInterconsultumCollection coll = new IcoInterconsultumCollection();
            Query qry = new Query(IcoInterconsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoInterconsultumCollection FetchByID(object IdInterconsulta)
        {
            IcoInterconsultumCollection coll = new IcoInterconsultumCollection().Where("idInterconsulta", IdInterconsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoInterconsultumCollection FetchByQuery(Query qry)
        {
            IcoInterconsultumCollection coll = new IcoInterconsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInterconsulta)
        {
            return (IcoInterconsultum.Delete(IdInterconsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInterconsulta)
        {
            return (IcoInterconsultum.Destroy(IdInterconsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime FechaSolicitud,DateTime FechaRecepcion,string ViaRecepcion,int IdProfesional,int IdEspecialidad,int IdPaciente,int? IdZona,int? IdEfector,int ProblemaIdCIE10,string MotivoConsulta,string ResumenHistoriaClinica,int CierreIdCIE10,string InterconsultaOCADU,string EstadoInterconsulta)
	    {
		    IcoInterconsultum item = new IcoInterconsultum();
		    
            item.FechaSolicitud = FechaSolicitud;
            
            item.FechaRecepcion = FechaRecepcion;
            
            item.ViaRecepcion = ViaRecepcion;
            
            item.IdProfesional = IdProfesional;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdPaciente = IdPaciente;
            
            item.IdZona = IdZona;
            
            item.IdEfector = IdEfector;
            
            item.ProblemaIdCIE10 = ProblemaIdCIE10;
            
            item.MotivoConsulta = MotivoConsulta;
            
            item.ResumenHistoriaClinica = ResumenHistoriaClinica;
            
            item.CierreIdCIE10 = CierreIdCIE10;
            
            item.InterconsultaOCADU = InterconsultaOCADU;
            
            item.EstadoInterconsulta = EstadoInterconsulta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInterconsulta,DateTime FechaSolicitud,DateTime FechaRecepcion,string ViaRecepcion,int IdProfesional,int IdEspecialidad,int IdPaciente,int? IdZona,int? IdEfector,int ProblemaIdCIE10,string MotivoConsulta,string ResumenHistoriaClinica,int CierreIdCIE10,string InterconsultaOCADU,string EstadoInterconsulta)
	    {
		    IcoInterconsultum item = new IcoInterconsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInterconsulta = IdInterconsulta;
				
			item.FechaSolicitud = FechaSolicitud;
				
			item.FechaRecepcion = FechaRecepcion;
				
			item.ViaRecepcion = ViaRecepcion;
				
			item.IdProfesional = IdProfesional;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdPaciente = IdPaciente;
				
			item.IdZona = IdZona;
				
			item.IdEfector = IdEfector;
				
			item.ProblemaIdCIE10 = ProblemaIdCIE10;
				
			item.MotivoConsulta = MotivoConsulta;
				
			item.ResumenHistoriaClinica = ResumenHistoriaClinica;
				
			item.CierreIdCIE10 = CierreIdCIE10;
				
			item.InterconsultaOCADU = InterconsultaOCADU;
				
			item.EstadoInterconsulta = EstadoInterconsulta;
				
	        item.Save(UserName);
	    }
    }
}
