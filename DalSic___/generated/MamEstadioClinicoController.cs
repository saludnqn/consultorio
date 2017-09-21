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
    /// Controller class for MAM_EstadioClinico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamEstadioClinicoController
    {
        // Preload our schema..
        MamEstadioClinico thisSchemaLoad = new MamEstadioClinico();
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
        public MamEstadioClinicoCollection FetchAll()
        {
            MamEstadioClinicoCollection coll = new MamEstadioClinicoCollection();
            Query qry = new Query(MamEstadioClinico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstadioClinicoCollection FetchByID(object IdEstadioClinico)
        {
            MamEstadioClinicoCollection coll = new MamEstadioClinicoCollection().Where("idEstadioClinico", IdEstadioClinico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamEstadioClinicoCollection FetchByQuery(Query qry)
        {
            MamEstadioClinicoCollection coll = new MamEstadioClinicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstadioClinico)
        {
            return (MamEstadioClinico.Delete(IdEstadioClinico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstadioClinico)
        {
            return (MamEstadioClinico.Destroy(IdEstadioClinico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,int IdCentroSalud,int Edad,DateTime FechaRegistro,int IdIndicadorT,int IdIndicadorN,int IdIndicadorM,int IdEstadio,int IdProfesional,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamEstadioClinico item = new MamEstadioClinico();
		    
            item.IdPaciente = IdPaciente;
            
            item.IdCentroSalud = IdCentroSalud;
            
            item.Edad = Edad;
            
            item.FechaRegistro = FechaRegistro;
            
            item.IdIndicadorT = IdIndicadorT;
            
            item.IdIndicadorN = IdIndicadorN;
            
            item.IdIndicadorM = IdIndicadorM;
            
            item.IdEstadio = IdEstadio;
            
            item.IdProfesional = IdProfesional;
            
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
	    public void Update(int IdEstadioClinico,int IdPaciente,int IdCentroSalud,int Edad,DateTime FechaRegistro,int IdIndicadorT,int IdIndicadorN,int IdIndicadorM,int IdEstadio,int IdProfesional,bool Activo,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    MamEstadioClinico item = new MamEstadioClinico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstadioClinico = IdEstadioClinico;
				
			item.IdPaciente = IdPaciente;
				
			item.IdCentroSalud = IdCentroSalud;
				
			item.Edad = Edad;
				
			item.FechaRegistro = FechaRegistro;
				
			item.IdIndicadorT = IdIndicadorT;
				
			item.IdIndicadorN = IdIndicadorN;
				
			item.IdIndicadorM = IdIndicadorM;
				
			item.IdEstadio = IdEstadio;
				
			item.IdProfesional = IdProfesional;
				
			item.Activo = Activo;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
