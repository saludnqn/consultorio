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
    /// Controller class for PN_egreso
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEgresoController
    {
        // Preload our schema..
        PnEgreso thisSchemaLoad = new PnEgreso();
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
        public PnEgresoCollection FetchAll()
        {
            PnEgresoCollection coll = new PnEgresoCollection();
            Query qry = new Query(PnEgreso.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEgresoCollection FetchByID(object IdEgreso)
        {
            PnEgresoCollection coll = new PnEgresoCollection().Where("id_egreso", IdEgreso).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEgresoCollection FetchByQuery(Query qry)
        {
            PnEgresoCollection coll = new PnEgresoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEgreso)
        {
            return (PnEgreso.Delete(IdEgreso) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEgreso)
        {
            return (PnEgreso.Destroy(IdEgreso) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,decimal? MontoEgreso,DateTime? FechaEgreso,string Comentario,string Usuario,DateTime? Fecha,int? IdServicio,int? IdInciso,decimal? MontoEgreComp,DateTime? FechaEgreComp,DateTime? FechaDeposito,int? IdItemGasto)
	    {
		    PnEgreso item = new PnEgreso();
		    
            item.Cuie = Cuie;
            
            item.MontoEgreso = MontoEgreso;
            
            item.FechaEgreso = FechaEgreso;
            
            item.Comentario = Comentario;
            
            item.Usuario = Usuario;
            
            item.Fecha = Fecha;
            
            item.IdServicio = IdServicio;
            
            item.IdInciso = IdInciso;
            
            item.MontoEgreComp = MontoEgreComp;
            
            item.FechaEgreComp = FechaEgreComp;
            
            item.FechaDeposito = FechaDeposito;
            
            item.IdItemGasto = IdItemGasto;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEgreso,string Cuie,decimal? MontoEgreso,DateTime? FechaEgreso,string Comentario,string Usuario,DateTime? Fecha,int? IdServicio,int? IdInciso,decimal? MontoEgreComp,DateTime? FechaEgreComp,DateTime? FechaDeposito,int? IdItemGasto)
	    {
		    PnEgreso item = new PnEgreso();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEgreso = IdEgreso;
				
			item.Cuie = Cuie;
				
			item.MontoEgreso = MontoEgreso;
				
			item.FechaEgreso = FechaEgreso;
				
			item.Comentario = Comentario;
				
			item.Usuario = Usuario;
				
			item.Fecha = Fecha;
				
			item.IdServicio = IdServicio;
				
			item.IdInciso = IdInciso;
				
			item.MontoEgreComp = MontoEgreComp;
				
			item.FechaEgreComp = FechaEgreComp;
				
			item.FechaDeposito = FechaDeposito;
				
			item.IdItemGasto = IdItemGasto;
				
	        item.Save(UserName);
	    }
    }
}
