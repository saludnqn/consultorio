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
    /// Controller class for Rem_TablaExamen
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RemTablaExamanController
    {
        // Preload our schema..
        RemTablaExaman thisSchemaLoad = new RemTablaExaman();
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
        public RemTablaExamanCollection FetchAll()
        {
            RemTablaExamanCollection coll = new RemTablaExamanCollection();
            Query qry = new Query(RemTablaExaman.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemTablaExamanCollection FetchByID(object IdTablaExamen)
        {
            RemTablaExamanCollection coll = new RemTablaExamanCollection().Where("idTablaExamen", IdTablaExamen).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RemTablaExamanCollection FetchByQuery(Query qry)
        {
            RemTablaExamanCollection coll = new RemTablaExamanCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdTablaExamen)
        {
            return (RemTablaExaman.Delete(IdTablaExamen) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdTablaExamen)
        {
            return (RemTablaExaman.Destroy(IdTablaExamen) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdExamenPies,bool? II1,bool? II2,bool? II3,bool? II4,bool? II5,bool? II6,bool? II7,bool? II8,bool? II9,bool? DD1,bool? DD2,bool? DD3,bool? DD4,bool? DD5,bool? DD6,bool? DD7,bool? DD8,bool? DD9)
	    {
		    RemTablaExaman item = new RemTablaExaman();
		    
            item.IdExamenPies = IdExamenPies;
            
            item.II1 = II1;
            
            item.II2 = II2;
            
            item.II3 = II3;
            
            item.II4 = II4;
            
            item.II5 = II5;
            
            item.II6 = II6;
            
            item.II7 = II7;
            
            item.II8 = II8;
            
            item.II9 = II9;
            
            item.DD1 = DD1;
            
            item.DD2 = DD2;
            
            item.DD3 = DD3;
            
            item.DD4 = DD4;
            
            item.DD5 = DD5;
            
            item.DD6 = DD6;
            
            item.DD7 = DD7;
            
            item.DD8 = DD8;
            
            item.DD9 = DD9;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdTablaExamen,int? IdExamenPies,bool? II1,bool? II2,bool? II3,bool? II4,bool? II5,bool? II6,bool? II7,bool? II8,bool? II9,bool? DD1,bool? DD2,bool? DD3,bool? DD4,bool? DD5,bool? DD6,bool? DD7,bool? DD8,bool? DD9)
	    {
		    RemTablaExaman item = new RemTablaExaman();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdTablaExamen = IdTablaExamen;
				
			item.IdExamenPies = IdExamenPies;
				
			item.II1 = II1;
				
			item.II2 = II2;
				
			item.II3 = II3;
				
			item.II4 = II4;
				
			item.II5 = II5;
				
			item.II6 = II6;
				
			item.II7 = II7;
				
			item.II8 = II8;
				
			item.II9 = II9;
				
			item.DD1 = DD1;
				
			item.DD2 = DD2;
				
			item.DD3 = DD3;
				
			item.DD4 = DD4;
				
			item.DD5 = DD5;
				
			item.DD6 = DD6;
				
			item.DD7 = DD7;
				
			item.DD8 = DD8;
				
			item.DD9 = DD9;
				
	        item.Save(UserName);
	    }
    }
}
