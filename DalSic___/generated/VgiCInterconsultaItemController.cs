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
    /// Controller class for VGI_CInterconsultaItems
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class VgiCInterconsultaItemController
    {
        // Preload our schema..
        VgiCInterconsultaItem thisSchemaLoad = new VgiCInterconsultaItem();
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
        public VgiCInterconsultaItemCollection FetchAll()
        {
            VgiCInterconsultaItemCollection coll = new VgiCInterconsultaItemCollection();
            Query qry = new Query(VgiCInterconsultaItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public VgiCInterconsultaItemCollection FetchByID(object IdCInterconsultaItems)
        {
            VgiCInterconsultaItemCollection coll = new VgiCInterconsultaItemCollection().Where("idCInterconsultaItems", IdCInterconsultaItems).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public VgiCInterconsultaItemCollection FetchByQuery(Query qry)
        {
            VgiCInterconsultaItemCollection coll = new VgiCInterconsultaItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCInterconsultaItems)
        {
            return (VgiCInterconsultaItem.Delete(IdCInterconsultaItems) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCInterconsultaItems)
        {
            return (VgiCInterconsultaItem.Destroy(IdCInterconsultaItems) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdItems,string Nombre,int? Valor,string CInterconsulta)
	    {
		    VgiCInterconsultaItem item = new VgiCInterconsultaItem();
		    
            item.IdItems = IdItems;
            
            item.Nombre = Nombre;
            
            item.Valor = Valor;
            
            item.CInterconsulta = CInterconsulta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCInterconsultaItems,int? IdItems,string Nombre,int? Valor,string CInterconsulta)
	    {
		    VgiCInterconsultaItem item = new VgiCInterconsultaItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCInterconsultaItems = IdCInterconsultaItems;
				
			item.IdItems = IdItems;
				
			item.Nombre = Nombre;
				
			item.Valor = Valor;
				
			item.CInterconsulta = CInterconsulta;
				
	        item.Save(UserName);
	    }
    }
}
