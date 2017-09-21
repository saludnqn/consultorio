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
    /// Controller class for CON_ConsultaMedicamento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConConsultaMedicamentoController
    {
        // Preload our schema..
        ConConsultaMedicamento thisSchemaLoad = new ConConsultaMedicamento();
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
        public ConConsultaMedicamentoCollection FetchAll()
        {
            ConConsultaMedicamentoCollection coll = new ConConsultaMedicamentoCollection();
            Query qry = new Query(ConConsultaMedicamento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultaMedicamentoCollection FetchByID(object IdConsultaMedicamento)
        {
            ConConsultaMedicamentoCollection coll = new ConConsultaMedicamentoCollection().Where("idConsultaMedicamento", IdConsultaMedicamento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConConsultaMedicamentoCollection FetchByQuery(Query qry)
        {
            ConConsultaMedicamentoCollection coll = new ConConsultaMedicamentoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdConsultaMedicamento)
        {
            return (ConConsultaMedicamento.Delete(IdConsultaMedicamento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdConsultaMedicamento)
        {
            return (ConConsultaMedicamento.Destroy(IdConsultaMedicamento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEfector,int? IdConsulta,int? IdMedicamento)
	    {
		    ConConsultaMedicamento item = new ConConsultaMedicamento();
		    
            item.IdEfector = IdEfector;
            
            item.IdConsulta = IdConsulta;
            
            item.IdMedicamento = IdMedicamento;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdConsultaMedicamento,int? IdEfector,int? IdConsulta,int? IdMedicamento)
	    {
		    ConConsultaMedicamento item = new ConConsultaMedicamento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdConsultaMedicamento = IdConsultaMedicamento;
				
			item.IdEfector = IdEfector;
				
			item.IdConsulta = IdConsulta;
				
			item.IdMedicamento = IdMedicamento;
				
	        item.Save(UserName);
	    }
    }
}
