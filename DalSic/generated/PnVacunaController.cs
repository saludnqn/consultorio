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
    /// Controller class for PN_vacunas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnVacunaController
    {
        // Preload our schema..
        PnVacuna thisSchemaLoad = new PnVacuna();
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
        public PnVacunaCollection FetchAll()
        {
            PnVacunaCollection coll = new PnVacunaCollection();
            Query qry = new Query(PnVacuna.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnVacunaCollection FetchByID(object IdVacunas)
        {
            PnVacunaCollection coll = new PnVacunaCollection().Where("id_vacunas", IdVacunas).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnVacunaCollection FetchByQuery(Query qry)
        {
            PnVacunaCollection coll = new PnVacunaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdVacunas)
        {
            return (PnVacuna.Delete(IdVacunas) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdVacunas)
        {
            return (PnVacuna.Destroy(IdVacunas) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdVacApli,int IdDosisApli,string Apellido,string Nombre,string Dni,string Sexo,DateTime? FechaNac,string Domicilio,DateTime? FechaVac,string NomResp,string Comentario,string Cuie)
	    {
		    PnVacuna item = new PnVacuna();
		    
            item.IdVacApli = IdVacApli;
            
            item.IdDosisApli = IdDosisApli;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.Dni = Dni;
            
            item.Sexo = Sexo;
            
            item.FechaNac = FechaNac;
            
            item.Domicilio = Domicilio;
            
            item.FechaVac = FechaVac;
            
            item.NomResp = NomResp;
            
            item.Comentario = Comentario;
            
            item.Cuie = Cuie;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdVacunas,int IdVacApli,int IdDosisApli,string Apellido,string Nombre,string Dni,string Sexo,DateTime? FechaNac,string Domicilio,DateTime? FechaVac,string NomResp,string Comentario,string Cuie)
	    {
		    PnVacuna item = new PnVacuna();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdVacunas = IdVacunas;
				
			item.IdVacApli = IdVacApli;
				
			item.IdDosisApli = IdDosisApli;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.Dni = Dni;
				
			item.Sexo = Sexo;
				
			item.FechaNac = FechaNac;
				
			item.Domicilio = Domicilio;
				
			item.FechaVac = FechaVac;
				
			item.NomResp = NomResp;
				
			item.Comentario = Comentario;
				
			item.Cuie = Cuie;
				
	        item.Save(UserName);
	    }
    }
}
