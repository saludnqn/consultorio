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
    /// Controller class for PN_prestacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPrestacionController
    {
        // Preload our schema..
        PnPrestacion thisSchemaLoad = new PnPrestacion();
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
        public PnPrestacionCollection FetchAll()
        {
            PnPrestacionCollection coll = new PnPrestacionCollection();
            Query qry = new Query(PnPrestacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPrestacionCollection FetchByID(object IdPrestacion)
        {
            PnPrestacionCollection coll = new PnPrestacionCollection().Where("id_prestacion", IdPrestacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPrestacionCollection FetchByQuery(Query qry)
        {
            PnPrestacionCollection coll = new PnPrestacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPrestacion)
        {
            return (PnPrestacion.Delete(IdPrestacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPrestacion)
        {
            return (PnPrestacion.Destroy(IdPrestacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdComprobante,int IdNomenclador,int? Cantidad,decimal? PrecioPrestacion,int? IdAnexo,decimal? Peso,string TensionArterial,string Diagnostico,string Edad,string Sexo,string CodigoComp,DateTime? FechaNacimiento,DateTime? FechaPrestacion,int? Anio,int? Mes,int? Dia,int? Talla,string PerimetroCefalico,int? SemanasGestacion)
	    {
		    PnPrestacion item = new PnPrestacion();
		    
            item.IdComprobante = IdComprobante;
            
            item.IdNomenclador = IdNomenclador;
            
            item.Cantidad = Cantidad;
            
            item.PrecioPrestacion = PrecioPrestacion;
            
            item.IdAnexo = IdAnexo;
            
            item.Peso = Peso;
            
            item.TensionArterial = TensionArterial;
            
            item.Diagnostico = Diagnostico;
            
            item.Edad = Edad;
            
            item.Sexo = Sexo;
            
            item.CodigoComp = CodigoComp;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.FechaPrestacion = FechaPrestacion;
            
            item.Anio = Anio;
            
            item.Mes = Mes;
            
            item.Dia = Dia;
            
            item.Talla = Talla;
            
            item.PerimetroCefalico = PerimetroCefalico;
            
            item.SemanasGestacion = SemanasGestacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPrestacion,int IdComprobante,int IdNomenclador,int? Cantidad,decimal? PrecioPrestacion,int? IdAnexo,decimal? Peso,string TensionArterial,string Diagnostico,string Edad,string Sexo,string CodigoComp,DateTime? FechaNacimiento,DateTime? FechaPrestacion,int? Anio,int? Mes,int? Dia,int? Talla,string PerimetroCefalico,int? SemanasGestacion)
	    {
		    PnPrestacion item = new PnPrestacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPrestacion = IdPrestacion;
				
			item.IdComprobante = IdComprobante;
				
			item.IdNomenclador = IdNomenclador;
				
			item.Cantidad = Cantidad;
				
			item.PrecioPrestacion = PrecioPrestacion;
				
			item.IdAnexo = IdAnexo;
				
			item.Peso = Peso;
				
			item.TensionArterial = TensionArterial;
				
			item.Diagnostico = Diagnostico;
				
			item.Edad = Edad;
				
			item.Sexo = Sexo;
				
			item.CodigoComp = CodigoComp;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.FechaPrestacion = FechaPrestacion;
				
			item.Anio = Anio;
				
			item.Mes = Mes;
				
			item.Dia = Dia;
				
			item.Talla = Talla;
				
			item.PerimetroCefalico = PerimetroCefalico;
				
			item.SemanasGestacion = SemanasGestacion;
				
	        item.Save(UserName);
	    }
    }
}
