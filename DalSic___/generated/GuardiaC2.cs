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
	/// Strongly-typed collection for the GuardiaC2 class.
	/// </summary>
    [Serializable]
	public partial class GuardiaC2Collection : ActiveList<GuardiaC2, GuardiaC2Collection>
	{	   
		public GuardiaC2Collection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaC2Collection</returns>
		public GuardiaC2Collection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaC2 o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_C2 table.
	/// </summary>
	[Serializable]
	public partial class GuardiaC2 : ActiveRecord<GuardiaC2>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaC2()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaC2(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaC2(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaC2(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_C2", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdRegistroGuardia = new TableSchema.TableColumn(schema);
				colvarIdRegistroGuardia.ColumnName = "idRegistroGuardia";
				colvarIdRegistroGuardia.DataType = DbType.Int32;
				colvarIdRegistroGuardia.MaxLength = 0;
				colvarIdRegistroGuardia.AutoIncrement = false;
				colvarIdRegistroGuardia.IsNullable = false;
				colvarIdRegistroGuardia.IsPrimaryKey = false;
				colvarIdRegistroGuardia.IsForeignKey = false;
				colvarIdRegistroGuardia.IsReadOnly = false;
				colvarIdRegistroGuardia.DefaultSetting = @"";
				colvarIdRegistroGuardia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRegistroGuardia);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdC2 = new TableSchema.TableColumn(schema);
				colvarIdC2.ColumnName = "idC2";
				colvarIdC2.DataType = DbType.Int32;
				colvarIdC2.MaxLength = 0;
				colvarIdC2.AutoIncrement = false;
				colvarIdC2.IsNullable = false;
				colvarIdC2.IsPrimaryKey = false;
				colvarIdC2.IsForeignKey = false;
				colvarIdC2.IsReadOnly = false;
				colvarIdC2.DefaultSetting = @"";
				colvarIdC2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdC2);
				
				TableSchema.TableColumn colvarSospecha = new TableSchema.TableColumn(schema);
				colvarSospecha.ColumnName = "sospecha";
				colvarSospecha.DataType = DbType.Boolean;
				colvarSospecha.MaxLength = 0;
				colvarSospecha.AutoIncrement = false;
				colvarSospecha.IsNullable = false;
				colvarSospecha.IsPrimaryKey = false;
				colvarSospecha.IsForeignKey = false;
				colvarSospecha.IsReadOnly = false;
				colvarSospecha.DefaultSetting = @"";
				colvarSospecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSospecha);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarAuditUser = new TableSchema.TableColumn(schema);
				colvarAuditUser.ColumnName = "auditUser";
				colvarAuditUser.DataType = DbType.Int32;
				colvarAuditUser.MaxLength = 0;
				colvarAuditUser.AutoIncrement = false;
				colvarAuditUser.IsNullable = false;
				colvarAuditUser.IsPrimaryKey = false;
				colvarAuditUser.IsForeignKey = false;
				colvarAuditUser.IsReadOnly = false;
				colvarAuditUser.DefaultSetting = @"";
				colvarAuditUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditUser);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_C2",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdRegistroGuardia")]
		[Bindable(true)]
		public int IdRegistroGuardia 
		{
			get { return GetColumnValue<int>(Columns.IdRegistroGuardia); }
			set { SetColumnValue(Columns.IdRegistroGuardia, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdC2")]
		[Bindable(true)]
		public int IdC2 
		{
			get { return GetColumnValue<int>(Columns.IdC2); }
			set { SetColumnValue(Columns.IdC2, value); }
		}
		  
		[XmlAttribute("Sospecha")]
		[Bindable(true)]
		public bool Sospecha 
		{
			get { return GetColumnValue<bool>(Columns.Sospecha); }
			set { SetColumnValue(Columns.Sospecha, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("AuditUser")]
		[Bindable(true)]
		public int AuditUser 
		{
			get { return GetColumnValue<int>(Columns.AuditUser); }
			set { SetColumnValue(Columns.AuditUser, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdRegistroGuardia,int? varIdEfector,int varIdC2,bool varSospecha,DateTime? varFecha,int varAuditUser)
		{
			GuardiaC2 item = new GuardiaC2();
			
			item.IdRegistroGuardia = varIdRegistroGuardia;
			
			item.IdEfector = varIdEfector;
			
			item.IdC2 = varIdC2;
			
			item.Sospecha = varSospecha;
			
			item.Fecha = varFecha;
			
			item.AuditUser = varAuditUser;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varIdRegistroGuardia,int? varIdEfector,int varIdC2,bool varSospecha,DateTime? varFecha,int varAuditUser)
		{
			GuardiaC2 item = new GuardiaC2();
			
				item.Id = varId;
			
				item.IdRegistroGuardia = varIdRegistroGuardia;
			
				item.IdEfector = varIdEfector;
			
				item.IdC2 = varIdC2;
			
				item.Sospecha = varSospecha;
			
				item.Fecha = varFecha;
			
				item.AuditUser = varAuditUser;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdRegistroGuardiaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdC2Column
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SospechaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditUserColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdRegistroGuardia = @"idRegistroGuardia";
			 public static string IdEfector = @"idEfector";
			 public static string IdC2 = @"idC2";
			 public static string Sospecha = @"sospecha";
			 public static string Fecha = @"fecha";
			 public static string AuditUser = @"auditUser";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
