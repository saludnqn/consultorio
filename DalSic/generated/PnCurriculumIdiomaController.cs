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
    /// Controller class for PN_curriculum_idiomas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCurriculumIdiomaController
    {
        // Preload our schema..
        PnCurriculumIdioma thisSchemaLoad = new PnCurriculumIdioma();
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
        public PnCurriculumIdiomaCollection FetchAll()
        {
            PnCurriculumIdiomaCollection coll = new PnCurriculumIdiomaCollection();
            Query qry = new Query(PnCurriculumIdioma.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCurriculumIdiomaCollection FetchByID(object IdCurriculumIdiomas)
        {
            PnCurriculumIdiomaCollection coll = new PnCurriculumIdiomaCollection().Where("id_curriculum_idiomas", IdCurriculumIdiomas).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCurriculumIdiomaCollection FetchByQuery(Query qry)
        {
            PnCurriculumIdiomaCollection coll = new PnCurriculumIdiomaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCurriculumIdiomas)
        {
            return (PnCurriculumIdioma.Delete(IdCurriculumIdiomas) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCurriculumIdiomas)
        {
            return (PnCurriculumIdioma.Destroy(IdCurriculumIdiomas) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdLegajo,string Idioma,string Lee,string Escribe)
	    {
		    PnCurriculumIdioma item = new PnCurriculumIdioma();
		    
            item.IdLegajo = IdLegajo;
            
            item.Idioma = Idioma;
            
            item.Lee = Lee;
            
            item.Escribe = Escribe;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCurriculumIdiomas,int IdLegajo,string Idioma,string Lee,string Escribe)
	    {
		    PnCurriculumIdioma item = new PnCurriculumIdioma();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCurriculumIdiomas = IdCurriculumIdiomas;
				
			item.IdLegajo = IdLegajo;
				
			item.Idioma = Idioma;
				
			item.Lee = Lee;
				
			item.Escribe = Escribe;
				
	        item.Save(UserName);
	    }
    }
}
