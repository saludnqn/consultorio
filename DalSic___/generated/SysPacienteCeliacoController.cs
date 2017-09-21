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
    /// Controller class for Sys_PacienteCeliaco
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysPacienteCeliacoController
    {
        // Preload our schema..
        SysPacienteCeliaco thisSchemaLoad = new SysPacienteCeliaco();
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
        public SysPacienteCeliacoCollection FetchAll()
        {
            SysPacienteCeliacoCollection coll = new SysPacienteCeliacoCollection();
            Query qry = new Query(SysPacienteCeliaco.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPacienteCeliacoCollection FetchByID(object IdPacienteCeliaco)
        {
            SysPacienteCeliacoCollection coll = new SysPacienteCeliacoCollection().Where("idPacienteCeliaco", IdPacienteCeliaco).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPacienteCeliacoCollection FetchByQuery(Query qry)
        {
            SysPacienteCeliacoCollection coll = new SysPacienteCeliacoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPacienteCeliaco)
        {
            return (SysPacienteCeliaco.Delete(IdPacienteCeliaco) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPacienteCeliaco)
        {
            return (SysPacienteCeliaco.Destroy(IdPacienteCeliaco) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,string Activo,DateTime FechaAlta)
	    {
		    SysPacienteCeliaco item = new SysPacienteCeliaco();
		    
            item.IdPaciente = IdPaciente;
            
            item.Activo = Activo;
            
            item.FechaAlta = FechaAlta;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPacienteCeliaco,int IdPaciente,string Activo,DateTime FechaAlta)
	    {
		    SysPacienteCeliaco item = new SysPacienteCeliaco();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPacienteCeliaco = IdPacienteCeliaco;
				
			item.IdPaciente = IdPaciente;
				
			item.Activo = Activo;
				
			item.FechaAlta = FechaAlta;
				
	        item.Save(UserName);
	    }
    }
}
