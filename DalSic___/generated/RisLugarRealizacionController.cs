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
    /// Controller class for RIS_LugarRealizacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisLugarRealizacionController
    {
        // Preload our schema..
        RisLugarRealizacion thisSchemaLoad = new RisLugarRealizacion();
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
        public RisLugarRealizacionCollection FetchAll()
        {
            RisLugarRealizacionCollection coll = new RisLugarRealizacionCollection();
            Query qry = new Query(RisLugarRealizacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisLugarRealizacionCollection FetchByID(object IdLugarRealizacion)
        {
            RisLugarRealizacionCollection coll = new RisLugarRealizacionCollection().Where("idLugarRealizacion", IdLugarRealizacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisLugarRealizacionCollection FetchByQuery(Query qry)
        {
            RisLugarRealizacionCollection coll = new RisLugarRealizacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLugarRealizacion)
        {
            return (RisLugarRealizacion.Delete(IdLugarRealizacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLugarRealizacion)
        {
            return (RisLugarRealizacion.Destroy(IdLugarRealizacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,string Descripcion,string Ambito,string Domicilio,string Cp,string Ciudad,string Email,string Responsable,string Cargo)
	    {
		    RisLugarRealizacion item = new RisLugarRealizacion();
		    
            item.IdEstudio = IdEstudio;
            
            item.Descripcion = Descripcion;
            
            item.Ambito = Ambito;
            
            item.Domicilio = Domicilio;
            
            item.Cp = Cp;
            
            item.Ciudad = Ciudad;
            
            item.Email = Email;
            
            item.Responsable = Responsable;
            
            item.Cargo = Cargo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLugarRealizacion,int IdEstudio,string Descripcion,string Ambito,string Domicilio,string Cp,string Ciudad,string Email,string Responsable,string Cargo)
	    {
		    RisLugarRealizacion item = new RisLugarRealizacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLugarRealizacion = IdLugarRealizacion;
				
			item.IdEstudio = IdEstudio;
				
			item.Descripcion = Descripcion;
				
			item.Ambito = Ambito;
				
			item.Domicilio = Domicilio;
				
			item.Cp = Cp;
				
			item.Ciudad = Ciudad;
				
			item.Email = Email;
				
			item.Responsable = Responsable;
				
			item.Cargo = Cargo;
				
	        item.Save(UserName);
	    }
    }
}
