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
    /// Controller class for PN_localidades
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLocalidadeController
    {
        // Preload our schema..
        PnLocalidade thisSchemaLoad = new PnLocalidade();
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
        public PnLocalidadeCollection FetchAll()
        {
            PnLocalidadeCollection coll = new PnLocalidadeCollection();
            Query qry = new Query(PnLocalidade.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLocalidadeCollection FetchByID(object IdLocalidad)
        {
            PnLocalidadeCollection coll = new PnLocalidadeCollection().Where("id_localidad", IdLocalidad).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLocalidadeCollection FetchByQuery(Query qry)
        {
            PnLocalidadeCollection coll = new PnLocalidadeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLocalidad)
        {
            return (PnLocalidade.Delete(IdLocalidad) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLocalidad)
        {
            return (PnLocalidade.Destroy(IdLocalidad) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Codigopostal,string Nombre,int IdDepartamento)
	    {
		    PnLocalidade item = new PnLocalidade();
		    
            item.Codigopostal = Codigopostal;
            
            item.Nombre = Nombre;
            
            item.IdDepartamento = IdDepartamento;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLocalidad,string Codigopostal,string Nombre,int IdDepartamento)
	    {
		    PnLocalidade item = new PnLocalidade();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLocalidad = IdLocalidad;
				
			item.Codigopostal = Codigopostal;
				
			item.Nombre = Nombre;
				
			item.IdDepartamento = IdDepartamento;
				
	        item.Save(UserName);
	    }
    }
}
