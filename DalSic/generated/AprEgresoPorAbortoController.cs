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
    /// Controller class for APR_EgresoPorAborto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprEgresoPorAbortoController
    {
        // Preload our schema..
        AprEgresoPorAborto thisSchemaLoad = new AprEgresoPorAborto();
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
        public AprEgresoPorAbortoCollection FetchAll()
        {
            AprEgresoPorAbortoCollection coll = new AprEgresoPorAbortoCollection();
            Query qry = new Query(AprEgresoPorAborto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEgresoPorAbortoCollection FetchByID(object IdEgresoPorAborto)
        {
            AprEgresoPorAbortoCollection coll = new AprEgresoPorAbortoCollection().Where("idEgresoPorAborto", IdEgresoPorAborto).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEgresoPorAbortoCollection FetchByQuery(Query qry)
        {
            AprEgresoPorAbortoCollection coll = new AprEgresoPorAbortoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEgresoPorAborto)
        {
            return (AprEgresoPorAborto.Delete(IdEgresoPorAborto) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEgresoPorAborto)
        {
            return (AprEgresoPorAborto.Destroy(IdEgresoPorAborto) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdAborto,DateTime FechaHora,int? IdTipoEgreso,int? IdEstadoEgreso,int? DIAGCIE10,int? IdTratamientoEgresoAborto,int? IdTraslado,bool? Autopsia,bool? IniciaMetodoAnticonceptivo,int? IdMetodoAnticonceptivoPreferido,int? IdMetodoAnticonceptivoAccedido,string Responsable)
	    {
		    AprEgresoPorAborto item = new AprEgresoPorAborto();
		    
            item.IdEfector = IdEfector;
            
            item.IdAborto = IdAborto;
            
            item.FechaHora = FechaHora;
            
            item.IdTipoEgreso = IdTipoEgreso;
            
            item.IdEstadoEgreso = IdEstadoEgreso;
            
            item.DIAGCIE10 = DIAGCIE10;
            
            item.IdTratamientoEgresoAborto = IdTratamientoEgresoAborto;
            
            item.IdTraslado = IdTraslado;
            
            item.Autopsia = Autopsia;
            
            item.IniciaMetodoAnticonceptivo = IniciaMetodoAnticonceptivo;
            
            item.IdMetodoAnticonceptivoPreferido = IdMetodoAnticonceptivoPreferido;
            
            item.IdMetodoAnticonceptivoAccedido = IdMetodoAnticonceptivoAccedido;
            
            item.Responsable = Responsable;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEgresoPorAborto,int IdEfector,int IdAborto,DateTime FechaHora,int? IdTipoEgreso,int? IdEstadoEgreso,int? DIAGCIE10,int? IdTratamientoEgresoAborto,int? IdTraslado,bool? Autopsia,bool? IniciaMetodoAnticonceptivo,int? IdMetodoAnticonceptivoPreferido,int? IdMetodoAnticonceptivoAccedido,string Responsable)
	    {
		    AprEgresoPorAborto item = new AprEgresoPorAborto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEgresoPorAborto = IdEgresoPorAborto;
				
			item.IdEfector = IdEfector;
				
			item.IdAborto = IdAborto;
				
			item.FechaHora = FechaHora;
				
			item.IdTipoEgreso = IdTipoEgreso;
				
			item.IdEstadoEgreso = IdEstadoEgreso;
				
			item.DIAGCIE10 = DIAGCIE10;
				
			item.IdTratamientoEgresoAborto = IdTratamientoEgresoAborto;
				
			item.IdTraslado = IdTraslado;
				
			item.Autopsia = Autopsia;
				
			item.IniciaMetodoAnticonceptivo = IniciaMetodoAnticonceptivo;
				
			item.IdMetodoAnticonceptivoPreferido = IdMetodoAnticonceptivoPreferido;
				
			item.IdMetodoAnticonceptivoAccedido = IdMetodoAnticonceptivoAccedido;
				
			item.Responsable = Responsable;
				
	        item.Save(UserName);
	    }
    }
}
