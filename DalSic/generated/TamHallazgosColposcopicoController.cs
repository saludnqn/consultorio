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
    /// Controller class for TAM_HallazgosColposcopicos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TamHallazgosColposcopicoController
    {
        // Preload our schema..
        TamHallazgosColposcopico thisSchemaLoad = new TamHallazgosColposcopico();
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
        public TamHallazgosColposcopicoCollection FetchAll()
        {
            TamHallazgosColposcopicoCollection coll = new TamHallazgosColposcopicoCollection();
            Query qry = new Query(TamHallazgosColposcopico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TamHallazgosColposcopicoCollection FetchByID(object IdHallazgosColposcopicos)
        {
            TamHallazgosColposcopicoCollection coll = new TamHallazgosColposcopicoCollection().Where("idHallazgosColposcopicos", IdHallazgosColposcopicos).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TamHallazgosColposcopicoCollection FetchByQuery(Query qry)
        {
            TamHallazgosColposcopicoCollection coll = new TamHallazgosColposcopicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdHallazgosColposcopicos)
        {
            return (TamHallazgosColposcopico.Delete(IdHallazgosColposcopicos) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdHallazgosColposcopicos)
        {
            return (TamHallazgosColposcopico.Destroy(IdHallazgosColposcopicos) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    TamHallazgosColposcopico item = new TamHallazgosColposcopico();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdHallazgosColposcopicos,string Nombre)
	    {
		    TamHallazgosColposcopico item = new TamHallazgosColposcopico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdHallazgosColposcopicos = IdHallazgosColposcopicos;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
