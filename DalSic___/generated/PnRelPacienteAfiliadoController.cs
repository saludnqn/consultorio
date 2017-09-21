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
    /// Controller class for PN_RelPacienteAfiliado
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnRelPacienteAfiliadoController
    {
        // Preload our schema..
        PnRelPacienteAfiliado thisSchemaLoad = new PnRelPacienteAfiliado();
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
        public PnRelPacienteAfiliadoCollection FetchAll()
        {
            PnRelPacienteAfiliadoCollection coll = new PnRelPacienteAfiliadoCollection();
            Query qry = new Query(PnRelPacienteAfiliado.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnRelPacienteAfiliadoCollection FetchByID(object IdRelPacienteAfiliado)
        {
            PnRelPacienteAfiliadoCollection coll = new PnRelPacienteAfiliadoCollection().Where("idRelPacienteAfiliado", IdRelPacienteAfiliado).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnRelPacienteAfiliadoCollection FetchByQuery(Query qry)
        {
            PnRelPacienteAfiliadoCollection coll = new PnRelPacienteAfiliadoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelPacienteAfiliado)
        {
            return (PnRelPacienteAfiliado.Delete(IdRelPacienteAfiliado) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelPacienteAfiliado)
        {
            return (PnRelPacienteAfiliado.Destroy(IdRelPacienteAfiliado) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPaciente,string Clavebeneficiario)
	    {
		    PnRelPacienteAfiliado item = new PnRelPacienteAfiliado();
		    
            item.IdPaciente = IdPaciente;
            
            item.Clavebeneficiario = Clavebeneficiario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelPacienteAfiliado,int IdPaciente,string Clavebeneficiario)
	    {
		    PnRelPacienteAfiliado item = new PnRelPacienteAfiliado();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelPacienteAfiliado = IdRelPacienteAfiliado;
				
			item.IdPaciente = IdPaciente;
				
			item.Clavebeneficiario = Clavebeneficiario;
				
	        item.Save(UserName);
	    }
    }
}
