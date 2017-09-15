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
    /// Controller class for PN_patologias
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPatologiaController
    {
        // Preload our schema..
        PnPatologia thisSchemaLoad = new PnPatologia();
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
        public PnPatologiaCollection FetchAll()
        {
            PnPatologiaCollection coll = new PnPatologiaCollection();
            Query qry = new Query(PnPatologia.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPatologiaCollection FetchByID(object IdPatologias)
        {
            PnPatologiaCollection coll = new PnPatologiaCollection().Where("id_patologias", IdPatologias).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPatologiaCollection FetchByQuery(Query qry)
        {
            PnPatologiaCollection coll = new PnPatologiaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPatologias)
        {
            return (PnPatologia.Delete(IdPatologias) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPatologias)
        {
            return (PnPatologia.Destroy(IdPatologias) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Codigo,string Descripcion,int? IdNomencladorDetalle,string Neo,string Ceroacinco,string Seisanueve,string Adol,string Adulto,string Color,string F,string GrupoPatologias,string M)
	    {
		    PnPatologia item = new PnPatologia();
		    
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
	    public void Update(string Codigo,string Descripcion,int? IdNomencladorDetalle,string Neo,string Ceroacinco,string Seisanueve,string Adol,string Adulto,string Color,int IdPatologias,string F,string GrupoPatologias,string M)
	    {
		    PnPatologia item = new PnPatologia();
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
				
			item.IdPatologias = IdPatologias;
				
			item.F = F;
				
			item.GrupoPatologias = GrupoPatologias;
				
			item.M = M;
				
	        item.Save(UserName);
	    }
    }
}
