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
    /// Controller class for EMR_RelTraumaPrehospitalaria
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class EmrRelTraumaPrehospitalariumController
    {
        // Preload our schema..
        EmrRelTraumaPrehospitalarium thisSchemaLoad = new EmrRelTraumaPrehospitalarium();
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
        public EmrRelTraumaPrehospitalariumCollection FetchAll()
        {
            EmrRelTraumaPrehospitalariumCollection coll = new EmrRelTraumaPrehospitalariumCollection();
            Query qry = new Query(EmrRelTraumaPrehospitalarium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmrRelTraumaPrehospitalariumCollection FetchByID(object IdRelTraumaPrehospitalaria)
        {
            EmrRelTraumaPrehospitalariumCollection coll = new EmrRelTraumaPrehospitalariumCollection().Where("idRelTraumaPrehospitalaria", IdRelTraumaPrehospitalaria).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmrRelTraumaPrehospitalariumCollection FetchByQuery(Query qry)
        {
            EmrRelTraumaPrehospitalariumCollection coll = new EmrRelTraumaPrehospitalariumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelTraumaPrehospitalaria)
        {
            return (EmrRelTraumaPrehospitalarium.Delete(IdRelTraumaPrehospitalaria) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelTraumaPrehospitalaria)
        {
            return (EmrRelTraumaPrehospitalarium.Destroy(IdRelTraumaPrehospitalaria) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdTrauma,int? IdPaciente,int? IdHCPrehospitalaria)
	    {
		    EmrRelTraumaPrehospitalarium item = new EmrRelTraumaPrehospitalarium();
		    
            item.IdTrauma = IdTrauma;
            
            item.IdPaciente = IdPaciente;
            
            item.IdHCPrehospitalaria = IdHCPrehospitalaria;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdRelTraumaPrehospitalaria,int? IdTrauma,int? IdPaciente,int? IdHCPrehospitalaria)
	    {
		    EmrRelTraumaPrehospitalarium item = new EmrRelTraumaPrehospitalarium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelTraumaPrehospitalaria = IdRelTraumaPrehospitalaria;
				
			item.IdTrauma = IdTrauma;
				
			item.IdPaciente = IdPaciente;
				
			item.IdHCPrehospitalaria = IdHCPrehospitalaria;
				
	        item.Save(UserName);
	    }
    }
}
