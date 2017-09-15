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
    /// Controller class for MAM_ResultadoExFisico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamResultadoExFisicoController
    {
        // Preload our schema..
        MamResultadoExFisico thisSchemaLoad = new MamResultadoExFisico();
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
        public MamResultadoExFisicoCollection FetchAll()
        {
            MamResultadoExFisicoCollection coll = new MamResultadoExFisicoCollection();
            Query qry = new Query(MamResultadoExFisico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamResultadoExFisicoCollection FetchByID(object IdResultadoExFisico)
        {
            MamResultadoExFisicoCollection coll = new MamResultadoExFisicoCollection().Where("idResultadoExFisico", IdResultadoExFisico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamResultadoExFisicoCollection FetchByQuery(Query qry)
        {
            MamResultadoExFisicoCollection coll = new MamResultadoExFisicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdResultadoExFisico)
        {
            return (MamResultadoExFisico.Delete(IdResultadoExFisico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdResultadoExFisico)
        {
            return (MamResultadoExFisico.Destroy(IdResultadoExFisico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,bool Activo)
	    {
		    MamResultadoExFisico item = new MamResultadoExFisico();
		    
            item.Nombre = Nombre;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdResultadoExFisico,string Nombre,bool Activo)
	    {
		    MamResultadoExFisico item = new MamResultadoExFisico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdResultadoExFisico = IdResultadoExFisico;
				
			item.Nombre = Nombre;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
