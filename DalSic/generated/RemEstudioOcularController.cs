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
    /// Controller class for Rem_EstudioOcular
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemEstudioOcularController
    {
        // Preload our schema..
        RemEstudioOcular thisSchemaLoad = new RemEstudioOcular();
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
        public RemEstudioOcularCollection FetchAll()
        {
            RemEstudioOcularCollection coll = new RemEstudioOcularCollection();
            Query qry = new Query(RemEstudioOcular.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemEstudioOcularCollection FetchByID(object IdEstudioOcular)
        {
            RemEstudioOcularCollection coll = new RemEstudioOcularCollection().Where("idEstudioOcular", IdEstudioOcular).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemEstudioOcularCollection FetchByQuery(Query qry)
        {
            RemEstudioOcularCollection coll = new RemEstudioOcularCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioOcular)
        {
            return (RemEstudioOcular.Delete(IdEstudioOcular) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioOcular)
        {
            return (RemEstudioOcular.Destroy(IdEstudioOcular) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdClasificacion,bool OIRpHipertensiva,bool OIRpDNoProliferativo,bool OIRpDProliferativo,bool OIRpDRetina,bool ODRpHipertensiva,bool ODRpDNoProliferativo,bool ODRpDProliferativo,bool ODRpDRetina)
	    {
		    RemEstudioOcular item = new RemEstudioOcular();
		    
            item.IdClasificacion = IdClasificacion;
            
            item.OIRpHipertensiva = OIRpHipertensiva;
            
            item.OIRpDNoProliferativo = OIRpDNoProliferativo;
            
            item.OIRpDProliferativo = OIRpDProliferativo;
            
            item.OIRpDRetina = OIRpDRetina;
            
            item.ODRpHipertensiva = ODRpHipertensiva;
            
            item.ODRpDNoProliferativo = ODRpDNoProliferativo;
            
            item.ODRpDProliferativo = ODRpDProliferativo;
            
            item.ODRpDRetina = ODRpDRetina;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioOcular,int IdClasificacion,bool OIRpHipertensiva,bool OIRpDNoProliferativo,bool OIRpDProliferativo,bool OIRpDRetina,bool ODRpHipertensiva,bool ODRpDNoProliferativo,bool ODRpDProliferativo,bool ODRpDRetina)
	    {
		    RemEstudioOcular item = new RemEstudioOcular();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioOcular = IdEstudioOcular;
				
			item.IdClasificacion = IdClasificacion;
				
			item.OIRpHipertensiva = OIRpHipertensiva;
				
			item.OIRpDNoProliferativo = OIRpDNoProliferativo;
				
			item.OIRpDProliferativo = OIRpDProliferativo;
				
			item.OIRpDRetina = OIRpDRetina;
				
			item.ODRpHipertensiva = ODRpHipertensiva;
				
			item.ODRpDNoProliferativo = ODRpDNoProliferativo;
				
			item.ODRpDProliferativo = ODRpDProliferativo;
				
			item.ODRpDRetina = ODRpDRetina;
				
	        item.Save(UserName);
	    }
    }
}
