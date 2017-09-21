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
    /// Controller class for Sys_Barrio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysBarrioController
    {
        // Preload our schema..
        SysBarrio thisSchemaLoad = new SysBarrio();
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
        public SysBarrioCollection FetchAll()
        {
            SysBarrioCollection coll = new SysBarrioCollection();
            Query qry = new Query(SysBarrio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysBarrioCollection FetchByID(object IdBarrio)
        {
            SysBarrioCollection coll = new SysBarrioCollection().Where("idBarrio", IdBarrio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysBarrioCollection FetchByQuery(Query qry)
        {
            SysBarrioCollection coll = new SysBarrioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdBarrio)
        {
            return (SysBarrio.Delete(IdBarrio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdBarrio)
        {
            return (SysBarrio.Destroy(IdBarrio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int? IdLocalidad,string CodigoIndec)
	    {
		    SysBarrio item = new SysBarrio();
		    
            item.Nombre = Nombre;
            
            item.IdLocalidad = IdLocalidad;
            
            item.CodigoIndec = CodigoIndec;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdBarrio,string Nombre,int? IdLocalidad,string CodigoIndec)
	    {
		    SysBarrio item = new SysBarrio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdBarrio = IdBarrio;
				
			item.Nombre = Nombre;
				
			item.IdLocalidad = IdLocalidad;
				
			item.CodigoIndec = CodigoIndec;
				
	        item.Save(UserName);
	    }
    }
}
