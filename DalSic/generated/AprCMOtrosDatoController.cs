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
    /// Controller class for APR_CMOtrosDatos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprCMOtrosDatoController
    {
        // Preload our schema..
        AprCMOtrosDato thisSchemaLoad = new AprCMOtrosDato();
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
        public AprCMOtrosDatoCollection FetchAll()
        {
            AprCMOtrosDatoCollection coll = new AprCMOtrosDatoCollection();
            Query qry = new Query(AprCMOtrosDato.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCMOtrosDatoCollection FetchByID(object IdOtrosDatosPaternos)
        {
            AprCMOtrosDatoCollection coll = new AprCMOtrosDatoCollection().Where("idOtrosDatosPaternos", IdOtrosDatosPaternos).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCMOtrosDatoCollection FetchByQuery(Query qry)
        {
            AprCMOtrosDatoCollection coll = new AprCMOtrosDatoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdOtrosDatosPaternos)
        {
            return (AprCMOtrosDato.Delete(IdOtrosDatosPaternos) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdOtrosDatosPaternos)
        {
            return (AprCMOtrosDato.Destroy(IdOtrosDatosPaternos) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(bool? Trabaja,int? CantidadHoras,bool? AsistenciaEconomica,int? IdControlNiñoSano,int? IdPaciente)
	    {
		    AprCMOtrosDato item = new AprCMOtrosDato();
		    
            item.Trabaja = Trabaja;
            
            item.CantidadHoras = CantidadHoras;
            
            item.AsistenciaEconomica = AsistenciaEconomica;
            
            item.IdControlNiñoSano = IdControlNiñoSano;
            
            item.IdPaciente = IdPaciente;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdOtrosDatosPaternos,bool? Trabaja,int? CantidadHoras,bool? AsistenciaEconomica,int? IdControlNiñoSano,int? IdPaciente)
	    {
		    AprCMOtrosDato item = new AprCMOtrosDato();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdOtrosDatosPaternos = IdOtrosDatosPaternos;
				
			item.Trabaja = Trabaja;
				
			item.CantidadHoras = CantidadHoras;
				
			item.AsistenciaEconomica = AsistenciaEconomica;
				
			item.IdControlNiñoSano = IdControlNiñoSano;
				
			item.IdPaciente = IdPaciente;
				
	        item.Save(UserName);
	    }
    }
}
