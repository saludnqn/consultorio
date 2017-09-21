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
    /// Controller class for PN_dpto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDptoController
    {
        // Preload our schema..
        PnDpto thisSchemaLoad = new PnDpto();
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
        public PnDptoCollection FetchAll()
        {
            PnDptoCollection coll = new PnDptoCollection();
            Query qry = new Query(PnDpto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDptoCollection FetchByID(object IdDpto)
        {
            PnDptoCollection coll = new PnDptoCollection().Where("id_dpto", IdDpto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDptoCollection FetchByQuery(Query qry)
        {
            PnDptoCollection coll = new PnDptoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDpto)
        {
            return (PnDpto.Delete(IdDpto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDpto)
        {
            return (PnDpto.Destroy(IdDpto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Codigo,int? InsCompAnual)
	    {
		    PnDpto item = new PnDpto();
		    
            item.Nombre = Nombre;
            
            item.Codigo = Codigo;
            
            item.InsCompAnual = InsCompAnual;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDpto,string Nombre,string Codigo,int? InsCompAnual)
	    {
		    PnDpto item = new PnDpto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDpto = IdDpto;
				
			item.Nombre = Nombre;
				
			item.Codigo = Codigo;
				
			item.InsCompAnual = InsCompAnual;
				
	        item.Save(UserName);
	    }
    }
}
