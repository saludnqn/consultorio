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
    /// Controller class for PN_familia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnFamiliumController
    {
        // Preload our schema..
        PnFamilium thisSchemaLoad = new PnFamilium();
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
        public PnFamiliumCollection FetchAll()
        {
            PnFamiliumCollection coll = new PnFamiliumCollection();
            Query qry = new Query(PnFamilium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnFamiliumCollection FetchByID(object IdFamilia)
        {
            PnFamiliumCollection coll = new PnFamiliumCollection().Where("id_familia", IdFamilia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnFamiliumCollection FetchByQuery(Query qry)
        {
            PnFamiliumCollection coll = new PnFamiliumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdFamilia)
        {
            return (PnFamilium.Delete(IdFamilia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdFamilia)
        {
            return (PnFamilium.Destroy(IdFamilia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdLegajo,string Relacion,string NombreApellido,DateTime? FechaNacimiento,string Domicilio,string Dni)
	    {
		    PnFamilium item = new PnFamilium();
		    
            item.IdLegajo = IdLegajo;
            
            item.Relacion = Relacion;
            
            item.NombreApellido = NombreApellido;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.Domicilio = Domicilio;
            
            item.Dni = Dni;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdFamilia,int IdLegajo,string Relacion,string NombreApellido,DateTime? FechaNacimiento,string Domicilio,string Dni)
	    {
		    PnFamilium item = new PnFamilium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdFamilia = IdFamilia;
				
			item.IdLegajo = IdLegajo;
				
			item.Relacion = Relacion;
				
			item.NombreApellido = NombreApellido;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.Domicilio = Domicilio;
				
			item.Dni = Dni;
				
	        item.Save(UserName);
	    }
    }
}
