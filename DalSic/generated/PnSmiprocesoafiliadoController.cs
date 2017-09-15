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
    /// Controller class for PN_smiprocesoafiliados
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnSmiprocesoafiliadoController
    {
        // Preload our schema..
        PnSmiprocesoafiliado thisSchemaLoad = new PnSmiprocesoafiliado();
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
        public PnSmiprocesoafiliadoCollection FetchAll()
        {
            PnSmiprocesoafiliadoCollection coll = new PnSmiprocesoafiliadoCollection();
            Query qry = new Query(PnSmiprocesoafiliado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmiprocesoafiliadoCollection FetchByID(object IdProcafiliado)
        {
            PnSmiprocesoafiliadoCollection coll = new PnSmiprocesoafiliadoCollection().Where("id_procafiliado", IdProcafiliado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmiprocesoafiliadoCollection FetchByQuery(Query qry)
        {
            PnSmiprocesoafiliadoCollection coll = new PnSmiprocesoafiliadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProcafiliado)
        {
            return (PnSmiprocesoafiliado.Delete(IdProcafiliado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProcafiliado)
        {
            return (PnSmiprocesoafiliado.Destroy(IdProcafiliado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Periodo,string Codigocialtadatos)
	    {
		    PnSmiprocesoafiliado item = new PnSmiprocesoafiliado();
		    
            item.Periodo = Periodo;
            
            item.Codigocialtadatos = Codigocialtadatos;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProcafiliado,string Periodo,string Codigocialtadatos)
	    {
		    PnSmiprocesoafiliado item = new PnSmiprocesoafiliado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProcafiliado = IdProcafiliado;
				
			item.Periodo = Periodo;
				
			item.Codigocialtadatos = Codigocialtadatos;
				
	        item.Save(UserName);
	    }
    }
}
