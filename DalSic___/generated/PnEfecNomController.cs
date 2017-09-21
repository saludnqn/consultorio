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
    /// Controller class for PN_efec_nom
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEfecNomController
    {
        // Preload our schema..
        PnEfecNom thisSchemaLoad = new PnEfecNom();
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
        public PnEfecNomCollection FetchAll()
        {
            PnEfecNomCollection coll = new PnEfecNomCollection();
            Query qry = new Query(PnEfecNom.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEfecNomCollection FetchByID(object IdEfecNom)
        {
            PnEfecNomCollection coll = new PnEfecNomCollection().Where("id_efec_nom", IdEfecNom).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEfecNomCollection FetchByQuery(Query qry)
        {
            PnEfecNomCollection coll = new PnEfecNomCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEfecNom)
        {
            return (PnEfecNom.Delete(IdEfecNom) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEfecNom)
        {
            return (PnEfecNom.Destroy(IdEfecNom) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Codigo,string Usuario,DateTime? FechaCarga)
	    {
		    PnEfecNom item = new PnEfecNom();
		    
            item.Cuie = Cuie;
            
            item.Codigo = Codigo;
            
            item.Usuario = Usuario;
            
            item.FechaCarga = FechaCarga;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEfecNom,string Cuie,string Codigo,string Usuario,DateTime? FechaCarga)
	    {
		    PnEfecNom item = new PnEfecNom();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEfecNom = IdEfecNom;
				
			item.Cuie = Cuie;
				
			item.Codigo = Codigo;
				
			item.Usuario = Usuario;
				
			item.FechaCarga = FechaCarga;
				
	        item.Save(UserName);
	    }
    }
}
