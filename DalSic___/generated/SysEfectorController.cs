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
    /// Controller class for Sys_Efector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysEfectorController
    {
        // Preload our schema..
        SysEfector thisSchemaLoad = new SysEfector();
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
        public SysEfectorCollection FetchAll()
        {
            SysEfectorCollection coll = new SysEfectorCollection();
            Query qry = new Query(SysEfector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEfectorCollection FetchByID(object IdEfector)
        {
            SysEfectorCollection coll = new SysEfectorCollection().Where("idEfector", IdEfector).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEfectorCollection FetchByQuery(Query qry)
        {
            SysEfectorCollection coll = new SysEfectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEfector)
        {
            return (SysEfector.Delete(IdEfector) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEfector)
        {
            return (SysEfector.Destroy(IdEfector) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdZona,string NombreNacion,string Complejidad,int IdEfectorSuperior,string Domicilio,string Telefono,string Reponsable,string CodigoRemediar,string Cuie,int? IdTipoEfector,string CodigoSisa)
	    {
		    SysEfector item = new SysEfector();
		    
            item.Nombre = Nombre;
            
            item.IdZona = IdZona;
            
            item.NombreNacion = NombreNacion;
            
            item.Complejidad = Complejidad;
            
            item.IdEfectorSuperior = IdEfectorSuperior;
            
            item.Domicilio = Domicilio;
            
            item.Telefono = Telefono;
            
            item.Reponsable = Reponsable;
            
            item.CodigoRemediar = CodigoRemediar;
            
            item.Cuie = Cuie;
            
            item.IdTipoEfector = IdTipoEfector;
            
            item.CodigoSisa = CodigoSisa;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEfector,string Nombre,int IdZona,string NombreNacion,string Complejidad,int IdEfectorSuperior,string Domicilio,string Telefono,string Reponsable,string CodigoRemediar,string Cuie,int? IdTipoEfector,string CodigoSisa)
	    {
		    SysEfector item = new SysEfector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEfector = IdEfector;
				
			item.Nombre = Nombre;
				
			item.IdZona = IdZona;
				
			item.NombreNacion = NombreNacion;
				
			item.Complejidad = Complejidad;
				
			item.IdEfectorSuperior = IdEfectorSuperior;
				
			item.Domicilio = Domicilio;
				
			item.Telefono = Telefono;
				
			item.Reponsable = Reponsable;
				
			item.CodigoRemediar = CodigoRemediar;
				
			item.Cuie = Cuie;
				
			item.IdTipoEfector = IdTipoEfector;
				
			item.CodigoSisa = CodigoSisa;
				
	        item.Save(UserName);
	    }
    }
}
