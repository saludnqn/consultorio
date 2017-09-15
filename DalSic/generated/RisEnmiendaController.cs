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
    /// Controller class for RIS_Enmienda
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEnmiendaController
    {
        // Preload our schema..
        RisEnmienda thisSchemaLoad = new RisEnmienda();
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
        public RisEnmiendaCollection FetchAll()
        {
            RisEnmiendaCollection coll = new RisEnmiendaCollection();
            Query qry = new Query(RisEnmienda.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEnmiendaCollection FetchByID(object IdEnmienda)
        {
            RisEnmiendaCollection coll = new RisEnmiendaCollection().Where("idEnmienda", IdEnmienda).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEnmiendaCollection FetchByQuery(Query qry)
        {
            RisEnmiendaCollection coll = new RisEnmiendaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEnmienda)
        {
            return (RisEnmienda.Delete(IdEnmienda) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEnmienda)
        {
            return (RisEnmienda.Destroy(IdEnmienda) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,string Modificacion,string Dictamen,DateTime? FechaDictamen,string Observaciones)
	    {
		    RisEnmienda item = new RisEnmienda();
		    
            item.IdEstudio = IdEstudio;
            
            item.Modificacion = Modificacion;
            
            item.Dictamen = Dictamen;
            
            item.FechaDictamen = FechaDictamen;
            
            item.Observaciones = Observaciones;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEnmienda,int IdEstudio,string Modificacion,string Dictamen,DateTime? FechaDictamen,string Observaciones)
	    {
		    RisEnmienda item = new RisEnmienda();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEnmienda = IdEnmienda;
				
			item.IdEstudio = IdEstudio;
				
			item.Modificacion = Modificacion;
				
			item.Dictamen = Dictamen;
				
			item.FechaDictamen = FechaDictamen;
				
			item.Observaciones = Observaciones;
				
	        item.Save(UserName);
	    }
    }
}
