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
    /// Controller class for VGI_AClinicosDet
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class VgiAClinicosDetController
    {
        // Preload our schema..
        VgiAClinicosDet thisSchemaLoad = new VgiAClinicosDet();
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
        public VgiAClinicosDetCollection FetchAll()
        {
            VgiAClinicosDetCollection coll = new VgiAClinicosDetCollection();
            Query qry = new Query(VgiAClinicosDet.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public VgiAClinicosDetCollection FetchByID(object IdVGIAClinico)
        {
            VgiAClinicosDetCollection coll = new VgiAClinicosDetCollection().Where("idVGIAClinico", IdVGIAClinico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public VgiAClinicosDetCollection FetchByQuery(Query qry)
        {
            VgiAClinicosDetCollection coll = new VgiAClinicosDetCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdVGIAClinico)
        {
            return (VgiAClinicosDet.Delete(IdVGIAClinico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdVGIAClinico)
        {
            return (VgiAClinicosDet.Destroy(IdVGIAClinico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdVGIDatos,string Ta,decimal? Peso,decimal? Talla,decimal? Imc,string Hta,string Dbt,string Dislip,string Irc,string CardioIsq,string Acv,string Amputacion,string Tabaquismo,string Alcoholismo,string Parkinson,string Demencia,string Prostatismo,string Incontinencia,string Neuplasias,string Otros,string Rcvg,string VisionConducir,string VacunacionDT,string VacunacionHepB,string VacunacionGripe,string VacunacionNeumococo,string AudicionPSeguirConv,int? Medicacion1,int? Medicacion2,int? Medicacion3,int? Medicacion4,int? Medicacion5,string CaidasFrecuentes,string NeuplaciaDet)
	    {
		    VgiAClinicosDet item = new VgiAClinicosDet();
		    
            item.IdVGIDatos = IdVGIDatos;
            
            item.Ta = Ta;
            
            item.Peso = Peso;
            
            item.Talla = Talla;
            
            item.Imc = Imc;
            
            item.Hta = Hta;
            
            item.Dbt = Dbt;
            
            item.Dislip = Dislip;
            
            item.Irc = Irc;
            
            item.CardioIsq = CardioIsq;
            
            item.Acv = Acv;
            
            item.Amputacion = Amputacion;
            
            item.Tabaquismo = Tabaquismo;
            
            item.Alcoholismo = Alcoholismo;
            
            item.Parkinson = Parkinson;
            
            item.Demencia = Demencia;
            
            item.Prostatismo = Prostatismo;
            
            item.Incontinencia = Incontinencia;
            
            item.Neuplasias = Neuplasias;
            
            item.Otros = Otros;
            
            item.Rcvg = Rcvg;
            
            item.VisionConducir = VisionConducir;
            
            item.VacunacionDT = VacunacionDT;
            
            item.VacunacionHepB = VacunacionHepB;
            
            item.VacunacionGripe = VacunacionGripe;
            
            item.VacunacionNeumococo = VacunacionNeumococo;
            
            item.AudicionPSeguirConv = AudicionPSeguirConv;
            
            item.Medicacion1 = Medicacion1;
            
            item.Medicacion2 = Medicacion2;
            
            item.Medicacion3 = Medicacion3;
            
            item.Medicacion4 = Medicacion4;
            
            item.Medicacion5 = Medicacion5;
            
            item.CaidasFrecuentes = CaidasFrecuentes;
            
            item.NeuplaciaDet = NeuplaciaDet;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdVGIDatos,decimal IdVGIAClinico,string Ta,decimal? Peso,decimal? Talla,decimal? Imc,string Hta,string Dbt,string Dislip,string Irc,string CardioIsq,string Acv,string Amputacion,string Tabaquismo,string Alcoholismo,string Parkinson,string Demencia,string Prostatismo,string Incontinencia,string Neuplasias,string Otros,string Rcvg,string VisionConducir,string VacunacionDT,string VacunacionHepB,string VacunacionGripe,string VacunacionNeumococo,string AudicionPSeguirConv,int? Medicacion1,int? Medicacion2,int? Medicacion3,int? Medicacion4,int? Medicacion5,string CaidasFrecuentes,string NeuplaciaDet)
	    {
		    VgiAClinicosDet item = new VgiAClinicosDet();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdVGIDatos = IdVGIDatos;
				
			item.IdVGIAClinico = IdVGIAClinico;
				
			item.Ta = Ta;
				
			item.Peso = Peso;
				
			item.Talla = Talla;
				
			item.Imc = Imc;
				
			item.Hta = Hta;
				
			item.Dbt = Dbt;
				
			item.Dislip = Dislip;
				
			item.Irc = Irc;
				
			item.CardioIsq = CardioIsq;
				
			item.Acv = Acv;
				
			item.Amputacion = Amputacion;
				
			item.Tabaquismo = Tabaquismo;
				
			item.Alcoholismo = Alcoholismo;
				
			item.Parkinson = Parkinson;
				
			item.Demencia = Demencia;
				
			item.Prostatismo = Prostatismo;
				
			item.Incontinencia = Incontinencia;
				
			item.Neuplasias = Neuplasias;
				
			item.Otros = Otros;
				
			item.Rcvg = Rcvg;
				
			item.VisionConducir = VisionConducir;
				
			item.VacunacionDT = VacunacionDT;
				
			item.VacunacionHepB = VacunacionHepB;
				
			item.VacunacionGripe = VacunacionGripe;
				
			item.VacunacionNeumococo = VacunacionNeumococo;
				
			item.AudicionPSeguirConv = AudicionPSeguirConv;
				
			item.Medicacion1 = Medicacion1;
				
			item.Medicacion2 = Medicacion2;
				
			item.Medicacion3 = Medicacion3;
				
			item.Medicacion4 = Medicacion4;
				
			item.Medicacion5 = Medicacion5;
				
			item.CaidasFrecuentes = CaidasFrecuentes;
				
			item.NeuplaciaDet = NeuplaciaDet;
				
	        item.Save(UserName);
	    }
    }
}
