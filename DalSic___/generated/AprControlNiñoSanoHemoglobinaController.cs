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
    /// Controller class for APR_ControlNiñoSanoHemoglobina
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprControlNiñoSanoHemoglobinaController
    {
        // Preload our schema..
        AprControlNiñoSanoHemoglobina thisSchemaLoad = new AprControlNiñoSanoHemoglobina();
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
        public AprControlNiñoSanoHemoglobinaCollection FetchAll()
        {
            AprControlNiñoSanoHemoglobinaCollection coll = new AprControlNiñoSanoHemoglobinaCollection();
            Query qry = new Query(AprControlNiñoSanoHemoglobina.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoHemoglobinaCollection FetchByID(object IdControlNiñoSanoHemoglobina)
        {
            AprControlNiñoSanoHemoglobinaCollection coll = new AprControlNiñoSanoHemoglobinaCollection().Where("idControlNiñoSanoHemoglobina", IdControlNiñoSanoHemoglobina).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprControlNiñoSanoHemoglobinaCollection FetchByQuery(Query qry)
        {
            AprControlNiñoSanoHemoglobinaCollection coll = new AprControlNiñoSanoHemoglobinaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdControlNiñoSanoHemoglobina)
        {
            return (AprControlNiñoSanoHemoglobina.Delete(IdControlNiñoSanoHemoglobina) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdControlNiñoSanoHemoglobina)
        {
            return (AprControlNiñoSanoHemoglobina.Destroy(IdControlNiñoSanoHemoglobina) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdControlNiñoSano,int? IdPaciente,decimal Valor)
	    {
		    AprControlNiñoSanoHemoglobina item = new AprControlNiñoSanoHemoglobina();
		    
            item.IdControlNiñoSano = IdControlNiñoSano;
            
            item.IdPaciente = IdPaciente;
            
            item.Valor = Valor;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdControlNiñoSanoHemoglobina,int IdControlNiñoSano,int? IdPaciente,decimal Valor)
	    {
		    AprControlNiñoSanoHemoglobina item = new AprControlNiñoSanoHemoglobina();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdControlNiñoSanoHemoglobina = IdControlNiñoSanoHemoglobina;
				
			item.IdControlNiñoSano = IdControlNiñoSano;
				
			item.IdPaciente = IdPaciente;
				
			item.Valor = Valor;
				
	        item.Save(UserName);
	    }
    }
}
