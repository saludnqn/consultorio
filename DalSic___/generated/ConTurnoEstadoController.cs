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
    /// Controller class for CON_TurnoEstado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConTurnoEstadoController
    {
        // Preload our schema..
        ConTurnoEstado thisSchemaLoad = new ConTurnoEstado();
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
        public ConTurnoEstadoCollection FetchAll()
        {
            ConTurnoEstadoCollection coll = new ConTurnoEstadoCollection();
            Query qry = new Query(ConTurnoEstado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoEstadoCollection FetchByID(object IdTurnoEstado)
        {
            ConTurnoEstadoCollection coll = new ConTurnoEstadoCollection().Where("idTurnoEstado", IdTurnoEstado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConTurnoEstadoCollection FetchByQuery(Query qry)
        {
            ConTurnoEstadoCollection coll = new ConTurnoEstadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTurnoEstado)
        {
            return (ConTurnoEstado.Delete(IdTurnoEstado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTurnoEstado)
        {
            return (ConTurnoEstado.Destroy(IdTurnoEstado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Accion,string ImagenComando,string NombreComando)
	    {
		    ConTurnoEstado item = new ConTurnoEstado();
		    
            item.Nombre = Nombre;
            
            item.Accion = Accion;
            
            item.ImagenComando = ImagenComando;
            
            item.NombreComando = NombreComando;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTurnoEstado,string Nombre,string Accion,string ImagenComando,string NombreComando)
	    {
		    ConTurnoEstado item = new ConTurnoEstado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTurnoEstado = IdTurnoEstado;
				
			item.Nombre = Nombre;
				
			item.Accion = Accion;
				
			item.ImagenComando = ImagenComando;
				
			item.NombreComando = NombreComando;
				
	        item.Save(UserName);
	    }
    }
}
