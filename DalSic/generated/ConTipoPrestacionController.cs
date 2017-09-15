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
    /// Controller class for CON_TipoPrestacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTipoPrestacionController
    {
        // Preload our schema..
        ConTipoPrestacion thisSchemaLoad = new ConTipoPrestacion();
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
        public ConTipoPrestacionCollection FetchAll()
        {
            ConTipoPrestacionCollection coll = new ConTipoPrestacionCollection();
            Query qry = new Query(ConTipoPrestacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTipoPrestacionCollection FetchByID(object IdTipoPrestacion)
        {
            ConTipoPrestacionCollection coll = new ConTipoPrestacionCollection().Where("idTipoPrestacion", IdTipoPrestacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTipoPrestacionCollection FetchByQuery(Query qry)
        {
            ConTipoPrestacionCollection coll = new ConTipoPrestacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoPrestacion)
        {
            return (ConTipoPrestacion.Delete(IdTipoPrestacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoPrestacion)
        {
            return (ConTipoPrestacion.Destroy(IdTipoPrestacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConTipoPrestacion item = new ConTipoPrestacion();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoPrestacion,string Nombre)
	    {
		    ConTipoPrestacion item = new ConTipoPrestacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoPrestacion = IdTipoPrestacion;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
