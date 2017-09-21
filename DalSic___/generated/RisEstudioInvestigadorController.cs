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
    /// Controller class for RIS_EstudioInvestigador
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RisEstudioInvestigadorController
    {
        // Preload our schema..
        RisEstudioInvestigador thisSchemaLoad = new RisEstudioInvestigador();
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
        public RisEstudioInvestigadorCollection FetchAll()
        {
            RisEstudioInvestigadorCollection coll = new RisEstudioInvestigadorCollection();
            Query qry = new Query(RisEstudioInvestigador.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioInvestigadorCollection FetchByID(object IdEstudioInvestigador)
        {
            RisEstudioInvestigadorCollection coll = new RisEstudioInvestigadorCollection().Where("idEstudioInvestigador", IdEstudioInvestigador).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RisEstudioInvestigadorCollection FetchByQuery(Query qry)
        {
            RisEstudioInvestigadorCollection coll = new RisEstudioInvestigadorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstudioInvestigador)
        {
            return (RisEstudioInvestigador.Delete(IdEstudioInvestigador) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstudioInvestigador)
        {
            return (RisEstudioInvestigador.Destroy(IdEstudioInvestigador) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdEstudio,int IdInvestigador,int? IdFuncionEnElEquipo)
	    {
		    RisEstudioInvestigador item = new RisEstudioInvestigador();
		    
            item.IdEstudio = IdEstudio;
            
            item.IdInvestigador = IdInvestigador;
            
            item.IdFuncionEnElEquipo = IdFuncionEnElEquipo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstudioInvestigador,int IdEstudio,int IdInvestigador,int? IdFuncionEnElEquipo)
	    {
		    RisEstudioInvestigador item = new RisEstudioInvestigador();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstudioInvestigador = IdEstudioInvestigador;
				
			item.IdEstudio = IdEstudio;
				
			item.IdInvestigador = IdInvestigador;
				
			item.IdFuncionEnElEquipo = IdFuncionEnElEquipo;
				
	        item.Save(UserName);
	    }
    }
}
