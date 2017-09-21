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
	/// Strongly-typed collection for the AprPartoProvisorio class.
	/// </summary>
    [Serializable]
	public partial class AprPartoProvisorioCollection : ActiveList<AprPartoProvisorio, AprPartoProvisorioCollection>
	{	   
		public AprPartoProvisorioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprPartoProvisorioCollection</returns>
		public AprPartoProvisorioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprPartoProvisorio o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_PartoProvisorio table.
	/// </summary>
	[Serializable]
	public partial class AprPartoProvisorio : ActiveRecord<AprPartoProvisorio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprPartoProvisorio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprPartoProvisorio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprPartoProvisorio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprPartoProvisorio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_PartoProvisorio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdParto = new TableSchema.TableColumn(schema);
				colvarIdParto.ColumnName = "idParto";
				colvarIdParto.DataType = DbType.Int32;
				colvarIdParto.MaxLength = 0;
				colvarIdParto.AutoIncrement = true;
				colvarIdParto.IsNullable = false;
				colvarIdParto.IsPrimaryKey = true;
				colvarIdParto.IsForeignKey = false;
				colvarIdParto.IsReadOnly = false;
				colvarIdParto.DefaultSetting = @"";
				colvarIdParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdParto);
				
				TableSchema.TableColumn colvarIdEfectorParto = new TableSchema.TableColumn(schema);
				colvarIdEfectorParto.ColumnName = "idEfectorParto";
				colvarIdEfectorParto.DataType = DbType.Int32;
				colvarIdEfectorParto.MaxLength = 0;
				colvarIdEfectorParto.AutoIncrement = false;
				colvarIdEfectorParto.IsNullable = true;
				colvarIdEfectorParto.IsPrimaryKey = false;
				colvarIdEfectorParto.IsForeignKey = true;
				colvarIdEfectorParto.IsReadOnly = false;
				colvarIdEfectorParto.DefaultSetting = @"";
				
					colvarIdEfectorParto.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorParto);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarIdHistoriaClinicaPerinatal = new TableSchema.TableColumn(schema);
				colvarIdHistoriaClinicaPerinatal.ColumnName = "idHistoriaClinicaPerinatal";
				colvarIdHistoriaClinicaPerinatal.DataType = DbType.Int32;
				colvarIdHistoriaClinicaPerinatal.MaxLength = 0;
				colvarIdHistoriaClinicaPerinatal.AutoIncrement = false;
				colvarIdHistoriaClinicaPerinatal.IsNullable = true;
				colvarIdHistoriaClinicaPerinatal.IsPrimaryKey = false;
				colvarIdHistoriaClinicaPerinatal.IsForeignKey = true;
				colvarIdHistoriaClinicaPerinatal.IsReadOnly = false;
				colvarIdHistoriaClinicaPerinatal.DefaultSetting = @"";
				
					colvarIdHistoriaClinicaPerinatal.ForeignKeyTableName = "APR_HistoriaClinicaPerinatal";
				schema.Columns.Add(colvarIdHistoriaClinicaPerinatal);
				
				TableSchema.TableColumn colvarParto = new TableSchema.TableColumn(schema);
				colvarParto.ColumnName = "parto";
				colvarParto.DataType = DbType.Boolean;
				colvarParto.MaxLength = 0;
				colvarParto.AutoIncrement = false;
				colvarParto.IsNullable = true;
				colvarParto.IsPrimaryKey = false;
				colvarParto.IsForeignKey = false;
				colvarParto.IsReadOnly = false;
				
						colvarParto.DefaultSetting = @"((1))";
				colvarParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParto);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fechaNacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarIdTerminacionParto = new TableSchema.TableColumn(schema);
				colvarIdTerminacionParto.ColumnName = "idTerminacionParto";
				colvarIdTerminacionParto.DataType = DbType.Int32;
				colvarIdTerminacionParto.MaxLength = 0;
				colvarIdTerminacionParto.AutoIncrement = false;
				colvarIdTerminacionParto.IsNullable = true;
				colvarIdTerminacionParto.IsPrimaryKey = false;
				colvarIdTerminacionParto.IsForeignKey = true;
				colvarIdTerminacionParto.IsReadOnly = false;
				colvarIdTerminacionParto.DefaultSetting = @"";
				
					colvarIdTerminacionParto.ForeignKeyTableName = "APR_TipoParto";
				schema.Columns.Add(colvarIdTerminacionParto);
				
				TableSchema.TableColumn colvarEdadGestacional = new TableSchema.TableColumn(schema);
				colvarEdadGestacional.ColumnName = "edadGestacional";
				colvarEdadGestacional.DataType = DbType.Decimal;
				colvarEdadGestacional.MaxLength = 0;
				colvarEdadGestacional.AutoIncrement = false;
				colvarEdadGestacional.IsNullable = true;
				colvarEdadGestacional.IsPrimaryKey = false;
				colvarEdadGestacional.IsForeignKey = false;
				colvarEdadGestacional.IsReadOnly = false;
				colvarEdadGestacional.DefaultSetting = @"";
				colvarEdadGestacional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadGestacional);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Int32;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarAPGAR1 = new TableSchema.TableColumn(schema);
				colvarAPGAR1.ColumnName = "APGAR1";
				colvarAPGAR1.DataType = DbType.Int32;
				colvarAPGAR1.MaxLength = 0;
				colvarAPGAR1.AutoIncrement = false;
				colvarAPGAR1.IsNullable = true;
				colvarAPGAR1.IsPrimaryKey = false;
				colvarAPGAR1.IsForeignKey = false;
				colvarAPGAR1.IsReadOnly = false;
				colvarAPGAR1.DefaultSetting = @"";
				colvarAPGAR1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAPGAR1);
				
				TableSchema.TableColumn colvarAPGAR5 = new TableSchema.TableColumn(schema);
				colvarAPGAR5.ColumnName = "APGAR5";
				colvarAPGAR5.DataType = DbType.Int32;
				colvarAPGAR5.MaxLength = 0;
				colvarAPGAR5.AutoIncrement = false;
				colvarAPGAR5.IsNullable = true;
				colvarAPGAR5.IsPrimaryKey = false;
				colvarAPGAR5.IsForeignKey = false;
				colvarAPGAR5.IsReadOnly = false;
				colvarAPGAR5.DefaultSetting = @"";
				colvarAPGAR5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAPGAR5);
				
				TableSchema.TableColumn colvarManejoActivoAlumbramiento = new TableSchema.TableColumn(schema);
				colvarManejoActivoAlumbramiento.ColumnName = "manejoActivoAlumbramiento";
				colvarManejoActivoAlumbramiento.DataType = DbType.Boolean;
				colvarManejoActivoAlumbramiento.MaxLength = 0;
				colvarManejoActivoAlumbramiento.AutoIncrement = false;
				colvarManejoActivoAlumbramiento.IsNullable = true;
				colvarManejoActivoAlumbramiento.IsPrimaryKey = false;
				colvarManejoActivoAlumbramiento.IsForeignKey = false;
				colvarManejoActivoAlumbramiento.IsReadOnly = false;
				
						colvarManejoActivoAlumbramiento.DefaultSetting = @"((0))";
				colvarManejoActivoAlumbramiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarManejoActivoAlumbramiento);
				
				TableSchema.TableColumn colvarFechaPrimerControlPuerperio = new TableSchema.TableColumn(schema);
				colvarFechaPrimerControlPuerperio.ColumnName = "fechaPrimerControlPuerperio";
				colvarFechaPrimerControlPuerperio.DataType = DbType.DateTime;
				colvarFechaPrimerControlPuerperio.MaxLength = 0;
				colvarFechaPrimerControlPuerperio.AutoIncrement = false;
				colvarFechaPrimerControlPuerperio.IsNullable = true;
				colvarFechaPrimerControlPuerperio.IsPrimaryKey = false;
				colvarFechaPrimerControlPuerperio.IsForeignKey = false;
				colvarFechaPrimerControlPuerperio.IsReadOnly = false;
				colvarFechaPrimerControlPuerperio.DefaultSetting = @"";
				colvarFechaPrimerControlPuerperio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaPrimerControlPuerperio);
				
				TableSchema.TableColumn colvarNotaPrimerControlPuerperio = new TableSchema.TableColumn(schema);
				colvarNotaPrimerControlPuerperio.ColumnName = "NotaPrimerControlPuerperio";
				colvarNotaPrimerControlPuerperio.DataType = DbType.AnsiString;
				colvarNotaPrimerControlPuerperio.MaxLength = 500;
				colvarNotaPrimerControlPuerperio.AutoIncrement = false;
				colvarNotaPrimerControlPuerperio.IsNullable = true;
				colvarNotaPrimerControlPuerperio.IsPrimaryKey = false;
				colvarNotaPrimerControlPuerperio.IsForeignKey = false;
				colvarNotaPrimerControlPuerperio.IsReadOnly = false;
				colvarNotaPrimerControlPuerperio.DefaultSetting = @"";
				colvarNotaPrimerControlPuerperio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotaPrimerControlPuerperio);
				
				TableSchema.TableColumn colvarFechaSegundoControlPuerperio = new TableSchema.TableColumn(schema);
				colvarFechaSegundoControlPuerperio.ColumnName = "fechaSegundoControlPuerperio";
				colvarFechaSegundoControlPuerperio.DataType = DbType.DateTime;
				colvarFechaSegundoControlPuerperio.MaxLength = 0;
				colvarFechaSegundoControlPuerperio.AutoIncrement = false;
				colvarFechaSegundoControlPuerperio.IsNullable = true;
				colvarFechaSegundoControlPuerperio.IsPrimaryKey = false;
				colvarFechaSegundoControlPuerperio.IsForeignKey = false;
				colvarFechaSegundoControlPuerperio.IsReadOnly = false;
				colvarFechaSegundoControlPuerperio.DefaultSetting = @"";
				colvarFechaSegundoControlPuerperio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaSegundoControlPuerperio);
				
				TableSchema.TableColumn colvarNotaSegundoControlPuerperio = new TableSchema.TableColumn(schema);
				colvarNotaSegundoControlPuerperio.ColumnName = "NotaSegundoControlPuerperio";
				colvarNotaSegundoControlPuerperio.DataType = DbType.AnsiString;
				colvarNotaSegundoControlPuerperio.MaxLength = 500;
				colvarNotaSegundoControlPuerperio.AutoIncrement = false;
				colvarNotaSegundoControlPuerperio.IsNullable = true;
				colvarNotaSegundoControlPuerperio.IsPrimaryKey = false;
				colvarNotaSegundoControlPuerperio.IsForeignKey = false;
				colvarNotaSegundoControlPuerperio.IsReadOnly = false;
				colvarNotaSegundoControlPuerperio.DefaultSetting = @"";
				colvarNotaSegundoControlPuerperio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotaSegundoControlPuerperio);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 500;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarActiva = new TableSchema.TableColumn(schema);
				colvarActiva.ColumnName = "activa";
				colvarActiva.DataType = DbType.Boolean;
				colvarActiva.MaxLength = 0;
				colvarActiva.AutoIncrement = false;
				colvarActiva.IsNullable = false;
				colvarActiva.IsPrimaryKey = false;
				colvarActiva.IsForeignKey = false;
				colvarActiva.IsReadOnly = false;
				
						colvarActiva.DefaultSetting = @"((1))";
				colvarActiva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActiva);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = true;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				
						colvarIdProfesional.DefaultSetting = @"((0))";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_PartoProvisorio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdParto")]
		[Bindable(true)]
		public int IdParto 
		{
			get { return GetColumnValue<int>(Columns.IdParto); }
			set { SetColumnValue(Columns.IdParto, value); }
		}
		  
		[XmlAttribute("IdEfectorParto")]
		[Bindable(true)]
		public int? IdEfectorParto 
		{
			get { return GetColumnValue<int?>(Columns.IdEfectorParto); }
			set { SetColumnValue(Columns.IdEfectorParto, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdHistoriaClinicaPerinatal")]
		[Bindable(true)]
		public int? IdHistoriaClinicaPerinatal 
		{
			get { return GetColumnValue<int?>(Columns.IdHistoriaClinicaPerinatal); }
			set { SetColumnValue(Columns.IdHistoriaClinicaPerinatal, value); }
		}
		  
		[XmlAttribute("Parto")]
		[Bindable(true)]
		public bool? Parto 
		{
			get { return GetColumnValue<bool?>(Columns.Parto); }
			set { SetColumnValue(Columns.Parto, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("IdTerminacionParto")]
		[Bindable(true)]
		public int? IdTerminacionParto 
		{
			get { return GetColumnValue<int?>(Columns.IdTerminacionParto); }
			set { SetColumnValue(Columns.IdTerminacionParto, value); }
		}
		  
		[XmlAttribute("EdadGestacional")]
		[Bindable(true)]
		public decimal? EdadGestacional 
		{
			get { return GetColumnValue<decimal?>(Columns.EdadGestacional); }
			set { SetColumnValue(Columns.EdadGestacional, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public int? Peso 
		{
			get { return GetColumnValue<int?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("APGAR1")]
		[Bindable(true)]
		public int? APGAR1 
		{
			get { return GetColumnValue<int?>(Columns.APGAR1); }
			set { SetColumnValue(Columns.APGAR1, value); }
		}
		  
		[XmlAttribute("APGAR5")]
		[Bindable(true)]
		public int? APGAR5 
		{
			get { return GetColumnValue<int?>(Columns.APGAR5); }
			set { SetColumnValue(Columns.APGAR5, value); }
		}
		  
		[XmlAttribute("ManejoActivoAlumbramiento")]
		[Bindable(true)]
		public bool? ManejoActivoAlumbramiento 
		{
			get { return GetColumnValue<bool?>(Columns.ManejoActivoAlumbramiento); }
			set { SetColumnValue(Columns.ManejoActivoAlumbramiento, value); }
		}
		  
		[XmlAttribute("FechaPrimerControlPuerperio")]
		[Bindable(true)]
		public DateTime? FechaPrimerControlPuerperio 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaPrimerControlPuerperio); }
			set { SetColumnValue(Columns.FechaPrimerControlPuerperio, value); }
		}
		  
		[XmlAttribute("NotaPrimerControlPuerperio")]
		[Bindable(true)]
		public string NotaPrimerControlPuerperio 
		{
			get { return GetColumnValue<string>(Columns.NotaPrimerControlPuerperio); }
			set { SetColumnValue(Columns.NotaPrimerControlPuerperio, value); }
		}
		  
		[XmlAttribute("FechaSegundoControlPuerperio")]
		[Bindable(true)]
		public DateTime? FechaSegundoControlPuerperio 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaSegundoControlPuerperio); }
			set { SetColumnValue(Columns.FechaSegundoControlPuerperio, value); }
		}
		  
		[XmlAttribute("NotaSegundoControlPuerperio")]
		[Bindable(true)]
		public string NotaSegundoControlPuerperio 
		{
			get { return GetColumnValue<string>(Columns.NotaSegundoControlPuerperio); }
			set { SetColumnValue(Columns.NotaSegundoControlPuerperio, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("Activa")]
		[Bindable(true)]
		public bool Activa 
		{
			get { return GetColumnValue<bool>(Columns.Activa); }
			set { SetColumnValue(Columns.Activa, value); }
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
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
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
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int? IdProfesional 
		{
			get { return GetColumnValue<int?>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this AprPartoProvisorio
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorParto); }
			set { SetColumnValue("idEfectorParto", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a AprHistoriaClinicaPerinatal ActiveRecord object related to this AprPartoProvisorio
		/// 
		/// </summary>
		public DalSic.AprHistoriaClinicaPerinatal AprHistoriaClinicaPerinatal
		{
			get { return DalSic.AprHistoriaClinicaPerinatal.FetchByID(this.IdHistoriaClinicaPerinatal); }
			set { SetColumnValue("idHistoriaClinicaPerinatal", value.IdHistoriaClinicaPerinatal); }
		}
		
		
		/// <summary>
		/// Returns a AprTerminacionParto ActiveRecord object related to this AprPartoProvisorio
		/// 
		/// </summary>
		public DalSic.AprTerminacionParto AprTerminacionParto
		{
			get { return DalSic.AprTerminacionParto.FetchByID(this.IdTerminacionParto); }
			set { SetColumnValue("idTerminacionParto", value.IdTerminacionParto); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this AprPartoProvisorio
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a AprTipoParto ActiveRecord object related to this AprPartoProvisorio
		/// 
		/// </summary>
		public DalSic.AprTipoParto AprTipoParto
		{
			get { return DalSic.AprTipoParto.FetchByID(this.IdTerminacionParto); }
			set { SetColumnValue("idTerminacionParto", value.IdTipoParto); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEfectorParto,int varIdPaciente,int? varIdHistoriaClinicaPerinatal,bool? varParto,DateTime? varFechaNacimiento,int? varIdTerminacionParto,decimal? varEdadGestacional,int? varPeso,int? varAPGAR1,int? varAPGAR5,bool? varManejoActivoAlumbramiento,DateTime? varFechaPrimerControlPuerperio,string varNotaPrimerControlPuerperio,DateTime? varFechaSegundoControlPuerperio,string varNotaSegundoControlPuerperio,string varObservaciones,bool varActiva,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdProfesional)
		{
			AprPartoProvisorio item = new AprPartoProvisorio();
			
			item.IdEfectorParto = varIdEfectorParto;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdHistoriaClinicaPerinatal = varIdHistoriaClinicaPerinatal;
			
			item.Parto = varParto;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.IdTerminacionParto = varIdTerminacionParto;
			
			item.EdadGestacional = varEdadGestacional;
			
			item.Peso = varPeso;
			
			item.APGAR1 = varAPGAR1;
			
			item.APGAR5 = varAPGAR5;
			
			item.ManejoActivoAlumbramiento = varManejoActivoAlumbramiento;
			
			item.FechaPrimerControlPuerperio = varFechaPrimerControlPuerperio;
			
			item.NotaPrimerControlPuerperio = varNotaPrimerControlPuerperio;
			
			item.FechaSegundoControlPuerperio = varFechaSegundoControlPuerperio;
			
			item.NotaSegundoControlPuerperio = varNotaSegundoControlPuerperio;
			
			item.Observaciones = varObservaciones;
			
			item.Activa = varActiva;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.IdProfesional = varIdProfesional;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdParto,int? varIdEfectorParto,int varIdPaciente,int? varIdHistoriaClinicaPerinatal,bool? varParto,DateTime? varFechaNacimiento,int? varIdTerminacionParto,decimal? varEdadGestacional,int? varPeso,int? varAPGAR1,int? varAPGAR5,bool? varManejoActivoAlumbramiento,DateTime? varFechaPrimerControlPuerperio,string varNotaPrimerControlPuerperio,DateTime? varFechaSegundoControlPuerperio,string varNotaSegundoControlPuerperio,string varObservaciones,bool varActiva,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdProfesional)
		{
			AprPartoProvisorio item = new AprPartoProvisorio();
			
				item.IdParto = varIdParto;
			
				item.IdEfectorParto = varIdEfectorParto;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdHistoriaClinicaPerinatal = varIdHistoriaClinicaPerinatal;
			
				item.Parto = varParto;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.IdTerminacionParto = varIdTerminacionParto;
			
				item.EdadGestacional = varEdadGestacional;
			
				item.Peso = varPeso;
			
				item.APGAR1 = varAPGAR1;
			
				item.APGAR5 = varAPGAR5;
			
				item.ManejoActivoAlumbramiento = varManejoActivoAlumbramiento;
			
				item.FechaPrimerControlPuerperio = varFechaPrimerControlPuerperio;
			
				item.NotaPrimerControlPuerperio = varNotaPrimerControlPuerperio;
			
				item.FechaSegundoControlPuerperio = varFechaSegundoControlPuerperio;
			
				item.NotaSegundoControlPuerperio = varNotaSegundoControlPuerperio;
			
				item.Observaciones = varObservaciones;
			
				item.Activa = varActiva;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.IdProfesional = varIdProfesional;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPartoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorPartoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdHistoriaClinicaPerinatalColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PartoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTerminacionPartoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadGestacionalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn APGAR1Column
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn APGAR5Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ManejoActivoAlumbramientoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPrimerControlPuerperioColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn NotaPrimerControlPuerperioColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaSegundoControlPuerperioColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn NotaSegundoControlPuerperioColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdParto = @"idParto";
			 public static string IdEfectorParto = @"idEfectorParto";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdHistoriaClinicaPerinatal = @"idHistoriaClinicaPerinatal";
			 public static string Parto = @"parto";
			 public static string FechaNacimiento = @"fechaNacimiento";
			 public static string IdTerminacionParto = @"idTerminacionParto";
			 public static string EdadGestacional = @"edadGestacional";
			 public static string Peso = @"peso";
			 public static string APGAR1 = @"APGAR1";
			 public static string APGAR5 = @"APGAR5";
			 public static string ManejoActivoAlumbramiento = @"manejoActivoAlumbramiento";
			 public static string FechaPrimerControlPuerperio = @"fechaPrimerControlPuerperio";
			 public static string NotaPrimerControlPuerperio = @"NotaPrimerControlPuerperio";
			 public static string FechaSegundoControlPuerperio = @"fechaSegundoControlPuerperio";
			 public static string NotaSegundoControlPuerperio = @"NotaSegundoControlPuerperio";
			 public static string Observaciones = @"observaciones";
			 public static string Activa = @"activa";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string IdProfesional = @"idProfesional";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
