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
    /// Controller class for Sys_Parentesco
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysParentescoController
    {
        // Preload our schema..
        SysParentesco thisSchemaLoad = new SysParentesco();
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
        public SysParentescoCollection FetchAll()
        {
            SysParentescoCollection coll = new SysParentescoCollection();
            Query qry = new Query(SysParentesco.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysParentescoCollection FetchByID(object IdParentesco)
        {
            SysParentescoCollection coll = new SysParentescoCollection().Where("idParentesco", IdParentesco).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysParentescoCollection FetchByQuery(Query qry)
        {
            SysParentescoCollection coll = new SysParentescoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdParentesco)
        {
            return (SysParentesco.Delete(IdParentesco) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdParentesco)
        {
            return (SysParentesco.Destroy(IdParentesco) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Apellido,int IdTipoDocumento,int NumeroDocumento,DateTime FechaNacimiento,int IdProvincia,int IdPais,int IdSituacionLaboral,int IdNivelInstruccion,int IdProfesion,int IdPaciente,string TipoParentesco,int IdUsuario,DateTime FechaModificacion,int IdAntecedente)
	    {
		    SysParentesco item = new SysParentesco();
		    
            item.Nombre = Nombre;
            
            item.Apellido = Apellido;
            
            item.IdTipoDocumento = IdTipoDocumento;
            
            item.NumeroDocumento = NumeroDocumento;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.IdProvincia = IdProvincia;
            
            item.IdPais = IdPais;
            
            item.IdSituacionLaboral = IdSituacionLaboral;
            
            item.IdNivelInstruccion = IdNivelInstruccion;
            
            item.IdProfesion = IdProfesion;
            
            item.IdPaciente = IdPaciente;
            
            item.TipoParentesco = TipoParentesco;
            
            item.IdUsuario = IdUsuario;
            
            item.FechaModificacion = FechaModificacion;
            
            item.IdAntecedente = IdAntecedente;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdParentesco,string Nombre,string Apellido,int IdTipoDocumento,int NumeroDocumento,DateTime FechaNacimiento,int IdProvincia,int IdPais,int IdSituacionLaboral,int IdNivelInstruccion,int IdProfesion,int IdPaciente,string TipoParentesco,int IdUsuario,DateTime FechaModificacion,int IdAntecedente)
	    {
		    SysParentesco item = new SysParentesco();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdParentesco = IdParentesco;
				
			item.Nombre = Nombre;
				
			item.Apellido = Apellido;
				
			item.IdTipoDocumento = IdTipoDocumento;
				
			item.NumeroDocumento = NumeroDocumento;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.IdProvincia = IdProvincia;
				
			item.IdPais = IdPais;
				
			item.IdSituacionLaboral = IdSituacionLaboral;
				
			item.IdNivelInstruccion = IdNivelInstruccion;
				
			item.IdProfesion = IdProfesion;
				
			item.IdPaciente = IdPaciente;
				
			item.TipoParentesco = TipoParentesco;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaModificacion = FechaModificacion;
				
			item.IdAntecedente = IdAntecedente;
				
	        item.Save(UserName);
	    }
    }
}
