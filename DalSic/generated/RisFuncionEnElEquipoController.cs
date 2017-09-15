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
    /// Controller class for RIS_FuncionEnElEquipo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisFuncionEnElEquipoController
    {
        // Preload our schema..
        RisFuncionEnElEquipo thisSchemaLoad = new RisFuncionEnElEquipo();
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
        public RisFuncionEnElEquipoCollection FetchAll()
        {
            RisFuncionEnElEquipoCollection coll = new RisFuncionEnElEquipoCollection();
            Query qry = new Query(RisFuncionEnElEquipo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisFuncionEnElEquipoCollection FetchByID(object IdFuncionEnElEquipo)
        {
            RisFuncionEnElEquipoCollection coll = new RisFuncionEnElEquipoCollection().Where("idFuncionEnElEquipo", IdFuncionEnElEquipo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisFuncionEnElEquipoCollection FetchByQuery(Query qry)
        {
            RisFuncionEnElEquipoCollection coll = new RisFuncionEnElEquipoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFuncionEnElEquipo)
        {
            return (RisFuncionEnElEquipo.Delete(IdFuncionEnElEquipo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFuncionEnElEquipo)
        {
            return (RisFuncionEnElEquipo.Destroy(IdFuncionEnElEquipo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    RisFuncionEnElEquipo item = new RisFuncionEnElEquipo();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFuncionEnElEquipo,string Descripcion)
	    {
		    RisFuncionEnElEquipo item = new RisFuncionEnElEquipo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFuncionEnElEquipo = IdFuncionEnElEquipo;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
