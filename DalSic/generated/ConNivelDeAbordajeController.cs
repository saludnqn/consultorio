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
    /// Controller class for CON_NivelDeAbordaje
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConNivelDeAbordajeController
    {
        // Preload our schema..
        ConNivelDeAbordaje thisSchemaLoad = new ConNivelDeAbordaje();
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
        public ConNivelDeAbordajeCollection FetchAll()
        {
            ConNivelDeAbordajeCollection coll = new ConNivelDeAbordajeCollection();
            Query qry = new Query(ConNivelDeAbordaje.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConNivelDeAbordajeCollection FetchByID(object IdNivelDeAbordaje)
        {
            ConNivelDeAbordajeCollection coll = new ConNivelDeAbordajeCollection().Where("idNivelDeAbordaje", IdNivelDeAbordaje).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConNivelDeAbordajeCollection FetchByQuery(Query qry)
        {
            ConNivelDeAbordajeCollection coll = new ConNivelDeAbordajeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNivelDeAbordaje)
        {
            return (ConNivelDeAbordaje.Delete(IdNivelDeAbordaje) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNivelDeAbordaje)
        {
            return (ConNivelDeAbordaje.Destroy(IdNivelDeAbordaje) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConNivelDeAbordaje item = new ConNivelDeAbordaje();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNivelDeAbordaje,string Nombre)
	    {
		    ConNivelDeAbordaje item = new ConNivelDeAbordaje();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNivelDeAbordaje = IdNivelDeAbordaje;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
