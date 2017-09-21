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
    /// Controller class for APR_ControlNiñoSanoEnfermeria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprControlNiñoSanoEnfermeriumController
    {
        // Preload our schema..
        AprControlNiñoSanoEnfermerium thisSchemaLoad = new AprControlNiñoSanoEnfermerium();
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
        public AprControlNiñoSanoEnfermeriumCollection FetchAll()
        {
            AprControlNiñoSanoEnfermeriumCollection coll = new AprControlNiñoSanoEnfermeriumCollection();
            Query qry = new Query(AprControlNiñoSanoEnfermerium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoEnfermeriumCollection FetchByID(object IdControlNiñoSanoEnfermeria)
        {
            AprControlNiñoSanoEnfermeriumCollection coll = new AprControlNiñoSanoEnfermeriumCollection().Where("idControlNiñoSanoEnfermeria", IdControlNiñoSanoEnfermeria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoEnfermeriumCollection FetchByQuery(Query qry)
        {
            AprControlNiñoSanoEnfermeriumCollection coll = new AprControlNiñoSanoEnfermeriumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdControlNiñoSanoEnfermeria)
        {
            return (AprControlNiñoSanoEnfermerium.Delete(IdControlNiñoSanoEnfermeria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdControlNiñoSanoEnfermeria)
        {
            return (AprControlNiñoSanoEnfermerium.Destroy(IdControlNiñoSanoEnfermeria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdControlNiñoSano,decimal Peso,decimal Talla,double PerimetroCefalico,int? IdEstadoNutricional,int? IdTallaEdad,int? IdPaciente,int? IdProfesional,string Observaciones,string Ta,DateTime? FechaControl,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,decimal? Icm)
	    {
		    AprControlNiñoSanoEnfermerium item = new AprControlNiñoSanoEnfermerium();
		    
            item.IdControlNiñoSano = IdControlNiñoSano;
            
            item.Peso = Peso;
            
            item.Talla = Talla;
            
            item.PerimetroCefalico = PerimetroCefalico;
            
            item.IdEstadoNutricional = IdEstadoNutricional;
            
            item.IdTallaEdad = IdTallaEdad;
            
            item.IdPaciente = IdPaciente;
            
            item.IdProfesional = IdProfesional;
            
            item.Observaciones = Observaciones;
            
            item.Ta = Ta;
            
            item.FechaControl = FechaControl;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.Icm = Icm;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdControlNiñoSanoEnfermeria,int IdControlNiñoSano,decimal Peso,decimal Talla,double PerimetroCefalico,int? IdEstadoNutricional,int? IdTallaEdad,int? IdPaciente,int? IdProfesional,string Observaciones,string Ta,DateTime? FechaControl,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,decimal? Icm)
	    {
		    AprControlNiñoSanoEnfermerium item = new AprControlNiñoSanoEnfermerium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdControlNiñoSanoEnfermeria = IdControlNiñoSanoEnfermeria;
				
			item.IdControlNiñoSano = IdControlNiñoSano;
				
			item.Peso = Peso;
				
			item.Talla = Talla;
				
			item.PerimetroCefalico = PerimetroCefalico;
				
			item.IdEstadoNutricional = IdEstadoNutricional;
				
			item.IdTallaEdad = IdTallaEdad;
				
			item.IdPaciente = IdPaciente;
				
			item.IdProfesional = IdProfesional;
				
			item.Observaciones = Observaciones;
				
			item.Ta = Ta;
				
			item.FechaControl = FechaControl;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.Icm = Icm;
				
	        item.Save(UserName);
	    }
    }
}
