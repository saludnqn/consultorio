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
    /// Controller class for PN_grupo_prestacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnGrupoPrestacionController
    {
        // Preload our schema..
        PnGrupoPrestacion thisSchemaLoad = new PnGrupoPrestacion();
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
        public PnGrupoPrestacionCollection FetchAll()
        {
            PnGrupoPrestacionCollection coll = new PnGrupoPrestacionCollection();
            Query qry = new Query(PnGrupoPrestacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnGrupoPrestacionCollection FetchByID(object IdGrupoPrestacion)
        {
            PnGrupoPrestacionCollection coll = new PnGrupoPrestacionCollection().Where("id_grupo_prestacion", IdGrupoPrestacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnGrupoPrestacionCollection FetchByQuery(Query qry)
        {
            PnGrupoPrestacionCollection coll = new PnGrupoPrestacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdGrupoPrestacion)
        {
            return (PnGrupoPrestacion.Delete(IdGrupoPrestacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdGrupoPrestacion)
        {
            return (PnGrupoPrestacion.Destroy(IdGrupoPrestacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdCategoriaPrestacion,string Tema,string Categoria,string Codigo,string CategoriaPadre,int? IdNomencladorDetalle,decimal? Precio,string Neo,string Ceroacinco,string Seisanueve,string Adol,string Adulto,string F,string M,int? DiasUti,int? DiasSala,int? DiasTotal,int? DiasMax)
	    {
		    PnGrupoPrestacion item = new PnGrupoPrestacion();
		    
            item.IdCategoriaPrestacion = IdCategoriaPrestacion;
            
            item.Tema = Tema;
            
            item.Categoria = Categoria;
            
            item.Codigo = Codigo;
            
            item.CategoriaPadre = CategoriaPadre;
            
            item.IdNomencladorDetalle = IdNomencladorDetalle;
            
            item.Precio = Precio;
            
            item.Neo = Neo;
            
            item.Ceroacinco = Ceroacinco;
            
            item.Seisanueve = Seisanueve;
            
            item.Adol = Adol;
            
            item.Adulto = Adulto;
            
            item.F = F;
            
            item.M = M;
            
            item.DiasUti = DiasUti;
            
            item.DiasSala = DiasSala;
            
            item.DiasTotal = DiasTotal;
            
            item.DiasMax = DiasMax;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdCategoriaPrestacion,string Tema,string Categoria,string Codigo,string CategoriaPadre,int? IdNomencladorDetalle,decimal? Precio,string Neo,string Ceroacinco,int IdGrupoPrestacion,string Seisanueve,string Adol,string Adulto,string F,string M,int? DiasUti,int? DiasSala,int? DiasTotal,int? DiasMax)
	    {
		    PnGrupoPrestacion item = new PnGrupoPrestacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdCategoriaPrestacion = IdCategoriaPrestacion;
				
			item.Tema = Tema;
				
			item.Categoria = Categoria;
				
			item.Codigo = Codigo;
				
			item.CategoriaPadre = CategoriaPadre;
				
			item.IdNomencladorDetalle = IdNomencladorDetalle;
				
			item.Precio = Precio;
				
			item.Neo = Neo;
				
			item.Ceroacinco = Ceroacinco;
				
			item.IdGrupoPrestacion = IdGrupoPrestacion;
				
			item.Seisanueve = Seisanueve;
				
			item.Adol = Adol;
				
			item.Adulto = Adulto;
				
			item.F = F;
				
			item.M = M;
				
			item.DiasUti = DiasUti;
				
			item.DiasSala = DiasSala;
				
			item.DiasTotal = DiasTotal;
				
			item.DiasMax = DiasMax;
				
	        item.Save(UserName);
	    }
    }
}
