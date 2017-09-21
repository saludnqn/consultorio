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
    /// Controller class for PN_smiafiliados
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnSmiafiliadoController
    {
        // Preload our schema..
        PnSmiafiliado thisSchemaLoad = new PnSmiafiliado();
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
        public PnSmiafiliadoCollection FetchAll()
        {
            PnSmiafiliadoCollection coll = new PnSmiafiliadoCollection();
            Query qry = new Query(PnSmiafiliado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmiafiliadoCollection FetchByID(object IdSmiafiliados)
        {
            PnSmiafiliadoCollection coll = new PnSmiafiliadoCollection().Where("id_smiafiliados", IdSmiafiliados).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnSmiafiliadoCollection FetchByQuery(Query qry)
        {
            PnSmiafiliadoCollection coll = new PnSmiafiliadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSmiafiliados)
        {
            return (PnSmiafiliado.Delete(IdSmiafiliados) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSmiafiliados)
        {
            return (PnSmiafiliado.Destroy(IdSmiafiliados) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Clavebeneficiario,string Afiapellido,string Afinombre,string Afitipodoc,string Aficlasedoc,string Afidni,string Afisexo,string Afidomdepartamento,string Afidomlocalidad,int? Afitipocategoria,DateTime? Afifechanac,string Activo,string Cuieefectorasignado,string Cuielugaratencionhabitual,int? Motivobaja,string Mensajebaja,DateTime? Fechainscripcion,DateTime? Fechacarga,string Usuariocarga,string Embarazoactual)
	    {
		    PnSmiafiliado item = new PnSmiafiliado();
		    
            item.Clavebeneficiario = Clavebeneficiario;
            
            item.Afiapellido = Afiapellido;
            
            item.Afinombre = Afinombre;
            
            item.Afitipodoc = Afitipodoc;
            
            item.Aficlasedoc = Aficlasedoc;
            
            item.Afidni = Afidni;
            
            item.Afisexo = Afisexo;
            
            item.Afidomdepartamento = Afidomdepartamento;
            
            item.Afidomlocalidad = Afidomlocalidad;
            
            item.Afitipocategoria = Afitipocategoria;
            
            item.Afifechanac = Afifechanac;
            
            item.Activo = Activo;
            
            item.Cuieefectorasignado = Cuieefectorasignado;
            
            item.Cuielugaratencionhabitual = Cuielugaratencionhabitual;
            
            item.Motivobaja = Motivobaja;
            
            item.Mensajebaja = Mensajebaja;
            
            item.Fechainscripcion = Fechainscripcion;
            
            item.Fechacarga = Fechacarga;
            
            item.Usuariocarga = Usuariocarga;
            
            item.Embarazoactual = Embarazoactual;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSmiafiliados,string Clavebeneficiario,string Afiapellido,string Afinombre,string Afitipodoc,string Aficlasedoc,string Afidni,string Afisexo,string Afidomdepartamento,string Afidomlocalidad,int? Afitipocategoria,DateTime? Afifechanac,string Activo,string Cuieefectorasignado,string Cuielugaratencionhabitual,int? Motivobaja,string Mensajebaja,DateTime? Fechainscripcion,DateTime? Fechacarga,string Usuariocarga,string Embarazoactual)
	    {
		    PnSmiafiliado item = new PnSmiafiliado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSmiafiliados = IdSmiafiliados;
				
			item.Clavebeneficiario = Clavebeneficiario;
				
			item.Afiapellido = Afiapellido;
				
			item.Afinombre = Afinombre;
				
			item.Afitipodoc = Afitipodoc;
				
			item.Aficlasedoc = Aficlasedoc;
				
			item.Afidni = Afidni;
				
			item.Afisexo = Afisexo;
				
			item.Afidomdepartamento = Afidomdepartamento;
				
			item.Afidomlocalidad = Afidomlocalidad;
				
			item.Afitipocategoria = Afitipocategoria;
				
			item.Afifechanac = Afifechanac;
				
			item.Activo = Activo;
				
			item.Cuieefectorasignado = Cuieefectorasignado;
				
			item.Cuielugaratencionhabitual = Cuielugaratencionhabitual;
				
			item.Motivobaja = Motivobaja;
				
			item.Mensajebaja = Mensajebaja;
				
			item.Fechainscripcion = Fechainscripcion;
				
			item.Fechacarga = Fechacarga;
				
			item.Usuariocarga = Usuariocarga;
				
			item.Embarazoactual = Embarazoactual;
				
	        item.Save(UserName);
	    }
    }
}
