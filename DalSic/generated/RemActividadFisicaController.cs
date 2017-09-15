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
    /// Controller class for Rem_ActividadFisica
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemActividadFisicaController
    {
        // Preload our schema..
        RemActividadFisica thisSchemaLoad = new RemActividadFisica();
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
        public RemActividadFisicaCollection FetchAll()
        {
            RemActividadFisicaCollection coll = new RemActividadFisicaCollection();
            Query qry = new Query(RemActividadFisica.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemActividadFisicaCollection FetchByID(object IdActividadFisica)
        {
            RemActividadFisicaCollection coll = new RemActividadFisicaCollection().Where("idActividadFisica", IdActividadFisica).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemActividadFisicaCollection FetchByQuery(Query qry)
        {
            RemActividadFisicaCollection coll = new RemActividadFisicaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdActividadFisica)
        {
            return (RemActividadFisica.Delete(IdActividadFisica) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdActividadFisica)
        {
            return (RemActividadFisica.Destroy(IdActividadFisica) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    RemActividadFisica item = new RemActividadFisica();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdActividadFisica,string Nombre)
	    {
		    RemActividadFisica item = new RemActividadFisica();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdActividadFisica = IdActividadFisica;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
