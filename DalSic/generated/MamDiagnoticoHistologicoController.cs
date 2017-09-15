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
    /// Controller class for MAM_DiagnoticoHistologico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MamDiagnoticoHistologicoController
    {
        // Preload our schema..
        MamDiagnoticoHistologico thisSchemaLoad = new MamDiagnoticoHistologico();
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
        public MamDiagnoticoHistologicoCollection FetchAll()
        {
            MamDiagnoticoHistologicoCollection coll = new MamDiagnoticoHistologicoCollection();
            Query qry = new Query(MamDiagnoticoHistologico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamDiagnoticoHistologicoCollection FetchByID(object IdDiagnosticoHistologico)
        {
            MamDiagnoticoHistologicoCollection coll = new MamDiagnoticoHistologicoCollection().Where("idDiagnosticoHistologico", IdDiagnosticoHistologico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MamDiagnoticoHistologicoCollection FetchByQuery(Query qry)
        {
            MamDiagnoticoHistologicoCollection coll = new MamDiagnoticoHistologicoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDiagnosticoHistologico)
        {
            return (MamDiagnoticoHistologico.Delete(IdDiagnosticoHistologico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDiagnosticoHistologico)
        {
            return (MamDiagnoticoHistologico.Destroy(IdDiagnosticoHistologico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    MamDiagnoticoHistologico item = new MamDiagnoticoHistologico();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDiagnosticoHistologico,string Descripcion)
	    {
		    MamDiagnoticoHistologico item = new MamDiagnoticoHistologico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDiagnosticoHistologico = IdDiagnosticoHistologico;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
