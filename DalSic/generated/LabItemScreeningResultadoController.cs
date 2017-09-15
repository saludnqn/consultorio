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
    /// Controller class for LAB_ItemScreeningResultado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabItemScreeningResultadoController
    {
        // Preload our schema..
        LabItemScreeningResultado thisSchemaLoad = new LabItemScreeningResultado();
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
        public LabItemScreeningResultadoCollection FetchAll()
        {
            LabItemScreeningResultadoCollection coll = new LabItemScreeningResultadoCollection();
            Query qry = new Query(LabItemScreeningResultado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabItemScreeningResultadoCollection FetchByID(object IdResultado)
        {
            LabItemScreeningResultadoCollection coll = new LabItemScreeningResultadoCollection().Where("idResultado", IdResultado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabItemScreeningResultadoCollection FetchByQuery(Query qry)
        {
            LabItemScreeningResultadoCollection coll = new LabItemScreeningResultadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdResultado)
        {
            return (LabItemScreeningResultado.Delete(IdResultado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdResultado)
        {
            return (LabItemScreeningResultado.Destroy(IdResultado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdItemScreening,string Nombre,string Abreviatura,bool Baja,int IdUsuarioRegistro,DateTime FechaRegistro,bool Pendiente)
	    {
		    LabItemScreeningResultado item = new LabItemScreeningResultado();
		    
            item.IdItemScreening = IdItemScreening;
            
            item.Nombre = Nombre;
            
            item.Abreviatura = Abreviatura;
            
            item.Baja = Baja;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
            item.Pendiente = Pendiente;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdResultado,int IdItemScreening,string Nombre,string Abreviatura,bool Baja,int IdUsuarioRegistro,DateTime FechaRegistro,bool Pendiente)
	    {
		    LabItemScreeningResultado item = new LabItemScreeningResultado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdResultado = IdResultado;
				
			item.IdItemScreening = IdItemScreening;
				
			item.Nombre = Nombre;
				
			item.Abreviatura = Abreviatura;
				
			item.Baja = Baja;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
			item.Pendiente = Pendiente;
				
	        item.Save(UserName);
	    }
    }
}
