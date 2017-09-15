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
    /// Controller class for Sys_Departamento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysDepartamentoController
    {
        // Preload our schema..
        SysDepartamento thisSchemaLoad = new SysDepartamento();
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
        public SysDepartamentoCollection FetchAll()
        {
            SysDepartamentoCollection coll = new SysDepartamentoCollection();
            Query qry = new Query(SysDepartamento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysDepartamentoCollection FetchByID(object IdDepartamento)
        {
            SysDepartamentoCollection coll = new SysDepartamentoCollection().Where("idDepartamento", IdDepartamento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysDepartamentoCollection FetchByQuery(Query qry)
        {
            SysDepartamentoCollection coll = new SysDepartamentoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDepartamento)
        {
            return (SysDepartamento.Delete(IdDepartamento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDepartamento)
        {
            return (SysDepartamento.Destroy(IdDepartamento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int? IdProvincia,string CodigoINDEC)
	    {
		    SysDepartamento item = new SysDepartamento();
		    
            item.Nombre = Nombre;
            
            item.IdProvincia = IdProvincia;
            
            item.CodigoINDEC = CodigoINDEC;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDepartamento,string Nombre,int? IdProvincia,string CodigoINDEC)
	    {
		    SysDepartamento item = new SysDepartamento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDepartamento = IdDepartamento;
				
			item.Nombre = Nombre;
				
			item.IdProvincia = IdProvincia;
				
			item.CodigoINDEC = CodigoINDEC;
				
	        item.Save(UserName);
	    }
    }
}
