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
    /// Controller class for PN_dat_min_obl
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDatMinOblController
    {
        // Preload our schema..
        PnDatMinObl thisSchemaLoad = new PnDatMinObl();
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
        public PnDatMinOblCollection FetchAll()
        {
            PnDatMinOblCollection coll = new PnDatMinOblCollection();
            Query qry = new Query(PnDatMinObl.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDatMinOblCollection FetchByID(object IdDatMinObl)
        {
            PnDatMinOblCollection coll = new PnDatMinOblCollection().Where("id_dat_min_obl", IdDatMinObl).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDatMinOblCollection FetchByQuery(Query qry)
        {
            PnDatMinOblCollection coll = new PnDatMinOblCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDatMinObl)
        {
            return (PnDatMinObl.Delete(IdDatMinObl) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDatMinObl)
        {
            return (PnDatMinObl.Destroy(IdDatMinObl) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TextoBoton,string LblText,string PaginaDestino,string ParamPaginaDestino,string ObligaEfector,string PracticaVincula,string ObjPrestacionVincula,string Diagnostico,string GrupoEtareo,string Sexo)
	    {
		    PnDatMinObl item = new PnDatMinObl();
		    
            item.TextoBoton = TextoBoton;
            
            item.LblText = LblText;
            
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
	    public void Update(int IdDatMinObl,string TextoBoton,string LblText,string PaginaDestino,string ParamPaginaDestino,string ObligaEfector,string PracticaVincula,string ObjPrestacionVincula,string Diagnostico,string GrupoEtareo,string Sexo)
	    {
		    PnDatMinObl item = new PnDatMinObl();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDatMinObl = IdDatMinObl;
				
			item.TextoBoton = TextoBoton;
				
			item.LblText = LblText;
				
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
