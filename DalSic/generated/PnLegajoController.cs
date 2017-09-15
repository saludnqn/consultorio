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
    /// Controller class for PN_legajos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLegajoController
    {
        // Preload our schema..
        PnLegajo thisSchemaLoad = new PnLegajo();
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
        public PnLegajoCollection FetchAll()
        {
            PnLegajoCollection coll = new PnLegajoCollection();
            Query qry = new Query(PnLegajo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLegajoCollection FetchByID(object IdLegajo)
        {
            PnLegajoCollection coll = new PnLegajoCollection().Where("id_legajo", IdLegajo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLegajoCollection FetchByQuery(Query qry)
        {
            PnLegajoCollection coll = new PnLegajoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLegajo)
        {
            return (PnLegajo.Delete(IdLegajo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLegajo)
        {
            return (PnLegajo.Destroy(IdLegajo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Apellido,string Nombre,string Dni,DateTime? FechaNacimiento,string LugarNacimiento,string Domicilio,string TelCelular,string TelParticular,string Localidad,string Provincia,string EmNombre,string EmTelefono,string EmDireccion,string EmRelacion,string Comentarios,int? IdUsuario,int? IdEvaluador,DateTime? FechaIngreso,string Cuil,string CajaAhorroPesosNro,int? IdTarea,int? IdCalificacion,int? IdAfjp,int? Idbanco,short? TipoLiq,short? TipoJub,DateTime? FechaBaja,short? Activo,string HrEntra,string HrSale,short? Ubicacion)
	    {
		    PnLegajo item = new PnLegajo();
		    
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.Dni = Dni;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.LugarNacimiento = LugarNacimiento;
            
            item.Domicilio = Domicilio;
            
            item.TelCelular = TelCelular;
            
            item.TelParticular = TelParticular;
            
            item.Localidad = Localidad;
            
            item.Provincia = Provincia;
            
            item.EmNombre = EmNombre;
            
            item.EmTelefono = EmTelefono;
            
            item.EmDireccion = EmDireccion;
            
            item.EmRelacion = EmRelacion;
            
            item.Comentarios = Comentarios;
            
            item.IdUsuario = IdUsuario;
            
            item.IdEvaluador = IdEvaluador;
            
            item.FechaIngreso = FechaIngreso;
            
            item.Cuil = Cuil;
            
            item.CajaAhorroPesosNro = CajaAhorroPesosNro;
            
            item.IdTarea = IdTarea;
            
            item.IdCalificacion = IdCalificacion;
            
            item.IdAfjp = IdAfjp;
            
            item.Idbanco = Idbanco;
            
            item.TipoLiq = TipoLiq;
            
            item.TipoJub = TipoJub;
            
            item.FechaBaja = FechaBaja;
            
            item.Activo = Activo;
            
            item.HrEntra = HrEntra;
            
            item.HrSale = HrSale;
            
            item.Ubicacion = Ubicacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLegajo,string Apellido,string Nombre,string Dni,DateTime? FechaNacimiento,string LugarNacimiento,string Domicilio,string TelCelular,string TelParticular,string Localidad,string Provincia,string EmNombre,string EmTelefono,string EmDireccion,string EmRelacion,string Comentarios,int? IdUsuario,int? IdEvaluador,DateTime? FechaIngreso,string Cuil,string CajaAhorroPesosNro,int? IdTarea,int? IdCalificacion,int? IdAfjp,int? Idbanco,short? TipoLiq,short? TipoJub,DateTime? FechaBaja,short? Activo,string HrEntra,string HrSale,short? Ubicacion)
	    {
		    PnLegajo item = new PnLegajo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLegajo = IdLegajo;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.Dni = Dni;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.LugarNacimiento = LugarNacimiento;
				
			item.Domicilio = Domicilio;
				
			item.TelCelular = TelCelular;
				
			item.TelParticular = TelParticular;
				
			item.Localidad = Localidad;
				
			item.Provincia = Provincia;
				
			item.EmNombre = EmNombre;
				
			item.EmTelefono = EmTelefono;
				
			item.EmDireccion = EmDireccion;
				
			item.EmRelacion = EmRelacion;
				
			item.Comentarios = Comentarios;
				
			item.IdUsuario = IdUsuario;
				
			item.IdEvaluador = IdEvaluador;
				
			item.FechaIngreso = FechaIngreso;
				
			item.Cuil = Cuil;
				
			item.CajaAhorroPesosNro = CajaAhorroPesosNro;
				
			item.IdTarea = IdTarea;
				
			item.IdCalificacion = IdCalificacion;
				
			item.IdAfjp = IdAfjp;
				
			item.Idbanco = Idbanco;
				
			item.TipoLiq = TipoLiq;
				
			item.TipoJub = TipoJub;
				
			item.FechaBaja = FechaBaja;
				
			item.Activo = Activo;
				
			item.HrEntra = HrEntra;
				
			item.HrSale = HrSale;
				
			item.Ubicacion = Ubicacion;
				
	        item.Save(UserName);
	    }
    }
}
