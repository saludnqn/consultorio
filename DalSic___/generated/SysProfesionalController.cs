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
    /// Controller class for Sys_Profesional
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysProfesionalController
    {
        // Preload our schema..
        SysProfesional thisSchemaLoad = new SysProfesional();
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
        public SysProfesionalCollection FetchAll()
        {
            SysProfesionalCollection coll = new SysProfesionalCollection();
            Query qry = new Query(SysProfesional.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysProfesionalCollection FetchByID(object IdProfesional)
        {
            SysProfesionalCollection coll = new SysProfesionalCollection().Where("idProfesional", IdProfesional).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysProfesionalCollection FetchByQuery(Query qry)
        {
            SysProfesionalCollection coll = new SysProfesionalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProfesional)
        {
            return (SysProfesional.Delete(IdProfesional) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProfesional)
        {
            return (SysProfesional.Destroy(IdProfesional) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,string Apellido,string Nombre,int IdTipoDocumento,int NumeroDocumento,string Matricula,string Legajo,string CodigoSISA,bool Activo,string NombreCompleto,string ApellidoyNombre,int IdTipoProfesional,int IdUsuario,DateTime FechaModificacion,string Mail,string Telefono,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SysProfesional item = new SysProfesional();
		    
            item.IdEfector = IdEfector;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.IdTipoDocumento = IdTipoDocumento;
            
            item.NumeroDocumento = NumeroDocumento;
            
            item.Matricula = Matricula;
            
            item.Legajo = Legajo;
            
            item.CodigoSISA = CodigoSISA;
            
            item.Activo = Activo;
            
            item.NombreCompleto = NombreCompleto;
            
            item.ApellidoyNombre = ApellidoyNombre;
            
            item.IdTipoProfesional = IdTipoProfesional;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaModificacion = FechaModificacion;
            
            item.Mail = Mail;
            
            item.Telefono = Telefono;
            
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
	    public void Update(int IdProfesional,int IdEfector,string Apellido,string Nombre,int IdTipoDocumento,int NumeroDocumento,string Matricula,string Legajo,string CodigoSISA,bool Activo,string NombreCompleto,string ApellidoyNombre,int IdTipoProfesional,int IdUsuario,DateTime FechaModificacion,string Mail,string Telefono,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SysProfesional item = new SysProfesional();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProfesional = IdProfesional;
				
			item.IdEfector = IdEfector;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.IdTipoDocumento = IdTipoDocumento;
				
			item.NumeroDocumento = NumeroDocumento;
				
			item.Matricula = Matricula;
				
			item.Legajo = Legajo;
				
			item.CodigoSISA = CodigoSISA;
				
			item.Activo = Activo;
				
			item.NombreCompleto = NombreCompleto;
				
			item.ApellidoyNombre = ApellidoyNombre;
				
			item.IdTipoProfesional = IdTipoProfesional;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaModificacion = FechaModificacion;
				
			item.Mail = Mail;
				
			item.Telefono = Telefono;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
