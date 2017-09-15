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
    /// Controller class for Rem_Complicaciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemComplicacioneController
    {
        // Preload our schema..
        RemComplicacione thisSchemaLoad = new RemComplicacione();
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
        public RemComplicacioneCollection FetchAll()
        {
            RemComplicacioneCollection coll = new RemComplicacioneCollection();
            Query qry = new Query(RemComplicacione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemComplicacioneCollection FetchByID(object IdComplicaciones)
        {
            RemComplicacioneCollection coll = new RemComplicacioneCollection().Where("idComplicaciones", IdComplicaciones).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemComplicacioneCollection FetchByQuery(Query qry)
        {
            RemComplicacioneCollection coll = new RemComplicacioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdComplicaciones)
        {
            return (RemComplicacione.Delete(IdComplicaciones) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdComplicaciones)
        {
            return (RemComplicacione.Destroy(IdComplicaciones) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdClasificacion,bool DisfuncionErectil,bool HipotencionOrtost,bool Iam,bool AnginaPecho,bool Acv,bool Ait,bool ClaudicMMII,bool CirugRevascMioc,bool InsuficienciaRenal,bool Nefropatia,bool Dialisis,bool Transplante,bool Ceguera,bool AmputSupramal,bool AmputInferomal,bool OtrasAmputaciones,DateTime Ecg,bool Hipertrofia,bool Normal,DateTime Ecocardiograma,bool EcocardNormal,DateTime Ergometria,bool ErgometNormal,DateTime ConsejoAntitabaco,bool Precontemplativa,bool Contemplativa,bool Preparacion,DateTime DejoFumar,DateTime FechaFojo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int FondoONormal)
	    {
		    RemComplicacione item = new RemComplicacione();
		    
            item.IdClasificacion = IdClasificacion;
            
            item.DisfuncionErectil = DisfuncionErectil;
            
            item.HipotencionOrtost = HipotencionOrtost;
            
            item.Iam = Iam;
            
            item.AnginaPecho = AnginaPecho;
            
            item.Acv = Acv;
            
            item.Ait = Ait;
            
            item.ClaudicMMII = ClaudicMMII;
            
            item.CirugRevascMioc = CirugRevascMioc;
            
            item.InsuficienciaRenal = InsuficienciaRenal;
            
            item.Nefropatia = Nefropatia;
            
            item.Dialisis = Dialisis;
            
            item.Transplante = Transplante;
            
            item.Ceguera = Ceguera;
            
            item.AmputSupramal = AmputSupramal;
            
            item.AmputInferomal = AmputInferomal;
            
            item.OtrasAmputaciones = OtrasAmputaciones;
            
            item.Ecg = Ecg;
            
            item.Hipertrofia = Hipertrofia;
            
            item.Normal = Normal;
            
            item.Ecocardiograma = Ecocardiograma;
            
            item.EcocardNormal = EcocardNormal;
            
            item.Ergometria = Ergometria;
            
            item.ErgometNormal = ErgometNormal;
            
            item.ConsejoAntitabaco = ConsejoAntitabaco;
            
            item.Precontemplativa = Precontemplativa;
            
            item.Contemplativa = Contemplativa;
            
            item.Preparacion = Preparacion;
            
            item.DejoFumar = DejoFumar;
            
            item.FechaFojo = FechaFojo;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.FondoONormal = FondoONormal;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdComplicaciones,int IdClasificacion,bool DisfuncionErectil,bool HipotencionOrtost,bool Iam,bool AnginaPecho,bool Acv,bool Ait,bool ClaudicMMII,bool CirugRevascMioc,bool InsuficienciaRenal,bool Nefropatia,bool Dialisis,bool Transplante,bool Ceguera,bool AmputSupramal,bool AmputInferomal,bool OtrasAmputaciones,DateTime Ecg,bool Hipertrofia,bool Normal,DateTime Ecocardiograma,bool EcocardNormal,DateTime Ergometria,bool ErgometNormal,DateTime ConsejoAntitabaco,bool Precontemplativa,bool Contemplativa,bool Preparacion,DateTime DejoFumar,DateTime FechaFojo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int FondoONormal)
	    {
		    RemComplicacione item = new RemComplicacione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdComplicaciones = IdComplicaciones;
				
			item.IdClasificacion = IdClasificacion;
				
			item.DisfuncionErectil = DisfuncionErectil;
				
			item.HipotencionOrtost = HipotencionOrtost;
				
			item.Iam = Iam;
				
			item.AnginaPecho = AnginaPecho;
				
			item.Acv = Acv;
				
			item.Ait = Ait;
				
			item.ClaudicMMII = ClaudicMMII;
				
			item.CirugRevascMioc = CirugRevascMioc;
				
			item.InsuficienciaRenal = InsuficienciaRenal;
				
			item.Nefropatia = Nefropatia;
				
			item.Dialisis = Dialisis;
				
			item.Transplante = Transplante;
				
			item.Ceguera = Ceguera;
				
			item.AmputSupramal = AmputSupramal;
				
			item.AmputInferomal = AmputInferomal;
				
			item.OtrasAmputaciones = OtrasAmputaciones;
				
			item.Ecg = Ecg;
				
			item.Hipertrofia = Hipertrofia;
				
			item.Normal = Normal;
				
			item.Ecocardiograma = Ecocardiograma;
				
			item.EcocardNormal = EcocardNormal;
				
			item.Ergometria = Ergometria;
				
			item.ErgometNormal = ErgometNormal;
				
			item.ConsejoAntitabaco = ConsejoAntitabaco;
				
			item.Precontemplativa = Precontemplativa;
				
			item.Contemplativa = Contemplativa;
				
			item.Preparacion = Preparacion;
				
			item.DejoFumar = DejoFumar;
				
			item.FechaFojo = FechaFojo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.FondoONormal = FondoONormal;
				
	        item.Save(UserName);
	    }
    }
}
