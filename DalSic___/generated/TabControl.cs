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
	/// Strongly-typed collection for the TabControl class.
	/// </summary>
    [Serializable]
	public partial class TabControlCollection : ActiveList<TabControl, TabControlCollection>
	{	   
		public TabControlCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TabControlCollection</returns>
		public TabControlCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TabControl o = this[i];
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
	/// This is an ActiveRecord class which wraps the TAB_Control table.
	/// </summary>
	[Serializable]
	public partial class TabControl : ActiveRecord<TabControl>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TabControl()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TabControl(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TabControl(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TabControl(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TAB_Control", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdControl = new TableSchema.TableColumn(schema);
				colvarIdControl.ColumnName = "idControl";
				colvarIdControl.DataType = DbType.Int32;
				colvarIdControl.MaxLength = 0;
				colvarIdControl.AutoIncrement = true;
				colvarIdControl.IsNullable = false;
				colvarIdControl.IsPrimaryKey = true;
				colvarIdControl.IsForeignKey = false;
				colvarIdControl.IsReadOnly = false;
				colvarIdControl.DefaultSetting = @"";
				colvarIdControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdControl);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				
						colvarIdEfector.DefaultSetting = @"((0))";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				
						colvarIdPaciente.DefaultSetting = @"((0))";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				
						colvarFechaRegistro.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.AnsiString;
				colvarSexo.MaxLength = 10;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = false;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				
						colvarSexo.DefaultSetting = @"('')";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = false;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				
						colvarEdad.DefaultSetting = @"((0))";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarOtrosTelefonos = new TableSchema.TableColumn(schema);
				colvarOtrosTelefonos.ColumnName = "otrosTelefonos";
				colvarOtrosTelefonos.DataType = DbType.AnsiString;
				colvarOtrosTelefonos.MaxLength = 200;
				colvarOtrosTelefonos.AutoIncrement = false;
				colvarOtrosTelefonos.IsNullable = false;
				colvarOtrosTelefonos.IsPrimaryKey = false;
				colvarOtrosTelefonos.IsForeignKey = false;
				colvarOtrosTelefonos.IsReadOnly = false;
				
						colvarOtrosTelefonos.DefaultSetting = @"('')";
				colvarOtrosTelefonos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrosTelefonos);
				
				TableSchema.TableColumn colvarFechaD = new TableSchema.TableColumn(schema);
				colvarFechaD.ColumnName = "fechaD";
				colvarFechaD.DataType = DbType.DateTime;
				colvarFechaD.MaxLength = 0;
				colvarFechaD.AutoIncrement = false;
				colvarFechaD.IsNullable = false;
				colvarFechaD.IsPrimaryKey = false;
				colvarFechaD.IsForeignKey = false;
				colvarFechaD.IsReadOnly = false;
				
						colvarFechaD.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaD);
				
				TableSchema.TableColumn colvarFechaPrescripcion = new TableSchema.TableColumn(schema);
				colvarFechaPrescripcion.ColumnName = "fechaPrescripcion";
				colvarFechaPrescripcion.DataType = DbType.DateTime;
				colvarFechaPrescripcion.MaxLength = 0;
				colvarFechaPrescripcion.AutoIncrement = false;
				colvarFechaPrescripcion.IsNullable = false;
				colvarFechaPrescripcion.IsPrimaryKey = false;
				colvarFechaPrescripcion.IsForeignKey = false;
				colvarFechaPrescripcion.IsReadOnly = false;
				
						colvarFechaPrescripcion.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaPrescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaPrescripcion);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 300;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = false;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				
						colvarObservaciones.DefaultSetting = @"('')";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				
						colvarIdProfesional.DefaultSetting = @"((0))";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((0))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"('')";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				
						colvarModifiedBy.DefaultSetting = @"('')";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				
						colvarModifiedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("TAB_Control",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdControl")]
		[Bindable(true)]
		public int IdControl 
		{
			get { return GetColumnValue<int>(Columns.IdControl); }
			set { SetColumnValue(Columns.IdControl, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("OtrosTelefonos")]
		[Bindable(true)]
		public string OtrosTelefonos 
		{
			get { return GetColumnValue<string>(Columns.OtrosTelefonos); }
			set { SetColumnValue(Columns.OtrosTelefonos, value); }
		}
		  
		[XmlAttribute("FechaD")]
		[Bindable(true)]
		public DateTime FechaD 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaD); }
			set { SetColumnValue(Columns.FechaD, value); }
		}
		  
		[XmlAttribute("FechaPrescripcion")]
		[Bindable(true)]
		public DateTime FechaPrescripcion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaPrescripcion); }
			set { SetColumnValue(Columns.FechaPrescripcion, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this TabControl
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this TabControl
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPaciente,DateTime varFechaRegistro,string varSexo,int varEdad,string varOtrosTelefonos,DateTime varFechaD,DateTime varFechaPrescripcion,string varObservaciones,int varIdProfesional,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			TabControl item = new TabControl();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.Sexo = varSexo;
			
			item.Edad = varEdad;
			
			item.OtrosTelefonos = varOtrosTelefonos;
			
			item.FechaD = varFechaD;
			
			item.FechaPrescripcion = varFechaPrescripcion;
			
			item.Observaciones = varObservaciones;
			
			item.IdProfesional = varIdProfesional;
			
			item.Activo = varActivo;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdControl,int varIdEfector,int varIdPaciente,DateTime varFechaRegistro,string varSexo,int varEdad,string varOtrosTelefonos,DateTime varFechaD,DateTime varFechaPrescripcion,string varObservaciones,int varIdProfesional,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			TabControl item = new TabControl();
			
				item.IdControl = varIdControl;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.Sexo = varSexo;
			
				item.Edad = varEdad;
			
				item.OtrosTelefonos = varOtrosTelefonos;
			
				item.FechaD = varFechaD;
			
				item.FechaPrescripcion = varFechaPrescripcion;
			
				item.Observaciones = varObservaciones;
			
				item.IdProfesional = varIdProfesional;
			
				item.Activo = varActivo;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdControlColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosTelefonosColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPrescripcionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdControl = @"idControl";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string FechaRegistro = @"fechaRegistro";
			 public static string Sexo = @"sexo";
			 public static string Edad = @"edad";
			 public static string OtrosTelefonos = @"otrosTelefonos";
			 public static string FechaD = @"fechaD";
			 public static string FechaPrescripcion = @"fechaPrescripcion";
			 public static string Observaciones = @"observaciones";
			 public static string IdProfesional = @"idProfesional";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
