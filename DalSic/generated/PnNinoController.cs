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
    /// Controller class for PN_nino
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnNinoController
    {
        // Preload our schema..
        PnNino thisSchemaLoad = new PnNino();
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
        public PnNinoCollection FetchAll()
        {
            PnNinoCollection coll = new PnNinoCollection();
            Query qry = new Query(PnNino.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNinoCollection FetchByID(object IdNino)
        {
            PnNinoCollection coll = new PnNinoCollection().Where("id_nino", IdNino).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNinoCollection FetchByQuery(Query qry)
        {
            PnNinoCollection coll = new PnNinoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNino)
        {
            return (PnNino.Delete(IdNino) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNino)
        {
            return (PnNino.Destroy(IdNino) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Clave,string ClaseDoc,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaNac,DateTime? FechaControl,decimal? Peso,decimal? Talla,decimal? PerimCefalico,string PercenPesoEdad,string PercenTallaEdad,string PercenPerimCefaliEdad,string PercenPesoTalla,DateTime? TripleViral,int? NinoEdad,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnNino item = new PnNino();
		    
            item.Cuie = Cuie;
            
            item.Clave = Clave;
            
            item.ClaseDoc = ClaseDoc;
            
            item.TipoDoc = TipoDoc;
            
            item.NumDoc = NumDoc;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.FechaNac = FechaNac;
            
            item.FechaControl = FechaControl;
            
            item.Peso = Peso;
            
            item.Talla = Talla;
            
            item.PerimCefalico = PerimCefalico;
            
            item.PercenPesoEdad = PercenPesoEdad;
            
            item.PercenTallaEdad = PercenTallaEdad;
            
            item.PercenPerimCefaliEdad = PercenPerimCefaliEdad;
            
            item.PercenPesoTalla = PercenPesoTalla;
            
            item.TripleViral = TripleViral;
            
            item.NinoEdad = NinoEdad;
            
            item.Observaciones = Observaciones;
            
            item.FechaCarga = FechaCarga;
            
            item.Usuario = Usuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdNino,string Cuie,string Clave,string ClaseDoc,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaNac,DateTime? FechaControl,decimal? Peso,decimal? Talla,decimal? PerimCefalico,string PercenPesoEdad,string PercenTallaEdad,string PercenPerimCefaliEdad,string PercenPesoTalla,DateTime? TripleViral,int? NinoEdad,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnNino item = new PnNino();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNino = IdNino;
				
			item.Cuie = Cuie;
				
			item.Clave = Clave;
				
			item.ClaseDoc = ClaseDoc;
				
			item.TipoDoc = TipoDoc;
				
			item.NumDoc = NumDoc;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.FechaNac = FechaNac;
				
			item.FechaControl = FechaControl;
				
			item.Peso = Peso;
				
			item.Talla = Talla;
				
			item.PerimCefalico = PerimCefalico;
				
			item.PercenPesoEdad = PercenPesoEdad;
				
			item.PercenTallaEdad = PercenTallaEdad;
				
			item.PercenPerimCefaliEdad = PercenPerimCefaliEdad;
				
			item.PercenPesoTalla = PercenPesoTalla;
				
			item.TripleViral = TripleViral;
				
			item.NinoEdad = NinoEdad;
				
			item.Observaciones = Observaciones;
				
			item.FechaCarga = FechaCarga;
				
			item.Usuario = Usuario;
				
	        item.Save(UserName);
	    }
    }
}
