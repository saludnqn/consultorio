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
    /// Controller class for PN_mu
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnMuController
    {
        // Preload our schema..
        PnMu thisSchemaLoad = new PnMu();
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
        public PnMuCollection FetchAll()
        {
            PnMuCollection coll = new PnMuCollection();
            Query qry = new Query(PnMu.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMuCollection FetchByID(object IdMu)
        {
            PnMuCollection coll = new PnMuCollection().Where("id_mu", IdMu).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnMuCollection FetchByQuery(Query qry)
        {
            PnMuCollection coll = new PnMuCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMu)
        {
            return (PnMu.Delete(IdMu) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMu)
        {
            return (PnMu.Destroy(IdMu) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaDefuncion,DateTime? FechaAuditoria,DateTime? FechaParInt,DateTime? FechaNac,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnMu item = new PnMu();
		    
            item.Cuie = Cuie;
            
            item.TipoDoc = TipoDoc;
            
            item.NumDoc = NumDoc;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.FechaDefuncion = FechaDefuncion;
            
            item.FechaAuditoria = FechaAuditoria;
            
            item.FechaParInt = FechaParInt;
            
            item.FechaNac = FechaNac;
            
            item.Observaciones = Observaciones;
            
            item.FechaCarga = FechaCarga;
            
            item.Usuario = Usuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMu,string Cuie,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaDefuncion,DateTime? FechaAuditoria,DateTime? FechaParInt,DateTime? FechaNac,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnMu item = new PnMu();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMu = IdMu;
				
			item.Cuie = Cuie;
				
			item.TipoDoc = TipoDoc;
				
			item.NumDoc = NumDoc;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.FechaDefuncion = FechaDefuncion;
				
			item.FechaAuditoria = FechaAuditoria;
				
			item.FechaParInt = FechaParInt;
				
			item.FechaNac = FechaNac;
				
			item.Observaciones = Observaciones;
				
			item.FechaCarga = FechaCarga;
				
			item.Usuario = Usuario;
				
	        item.Save(UserName);
	    }
    }
}
