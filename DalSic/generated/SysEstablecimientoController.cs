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
    /// Controller class for sys_Establecimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysEstablecimientoController
    {
        // Preload our schema..
        SysEstablecimiento thisSchemaLoad = new SysEstablecimiento();
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
        public SysEstablecimientoCollection FetchAll()
        {
            SysEstablecimientoCollection coll = new SysEstablecimientoCollection();
            Query qry = new Query(SysEstablecimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEstablecimientoCollection FetchByID(object IdEstablecimiento)
        {
            SysEstablecimientoCollection coll = new SysEstablecimientoCollection().Where("idEstablecimiento", IdEstablecimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEstablecimientoCollection FetchByQuery(Query qry)
        {
            SysEstablecimientoCollection coll = new SysEstablecimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstablecimiento)
        {
            return (SysEstablecimiento.Delete(IdEstablecimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstablecimiento)
        {
            return (SysEstablecimiento.Destroy(IdEstablecimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstablecimiento,string Localidad,string Nombre,int IdZona,int? IdLocalidad,int? IdEfector,string TipoEstab)
	    {
		    SysEstablecimiento item = new SysEstablecimiento();
		    
            item.IdEstablecimiento = IdEstablecimiento;
            
            item.Localidad = Localidad;
            
            item.Nombre = Nombre;
            
            item.IdZona = IdZona;
            
            item.IdLocalidad = IdLocalidad;
            
            item.IdEfector = IdEfector;
            
            item.TipoEstab = TipoEstab;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstablecimiento,string Localidad,string Nombre,int IdZona,int? IdLocalidad,int? IdEfector,string TipoEstab)
	    {
		    SysEstablecimiento item = new SysEstablecimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstablecimiento = IdEstablecimiento;
				
			item.Localidad = Localidad;
				
			item.Nombre = Nombre;
				
			item.IdZona = IdZona;
				
			item.IdLocalidad = IdLocalidad;
				
			item.IdEfector = IdEfector;
				
			item.TipoEstab = TipoEstab;
				
	        item.Save(UserName);
	    }
    }
}
