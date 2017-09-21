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
    /// Controller class for Sys_MedicamentoRubro
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysMedicamentoRubroController
    {
        // Preload our schema..
        SysMedicamentoRubro thisSchemaLoad = new SysMedicamentoRubro();
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
        public SysMedicamentoRubroCollection FetchAll()
        {
            SysMedicamentoRubroCollection coll = new SysMedicamentoRubroCollection();
            Query qry = new Query(SysMedicamentoRubro.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMedicamentoRubroCollection FetchByID(object IdMedicamentoRubro)
        {
            SysMedicamentoRubroCollection coll = new SysMedicamentoRubroCollection().Where("idMedicamentoRubro", IdMedicamentoRubro).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysMedicamentoRubroCollection FetchByQuery(Query qry)
        {
            SysMedicamentoRubroCollection coll = new SysMedicamentoRubroCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMedicamentoRubro)
        {
            return (SysMedicamentoRubro.Delete(IdMedicamentoRubro) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMedicamentoRubro)
        {
            return (SysMedicamentoRubro.Destroy(IdMedicamentoRubro) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdMedicamentoRubro,int? Padre,string Nombre,int? RubroPrimerNivel)
	    {
		    SysMedicamentoRubro item = new SysMedicamentoRubro();
		    
            item.IdMedicamentoRubro = IdMedicamentoRubro;
            
            item.Padre = Padre;
            
            item.Nombre = Nombre;
            
            item.RubroPrimerNivel = RubroPrimerNivel;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMedicamentoRubro,int? Padre,string Nombre,int? RubroPrimerNivel)
	    {
		    SysMedicamentoRubro item = new SysMedicamentoRubro();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMedicamentoRubro = IdMedicamentoRubro;
				
			item.Padre = Padre;
				
			item.Nombre = Nombre;
				
			item.RubroPrimerNivel = RubroPrimerNivel;
				
	        item.Save(UserName);
	    }
    }
}
