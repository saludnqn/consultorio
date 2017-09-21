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
    /// Controller class for LAB_ItemScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabItemScreeningController
    {
        // Preload our schema..
        LabItemScreening thisSchemaLoad = new LabItemScreening();
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
        public LabItemScreeningCollection FetchAll()
        {
            LabItemScreeningCollection coll = new LabItemScreeningCollection();
            Query qry = new Query(LabItemScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabItemScreeningCollection FetchByID(object IdItemScreening)
        {
            LabItemScreeningCollection coll = new LabItemScreeningCollection().Where("idItemScreening", IdItemScreening).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabItemScreeningCollection FetchByQuery(Query qry)
        {
            LabItemScreeningCollection coll = new LabItemScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdItemScreening)
        {
            return (LabItemScreening.Delete(IdItemScreening) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdItemScreening)
        {
            return (LabItemScreening.Destroy(IdItemScreening) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdMetodo,string ValorReferencia,int IdUsuarioRegistro,DateTime FechaRegistro,bool Baja,string Abreviatura)
	    {
		    LabItemScreening item = new LabItemScreening();
		    
            item.Nombre = Nombre;
            
            item.IdMetodo = IdMetodo;
            
            item.ValorReferencia = ValorReferencia;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
            item.Baja = Baja;
            
            item.Abreviatura = Abreviatura;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdItemScreening,string Nombre,int IdMetodo,string ValorReferencia,int IdUsuarioRegistro,DateTime FechaRegistro,bool Baja,string Abreviatura)
	    {
		    LabItemScreening item = new LabItemScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdItemScreening = IdItemScreening;
				
			item.Nombre = Nombre;
				
			item.IdMetodo = IdMetodo;
				
			item.ValorReferencia = ValorReferencia;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
			item.Baja = Baja;
				
			item.Abreviatura = Abreviatura;
				
	        item.Save(UserName);
	    }
    }
}
