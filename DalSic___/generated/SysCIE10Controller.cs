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
    /// Controller class for Sys_CIE10
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysCIE10Controller
    {
        // Preload our schema..
        SysCIE10 thisSchemaLoad = new SysCIE10();
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
        public SysCIE10Collection FetchAll()
        {
            SysCIE10Collection coll = new SysCIE10Collection();
            Query qry = new Query(SysCIE10.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysCIE10Collection FetchByID(object Id)
        {
            SysCIE10Collection coll = new SysCIE10Collection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysCIE10Collection FetchByQuery(Query qry)
        {
            SysCIE10Collection coll = new SysCIE10Collection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (SysCIE10.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (SysCIE10.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Capitulo,string GRUPOCIE10,string Causa,string Subcausa,string Codigo,string Nombre,string Sinonimo,string DescripCap,double? Modif,string Cepsap,bool C2)
	    {
		    SysCIE10 item = new SysCIE10();
		    
            item.Capitulo = Capitulo;
            
            item.GRUPOCIE10 = GRUPOCIE10;
            
            item.Causa = Causa;
            
            item.Subcausa = Subcausa;
            
            item.Codigo = Codigo;
            
            item.Nombre = Nombre;
            
            item.Sinonimo = Sinonimo;
            
            item.DescripCap = DescripCap;
            
            item.Modif = Modif;
            
            item.Cepsap = Cepsap;
            
            item.C2 = C2;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Capitulo,string GRUPOCIE10,string Causa,string Subcausa,string Codigo,string Nombre,string Sinonimo,string DescripCap,double? Modif,string Cepsap,bool C2)
	    {
		    SysCIE10 item = new SysCIE10();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Capitulo = Capitulo;
				
			item.GRUPOCIE10 = GRUPOCIE10;
				
			item.Causa = Causa;
				
			item.Subcausa = Subcausa;
				
			item.Codigo = Codigo;
				
			item.Nombre = Nombre;
				
			item.Sinonimo = Sinonimo;
				
			item.DescripCap = DescripCap;
				
			item.Modif = Modif;
				
			item.Cepsap = Cepsap;
				
			item.C2 = C2;
				
	        item.Save(UserName);
	    }
    }
}
