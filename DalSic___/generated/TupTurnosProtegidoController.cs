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
    /// Controller class for TUP_TurnosProtegidos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TupTurnosProtegidoController
    {
        // Preload our schema..
        TupTurnosProtegido thisSchemaLoad = new TupTurnosProtegido();
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
        public TupTurnosProtegidoCollection FetchAll()
        {
            TupTurnosProtegidoCollection coll = new TupTurnosProtegidoCollection();
            Query qry = new Query(TupTurnosProtegido.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TupTurnosProtegidoCollection FetchByID(object IdTurnoSubsecretaria)
        {
            TupTurnosProtegidoCollection coll = new TupTurnosProtegidoCollection().Where("idTurnoSubsecretaria", IdTurnoSubsecretaria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TupTurnosProtegidoCollection FetchByQuery(Query qry)
        {
            TupTurnosProtegidoCollection coll = new TupTurnosProtegidoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTurnoSubsecretaria)
        {
            return (TupTurnosProtegido.Delete(IdTurnoSubsecretaria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTurnoSubsecretaria)
        {
            return (TupTurnosProtegido.Destroy(IdTurnoSubsecretaria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdInterconsulta,int IdTurnoEfector,int IdEfector,int IdExternoEspecialidad,string NombreEspecialidad,int IdExternoProfesional,string NombreProfesional,DateTime FechaTurno,DateTime HoraTurno,int IdUsuarioCarga)
	    {
		    TupTurnosProtegido item = new TupTurnosProtegido();
		    
            item.IdInterconsulta = IdInterconsulta;
            
            item.IdTurnoEfector = IdTurnoEfector;
            
            item.IdEfector = IdEfector;
            
            item.IdExternoEspecialidad = IdExternoEspecialidad;
            
            item.NombreEspecialidad = NombreEspecialidad;
            
            item.IdExternoProfesional = IdExternoProfesional;
            
            item.NombreProfesional = NombreProfesional;
            
            item.FechaTurno = FechaTurno;
            
            item.HoraTurno = HoraTurno;
            
            item.IdUsuarioCarga = IdUsuarioCarga;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTurnoSubsecretaria,int IdInterconsulta,int IdTurnoEfector,int IdEfector,int IdExternoEspecialidad,string NombreEspecialidad,int IdExternoProfesional,string NombreProfesional,DateTime FechaTurno,DateTime HoraTurno,int IdUsuarioCarga)
	    {
		    TupTurnosProtegido item = new TupTurnosProtegido();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTurnoSubsecretaria = IdTurnoSubsecretaria;
				
			item.IdInterconsulta = IdInterconsulta;
				
			item.IdTurnoEfector = IdTurnoEfector;
				
			item.IdEfector = IdEfector;
				
			item.IdExternoEspecialidad = IdExternoEspecialidad;
				
			item.NombreEspecialidad = NombreEspecialidad;
				
			item.IdExternoProfesional = IdExternoProfesional;
				
			item.NombreProfesional = NombreProfesional;
				
			item.FechaTurno = FechaTurno;
				
			item.HoraTurno = HoraTurno;
				
			item.IdUsuarioCarga = IdUsuarioCarga;
				
	        item.Save(UserName);
	    }
    }
}
