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
    /// Controller class for ICO_DialogoInterconsulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IcoDialogoInterconsultumController
    {
        // Preload our schema..
        IcoDialogoInterconsultum thisSchemaLoad = new IcoDialogoInterconsultum();
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
        public IcoDialogoInterconsultumCollection FetchAll()
        {
            IcoDialogoInterconsultumCollection coll = new IcoDialogoInterconsultumCollection();
            Query qry = new Query(IcoDialogoInterconsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoDialogoInterconsultumCollection FetchByID(object IdDialogoInterconsulta)
        {
            IcoDialogoInterconsultumCollection coll = new IcoDialogoInterconsultumCollection().Where("idDialogoInterconsulta", IdDialogoInterconsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IcoDialogoInterconsultumCollection FetchByQuery(Query qry)
        {
            IcoDialogoInterconsultumCollection coll = new IcoDialogoInterconsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDialogoInterconsulta)
        {
            return (IcoDialogoInterconsultum.Delete(IdDialogoInterconsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDialogoInterconsulta)
        {
            return (IcoDialogoInterconsultum.Destroy(IdDialogoInterconsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdInterconsulta,DateTime Fecha,int IdProfesional,int IdEspecialidad,string Descripcion,string Respuesta,int? IdZona,int? IdEfector,int? IdUsuarioCarga)
	    {
		    IcoDialogoInterconsultum item = new IcoDialogoInterconsultum();
		    
            item.IdInterconsulta = IdInterconsulta;
            
            item.Fecha = Fecha;
            
            item.IdProfesional = IdProfesional;
            
            item.IdEspecialidad = IdEspecialidad;
            
            item.Descripcion = Descripcion;
            
            item.Respuesta = Respuesta;
            
            item.IdZona = IdZona;
            
            item.IdEfector = IdEfector;
            
            item.IdUsuarioCarga = IdUsuarioCarga;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDialogoInterconsulta,int IdInterconsulta,DateTime Fecha,int IdProfesional,int IdEspecialidad,string Descripcion,string Respuesta,int? IdZona,int? IdEfector,int? IdUsuarioCarga)
	    {
		    IcoDialogoInterconsultum item = new IcoDialogoInterconsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDialogoInterconsulta = IdDialogoInterconsulta;
				
			item.IdInterconsulta = IdInterconsulta;
				
			item.Fecha = Fecha;
				
			item.IdProfesional = IdProfesional;
				
			item.IdEspecialidad = IdEspecialidad;
				
			item.Descripcion = Descripcion;
				
			item.Respuesta = Respuesta;
				
			item.IdZona = IdZona;
				
			item.IdEfector = IdEfector;
				
			item.IdUsuarioCarga = IdUsuarioCarga;
				
	        item.Save(UserName);
	    }
    }
}
