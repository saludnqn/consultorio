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
    /// Controller class for Rem_Agente
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemAgenteController
    {
        // Preload our schema..
        RemAgente thisSchemaLoad = new RemAgente();
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
        public RemAgenteCollection FetchAll()
        {
            RemAgenteCollection coll = new RemAgenteCollection();
            Query qry = new Query(RemAgente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemAgenteCollection FetchByID(object IdAgente)
        {
            RemAgenteCollection coll = new RemAgenteCollection().Where("idAgente", IdAgente).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemAgenteCollection FetchByQuery(Query qry)
        {
            RemAgenteCollection coll = new RemAgenteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAgente)
        {
            return (RemAgente.Delete(IdAgente) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAgente)
        {
            return (RemAgente.Destroy(IdAgente) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Apellido,string Nombre,int Codigo,bool Activo,string NombreCompleto)
	    {
		    RemAgente item = new RemAgente();
		    
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.Codigo = Codigo;
            
            item.Activo = Activo;
            
            item.NombreCompleto = NombreCompleto;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAgente,string Apellido,string Nombre,int Codigo,bool Activo,string NombreCompleto)
	    {
		    RemAgente item = new RemAgente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAgente = IdAgente;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.Codigo = Codigo;
				
			item.Activo = Activo;
				
			item.NombreCompleto = NombreCompleto;
				
	        item.Save(UserName);
	    }
    }
}
