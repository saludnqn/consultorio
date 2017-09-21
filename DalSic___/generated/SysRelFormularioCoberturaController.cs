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
    /// Controller class for Sys_RelFormularioCobertura
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysRelFormularioCoberturaController
    {
        // Preload our schema..
        SysRelFormularioCobertura thisSchemaLoad = new SysRelFormularioCobertura();
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
        public SysRelFormularioCoberturaCollection FetchAll()
        {
            SysRelFormularioCoberturaCollection coll = new SysRelFormularioCoberturaCollection();
            Query qry = new Query(SysRelFormularioCobertura.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelFormularioCoberturaCollection FetchByID(object IdRelFormularioCobertura)
        {
            SysRelFormularioCoberturaCollection coll = new SysRelFormularioCoberturaCollection().Where("idRelFormularioCobertura", IdRelFormularioCobertura).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysRelFormularioCoberturaCollection FetchByQuery(Query qry)
        {
            SysRelFormularioCoberturaCollection coll = new SysRelFormularioCoberturaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelFormularioCobertura)
        {
            return (SysRelFormularioCobertura.Delete(IdRelFormularioCobertura) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelFormularioCobertura)
        {
            return (SysRelFormularioCobertura.Destroy(IdRelFormularioCobertura) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdFormulario,int IdTipoCobertura)
	    {
		    SysRelFormularioCobertura item = new SysRelFormularioCobertura();
		    
            item.IdFormulario = IdFormulario;
            
            item.IdTipoCobertura = IdTipoCobertura;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelFormularioCobertura,int IdFormulario,int IdTipoCobertura)
	    {
		    SysRelFormularioCobertura item = new SysRelFormularioCobertura();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelFormularioCobertura = IdRelFormularioCobertura;
				
			item.IdFormulario = IdFormulario;
				
			item.IdTipoCobertura = IdTipoCobertura;
				
	        item.Save(UserName);
	    }
    }
}
