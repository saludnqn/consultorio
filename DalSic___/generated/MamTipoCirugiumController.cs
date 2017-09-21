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
    /// Controller class for MAM_TipoCirugia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamTipoCirugiumController
    {
        // Preload our schema..
        MamTipoCirugium thisSchemaLoad = new MamTipoCirugium();
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
        public MamTipoCirugiumCollection FetchAll()
        {
            MamTipoCirugiumCollection coll = new MamTipoCirugiumCollection();
            Query qry = new Query(MamTipoCirugium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTipoCirugiumCollection FetchByID(object IdTipoCirugia)
        {
            MamTipoCirugiumCollection coll = new MamTipoCirugiumCollection().Where("idTipoCirugia", IdTipoCirugia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamTipoCirugiumCollection FetchByQuery(Query qry)
        {
            MamTipoCirugiumCollection coll = new MamTipoCirugiumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoCirugia)
        {
            return (MamTipoCirugium.Delete(IdTipoCirugia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoCirugia)
        {
            return (MamTipoCirugium.Destroy(IdTipoCirugia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamTipoCirugium item = new MamTipoCirugium();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoCirugia,string Descripcion)
	    {
		    MamTipoCirugium item = new MamTipoCirugium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoCirugia = IdTipoCirugia;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
