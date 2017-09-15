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
    /// Controller class for CON_Equipo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConEquipoController
    {
        // Preload our schema..
        ConEquipo thisSchemaLoad = new ConEquipo();
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
        public ConEquipoCollection FetchAll()
        {
            ConEquipoCollection coll = new ConEquipoCollection();
            Query qry = new Query(ConEquipo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConEquipoCollection FetchByID(object IdEquipo)
        {
            ConEquipoCollection coll = new ConEquipoCollection().Where("idEquipo", IdEquipo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConEquipoCollection FetchByQuery(Query qry)
        {
            ConEquipoCollection coll = new ConEquipoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEquipo)
        {
            return (ConEquipo.Delete(IdEquipo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEquipo)
        {
            return (ConEquipo.Destroy(IdEquipo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConEquipo item = new ConEquipo();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEquipo,string Nombre)
	    {
		    ConEquipo item = new ConEquipo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEquipo = IdEquipo;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
