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
	/// Strongly-typed collection for the GuardiaPrescripcione class.
	/// </summary>
    [Serializable]
	public partial class GuardiaPrescripcioneCollection : ActiveList<GuardiaPrescripcione, GuardiaPrescripcioneCollection>
	{	   
		public GuardiaPrescripcioneCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaPrescripcioneCollection</returns>
		public GuardiaPrescripcioneCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaPrescripcione o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Prescripciones table.
	/// </summary>
	[Serializable]
	public partial class GuardiaPrescripcione : ActiveRecord<GuardiaPrescripcione>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaPrescripcione()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaPrescripcione(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaPrescripcione(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaPrescripcione(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Prescripciones", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarIdRegistro = new TableSchema.TableColumn(schema);
				colvarIdRegistro.ColumnName = "id_Registro";
				colvarIdRegistro.DataType = DbType.Int32;
				colvarIdRegistro.MaxLength = 0;
				colvarIdRegistro.AutoIncrement = false;
				colvarIdRegistro.IsNullable = false;
				colvarIdRegistro.IsPrimaryKey = false;
				colvarIdRegistro.IsForeignKey = false;
				colvarIdRegistro.IsReadOnly = false;
				colvarIdRegistro.DefaultSetting = @"";
				colvarIdRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRegistro);
				
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
				
				TableSchema.TableColumn colvarIsPrescMedica = new TableSchema.TableColumn(schema);
				colvarIsPrescMedica.ColumnName = "isPrescMedica";
				colvarIsPrescMedica.DataType = DbType.Boolean;
				colvarIsPrescMedica.MaxLength = 0;
				colvarIsPrescMedica.AutoIncrement = false;
				colvarIsPrescMedica.IsNullable = true;
				colvarIsPrescMedica.IsPrimaryKey = false;
				colvarIsPrescMedica.IsForeignKey = false;
				colvarIsPrescMedica.IsReadOnly = false;
				colvarIsPrescMedica.DefaultSetting = @"";
				colvarIsPrescMedica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsPrescMedica);
				
				TableSchema.TableColumn colvarPrescripcion = new TableSchema.TableColumn(schema);
				colvarPrescripcion.ColumnName = "prescripcion";
				colvarPrescripcion.DataType = DbType.AnsiString;
				colvarPrescripcion.MaxLength = -1;
				colvarPrescripcion.AutoIncrement = false;
				colvarPrescripcion.IsNullable = true;
				colvarPrescripcion.IsPrimaryKey = false;
				colvarPrescripcion.IsForeignKey = false;
				colvarPrescripcion.IsReadOnly = false;
				colvarPrescripcion.DefaultSetting = @"";
				colvarPrescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrescripcion);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "observacion";
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
				
				TableSchema.TableColumn colvarIsTerminada = new TableSchema.TableColumn(schema);
				colvarIsTerminada.ColumnName = "isTerminada";
				colvarIsTerminada.DataType = DbType.Boolean;
				colvarIsTerminada.MaxLength = 0;
				colvarIsTerminada.AutoIncrement = false;
				colvarIsTerminada.IsNullable = true;
				colvarIsTerminada.IsPrimaryKey = false;
				colvarIsTerminada.IsForeignKey = false;
				colvarIsTerminada.IsReadOnly = false;
				colvarIsTerminada.DefaultSetting = @"";
				colvarIsTerminada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsTerminada);
				
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
				
				TableSchema.TableColumn colvarFechaRealizada = new TableSchema.TableColumn(schema);
				colvarFechaRealizada.ColumnName = "fechaRealizada";
				colvarFechaRealizada.DataType = DbType.DateTime;
				colvarFechaRealizada.MaxLength = 0;
				colvarFechaRealizada.AutoIncrement = false;
				colvarFechaRealizada.IsNullable = true;
				colvarFechaRealizada.IsPrimaryKey = false;
				colvarFechaRealizada.IsForeignKey = false;
				colvarFechaRealizada.IsReadOnly = false;
				colvarFechaRealizada.DefaultSetting = @"";
				colvarFechaRealizada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRealizada);
				
				TableSchema.TableColumn colvarAuditUserMedico = new TableSchema.TableColumn(schema);
				colvarAuditUserMedico.ColumnName = "audit_user_Medico";
				colvarAuditUserMedico.DataType = DbType.Int32;
				colvarAuditUserMedico.MaxLength = 0;
				colvarAuditUserMedico.AutoIncrement = false;
				colvarAuditUserMedico.IsNullable = true;
				colvarAuditUserMedico.IsPrimaryKey = false;
				colvarAuditUserMedico.IsForeignKey = false;
				colvarAuditUserMedico.IsReadOnly = false;
				colvarAuditUserMedico.DefaultSetting = @"";
				colvarAuditUserMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditUserMedico);
				
				TableSchema.TableColumn colvarAuditUserEnfermeria = new TableSchema.TableColumn(schema);
				colvarAuditUserEnfermeria.ColumnName = "audit_user_enfermeria";
				colvarAuditUserEnfermeria.DataType = DbType.Int32;
				colvarAuditUserEnfermeria.MaxLength = 0;
				colvarAuditUserEnfermeria.AutoIncrement = false;
				colvarAuditUserEnfermeria.IsNullable = true;
				colvarAuditUserEnfermeria.IsPrimaryKey = false;
				colvarAuditUserEnfermeria.IsForeignKey = false;
				colvarAuditUserEnfermeria.IsReadOnly = false;
				colvarAuditUserEnfermeria.DefaultSetting = @"";
				colvarAuditUserEnfermeria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditUserEnfermeria);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Prescripciones",schema);
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
		  
		[XmlAttribute("IdRegistro")]
		[Bindable(true)]
		public int IdRegistro 
		{
			get { return GetColumnValue<int>(Columns.IdRegistro); }
			set { SetColumnValue(Columns.IdRegistro, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IsPrescMedica")]
		[Bindable(true)]
		public bool? IsPrescMedica 
		{
			get { return GetColumnValue<bool?>(Columns.IsPrescMedica); }
			set { SetColumnValue(Columns.IsPrescMedica, value); }
		}
		  
		[XmlAttribute("Prescripcion")]
		[Bindable(true)]
		public string Prescripcion 
		{
			get { return GetColumnValue<string>(Columns.Prescripcion); }
			set { SetColumnValue(Columns.Prescripcion, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		  
		[XmlAttribute("IsTerminada")]
		[Bindable(true)]
		public bool? IsTerminada 
		{
			get { return GetColumnValue<bool?>(Columns.IsTerminada); }
			set { SetColumnValue(Columns.IsTerminada, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("FechaRealizada")]
		[Bindable(true)]
		public DateTime? FechaRealizada 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRealizada); }
			set { SetColumnValue(Columns.FechaRealizada, value); }
		}
		  
		[XmlAttribute("AuditUserMedico")]
		[Bindable(true)]
		public int? AuditUserMedico 
		{
			get { return GetColumnValue<int?>(Columns.AuditUserMedico); }
			set { SetColumnValue(Columns.AuditUserMedico, value); }
		}
		  
		[XmlAttribute("AuditUserEnfermeria")]
		[Bindable(true)]
		public int? AuditUserEnfermeria 
		{
			get { return GetColumnValue<int?>(Columns.AuditUserEnfermeria); }
			set { SetColumnValue(Columns.AuditUserEnfermeria, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdRegistro,int? varIdEfector,bool? varIsPrescMedica,string varPrescripcion,string varObservacion,bool? varIsTerminada,DateTime? varFecha,DateTime? varFechaRealizada,int? varAuditUserMedico,int? varAuditUserEnfermeria)
		{
			GuardiaPrescripcione item = new GuardiaPrescripcione();
			
			item.IdRegistro = varIdRegistro;
			
			item.IdEfector = varIdEfector;
			
			item.IsPrescMedica = varIsPrescMedica;
			
			item.Prescripcion = varPrescripcion;
			
			item.Observacion = varObservacion;
			
			item.IsTerminada = varIsTerminada;
			
			item.Fecha = varFecha;
			
			item.FechaRealizada = varFechaRealizada;
			
			item.AuditUserMedico = varAuditUserMedico;
			
			item.AuditUserEnfermeria = varAuditUserEnfermeria;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varIdRegistro,int? varIdEfector,bool? varIsPrescMedica,string varPrescripcion,string varObservacion,bool? varIsTerminada,DateTime? varFecha,DateTime? varFechaRealizada,int? varAuditUserMedico,int? varAuditUserEnfermeria)
		{
			GuardiaPrescripcione item = new GuardiaPrescripcione();
			
				item.Id = varId;
			
				item.IdRegistro = varIdRegistro;
			
				item.IdEfector = varIdEfector;
			
				item.IsPrescMedica = varIsPrescMedica;
			
				item.Prescripcion = varPrescripcion;
			
				item.Observacion = varObservacion;
			
				item.IsTerminada = varIsTerminada;
			
				item.Fecha = varFecha;
			
				item.FechaRealizada = varFechaRealizada;
			
				item.AuditUserMedico = varAuditUserMedico;
			
				item.AuditUserEnfermeria = varAuditUserEnfermeria;
			
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
        
        
        
        public static TableSchema.TableColumn IdRegistroColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IsPrescMedicaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PrescripcionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IsTerminadaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRealizadaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditUserMedicoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditUserEnfermeriaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdRegistro = @"id_Registro";
			 public static string IdEfector = @"idEfector";
			 public static string IsPrescMedica = @"isPrescMedica";
			 public static string Prescripcion = @"prescripcion";
			 public static string Observacion = @"observacion";
			 public static string IsTerminada = @"isTerminada";
			 public static string Fecha = @"fecha";
			 public static string FechaRealizada = @"fechaRealizada";
			 public static string AuditUserMedico = @"audit_user_Medico";
			 public static string AuditUserEnfermeria = @"audit_user_enfermeria";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
