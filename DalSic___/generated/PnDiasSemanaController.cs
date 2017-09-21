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
    /// Controller class for PN_dias_semana
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnDiasSemanaController
    {
        // Preload our schema..
        PnDiasSemana thisSchemaLoad = new PnDiasSemana();
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
        public PnDiasSemanaCollection FetchAll()
        {
            PnDiasSemanaCollection coll = new PnDiasSemanaCollection();
            Query qry = new Query(PnDiasSemana.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDiasSemanaCollection FetchByID(object IdDia)
        {
            PnDiasSemanaCollection coll = new PnDiasSemanaCollection().Where("id_dia", IdDia).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnDiasSemanaCollection FetchByQuery(Query qry)
        {
            PnDiasSemanaCollection coll = new PnDiasSemanaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDia)
        {
            return (PnDiasSemana.Delete(IdDia) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDia)
        {
            return (PnDiasSemana.Destroy(IdDia) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    PnDiasSemana item = new PnDiasSemana();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDia,string Nombre)
	    {
		    PnDiasSemana item = new PnDiasSemana();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDia = IdDia;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
