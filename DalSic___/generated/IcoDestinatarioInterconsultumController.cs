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
    /// Controller class for ICO_DestinatarioInterconsulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IcoDestinatarioInterconsultumController
    {
        // Preload our schema..
        IcoDestinatarioInterconsultum thisSchemaLoad = new IcoDestinatarioInterconsultum();
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
        public IcoDestinatarioInterconsultumCollection FetchAll()
        {
            IcoDestinatarioInterconsultumCollection coll = new IcoDestinatarioInterconsultumCollection();
            Query qry = new Query(IcoDestinatarioInterconsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoDestinatarioInterconsultumCollection FetchByID(object IdDestinatariosInterconsulta)
        {
            IcoDestinatarioInterconsultumCollection coll = new IcoDestinatarioInterconsultumCollection().Where("idDestinatariosInterconsulta", IdDestinatariosInterconsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoDestinatarioInterconsultumCollection FetchByQuery(Query qry)
        {
            IcoDestinatarioInterconsultumCollection coll = new IcoDestinatarioInterconsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDestinatariosInterconsulta)
        {
            return (IcoDestinatarioInterconsultum.Delete(IdDestinatariosInterconsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDestinatariosInterconsulta)
        {
            return (IcoDestinatarioInterconsultum.Destroy(IdDestinatariosInterconsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdInterconsulta,int IdProfesional,int IdEspecialidad,int? IdZona,int? IdEfector,string Estado,DateTime? TurnoOtorgadoFecha,string TurnoOtorgadoHora,int? TurnoOtorgadoIdProfesional,int? TurnoOtorgadoIdEspecialidad)
	    {
		    IcoDestinatarioInterconsultum item = new IcoDestinatarioInterconsultum();
		    
            item.IdInterconsulta = IdInterconsulta;
            
            item.IdProfesional = IdProfesional;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.IdZona = IdZona;
            
            item.IdEfector = IdEfector;
            
            item.Estado = Estado;
            
            item.TurnoOtorgadoFecha = TurnoOtorgadoFecha;
            
            item.TurnoOtorgadoHora = TurnoOtorgadoHora;
            
            item.TurnoOtorgadoIdProfesional = TurnoOtorgadoIdProfesional;
            
            item.TurnoOtorgadoIdEspecialidad = TurnoOtorgadoIdEspecialidad;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDestinatariosInterconsulta,int IdInterconsulta,int IdProfesional,int IdEspecialidad,int? IdZona,int? IdEfector,string Estado,DateTime? TurnoOtorgadoFecha,string TurnoOtorgadoHora,int? TurnoOtorgadoIdProfesional,int? TurnoOtorgadoIdEspecialidad)
	    {
		    IcoDestinatarioInterconsultum item = new IcoDestinatarioInterconsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDestinatariosInterconsulta = IdDestinatariosInterconsulta;
				
			item.IdInterconsulta = IdInterconsulta;
				
			item.IdProfesional = IdProfesional;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.IdZona = IdZona;
				
			item.IdEfector = IdEfector;
				
			item.Estado = Estado;
				
			item.TurnoOtorgadoFecha = TurnoOtorgadoFecha;
				
			item.TurnoOtorgadoHora = TurnoOtorgadoHora;
				
			item.TurnoOtorgadoIdProfesional = TurnoOtorgadoIdProfesional;
				
			item.TurnoOtorgadoIdEspecialidad = TurnoOtorgadoIdEspecialidad;
				
	        item.Save(UserName);
	    }
    }
}
