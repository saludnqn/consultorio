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
    /// Controller class for PN_indicadores_ins
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnIndicadoresInController
    {
        // Preload our schema..
        PnIndicadoresIn thisSchemaLoad = new PnIndicadoresIn();
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
        public PnIndicadoresInCollection FetchAll()
        {
            PnIndicadoresInCollection coll = new PnIndicadoresInCollection();
            Query qry = new Query(PnIndicadoresIn.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIndicadoresInCollection FetchByID(object IdIndicadoresIns)
        {
            PnIndicadoresInCollection coll = new PnIndicadoresInCollection().Where("id_indicadores_ins", IdIndicadoresIns).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnIndicadoresInCollection FetchByQuery(Query qry)
        {
            PnIndicadoresInCollection coll = new PnIndicadoresInCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdIndicadoresIns)
        {
            return (PnIndicadoresIn.Delete(IdIndicadoresIns) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdIndicadoresIns)
        {
            return (PnIndicadoresIn.Destroy(IdIndicadoresIns) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdDescIndicadorIns,int? Mes,int? Anio,decimal? Valor)
	    {
		    PnIndicadoresIn item = new PnIndicadoresIn();
		    
            item.IdDescIndicadorIns = IdDescIndicadorIns;
            
            item.Mes = Mes;
            
            item.Anio = Anio;
            
            item.Valor = Valor;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdIndicadoresIns,int IdDescIndicadorIns,int? Mes,int? Anio,decimal? Valor)
	    {
		    PnIndicadoresIn item = new PnIndicadoresIn();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdIndicadoresIns = IdIndicadoresIns;
				
			item.IdDescIndicadorIns = IdDescIndicadorIns;
				
			item.Mes = Mes;
				
			item.Anio = Anio;
				
			item.Valor = Valor;
				
	        item.Save(UserName);
	    }
    }
}
