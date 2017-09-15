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
    /// Controller class for Sys_Medicamento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysMedicamentoController
    {
        // Preload our schema..
        SysMedicamento thisSchemaLoad = new SysMedicamento();
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
        public SysMedicamentoCollection FetchAll()
        {
            SysMedicamentoCollection coll = new SysMedicamentoCollection();
            Query qry = new Query(SysMedicamento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMedicamentoCollection FetchByID(object IdMedicamento)
        {
            SysMedicamentoCollection coll = new SysMedicamentoCollection().Where("idMedicamento", IdMedicamento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMedicamentoCollection FetchByQuery(Query qry)
        {
            SysMedicamentoCollection coll = new SysMedicamentoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMedicamento)
        {
            return (SysMedicamento.Delete(IdMedicamento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMedicamento)
        {
            return (SysMedicamento.Destroy(IdMedicamento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdMedicamentoRubro,string Nombre,string Unidad,bool? NecesitaVencimiento,bool? Activo,DateTime? UltimaModificacion)
	    {
		    SysMedicamento item = new SysMedicamento();
		    
            item.IdMedicamentoRubro = IdMedicamentoRubro;
            
            item.Nombre = Nombre;
            
            item.Unidad = Unidad;
            
            item.NecesitaVencimiento = NecesitaVencimiento;
            
            item.Activo = Activo;
            
            item.UltimaModificacion = UltimaModificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMedicamento,int? IdMedicamentoRubro,string Nombre,string Unidad,bool? NecesitaVencimiento,bool? Activo,DateTime? UltimaModificacion)
	    {
		    SysMedicamento item = new SysMedicamento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMedicamento = IdMedicamento;
				
			item.IdMedicamentoRubro = IdMedicamentoRubro;
				
			item.Nombre = Nombre;
				
			item.Unidad = Unidad;
				
			item.NecesitaVencimiento = NecesitaVencimiento;
				
			item.Activo = Activo;
				
			item.UltimaModificacion = UltimaModificacion;
				
	        item.Save(UserName);
	    }
    }
}
