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
    /// Controller class for ODO_Nomenclador
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class OdoNomencladorController
    {
        // Preload our schema..
        OdoNomenclador thisSchemaLoad = new OdoNomenclador();
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
        public OdoNomencladorCollection FetchAll()
        {
            OdoNomencladorCollection coll = new OdoNomencladorCollection();
            Query qry = new Query(OdoNomenclador.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public OdoNomencladorCollection FetchByID(object IdNomenclador)
        {
            OdoNomencladorCollection coll = new OdoNomencladorCollection().Where("idNomenclador", IdNomenclador).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public OdoNomencladorCollection FetchByQuery(Query qry)
        {
            OdoNomencladorCollection coll = new OdoNomencladorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNomenclador)
        {
            return (OdoNomenclador.Delete(IdNomenclador) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNomenclador)
        {
            return (OdoNomenclador.Destroy(IdNomenclador) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Codigo,string Descripcion,string Clasificacion,bool PiezaDental)
	    {
		    OdoNomenclador item = new OdoNomenclador();
		    
            item.Codigo = Codigo;
            
            item.Descripcion = Descripcion;
            
            item.Clasificacion = Clasificacion;
            
            item.PiezaDental = PiezaDental;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNomenclador,string Codigo,string Descripcion,string Clasificacion,bool PiezaDental)
	    {
		    OdoNomenclador item = new OdoNomenclador();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNomenclador = IdNomenclador;
				
			item.Codigo = Codigo;
				
			item.Descripcion = Descripcion;
				
			item.Clasificacion = Clasificacion;
				
			item.PiezaDental = PiezaDental;
				
	        item.Save(UserName);
	    }
    }
}
