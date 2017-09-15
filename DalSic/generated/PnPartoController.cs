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
    /// Controller class for PN_partos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPartoController
    {
        // Preload our schema..
        PnParto thisSchemaLoad = new PnParto();
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
        public PnPartoCollection FetchAll()
        {
            PnPartoCollection coll = new PnPartoCollection();
            Query qry = new Query(PnParto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPartoCollection FetchByID(object IdPar)
        {
            PnPartoCollection coll = new PnPartoCollection().Where("id_par", IdPar).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPartoCollection FetchByQuery(Query qry)
        {
            PnPartoCollection coll = new PnPartoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPar)
        {
            return (PnParto.Delete(IdPar) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPar)
        {
            return (PnParto.Destroy(IdPar) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Clave,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaParto,decimal? Apgar,decimal? Peso,string Vdrl,string Antitetanica,DateTime? FechaConserjeria,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnParto item = new PnParto();
		    
            item.Cuie = Cuie;
            
            item.Clave = Clave;
            
            item.TipoDoc = TipoDoc;
            
            item.NumDoc = NumDoc;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.FechaParto = FechaParto;
            
            item.Apgar = Apgar;
            
            item.Peso = Peso;
            
            item.Vdrl = Vdrl;
            
            item.Antitetanica = Antitetanica;
            
            item.FechaConserjeria = FechaConserjeria;
            
            item.Observaciones = Observaciones;
            
            item.FechaCarga = FechaCarga;
            
            item.Usuario = Usuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPar,string Cuie,string Clave,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaParto,decimal? Apgar,decimal? Peso,string Vdrl,string Antitetanica,DateTime? FechaConserjeria,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnParto item = new PnParto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPar = IdPar;
				
			item.Cuie = Cuie;
				
			item.Clave = Clave;
				
			item.TipoDoc = TipoDoc;
				
			item.NumDoc = NumDoc;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.FechaParto = FechaParto;
				
			item.Apgar = Apgar;
				
			item.Peso = Peso;
				
			item.Vdrl = Vdrl;
				
			item.Antitetanica = Antitetanica;
				
			item.FechaConserjeria = FechaConserjeria;
				
			item.Observaciones = Observaciones;
				
			item.FechaCarga = FechaCarga;
				
			item.Usuario = Usuario;
				
	        item.Save(UserName);
	    }
    }
}
