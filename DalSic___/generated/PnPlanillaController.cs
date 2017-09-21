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
    /// Controller class for PN_planillas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPlanillaController
    {
        // Preload our schema..
        PnPlanilla thisSchemaLoad = new PnPlanilla();
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
        public PnPlanillaCollection FetchAll()
        {
            PnPlanillaCollection coll = new PnPlanillaCollection();
            Query qry = new Query(PnPlanilla.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPlanillaCollection FetchByID(object IdPlanillas)
        {
            PnPlanillaCollection coll = new PnPlanillaCollection().Where("id_planillas", IdPlanillas).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPlanillaCollection FetchByQuery(Query qry)
        {
            PnPlanillaCollection coll = new PnPlanillaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPlanillas)
        {
            return (PnPlanilla.Delete(IdPlanillas) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPlanillas)
        {
            return (PnPlanilla.Destroy(IdPlanillas) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdAgenteInscriptor,int IdEntrega,int IdRecibe,string Periodo,int? CantNino,int? CantEmbarazada,string Motivo,string Usuario,string Tipo,string IdEfector,DateTime? FechaHora)
	    {
		    PnPlanilla item = new PnPlanilla();
		    
            item.IdAgenteInscriptor = IdAgenteInscriptor;
            
            item.IdEntrega = IdEntrega;
            
            item.IdRecibe = IdRecibe;
            
            item.Periodo = Periodo;
            
            item.CantNino = CantNino;
            
            item.CantEmbarazada = CantEmbarazada;
            
            item.Motivo = Motivo;
            
            item.Usuario = Usuario;
            
            item.Tipo = Tipo;
            
            item.IdEfector = IdEfector;
            
            item.FechaHora = FechaHora;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPlanillas,int IdAgenteInscriptor,int IdEntrega,int IdRecibe,string Periodo,int? CantNino,int? CantEmbarazada,string Motivo,string Usuario,string Tipo,string IdEfector,DateTime? FechaHora)
	    {
		    PnPlanilla item = new PnPlanilla();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPlanillas = IdPlanillas;
				
			item.IdAgenteInscriptor = IdAgenteInscriptor;
				
			item.IdEntrega = IdEntrega;
				
			item.IdRecibe = IdRecibe;
				
			item.Periodo = Periodo;
				
			item.CantNino = CantNino;
				
			item.CantEmbarazada = CantEmbarazada;
				
			item.Motivo = Motivo;
				
			item.Usuario = Usuario;
				
			item.Tipo = Tipo;
				
			item.IdEfector = IdEfector;
				
			item.FechaHora = FechaHora;
				
	        item.Save(UserName);
	    }
    }
}
