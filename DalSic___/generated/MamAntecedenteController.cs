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
    /// Controller class for MAM_Antecedentes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamAntecedenteController
    {
        // Preload our schema..
        MamAntecedente thisSchemaLoad = new MamAntecedente();
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
        public MamAntecedenteCollection FetchAll()
        {
            MamAntecedenteCollection coll = new MamAntecedenteCollection();
            Query qry = new Query(MamAntecedente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamAntecedenteCollection FetchByID(object IdAntecedenteMamas)
        {
            MamAntecedenteCollection coll = new MamAntecedenteCollection().Where("idAntecedenteMamas", IdAntecedenteMamas).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamAntecedenteCollection FetchByQuery(Query qry)
        {
            MamAntecedenteCollection coll = new MamAntecedenteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAntecedenteMamas)
        {
            return (MamAntecedente.Delete(IdAntecedenteMamas) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAntecedenteMamas)
        {
            return (MamAntecedente.Destroy(IdAntecedenteMamas) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,int Edad,int IdMetodoAnticonceptivo,int EmbarazoActual,int CantidadPartos,int CantidadEmbarazos,int AntecLactancia,int AntecCancer,string AntecCancerCual,string AntecCancerTipoParentezco,DateTime FechaFUM,int EdadFUM,int EdadPrimerEmb,int Menopausia,int Thr,string TiempoUso,int AntecEnfermedadMx,int AntecBiopsiaMx,string LocalizacionBMx,string InformeAnatomiaPatologica,int AntecCancerPersonal,string AntecCancerPersonalCual,int MxPrevia,DateTime FechaMxPrevia,string TiempoEstimado,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int Menarca)
	    {
		    MamAntecedente item = new MamAntecedente();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.IdMetodoAnticonceptivo = IdMetodoAnticonceptivo;
            
            item.EmbarazoActual = EmbarazoActual;
            
            item.CantidadPartos = CantidadPartos;
            
            item.CantidadEmbarazos = CantidadEmbarazos;
            
            item.AntecLactancia = AntecLactancia;
            
            item.AntecCancer = AntecCancer;
            
            item.AntecCancerCual = AntecCancerCual;
            
            item.AntecCancerTipoParentezco = AntecCancerTipoParentezco;
            
            item.FechaFUM = FechaFUM;
            
            item.EdadFUM = EdadFUM;
            
            item.EdadPrimerEmb = EdadPrimerEmb;
            
            item.Menopausia = Menopausia;
            
            item.Thr = Thr;
            
            item.TiempoUso = TiempoUso;
            
            item.AntecEnfermedadMx = AntecEnfermedadMx;
            
            item.AntecBiopsiaMx = AntecBiopsiaMx;
            
            item.LocalizacionBMx = LocalizacionBMx;
            
            item.InformeAnatomiaPatologica = InformeAnatomiaPatologica;
            
            item.AntecCancerPersonal = AntecCancerPersonal;
            
            item.AntecCancerPersonalCual = AntecCancerPersonalCual;
            
            item.MxPrevia = MxPrevia;
            
            item.FechaMxPrevia = FechaMxPrevia;
            
            item.TiempoEstimado = TiempoEstimado;
            
            item.Activo = Activo;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.Menarca = Menarca;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAntecedenteMamas,int IdEfector,int IdPaciente,int Edad,int IdMetodoAnticonceptivo,int EmbarazoActual,int CantidadPartos,int CantidadEmbarazos,int AntecLactancia,int AntecCancer,string AntecCancerCual,string AntecCancerTipoParentezco,DateTime FechaFUM,int EdadFUM,int EdadPrimerEmb,int Menopausia,int Thr,string TiempoUso,int AntecEnfermedadMx,int AntecBiopsiaMx,string LocalizacionBMx,string InformeAnatomiaPatologica,int AntecCancerPersonal,string AntecCancerPersonalCual,int MxPrevia,DateTime FechaMxPrevia,string TiempoEstimado,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int Menarca)
	    {
		    MamAntecedente item = new MamAntecedente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAntecedenteMamas = IdAntecedenteMamas;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.IdMetodoAnticonceptivo = IdMetodoAnticonceptivo;
				
			item.EmbarazoActual = EmbarazoActual;
				
			item.CantidadPartos = CantidadPartos;
				
			item.CantidadEmbarazos = CantidadEmbarazos;
				
			item.AntecLactancia = AntecLactancia;
				
			item.AntecCancer = AntecCancer;
				
			item.AntecCancerCual = AntecCancerCual;
				
			item.AntecCancerTipoParentezco = AntecCancerTipoParentezco;
				
			item.FechaFUM = FechaFUM;
				
			item.EdadFUM = EdadFUM;
				
			item.EdadPrimerEmb = EdadPrimerEmb;
				
			item.Menopausia = Menopausia;
				
			item.Thr = Thr;
				
			item.TiempoUso = TiempoUso;
				
			item.AntecEnfermedadMx = AntecEnfermedadMx;
				
			item.AntecBiopsiaMx = AntecBiopsiaMx;
				
			item.LocalizacionBMx = LocalizacionBMx;
				
			item.InformeAnatomiaPatologica = InformeAnatomiaPatologica;
				
			item.AntecCancerPersonal = AntecCancerPersonal;
				
			item.AntecCancerPersonalCual = AntecCancerPersonalCual;
				
			item.MxPrevia = MxPrevia;
				
			item.FechaMxPrevia = FechaMxPrevia;
				
			item.TiempoEstimado = TiempoEstimado;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.Menarca = Menarca;
				
	        item.Save(UserName);
	    }
    }
}
