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
    /// Controller class for LAB_ResultadoScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabResultadoScreeningController
    {
        // Preload our schema..
        LabResultadoScreening thisSchemaLoad = new LabResultadoScreening();
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
        public LabResultadoScreeningCollection FetchAll()
        {
            LabResultadoScreeningCollection coll = new LabResultadoScreeningCollection();
            Query qry = new Query(LabResultadoScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabResultadoScreeningCollection FetchByID(object IdResultadoScreening)
        {
            LabResultadoScreeningCollection coll = new LabResultadoScreeningCollection().Where("idResultadoScreening", IdResultadoScreening).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabResultadoScreeningCollection FetchByQuery(Query qry)
        {
            LabResultadoScreeningCollection coll = new LabResultadoScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdResultadoScreening)
        {
            return (LabResultadoScreening.Delete(IdResultadoScreening) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdResultadoScreening)
        {
            return (LabResultadoScreening.Destroy(IdResultadoScreening) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,bool Baja,int IdUsuarioRegistro,DateTime FechaRegistro,string Abreviatura)
	    {
		    LabResultadoScreening item = new LabResultadoScreening();
		    
            item.Descripcion = Descripcion;
            
            item.Baja = Baja;
            
            item.IdUsuarioRegistro = IdUsuarioRegistro;
            
            item.FechaRegistro = FechaRegistro;
            
            item.Abreviatura = Abreviatura;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdResultadoScreening,string Descripcion,bool Baja,int IdUsuarioRegistro,DateTime FechaRegistro,string Abreviatura)
	    {
		    LabResultadoScreening item = new LabResultadoScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdResultadoScreening = IdResultadoScreening;
				
			item.Descripcion = Descripcion;
				
			item.Baja = Baja;
				
			item.IdUsuarioRegistro = IdUsuarioRegistro;
				
			item.FechaRegistro = FechaRegistro;
				
			item.Abreviatura = Abreviatura;
				
	        item.Save(UserName);
	    }
    }
}
