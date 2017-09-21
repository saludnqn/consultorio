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
    /// Controller class for Sys_Especialidad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysEspecialidadController
    {
        // Preload our schema..
        SysEspecialidad thisSchemaLoad = new SysEspecialidad();
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
        public SysEspecialidadCollection FetchAll()
        {
            SysEspecialidadCollection coll = new SysEspecialidadCollection();
            Query qry = new Query(SysEspecialidad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEspecialidadCollection FetchByID(object IdEspecialidad)
        {
            SysEspecialidadCollection coll = new SysEspecialidadCollection().Where("idEspecialidad", IdEspecialidad).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysEspecialidadCollection FetchByQuery(Query qry)
        {
            SysEspecialidadCollection coll = new SysEspecialidadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEspecialidad)
        {
            return (SysEspecialidad.Delete(IdEspecialidad) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEspecialidad)
        {
            return (SysEspecialidad.Destroy(IdEspecialidad) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int Codigo,string BackColor,string ForeColor,int CodigoNacion,string UnidadOperativa)
	    {
		    SysEspecialidad item = new SysEspecialidad();
		    
            item.Nombre = Nombre;
            
            item.Codigo = Codigo;
            
            item.BackColor = BackColor;
            
            item.ForeColor = ForeColor;
            
            item.CodigoNacion = CodigoNacion;
            
            item.UnidadOperativa = UnidadOperativa;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEspecialidad,string Nombre,int Codigo,string BackColor,string ForeColor,int CodigoNacion,string UnidadOperativa)
	    {
		    SysEspecialidad item = new SysEspecialidad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEspecialidad = IdEspecialidad;
				
			item.Nombre = Nombre;
				
			item.Codigo = Codigo;
				
			item.BackColor = BackColor;
				
			item.ForeColor = ForeColor;
				
			item.CodigoNacion = CodigoNacion;
				
			item.UnidadOperativa = UnidadOperativa;
				
	        item.Save(UserName);
	    }
    }
}
