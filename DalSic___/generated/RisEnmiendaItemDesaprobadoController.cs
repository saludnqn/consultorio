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
    /// Controller class for RIS_EnmiendaItemDesaprobado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEnmiendaItemDesaprobadoController
    {
        // Preload our schema..
        RisEnmiendaItemDesaprobado thisSchemaLoad = new RisEnmiendaItemDesaprobado();
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
        public RisEnmiendaItemDesaprobadoCollection FetchAll()
        {
            RisEnmiendaItemDesaprobadoCollection coll = new RisEnmiendaItemDesaprobadoCollection();
            Query qry = new Query(RisEnmiendaItemDesaprobado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEnmiendaItemDesaprobadoCollection FetchByID(object IdEnmiendaItemDesaprobado)
        {
            RisEnmiendaItemDesaprobadoCollection coll = new RisEnmiendaItemDesaprobadoCollection().Where("idEnmiendaItemDesaprobado", IdEnmiendaItemDesaprobado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEnmiendaItemDesaprobadoCollection FetchByQuery(Query qry)
        {
            RisEnmiendaItemDesaprobadoCollection coll = new RisEnmiendaItemDesaprobadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEnmiendaItemDesaprobado)
        {
            return (RisEnmiendaItemDesaprobado.Delete(IdEnmiendaItemDesaprobado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEnmiendaItemDesaprobado)
        {
            return (RisEnmiendaItemDesaprobado.Destroy(IdEnmiendaItemDesaprobado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEnmienda,int IdItemDesaprobado)
	    {
		    RisEnmiendaItemDesaprobado item = new RisEnmiendaItemDesaprobado();
		    
            item.IdEnmienda = IdEnmienda;
            
            item.IdItemDesaprobado = IdItemDesaprobado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEnmiendaItemDesaprobado,int IdEnmienda,int IdItemDesaprobado)
	    {
		    RisEnmiendaItemDesaprobado item = new RisEnmiendaItemDesaprobado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEnmiendaItemDesaprobado = IdEnmiendaItemDesaprobado;
				
			item.IdEnmienda = IdEnmienda;
				
			item.IdItemDesaprobado = IdItemDesaprobado;
				
	        item.Save(UserName);
	    }
    }
}
