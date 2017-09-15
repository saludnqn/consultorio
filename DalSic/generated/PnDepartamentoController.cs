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
    /// Controller class for PN_departamentos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDepartamentoController
    {
        // Preload our schema..
        PnDepartamento thisSchemaLoad = new PnDepartamento();
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
        public PnDepartamentoCollection FetchAll()
        {
            PnDepartamentoCollection coll = new PnDepartamentoCollection();
            Query qry = new Query(PnDepartamento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDepartamentoCollection FetchByID(object IdDepartamento)
        {
            PnDepartamentoCollection coll = new PnDepartamentoCollection().Where("id_departamento", IdDepartamento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDepartamentoCollection FetchByQuery(Query qry)
        {
            PnDepartamentoCollection coll = new PnDepartamentoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDepartamento)
        {
            return (PnDepartamento.Delete(IdDepartamento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDepartamento)
        {
            return (PnDepartamento.Destroy(IdDepartamento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int IdProvincia)
	    {
		    PnDepartamento item = new PnDepartamento();
		    
            item.Nombre = Nombre;
            
            item.IdProvincia = IdProvincia;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDepartamento,string Nombre,int IdProvincia)
	    {
		    PnDepartamento item = new PnDepartamento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDepartamento = IdDepartamento;
				
			item.Nombre = Nombre;
				
			item.IdProvincia = IdProvincia;
				
	        item.Save(UserName);
	    }
    }
}
