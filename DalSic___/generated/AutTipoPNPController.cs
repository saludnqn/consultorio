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
    /// Controller class for Aut_TipoPNP
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AutTipoPNPController
    {
        // Preload our schema..
        AutTipoPNP thisSchemaLoad = new AutTipoPNP();
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
        public AutTipoPNPCollection FetchAll()
        {
            AutTipoPNPCollection coll = new AutTipoPNPCollection();
            Query qry = new Query(AutTipoPNP.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AutTipoPNPCollection FetchByID(object IdTipoPMP)
        {
            AutTipoPNPCollection coll = new AutTipoPNPCollection().Where("idTipoPMP", IdTipoPMP).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AutTipoPNPCollection FetchByQuery(Query qry)
        {
            AutTipoPNPCollection coll = new AutTipoPNPCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTipoPMP)
        {
            return (AutTipoPNP.Delete(IdTipoPMP) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTipoPMP)
        {
            return (AutTipoPNP.Destroy(IdTipoPMP) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdTipoPMP,string Nombre)
	    {
		    AutTipoPNP item = new AutTipoPNP();
		    
            item.IdTipoPMP = IdTipoPMP;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTipoPMP,string Nombre)
	    {
		    AutTipoPNP item = new AutTipoPNP();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTipoPMP = IdTipoPMP;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
