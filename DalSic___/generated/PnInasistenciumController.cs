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
    /// Controller class for PN_inasistencia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnInasistenciumController
    {
        // Preload our schema..
        PnInasistencium thisSchemaLoad = new PnInasistencium();
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
        public PnInasistenciumCollection FetchAll()
        {
            PnInasistenciumCollection coll = new PnInasistenciumCollection();
            Query qry = new Query(PnInasistencium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnInasistenciumCollection FetchByID(object IdInasistencia)
        {
            PnInasistenciumCollection coll = new PnInasistenciumCollection().Where("id_inasistencia", IdInasistencia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnInasistenciumCollection FetchByQuery(Query qry)
        {
            PnInasistenciumCollection coll = new PnInasistenciumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInasistencia)
        {
            return (PnInasistencium.Delete(IdInasistencia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInasistencia)
        {
            return (PnInasistencium.Destroy(IdInasistencia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUsuario,string Comentario,DateTime? Fecha,short? TipoJustificacion)
	    {
		    PnInasistencium item = new PnInasistencium();
		    
            item.IdUsuario = IdUsuario;
            
            item.Comentario = Comentario;
            
            item.Fecha = Fecha;
            
            item.TipoJustificacion = TipoJustificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInasistencia,int IdUsuario,string Comentario,DateTime? Fecha,short? TipoJustificacion)
	    {
		    PnInasistencium item = new PnInasistencium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInasistencia = IdInasistencia;
				
			item.IdUsuario = IdUsuario;
				
			item.Comentario = Comentario;
				
			item.Fecha = Fecha;
				
			item.TipoJustificacion = TipoJustificacion;
				
	        item.Save(UserName);
	    }
    }
}
