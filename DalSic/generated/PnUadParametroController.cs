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
    /// Controller class for PN_uad_parametros
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnUadParametroController
    {
        // Preload our schema..
        PnUadParametro thisSchemaLoad = new PnUadParametro();
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
        public PnUadParametroCollection FetchAll()
        {
            PnUadParametroCollection coll = new PnUadParametroCollection();
            Query qry = new Query(PnUadParametro.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnUadParametroCollection FetchByID(object IdParametros)
        {
            PnUadParametroCollection coll = new PnUadParametroCollection().Where("id_parametros", IdParametros).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnUadParametroCollection FetchByQuery(Query qry)
        {
            PnUadParametroCollection coll = new PnUadParametroCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdParametros)
        {
            return (PnUadParametro.Delete(IdParametros) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdParametros)
        {
            return (PnUadParametro.Destroy(IdParametros) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CodigoProvincia,string CodigoUad,string NombreUad,string CodigoCi,string NombreCi,string NombreProvincia)
	    {
		    PnUadParametro item = new PnUadParametro();
		    
            item.CodigoProvincia = CodigoProvincia;
            
            item.CodigoUad = CodigoUad;
            
            item.NombreUad = NombreUad;
            
            item.CodigoCi = CodigoCi;
            
            item.NombreCi = NombreCi;
            
            item.NombreProvincia = NombreProvincia;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdParametros,string CodigoProvincia,string CodigoUad,string NombreUad,string CodigoCi,string NombreCi,string NombreProvincia)
	    {
		    PnUadParametro item = new PnUadParametro();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdParametros = IdParametros;
				
			item.CodigoProvincia = CodigoProvincia;
				
			item.CodigoUad = CodigoUad;
				
			item.NombreUad = NombreUad;
				
			item.CodigoCi = CodigoCi;
				
			item.NombreCi = NombreCi;
				
			item.NombreProvincia = NombreProvincia;
				
	        item.Save(UserName);
	    }
    }
}
