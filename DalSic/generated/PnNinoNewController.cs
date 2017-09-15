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
    /// Controller class for PN_nino_new
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnNinoNewController
    {
        // Preload our schema..
        PnNinoNew thisSchemaLoad = new PnNinoNew();
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
        public PnNinoNewCollection FetchAll()
        {
            PnNinoNewCollection coll = new PnNinoNewCollection();
            Query qry = new Query(PnNinoNew.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNinoNewCollection FetchByID(object IdNinoNew)
        {
            PnNinoNewCollection coll = new PnNinoNewCollection().Where("id_nino_new", IdNinoNew).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnNinoNewCollection FetchByQuery(Query qry)
        {
            PnNinoNewCollection coll = new PnNinoNewCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdNinoNew)
        {
            return (PnNinoNew.Delete(IdNinoNew) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdNinoNew)
        {
            return (PnNinoNew.Destroy(IdNinoNew) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Cuie,string Clave,string ClaseDoc,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaNac,DateTime? FechaControl,decimal? Peso,decimal? Talla,string PercenPesoEdad,string PercenTallaEdad,decimal? PerimCefalico,string PercenPerimCefaliEdad,string Imc,string PercenImcEdad,string PercenPesoTalla,DateTime? TripleViral,int? NinoEdad,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnNinoNew item = new PnNinoNew();
		    
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
            
            item.PercenPesoEdad = PercenPesoEdad;
            
            item.PercenTallaEdad = PercenTallaEdad;
            
            item.PerimCefalico = PerimCefalico;
            
            item.PercenPerimCefaliEdad = PercenPerimCefaliEdad;
            
            item.Imc = Imc;
            
            item.PercenImcEdad = PercenImcEdad;
            
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
	    public void Update(int IdNinoNew,string Cuie,string Clave,string ClaseDoc,string TipoDoc,decimal? NumDoc,string Apellido,string Nombre,DateTime? FechaNac,DateTime? FechaControl,decimal? Peso,decimal? Talla,string PercenPesoEdad,string PercenTallaEdad,decimal? PerimCefalico,string PercenPerimCefaliEdad,string Imc,string PercenImcEdad,string PercenPesoTalla,DateTime? TripleViral,int? NinoEdad,string Observaciones,DateTime? FechaCarga,string Usuario)
	    {
		    PnNinoNew item = new PnNinoNew();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdNinoNew = IdNinoNew;
				
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
				
			item.PercenPesoEdad = PercenPesoEdad;
				
			item.PercenTallaEdad = PercenTallaEdad;
				
			item.PerimCefalico = PerimCefalico;
				
			item.PercenPerimCefaliEdad = PercenPerimCefaliEdad;
				
			item.Imc = Imc;
				
			item.PercenImcEdad = PercenImcEdad;
				
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
