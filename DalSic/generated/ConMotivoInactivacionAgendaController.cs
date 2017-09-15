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
    /// Controller class for CON_MotivoInactivacionAgenda
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConMotivoInactivacionAgendaController
    {
        // Preload our schema..
        ConMotivoInactivacionAgenda thisSchemaLoad = new ConMotivoInactivacionAgenda();
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
        public ConMotivoInactivacionAgendaCollection FetchAll()
        {
            ConMotivoInactivacionAgendaCollection coll = new ConMotivoInactivacionAgendaCollection();
            Query qry = new Query(ConMotivoInactivacionAgenda.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConMotivoInactivacionAgendaCollection FetchByID(object IdMotivoInactivacion)
        {
            ConMotivoInactivacionAgendaCollection coll = new ConMotivoInactivacionAgendaCollection().Where("idMotivoInactivacion", IdMotivoInactivacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConMotivoInactivacionAgendaCollection FetchByQuery(Query qry)
        {
            ConMotivoInactivacionAgendaCollection coll = new ConMotivoInactivacionAgendaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMotivoInactivacion)
        {
            return (ConMotivoInactivacionAgenda.Delete(IdMotivoInactivacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMotivoInactivacion)
        {
            return (ConMotivoInactivacionAgenda.Destroy(IdMotivoInactivacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    ConMotivoInactivacionAgenda item = new ConMotivoInactivacionAgenda();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMotivoInactivacion,string Descripcion)
	    {
		    ConMotivoInactivacionAgenda item = new ConMotivoInactivacionAgenda();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMotivoInactivacion = IdMotivoInactivacion;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
