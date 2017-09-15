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
    /// Controller class for PN_Borrar
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnBorrarController
    {
        // Preload our schema..
        PnBorrar thisSchemaLoad = new PnBorrar();
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
        public PnBorrarCollection FetchAll()
        {
            PnBorrarCollection coll = new PnBorrarCollection();
            Query qry = new Query(PnBorrar.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnBorrarCollection FetchByID(object IdNomenclador)
        {
            PnBorrarCollection coll = new PnBorrarCollection().Where("id_nomenclador", IdNomenclador).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnBorrarCollection FetchByQuery(Query qry)
        {
            PnBorrarCollection coll = new PnBorrarCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNomenclador)
        {
            return (PnBorrar.Delete(IdNomenclador) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNomenclador)
        {
            return (PnBorrar.Destroy(IdNomenclador) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Codigo,string Grupo,string Subgrupo,string Descripcion,decimal? Precio,string TipoNomenclador,int? IdNomencladorDetalle,string Borrado,string Definicion,int? DiasUti,int? DiasSala,int? DiasTotal,int? DiasMax,string Neo,string Ceroacinco,string Seisanueve,string Adol,string Adulto,string F,string M,string LineaCuidado)
	    {
		    PnBorrar item = new PnBorrar();
		    
            item.Codigo = Codigo;
            
            item.Grupo = Grupo;
            
            item.Subgrupo = Subgrupo;
            
            item.Descripcion = Descripcion;
            
            item.Precio = Precio;
            
            item.TipoNomenclador = TipoNomenclador;
            
            item.IdNomencladorDetalle = IdNomencladorDetalle;
            
            item.Borrado = Borrado;
            
            item.Definicion = Definicion;
            
            item.DiasUti = DiasUti;
            
            item.DiasSala = DiasSala;
            
            item.DiasTotal = DiasTotal;
            
            item.DiasMax = DiasMax;
            
            item.Neo = Neo;
            
            item.Ceroacinco = Ceroacinco;
            
            item.Seisanueve = Seisanueve;
            
            item.Adol = Adol;
            
            item.Adulto = Adulto;
            
            item.F = F;
            
            item.M = M;
            
            item.LineaCuidado = LineaCuidado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNomenclador,string Codigo,string Grupo,string Subgrupo,string Descripcion,decimal? Precio,string TipoNomenclador,int? IdNomencladorDetalle,string Borrado,string Definicion,int? DiasUti,int? DiasSala,int? DiasTotal,int? DiasMax,string Neo,string Ceroacinco,string Seisanueve,string Adol,string Adulto,string F,string M,string LineaCuidado)
	    {
		    PnBorrar item = new PnBorrar();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNomenclador = IdNomenclador;
				
			item.Codigo = Codigo;
				
			item.Grupo = Grupo;
				
			item.Subgrupo = Subgrupo;
				
			item.Descripcion = Descripcion;
				
			item.Precio = Precio;
				
			item.TipoNomenclador = TipoNomenclador;
				
			item.IdNomencladorDetalle = IdNomencladorDetalle;
				
			item.Borrado = Borrado;
				
			item.Definicion = Definicion;
				
			item.DiasUti = DiasUti;
				
			item.DiasSala = DiasSala;
				
			item.DiasTotal = DiasTotal;
				
			item.DiasMax = DiasMax;
				
			item.Neo = Neo;
				
			item.Ceroacinco = Ceroacinco;
				
			item.Seisanueve = Seisanueve;
				
			item.Adol = Adol;
				
			item.Adulto = Adulto;
				
			item.F = F;
				
			item.M = M;
				
			item.LineaCuidado = LineaCuidado;
				
	        item.Save(UserName);
	    }
    }
}
