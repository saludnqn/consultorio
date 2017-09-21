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
    /// Controller class for AUT_Historico_Vehiculo_PMP
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AutHistoricoVehiculoPmpController
    {
        // Preload our schema..
        AutHistoricoVehiculoPmp thisSchemaLoad = new AutHistoricoVehiculoPmp();
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
        public AutHistoricoVehiculoPmpCollection FetchAll()
        {
            AutHistoricoVehiculoPmpCollection coll = new AutHistoricoVehiculoPmpCollection();
            Query qry = new Query(AutHistoricoVehiculoPmp.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AutHistoricoVehiculoPmpCollection FetchByID(object IdHistoricoVehiculoPMP)
        {
            AutHistoricoVehiculoPmpCollection coll = new AutHistoricoVehiculoPmpCollection().Where("idHistoricoVehiculoPMP", IdHistoricoVehiculoPMP).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AutHistoricoVehiculoPmpCollection FetchByQuery(Query qry)
        {
            AutHistoricoVehiculoPmpCollection coll = new AutHistoricoVehiculoPmpCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdHistoricoVehiculoPMP)
        {
            return (AutHistoricoVehiculoPmp.Delete(IdHistoricoVehiculoPMP) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdHistoricoVehiculoPMP)
        {
            return (AutHistoricoVehiculoPmp.Destroy(IdHistoricoVehiculoPMP) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdVehiculoPMP,DateTime Fecha,int Kilometraje)
	    {
		    AutHistoricoVehiculoPmp item = new AutHistoricoVehiculoPmp();
		    
            item.IdVehiculoPMP = IdVehiculoPMP;
            
            item.Fecha = Fecha;
            
            item.Kilometraje = Kilometraje;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdHistoricoVehiculoPMP,int IdVehiculoPMP,DateTime Fecha,int Kilometraje)
	    {
		    AutHistoricoVehiculoPmp item = new AutHistoricoVehiculoPmp();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdHistoricoVehiculoPMP = IdHistoricoVehiculoPMP;
				
			item.IdVehiculoPMP = IdVehiculoPMP;
				
			item.Fecha = Fecha;
				
			item.Kilometraje = Kilometraje;
				
	        item.Save(UserName);
	    }
    }
}
