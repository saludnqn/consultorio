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
    /// Controller class for PN_calcula_precio
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnCalculaPrecioController
    {
        // Preload our schema..
        PnCalculaPrecio thisSchemaLoad = new PnCalculaPrecio();
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
        public PnCalculaPrecioCollection FetchAll()
        {
            PnCalculaPrecioCollection coll = new PnCalculaPrecioCollection();
            Query qry = new Query(PnCalculaPrecio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCalculaPrecioCollection FetchByID(object IdCalculaPrecio)
        {
            PnCalculaPrecioCollection coll = new PnCalculaPrecioCollection().Where("id_calcula_precio", IdCalculaPrecio).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCalculaPrecioCollection FetchByQuery(Query qry)
        {
            PnCalculaPrecioCollection coll = new PnCalculaPrecioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdCalculaPrecio)
        {
            return (PnCalculaPrecio.Delete(IdCalculaPrecio) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdCalculaPrecio)
        {
            return (PnCalculaPrecio.Destroy(IdCalculaPrecio) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string PracticaVincula,string ObjPrestacionVincula,string Diagnostico,string GrupoEtareo,string Sexo)
	    {
		    PnCalculaPrecio item = new PnCalculaPrecio();
		    
            item.PracticaVincula = PracticaVincula;
            
            item.ObjPrestacionVincula = ObjPrestacionVincula;
            
            item.Diagnostico = Diagnostico;
            
            item.GrupoEtareo = GrupoEtareo;
            
            item.Sexo = Sexo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCalculaPrecio,string PracticaVincula,string ObjPrestacionVincula,string Diagnostico,string GrupoEtareo,string Sexo)
	    {
		    PnCalculaPrecio item = new PnCalculaPrecio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCalculaPrecio = IdCalculaPrecio;
				
			item.PracticaVincula = PracticaVincula;
				
			item.ObjPrestacionVincula = ObjPrestacionVincula;
				
			item.Diagnostico = Diagnostico;
				
			item.GrupoEtareo = GrupoEtareo;
				
			item.Sexo = Sexo;
				
	        item.Save(UserName);
	    }
    }
}
