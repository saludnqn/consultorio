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
    /// Controller class for Guardia_Antecedentes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaAntecedenteController
    {
        // Preload our schema..
        GuardiaAntecedente thisSchemaLoad = new GuardiaAntecedente();
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
        public GuardiaAntecedenteCollection FetchAll()
        {
            GuardiaAntecedenteCollection coll = new GuardiaAntecedenteCollection();
            Query qry = new Query(GuardiaAntecedente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaAntecedenteCollection FetchByID(object Id)
        {
            GuardiaAntecedenteCollection coll = new GuardiaAntecedenteCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaAntecedenteCollection FetchByQuery(Query qry)
        {
            GuardiaAntecedenteCollection coll = new GuardiaAntecedenteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (GuardiaAntecedente.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (GuardiaAntecedente.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Id,bool? Asma,string AsmaText,bool? Irc,string IrcText,bool? Cirugias,string CirugiasText,bool? Hta,string HtaText,bool? Infectologicas,string InfectologicasText,bool? Alergias,string AlergiasText,bool? Adicciones,string AdiccionesText,bool? Convulsiones,string ConvulsionesText,bool? Epoc,string EpocText,bool? Cardiopatia,string CardiopatiaText,bool? Neoplasias,string NeoplasiasText,bool? Traumatismos,string TraumatismosText,bool? Vacunas,string VacunasText,bool? Endocrinologia,string EndocrinologiaText,bool? Respiratorios,string RespiratoriosText,bool? Inmunodeficiencia,string InmunodeficienciaText,bool? RetrasoMaduativo,string RetrasoMadurativoText,bool? Malformaciones,string MalformacionesText,bool? AlteracionesSistemaNervioso,string AlteracionesSistemaNerviosoText,bool? Otras,string OtrasText)
	    {
		    GuardiaAntecedente item = new GuardiaAntecedente();
		    
            item.Id = Id;
            
            item.Asma = Asma;
            
            item.AsmaText = AsmaText;
            
            item.Irc = Irc;
            
            item.IrcText = IrcText;
            
            item.Cirugias = Cirugias;
            
            item.CirugiasText = CirugiasText;
            
            item.Hta = Hta;
            
            item.HtaText = HtaText;
            
            item.Infectologicas = Infectologicas;
            
            item.InfectologicasText = InfectologicasText;
            
            item.Alergias = Alergias;
            
            item.AlergiasText = AlergiasText;
            
            item.Adicciones = Adicciones;
            
            item.AdiccionesText = AdiccionesText;
            
            item.Convulsiones = Convulsiones;
            
            item.ConvulsionesText = ConvulsionesText;
            
            item.Epoc = Epoc;
            
            item.EpocText = EpocText;
            
            item.Cardiopatia = Cardiopatia;
            
            item.CardiopatiaText = CardiopatiaText;
            
            item.Neoplasias = Neoplasias;
            
            item.NeoplasiasText = NeoplasiasText;
            
            item.Traumatismos = Traumatismos;
            
            item.TraumatismosText = TraumatismosText;
            
            item.Vacunas = Vacunas;
            
            item.VacunasText = VacunasText;
            
            item.Endocrinologia = Endocrinologia;
            
            item.EndocrinologiaText = EndocrinologiaText;
            
            item.Respiratorios = Respiratorios;
            
            item.RespiratoriosText = RespiratoriosText;
            
            item.Inmunodeficiencia = Inmunodeficiencia;
            
            item.InmunodeficienciaText = InmunodeficienciaText;
            
            item.RetrasoMaduativo = RetrasoMaduativo;
            
            item.RetrasoMadurativoText = RetrasoMadurativoText;
            
            item.Malformaciones = Malformaciones;
            
            item.MalformacionesText = MalformacionesText;
            
            item.AlteracionesSistemaNervioso = AlteracionesSistemaNervioso;
            
            item.AlteracionesSistemaNerviosoText = AlteracionesSistemaNerviosoText;
            
            item.Otras = Otras;
            
            item.OtrasText = OtrasText;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,bool? Asma,string AsmaText,bool? Irc,string IrcText,bool? Cirugias,string CirugiasText,bool? Hta,string HtaText,bool? Infectologicas,string InfectologicasText,bool? Alergias,string AlergiasText,bool? Adicciones,string AdiccionesText,bool? Convulsiones,string ConvulsionesText,bool? Epoc,string EpocText,bool? Cardiopatia,string CardiopatiaText,bool? Neoplasias,string NeoplasiasText,bool? Traumatismos,string TraumatismosText,bool? Vacunas,string VacunasText,bool? Endocrinologia,string EndocrinologiaText,bool? Respiratorios,string RespiratoriosText,bool? Inmunodeficiencia,string InmunodeficienciaText,bool? RetrasoMaduativo,string RetrasoMadurativoText,bool? Malformaciones,string MalformacionesText,bool? AlteracionesSistemaNervioso,string AlteracionesSistemaNerviosoText,bool? Otras,string OtrasText)
	    {
		    GuardiaAntecedente item = new GuardiaAntecedente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Asma = Asma;
				
			item.AsmaText = AsmaText;
				
			item.Irc = Irc;
				
			item.IrcText = IrcText;
				
			item.Cirugias = Cirugias;
				
			item.CirugiasText = CirugiasText;
				
			item.Hta = Hta;
				
			item.HtaText = HtaText;
				
			item.Infectologicas = Infectologicas;
				
			item.InfectologicasText = InfectologicasText;
				
			item.Alergias = Alergias;
				
			item.AlergiasText = AlergiasText;
				
			item.Adicciones = Adicciones;
				
			item.AdiccionesText = AdiccionesText;
				
			item.Convulsiones = Convulsiones;
				
			item.ConvulsionesText = ConvulsionesText;
				
			item.Epoc = Epoc;
				
			item.EpocText = EpocText;
				
			item.Cardiopatia = Cardiopatia;
				
			item.CardiopatiaText = CardiopatiaText;
				
			item.Neoplasias = Neoplasias;
				
			item.NeoplasiasText = NeoplasiasText;
				
			item.Traumatismos = Traumatismos;
				
			item.TraumatismosText = TraumatismosText;
				
			item.Vacunas = Vacunas;
				
			item.VacunasText = VacunasText;
				
			item.Endocrinologia = Endocrinologia;
				
			item.EndocrinologiaText = EndocrinologiaText;
				
			item.Respiratorios = Respiratorios;
				
			item.RespiratoriosText = RespiratoriosText;
				
			item.Inmunodeficiencia = Inmunodeficiencia;
				
			item.InmunodeficienciaText = InmunodeficienciaText;
				
			item.RetrasoMaduativo = RetrasoMaduativo;
				
			item.RetrasoMadurativoText = RetrasoMadurativoText;
				
			item.Malformaciones = Malformaciones;
				
			item.MalformacionesText = MalformacionesText;
				
			item.AlteracionesSistemaNervioso = AlteracionesSistemaNervioso;
				
			item.AlteracionesSistemaNerviosoText = AlteracionesSistemaNerviosoText;
				
			item.Otras = Otras;
				
			item.OtrasText = OtrasText;
				
	        item.Save(UserName);
	    }
    }
}
