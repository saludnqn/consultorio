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
    /// Controller class for RIS_EvaluacionRechazada
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEvaluacionRechazadaController
    {
        // Preload our schema..
        RisEvaluacionRechazada thisSchemaLoad = new RisEvaluacionRechazada();
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
        public RisEvaluacionRechazadaCollection FetchAll()
        {
            RisEvaluacionRechazadaCollection coll = new RisEvaluacionRechazadaCollection();
            Query qry = new Query(RisEvaluacionRechazada.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEvaluacionRechazadaCollection FetchByID(object IdEvaluacionRechazada)
        {
            RisEvaluacionRechazadaCollection coll = new RisEvaluacionRechazadaCollection().Where("idEvaluacionRechazada", IdEvaluacionRechazada).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEvaluacionRechazadaCollection FetchByQuery(Query qry)
        {
            RisEvaluacionRechazadaCollection coll = new RisEvaluacionRechazadaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEvaluacionRechazada)
        {
            return (RisEvaluacionRechazada.Delete(IdEvaluacionRechazada) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEvaluacionRechazada)
        {
            return (RisEvaluacionRechazada.Destroy(IdEvaluacionRechazada) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEstudio,string NumeroRegistro,DateTime? Fecha,string InstitucionPertenece,string ResponsableComite,string Domicilio,string Telefono,string Mail)
	    {
		    RisEvaluacionRechazada item = new RisEvaluacionRechazada();
		    
            item.IdEstudio = IdEstudio;
            
            item.NumeroRegistro = NumeroRegistro;
            
            item.Fecha = Fecha;
            
            item.InstitucionPertenece = InstitucionPertenece;
            
            item.ResponsableComite = ResponsableComite;
            
            item.Domicilio = Domicilio;
            
            item.Telefono = Telefono;
            
            item.Mail = Mail;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEvaluacionRechazada,int? IdEstudio,string NumeroRegistro,DateTime? Fecha,string InstitucionPertenece,string ResponsableComite,string Domicilio,string Telefono,string Mail)
	    {
		    RisEvaluacionRechazada item = new RisEvaluacionRechazada();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEvaluacionRechazada = IdEvaluacionRechazada;
				
			item.IdEstudio = IdEstudio;
				
			item.NumeroRegistro = NumeroRegistro;
				
			item.Fecha = Fecha;
				
			item.InstitucionPertenece = InstitucionPertenece;
				
			item.ResponsableComite = ResponsableComite;
				
			item.Domicilio = Domicilio;
				
			item.Telefono = Telefono;
				
			item.Mail = Mail;
				
	        item.Save(UserName);
	    }
    }
}
