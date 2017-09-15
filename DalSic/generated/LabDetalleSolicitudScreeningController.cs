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
    /// Controller class for LAB_DetalleSolicitudScreening
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabDetalleSolicitudScreeningController
    {
        // Preload our schema..
        LabDetalleSolicitudScreening thisSchemaLoad = new LabDetalleSolicitudScreening();
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
        public LabDetalleSolicitudScreeningCollection FetchAll()
        {
            LabDetalleSolicitudScreeningCollection coll = new LabDetalleSolicitudScreeningCollection();
            Query qry = new Query(LabDetalleSolicitudScreening.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabDetalleSolicitudScreeningCollection FetchByID(object IdDetalleSolicitudScreening)
        {
            LabDetalleSolicitudScreeningCollection coll = new LabDetalleSolicitudScreeningCollection().Where("idDetalleSolicitudScreening", IdDetalleSolicitudScreening).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabDetalleSolicitudScreeningCollection FetchByQuery(Query qry)
        {
            LabDetalleSolicitudScreeningCollection coll = new LabDetalleSolicitudScreeningCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDetalleSolicitudScreening)
        {
            return (LabDetalleSolicitudScreening.Delete(IdDetalleSolicitudScreening) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDetalleSolicitudScreening)
        {
            return (LabDetalleSolicitudScreening.Destroy(IdDetalleSolicitudScreening) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdSolicitudScreening,int IdItem,string Resultado,string Metodo,string ValorReferencia,string IdUsuarioResultado,DateTime FechaResultado,string IdUsuarioValida,DateTime FechaValida,string ValorEncontrado,int? IdResultado)
	    {
		    LabDetalleSolicitudScreening item = new LabDetalleSolicitudScreening();
		    
            item.IdSolicitudScreening = IdSolicitudScreening;
            
            item.IdItem = IdItem;
            
            item.Resultado = Resultado;
            
            item.Metodo = Metodo;
            
            item.ValorReferencia = ValorReferencia;
            
            item.IdUsuarioResultado = IdUsuarioResultado;
            
            item.FechaResultado = FechaResultado;
            
            item.IdUsuarioValida = IdUsuarioValida;
            
            item.FechaValida = FechaValida;
            
            item.ValorEncontrado = ValorEncontrado;
            
            item.IdResultado = IdResultado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDetalleSolicitudScreening,int IdSolicitudScreening,int IdItem,string Resultado,string Metodo,string ValorReferencia,string IdUsuarioResultado,DateTime FechaResultado,string IdUsuarioValida,DateTime FechaValida,string ValorEncontrado,int? IdResultado)
	    {
		    LabDetalleSolicitudScreening item = new LabDetalleSolicitudScreening();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDetalleSolicitudScreening = IdDetalleSolicitudScreening;
				
			item.IdSolicitudScreening = IdSolicitudScreening;
				
			item.IdItem = IdItem;
				
			item.Resultado = Resultado;
				
			item.Metodo = Metodo;
				
			item.ValorReferencia = ValorReferencia;
				
			item.IdUsuarioResultado = IdUsuarioResultado;
				
			item.FechaResultado = FechaResultado;
				
			item.IdUsuarioValida = IdUsuarioValida;
				
			item.FechaValida = FechaValida;
				
			item.ValorEncontrado = ValorEncontrado;
				
			item.IdResultado = IdResultado;
				
	        item.Save(UserName);
	    }
    }
}
