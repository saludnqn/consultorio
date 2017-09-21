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
    /// Controller class for TAB_Control
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TabControlController
    {
        // Preload our schema..
        TabControl thisSchemaLoad = new TabControl();
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
        public TabControlCollection FetchAll()
        {
            TabControlCollection coll = new TabControlCollection();
            Query qry = new Query(TabControl.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TabControlCollection FetchByID(object IdControl)
        {
            TabControlCollection coll = new TabControlCollection().Where("idControl", IdControl).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TabControlCollection FetchByQuery(Query qry)
        {
            TabControlCollection coll = new TabControlCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdControl)
        {
            return (TabControl.Delete(IdControl) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdControl)
        {
            return (TabControl.Destroy(IdControl) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,DateTime FechaRegistro,string Sexo,int Edad,string OtrosTelefonos,DateTime FechaD,DateTime FechaPrescripcion,string Observaciones,int IdProfesional,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    TabControl item = new TabControl();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.FechaRegistro = FechaRegistro;
            
            item.Sexo = Sexo;
            
            item.Edad = Edad;
            
            item.OtrosTelefonos = OtrosTelefonos;
            
            item.FechaD = FechaD;
            
            item.FechaPrescripcion = FechaPrescripcion;
            
            item.Observaciones = Observaciones;
            
            item.IdProfesional = IdProfesional;
            
            item.Activo = Activo;
            
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
	    public void Update(int IdControl,int IdEfector,int IdPaciente,DateTime FechaRegistro,string Sexo,int Edad,string OtrosTelefonos,DateTime FechaD,DateTime FechaPrescripcion,string Observaciones,int IdProfesional,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    TabControl item = new TabControl();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdControl = IdControl;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.FechaRegistro = FechaRegistro;
				
			item.Sexo = Sexo;
				
			item.Edad = Edad;
				
			item.OtrosTelefonos = OtrosTelefonos;
				
			item.FechaD = FechaD;
				
			item.FechaPrescripcion = FechaPrescripcion;
				
			item.Observaciones = Observaciones;
				
			item.IdProfesional = IdProfesional;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
