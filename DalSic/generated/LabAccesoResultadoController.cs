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
    /// Controller class for LAB_AccesoResultado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabAccesoResultadoController
    {
        // Preload our schema..
        LabAccesoResultado thisSchemaLoad = new LabAccesoResultado();
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
        public LabAccesoResultadoCollection FetchAll()
        {
            LabAccesoResultadoCollection coll = new LabAccesoResultadoCollection();
            Query qry = new Query(LabAccesoResultado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabAccesoResultadoCollection FetchByID(object IdAccesoResultado)
        {
            LabAccesoResultadoCollection coll = new LabAccesoResultadoCollection().Where("idAccesoResultado", IdAccesoResultado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabAccesoResultadoCollection FetchByQuery(Query qry)
        {
            LabAccesoResultadoCollection coll = new LabAccesoResultadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAccesoResultado)
        {
            return (LabAccesoResultado.Delete(IdAccesoResultado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAccesoResultado)
        {
            return (LabAccesoResultado.Destroy(IdAccesoResultado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdUsuario,DateTime Fecha,int NumeroDocumento,string NumeroProtocolo)
	    {
		    LabAccesoResultado item = new LabAccesoResultado();
		    
            item.IdUsuario = IdUsuario;
            
            item.Fecha = Fecha;
            
            item.NumeroDocumento = NumeroDocumento;
            
            item.NumeroProtocolo = NumeroProtocolo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAccesoResultado,int IdUsuario,DateTime Fecha,int NumeroDocumento,string NumeroProtocolo)
	    {
		    LabAccesoResultado item = new LabAccesoResultado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAccesoResultado = IdAccesoResultado;
				
			item.IdUsuario = IdUsuario;
				
			item.Fecha = Fecha;
				
			item.NumeroDocumento = NumeroDocumento;
				
			item.NumeroProtocolo = NumeroProtocolo;
				
	        item.Save(UserName);
	    }
    }
}
