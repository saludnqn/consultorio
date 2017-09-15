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
    /// Controller class for PN_trz_pres
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnTrzPreController
    {
        // Preload our schema..
        PnTrzPre thisSchemaLoad = new PnTrzPre();
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
        public PnTrzPreCollection FetchAll()
        {
            PnTrzPreCollection coll = new PnTrzPreCollection();
            Query qry = new Query(PnTrzPre.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTrzPreCollection FetchByID(object IdTrzPres)
        {
            PnTrzPreCollection coll = new PnTrzPreCollection().Where("id_trz_pres", IdTrzPres).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnTrzPreCollection FetchByQuery(Query qry)
        {
            PnTrzPreCollection coll = new PnTrzPreCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTrzPres)
        {
            return (PnTrzPre.Delete(IdTrzPres) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTrzPres)
        {
            return (PnTrzPre.Destroy(IdTrzPres) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TextoBoton,string TrzVincula,string PaginaDestino,string ParamPaginaDestino,string ObligaEfector,string PracticaVincula,string ObjPrestacionVincula,string Diagnostico,string GrupoEtareo,string Sexo)
	    {
		    PnTrzPre item = new PnTrzPre();
		    
            item.TextoBoton = TextoBoton;
            
            item.TrzVincula = TrzVincula;
            
            item.PaginaDestino = PaginaDestino;
            
            item.ParamPaginaDestino = ParamPaginaDestino;
            
            item.ObligaEfector = ObligaEfector;
            
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
	    public void Update(int IdTrzPres,string TextoBoton,string TrzVincula,string PaginaDestino,string ParamPaginaDestino,string ObligaEfector,string PracticaVincula,string ObjPrestacionVincula,string Diagnostico,string GrupoEtareo,string Sexo)
	    {
		    PnTrzPre item = new PnTrzPre();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTrzPres = IdTrzPres;
				
			item.TextoBoton = TextoBoton;
				
			item.TrzVincula = TrzVincula;
				
			item.PaginaDestino = PaginaDestino;
				
			item.ParamPaginaDestino = ParamPaginaDestino;
				
			item.ObligaEfector = ObligaEfector;
				
			item.PracticaVincula = PracticaVincula;
				
			item.ObjPrestacionVincula = ObjPrestacionVincula;
				
			item.Diagnostico = Diagnostico;
				
			item.GrupoEtareo = GrupoEtareo;
				
			item.Sexo = Sexo;
				
	        item.Save(UserName);
	    }
    }
}
