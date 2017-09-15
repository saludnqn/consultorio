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
    /// Controller class for PN_barrios
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnBarrioController
    {
        // Preload our schema..
        PnBarrio thisSchemaLoad = new PnBarrio();
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
        public PnBarrioCollection FetchAll()
        {
            PnBarrioCollection coll = new PnBarrioCollection();
            Query qry = new Query(PnBarrio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnBarrioCollection FetchByID(object IdBarrio)
        {
            PnBarrioCollection coll = new PnBarrioCollection().Where("id_barrio", IdBarrio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnBarrioCollection FetchByQuery(Query qry)
        {
            PnBarrioCollection coll = new PnBarrioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdBarrio)
        {
            return (PnBarrio.Delete(IdBarrio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdBarrio)
        {
            return (PnBarrio.Destroy(IdBarrio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdMunicipio)
	    {
		    PnBarrio item = new PnBarrio();
		    
            item.Nombre = Nombre;
            
            item.IdMunicipio = IdMunicipio;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdBarrio,string Nombre,int IdMunicipio)
	    {
		    PnBarrio item = new PnBarrio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdBarrio = IdBarrio;
				
			item.Nombre = Nombre;
				
			item.IdMunicipio = IdMunicipio;
				
	        item.Save(UserName);
	    }
    }
}
