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
    /// Controller class for Guardia_Turnero
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class GuardiaTurneroController
    {
        // Preload our schema..
        GuardiaTurnero thisSchemaLoad = new GuardiaTurnero();
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
        public GuardiaTurneroCollection FetchAll()
        {
            GuardiaTurneroCollection coll = new GuardiaTurneroCollection();
            Query qry = new Query(GuardiaTurnero.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTurneroCollection FetchByID(object Nombre)
        {
            GuardiaTurneroCollection coll = new GuardiaTurneroCollection().Where("nombre", Nombre).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public GuardiaTurneroCollection FetchByQuery(Query qry)
        {
            GuardiaTurneroCollection coll = new GuardiaTurneroCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Nombre)
        {
            return (GuardiaTurnero.Delete(Nombre) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Nombre)
        {
            return (GuardiaTurnero.Destroy(Nombre) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int? ValorInt,string ValorString)
	    {
		    GuardiaTurnero item = new GuardiaTurnero();
		    
            item.Nombre = Nombre;
            
            item.ValorInt = ValorInt;
            
            item.ValorString = ValorString;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Nombre,int? ValorInt,string ValorString)
	    {
		    GuardiaTurnero item = new GuardiaTurnero();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Nombre = Nombre;
				
			item.ValorInt = ValorInt;
				
			item.ValorString = ValorString;
				
	        item.Save(UserName);
	    }
    }
}
