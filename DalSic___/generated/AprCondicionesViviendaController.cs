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
    /// Controller class for APR_CondicionesVivienda
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprCondicionesViviendaController
    {
        // Preload our schema..
        AprCondicionesVivienda thisSchemaLoad = new AprCondicionesVivienda();
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
        public AprCondicionesViviendaCollection FetchAll()
        {
            AprCondicionesViviendaCollection coll = new AprCondicionesViviendaCollection();
            Query qry = new Query(AprCondicionesVivienda.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCondicionesViviendaCollection FetchByID(object IdCondicionesVivienda)
        {
            AprCondicionesViviendaCollection coll = new AprCondicionesViviendaCollection().Where("idCondicionesVivienda", IdCondicionesVivienda).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprCondicionesViviendaCollection FetchByQuery(Query qry)
        {
            AprCondicionesViviendaCollection coll = new AprCondicionesViviendaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCondicionesVivienda)
        {
            return (AprCondicionesVivienda.Delete(IdCondicionesVivienda) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCondicionesVivienda)
        {
            return (AprCondicionesVivienda.Destroy(IdCondicionesVivienda) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(bool? PisoTierra,bool? PisoMaterial,bool? BRecoleccion,bool? BEntierran,bool? BQueman,bool? BOtra,bool? FCGasNatural,bool? FCGarrafa,bool? FCCarbon,bool? FCKerosen,bool? FCElectricidad,bool? FCOtro,bool? PCHumo,bool? PCBasurales,bool? PCAgroquimicos,bool? PCVectores,bool? PCTerrInundados,bool? PCPetroquimicos,bool? CRedAgua,bool? CRedExcretas,bool? NoCRedAgua,bool? NoCRedExcretas,bool? FHogarAgua,bool? FHogarExcretas,int? IdControlNiñoSano,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdPaciente)
	    {
		    AprCondicionesVivienda item = new AprCondicionesVivienda();
		    
            item.PisoTierra = PisoTierra;
            
            item.PisoMaterial = PisoMaterial;
            
            item.BRecoleccion = BRecoleccion;
            
            item.BEntierran = BEntierran;
            
            item.BQueman = BQueman;
            
            item.BOtra = BOtra;
            
            item.FCGasNatural = FCGasNatural;
            
            item.FCGarrafa = FCGarrafa;
            
            item.FCCarbon = FCCarbon;
            
            item.FCKerosen = FCKerosen;
            
            item.FCElectricidad = FCElectricidad;
            
            item.FCOtro = FCOtro;
            
            item.PCHumo = PCHumo;
            
            item.PCBasurales = PCBasurales;
            
            item.PCAgroquimicos = PCAgroquimicos;
            
            item.PCVectores = PCVectores;
            
            item.PCTerrInundados = PCTerrInundados;
            
            item.PCPetroquimicos = PCPetroquimicos;
            
            item.CRedAgua = CRedAgua;
            
            item.CRedExcretas = CRedExcretas;
            
            item.NoCRedAgua = NoCRedAgua;
            
            item.NoCRedExcretas = NoCRedExcretas;
            
            item.FHogarAgua = FHogarAgua;
            
            item.FHogarExcretas = FHogarExcretas;
            
            item.IdControlNiñoSano = IdControlNiñoSano;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IdPaciente = IdPaciente;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCondicionesVivienda,bool? PisoTierra,bool? PisoMaterial,bool? BRecoleccion,bool? BEntierran,bool? BQueman,bool? BOtra,bool? FCGasNatural,bool? FCGarrafa,bool? FCCarbon,bool? FCKerosen,bool? FCElectricidad,bool? FCOtro,bool? PCHumo,bool? PCBasurales,bool? PCAgroquimicos,bool? PCVectores,bool? PCTerrInundados,bool? PCPetroquimicos,bool? CRedAgua,bool? CRedExcretas,bool? NoCRedAgua,bool? NoCRedExcretas,bool? FHogarAgua,bool? FHogarExcretas,int? IdControlNiñoSano,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn,int? IdPaciente)
	    {
		    AprCondicionesVivienda item = new AprCondicionesVivienda();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCondicionesVivienda = IdCondicionesVivienda;
				
			item.PisoTierra = PisoTierra;
				
			item.PisoMaterial = PisoMaterial;
				
			item.BRecoleccion = BRecoleccion;
				
			item.BEntierran = BEntierran;
				
			item.BQueman = BQueman;
				
			item.BOtra = BOtra;
				
			item.FCGasNatural = FCGasNatural;
				
			item.FCGarrafa = FCGarrafa;
				
			item.FCCarbon = FCCarbon;
				
			item.FCKerosen = FCKerosen;
				
			item.FCElectricidad = FCElectricidad;
				
			item.FCOtro = FCOtro;
				
			item.PCHumo = PCHumo;
				
			item.PCBasurales = PCBasurales;
				
			item.PCAgroquimicos = PCAgroquimicos;
				
			item.PCVectores = PCVectores;
				
			item.PCTerrInundados = PCTerrInundados;
				
			item.PCPetroquimicos = PCPetroquimicos;
				
			item.CRedAgua = CRedAgua;
				
			item.CRedExcretas = CRedExcretas;
				
			item.NoCRedAgua = NoCRedAgua;
				
			item.NoCRedExcretas = NoCRedExcretas;
				
			item.FHogarAgua = FHogarAgua;
				
			item.FHogarExcretas = FHogarExcretas;
				
			item.IdControlNiñoSano = IdControlNiñoSano;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.IdPaciente = IdPaciente;
				
	        item.Save(UserName);
	    }
    }
}
