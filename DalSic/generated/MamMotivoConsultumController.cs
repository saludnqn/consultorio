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
    /// Controller class for MAM_MotivoConsulta
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamMotivoConsultumController
    {
        // Preload our schema..
        MamMotivoConsultum thisSchemaLoad = new MamMotivoConsultum();
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
        public MamMotivoConsultumCollection FetchAll()
        {
            MamMotivoConsultumCollection coll = new MamMotivoConsultumCollection();
            Query qry = new Query(MamMotivoConsultum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamMotivoConsultumCollection FetchByID(object IdMotivoConsulta)
        {
            MamMotivoConsultumCollection coll = new MamMotivoConsultumCollection().Where("idMotivoConsulta", IdMotivoConsulta).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamMotivoConsultumCollection FetchByQuery(Query qry)
        {
            MamMotivoConsultumCollection coll = new MamMotivoConsultumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivoConsulta)
        {
            return (MamMotivoConsultum.Delete(IdMotivoConsulta) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivoConsulta)
        {
            return (MamMotivoConsultum.Destroy(IdMotivoConsulta) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdTipoMotivoConsulta)
	    {
		    MamMotivoConsultum item = new MamMotivoConsultum();
		    
            item.Nombre = Nombre;
            
            item.IdTipoMotivoConsulta = IdTipoMotivoConsulta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivoConsulta,string Nombre,int IdTipoMotivoConsulta)
	    {
		    MamMotivoConsultum item = new MamMotivoConsultum();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivoConsulta = IdMotivoConsulta;
				
			item.Nombre = Nombre;
				
			item.IdTipoMotivoConsulta = IdTipoMotivoConsulta;
				
	        item.Save(UserName);
	    }
    }
}
