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
    /// Controller class for PN_horarios_trabajo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnHorariosTrabajoController
    {
        // Preload our schema..
        PnHorariosTrabajo thisSchemaLoad = new PnHorariosTrabajo();
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
        public PnHorariosTrabajoCollection FetchAll()
        {
            PnHorariosTrabajoCollection coll = new PnHorariosTrabajoCollection();
            Query qry = new Query(PnHorariosTrabajo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnHorariosTrabajoCollection FetchByID(object IdHorarioTrabajo)
        {
            PnHorariosTrabajoCollection coll = new PnHorariosTrabajoCollection().Where("id_horario_trabajo", IdHorarioTrabajo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnHorariosTrabajoCollection FetchByQuery(Query qry)
        {
            PnHorariosTrabajoCollection coll = new PnHorariosTrabajoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdHorarioTrabajo)
        {
            return (PnHorariosTrabajo.Delete(IdHorarioTrabajo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdHorarioTrabajo)
        {
            return (PnHorariosTrabajo.Destroy(IdHorarioTrabajo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdDia,int IdUsuario,short? TrabajaSabado,short? TrabajaDomingo,string InicioHorario,string FinHorario)
	    {
		    PnHorariosTrabajo item = new PnHorariosTrabajo();
		    
            item.IdDia = IdDia;
            
            item.IdUsuario = IdUsuario;
            
            item.TrabajaSabado = TrabajaSabado;
            
            item.TrabajaDomingo = TrabajaDomingo;
            
            item.InicioHorario = InicioHorario;
            
            item.FinHorario = FinHorario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdHorarioTrabajo,int IdDia,int IdUsuario,short? TrabajaSabado,short? TrabajaDomingo,string InicioHorario,string FinHorario)
	    {
		    PnHorariosTrabajo item = new PnHorariosTrabajo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdHorarioTrabajo = IdHorarioTrabajo;
				
			item.IdDia = IdDia;
				
			item.IdUsuario = IdUsuario;
				
			item.TrabajaSabado = TrabajaSabado;
				
			item.TrabajaDomingo = TrabajaDomingo;
				
			item.InicioHorario = InicioHorario;
				
			item.FinHorario = FinHorario;
				
	        item.Save(UserName);
	    }
    }
}
