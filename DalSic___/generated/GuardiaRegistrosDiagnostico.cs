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
	/// Strongly-typed collection for the GuardiaRegistrosDiagnostico class.
	/// </summary>
    [Serializable]
	public partial class GuardiaRegistrosDiagnosticoCollection : ActiveList<GuardiaRegistrosDiagnostico, GuardiaRegistrosDiagnosticoCollection>
	{	   
		public GuardiaRegistrosDiagnosticoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaRegistrosDiagnosticoCollection</returns>
		public GuardiaRegistrosDiagnosticoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaRegistrosDiagnostico o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Registros_Diagnosticos table.
	/// </summary>
	[Serializable]
	public partial class GuardiaRegistrosDiagnostico : ActiveRecord<GuardiaRegistrosDiagnostico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaRegistrosDiagnostico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaRegistrosDiagnostico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaRegistrosDiagnostico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaRegistrosDiagnostico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Registros_Diagnosticos", TableType.Table, DataService.GetInstance("sicProvider"));
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
				colvarIdRegistroGuardia.IsNullable = true;
				colvarIdRegistroGuardia.IsPrimaryKey = false;
				colvarIdRegistroGuardia.IsForeignKey = true;
				colvarIdRegistroGuardia.IsReadOnly = false;
				colvarIdRegistroGuardia.DefaultSetting = @"";
				
					colvarIdRegistroGuardia.ForeignKeyTableName = "Guardia_Registros";
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
				
				TableSchema.TableColumn colvarAuditUser = new TableSchema.TableColumn(schema);
				colvarAuditUser.ColumnName = "audit_user";
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
				
				TableSchema.TableColumn colvarTipoAnotacion = new TableSchema.TableColumn(schema);
				colvarTipoAnotacion.ColumnName = "tipoAnotacion";
				colvarTipoAnotacion.DataType = DbType.Int32;
				colvarTipoAnotacion.MaxLength = 0;
				colvarTipoAnotacion.AutoIncrement = false;
				colvarTipoAnotacion.IsNullable = false;
				colvarTipoAnotacion.IsPrimaryKey = false;
				colvarTipoAnotacion.IsForeignKey = false;
				colvarTipoAnotacion.IsReadOnly = false;
				colvarTipoAnotacion.DefaultSetting = @"";
				colvarTipoAnotacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoAnotacion);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "Observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = -1;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = true;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				colvarObservacion.DefaultSetting = @"";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Registros_Diagnosticos",schema);
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
		public int? IdRegistroGuardia 
		{
			get { return GetColumnValue<int?>(Columns.IdRegistroGuardia); }
			set { SetColumnValue(Columns.IdRegistroGuardia, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("AuditUser")]
		[Bindable(true)]
		public int AuditUser 
		{
			get { return GetColumnValue<int>(Columns.AuditUser); }
			set { SetColumnValue(Columns.AuditUser, value); }
		}
		  
		[XmlAttribute("TipoAnotacion")]
		[Bindable(true)]
		public int TipoAnotacion 
		{
			get { return GetColumnValue<int>(Columns.TipoAnotacion); }
			set { SetColumnValue(Columns.TipoAnotacion, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a GuardiaRegistro ActiveRecord object related to this GuardiaRegistrosDiagnostico
		/// 
		/// </summary>
		public DalSic.GuardiaRegistro GuardiaRegistro
		{
			get { return DalSic.GuardiaRegistro.FetchByID(this.IdRegistroGuardia); }
			set { SetColumnValue("idRegistroGuardia", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdRegistroGuardia,int? varIdEfector,int varAuditUser,int varTipoAnotacion,string varObservacion,DateTime? varFecha)
		{
			GuardiaRegistrosDiagnostico item = new GuardiaRegistrosDiagnostico();
			
			item.IdRegistroGuardia = varIdRegistroGuardia;
			
			item.IdEfector = varIdEfector;
			
			item.AuditUser = varAuditUser;
			
			item.TipoAnotacion = varTipoAnotacion;
			
			item.Observacion = varObservacion;
			
			item.Fecha = varFecha;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdRegistroGuardia,int? varIdEfector,int varAuditUser,int varTipoAnotacion,string varObservacion,DateTime? varFecha)
		{
			GuardiaRegistrosDiagnostico item = new GuardiaRegistrosDiagnostico();
			
				item.Id = varId;
			
				item.IdRegistroGuardia = varIdRegistroGuardia;
			
				item.IdEfector = varIdEfector;
			
				item.AuditUser = varAuditUser;
			
				item.TipoAnotacion = varTipoAnotacion;
			
				item.Observacion = varObservacion;
			
				item.Fecha = varFecha;
			
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
        
        
        
        public static TableSchema.TableColumn AuditUserColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoAnotacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
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
			 public static string AuditUser = @"audit_user";
			 public static string TipoAnotacion = @"tipoAnotacion";
			 public static string Observacion = @"Observacion";
			 public static string Fecha = @"fecha";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
