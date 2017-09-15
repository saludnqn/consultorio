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
    /// Controller class for PN_alta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAltumController
    {
        // Preload our schema..
        PnAltum thisSchemaLoad = new PnAltum();
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
        public PnAltumCollection FetchAll()
        {
            PnAltumCollection coll = new PnAltumCollection();
            Query qry = new Query(PnAltum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAltumCollection FetchByID(object IdAlta)
        {
            PnAltumCollection coll = new PnAltumCollection().Where("id_alta", IdAlta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAltumCollection FetchByQuery(Query qry)
        {
            PnAltumCollection coll = new PnAltumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAlta)
        {
            return (PnAltum.Delete(IdAlta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAlta)
        {
            return (PnAltum.Destroy(IdAlta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,DateTime? FechaAlta,DateTime? FechaParto,string NomMadre,string DocMadre,string NomBebe,string RepObstetricia,string RepNeo,string RepEnf,string LlenaEpi,string CarnetParenteral,decimal? PesoNacer,string RiesgoSocial,string Sifilis,string Hiv,string HepB,string Chagas,string Toxo,string PesNeonatal,string VacHepB,string VacBcg,string GrupoFactorMama,string GrupoFactorBebe,string GammaAntiRh,string Observaciones,string CuieAtHab,string Domicilio,string Pueri,string AlarmaBebe,string AlarmaMadre,string LacMaterna,string SaludRepro,string CuidadosPuerpe)
	    {
		    PnAltum item = new PnAltum();
		    
            item.Cuie = Cuie;
            
            item.FechaAlta = FechaAlta;
            
            item.FechaParto = FechaParto;
            
            item.NomMadre = NomMadre;
            
            item.DocMadre = DocMadre;
            
            item.NomBebe = NomBebe;
            
            item.RepObstetricia = RepObstetricia;
            
            item.RepNeo = RepNeo;
            
            item.RepEnf = RepEnf;
            
            item.LlenaEpi = LlenaEpi;
            
            item.CarnetParenteral = CarnetParenteral;
            
            item.PesoNacer = PesoNacer;
            
            item.RiesgoSocial = RiesgoSocial;
            
            item.Sifilis = Sifilis;
            
            item.Hiv = Hiv;
            
            item.HepB = HepB;
            
            item.Chagas = Chagas;
            
            item.Toxo = Toxo;
            
            item.PesNeonatal = PesNeonatal;
            
            item.VacHepB = VacHepB;
            
            item.VacBcg = VacBcg;
            
            item.GrupoFactorMama = GrupoFactorMama;
            
            item.GrupoFactorBebe = GrupoFactorBebe;
            
            item.GammaAntiRh = GammaAntiRh;
            
            item.Observaciones = Observaciones;
            
            item.CuieAtHab = CuieAtHab;
            
            item.Domicilio = Domicilio;
            
            item.Pueri = Pueri;
            
            item.AlarmaBebe = AlarmaBebe;
            
            item.AlarmaMadre = AlarmaMadre;
            
            item.LacMaterna = LacMaterna;
            
            item.SaludRepro = SaludRepro;
            
            item.CuidadosPuerpe = CuidadosPuerpe;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAlta,string Cuie,DateTime? FechaAlta,DateTime? FechaParto,string NomMadre,string DocMadre,string NomBebe,string RepObstetricia,string RepNeo,string RepEnf,string LlenaEpi,string CarnetParenteral,decimal? PesoNacer,string RiesgoSocial,string Sifilis,string Hiv,string HepB,string Chagas,string Toxo,string PesNeonatal,string VacHepB,string VacBcg,string GrupoFactorMama,string GrupoFactorBebe,string GammaAntiRh,string Observaciones,string CuieAtHab,string Domicilio,string Pueri,string AlarmaBebe,string AlarmaMadre,string LacMaterna,string SaludRepro,string CuidadosPuerpe)
	    {
		    PnAltum item = new PnAltum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAlta = IdAlta;
				
			item.Cuie = Cuie;
				
			item.FechaAlta = FechaAlta;
				
			item.FechaParto = FechaParto;
				
			item.NomMadre = NomMadre;
				
			item.DocMadre = DocMadre;
				
			item.NomBebe = NomBebe;
				
			item.RepObstetricia = RepObstetricia;
				
			item.RepNeo = RepNeo;
				
			item.RepEnf = RepEnf;
				
			item.LlenaEpi = LlenaEpi;
				
			item.CarnetParenteral = CarnetParenteral;
				
			item.PesoNacer = PesoNacer;
				
			item.RiesgoSocial = RiesgoSocial;
				
			item.Sifilis = Sifilis;
				
			item.Hiv = Hiv;
				
			item.HepB = HepB;
				
			item.Chagas = Chagas;
				
			item.Toxo = Toxo;
				
			item.PesNeonatal = PesNeonatal;
				
			item.VacHepB = VacHepB;
				
			item.VacBcg = VacBcg;
				
			item.GrupoFactorMama = GrupoFactorMama;
				
			item.GrupoFactorBebe = GrupoFactorBebe;
				
			item.GammaAntiRh = GammaAntiRh;
				
			item.Observaciones = Observaciones;
				
			item.CuieAtHab = CuieAtHab;
				
			item.Domicilio = Domicilio;
				
			item.Pueri = Pueri;
				
			item.AlarmaBebe = AlarmaBebe;
				
			item.AlarmaMadre = AlarmaMadre;
				
			item.LacMaterna = LacMaterna;
				
			item.SaludRepro = SaludRepro;
				
			item.CuidadosPuerpe = CuidadosPuerpe;
				
	        item.Save(UserName);
	    }
    }
}
