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
    /// Controller class for PN_PrestacionesNuevas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPrestacionesNuevaController
    {
        // Preload our schema..
        PnPrestacionesNueva thisSchemaLoad = new PnPrestacionesNueva();
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
        public PnPrestacionesNuevaCollection FetchAll()
        {
            PnPrestacionesNuevaCollection coll = new PnPrestacionesNuevaCollection();
            Query qry = new Query(PnPrestacionesNueva.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPrestacionesNuevaCollection FetchByID(object IdPrestacionesNuevas)
        {
            PnPrestacionesNuevaCollection coll = new PnPrestacionesNuevaCollection().Where("idPrestacionesNuevas", IdPrestacionesNuevas).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPrestacionesNuevaCollection FetchByQuery(Query qry)
        {
            PnPrestacionesNuevaCollection coll = new PnPrestacionesNuevaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPrestacionesNuevas)
        {
            return (PnPrestacionesNueva.Delete(IdPrestacionesNuevas) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPrestacionesNuevas)
        {
            return (PnPrestacionesNueva.Destroy(IdPrestacionesNuevas) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CodigoPrestacion,string DescripcionPrestacion,string Tipo,string Objeto,string Diagnostico,string MatrizExtendida,string LineaCuidado,string GrupoEtario,string DescripcionGrupoEtario,string Catastrofico,string Ccc,string Patologia,string Modulos,string Estrategicos,string MujeresEmbarazadas,string EmbarazoRiesgo,string EmbarazoNormal,string Odps,string Ppac,string Sara,string Ambulatorio,string Internacion,string HospitalDia,string Traslado,string PatologiaQuirurgica,string PatologiaPrematurez,string Ii,string Iiia,string Iiib,string Priorizadas,double? Trazadoras,string GruposCeb,string DescripcionGruposCeb,string CodigosNacer,string CodigosRural)
	    {
		    PnPrestacionesNueva item = new PnPrestacionesNueva();
		    
            item.CodigoPrestacion = CodigoPrestacion;
            
            item.DescripcionPrestacion = DescripcionPrestacion;
            
            item.Tipo = Tipo;
            
            item.Objeto = Objeto;
            
            item.Diagnostico = Diagnostico;
            
            item.MatrizExtendida = MatrizExtendida;
            
            item.LineaCuidado = LineaCuidado;
            
            item.GrupoEtario = GrupoEtario;
            
            item.DescripcionGrupoEtario = DescripcionGrupoEtario;
            
            item.Catastrofico = Catastrofico;
            
            item.Ccc = Ccc;
            
            item.Patologia = Patologia;
            
            item.Modulos = Modulos;
            
            item.Estrategicos = Estrategicos;
            
            item.MujeresEmbarazadas = MujeresEmbarazadas;
            
            item.EmbarazoRiesgo = EmbarazoRiesgo;
            
            item.EmbarazoNormal = EmbarazoNormal;
            
            item.Odps = Odps;
            
            item.Ppac = Ppac;
            
            item.Sara = Sara;
            
            item.Ambulatorio = Ambulatorio;
            
            item.Internacion = Internacion;
            
            item.HospitalDia = HospitalDia;
            
            item.Traslado = Traslado;
            
            item.PatologiaQuirurgica = PatologiaQuirurgica;
            
            item.PatologiaPrematurez = PatologiaPrematurez;
            
            item.Ii = Ii;
            
            item.Iiia = Iiia;
            
            item.Iiib = Iiib;
            
            item.Priorizadas = Priorizadas;
            
            item.Trazadoras = Trazadoras;
            
            item.GruposCeb = GruposCeb;
            
            item.DescripcionGruposCeb = DescripcionGruposCeb;
            
            item.CodigosNacer = CodigosNacer;
            
            item.CodigosRural = CodigosRural;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPrestacionesNuevas,string CodigoPrestacion,string DescripcionPrestacion,string Tipo,string Objeto,string Diagnostico,string MatrizExtendida,string LineaCuidado,string GrupoEtario,string DescripcionGrupoEtario,string Catastrofico,string Ccc,string Patologia,string Modulos,string Estrategicos,string MujeresEmbarazadas,string EmbarazoRiesgo,string EmbarazoNormal,string Odps,string Ppac,string Sara,string Ambulatorio,string Internacion,string HospitalDia,string Traslado,string PatologiaQuirurgica,string PatologiaPrematurez,string Ii,string Iiia,string Iiib,string Priorizadas,double? Trazadoras,string GruposCeb,string DescripcionGruposCeb,string CodigosNacer,string CodigosRural)
	    {
		    PnPrestacionesNueva item = new PnPrestacionesNueva();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPrestacionesNuevas = IdPrestacionesNuevas;
				
			item.CodigoPrestacion = CodigoPrestacion;
				
			item.DescripcionPrestacion = DescripcionPrestacion;
				
			item.Tipo = Tipo;
				
			item.Objeto = Objeto;
				
			item.Diagnostico = Diagnostico;
				
			item.MatrizExtendida = MatrizExtendida;
				
			item.LineaCuidado = LineaCuidado;
				
			item.GrupoEtario = GrupoEtario;
				
			item.DescripcionGrupoEtario = DescripcionGrupoEtario;
				
			item.Catastrofico = Catastrofico;
				
			item.Ccc = Ccc;
				
			item.Patologia = Patologia;
				
			item.Modulos = Modulos;
				
			item.Estrategicos = Estrategicos;
				
			item.MujeresEmbarazadas = MujeresEmbarazadas;
				
			item.EmbarazoRiesgo = EmbarazoRiesgo;
				
			item.EmbarazoNormal = EmbarazoNormal;
				
			item.Odps = Odps;
				
			item.Ppac = Ppac;
				
			item.Sara = Sara;
				
			item.Ambulatorio = Ambulatorio;
				
			item.Internacion = Internacion;
				
			item.HospitalDia = HospitalDia;
				
			item.Traslado = Traslado;
				
			item.PatologiaQuirurgica = PatologiaQuirurgica;
				
			item.PatologiaPrematurez = PatologiaPrematurez;
				
			item.Ii = Ii;
				
			item.Iiia = Iiia;
				
			item.Iiib = Iiib;
				
			item.Priorizadas = Priorizadas;
				
			item.Trazadoras = Trazadoras;
				
			item.GruposCeb = GruposCeb;
				
			item.DescripcionGruposCeb = DescripcionGruposCeb;
				
			item.CodigosNacer = CodigosNacer;
				
			item.CodigosRural = CodigosRural;
				
	        item.Save(UserName);
	    }
    }
}
