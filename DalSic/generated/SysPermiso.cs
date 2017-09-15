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
	/// Strongly-typed collection for the SysPermiso class.
	/// </summary>
    [Serializable]
	public partial class SysPermisoCollection : ActiveList<SysPermiso, SysPermisoCollection>
	{	   
		public SysPermisoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysPermisoCollection</returns>
		public SysPermisoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysPermiso o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Permiso table.
	/// </summary>
	[Serializable]
	public partial class SysPermiso : ActiveRecord<SysPermiso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysPermiso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysPermiso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysPermiso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysPermiso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Permiso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPermiso = new TableSchema.TableColumn(schema);
				colvarIdPermiso.ColumnName = "idPermiso";
				colvarIdPermiso.DataType = DbType.Int32;
				colvarIdPermiso.MaxLength = 0;
				colvarIdPermiso.AutoIncrement = true;
				colvarIdPermiso.IsNullable = false;
				colvarIdPermiso.IsPrimaryKey = true;
				colvarIdPermiso.IsForeignKey = false;
				colvarIdPermiso.IsReadOnly = false;
				colvarIdPermiso.DefaultSetting = @"";
				colvarIdPermiso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPermiso);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				
						colvarIdEfector.DefaultSetting = @"((0))";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdPerfil = new TableSchema.TableColumn(schema);
				colvarIdPerfil.ColumnName = "idPerfil";
				colvarIdPerfil.DataType = DbType.Int32;
				colvarIdPerfil.MaxLength = 0;
				colvarIdPerfil.AutoIncrement = false;
				colvarIdPerfil.IsNullable = false;
				colvarIdPerfil.IsPrimaryKey = false;
				colvarIdPerfil.IsForeignKey = true;
				colvarIdPerfil.IsReadOnly = false;
				
						colvarIdPerfil.DefaultSetting = @"((0))";
				
					colvarIdPerfil.ForeignKeyTableName = "Sys_Perfil";
				schema.Columns.Add(colvarIdPerfil);
				
				TableSchema.TableColumn colvarIdMenu = new TableSchema.TableColumn(schema);
				colvarIdMenu.ColumnName = "idMenu";
				colvarIdMenu.DataType = DbType.Int32;
				colvarIdMenu.MaxLength = 0;
				colvarIdMenu.AutoIncrement = false;
				colvarIdMenu.IsNullable = false;
				colvarIdMenu.IsPrimaryKey = false;
				colvarIdMenu.IsForeignKey = true;
				colvarIdMenu.IsReadOnly = false;
				
						colvarIdMenu.DefaultSetting = @"((0))";
				
					colvarIdMenu.ForeignKeyTableName = "Sys_Menu";
				schema.Columns.Add(colvarIdMenu);
				
				TableSchema.TableColumn colvarPermiso = new TableSchema.TableColumn(schema);
				colvarPermiso.ColumnName = "permiso";
				colvarPermiso.DataType = DbType.String;
				colvarPermiso.MaxLength = 1;
				colvarPermiso.AutoIncrement = false;
				colvarPermiso.IsNullable = false;
				colvarPermiso.IsPrimaryKey = false;
				colvarPermiso.IsForeignKey = false;
				colvarPermiso.IsReadOnly = false;
				
						colvarPermiso.DefaultSetting = @"((0))";
				colvarPermiso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPermiso);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Permiso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPermiso")]
		[Bindable(true)]
		public int IdPermiso 
		{
			get { return GetColumnValue<int>(Columns.IdPermiso); }
			set { SetColumnValue(Columns.IdPermiso, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
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
		  
		[XmlAttribute("Permiso")]
		[Bindable(true)]
		public string Permiso 
		{
			get { return GetColumnValue<string>(Columns.Permiso); }
			set { SetColumnValue(Columns.Permiso, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysPerfil ActiveRecord object related to this SysPermiso
		/// 
		/// </summary>
		public DalSic.SysPerfil SysPerfil
		{
			get { return DalSic.SysPerfil.FetchByID(this.IdPerfil); }
			set { SetColumnValue("idPerfil", value.IdPerfil); }
		}
		
		
		/// <summary>
		/// Returns a SysMenu ActiveRecord object related to this SysPermiso
		/// 
		/// </summary>
		public DalSic.SysMenu SysMenu
		{
			get { return DalSic.SysMenu.FetchByID(this.IdMenu); }
			set { SetColumnValue("idMenu", value.IdMenu); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPerfil,int varIdMenu,string varPermiso)
		{
			SysPermiso item = new SysPermiso();
			
			item.IdEfector = varIdEfector;
			
			item.IdPerfil = varIdPerfil;
			
			item.IdMenu = varIdMenu;
			
			item.Permiso = varPermiso;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPermiso,int varIdEfector,int varIdPerfil,int varIdMenu,string varPermiso)
		{
			SysPermiso item = new SysPermiso();
			
				item.IdPermiso = varIdPermiso;
			
				item.IdEfector = varIdEfector;
			
				item.IdPerfil = varIdPerfil;
			
				item.IdMenu = varIdMenu;
			
				item.Permiso = varPermiso;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPermisoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPerfilColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMenuColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PermisoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPermiso = @"idPermiso";
			 public static string IdEfector = @"idEfector";
			 public static string IdPerfil = @"idPerfil";
			 public static string IdMenu = @"idMenu";
			 public static string Permiso = @"permiso";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
