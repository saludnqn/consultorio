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
    /// Controller class for PN_pac_pap
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnPacPapController
    {
        // Preload our schema..
        PnPacPap thisSchemaLoad = new PnPacPap();
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
        public PnPacPapCollection FetchAll()
        {
            PnPacPapCollection coll = new PnPacPapCollection();
            Query qry = new Query(PnPacPap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPacPapCollection FetchByID(object IdPacPap)
        {
            PnPacPapCollection coll = new PnPacPapCollection().Where("id_pac_pap", IdPacPap).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnPacPapCollection FetchByQuery(Query qry)
        {
            PnPacPapCollection coll = new PnPacPapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPacPap)
        {
            return (PnPacPap.Delete(IdPacPap) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPacPap)
        {
            return (PnPacPap.Destroy(IdPacPap) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdNoConformidad,string Descripcion,string AccionCorrectiva,string EvaluacionEficacia,short? Tipo,DateTime? Fecha,string Area,DateTime? FechaCierre,string AccionInmediata,string CausaNc,short? Verificacion,DateTime? FechaVerificacion)
	    {
		    PnPacPap item = new PnPacPap();
		    
            item.IdNoConformidad = IdNoConformidad;
            
            item.Descripcion = Descripcion;
            
            item.AccionCorrectiva = AccionCorrectiva;
            
            item.EvaluacionEficacia = EvaluacionEficacia;
            
            item.Tipo = Tipo;
            
            item.Fecha = Fecha;
            
            item.Area = Area;
            
            item.FechaCierre = FechaCierre;
            
            item.AccionInmediata = AccionInmediata;
            
            item.CausaNc = CausaNc;
            
            item.Verificacion = Verificacion;
            
            item.FechaVerificacion = FechaVerificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPacPap,int IdNoConformidad,string Descripcion,string AccionCorrectiva,string EvaluacionEficacia,short? Tipo,DateTime? Fecha,string Area,DateTime? FechaCierre,string AccionInmediata,string CausaNc,short? Verificacion,DateTime? FechaVerificacion)
	    {
		    PnPacPap item = new PnPacPap();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPacPap = IdPacPap;
				
			item.IdNoConformidad = IdNoConformidad;
				
			item.Descripcion = Descripcion;
				
			item.AccionCorrectiva = AccionCorrectiva;
				
			item.EvaluacionEficacia = EvaluacionEficacia;
				
			item.Tipo = Tipo;
				
			item.Fecha = Fecha;
				
			item.Area = Area;
				
			item.FechaCierre = FechaCierre;
				
			item.AccionInmediata = AccionInmediata;
				
			item.CausaNc = CausaNc;
				
			item.Verificacion = Verificacion;
				
			item.FechaVerificacion = FechaVerificacion;
				
	        item.Save(UserName);
	    }
    }
}
