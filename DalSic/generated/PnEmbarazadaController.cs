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
    /// Controller class for PN_embarazadas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnEmbarazadaController
    {
        // Preload our schema..
        PnEmbarazada thisSchemaLoad = new PnEmbarazada();
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
        public PnEmbarazadaCollection FetchAll()
        {
            PnEmbarazadaCollection coll = new PnEmbarazadaCollection();
            Query qry = new Query(PnEmbarazada.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEmbarazadaCollection FetchByID(object IdEmb)
        {
            PnEmbarazadaCollection coll = new PnEmbarazadaCollection().Where("id_emb", IdEmb).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnEmbarazadaCollection FetchByQuery(Query qry)
        {
            PnEmbarazadaCollection coll = new PnEmbarazadaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEmb)
        {
            return (PnEmbarazada.Delete(IdEmb) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEmb)
        {
            return (PnEmbarazada.Destroy(IdEmb) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Clave,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaControl,decimal? SemGestacion,DateTime? Fum,DateTime? Fpp,DateTime? Fpcp,string Observaciones,DateTime? FechaCarga,string Usuario,string Antitetanica,string Vdrl)
	    {
		    PnEmbarazada item = new PnEmbarazada();
		    
            item.Cuie = Cuie;
            
            item.Clave = Clave;
            
            item.TipoDoc = TipoDoc;
            
            item.NumDoc = NumDoc;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.FechaControl = FechaControl;
            
            item.SemGestacion = SemGestacion;
            
            item.Fum = Fum;
            
            item.Fpp = Fpp;
            
            item.Fpcp = Fpcp;
            
            item.Observaciones = Observaciones;
            
            item.FechaCarga = FechaCarga;
            
            item.Usuario = Usuario;
            
            item.Antitetanica = Antitetanica;
            
            item.Vdrl = Vdrl;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEmb,string Cuie,string Clave,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaControl,decimal? SemGestacion,DateTime? Fum,DateTime? Fpp,DateTime? Fpcp,string Observaciones,DateTime? FechaCarga,string Usuario,string Antitetanica,string Vdrl)
	    {
		    PnEmbarazada item = new PnEmbarazada();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEmb = IdEmb;
				
			item.Cuie = Cuie;
				
			item.Clave = Clave;
				
			item.TipoDoc = TipoDoc;
				
			item.NumDoc = NumDoc;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.FechaControl = FechaControl;
				
			item.SemGestacion = SemGestacion;
				
			item.Fum = Fum;
				
			item.Fpp = Fpp;
				
			item.Fpcp = Fpcp;
				
			item.Observaciones = Observaciones;
				
			item.FechaCarga = FechaCarga;
				
			item.Usuario = Usuario;
				
			item.Antitetanica = Antitetanica;
				
			item.Vdrl = Vdrl;
				
	        item.Save(UserName);
	    }
    }
}
