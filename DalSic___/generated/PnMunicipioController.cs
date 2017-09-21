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
    /// Controller class for PN_municipios
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnMunicipioController
    {
        // Preload our schema..
        PnMunicipio thisSchemaLoad = new PnMunicipio();
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
        public PnMunicipioCollection FetchAll()
        {
            PnMunicipioCollection coll = new PnMunicipioCollection();
            Query qry = new Query(PnMunicipio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMunicipioCollection FetchByID(object IdMunicipio)
        {
            PnMunicipioCollection coll = new PnMunicipioCollection().Where("id_municipio", IdMunicipio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMunicipioCollection FetchByQuery(Query qry)
        {
            PnMunicipioCollection coll = new PnMunicipioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMunicipio)
        {
            return (PnMunicipio.Delete(IdMunicipio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMunicipio)
        {
            return (PnMunicipio.Destroy(IdMunicipio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdLocalidad)
	    {
		    PnMunicipio item = new PnMunicipio();
		    
            item.Nombre = Nombre;
            
            item.IdLocalidad = IdLocalidad;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMunicipio,string Nombre,int IdLocalidad)
	    {
		    PnMunicipio item = new PnMunicipio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMunicipio = IdMunicipio;
				
			item.Nombre = Nombre;
				
			item.IdLocalidad = IdLocalidad;
				
	        item.Save(UserName);
	    }
    }
}
