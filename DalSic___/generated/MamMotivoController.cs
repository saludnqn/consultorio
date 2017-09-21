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
    /// Controller class for MAM_Motivo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamMotivoController
    {
        // Preload our schema..
        MamMotivo thisSchemaLoad = new MamMotivo();
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
        public MamMotivoCollection FetchAll()
        {
            MamMotivoCollection coll = new MamMotivoCollection();
            Query qry = new Query(MamMotivo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamMotivoCollection FetchByID(object IdMotivo)
        {
            MamMotivoCollection coll = new MamMotivoCollection().Where("idMotivo", IdMotivo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamMotivoCollection FetchByQuery(Query qry)
        {
            MamMotivoCollection coll = new MamMotivoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivo)
        {
            return (MamMotivo.Delete(IdMotivo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivo)
        {
            return (MamMotivo.Destroy(IdMotivo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamMotivo item = new MamMotivo();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivo,string Descripcion)
	    {
		    MamMotivo item = new MamMotivo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivo = IdMotivo;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
