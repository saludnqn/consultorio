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
    /// Controller class for PN_mail_efe_conv
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnMailEfeConvController
    {
        // Preload our schema..
        PnMailEfeConv thisSchemaLoad = new PnMailEfeConv();
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
        public PnMailEfeConvCollection FetchAll()
        {
            PnMailEfeConvCollection coll = new PnMailEfeConvCollection();
            Query qry = new Query(PnMailEfeConv.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMailEfeConvCollection FetchByID(object IdMailEfeConv)
        {
            PnMailEfeConvCollection coll = new PnMailEfeConvCollection().Where("id_mail_efe_conv", IdMailEfeConv).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMailEfeConvCollection FetchByQuery(Query qry)
        {
            PnMailEfeConvCollection coll = new PnMailEfeConvCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMailEfeConv)
        {
            return (PnMailEfeConv.Delete(IdMailEfeConv) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMailEfeConv)
        {
            return (PnMailEfeConv.Destroy(IdMailEfeConv) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Descripcion,string Mail)
	    {
		    PnMailEfeConv item = new PnMailEfeConv();
		    
            item.Cuie = Cuie;
            
            item.Descripcion = Descripcion;
            
            item.Mail = Mail;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMailEfeConv,string Cuie,string Descripcion,string Mail)
	    {
		    PnMailEfeConv item = new PnMailEfeConv();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMailEfeConv = IdMailEfeConv;
				
			item.Cuie = Cuie;
				
			item.Descripcion = Descripcion;
				
			item.Mail = Mail;
				
	        item.Save(UserName);
	    }
    }
}
