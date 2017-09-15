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
    /// Controller class for APR_TipoProfesional
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprTipoProfesionalController
    {
        // Preload our schema..
        AprTipoProfesional thisSchemaLoad = new AprTipoProfesional();
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
        public AprTipoProfesionalCollection FetchAll()
        {
            AprTipoProfesionalCollection coll = new AprTipoProfesionalCollection();
            Query qry = new Query(AprTipoProfesional.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTipoProfesionalCollection FetchByID(object IdTipoProfesional)
        {
            AprTipoProfesionalCollection coll = new AprTipoProfesionalCollection().Where("idTipoProfesional", IdTipoProfesional).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprTipoProfesionalCollection FetchByQuery(Query qry)
        {
            AprTipoProfesionalCollection coll = new AprTipoProfesionalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoProfesional)
        {
            return (AprTipoProfesional.Delete(IdTipoProfesional) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoProfesional)
        {
            return (AprTipoProfesional.Destroy(IdTipoProfesional) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprTipoProfesional item = new AprTipoProfesional();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoProfesional,string Nombre)
	    {
		    AprTipoProfesional item = new AprTipoProfesional();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoProfesional = IdTipoProfesional;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
