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
    /// Controller class for APR_Embarazo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AprEmbarazoController
    {
        // Preload our schema..
        AprEmbarazo thisSchemaLoad = new AprEmbarazo();
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
        public AprEmbarazoCollection FetchAll()
        {
            AprEmbarazoCollection coll = new AprEmbarazoCollection();
            Query qry = new Query(AprEmbarazo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEmbarazoCollection FetchByID(object IdEmbarazo)
        {
            AprEmbarazoCollection coll = new AprEmbarazoCollection().Where("idEmbarazo", IdEmbarazo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AprEmbarazoCollection FetchByQuery(Query qry)
        {
            AprEmbarazoCollection coll = new AprEmbarazoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEmbarazo)
        {
            return (AprEmbarazo.Delete(IdEmbarazo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEmbarazo)
        {
            return (AprEmbarazo.Destroy(IdEmbarazo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEfector,int IdPaciente,bool? Planeado,int? IdFracasoMetodoAnticonceptivo,DateTime Fum,DateTime Fpp,double? PesoAnterior,double? Talla)
	    {
		    AprEmbarazo item = new AprEmbarazo();
		    
            item.IdEfector = IdEfector;
            
            item.IdPaciente = IdPaciente;
            
            item.Planeado = Planeado;
            
            item.IdFracasoMetodoAnticonceptivo = IdFracasoMetodoAnticonceptivo;
            
            item.Fum = Fum;
            
            item.Fpp = Fpp;
            
            item.PesoAnterior = PesoAnterior;
            
            item.Talla = Talla;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEmbarazo,int IdEfector,int IdPaciente,bool? Planeado,int? IdFracasoMetodoAnticonceptivo,DateTime Fum,DateTime Fpp,double? PesoAnterior,double? Talla)
	    {
		    AprEmbarazo item = new AprEmbarazo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEmbarazo = IdEmbarazo;
				
			item.IdEfector = IdEfector;
				
			item.IdPaciente = IdPaciente;
				
			item.Planeado = Planeado;
				
			item.IdFracasoMetodoAnticonceptivo = IdFracasoMetodoAnticonceptivo;
				
			item.Fum = Fum;
				
			item.Fpp = Fpp;
				
			item.PesoAnterior = PesoAnterior;
				
			item.Talla = Talla;
				
	        item.Save(UserName);
	    }
    }
}
