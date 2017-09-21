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
    /// Controller class for FAC_JefeLaboratorio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class FacJefeLaboratorioController
    {
        // Preload our schema..
        FacJefeLaboratorio thisSchemaLoad = new FacJefeLaboratorio();
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
        public FacJefeLaboratorioCollection FetchAll()
        {
            FacJefeLaboratorioCollection coll = new FacJefeLaboratorioCollection();
            Query qry = new Query(FacJefeLaboratorio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacJefeLaboratorioCollection FetchByID(object IdJefeLaboratorio)
        {
            FacJefeLaboratorioCollection coll = new FacJefeLaboratorioCollection().Where("idJefeLaboratorio", IdJefeLaboratorio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public FacJefeLaboratorioCollection FetchByQuery(Query qry)
        {
            FacJefeLaboratorioCollection coll = new FacJefeLaboratorioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdJefeLaboratorio)
        {
            return (FacJefeLaboratorio.Delete(IdJefeLaboratorio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdJefeLaboratorio)
        {
            return (FacJefeLaboratorio.Destroy(IdJefeLaboratorio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdProfesional,bool Baja)
	    {
		    FacJefeLaboratorio item = new FacJefeLaboratorio();
		    
            item.IdEfector = IdEfector;
            
            item.IdProfesional = IdProfesional;
            
            item.Baja = Baja;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdJefeLaboratorio,int IdEfector,int IdProfesional,bool Baja)
	    {
		    FacJefeLaboratorio item = new FacJefeLaboratorio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdJefeLaboratorio = IdJefeLaboratorio;
				
			item.IdEfector = IdEfector;
				
			item.IdProfesional = IdProfesional;
				
			item.Baja = Baja;
				
	        item.Save(UserName);
	    }
    }
}
