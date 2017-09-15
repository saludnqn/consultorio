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
    /// Controller class for APR_FactorRiesgoPsicosocial
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprFactorRiesgoPsicosocialController
    {
        // Preload our schema..
        AprFactorRiesgoPsicosocial thisSchemaLoad = new AprFactorRiesgoPsicosocial();
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
        public AprFactorRiesgoPsicosocialCollection FetchAll()
        {
            AprFactorRiesgoPsicosocialCollection coll = new AprFactorRiesgoPsicosocialCollection();
            Query qry = new Query(AprFactorRiesgoPsicosocial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFactorRiesgoPsicosocialCollection FetchByID(object IdFactorRiesgoPsicosocial)
        {
            AprFactorRiesgoPsicosocialCollection coll = new AprFactorRiesgoPsicosocialCollection().Where("idFactorRiesgoPsicosocial", IdFactorRiesgoPsicosocial).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprFactorRiesgoPsicosocialCollection FetchByQuery(Query qry)
        {
            AprFactorRiesgoPsicosocialCollection coll = new AprFactorRiesgoPsicosocialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFactorRiesgoPsicosocial)
        {
            return (AprFactorRiesgoPsicosocial.Delete(IdFactorRiesgoPsicosocial) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFactorRiesgoPsicosocial)
        {
            return (AprFactorRiesgoPsicosocial.Destroy(IdFactorRiesgoPsicosocial) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    AprFactorRiesgoPsicosocial item = new AprFactorRiesgoPsicosocial();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFactorRiesgoPsicosocial,string Nombre)
	    {
		    AprFactorRiesgoPsicosocial item = new AprFactorRiesgoPsicosocial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFactorRiesgoPsicosocial = IdFactorRiesgoPsicosocial;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
