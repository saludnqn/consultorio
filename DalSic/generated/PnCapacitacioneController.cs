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
    /// Controller class for PN_capacitaciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCapacitacioneController
    {
        // Preload our schema..
        PnCapacitacione thisSchemaLoad = new PnCapacitacione();
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
        public PnCapacitacioneCollection FetchAll()
        {
            PnCapacitacioneCollection coll = new PnCapacitacioneCollection();
            Query qry = new Query(PnCapacitacione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCapacitacioneCollection FetchByID(object IdCapacitacion)
        {
            PnCapacitacioneCollection coll = new PnCapacitacioneCollection().Where("id_capacitacion", IdCapacitacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCapacitacioneCollection FetchByQuery(Query qry)
        {
            PnCapacitacioneCollection coll = new PnCapacitacioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCapacitacion)
        {
            return (PnCapacitacione.Delete(IdCapacitacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCapacitacion)
        {
            return (PnCapacitacione.Destroy(IdCapacitacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Tema,short Dictado,string Comentarios,DateTime? DictadoDesde,DateTime? DictadoHasta,short Locacion,string DictadoPor)
	    {
		    PnCapacitacione item = new PnCapacitacione();
		    
            item.Tema = Tema;
            
            item.Dictado = Dictado;
            
            item.Comentarios = Comentarios;
            
            item.DictadoDesde = DictadoDesde;
            
            item.DictadoHasta = DictadoHasta;
            
            item.Locacion = Locacion;
            
            item.DictadoPor = DictadoPor;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCapacitacion,string Tema,short Dictado,string Comentarios,DateTime? DictadoDesde,DateTime? DictadoHasta,short Locacion,string DictadoPor)
	    {
		    PnCapacitacione item = new PnCapacitacione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCapacitacion = IdCapacitacion;
				
			item.Tema = Tema;
				
			item.Dictado = Dictado;
				
			item.Comentarios = Comentarios;
				
			item.DictadoDesde = DictadoDesde;
				
			item.DictadoHasta = DictadoHasta;
				
			item.Locacion = Locacion;
				
			item.DictadoPor = DictadoPor;
				
	        item.Save(UserName);
	    }
    }
}
