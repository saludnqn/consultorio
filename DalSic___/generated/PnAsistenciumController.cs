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
    /// Controller class for PN_asistencia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAsistenciumController
    {
        // Preload our schema..
        PnAsistencium thisSchemaLoad = new PnAsistencium();
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
        public PnAsistenciumCollection FetchAll()
        {
            PnAsistenciumCollection coll = new PnAsistenciumCollection();
            Query qry = new Query(PnAsistencium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAsistenciumCollection FetchByID(object IdAsistencia)
        {
            PnAsistenciumCollection coll = new PnAsistenciumCollection().Where("id_asistencia", IdAsistencia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAsistenciumCollection FetchByQuery(Query qry)
        {
            PnAsistenciumCollection coll = new PnAsistenciumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAsistencia)
        {
            return (PnAsistencium.Delete(IdAsistencia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAsistencia)
        {
            return (PnAsistencium.Destroy(IdAsistencia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdLegajo,int? IdUsuario,DateTime Fecha,string HoraEntra,string HoraSale,int? IdServidor)
	    {
		    PnAsistencium item = new PnAsistencium();
		    
            item.IdLegajo = IdLegajo;
            
            item.IdUsuario = IdUsuario;
            
            item.Fecha = Fecha;
            
            item.HoraEntra = HoraEntra;
            
            item.HoraSale = HoraSale;
            
            item.IdServidor = IdServidor;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAsistencia,int? IdLegajo,int? IdUsuario,DateTime Fecha,string HoraEntra,string HoraSale,int? IdServidor)
	    {
		    PnAsistencium item = new PnAsistencium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAsistencia = IdAsistencia;
				
			item.IdLegajo = IdLegajo;
				
			item.IdUsuario = IdUsuario;
				
			item.Fecha = Fecha;
				
			item.HoraEntra = HoraEntra;
				
			item.HoraSale = HoraSale;
				
			item.IdServidor = IdServidor;
				
	        item.Save(UserName);
	    }
    }
}
