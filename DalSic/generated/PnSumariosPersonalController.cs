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
    /// Controller class for PN_sumarios_personal
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnSumariosPersonalController
    {
        // Preload our schema..
        PnSumariosPersonal thisSchemaLoad = new PnSumariosPersonal();
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
        public PnSumariosPersonalCollection FetchAll()
        {
            PnSumariosPersonalCollection coll = new PnSumariosPersonalCollection();
            Query qry = new Query(PnSumariosPersonal.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSumariosPersonalCollection FetchByID(object IdSumarioPersonal)
        {
            PnSumariosPersonalCollection coll = new PnSumariosPersonalCollection().Where("id_sumario_personal", IdSumarioPersonal).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSumariosPersonalCollection FetchByQuery(Query qry)
        {
            PnSumariosPersonalCollection coll = new PnSumariosPersonalCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSumarioPersonal)
        {
            return (PnSumariosPersonal.Delete(IdSumarioPersonal) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSumarioPersonal)
        {
            return (PnSumariosPersonal.Destroy(IdSumarioPersonal) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime? Fecha,string Titulo,string Descripcion,int IdLegajo)
	    {
		    PnSumariosPersonal item = new PnSumariosPersonal();
		    
            item.Fecha = Fecha;
            
            item.Titulo = Titulo;
            
            item.Descripcion = Descripcion;
            
            item.IdLegajo = IdLegajo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSumarioPersonal,DateTime? Fecha,string Titulo,string Descripcion,int IdLegajo)
	    {
		    PnSumariosPersonal item = new PnSumariosPersonal();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSumarioPersonal = IdSumarioPersonal;
				
			item.Fecha = Fecha;
				
			item.Titulo = Titulo;
				
			item.Descripcion = Descripcion;
				
			item.IdLegajo = IdLegajo;
				
	        item.Save(UserName);
	    }
    }
}
