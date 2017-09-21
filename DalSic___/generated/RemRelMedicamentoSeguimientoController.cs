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
    /// Controller class for Rem_RelMedicamentoSeguimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemRelMedicamentoSeguimientoController
    {
        // Preload our schema..
        RemRelMedicamentoSeguimiento thisSchemaLoad = new RemRelMedicamentoSeguimiento();
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
        public RemRelMedicamentoSeguimientoCollection FetchAll()
        {
            RemRelMedicamentoSeguimientoCollection coll = new RemRelMedicamentoSeguimientoCollection();
            Query qry = new Query(RemRelMedicamentoSeguimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemRelMedicamentoSeguimientoCollection FetchByID(object IdRelMedicamentoSeguimiento)
        {
            RemRelMedicamentoSeguimientoCollection coll = new RemRelMedicamentoSeguimientoCollection().Where("idRelMedicamentoSeguimiento", IdRelMedicamentoSeguimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemRelMedicamentoSeguimientoCollection FetchByQuery(Query qry)
        {
            RemRelMedicamentoSeguimientoCollection coll = new RemRelMedicamentoSeguimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelMedicamentoSeguimiento)
        {
            return (RemRelMedicamentoSeguimiento.Delete(IdRelMedicamentoSeguimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelMedicamentoSeguimiento)
        {
            return (RemRelMedicamentoSeguimiento.Destroy(IdRelMedicamentoSeguimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdMedicamento,int IdClasificacion,int IdSeguimiento,double Dosis)
	    {
		    RemRelMedicamentoSeguimiento item = new RemRelMedicamentoSeguimiento();
		    
            item.IdMedicamento = IdMedicamento;
            
            item.IdClasificacion = IdClasificacion;
            
            item.IdSeguimiento = IdSeguimiento;
            
            item.Dosis = Dosis;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelMedicamentoSeguimiento,int IdMedicamento,int IdClasificacion,int IdSeguimiento,double Dosis)
	    {
		    RemRelMedicamentoSeguimiento item = new RemRelMedicamentoSeguimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelMedicamentoSeguimiento = IdRelMedicamentoSeguimiento;
				
			item.IdMedicamento = IdMedicamento;
				
			item.IdClasificacion = IdClasificacion;
				
			item.IdSeguimiento = IdSeguimiento;
				
			item.Dosis = Dosis;
				
	        item.Save(UserName);
	    }
    }
}
