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
    /// Controller class for CON_ConsultaDiagnostico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConConsultaDiagnosticoController
    {
        // Preload our schema..
        ConConsultaDiagnostico thisSchemaLoad = new ConConsultaDiagnostico();
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
        public ConConsultaDiagnosticoCollection FetchAll()
        {
            ConConsultaDiagnosticoCollection coll = new ConConsultaDiagnosticoCollection();
            Query qry = new Query(ConConsultaDiagnostico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultaDiagnosticoCollection FetchByID(object IdConsultaDiagnostico)
        {
            ConConsultaDiagnosticoCollection coll = new ConConsultaDiagnosticoCollection().Where("idConsultaDiagnostico", IdConsultaDiagnostico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultaDiagnosticoCollection FetchByQuery(Query qry)
        {
            ConConsultaDiagnosticoCollection coll = new ConConsultaDiagnosticoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConsultaDiagnostico)
        {
            return (ConConsultaDiagnostico.Delete(IdConsultaDiagnostico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConsultaDiagnostico)
        {
            return (ConConsultaDiagnostico.Destroy(IdConsultaDiagnostico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEfector,int? IdConsulta,bool? Principal,int? CODCIE10,int PrimerConsulta,int? IdNivelDeAbordaje,int? IdTipoPrestacionSaludMental,int? IdTiempoInsumido,int? IdDemanda,string RecursoHumano)
	    {
		    ConConsultaDiagnostico item = new ConConsultaDiagnostico();
		    
            item.IdEfector = IdEfector;
            
            item.IdConsulta = IdConsulta;
            
            item.Principal = Principal;
            
            item.CODCIE10 = CODCIE10;
            
            item.PrimerConsulta = PrimerConsulta;
            
            item.IdNivelDeAbordaje = IdNivelDeAbordaje;
            
            item.IdTipoPrestacionSaludMental = IdTipoPrestacionSaludMental;
            
            item.IdTiempoInsumido = IdTiempoInsumido;
            
            item.IdDemanda = IdDemanda;
            
            item.RecursoHumano = RecursoHumano;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConsultaDiagnostico,int? IdEfector,int? IdConsulta,bool? Principal,int? CODCIE10,int PrimerConsulta,int? IdNivelDeAbordaje,int? IdTipoPrestacionSaludMental,int? IdTiempoInsumido,int? IdDemanda,string RecursoHumano)
	    {
		    ConConsultaDiagnostico item = new ConConsultaDiagnostico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConsultaDiagnostico = IdConsultaDiagnostico;
				
			item.IdEfector = IdEfector;
				
			item.IdConsulta = IdConsulta;
				
			item.Principal = Principal;
				
			item.CODCIE10 = CODCIE10;
				
			item.PrimerConsulta = PrimerConsulta;
				
			item.IdNivelDeAbordaje = IdNivelDeAbordaje;
				
			item.IdTipoPrestacionSaludMental = IdTipoPrestacionSaludMental;
				
			item.IdTiempoInsumido = IdTiempoInsumido;
				
			item.IdDemanda = IdDemanda;
				
			item.RecursoHumano = RecursoHumano;
				
	        item.Save(UserName);
	    }
    }
}
