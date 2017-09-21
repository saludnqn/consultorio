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
    /// Controller class for Sys_Antecedente
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysAntecedenteController
    {
        // Preload our schema..
        SysAntecedente thisSchemaLoad = new SysAntecedente();
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
        public SysAntecedenteCollection FetchAll()
        {
            SysAntecedenteCollection coll = new SysAntecedenteCollection();
            Query qry = new Query(SysAntecedente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysAntecedenteCollection FetchByID(object IdAntecedente)
        {
            SysAntecedenteCollection coll = new SysAntecedenteCollection().Where("idAntecedente", IdAntecedente).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysAntecedenteCollection FetchByQuery(Query qry)
        {
            SysAntecedenteCollection coll = new SysAntecedenteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAntecedente)
        {
            return (SysAntecedente.Delete(IdAntecedente) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAntecedente)
        {
            return (SysAntecedente.Destroy(IdAntecedente) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int? IdTipoAntecedente,int Grupo,bool Activo)
	    {
		    SysAntecedente item = new SysAntecedente();
		    
            item.Nombre = Nombre;
            
            item.IdTipoAntecedente = IdTipoAntecedente;
            
            item.Grupo = Grupo;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAntecedente,string Nombre,int? IdTipoAntecedente,int Grupo,bool Activo)
	    {
		    SysAntecedente item = new SysAntecedente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAntecedente = IdAntecedente;
				
			item.Nombre = Nombre;
				
			item.IdTipoAntecedente = IdTipoAntecedente;
				
			item.Grupo = Grupo;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
