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
    /// Controller class for PN_tipo_documento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTipoDocumentoController
    {
        // Preload our schema..
        PnTipoDocumento thisSchemaLoad = new PnTipoDocumento();
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
        public PnTipoDocumentoCollection FetchAll()
        {
            PnTipoDocumentoCollection coll = new PnTipoDocumentoCollection();
            Query qry = new Query(PnTipoDocumento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTipoDocumentoCollection FetchByID(object IdTipoDocumento)
        {
            PnTipoDocumentoCollection coll = new PnTipoDocumentoCollection().Where("id_tipo_documento", IdTipoDocumento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTipoDocumentoCollection FetchByQuery(Query qry)
        {
            PnTipoDocumentoCollection coll = new PnTipoDocumentoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoDocumento)
        {
            return (PnTipoDocumento.Delete(IdTipoDocumento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoDocumento)
        {
            return (PnTipoDocumento.Destroy(IdTipoDocumento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Tipo,string Descripcion,int IdBeneficiario)
	    {
		    PnTipoDocumento item = new PnTipoDocumento();
		    
            item.Tipo = Tipo;
            
            item.Descripcion = Descripcion;
            
            item.IdBeneficiario = IdBeneficiario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoDocumento,string Tipo,string Descripcion,int IdBeneficiario)
	    {
		    PnTipoDocumento item = new PnTipoDocumento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoDocumento = IdTipoDocumento;
				
			item.Tipo = Tipo;
				
			item.Descripcion = Descripcion;
				
			item.IdBeneficiario = IdBeneficiario;
				
	        item.Save(UserName);
	    }
    }
}
