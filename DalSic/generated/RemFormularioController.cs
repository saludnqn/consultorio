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
    /// Controller class for Rem_Formulario
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemFormularioController
    {
        // Preload our schema..
        RemFormulario thisSchemaLoad = new RemFormulario();
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
        public RemFormularioCollection FetchAll()
        {
            RemFormularioCollection coll = new RemFormularioCollection();
            Query qry = new Query(RemFormulario.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemFormularioCollection FetchByID(object IdFormulario)
        {
            RemFormularioCollection coll = new RemFormularioCollection().Where("idFormulario", IdFormulario).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemFormularioCollection FetchByQuery(Query qry)
        {
            RemFormularioCollection coll = new RemFormularioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFormulario)
        {
            return (RemFormulario.Delete(IdFormulario) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFormulario)
        {
            return (RemFormulario.Destroy(IdFormulario) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,int IdObraSocial,int NumeroFormulario,DateTime FechaEmpadronamiento,int? IdAgente,int IdMunicipio,int Sexo,int Edad,int Hta2,int Hta3,int Colesterol4,int Colesterol5,int Dtm26,int Dtm27,int Ecv8,int Tabaco9,int Sumatoria,bool PoseeFirma,int CreatedBy,DateTime CreatedOn,int ModifiedBy,DateTime ModifiedOn,string Centros,int VacunasCompletas,int Pap,int? IdProfesional)
	    {
		    RemFormulario item = new RemFormulario();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.IdObraSocial = IdObraSocial;
            
            item.NumeroFormulario = NumeroFormulario;
            
            item.FechaEmpadronamiento = FechaEmpadronamiento;
            
            item.IdAgente = IdAgente;
            
            item.IdMunicipio = IdMunicipio;
            
            item.Sexo = Sexo;
            
            item.Edad = Edad;
            
            item.Hta2 = Hta2;
            
            item.Hta3 = Hta3;
            
            item.Colesterol4 = Colesterol4;
            
            item.Colesterol5 = Colesterol5;
            
            item.Dtm26 = Dtm26;
            
            item.Dtm27 = Dtm27;
            
            item.Ecv8 = Ecv8;
            
            item.Tabaco9 = Tabaco9;
            
            item.Sumatoria = Sumatoria;
            
            item.PoseeFirma = PoseeFirma;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.Centros = Centros;
            
            item.VacunasCompletas = VacunasCompletas;
            
            item.Pap = Pap;
            
            item.IdProfesional = IdProfesional;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFormulario,int IdEfector,int IdPaciente,int IdObraSocial,int NumeroFormulario,DateTime FechaEmpadronamiento,int? IdAgente,int IdMunicipio,int Sexo,int Edad,int Hta2,int Hta3,int Colesterol4,int Colesterol5,int Dtm26,int Dtm27,int Ecv8,int Tabaco9,int Sumatoria,bool PoseeFirma,int CreatedBy,DateTime CreatedOn,int ModifiedBy,DateTime ModifiedOn,string Centros,int VacunasCompletas,int Pap,int? IdProfesional)
	    {
		    RemFormulario item = new RemFormulario();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFormulario = IdFormulario;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.IdObraSocial = IdObraSocial;
				
			item.NumeroFormulario = NumeroFormulario;
				
			item.FechaEmpadronamiento = FechaEmpadronamiento;
				
			item.IdAgente = IdAgente;
				
			item.IdMunicipio = IdMunicipio;
				
			item.Sexo = Sexo;
				
			item.Edad = Edad;
				
			item.Hta2 = Hta2;
				
			item.Hta3 = Hta3;
				
			item.Colesterol4 = Colesterol4;
				
			item.Colesterol5 = Colesterol5;
				
			item.Dtm26 = Dtm26;
				
			item.Dtm27 = Dtm27;
				
			item.Ecv8 = Ecv8;
				
			item.Tabaco9 = Tabaco9;
				
			item.Sumatoria = Sumatoria;
				
			item.PoseeFirma = PoseeFirma;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.Centros = Centros;
				
			item.VacunasCompletas = VacunasCompletas;
				
			item.Pap = Pap;
				
			item.IdProfesional = IdProfesional;
				
	        item.Save(UserName);
	    }
    }
}
