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
    /// Controller class for PN_patologias_frecuentes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPatologiasFrecuenteController
    {
        // Preload our schema..
        PnPatologiasFrecuente thisSchemaLoad = new PnPatologiasFrecuente();
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
        public PnPatologiasFrecuenteCollection FetchAll()
        {
            PnPatologiasFrecuenteCollection coll = new PnPatologiasFrecuenteCollection();
            Query qry = new Query(PnPatologiasFrecuente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPatologiasFrecuenteCollection FetchByID(object IdPatologiasFrecuentes)
        {
            PnPatologiasFrecuenteCollection coll = new PnPatologiasFrecuenteCollection().Where("id_patologias_frecuentes", IdPatologiasFrecuentes).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPatologiasFrecuenteCollection FetchByQuery(Query qry)
        {
            PnPatologiasFrecuenteCollection coll = new PnPatologiasFrecuenteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPatologiasFrecuentes)
        {
            return (PnPatologiasFrecuente.Delete(IdPatologiasFrecuentes) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPatologiasFrecuentes)
        {
            return (PnPatologiasFrecuente.Destroy(IdPatologiasFrecuentes) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Codigo,string Descripcion,int? IdNomencladorDetalle,string Neo,string Ceroacinco,string Seisanueve,string Adol,string Adulto,string Color,string F,string GrupoPatologias,string M)
	    {
		    PnPatologiasFrecuente item = new PnPatologiasFrecuente();
		    
            item.Codigo = Codigo;
            
            item.Descripcion = Descripcion;
            
            item.IdNomencladorDetalle = IdNomencladorDetalle;
            
            item.Neo = Neo;
            
            item.Ceroacinco = Ceroacinco;
            
            item.Seisanueve = Seisanueve;
            
            item.Adol = Adol;
            
            item.Adulto = Adulto;
            
            item.Color = Color;
            
            item.F = F;
            
            item.GrupoPatologias = GrupoPatologias;
            
            item.M = M;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Codigo,string Descripcion,int? IdNomencladorDetalle,string Neo,string Ceroacinco,string Seisanueve,string Adol,string Adulto,string Color,int IdPatologiasFrecuentes,string F,string GrupoPatologias,string M)
	    {
		    PnPatologiasFrecuente item = new PnPatologiasFrecuente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Codigo = Codigo;
				
			item.Descripcion = Descripcion;
				
			item.IdNomencladorDetalle = IdNomencladorDetalle;
				
			item.Neo = Neo;
				
			item.Ceroacinco = Ceroacinco;
				
			item.Seisanueve = Seisanueve;
				
			item.Adol = Adol;
				
			item.Adulto = Adulto;
				
			item.Color = Color;
				
			item.IdPatologiasFrecuentes = IdPatologiasFrecuentes;
				
			item.F = F;
				
			item.GrupoPatologias = GrupoPatologias;
				
			item.M = M;
				
	        item.Save(UserName);
	    }
    }
}
