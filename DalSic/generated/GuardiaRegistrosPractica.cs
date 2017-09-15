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
	/// Strongly-typed collection for the GuardiaRegistrosPractica class.
	/// </summary>
    [Serializable]
	public partial class GuardiaRegistrosPracticaCollection : ActiveList<GuardiaRegistrosPractica, GuardiaRegistrosPracticaCollection>
	{	   
		public GuardiaRegistrosPracticaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaRegistrosPracticaCollection</returns>
		public GuardiaRegistrosPracticaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaRegistrosPractica o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Registros_Practicas table.
	/// </summary>
	[Serializable]
	public partial class GuardiaRegistrosPractica : ActiveRecord<GuardiaRegistrosPractica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaRegistrosPractica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaRegistrosPractica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaRegistrosPractica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaRegistrosPractica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Registros_Practicas", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarIdTipoPractica = new TableSchema.TableColumn(schema);
				colvarIdTipoPractica.ColumnName = "idTipoPractica";
				colvarIdTipoPractica.DataType = DbType.Int32;
				colvarIdTipoPractica.MaxLength = 0;
				colvarIdTipoPractica.AutoIncrement = false;
				colvarIdTipoPractica.IsNullable = false;
				colvarIdTipoPractica.IsPrimaryKey = false;
				colvarIdTipoPractica.IsForeignKey = false;
				colvarIdTipoPractica.IsReadOnly = false;
				colvarIdTipoPractica.DefaultSetting = @"";
				colvarIdTipoPractica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoPractica);
				
				TableSchema.TableColumn colvarIdPrioridad = new TableSchema.TableColumn(schema);
				colvarIdPrioridad.ColumnName = "idPrioridad";
				colvarIdPrioridad.DataType = DbType.Int32;
				colvarIdPrioridad.MaxLength = 0;
				colvarIdPrioridad.AutoIncrement = false;
				colvarIdPrioridad.IsNullable = false;
				colvarIdPrioridad.IsPrimaryKey = false;
				colvarIdPrioridad.IsForeignKey = false;
				colvarIdPrioridad.IsReadOnly = false;
				colvarIdPrioridad.DefaultSetting = @"";
				colvarIdPrioridad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrioridad);
				
				TableSchema.TableColumn colvarIdEstado = new TableSchema.TableColumn(schema);
				colvarIdEstado.ColumnName = "idEstado";
				colvarIdEstado.DataType = DbType.Int32;
				colvarIdEstado.MaxLength = 0;
				colvarIdEstado.AutoIncrement = false;
				colvarIdEstado.IsNullable = false;
				colvarIdEstado.IsPrimaryKey = false;
				colvarIdEstado.IsForeignKey = false;
				colvarIdEstado.IsReadOnly = false;
				colvarIdEstado.DefaultSetting = @"";
				colvarIdEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstado);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "url";
				colvarUrl.DataType = DbType.AnsiString;
				colvarUrl.MaxLength = -1;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = true;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
				TableSchema.TableColumn colvarAuditUser = new TableSchema.TableColumn(schema);
				colvarAuditUser.ColumnName = "auditUser";
				colvarAuditUser.DataType = DbType.Int32;
				colvarAuditUser.MaxLength = 0;
				colvarAuditUser.AutoIncrement = false;
				colvarAuditUser.IsNullable = true;
				colvarAuditUser.IsPrimaryKey = false;
				colvarAuditUser.IsForeignKey = false;
				colvarAuditUser.IsReadOnly = false;
				colvarAuditUser.DefaultSetting = @"";
				colvarAuditUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditUser);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Registros_Practicas",schema);
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
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("IdTipoPractica")]
		[Bindable(true)]
		public int IdTipoPractica 
		{
			get { return GetColumnValue<int>(Columns.IdTipoPractica); }
			set { SetColumnValue(Columns.IdTipoPractica, value); }
		}
		  
		[XmlAttribute("IdPrioridad")]
		[Bindable(true)]
		public int IdPrioridad 
		{
			get { return GetColumnValue<int>(Columns.IdPrioridad); }
			set { SetColumnValue(Columns.IdPrioridad, value); }
		}
		  
		[XmlAttribute("IdEstado")]
		[Bindable(true)]
		public int IdEstado 
		{
			get { return GetColumnValue<int>(Columns.IdEstado); }
			set { SetColumnValue(Columns.IdEstado, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		  
		[XmlAttribute("AuditUser")]
		[Bindable(true)]
		public int? AuditUser 
		{
			get { return GetColumnValue<int?>(Columns.AuditUser); }
			set { SetColumnValue(Columns.AuditUser, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdRegistroGuardia,int? varIdEfector,DateTime varFecha,int varIdTipoPractica,int varIdPrioridad,int varIdEstado,string varObservaciones,string varUrl,int? varAuditUser)
		{
			GuardiaRegistrosPractica item = new GuardiaRegistrosPractica();
			
			item.IdRegistroGuardia = varIdRegistroGuardia;
			
			item.IdEfector = varIdEfector;
			
			item.Fecha = varFecha;
			
			item.IdTipoPractica = varIdTipoPractica;
			
			item.IdPrioridad = varIdPrioridad;
			
			item.IdEstado = varIdEstado;
			
			item.Observaciones = varObservaciones;
			
			item.Url = varUrl;
			
			item.AuditUser = varAuditUser;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varIdRegistroGuardia,int? varIdEfector,DateTime varFecha,int varIdTipoPractica,int varIdPrioridad,int varIdEstado,string varObservaciones,string varUrl,int? varAuditUser)
		{
			GuardiaRegistrosPractica item = new GuardiaRegistrosPractica();
			
				item.Id = varId;
			
				item.IdRegistroGuardia = varIdRegistroGuardia;
			
				item.IdEfector = varIdEfector;
			
				item.Fecha = varFecha;
			
				item.IdTipoPractica = varIdTipoPractica;
			
				item.IdPrioridad = varIdPrioridad;
			
				item.IdEstado = varIdEstado;
			
				item.Observaciones = varObservaciones;
			
				item.Url = varUrl;
			
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
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoPracticaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPrioridadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditUserColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdRegistroGuardia = @"idRegistroGuardia";
			 public static string IdEfector = @"idEfector";
			 public static string Fecha = @"fecha";
			 public static string IdTipoPractica = @"idTipoPractica";
			 public static string IdPrioridad = @"idPrioridad";
			 public static string IdEstado = @"idEstado";
			 public static string Observaciones = @"observaciones";
			 public static string Url = @"url";
			 public static string AuditUser = @"auditUser";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
