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
    /// Controller class for LAB_Reactivo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabReactivoController
    {
        // Preload our schema..
        LabReactivo thisSchemaLoad = new LabReactivo();
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
        public LabReactivoCollection FetchAll()
        {
            LabReactivoCollection coll = new LabReactivoCollection();
            Query qry = new Query(LabReactivo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabReactivoCollection FetchByID(object IdReactivo)
        {
            LabReactivoCollection coll = new LabReactivoCollection().Where("idReactivo", IdReactivo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabReactivoCollection FetchByQuery(Query qry)
        {
            LabReactivoCollection coll = new LabReactivoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdReactivo)
        {
            return (LabReactivo.Delete(IdReactivo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdReactivo)
        {
            return (LabReactivo.Destroy(IdReactivo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdArea)
	    {
		    LabReactivo item = new LabReactivo();
		    
            item.Nombre = Nombre;
            
            item.IdArea = IdArea;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdReactivo,string Nombre,int IdArea)
	    {
		    LabReactivo item = new LabReactivo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdReactivo = IdReactivo;
				
			item.Nombre = Nombre;
				
			item.IdArea = IdArea;
				
	        item.Save(UserName);
	    }
    }
}
