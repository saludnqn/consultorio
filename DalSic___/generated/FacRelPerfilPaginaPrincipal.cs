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
	/// Strongly-typed collection for the FacRelPerfilPaginaPrincipal class.
	/// </summary>
    [Serializable]
	public partial class FacRelPerfilPaginaPrincipalCollection : ActiveList<FacRelPerfilPaginaPrincipal, FacRelPerfilPaginaPrincipalCollection>
	{	   
		public FacRelPerfilPaginaPrincipalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>FacRelPerfilPaginaPrincipalCollection</returns>
		public FacRelPerfilPaginaPrincipalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                FacRelPerfilPaginaPrincipal o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the FAC_RelPerfilPaginaPrincipal table.
	/// </summary>
	[Serializable]
	public partial class FacRelPerfilPaginaPrincipal : ActiveRecord<FacRelPerfilPaginaPrincipal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public FacRelPerfilPaginaPrincipal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public FacRelPerfilPaginaPrincipal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public FacRelPerfilPaginaPrincipal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public FacRelPerfilPaginaPrincipal(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("FAC_RelPerfilPaginaPrincipal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelPerfilPaginaPrincipal = new TableSchema.TableColumn(schema);
				colvarIdRelPerfilPaginaPrincipal.ColumnName = "idRelPerfilPaginaPrincipal";
				colvarIdRelPerfilPaginaPrincipal.DataType = DbType.Int32;
				colvarIdRelPerfilPaginaPrincipal.MaxLength = 0;
				colvarIdRelPerfilPaginaPrincipal.AutoIncrement = true;
				colvarIdRelPerfilPaginaPrincipal.IsNullable = false;
				colvarIdRelPerfilPaginaPrincipal.IsPrimaryKey = true;
				colvarIdRelPerfilPaginaPrincipal.IsForeignKey = false;
				colvarIdRelPerfilPaginaPrincipal.IsReadOnly = false;
				colvarIdRelPerfilPaginaPrincipal.DefaultSetting = @"";
				colvarIdRelPerfilPaginaPrincipal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelPerfilPaginaPrincipal);
				
				TableSchema.TableColumn colvarIdPerfil = new TableSchema.TableColumn(schema);
				colvarIdPerfil.ColumnName = "idPerfil";
				colvarIdPerfil.DataType = DbType.Int32;
				colvarIdPerfil.MaxLength = 0;
				colvarIdPerfil.AutoIncrement = false;
				colvarIdPerfil.IsNullable = false;
				colvarIdPerfil.IsPrimaryKey = false;
				colvarIdPerfil.IsForeignKey = false;
				colvarIdPerfil.IsReadOnly = false;
				colvarIdPerfil.DefaultSetting = @"";
				colvarIdPerfil.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPerfil);
				
				TableSchema.TableColumn colvarIdMenu = new TableSchema.TableColumn(schema);
				colvarIdMenu.ColumnName = "idMenu";
				colvarIdMenu.DataType = DbType.Int32;
				colvarIdMenu.MaxLength = 0;
				colvarIdMenu.AutoIncrement = false;
				colvarIdMenu.IsNullable = false;
				colvarIdMenu.IsPrimaryKey = false;
				colvarIdMenu.IsForeignKey = false;
				colvarIdMenu.IsReadOnly = false;
				colvarIdMenu.DefaultSetting = @"";
				colvarIdMenu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMenu);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "url";
				colvarUrl.DataType = DbType.AnsiString;
				colvarUrl.MaxLength = 500;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = false;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("FAC_RelPerfilPaginaPrincipal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelPerfilPaginaPrincipal")]
		[Bindable(true)]
		public int IdRelPerfilPaginaPrincipal 
		{
			get { return GetColumnValue<int>(Columns.IdRelPerfilPaginaPrincipal); }
			set { SetColumnValue(Columns.IdRelPerfilPaginaPrincipal, value); }
		}
		  
		[XmlAttribute("IdPerfil")]
		[Bindable(true)]
		public int IdPerfil 
		{
			get { return GetColumnValue<int>(Columns.IdPerfil); }
			set { SetColumnValue(Columns.IdPerfil, value); }
		}
		  
		[XmlAttribute("IdMenu")]
		[Bindable(true)]
		public int IdMenu 
		{
			get { return GetColumnValue<int>(Columns.IdMenu); }
			set { SetColumnValue(Columns.IdMenu, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPerfil,int varIdMenu,string varUrl)
		{
			FacRelPerfilPaginaPrincipal item = new FacRelPerfilPaginaPrincipal();
			
			item.IdPerfil = varIdPerfil;
			
			item.IdMenu = varIdMenu;
			
			item.Url = varUrl;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelPerfilPaginaPrincipal,int varIdPerfil,int varIdMenu,string varUrl)
		{
			FacRelPerfilPaginaPrincipal item = new FacRelPerfilPaginaPrincipal();
			
				item.IdRelPerfilPaginaPrincipal = varIdRelPerfilPaginaPrincipal;
			
				item.IdPerfil = varIdPerfil;
			
				item.IdMenu = varIdMenu;
			
				item.Url = varUrl;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelPerfilPaginaPrincipalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPerfilColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMenuColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelPerfilPaginaPrincipal = @"idRelPerfilPaginaPrincipal";
			 public static string IdPerfil = @"idPerfil";
			 public static string IdMenu = @"idMenu";
			 public static string Url = @"url";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
