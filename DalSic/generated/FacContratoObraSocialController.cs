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
    /// Controller class for FAC_ContratoObraSocial
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class FacContratoObraSocialController
    {
        // Preload our schema..
        FacContratoObraSocial thisSchemaLoad = new FacContratoObraSocial();
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
        public FacContratoObraSocialCollection FetchAll()
        {
            FacContratoObraSocialCollection coll = new FacContratoObraSocialCollection();
            Query qry = new Query(FacContratoObraSocial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacContratoObraSocialCollection FetchByID(object IdContratoObraSocial)
        {
            FacContratoObraSocialCollection coll = new FacContratoObraSocialCollection().Where("idContratoObraSocial", IdContratoObraSocial).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacContratoObraSocialCollection FetchByQuery(Query qry)
        {
            FacContratoObraSocialCollection coll = new FacContratoObraSocialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdContratoObraSocial)
        {
            return (FacContratoObraSocial.Delete(IdContratoObraSocial) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdContratoObraSocial)
        {
            return (FacContratoObraSocial.Destroy(IdContratoObraSocial) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdTipoNomenclador,int IdObraSocial)
	    {
		    FacContratoObraSocial item = new FacContratoObraSocial();
		    
            item.IdTipoNomenclador = IdTipoNomenclador;
            
            item.IdObraSocial = IdObraSocial;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdContratoObraSocial,int IdTipoNomenclador,int IdObraSocial)
	    {
		    FacContratoObraSocial item = new FacContratoObraSocial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdContratoObraSocial = IdContratoObraSocial;
				
			item.IdTipoNomenclador = IdTipoNomenclador;
				
			item.IdObraSocial = IdObraSocial;
				
	        item.Save(UserName);
	    }
    }
}
