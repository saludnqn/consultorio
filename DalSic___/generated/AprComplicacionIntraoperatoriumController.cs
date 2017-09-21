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
    /// Controller class for APR_ComplicacionIntraoperatoria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprComplicacionIntraoperatoriumController
    {
        // Preload our schema..
        AprComplicacionIntraoperatorium thisSchemaLoad = new AprComplicacionIntraoperatorium();
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
        public AprComplicacionIntraoperatoriumCollection FetchAll()
        {
            AprComplicacionIntraoperatoriumCollection coll = new AprComplicacionIntraoperatoriumCollection();
            Query qry = new Query(AprComplicacionIntraoperatorium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprComplicacionIntraoperatoriumCollection FetchByID(object IdComplicacionIntraoperatoria)
        {
            AprComplicacionIntraoperatoriumCollection coll = new AprComplicacionIntraoperatoriumCollection().Where("idComplicacionIntraoperatoria", IdComplicacionIntraoperatoria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprComplicacionIntraoperatoriumCollection FetchByQuery(Query qry)
        {
            AprComplicacionIntraoperatoriumCollection coll = new AprComplicacionIntraoperatoriumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdComplicacionIntraoperatoria)
        {
            return (AprComplicacionIntraoperatorium.Delete(IdComplicacionIntraoperatoria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdComplicacionIntraoperatoria)
        {
            return (AprComplicacionIntraoperatorium.Destroy(IdComplicacionIntraoperatoria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int DTipoComplicacionIntraoperatoria,string Nombre)
	    {
		    AprComplicacionIntraoperatorium item = new AprComplicacionIntraoperatorium();
		    
            item.DTipoComplicacionIntraoperatoria = DTipoComplicacionIntraoperatoria;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdComplicacionIntraoperatoria,int DTipoComplicacionIntraoperatoria,string Nombre)
	    {
		    AprComplicacionIntraoperatorium item = new AprComplicacionIntraoperatorium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdComplicacionIntraoperatoria = IdComplicacionIntraoperatoria;
				
			item.DTipoComplicacionIntraoperatoria = DTipoComplicacionIntraoperatoria;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
