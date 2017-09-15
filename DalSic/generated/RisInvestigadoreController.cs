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
    /// Controller class for RIS_Investigadores
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisInvestigadoreController
    {
        // Preload our schema..
        RisInvestigadore thisSchemaLoad = new RisInvestigadore();
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
        public RisInvestigadoreCollection FetchAll()
        {
            RisInvestigadoreCollection coll = new RisInvestigadoreCollection();
            Query qry = new Query(RisInvestigadore.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisInvestigadoreCollection FetchByID(object IdInvestigador)
        {
            RisInvestigadoreCollection coll = new RisInvestigadoreCollection().Where("idInvestigador", IdInvestigador).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisInvestigadoreCollection FetchByQuery(Query qry)
        {
            RisInvestigadoreCollection coll = new RisInvestigadoreCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdInvestigador)
        {
            return (RisInvestigadore.Delete(IdInvestigador) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdInvestigador)
        {
            return (RisInvestigadore.Destroy(IdInvestigador) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Apellido,string Nombre,string Sexo,DateTime FechaNacimiento,int IdTipoDocumento,string NumeroDocumento,int IdProfesion,string NumeroMatricula,string DomicilioLaboral,string CpDomicilioLaboral,string DomicilioParticular,string CpDomicilioParticular,int IdTipoTelLaboral,string TelefonoLaboral,int? IdTipoTelParticular,string TelefonoParticular,string EmailLaboral,string EmailParticular,int? IdEntidad)
	    {
		    RisInvestigadore item = new RisInvestigadore();
		    
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.Sexo = Sexo;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.IdTipoDocumento = IdTipoDocumento;
            
            item.NumeroDocumento = NumeroDocumento;
            
            item.IdProfesion = IdProfesion;
            
            item.NumeroMatricula = NumeroMatricula;
            
            item.DomicilioLaboral = DomicilioLaboral;
            
            item.CpDomicilioLaboral = CpDomicilioLaboral;
            
            item.DomicilioParticular = DomicilioParticular;
            
            item.CpDomicilioParticular = CpDomicilioParticular;
            
            item.IdTipoTelLaboral = IdTipoTelLaboral;
            
            item.TelefonoLaboral = TelefonoLaboral;
            
            item.IdTipoTelParticular = IdTipoTelParticular;
            
            item.TelefonoParticular = TelefonoParticular;
            
            item.EmailLaboral = EmailLaboral;
            
            item.EmailParticular = EmailParticular;
            
            item.IdEntidad = IdEntidad;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdInvestigador,string Apellido,string Nombre,string Sexo,DateTime FechaNacimiento,int IdTipoDocumento,string NumeroDocumento,int IdProfesion,string NumeroMatricula,string DomicilioLaboral,string CpDomicilioLaboral,string DomicilioParticular,string CpDomicilioParticular,int IdTipoTelLaboral,string TelefonoLaboral,int? IdTipoTelParticular,string TelefonoParticular,string EmailLaboral,string EmailParticular,int? IdEntidad)
	    {
		    RisInvestigadore item = new RisInvestigadore();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdInvestigador = IdInvestigador;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.Sexo = Sexo;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.IdTipoDocumento = IdTipoDocumento;
				
			item.NumeroDocumento = NumeroDocumento;
				
			item.IdProfesion = IdProfesion;
				
			item.NumeroMatricula = NumeroMatricula;
				
			item.DomicilioLaboral = DomicilioLaboral;
				
			item.CpDomicilioLaboral = CpDomicilioLaboral;
				
			item.DomicilioParticular = DomicilioParticular;
				
			item.CpDomicilioParticular = CpDomicilioParticular;
				
			item.IdTipoTelLaboral = IdTipoTelLaboral;
				
			item.TelefonoLaboral = TelefonoLaboral;
				
			item.IdTipoTelParticular = IdTipoTelParticular;
				
			item.TelefonoParticular = TelefonoParticular;
				
			item.EmailLaboral = EmailLaboral;
				
			item.EmailParticular = EmailParticular;
				
			item.IdEntidad = IdEntidad;
				
	        item.Save(UserName);
	    }
    }
}
