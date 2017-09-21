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
    /// Controller class for MAM_DiagnosticoCitologico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamDiagnosticoCitologicoController
    {
        // Preload our schema..
        MamDiagnosticoCitologico thisSchemaLoad = new MamDiagnosticoCitologico();
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
        public MamDiagnosticoCitologicoCollection FetchAll()
        {
            MamDiagnosticoCitologicoCollection coll = new MamDiagnosticoCitologicoCollection();
            Query qry = new Query(MamDiagnosticoCitologico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamDiagnosticoCitologicoCollection FetchByID(object IdDiagnosticoCitologico)
        {
            MamDiagnosticoCitologicoCollection coll = new MamDiagnosticoCitologicoCollection().Where("idDiagnosticoCitologico", IdDiagnosticoCitologico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamDiagnosticoCitologicoCollection FetchByQuery(Query qry)
        {
            MamDiagnosticoCitologicoCollection coll = new MamDiagnosticoCitologicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDiagnosticoCitologico)
        {
            return (MamDiagnosticoCitologico.Delete(IdDiagnosticoCitologico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDiagnosticoCitologico)
        {
            return (MamDiagnosticoCitologico.Destroy(IdDiagnosticoCitologico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamDiagnosticoCitologico item = new MamDiagnosticoCitologico();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDiagnosticoCitologico,string Descripcion)
	    {
		    MamDiagnosticoCitologico item = new MamDiagnosticoCitologico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDiagnosticoCitologico = IdDiagnosticoCitologico;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
