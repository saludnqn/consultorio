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
    /// Controller class for PN_indicadores_globales
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnIndicadoresGlobaleController
    {
        // Preload our schema..
        PnIndicadoresGlobale thisSchemaLoad = new PnIndicadoresGlobale();
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
        public PnIndicadoresGlobaleCollection FetchAll()
        {
            PnIndicadoresGlobaleCollection coll = new PnIndicadoresGlobaleCollection();
            Query qry = new Query(PnIndicadoresGlobale.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIndicadoresGlobaleCollection FetchByID(object IdIndicadoresGlobales)
        {
            PnIndicadoresGlobaleCollection coll = new PnIndicadoresGlobaleCollection().Where("id_indicadores_globales", IdIndicadoresGlobales).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIndicadoresGlobaleCollection FetchByQuery(Query qry)
        {
            PnIndicadoresGlobaleCollection coll = new PnIndicadoresGlobaleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIndicadoresGlobales)
        {
            return (PnIndicadoresGlobale.Delete(IdIndicadoresGlobales) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIndicadoresGlobales)
        {
            return (PnIndicadoresGlobale.Destroy(IdIndicadoresGlobales) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,decimal? Valor,string Observaciones)
	    {
		    PnIndicadoresGlobale item = new PnIndicadoresGlobale();
		    
            item.Descripcion = Descripcion;
            
            item.Valor = Valor;
            
            item.Observaciones = Observaciones;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIndicadoresGlobales,string Descripcion,decimal? Valor,string Observaciones)
	    {
		    PnIndicadoresGlobale item = new PnIndicadoresGlobale();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIndicadoresGlobales = IdIndicadoresGlobales;
				
			item.Descripcion = Descripcion;
				
			item.Valor = Valor;
				
			item.Observaciones = Observaciones;
				
	        item.Save(UserName);
	    }
    }
}
