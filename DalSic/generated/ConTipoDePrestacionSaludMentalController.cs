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
    /// Controller class for CON_TipoDePrestacionSaludMental
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTipoDePrestacionSaludMentalController
    {
        // Preload our schema..
        ConTipoDePrestacionSaludMental thisSchemaLoad = new ConTipoDePrestacionSaludMental();
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
        public ConTipoDePrestacionSaludMentalCollection FetchAll()
        {
            ConTipoDePrestacionSaludMentalCollection coll = new ConTipoDePrestacionSaludMentalCollection();
            Query qry = new Query(ConTipoDePrestacionSaludMental.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTipoDePrestacionSaludMentalCollection FetchByID(object IdTipoPrestacion)
        {
            ConTipoDePrestacionSaludMentalCollection coll = new ConTipoDePrestacionSaludMentalCollection().Where("idTipoPrestacion", IdTipoPrestacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTipoDePrestacionSaludMentalCollection FetchByQuery(Query qry)
        {
            ConTipoDePrestacionSaludMentalCollection coll = new ConTipoDePrestacionSaludMentalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoPrestacion)
        {
            return (ConTipoDePrestacionSaludMental.Delete(IdTipoPrestacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoPrestacion)
        {
            return (ConTipoDePrestacionSaludMental.Destroy(IdTipoPrestacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    ConTipoDePrestacionSaludMental item = new ConTipoDePrestacionSaludMental();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoPrestacion,string Nombre)
	    {
		    ConTipoDePrestacionSaludMental item = new ConTipoDePrestacionSaludMental();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoPrestacion = IdTipoPrestacion;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
