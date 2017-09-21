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
    /// Controller class for LAB_Acceso
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabAccesoController
    {
        // Preload our schema..
        LabAcceso thisSchemaLoad = new LabAcceso();
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
        public LabAccesoCollection FetchAll()
        {
            LabAccesoCollection coll = new LabAccesoCollection();
            Query qry = new Query(LabAcceso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabAccesoCollection FetchByID(object IdAcceso)
        {
            LabAccesoCollection coll = new LabAccesoCollection().Where("idAcceso", IdAcceso).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabAccesoCollection FetchByQuery(Query qry)
        {
            LabAccesoCollection coll = new LabAccesoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAcceso)
        {
            return (LabAcceso.Delete(IdAcceso) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAcceso)
        {
            return (LabAcceso.Destroy(IdAcceso) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUsuario,DateTime FechaUltimoAcceso)
	    {
		    LabAcceso item = new LabAcceso();
		    
            item.IdUsuario = IdUsuario;
            
            item.FechaUltimoAcceso = FechaUltimoAcceso;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAcceso,int IdUsuario,DateTime FechaUltimoAcceso)
	    {
		    LabAcceso item = new LabAcceso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAcceso = IdAcceso;
				
			item.IdUsuario = IdUsuario;
				
			item.FechaUltimoAcceso = FechaUltimoAcceso;
				
	        item.Save(UserName);
	    }
    }
}
