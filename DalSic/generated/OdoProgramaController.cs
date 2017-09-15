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
    /// Controller class for ODO_Programa
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class OdoProgramaController
    {
        // Preload our schema..
        OdoPrograma thisSchemaLoad = new OdoPrograma();
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
        public OdoProgramaCollection FetchAll()
        {
            OdoProgramaCollection coll = new OdoProgramaCollection();
            Query qry = new Query(OdoPrograma.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public OdoProgramaCollection FetchByID(object IdProgramaOdontologia)
        {
            OdoProgramaCollection coll = new OdoProgramaCollection().Where("idProgramaOdontologia", IdProgramaOdontologia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public OdoProgramaCollection FetchByQuery(Query qry)
        {
            OdoProgramaCollection coll = new OdoProgramaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProgramaOdontologia)
        {
            return (OdoPrograma.Delete(IdProgramaOdontologia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProgramaOdontologia)
        {
            return (OdoPrograma.Destroy(IdProgramaOdontologia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    OdoPrograma item = new OdoPrograma();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProgramaOdontologia,string Nombre)
	    {
		    OdoPrograma item = new OdoPrograma();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProgramaOdontologia = IdProgramaOdontologia;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
