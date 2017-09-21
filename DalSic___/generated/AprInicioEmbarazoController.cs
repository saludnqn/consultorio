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
    /// Controller class for APR_InicioEmbarazo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprInicioEmbarazoController
    {
        // Preload our schema..
        AprInicioEmbarazo thisSchemaLoad = new AprInicioEmbarazo();
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
        public AprInicioEmbarazoCollection FetchAll()
        {
            AprInicioEmbarazoCollection coll = new AprInicioEmbarazoCollection();
            Query qry = new Query(AprInicioEmbarazo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprInicioEmbarazoCollection FetchByID(object IdInicioEmabarazo)
        {
            AprInicioEmbarazoCollection coll = new AprInicioEmbarazoCollection().Where("idInicioEmabarazo", IdInicioEmabarazo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprInicioEmbarazoCollection FetchByQuery(Query qry)
        {
            AprInicioEmbarazoCollection coll = new AprInicioEmbarazoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInicioEmabarazo)
        {
            return (AprInicioEmbarazo.Delete(IdInicioEmabarazo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInicioEmabarazo)
        {
            return (AprInicioEmbarazo.Destroy(IdInicioEmabarazo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprInicioEmbarazo item = new AprInicioEmbarazo();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInicioEmabarazo,string Nombre)
	    {
		    AprInicioEmbarazo item = new AprInicioEmbarazo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInicioEmabarazo = IdInicioEmabarazo;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
