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
    /// Controller class for TAM_Diagnostico
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TamDiagnosticoController
    {
        // Preload our schema..
        TamDiagnostico thisSchemaLoad = new TamDiagnostico();
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
        public TamDiagnosticoCollection FetchAll()
        {
            TamDiagnosticoCollection coll = new TamDiagnosticoCollection();
            Query qry = new Query(TamDiagnostico.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TamDiagnosticoCollection FetchByID(object IdDiagnostico)
        {
            TamDiagnosticoCollection coll = new TamDiagnosticoCollection().Where("idDiagnostico", IdDiagnostico).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TamDiagnosticoCollection FetchByQuery(Query qry)
        {
            TamDiagnosticoCollection coll = new TamDiagnosticoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDiagnostico)
        {
            return (TamDiagnostico.Delete(IdDiagnostico) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDiagnostico)
        {
            return (TamDiagnostico.Destroy(IdDiagnostico) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    TamDiagnostico item = new TamDiagnostico();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDiagnostico,string Nombre)
	    {
		    TamDiagnostico item = new TamDiagnostico();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDiagnostico = IdDiagnostico;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
