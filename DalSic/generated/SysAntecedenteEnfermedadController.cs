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
    /// Controller class for Sys_AntecedenteEnfermedad
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysAntecedenteEnfermedadController
    {
        // Preload our schema..
        SysAntecedenteEnfermedad thisSchemaLoad = new SysAntecedenteEnfermedad();
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
        public SysAntecedenteEnfermedadCollection FetchAll()
        {
            SysAntecedenteEnfermedadCollection coll = new SysAntecedenteEnfermedadCollection();
            Query qry = new Query(SysAntecedenteEnfermedad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysAntecedenteEnfermedadCollection FetchByID(object IdAntecedenteEnfermedad)
        {
            SysAntecedenteEnfermedadCollection coll = new SysAntecedenteEnfermedadCollection().Where("idAntecedenteEnfermedad", IdAntecedenteEnfermedad).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysAntecedenteEnfermedadCollection FetchByQuery(Query qry)
        {
            SysAntecedenteEnfermedadCollection coll = new SysAntecedenteEnfermedadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAntecedenteEnfermedad)
        {
            return (SysAntecedenteEnfermedad.Delete(IdAntecedenteEnfermedad) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAntecedenteEnfermedad)
        {
            return (SysAntecedenteEnfermedad.Destroy(IdAntecedenteEnfermedad) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,DateTime FechaRegistro,bool? Familiar,string TipoParentezco,int CODCIE10)
	    {
		    SysAntecedenteEnfermedad item = new SysAntecedenteEnfermedad();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.FechaRegistro = FechaRegistro;
            
            item.Familiar = Familiar;
            
            item.TipoParentezco = TipoParentezco;
            
            item.CODCIE10 = CODCIE10;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAntecedenteEnfermedad,int IdEfector,int IdPaciente,DateTime FechaRegistro,bool? Familiar,string TipoParentezco,int CODCIE10)
	    {
		    SysAntecedenteEnfermedad item = new SysAntecedenteEnfermedad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAntecedenteEnfermedad = IdAntecedenteEnfermedad;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.FechaRegistro = FechaRegistro;
				
			item.Familiar = Familiar;
				
			item.TipoParentezco = TipoParentezco;
				
			item.CODCIE10 = CODCIE10;
				
	        item.Save(UserName);
	    }
    }
}
