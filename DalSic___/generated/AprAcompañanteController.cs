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
    /// Controller class for APR_Acompañante
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprAcompañanteController
    {
        // Preload our schema..
        AprAcompañante thisSchemaLoad = new AprAcompañante();
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
        public AprAcompañanteCollection FetchAll()
        {
            AprAcompañanteCollection coll = new AprAcompañanteCollection();
            Query qry = new Query(AprAcompañante.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAcompañanteCollection FetchByID(object IdAcompañante)
        {
            AprAcompañanteCollection coll = new AprAcompañanteCollection().Where("idAcompañante", IdAcompañante).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprAcompañanteCollection FetchByQuery(Query qry)
        {
            AprAcompañanteCollection coll = new AprAcompañanteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAcompañante)
        {
            return (AprAcompañante.Delete(IdAcompañante) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAcompañante)
        {
            return (AprAcompañante.Destroy(IdAcompañante) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprAcompañante item = new AprAcompañante();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAcompañante,string Nombre)
	    {
		    AprAcompañante item = new AprAcompañante();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAcompañante = IdAcompañante;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
