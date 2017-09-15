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
    /// Controller class for PN_log_pac_pap
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnLogPacPapController
    {
        // Preload our schema..
        PnLogPacPap thisSchemaLoad = new PnLogPacPap();
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
        public PnLogPacPapCollection FetchAll()
        {
            PnLogPacPapCollection coll = new PnLogPacPapCollection();
            Query qry = new Query(PnLogPacPap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogPacPapCollection FetchByID(object IdLogPacPap)
        {
            PnLogPacPapCollection coll = new PnLogPacPapCollection().Where("id_log_pac_pap", IdLogPacPap).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnLogPacPapCollection FetchByQuery(Query qry)
        {
            PnLogPacPapCollection coll = new PnLogPacPapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLogPacPap)
        {
            return (PnLogPacPap.Delete(IdLogPacPap) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLogPacPap)
        {
            return (PnLogPacPap.Destroy(IdLogPacPap) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPacPap,DateTime? Fecha,string Usuario,string Tipo,string Forma)
	    {
		    PnLogPacPap item = new PnLogPacPap();
		    
            item.IdPacPap = IdPacPap;
            
            item.Fecha = Fecha;
            
            item.Usuario = Usuario;
            
            item.Tipo = Tipo;
            
            item.Forma = Forma;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdLogPacPap,int IdPacPap,DateTime? Fecha,string Usuario,string Tipo,string Forma)
	    {
		    PnLogPacPap item = new PnLogPacPap();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdLogPacPap = IdLogPacPap;
				
			item.IdPacPap = IdPacPap;
				
			item.Fecha = Fecha;
				
			item.Usuario = Usuario;
				
			item.Tipo = Tipo;
				
			item.Forma = Forma;
				
	        item.Save(UserName);
	    }
    }
}
