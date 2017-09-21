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
	/// Strongly-typed collection for the GuardiaRegistrosDiagnosticosCie10 class.
	/// </summary>
    [Serializable]
	public partial class GuardiaRegistrosDiagnosticosCie10Collection : ActiveList<GuardiaRegistrosDiagnosticosCie10, GuardiaRegistrosDiagnosticosCie10Collection>
	{	   
		public GuardiaRegistrosDiagnosticosCie10Collection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaRegistrosDiagnosticosCie10Collection</returns>
		public GuardiaRegistrosDiagnosticosCie10Collection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaRegistrosDiagnosticosCie10 o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Registros_Diagnosticos_Cie10 table.
	/// </summary>
	[Serializable]
	public partial class GuardiaRegistrosDiagnosticosCie10 : ActiveRecord<GuardiaRegistrosDiagnosticosCie10>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaRegistrosDiagnosticosCie10()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaRegistrosDiagnosticosCie10(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaRegistrosDiagnosticosCie10(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaRegistrosDiagnosticosCie10(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Registros_Diagnosticos_Cie10", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarIdCie10 = new TableSchema.TableColumn(schema);
				colvarIdCie10.ColumnName = "idCie10";
				colvarIdCie10.DataType = DbType.Int32;
				colvarIdCie10.MaxLength = 0;
				colvarIdCie10.AutoIncrement = false;
				colvarIdCie10.IsNullable = true;
				colvarIdCie10.IsPrimaryKey = false;
				colvarIdCie10.IsForeignKey = true;
				colvarIdCie10.IsReadOnly = false;
				colvarIdCie10.DefaultSetting = @"";
				
					colvarIdCie10.ForeignKeyTableName = "Sys_CIE10";
				schema.Columns.Add(colvarIdCie10);
				
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
				
				TableSchema.TableColumn colvarPrimeraVez = new TableSchema.TableColumn(schema);
				colvarPrimeraVez.ColumnName = "primeraVez";
				colvarPrimeraVez.DataType = DbType.Int32;
				colvarPrimeraVez.MaxLength = 0;
				colvarPrimeraVez.AutoIncrement = false;
				colvarPrimeraVez.IsNullable = true;
				colvarPrimeraVez.IsPrimaryKey = false;
				colvarPrimeraVez.IsForeignKey = false;
				colvarPrimeraVez.IsReadOnly = false;
				colvarPrimeraVez.DefaultSetting = @"";
				colvarPrimeraVez.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimeraVez);
				
				TableSchema.TableColumn colvarTipoDiagnostico = new TableSchema.TableColumn(schema);
				colvarTipoDiagnostico.ColumnName = "tipoDiagnostico";
				colvarTipoDiagnostico.DataType = DbType.Int32;
				colvarTipoDiagnostico.MaxLength = 0;
				colvarTipoDiagnostico.AutoIncrement = false;
				colvarTipoDiagnostico.IsNullable = true;
				colvarTipoDiagnostico.IsPrimaryKey = false;
				colvarTipoDiagnostico.IsForeignKey = false;
				colvarTipoDiagnostico.IsReadOnly = false;
				colvarTipoDiagnostico.DefaultSetting = @"";
				colvarTipoDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDiagnostico);
				
				TableSchema.TableColumn colvarDiagnosticoManual = new TableSchema.TableColumn(schema);
				colvarDiagnosticoManual.ColumnName = "diagnosticoManual";
				colvarDiagnosticoManual.DataType = DbType.AnsiString;
				colvarDiagnosticoManual.MaxLength = -1;
				colvarDiagnosticoManual.AutoIncrement = false;
				colvarDiagnosticoManual.IsNullable = true;
				colvarDiagnosticoManual.IsPrimaryKey = false;
				colvarDiagnosticoManual.IsForeignKey = false;
				colvarDiagnosticoManual.IsReadOnly = false;
				colvarDiagnosticoManual.DefaultSetting = @"";
				colvarDiagnosticoManual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoManual);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Registros_Diagnosticos_Cie10",schema);
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
		  
		[XmlAttribute("IdCie10")]
		[Bindable(true)]
		public int? IdCie10 
		{
			get { return GetColumnValue<int?>(Columns.IdCie10); }
			set { SetColumnValue(Columns.IdCie10, value); }
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
		  
		[XmlAttribute("PrimeraVez")]
		[Bindable(true)]
		public int? PrimeraVez 
		{
			get { return GetColumnValue<int?>(Columns.PrimeraVez); }
			set { SetColumnValue(Columns.PrimeraVez, value); }
		}
		  
		[XmlAttribute("TipoDiagnostico")]
		[Bindable(true)]
		public int? TipoDiagnostico 
		{
			get { return GetColumnValue<int?>(Columns.TipoDiagnostico); }
			set { SetColumnValue(Columns.TipoDiagnostico, value); }
		}
		  
		[XmlAttribute("DiagnosticoManual")]
		[Bindable(true)]
		public string DiagnosticoManual 
		{
			get { return GetColumnValue<string>(Columns.DiagnosticoManual); }
			set { SetColumnValue(Columns.DiagnosticoManual, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysCIE10 ActiveRecord object related to this GuardiaRegistrosDiagnosticosCie10
		/// 
		/// </summary>
		public DalSic.SysCIE10 SysCIE10
		{
			get { return DalSic.SysCIE10.FetchByID(this.IdCie10); }
			set { SetColumnValue("idCie10", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a GuardiaRegistro ActiveRecord object related to this GuardiaRegistrosDiagnosticosCie10
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
		public static void Insert(int? varIdRegistroGuardia,int? varIdEfector,int? varIdCie10,DateTime? varFecha,int varAuditUser,int? varPrimeraVez,int? varTipoDiagnostico,string varDiagnosticoManual)
		{
			GuardiaRegistrosDiagnosticosCie10 item = new GuardiaRegistrosDiagnosticosCie10();
			
			item.IdRegistroGuardia = varIdRegistroGuardia;
			
			item.IdEfector = varIdEfector;
			
			item.IdCie10 = varIdCie10;
			
			item.Fecha = varFecha;
			
			item.AuditUser = varAuditUser;
			
			item.PrimeraVez = varPrimeraVez;
			
			item.TipoDiagnostico = varTipoDiagnostico;
			
			item.DiagnosticoManual = varDiagnosticoManual;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdRegistroGuardia,int? varIdEfector,int? varIdCie10,DateTime? varFecha,int varAuditUser,int? varPrimeraVez,int? varTipoDiagnostico,string varDiagnosticoManual)
		{
			GuardiaRegistrosDiagnosticosCie10 item = new GuardiaRegistrosDiagnosticosCie10();
			
				item.Id = varId;
			
				item.IdRegistroGuardia = varIdRegistroGuardia;
			
				item.IdEfector = varIdEfector;
			
				item.IdCie10 = varIdCie10;
			
				item.Fecha = varFecha;
			
				item.AuditUser = varAuditUser;
			
				item.PrimeraVez = varPrimeraVez;
			
				item.TipoDiagnostico = varTipoDiagnostico;
			
				item.DiagnosticoManual = varDiagnosticoManual;
			
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
        
        
        
        public static TableSchema.TableColumn IdCie10Column
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditUserColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimeraVezColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDiagnosticoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoManualColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdRegistroGuardia = @"idRegistroGuardia";
			 public static string IdEfector = @"idEfector";
			 public static string IdCie10 = @"idCie10";
			 public static string Fecha = @"fecha";
			 public static string AuditUser = @"audit_user";
			 public static string PrimeraVez = @"primeraVez";
			 public static string TipoDiagnostico = @"tipoDiagnostico";
			 public static string DiagnosticoManual = @"diagnosticoManual";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
