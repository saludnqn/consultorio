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
    /// Controller class for PN_dosis_apli
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDosisApliController
    {
        // Preload our schema..
        PnDosisApli thisSchemaLoad = new PnDosisApli();
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
        public PnDosisApliCollection FetchAll()
        {
            PnDosisApliCollection coll = new PnDosisApliCollection();
            Query qry = new Query(PnDosisApli.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDosisApliCollection FetchByID(object IdDosisApli)
        {
            PnDosisApliCollection coll = new PnDosisApliCollection().Where("id_dosis_apli", IdDosisApli).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDosisApliCollection FetchByQuery(Query qry)
        {
            PnDosisApliCollection coll = new PnDosisApliCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDosisApli)
        {
            return (PnDosisApli.Delete(IdDosisApli) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDosisApli)
        {
            return (PnDosisApli.Destroy(IdDosisApli) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    PnDosisApli item = new PnDosisApli();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDosisApli,string Nombre)
	    {
		    PnDosisApli item = new PnDosisApli();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDosisApli = IdDosisApli;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
