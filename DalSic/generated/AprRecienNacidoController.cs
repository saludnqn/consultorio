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
    /// Controller class for APR_RecienNacido
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprRecienNacidoController
    {
        // Preload our schema..
        AprRecienNacido thisSchemaLoad = new AprRecienNacido();
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
        public AprRecienNacidoCollection FetchAll()
        {
            AprRecienNacidoCollection coll = new AprRecienNacidoCollection();
            Query qry = new Query(AprRecienNacido.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRecienNacidoCollection FetchByID(object IdRecienNacido)
        {
            AprRecienNacidoCollection coll = new AprRecienNacidoCollection().Where("idRecienNacido", IdRecienNacido).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprRecienNacidoCollection FetchByQuery(Query qry)
        {
            AprRecienNacidoCollection coll = new AprRecienNacidoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRecienNacido)
        {
            return (AprRecienNacido.Delete(IdRecienNacido) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRecienNacido)
        {
            return (AprRecienNacido.Destroy(IdRecienNacido) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int? IdPaciente,double? Peso,double? PerimetroCefalico,double? Longitud,int? APGAR1,int? APGAR5,double? PesoAlAlta,bool? Gemelar,int? NroGesta,string DiagnosticoNeonatalTemporal,string DiagnosticoNeonatalFisico,bool? ScreeningRealizado,bool? ScreeningNormal,string OEARealizado,bool? EmbarazoNormal,int? IdTipoParto,bool? PesquizaNeonatal,bool? Hb12meses,bool? TA3,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRecienNacido item = new AprRecienNacido();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.Peso = Peso;
            
            item.PerimetroCefalico = PerimetroCefalico;
            
            item.Longitud = Longitud;
            
            item.APGAR1 = APGAR1;
            
            item.APGAR5 = APGAR5;
            
            item.PesoAlAlta = PesoAlAlta;
            
            item.Gemelar = Gemelar;
            
            item.NroGesta = NroGesta;
            
            item.DiagnosticoNeonatalTemporal = DiagnosticoNeonatalTemporal;
            
            item.DiagnosticoNeonatalFisico = DiagnosticoNeonatalFisico;
            
            item.ScreeningRealizado = ScreeningRealizado;
            
            item.ScreeningNormal = ScreeningNormal;
            
            item.OEARealizado = OEARealizado;
            
            item.EmbarazoNormal = EmbarazoNormal;
            
            item.IdTipoParto = IdTipoParto;
            
            item.PesquizaNeonatal = PesquizaNeonatal;
            
            item.Hb12meses = Hb12meses;
            
            item.TA3 = TA3;
            
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
	    public void Update(int IdRecienNacido,int IdEfector,int? IdPaciente,double? Peso,double? PerimetroCefalico,double? Longitud,int? APGAR1,int? APGAR5,double? PesoAlAlta,bool? Gemelar,int? NroGesta,string DiagnosticoNeonatalTemporal,string DiagnosticoNeonatalFisico,bool? ScreeningRealizado,bool? ScreeningNormal,string OEARealizado,bool? EmbarazoNormal,int? IdTipoParto,bool? PesquizaNeonatal,bool? Hb12meses,bool? TA3,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    AprRecienNacido item = new AprRecienNacido();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRecienNacido = IdRecienNacido;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.Peso = Peso;
				
			item.PerimetroCefalico = PerimetroCefalico;
				
			item.Longitud = Longitud;
				
			item.APGAR1 = APGAR1;
				
			item.APGAR5 = APGAR5;
				
			item.PesoAlAlta = PesoAlAlta;
				
			item.Gemelar = Gemelar;
				
			item.NroGesta = NroGesta;
				
			item.DiagnosticoNeonatalTemporal = DiagnosticoNeonatalTemporal;
				
			item.DiagnosticoNeonatalFisico = DiagnosticoNeonatalFisico;
				
			item.ScreeningRealizado = ScreeningRealizado;
				
			item.ScreeningNormal = ScreeningNormal;
				
			item.OEARealizado = OEARealizado;
				
			item.EmbarazoNormal = EmbarazoNormal;
				
			item.IdTipoParto = IdTipoParto;
				
			item.PesquizaNeonatal = PesquizaNeonatal;
				
			item.Hb12meses = Hb12meses;
				
			item.TA3 = TA3;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
