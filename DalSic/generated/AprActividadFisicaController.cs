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
    /// Controller class for APR_ActividadFisica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprActividadFisicaController
    {
        // Preload our schema..
        AprActividadFisica thisSchemaLoad = new AprActividadFisica();
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
        public AprActividadFisicaCollection FetchAll()
        {
            AprActividadFisicaCollection coll = new AprActividadFisicaCollection();
            Query qry = new Query(AprActividadFisica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActividadFisicaCollection FetchByID(object IdActividadFisica)
        {
            AprActividadFisicaCollection coll = new AprActividadFisicaCollection().Where("idActividadFisica", IdActividadFisica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprActividadFisicaCollection FetchByQuery(Query qry)
        {
            AprActividadFisicaCollection coll = new AprActividadFisicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdActividadFisica)
        {
            return (AprActividadFisica.Delete(IdActividadFisica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdActividadFisica)
        {
            return (AprActividadFisica.Destroy(IdActividadFisica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,DateTime FechaControl,int Edad,int IdEfector,string MedicoCabecera,decimal Peso,decimal Talla,decimal Imc,int RiesgoCardiovascular,string Diagnosticos,string Aptitud,int IdProfesional,string Observacion,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    AprActividadFisica item = new AprActividadFisica();
		    
            item.IdPaciente = IdPaciente;
            
            item.FechaControl = FechaControl;
            
            item.Edad = Edad;
            
            item.IdEfector = IdEfector;
            
            item.MedicoCabecera = MedicoCabecera;
            
            item.Peso = Peso;
            
            item.Talla = Talla;
            
            item.Imc = Imc;
            
            item.RiesgoCardiovascular = RiesgoCardiovascular;
            
            item.Diagnosticos = Diagnosticos;
            
            item.Aptitud = Aptitud;
            
            item.IdProfesional = IdProfesional;
            
            item.Observacion = Observacion;
            
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
	    public void Update(int IdActividadFisica,int IdPaciente,DateTime FechaControl,int Edad,int IdEfector,string MedicoCabecera,decimal Peso,decimal Talla,decimal Imc,int RiesgoCardiovascular,string Diagnosticos,string Aptitud,int IdProfesional,string Observacion,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    AprActividadFisica item = new AprActividadFisica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdActividadFisica = IdActividadFisica;
				
			item.IdPaciente = IdPaciente;
				
			item.FechaControl = FechaControl;
				
			item.Edad = Edad;
				
			item.IdEfector = IdEfector;
				
			item.MedicoCabecera = MedicoCabecera;
				
			item.Peso = Peso;
				
			item.Talla = Talla;
				
			item.Imc = Imc;
				
			item.RiesgoCardiovascular = RiesgoCardiovascular;
				
			item.Diagnosticos = Diagnosticos;
				
			item.Aptitud = Aptitud;
				
			item.IdProfesional = IdProfesional;
				
			item.Observacion = Observacion;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
