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
    /// Controller class for Guardia_Registros_Practicas_Laboratorio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaRegistrosPracticasLaboratorioController
    {
        // Preload our schema..
        GuardiaRegistrosPracticasLaboratorio thisSchemaLoad = new GuardiaRegistrosPracticasLaboratorio();
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
        public GuardiaRegistrosPracticasLaboratorioCollection FetchAll()
        {
            GuardiaRegistrosPracticasLaboratorioCollection coll = new GuardiaRegistrosPracticasLaboratorioCollection();
            Query qry = new Query(GuardiaRegistrosPracticasLaboratorio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosPracticasLaboratorioCollection FetchByID(object IdPractica)
        {
            GuardiaRegistrosPracticasLaboratorioCollection coll = new GuardiaRegistrosPracticasLaboratorioCollection().Where("idPractica", IdPractica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaRegistrosPracticasLaboratorioCollection FetchByQuery(Query qry)
        {
            GuardiaRegistrosPracticasLaboratorioCollection coll = new GuardiaRegistrosPracticasLaboratorioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPractica)
        {
            return (GuardiaRegistrosPracticasLaboratorio.Delete(IdPractica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPractica)
        {
            return (GuardiaRegistrosPracticasLaboratorio.Destroy(IdPractica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPractica,bool Hematocrito,bool Hemoglobina,bool FormulaLeucocitaria,bool Plaquetas,bool Urea,bool Creatinina,bool Glucosa,bool Lactato,bool Got,bool Amilasa,bool Hiv,bool CkCkmb,bool Cloro,bool Ionograma,bool GasesSangre,bool CalcioIonico,bool Proteinas,bool SedimentoOrina,bool Bilirrubina,bool TiempoProtrombina,bool Kptt,bool Gpt,bool Vdrl,bool Ldh)
	    {
		    GuardiaRegistrosPracticasLaboratorio item = new GuardiaRegistrosPracticasLaboratorio();
		    
            item.IdPractica = IdPractica;
            
            item.Hematocrito = Hematocrito;
            
            item.Hemoglobina = Hemoglobina;
            
            item.FormulaLeucocitaria = FormulaLeucocitaria;
            
            item.Plaquetas = Plaquetas;
            
            item.Urea = Urea;
            
            item.Creatinina = Creatinina;
            
            item.Glucosa = Glucosa;
            
            item.Lactato = Lactato;
            
            item.Got = Got;
            
            item.Amilasa = Amilasa;
            
            item.Hiv = Hiv;
            
            item.CkCkmb = CkCkmb;
            
            item.Cloro = Cloro;
            
            item.Ionograma = Ionograma;
            
            item.GasesSangre = GasesSangre;
            
            item.CalcioIonico = CalcioIonico;
            
            item.Proteinas = Proteinas;
            
            item.SedimentoOrina = SedimentoOrina;
            
            item.Bilirrubina = Bilirrubina;
            
            item.TiempoProtrombina = TiempoProtrombina;
            
            item.Kptt = Kptt;
            
            item.Gpt = Gpt;
            
            item.Vdrl = Vdrl;
            
            item.Ldh = Ldh;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPractica,bool Hematocrito,bool Hemoglobina,bool FormulaLeucocitaria,bool Plaquetas,bool Urea,bool Creatinina,bool Glucosa,bool Lactato,bool Got,bool Amilasa,bool Hiv,bool CkCkmb,bool Cloro,bool Ionograma,bool GasesSangre,bool CalcioIonico,bool Proteinas,bool SedimentoOrina,bool Bilirrubina,bool TiempoProtrombina,bool Kptt,bool Gpt,bool Vdrl,bool Ldh)
	    {
		    GuardiaRegistrosPracticasLaboratorio item = new GuardiaRegistrosPracticasLaboratorio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPractica = IdPractica;
				
			item.Hematocrito = Hematocrito;
				
			item.Hemoglobina = Hemoglobina;
				
			item.FormulaLeucocitaria = FormulaLeucocitaria;
				
			item.Plaquetas = Plaquetas;
				
			item.Urea = Urea;
				
			item.Creatinina = Creatinina;
				
			item.Glucosa = Glucosa;
				
			item.Lactato = Lactato;
				
			item.Got = Got;
				
			item.Amilasa = Amilasa;
				
			item.Hiv = Hiv;
				
			item.CkCkmb = CkCkmb;
				
			item.Cloro = Cloro;
				
			item.Ionograma = Ionograma;
				
			item.GasesSangre = GasesSangre;
				
			item.CalcioIonico = CalcioIonico;
				
			item.Proteinas = Proteinas;
				
			item.SedimentoOrina = SedimentoOrina;
				
			item.Bilirrubina = Bilirrubina;
				
			item.TiempoProtrombina = TiempoProtrombina;
				
			item.Kptt = Kptt;
				
			item.Gpt = Gpt;
				
			item.Vdrl = Vdrl;
				
			item.Ldh = Ldh;
				
	        item.Save(UserName);
	    }
    }
}
