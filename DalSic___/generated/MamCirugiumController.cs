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
    /// Controller class for MAM_Cirugia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamCirugiumController
    {
        // Preload our schema..
        MamCirugium thisSchemaLoad = new MamCirugium();
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
        public MamCirugiumCollection FetchAll()
        {
            MamCirugiumCollection coll = new MamCirugiumCollection();
            Query qry = new Query(MamCirugium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamCirugiumCollection FetchByID(object IdCirugia)
        {
            MamCirugiumCollection coll = new MamCirugiumCollection().Where("idCirugia", IdCirugia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamCirugiumCollection FetchByQuery(Query qry)
        {
            MamCirugiumCollection coll = new MamCirugiumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCirugia)
        {
            return (MamCirugium.Delete(IdCirugia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCirugia)
        {
            return (MamCirugium.Destroy(IdCirugia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,DateTime Fecha,int Edad,string IndicadorT,string IndicadorN,string IndicadorM,int IdMaterialIzq,int IdMaterialDer,int IdTipoCirugiaIzq,int IdTipoCirugiaDer,int IdCentroSalud,int IdProfesionalResponsable,string Observacion,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamCirugium item = new MamCirugium();
		    
            item.IdPaciente = IdPaciente;
            
            item.Fecha = Fecha;
            
            item.Edad = Edad;
            
            item.IndicadorT = IndicadorT;
            
            item.IndicadorN = IndicadorN;
            
            item.IndicadorM = IndicadorM;
            
            item.IdMaterialIzq = IdMaterialIzq;
            
            item.IdMaterialDer = IdMaterialDer;
            
            item.IdTipoCirugiaIzq = IdTipoCirugiaIzq;
            
            item.IdTipoCirugiaDer = IdTipoCirugiaDer;
            
            item.IdCentroSalud = IdCentroSalud;
            
            item.IdProfesionalResponsable = IdProfesionalResponsable;
            
            item.Observacion = Observacion;
            
            item.Activo = Activo;
            
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
	    public void Update(int IdCirugia,int IdPaciente,DateTime Fecha,int Edad,string IndicadorT,string IndicadorN,string IndicadorM,int IdMaterialIzq,int IdMaterialDer,int IdTipoCirugiaIzq,int IdTipoCirugiaDer,int IdCentroSalud,int IdProfesionalResponsable,string Observacion,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamCirugium item = new MamCirugium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCirugia = IdCirugia;
				
			item.IdPaciente = IdPaciente;
				
			item.Fecha = Fecha;
				
			item.Edad = Edad;
				
			item.IndicadorT = IndicadorT;
				
			item.IndicadorN = IndicadorN;
				
			item.IndicadorM = IndicadorM;
				
			item.IdMaterialIzq = IdMaterialIzq;
				
			item.IdMaterialDer = IdMaterialDer;
				
			item.IdTipoCirugiaIzq = IdTipoCirugiaIzq;
				
			item.IdTipoCirugiaDer = IdTipoCirugiaDer;
				
			item.IdCentroSalud = IdCentroSalud;
				
			item.IdProfesionalResponsable = IdProfesionalResponsable;
				
			item.Observacion = Observacion;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
