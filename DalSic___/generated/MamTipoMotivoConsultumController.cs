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
    /// Controller class for MAM_TipoMotivoConsulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamTipoMotivoConsultumController
    {
        // Preload our schema..
        MamTipoMotivoConsultum thisSchemaLoad = new MamTipoMotivoConsultum();
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
        public MamTipoMotivoConsultumCollection FetchAll()
        {
            MamTipoMotivoConsultumCollection coll = new MamTipoMotivoConsultumCollection();
            Query qry = new Query(MamTipoMotivoConsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTipoMotivoConsultumCollection FetchByID(object IdTipoMotivoConsulta)
        {
            MamTipoMotivoConsultumCollection coll = new MamTipoMotivoConsultumCollection().Where("idTipoMotivoConsulta", IdTipoMotivoConsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTipoMotivoConsultumCollection FetchByQuery(Query qry)
        {
            MamTipoMotivoConsultumCollection coll = new MamTipoMotivoConsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoMotivoConsulta)
        {
            return (MamTipoMotivoConsultum.Delete(IdTipoMotivoConsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoMotivoConsulta)
        {
            return (MamTipoMotivoConsultum.Destroy(IdTipoMotivoConsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamTipoMotivoConsultum item = new MamTipoMotivoConsultum();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoMotivoConsulta,string Descripcion)
	    {
		    MamTipoMotivoConsultum item = new MamTipoMotivoConsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoMotivoConsulta = IdTipoMotivoConsulta;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
