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
	/// Strongly-typed collection for the AprActividadFisica class.
	/// </summary>
    [Serializable]
	public partial class AprActividadFisicaCollection : ActiveList<AprActividadFisica, AprActividadFisicaCollection>
	{	   
		public AprActividadFisicaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprActividadFisicaCollection</returns>
		public AprActividadFisicaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprActividadFisica o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ActividadFisica table.
	/// </summary>
	[Serializable]
	public partial class AprActividadFisica : ActiveRecord<AprActividadFisica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprActividadFisica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprActividadFisica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprActividadFisica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprActividadFisica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ActividadFisica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdActividadFisica = new TableSchema.TableColumn(schema);
				colvarIdActividadFisica.ColumnName = "idActividadFisica";
				colvarIdActividadFisica.DataType = DbType.Int32;
				colvarIdActividadFisica.MaxLength = 0;
				colvarIdActividadFisica.AutoIncrement = true;
				colvarIdActividadFisica.IsNullable = false;
				colvarIdActividadFisica.IsPrimaryKey = true;
				colvarIdActividadFisica.IsForeignKey = false;
				colvarIdActividadFisica.IsReadOnly = false;
				colvarIdActividadFisica.DefaultSetting = @"";
				colvarIdActividadFisica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdActividadFisica);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				
						colvarIdPaciente.DefaultSetting = @"((0))";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarFechaControl = new TableSchema.TableColumn(schema);
				colvarFechaControl.ColumnName = "fechaControl";
				colvarFechaControl.DataType = DbType.DateTime;
				colvarFechaControl.MaxLength = 0;
				colvarFechaControl.AutoIncrement = false;
				colvarFechaControl.IsNullable = false;
				colvarFechaControl.IsPrimaryKey = false;
				colvarFechaControl.IsForeignKey = false;
				colvarFechaControl.IsReadOnly = false;
				colvarFechaControl.DefaultSetting = @"";
				colvarFechaControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaControl);
				
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
				
				TableSchema.TableColumn colvarMedicoCabecera = new TableSchema.TableColumn(schema);
				colvarMedicoCabecera.ColumnName = "medicoCabecera";
				colvarMedicoCabecera.DataType = DbType.AnsiString;
				colvarMedicoCabecera.MaxLength = 300;
				colvarMedicoCabecera.AutoIncrement = false;
				colvarMedicoCabecera.IsNullable = false;
				colvarMedicoCabecera.IsPrimaryKey = false;
				colvarMedicoCabecera.IsForeignKey = false;
				colvarMedicoCabecera.IsReadOnly = false;
				
						colvarMedicoCabecera.DefaultSetting = @"((0))";
				colvarMedicoCabecera.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicoCabecera);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = false;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				
						colvarPeso.DefaultSetting = @"((0))";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "talla";
				colvarTalla.DataType = DbType.Decimal;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = false;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				
						colvarTalla.DefaultSetting = @"((0))";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarImc = new TableSchema.TableColumn(schema);
				colvarImc.ColumnName = "Imc";
				colvarImc.DataType = DbType.Decimal;
				colvarImc.MaxLength = 0;
				colvarImc.AutoIncrement = false;
				colvarImc.IsNullable = false;
				colvarImc.IsPrimaryKey = false;
				colvarImc.IsForeignKey = false;
				colvarImc.IsReadOnly = false;
				
						colvarImc.DefaultSetting = @"((0))";
				colvarImc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImc);
				
				TableSchema.TableColumn colvarRiesgoCardiovascular = new TableSchema.TableColumn(schema);
				colvarRiesgoCardiovascular.ColumnName = "riesgoCardiovascular";
				colvarRiesgoCardiovascular.DataType = DbType.Int32;
				colvarRiesgoCardiovascular.MaxLength = 0;
				colvarRiesgoCardiovascular.AutoIncrement = false;
				colvarRiesgoCardiovascular.IsNullable = false;
				colvarRiesgoCardiovascular.IsPrimaryKey = false;
				colvarRiesgoCardiovascular.IsForeignKey = false;
				colvarRiesgoCardiovascular.IsReadOnly = false;
				
						colvarRiesgoCardiovascular.DefaultSetting = @"((0))";
				colvarRiesgoCardiovascular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRiesgoCardiovascular);
				
				TableSchema.TableColumn colvarDiagnosticos = new TableSchema.TableColumn(schema);
				colvarDiagnosticos.ColumnName = "diagnosticos";
				colvarDiagnosticos.DataType = DbType.AnsiString;
				colvarDiagnosticos.MaxLength = 500;
				colvarDiagnosticos.AutoIncrement = false;
				colvarDiagnosticos.IsNullable = false;
				colvarDiagnosticos.IsPrimaryKey = false;
				colvarDiagnosticos.IsForeignKey = false;
				colvarDiagnosticos.IsReadOnly = false;
				
						colvarDiagnosticos.DefaultSetting = @"('')";
				colvarDiagnosticos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticos);
				
				TableSchema.TableColumn colvarAptitud = new TableSchema.TableColumn(schema);
				colvarAptitud.ColumnName = "aptitud";
				colvarAptitud.DataType = DbType.AnsiStringFixedLength;
				colvarAptitud.MaxLength = 10;
				colvarAptitud.AutoIncrement = false;
				colvarAptitud.IsNullable = false;
				colvarAptitud.IsPrimaryKey = false;
				colvarAptitud.IsForeignKey = false;
				colvarAptitud.IsReadOnly = false;
				
						colvarAptitud.DefaultSetting = @"('')";
				colvarAptitud.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAptitud);
				
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
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = 500;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = false;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				
						colvarObservacion.DefaultSetting = @"('')";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
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
				colvarModifiedBy.DataType = DbType.String;
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
				DataService.Providers["sicProvider"].AddSchema("APR_ActividadFisica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdActividadFisica")]
		[Bindable(true)]
		public int IdActividadFisica 
		{
			get { return GetColumnValue<int>(Columns.IdActividadFisica); }
			set { SetColumnValue(Columns.IdActividadFisica, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("FechaControl")]
		[Bindable(true)]
		public DateTime FechaControl 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaControl); }
			set { SetColumnValue(Columns.FechaControl, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("MedicoCabecera")]
		[Bindable(true)]
		public string MedicoCabecera 
		{
			get { return GetColumnValue<string>(Columns.MedicoCabecera); }
			set { SetColumnValue(Columns.MedicoCabecera, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal Peso 
		{
			get { return GetColumnValue<decimal>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public decimal Talla 
		{
			get { return GetColumnValue<decimal>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("Imc")]
		[Bindable(true)]
		public decimal Imc 
		{
			get { return GetColumnValue<decimal>(Columns.Imc); }
			set { SetColumnValue(Columns.Imc, value); }
		}
		  
		[XmlAttribute("RiesgoCardiovascular")]
		[Bindable(true)]
		public int RiesgoCardiovascular 
		{
			get { return GetColumnValue<int>(Columns.RiesgoCardiovascular); }
			set { SetColumnValue(Columns.RiesgoCardiovascular, value); }
		}
		  
		[XmlAttribute("Diagnosticos")]
		[Bindable(true)]
		public string Diagnosticos 
		{
			get { return GetColumnValue<string>(Columns.Diagnosticos); }
			set { SetColumnValue(Columns.Diagnosticos, value); }
		}
		  
		[XmlAttribute("Aptitud")]
		[Bindable(true)]
		public string Aptitud 
		{
			get { return GetColumnValue<string>(Columns.Aptitud); }
			set { SetColumnValue(Columns.Aptitud, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this AprActividadFisica
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this AprActividadFisica
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this AprActividadFisica
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
		public static void Insert(int varIdPaciente,DateTime varFechaControl,int varEdad,int varIdEfector,string varMedicoCabecera,decimal varPeso,decimal varTalla,decimal varImc,int varRiesgoCardiovascular,string varDiagnosticos,string varAptitud,int varIdProfesional,string varObservacion,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			AprActividadFisica item = new AprActividadFisica();
			
			item.IdPaciente = varIdPaciente;
			
			item.FechaControl = varFechaControl;
			
			item.Edad = varEdad;
			
			item.IdEfector = varIdEfector;
			
			item.MedicoCabecera = varMedicoCabecera;
			
			item.Peso = varPeso;
			
			item.Talla = varTalla;
			
			item.Imc = varImc;
			
			item.RiesgoCardiovascular = varRiesgoCardiovascular;
			
			item.Diagnosticos = varDiagnosticos;
			
			item.Aptitud = varAptitud;
			
			item.IdProfesional = varIdProfesional;
			
			item.Observacion = varObservacion;
			
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
		public static void Update(int varIdActividadFisica,int varIdPaciente,DateTime varFechaControl,int varEdad,int varIdEfector,string varMedicoCabecera,decimal varPeso,decimal varTalla,decimal varImc,int varRiesgoCardiovascular,string varDiagnosticos,string varAptitud,int varIdProfesional,string varObservacion,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			AprActividadFisica item = new AprActividadFisica();
			
				item.IdActividadFisica = varIdActividadFisica;
			
				item.IdPaciente = varIdPaciente;
			
				item.FechaControl = varFechaControl;
			
				item.Edad = varEdad;
			
				item.IdEfector = varIdEfector;
			
				item.MedicoCabecera = varMedicoCabecera;
			
				item.Peso = varPeso;
			
				item.Talla = varTalla;
			
				item.Imc = varImc;
			
				item.RiesgoCardiovascular = varRiesgoCardiovascular;
			
				item.Diagnosticos = varDiagnosticos;
			
				item.Aptitud = varAptitud;
			
				item.IdProfesional = varIdProfesional;
			
				item.Observacion = varObservacion;
			
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
        
        
        public static TableSchema.TableColumn IdActividadFisicaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaControlColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoCabeceraColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ImcColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn RiesgoCardiovascularColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticosColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AptitudColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdActividadFisica = @"idActividadFisica";
			 public static string IdPaciente = @"idPaciente";
			 public static string FechaControl = @"fechaControl";
			 public static string Edad = @"edad";
			 public static string IdEfector = @"idEfector";
			 public static string MedicoCabecera = @"medicoCabecera";
			 public static string Peso = @"peso";
			 public static string Talla = @"talla";
			 public static string Imc = @"Imc";
			 public static string RiesgoCardiovascular = @"riesgoCardiovascular";
			 public static string Diagnosticos = @"diagnosticos";
			 public static string Aptitud = @"aptitud";
			 public static string IdProfesional = @"idProfesional";
			 public static string Observacion = @"observacion";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
