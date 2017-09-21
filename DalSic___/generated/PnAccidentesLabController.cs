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
    /// Controller class for PN_accidentes_lab
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnAccidentesLabController
    {
        // Preload our schema..
        PnAccidentesLab thisSchemaLoad = new PnAccidentesLab();
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
        public PnAccidentesLabCollection FetchAll()
        {
            PnAccidentesLabCollection coll = new PnAccidentesLabCollection();
            Query qry = new Query(PnAccidentesLab.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAccidentesLabCollection FetchByID(object IdAccidentesLab)
        {
            PnAccidentesLabCollection coll = new PnAccidentesLabCollection().Where("id_accidentes_lab", IdAccidentesLab).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnAccidentesLabCollection FetchByQuery(Query qry)
        {
            PnAccidentesLabCollection coll = new PnAccidentesLabCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdAccidentesLab)
        {
            return (PnAccidentesLab.Delete(IdAccidentesLab) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdAccidentesLab)
        {
            return (PnAccidentesLab.Destroy(IdAccidentesLab) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime? FechInicio,string Descripcion,string Art,string NumArt,DateTime? FechInicioArt,int IdLegajo,string Titulo)
	    {
		    PnAccidentesLab item = new PnAccidentesLab();
		    
            item.FechInicio = FechInicio;
            
            item.Descripcion = Descripcion;
            
            item.Art = Art;
            
            item.NumArt = NumArt;
            
            item.FechInicioArt = FechInicioArt;
            
            item.IdLegajo = IdLegajo;
            
            item.Titulo = Titulo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdAccidentesLab,DateTime? FechInicio,string Descripcion,string Art,string NumArt,DateTime? FechInicioArt,int IdLegajo,string Titulo)
	    {
		    PnAccidentesLab item = new PnAccidentesLab();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdAccidentesLab = IdAccidentesLab;
				
			item.FechInicio = FechInicio;
				
			item.Descripcion = Descripcion;
				
			item.Art = Art;
				
			item.NumArt = NumArt;
				
			item.FechInicioArt = FechInicioArt;
				
			item.IdLegajo = IdLegajo;
				
			item.Titulo = Titulo;
				
	        item.Save(UserName);
	    }
    }
}
