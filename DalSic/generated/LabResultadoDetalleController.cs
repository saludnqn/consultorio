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
    /// Controller class for LAB_ResultadoDetalle
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabResultadoDetalleController
    {
        // Preload our schema..
        LabResultadoDetalle thisSchemaLoad = new LabResultadoDetalle();
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
        public LabResultadoDetalleCollection FetchAll()
        {
            LabResultadoDetalleCollection coll = new LabResultadoDetalleCollection();
            Query qry = new Query(LabResultadoDetalle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabResultadoDetalleCollection FetchByID(object IdProtocolo)
        {
            LabResultadoDetalleCollection coll = new LabResultadoDetalleCollection().Where("idProtocolo", IdProtocolo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabResultadoDetalleCollection FetchByQuery(Query qry)
        {
            LabResultadoDetalleCollection coll = new LabResultadoDetalleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProtocolo)
        {
            return (LabResultadoDetalle.Delete(IdProtocolo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProtocolo)
        {
            return (LabResultadoDetalle.Destroy(IdProtocolo) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int IdProtocolo,int IdEfector,int IdDetalleProtocolo)
        {
            Query qry = new Query(LabResultadoDetalle.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("IdProtocolo", IdProtocolo).AND("IdEfector", IdEfector).AND("IdDetalleProtocolo", IdDetalleProtocolo);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdProtocolo,int IdEfector,int IdDetalleProtocolo,string Codigo,int OrdenArea,int Orden,string Area,string Grupo,string Item,string Observaciones,string EsTitulo,string Derivado,string Unidad,bool? Hiv,string Metodo,string ValorReferencia,int Orden1,string Muestra,int Conresultado,string Resultado,string Codigo2,string CodigoNomenclador,string ProfesionalVal)
	    {
		    LabResultadoDetalle item = new LabResultadoDetalle();
		    
            item.IdProtocolo = IdProtocolo;
            
            item.IdEfector = IdEfector;
            
            item.IdDetalleProtocolo = IdDetalleProtocolo;
            
            item.Codigo = Codigo;
            
            item.OrdenArea = OrdenArea;
            
            item.Orden = Orden;
            
            item.Area = Area;
            
            item.Grupo = Grupo;
            
            item.Item = Item;
            
            item.Observaciones = Observaciones;
            
            item.EsTitulo = EsTitulo;
            
            item.Derivado = Derivado;
            
            item.Unidad = Unidad;
            
            item.Hiv = Hiv;
            
            item.Metodo = Metodo;
            
            item.ValorReferencia = ValorReferencia;
            
            item.Orden1 = Orden1;
            
            item.Muestra = Muestra;
            
            item.Conresultado = Conresultado;
            
            item.Resultado = Resultado;
            
            item.Codigo2 = Codigo2;
            
            item.CodigoNomenclador = CodigoNomenclador;
            
            item.ProfesionalVal = ProfesionalVal;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdProtocolo,int IdEfector,int IdDetalleProtocolo,string Codigo,int OrdenArea,int Orden,string Area,string Grupo,string Item,string Observaciones,string EsTitulo,string Derivado,string Unidad,bool? Hiv,string Metodo,string ValorReferencia,int Orden1,string Muestra,int Conresultado,string Resultado,string Codigo2,string CodigoNomenclador,string ProfesionalVal)
	    {
		    LabResultadoDetalle item = new LabResultadoDetalle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProtocolo = IdProtocolo;
				
			item.IdEfector = IdEfector;
				
			item.IdDetalleProtocolo = IdDetalleProtocolo;
				
			item.Codigo = Codigo;
				
			item.OrdenArea = OrdenArea;
				
			item.Orden = Orden;
				
			item.Area = Area;
				
			item.Grupo = Grupo;
				
			item.Item = Item;
				
			item.Observaciones = Observaciones;
				
			item.EsTitulo = EsTitulo;
				
			item.Derivado = Derivado;
				
			item.Unidad = Unidad;
				
			item.Hiv = Hiv;
				
			item.Metodo = Metodo;
				
			item.ValorReferencia = ValorReferencia;
				
			item.Orden1 = Orden1;
				
			item.Muestra = Muestra;
				
			item.Conresultado = Conresultado;
				
			item.Resultado = Resultado;
				
			item.Codigo2 = Codigo2;
				
			item.CodigoNomenclador = CodigoNomenclador;
				
			item.ProfesionalVal = ProfesionalVal;
				
	        item.Save(UserName);
	    }
    }
}
